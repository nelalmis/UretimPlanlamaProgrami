using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace uretimPlanlamaProgrami
{
   
    public partial class frmUrunDuzenle : Form
    {

        SqlConnection conn = new SqlConnection("Server=VAIO\\SQLEXPRESS;Database=Planlama; Integrated Security=true; MultipleActiveResultSets=true");
        public frmUrunDuzenle()
        {
            InitializeComponent();
        }
        ses s = new ses();
        private void frmUrunDuzenle_Load(object sender, EventArgs e)
        {
            conn.Open();
            // TODO: This line of code loads data into the 'planlamaDataSet2.urunler' table. You can move, or remove it, as needed.
            
            // TODO: This line of code loads data into the 'planlamaDataSet1.urunler' table. You can move, or remove it, as needed.
            pnlGuncelleme.Visible = false;
           
            lblFire.Text = "";
            lblKod.Text = "";
            lblHiz.Text = "";
            lblGramaj.Text = "";
           
            kayitGetir2();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            kayitGetir();
        }

        private void kayitGetir()
        {
            int satirSayisi;
            SqlCommand ara = new SqlCommand("select id,kod,hizi,gramaj,fireMiktari,resim from urunler where kod like '"+textBox1.Text+"%'",conn);
            SqlDataAdapter da = new SqlDataAdapter(ara);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            satirSayisi = dataGridView1.RowCount ;
            if (satirSayisi > 0)
            {
                lblDurum.Text = satirSayisi + "  adet Ürün listelendi...";
                lblDurum.ForeColor = Color.LimeGreen;
            }
            else
            {
                lblDurum.Text = "Aranan koda ait kayıtlı bir Ürün bulunamadı!";
                lblDurum.ForeColor = Color.Red;

            }
        
        }
        private void kayitGetir2()
        {
            int satirSayisi;
            //tüm kayıtlar
            SqlCommand ara = new SqlCommand("select id,kod,hizi,gramaj,fireMiktari,resim from urunler", conn);
            SqlDataAdapter da = new SqlDataAdapter(ara);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            satirSayisi = dataGridView1.RowCount;
            if (satirSayisi > 0)
            {
                lblDurum.Text = satirSayisi + "   adet Ürün listelendi...";
                lblDurum.ForeColor = Color.LimeGreen;
            }
            else {
                lblDurum.Text = "Sisteme kayıtlı Ürün yok!";
                lblDurum.ForeColor = Color.Red;
                
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
           
            kayitGetir();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            kayitGetir2();
          

            
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            veritabani.baglan();
            DialogResult cevap;
             string urunKod=dataGridView1.CurrentRow.Cells[1].Value.ToString();
            SqlCommand sor = new SqlCommand("select count(urunKod) from siparis where devamDurumu!=2 and urunKod='"+urunKod+"' ",veritabani.conn);
            int sayi = Convert.ToInt32(sor.ExecuteScalar());
            if (sayi == 0)
            {


                cevap = MessageBox.Show("Kaydı silmek istediğinizden emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (cevap == DialogResult.Yes)
                {


                    SqlCommand sill = new SqlCommand("delete from urunUretimHatlari where urunKod='" + urunKod+ "'", conn);
                    sill.ExecuteNonQuery();
                    SqlCommand sil = new SqlCommand("delete from urunler where id='" + dataGridView1.CurrentRow.Cells[0].Value + "'", conn);
                    sil.ExecuteNonQuery();
                    kayitGetir2();
                    s.onay_sesi();
                    MessageBox.Show("Kayıt başarıyla silindi!", "BİLGİ", MessageBoxButtons.OK);

                }
            }
            else {
                MessageBox.Show("Ürün kullanıldığından dolayı silinemez!","HATA",MessageBoxButtons.OK,MessageBoxIcon.Error);
            
            }
            veritabani.baglantiyiKes();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            pnlGuncelleme.Visible = true;
            txtUrunKod.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtUrunHiz.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtGramaj.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtFireMiktari.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();


        }

        private void frmUrunDuzenle_FormClosed(object sender, FormClosedEventArgs e)
        {
            conn.Close();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
          
            listHatlar.Items.Clear();
            veritabani.baglan();
            string urunKod=dataGridView1.CurrentRow.Cells[1].Value.ToString();
            SqlCommand sor = new SqlCommand("select HatNo from urunler u,urunUretimHatlari h where u.kod=h.urunKod and urunKod='"+urunKod+"'",veritabani.conn);
            SqlDataReader oku = sor.ExecuteReader();
            while(oku.Read()){
               
                     listHatlar.Items.Add("HAT-"+oku["HatNo"].ToString());
            
            }

            listBOxDoldur();

            cellMouseClick();


        }
        private void cellMouseClick(){

            
            lblKod.Text=dataGridView1.CurrentRow.Cells[1].Value.ToString();
            lblHiz.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString()+"  m/dk" ;
            lblGramaj.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString()+" gr/m";
            lblFire.Text ="%"+ dataGridView1.CurrentRow.Cells[4].Value.ToString();
            
        
        }

        private void btnPanaldeGuncelle_Click(object sender, EventArgs e)
        {
            bool yapilsinmi;
            yapilsinmi = urunGuncelle();
            
            if (yapilsinmi)
            {
                DialogResult cevap;

                cevap = MessageBox.Show("Kaydı güncellemek istediğinizden emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes)
                {
                    FileStream fs = new FileStream(resim, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);

                    byte[] resimm = br.ReadBytes((int)fs.Length);

                    br.Close();

                    fs.Close();

                    SqlCommand guncelle = new SqlCommand("update urunler set kod='" + txtUrunKod.Text + "', hizi='" + txtUrunHiz.Text + "', gramaj='" + txtGramaj.Text + "', fireMiktari='" + txtFireMiktari.Text + "',resim=@image  where id='" + dataGridView1.CurrentRow.Cells[0].Value + "'", conn);
                    guncelle.Parameters.Add("@image", SqlDbType.Image, resimm.Length).Value = resimm;
                    guncelle.ExecuteNonQuery();
                    
                    kayitGetir2();
                    s.onay_sesi();
                    MessageBox.Show("Kayıt başarıyla güncellendi!", "BİLGİ", MessageBoxButtons.OK);
                    pnlGuncelleme.Visible = false;

                }
            }
        }

        private void btnPnlKapat_Click(object sender, EventArgs e)
        {
            pnlGuncelleme.Visible = false;
        }

        private bool urunGuncelle() {
            bool durum = false;
            string urunKodu=dataGridView1.CurrentRow.Cells[1].Value.ToString();
                //sipariş devam eden sipariş varsa güncelleme işlmei yapılmayaca
            //sadece bekleyenlerde yapılacak;
            //bu değişikliklerden etkilenen siparişleri alacaz.
            veritabani.baglan();
            SqlCommand sor = new SqlCommand("select top 1 bitisTarihi from hatBitisTarih ht,urunler u,urunUretimHatlari ur where u.kod=ur.urunKod and ur.HatNo=ht.hatNo and kod='"+urunKodu+"' order by bitisTarihi desc", veritabani.conn);
            SqlDataReader oku = sor.ExecuteReader();

            if (oku.Read())
            {
                if (oku["bitisTarihi"].ToString()!="")
                {
                    s.hata_sesi();
                    MessageBox.Show("Bu ürünü kullanmak için sisteme kayıtlı siparişler bulunduğu için güncelleme işlemi yapılamamaktadır! En yakın güncelleme tarihi '" + oku["bitisTarihi"].ToString() + "'");
                    pnlGuncelleme.Visible = false;

                    durum = false;
                }
                else
                    durum = true;
            }
            else {

                //MessageBox.Show("Güncellme");
                durum = true;
            
            }
            return durum;
        
        }

        private void btnhatEkle_Click(object sender, EventArgs e)
        {
            int secili;
            secili = dataGridView1.SelectedRows.Count;
            if (secili == 0)
            {
                s.hata_sesi();
                MessageBox.Show("Lütfen hat eklemek istediğiniz ürünü seçiniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }
            else {
                listBOxDoldur();
                grpEklenecekHatlar.Visible = true;   
  

            
            }
        }
        private void listBOxDoldur()
        {
            string urunKodu = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            listEklenecekHatlar.Items.Clear();
            SqlCommand al = new SqlCommand("select numara from uretimHatti where numara not in(select HatNo from urunler u,urunUretimHatlari h where u.kod=h.urunKod and urunKod='" + urunKodu + "')", conn);
            SqlDataReader oku = al.ExecuteReader();
            while (oku.Read())
            {
                listEklenecekHatlar.Items.Add("HAT-" + oku["numara"]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int toplamhatSayisi = listHatlar.Items.Count;
                string urunKodu = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                DialogResult cevap;
                int hatno = Convert.ToInt16(listHatlar.SelectedItem.ToString().Substring(4));
                cevap = MessageBox.Show("Seçili Hattı,Üründen silmek istediğinizden emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes)
                {

                    if (toplamhatSayisi > 1)
                    {

                        SqlCommand sor = new SqlCommand("select count(urunKod) from siparis where devamDurumu!=2 and kullanilacakHat='" + hatno + "' and urunKod='" + urunKodu + "'", veritabani.conn);
                        int sayi = Convert.ToInt32(sor.ExecuteScalar());
                        if (sayi == 0)
                        {
                            SqlCommand deleteUrunHat = new SqlCommand("delete from urunUretimHatlari where urunKod='" + urunKodu + "' and HatNo='" + hatno + "'", veritabani.conn);
                            deleteUrunHat.ExecuteNonQuery();
                            listEklenecekHatlar.Items.Add("HAT-" + hatno.ToString());
                            listHatlar.Items.Remove("HAT-" + hatno.ToString());
                            s.onay_sesi();
                            MessageBox.Show("Seçi hat ilgili üründen silindi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            s.hata_sesi();
                            MessageBox.Show("Bu hat kullanıldığından dolayı silinemedi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    else
                    {
                        s.hata_sesi();
                        MessageBox.Show("En az bir hat ürüne kayıtlı olmalı.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }


                }
            }catch(Exception){
            
            }
             
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult cevap;
            string urunKodu = dataGridView1.CurrentRow.Cells[1].Value.ToString();
              cevap = MessageBox.Show("Seçili Hattı ürüne  eklemek istediğinizden emin misiniz ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
              if (cevap == DialogResult.Yes)
              {
                  int[] dizi = new int[listEklenecekHatlar.SelectedItems.Count];
                  int i = 0;
                  foreach (object listItem in listEklenecekHatlar.SelectedItems)
                  {
                      dizi[i++] = Convert.ToInt16(listItem.ToString().Substring(4));

                  }
                  for (i = 0; i < listEklenecekHatlar.SelectedItems.Count; i++)
                  {

                      SqlCommand insertUrunHat = new SqlCommand("insert into urunUretimHatlari(urunKod,HatNo) values('" +urunKodu+ "'," + dizi[i] + ")", conn);
                      insertUrunHat.ExecuteNonQuery();
                      s.onay_sesi();
                      listHatlar.Items.Add("HAT-" + dizi[i].ToString());
                    
                      listEklenecekHatlar.Items.Remove("HAT-" + dizi[i].ToString());


                  }
                 

              }

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            cellMouseClick();
        }
        string resim = string.Empty;
        private void button4_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Resim Aç";


            openFileDialog1.Filter = "Jpeg Dosyası (*.jpg)|*.jpg";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pr.Image = Image.FromFile(openFileDialog1.FileName);
                resim = openFileDialog1.FileName.ToString();

            }
        }
        frmUrunResmi urunResimGorm;
        private void lblUrunREsmiGor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Image urunResim = null;
            veritabani.baglan();
            SqlCommand urunResmi = new SqlCommand("select resim from urunler where kod='" + lblKod.Text + "'", veritabani.conn);
            SqlDataReader urunResmiOku = urunResmi.ExecuteReader();
            if (urunResmiOku.Read())
            {

                byte[] resim = (byte[])urunResmiOku["resim"];
                MemoryStream ms = new MemoryStream(resim, 0, resim.Length);
                ms.Write(resim, 0, resim.Length);
                urunResim = Image.FromStream(ms, true);

                if (urunResimGorm == null || urunResimGorm.IsDisposed)
                {

                    urunResimGorm = new frmUrunResmi(urunResim);

                    urunResimGorm.Show();
                }
                else
                    MessageBox.Show("Ürün Resmi açık durumda!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);



            }
        }

    }
}
