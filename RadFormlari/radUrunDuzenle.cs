using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using uretimPlanlamaProgrami.RadFormlari;

namespace uretimPlanlamaProgrami.Rad_Formlari
{
    public partial class radUrunDuzenle : Telerik.WinControls.UI.RadForm
    {
        public radUrunDuzenle()
        {
            InitializeComponent();
        }
        ses s = new ses();
        private void radUrunDuzenle_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'genelDataSet.uretimHatti' table. You can move, or remove it, as needed.
            this.uretimHattiTableAdapter.Fill(this.genelDataSet.uretimHatti);
            // TODO: This line of code loads data into the 'genelDataSet.urunler' table. You can move, or remove it, as needed.
            this.urunlerTableAdapter.Fill(this.genelDataSet.urunler);
            pnlGuncelleme.Visible = false;
            radAyrintilar.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnPnlKapat_Click(object sender, EventArgs e)
        {
            pnlGuncelleme.Visible = false;



        }

        private void btnPanaldeGuncelle_Click(object sender, EventArgs e)
        {

        }
        string resim = string.Empty;
        bool degisti;
       

        private void button2_Click(object sender, EventArgs e)
        {

        }
        radUrunResmiGor urunResimGorm;
        radUrunResimFormu radUrunResimFormu;
        private void lblUrunREsmiGor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
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


                    if (radUrunResimFormu == null || radUrunResimFormu.IsDisposed)
                    {

                        radUrunResimFormu = new radUrunResimFormu(urunResim);

                        radUrunResimFormu.Show();
                    }
                    else
                        MessageBox.Show("Ürün Resmi açık durumda!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);




                }
            }catch(Exception ex){
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hata.hataKodu = "radUrunDuzenle-lblUrunREsmiGor_LinkClicked";
                hata.hataMesajı = ex.Message;
                hata.hataMesajiKaydet();
                
            }
        }

      
       

       

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAra_Click(object sender, EventArgs e)
        {

        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            pnlGuncelleme.Visible = true;
            try
            {
                Image urunResim;
                byte[] resim = (byte[])radGridView1.CurrentRow.Cells[5].Value;
                MemoryStream ms = new MemoryStream(resim, 0, resim.Length);
                ms.Write(resim, 0, resim.Length);
                urunResim = Image.FromStream(ms, true);
                txtUrunKod.Text = radGridView1.CurrentRow.Cells[1].Value.ToString();
                txtUrunHiz.Text = radGridView1.CurrentRow.Cells[2].Value.ToString();
                txtGramaj.Text = radGridView1.CurrentRow.Cells[3].Value.ToString();
                txtFireMiktari.Text = radGridView1.CurrentRow.Cells[4].Value.ToString();
                pr.Image = urunResim;
            }catch{
                
            
            }
        }
        hatalar hata = new hatalar();
        private void listBOxDoldur()
        {
            try
            {
                veritabani.baglan();
                string urunKodu = radGridView1.CurrentRow.Cells[1].Value.ToString();
                listEklenecekHatlar.Items.Clear();
                SqlCommand al = new SqlCommand("select numara from uretimHatti where numara not in(select HatNo from urunler u,urunUretimHatlari h where u.kod=h.urunKod and urunKod='" + urunKodu + "')", veritabani.conn);
                SqlDataReader oku = al.ExecuteReader();
                while (oku.Read())
                {
                    listEklenecekHatlar.Items.Add("HAT-" + oku["numara"]);
                }
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hata.hataKodu = "radUrunDuzenle listBOxDoldur";
                hata.hataMesajı = ex.Message;
                hata.hataMesajiKaydet();
                
            
            }
        }
        private void cellMouseClick()
        {

            radAyrintilar.Visible = true;
            lblKod.Text = radGridView1.CurrentRow.Cells[1].Value.ToString();
            lblHiz.Text = radGridView1.CurrentRow.Cells[2].Value.ToString() + "  m/dk";
            lblGramaj.Text = radGridView1.CurrentRow.Cells[3].Value.ToString() + " gr/m";
            lblFire.Text = "%" + radGridView1.CurrentRow.Cells[4].Value.ToString();


        }

        private void radGridView1_CommandCellClick(object sender, EventArgs e)
        {
           
        }

        private void radGridView1_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                listHatlar.Items.Clear();
                veritabani.baglan();
                string urunKod = radGridView1.CurrentRow.Cells[1].Value.ToString();
                SqlCommand sor = new SqlCommand("select HatNo from urunler u,urunUretimHatlari h where u.kod=h.urunKod and urunKod='" + urunKod + "'", veritabani.conn);
                SqlDataReader oku = sor.ExecuteReader();
                while (oku.Read())
                {

                    listHatlar.Items.Add("HAT-" + oku["HatNo"].ToString());

                }
                cellMouseClick();
                listBOxDoldur();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hata.hataKodu = "radUrunDuzenle-radGridView1_CellClick";
                hata.hataMesajı = ex.Message;
                hata.hataMesajiKaydet();

            }
        }
        
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
           
            bool yapilsinmi;
            yapilsinmi = urunGuncelle();
            DialogResult cevap;
            SqlCommand guncelle;
            if (yapilsinmi)
            {
                
                cevap = MessageBox.Show("Kaydı güncellemek istediğinizden emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes)
                {
                    try
                    {
                        if (degisti)
                        {

                            byte[] resimm;

                            FileStream fs = new FileStream(resim, FileMode.Open, FileAccess.Read);
                            BinaryReader br = new BinaryReader(fs);

                            resimm = br.ReadBytes((int)fs.Length);

                            br.Close();

                            fs.Close();
                            guncelle = new SqlCommand("update urunler set kod='" + txtUrunKod.Text + "', hizi='" + txtUrunHiz.Text + "', gramaj='" + txtGramaj.Text + "', fireMiktari='" + txtFireMiktari.Text + "',resim=@image  where id='" + radGridView1.CurrentRow.Cells[0].Value + "'", veritabani.conn);
                            guncelle.Parameters.Add("@image", SqlDbType.Image, resimm.Length).Value = resimm;
                        }
                        else
                        {

                            guncelle = new SqlCommand("update urunler set kod='" + txtUrunKod.Text + "', hizi='" + txtUrunHiz.Text + "', gramaj='" + txtGramaj.Text + "', fireMiktari='" + txtFireMiktari.Text + "'  where id='" + radGridView1.CurrentRow.Cells[0].Value + "'", veritabani.conn);
                        }
                        guncelle.ExecuteNonQuery();


                        s.onay_sesi();
                        MessageBox.Show("Kayıt başarıyla güncellendi!", "BİLGİ", MessageBoxButtons.OK);
                        radGridView1.Refresh();
                        this.urunlerTableAdapter.Fill(this.genelDataSet.urunler);
                        pnlGuncelleme.Visible = false;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        hata.hataKodu = "radUrunDuzenle-btnGuncelle_Click";
                        hata.hataMesajı = ex.Message;
                        hata.hataMesajiKaydet();

                    }
                }
            }
            
         
        
            else if (degisti)
            {

                cevap = MessageBox.Show("Sadece resim bilgisi güncellenecek?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes)
                {
                    try
                    {
                        FileStream fs = new FileStream(resim, FileMode.Open, FileAccess.Read);
                        BinaryReader br = new BinaryReader(fs);

                        byte[] resimm = br.ReadBytes((int)fs.Length);

                        br.Close();

                        fs.Close();
                        guncelle = new SqlCommand("update urunler set resim=@image  where id='" + radGridView1.CurrentRow.Cells[0].Value + "'", veritabani.conn);
                        guncelle.Parameters.Add("@image", SqlDbType.Image, resimm.Length).Value = resimm;
                        guncelle.ExecuteNonQuery();


                        s.onay_sesi();
                        MessageBox.Show("Ürün resmi başarıyla güncellendi!", "BİLGİ", MessageBoxButtons.OK);
                        radGridView1.Refresh();
                        this.urunlerTableAdapter.Fill(this.genelDataSet.urunler);
                        pnlGuncelleme.Visible = false;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        hata.hataKodu = "radUrunDuzenle-btnGuncelle_Click";
                        hata.hataMesajı = ex.Message;
                        hata.hataMesajiKaydet();

                    }

                }
            }
            else
                pnlGuncelleme.Visible = false;
        }
        private bool urunGuncelle()
        {
            bool durum = false;
            string urunKodu = radGridView1.CurrentRow.Cells[1].Value.ToString();
            //sipariş devam eden sipariş varsa güncelleme işlmei yapılmayaca
            //sadece bekleyenlerde yapılacak;
            //bu değişikliklerden etkilenen siparişleri alacaz.
            veritabani.baglan();
            //SqlCommand sor = new SqlCommand("select top 1 bitisTarihi from hatBitisTarih ht,urunler u,urunUretimHatlari ur where u.kod=ur.urunKod and ur.HatNo=ht.hatNo and kod='" + urunKodu + "' order by bitisTarihi desc", veritabani.conn);
            try
            {
                SqlCommand sor = new SqlCommand("select top 1 bitisTarihi from siparis where urunKod='" + urunKodu + "' and (devamDurumu=1 or devamDurumu=3) order by bitisTarihi desc", veritabani.conn);
                SqlDataReader oku = sor.ExecuteReader();

                if (oku.Read())
                {
                    if (oku["bitisTarihi"].ToString() != "")
                    {
                        s.hata_sesi();

                        MessageBox.Show("Bu ürünü kullanmak için sisteme kayıtlı siparişler bulunduğu için güncelleme işlemi yapılamamaktadır! En yakın güncelleme tarihi '" + oku["bitisTarihi"].ToString() + "'");

                        durum = false;
                    }
                    else
                        durum = true;
                }
                else
                    durum = true;


                return durum;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hata.hataKodu = "radUrunDuzenle-urunGuncelle";
                hata.hataMesajı = ex.Message;
                hata.hataMesajiKaydet();
                return false;

            }
        }
        private void btnMevcutlar_Click(object sender, EventArgs e)
        {
            try
            {
                int toplamhatSayisi = listHatlar.Items.Count;
                string urunKodu = radGridView1.CurrentRow.Cells[1].Value.ToString();
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hata.hataKodu = "radUrunDuzenle-btnMevcutlar_Click";
                hata.hataMesajı = ex.Message;
                hata.hataMesajiKaydet();

            }
             
        }
        
        private void btnHatekle_Click(object sender, EventArgs e)
        {
            DialogResult cevap;
            string urunKodu = radGridView1.CurrentRow.Cells[1].Value.ToString();
            cevap = MessageBox.Show("Seçili Hattı ürüne  eklemek istediğinizden emin misiniz ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes)
            {
                try
                {
                    int[] dizi = new int[listEklenecekHatlar.SelectedItems.Count];
                    int i = 0;
                    foreach (object listItem in listEklenecekHatlar.SelectedItems)
                    {
                        dizi[i++] = Convert.ToInt16(listItem.ToString().Substring(4));

                    }
                    for (i = 0; i < listEklenecekHatlar.SelectedItems.Count; i++)
                    {

                        SqlCommand insertUrunHat = new SqlCommand("insert into urunUretimHatlari(urunKod,HatNo) values('" + urunKodu + "'," + dizi[i] + ")", veritabani.conn);
                        insertUrunHat.ExecuteNonQuery();
                        s.onay_sesi();
                        listHatlar.Items.Add("HAT-" + dizi[i].ToString());

                        listEklenecekHatlar.Items.Remove("HAT-" + dizi[i].ToString());


                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    hata.hataKodu = "radUrunDuzenle-btnHatekle_Click";
                    hata.hataMesajı = ex.Message;
                    hata.hataMesajiKaydet();

                }
            }
        }

        private void btnSil_Click_1(object sender, EventArgs e)
        {
            
                veritabani.baglan();
                DialogResult cevap;
                string urunKod = radGridView1.CurrentRow.Cells[1].Value.ToString();
                SqlCommand sor = new SqlCommand("select count(urunKod) from siparis where devamDurumu!=2 and urunKod='" + urunKod + "' ", veritabani.conn);
                int sayi = Convert.ToInt32(sor.ExecuteScalar());
                if (sayi == 0)
                {


                    cevap = MessageBox.Show("Kaydı silmek istediğinizden emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (cevap == DialogResult.Yes)
                    {

                        try
                        {
                            SqlCommand sill = new SqlCommand("delete from urunUretimHatlari where urunKod='" + urunKod + "'", veritabani.conn);
                            sill.ExecuteNonQuery();

                            SqlCommand sil2 = new SqlCommand("delete from urunRapor where urunKod='" + urunKod + "'", veritabani.conn);
                            sil2.ExecuteNonQuery();
                            SqlCommand sil = new SqlCommand("delete from urunler where id='" + radGridView1.CurrentRow.Cells[0].Value + "'", veritabani.conn);
                            sil.ExecuteNonQuery();
                            s.onay_sesi();
                            MessageBox.Show("Kayıt başarıyla silindi!", "BİLGİ", MessageBoxButtons.OK);
                            radGridView1.Rows.Remove(radGridView1.CurrentRow);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            hata.hataKodu = "radUrunDuzenle-btnSil_Click_1";
                            hata.hataMesajı = ex.Message;
                            hata.hataMesajiKaydet();

                        }
                    }
                }
                else
                {
                    MessageBox.Show("Ürün kullanıldığından dolayı silinemez!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            
            
            veritabani.baglantiyiKes();
        }
    
        private void btnResimsec_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Title = "Resim Aç";
                openFileDialog1.FileName = "";

                openFileDialog1.Filter = "Jpeg Dosyası (*.jpg)|*.jpg";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    pr.Image = Image.FromFile(openFileDialog1.FileName);
                    resim = openFileDialog1.FileName.ToString();
                    degisti = true;
                }
                else
                    degisti = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hata.hataKodu = "radUrunDuzenle-btnResimsec_Click";
                hata.hataMesajı = ex.Message;
                hata.hataMesajiKaydet();
                degisti = false;
            }
        }

        private void radGridView1_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
        {
            e.RowElement.RowInfo.Height = 60;
        }
       
    }
}
