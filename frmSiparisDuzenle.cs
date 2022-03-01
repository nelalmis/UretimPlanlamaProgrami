using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using System.IO;
namespace uretimPlanlamaProgrami
{
    public partial class frmSiparisDuzenle : Form
    {
        int deger,gosterilecekKayitSayisi;
       
        public frmSiparisDuzenle()
        {
            
            deger = 0;
            gosterilecekKayitSayisi = 2;
            InitializeComponent();
        }

        
         int indeks;
         DataTable table1 = new DataTable();
         DataTable table2 = new DataTable();
         DataTable table3 = new DataTable();

         DataSet ds;
         SqlDataAdapter da;

        private void frmSiparisDuzenle_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'siparisTabloDataSet.siparis' table. You can move, or remove it, as needed.
           // this.siparisTableAdapter.Fill(this.siparisTabloDataSet.siparis);

            pnlGelismisArama.Visible = false;
                gridDoldur();
             
                SqlCommand hammadde = new SqlCommand("select id,adi from hammadde", veritabani.conn);
                SqlDataAdapter dpp = new SqlDataAdapter(hammadde);
                dpp.Fill(table1);
                cmbHammdde.DataSource = new BindingSource(table1, null);
                cmbHammdde.DisplayMember = "adi";
                cmbHammdde.ValueMember = "id";

                SqlCommand HatNO = new SqlCommand("select numara from uretimHatti", veritabani.conn);
                SqlDataAdapter dbHAt = new SqlDataAdapter(HatNO);
                dbHAt.Fill(table3);
                cmbHatNo.DataSource = new BindingSource(table3, null);
                cmbHatNo.DisplayMember = "numara";
                cmbHatNo.ValueMember = "numara";

                SqlCommand renk = new SqlCommand("select id,kod,renkAdi from renkler", veritabani.conn);
                SqlDataAdapter dprenk = new SqlDataAdapter(renk);
                dprenk.Fill(table2);
                cmbRebk.DataSource = new BindingSource(table2, null);
                cmbRebk.DisplayMember = "renkAdi";
                cmbRebk.ValueMember = "id";
            
            
            if(dataGridView1.RowCount>=1)
             dataGridView1.SelectedRows[0].Selected.Equals(false);
            lbl();
           
        }

        void lbl() {

            lblUrunKod.Text = "";
            lblSiparisKod.Text = "";
            lblFirmaAd.Text = "";
            lblHammadde.Text = "";
            lblOncelik.Text = "";
            lblBoy.Text = "";
            lblAdet.Text = "";
            lblRenk.Text = "";
            lblBasTarihi.Text = "";
            lblBitTarihi.Text = "";

            lblToplamSure.Text = "";
            lblUrunMiktari.Text = "";
            lblHat.Text = "";
            lblDevamDur.Text = "";
            lblKayitTarihi.Text = "";
        
        }
        
        void gridDoldur() {
           
            SqlCommand ara = new SqlCommand("select s.id,urunKod as ÜrünKodu,siparisKod as SiparişKodu,firmaAdi as FirmaAdı,adi as Hammadde,oncelikSirasi as OncelikSırası,boy,adet,renkAdi as renk,baslangicTarihi,bitisTarihi,toplamSure,gerekenUrunMiktari,kullanilacakHat HATNO,durum,kayitTarihi as KayıtTarihi from siparis s,DevamDurumu d,renkler r,hammadde h where r.id=s.renk and s.devamDurumu=d.id and h.id=s.hammadde order by s.id desc", veritabani.conn);
            SqlDataAdapter da = new SqlDataAdapter(ara);
            ds = new DataSet();
            ds.Clear();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];

            dataGridView1.Columns["KayıtTarihi"].DefaultCellStyle.Format = "dd/MM/yyyy hh:ss";
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["baslangicTarihi"].Width = 150;
            dataGridView1.Columns["bitisTarihi"].Width = 150;
            dataGridView1.Columns["renk"].Width = 110;
            dataGridView1.Columns["HATNO"].Width = 60;
            dataGridView1.Columns["durum"].Width = 120;
            dataGridView1.Columns["gerekenUrunMiktari"].Width = 150;
            dataGridView1.Columns["KayıtTarihi"].Width = 150;
            dataGridView1.Columns["boy"].Width = 140;
           
            kacAdetSiparisVar();
            
        
        }
        int satirSayisi;
        void kacAdetSiparisVar() {
            
            satirSayisi = dataGridView1.RowCount ;
            if (satirSayisi > 0)
            {
                lblSonuc.Text = satirSayisi + " adet sipariş listelendi";
                lblSonuc.ForeColor = Color.LimeGreen;
            }
            else
            {
                lblSonuc.Text = "Sistemde sipariş kaydı bulunmamaktadır.";
                lblSonuc.ForeColor = Color.Red;

            }
            
        
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            veritabani.baglan();

                TextBox txt = (sender) as TextBox;
                string aranacakKelime = txtKod.Text;
               
                    kodaGoreAra(aranacakKelime);
               
                   
 

            
        }
        string command;
        public void aramaUrunKodFonksiyonu(string kod,int hangiSiparislerde){
            int satirSayisi;
            if (hangiSiparislerde == 0)
            {
                command = "select s.id,urunKod as ÜrünKodu,siparisKod as SiparişKodu,firmaAdi as FirmaAdı,h.adi as hammadde,oncelikSirasi as OncelikSırası,boy,adet,r.renkAdi as renk,baslangicTarihi,bitisTarihi,toplamSure,gerekenUrunMiktari,kullanilacakHat HATNO,durum,kayitTarihi as KayıtTarihi  from siparis s,DevamDurumu d,renkler r,hammadde h where r.id=s.renk and s.devamDurumu=d.id and h.id=s.hammadde and s.sil=0 and s.urunKod like '" + kod + "%' order by s.id desc";
            }else if(hangiSiparislerde==1)
                command = "select s.id,urunKod as ÜrünKodu,siparisKod as SiparişKodu,firmaAdi as FirmaAdı,h.adi as hammadde,oncelikSirasi as OncelikSırası,boy,adet,r.renkAdi as renk,baslangicTarihi,bitisTarihi,toplamSure,gerekenUrunMiktari,kullanilacakHat HATNO,durum,kayitTarihi as KayıtTarihi  from siparis s,DevamDurumu d, renkler r,hammadde h where r.id=s.renk and s.devamDurumu=d.id and h.id=s.hammadde and s.devamDurumu=1 and s.urunKod like '" + kod + "%' order by s.id desc";
            else if(hangiSiparislerde==2)
                command = "select s.id,urunKod as ÜrünKodu,siparisKod as SiparişKodu,firmaAdi as FirmaAdı,h.adi as hammadde,oncelikSirasi as OncelikSırası,boy,adet,r.renkAdi as renk,baslangicTarihi,bitisTarihi,toplamSure,gerekenUrunMiktari,kullanilacakHat HATNO,durum,kayitTarihi as KayıtTarihi  from siparis s,DevamDurumu d,renkler r,hammadde h where r.id=s.renk and s.devamDurumu=d.id and h.id=s.hammadde and s.devamDurumu=2 and s.urunKod like '" + kod + "%' order by s.id desc";
            else if(hangiSiparislerde==3)
                command = "select s.id,urunKod as ÜrünKodu,siparisKod as SiparişKodu,firmaAdi as FirmaAdı,h.adi as hammadde,oncelikSirasi as OncelikSırası,boy,adet,r.renkAdi as renk,baslangicTarihi,bitisTarihi,toplamSure,gerekenUrunMiktari,kullanilacakHat HATNO,durum,kayitTarihi as KayıtTarihi  from siparis s,DevamDurumu d,renkler r,hammadde h where r.id=s.renk and s.devamDurumu=d.id and h.id=s.hammadde and s.devamDurumu=3 and s.urunKod like '" + kod + "%' order by s.id desc";
            SqlCommand ara=new SqlCommand(command,veritabani.conn);
            da = new SqlDataAdapter(ara);
            ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            satirSayisi = dataGridView1.RowCount ;
            if (satirSayisi > 0)
            {
                lblSonuc.Text = satirSayisi + " adet sipariş listelendi";
                lblSonuc.ForeColor = Color.LimeGreen;
            }
            else
            {
                lblSonuc.Text = "Aranan Ürün koduna ait sipariş kaydı bulunamadı.";
                lblSonuc.ForeColor = Color.Red;

            }


        }
        public void aramaSiparisKodFonksiyonu(string kod,int hangiSiparişlerde) {
            int satirSayisi;
           if(hangiSiparişlerde==0)//tüm sipaişlerde
               command = "select s.id,urunKod as ÜrünKodu,siparisKod as SiparişKodu,firmaAdi as FirmaAdı,h.adi as hammadde,oncelikSirasi as OncelikSırası,boy,adet,r.renkAdi as renk,baslangicTarihi,bitisTarihi,toplamSure,gerekenUrunMiktari,kullanilacakHat HATNO,durum,kayitTarihi as KayıtTarihi  from siparis s,DevamDurumu d, renkler r,hammadde h where r.id=s.renk and s.devamDurumu=d.id and h.id=s.hammadde and s.sil=0 and s.siparisKod like '" + kod + "%' ";
           else if(hangiSiparişlerde==1)
               command = "select s.id,urunKod as ÜrünKodu,siparisKod as SiparişKodu,firmaAdi as FirmaAdı,h.adi as hammadde,oncelikSirasi as OncelikSırası,boy,adet,r.renkAdi as renk,baslangicTarihi,bitisTarihi,toplamSure,gerekenUrunMiktari,kullanilacakHat HATNO,durum,kayitTarihi as KayıtTarihi  from siparis s,DevamDurumu d, renkler r,hammadde h where r.id=s.renk and s.devamDurumu=d.id and h.id=s.hammadde and s.devamDurumu=1 and s.siparisKod like '" + kod + "%'";
            else if(hangiSiparişlerde==2)//bitmişs
               command = "select s.id,urunKod as ÜrünKodu,siparisKod as SiparişKodu,firmaAdi as FirmaAdı,h.adi as hammadde,oncelikSirasi as OncelikSırası,boy,adet,r.renkAdi as renk,baslangicTarihi,bitisTarihi,toplamSure,gerekenUrunMiktari,kullanilacakHat HATNO,durum,kayitTarihi as KayıtTarihi  from siparis s,DevamDurumu d, renkler r,hammadde h where r.id=s.renk and s.devamDurumu=d.id and h.id=s.hammadde and s.devamDurumu=2 and s.siparisKod like '" + kod + "%'";
           else if(hangiSiparişlerde==3)
               command = "select s.id,urunKod as ÜrünKodu,siparisKod as SiparişKodu,firmaAdi as FirmaAdı,h.adi as hammadde,oncelikSirasi as OncelikSırası,boy,adet,r.renkAdi as renk,baslangicTarihi,bitisTarihi,toplamSure,gerekenUrunMiktari,kullanilacakHat HATNO,durum,kayitTarihi as KayıtTarihi  from siparis s,DevamDurumu d, renkler r,hammadde h where r.id=s.renk and s.devamDurumu=d.id and h.id=s.hammadde and s.devamDurumu=3 and s.siparisKod like '" + kod + "%'";

           command += " order by s.id desc";
           SqlCommand ara = new SqlCommand(command,veritabani.conn); 

            SqlDataAdapter da = new SqlDataAdapter(ara);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            satirSayisi = dataGridView1.RowCount - 1;
            if (satirSayisi > 0)
            {
                lblSonuc.Text = satirSayisi + " adet sipariş listelendi";
                lblSonuc.ForeColor = Color.LimeGreen;
            }
            else
            {
                lblSonuc.Text = "Aranan Sipariş koduna ait sipariş kaydı bulunamadı.";
                lblSonuc.ForeColor = Color.Red;

            }

            // SqlCommand ara = new SqlCommand("select s.id,urunKod as ÜrünKodu,siparisKod as SiparişKodu,firmaAdi as FirmaAdı,hammadde,oncelikSirasi as OncelikSırası,boy,adet,renk,baslangicTarihi,bitisTarihi,toplamSure,gerekenUrunMiktari,kullanilacakHat HATNO,durum from siparis s,DevamDurumu d where s.devamDurumu=d.id and sil=0 and siparisKod like '" + kod + "%'", veritabani.conn);
        
        }
        public void aramaUrveSipKodunaGore(int indis) {
            SqlCommand ara = new SqlCommand("select s.id,urunKod as ÜrünKodu,siparisKod as SiparişKodu,firmaAdi as FirmaAdı,h.adi as hammadde,oncelikSirasi as OncelikSırası,boy,adet,r.renkAdi as renk,baslangicTarihi,bitisTarihi,toplamSure,gerekenUrunMiktari,kullanilacakHat HATNO,durum,kayitTarihi as KayıtTarihi  from siparis s,DevamDurumu d, renkler r,hammadde h where r.id=s.renk and s.devamDurumu=d.id and h.id=s.hammadde and siparisBittimi='" + indis + "' and siparisKod like '" + txtKod.Text + "%' and urunKod like '" + txtKod.Text + "%' order by s.id desc", veritabani.conn);
            da = new SqlDataAdapter(ara);
            ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            dataGridView1.DataSource = ds;
        
        }
        int kodSec;
        bool com;

        public void kodaGoreAra(string aranacakKelime) {
            if (aranacakKelime != "")
            {
                indeks = comboBox2.SelectedIndex;
                kodSec = cmbKodSec.SelectedIndex;
                /*kodsec 0 Sipariş kodu
                 * kodsec 1 ürün kodu
                */
                if (kodSec == -1)
                {
                    MessageBox.Show("Lütfen arama yapmak istediğiniz kod türünü seçin!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (kodSec == 1)
                {//ürün Kodu
                    aramaUrunKodFonksiyonu(aranacakKelime, indeks);

                }
                else if (kodSec == 0)//tüm siparişler sipariş kodu ile
                {
                    //siparis koduna göre tamamlanan
                    aramaSiparisKodFonksiyonu(aranacakKelime,indeks);

                }
              

            }
            else
            {
               


                if (indeks == 0 || indeks==-1)
                {
                    
                    gridDoldur();
                    kacAdetSiparisVar();
                    com = false;
                    //arama yapılmaz
                }
                else if (indeks == 1)
                {
                    command = "select s.id,urunKod as ÜrünKodu,siparisKod as SiparişKodu,firmaAdi as FirmaAdı,h.adi as hammadde,oncelikSirasi as OncelikSırası,boy,adet,r.renkAdi as renk,baslangicTarihi,bitisTarihi,toplamSure,gerekenUrunMiktari,kullanilacakHat HATNO,durum,kayitTarihi as KayıtTarihi  from siparis s,DevamDurumu d , renkler r,hammadde h where r.id=s.renk and s.devamDurumu=d.id and h.id=s.hammadde and devamDurumu=1";
                    com = true;
                }
                else if (indeks == 3) {
                    command = "select s.id,urunKod as ÜrünKodu,siparisKod as SiparişKodu,firmaAdi as FirmaAdı,h.adi as hammadde,oncelikSirasi as OncelikSırası,boy,adet,r.renkAdi as renk,baslangicTarihi,bitisTarihi,toplamSure,gerekenUrunMiktari,kullanilacakHat HATNO,durum,kayitTarihi as KayıtTarihi  from siparis s,DevamDurumu d , renkler r,hammadde h where r.id=s.renk and s.devamDurumu=d.id and h.id=s.hammadde and devamDurumu=3";

                    com = true;
                }

                else if(indeks==2)
                {
                    command = "select s.id,urunKod as ÜrünKodu,siparisKod as SiparişKodu,firmaAdi as FirmaAdı,h.adi as hammadde,oncelikSirasi as OncelikSırası,boy,adet,r.renkAdi as renk,baslangicTarihi,bitisTarihi,toplamSure,gerekenUrunMiktari,kullanilacakHat HATNO,durum,kayitTarihi as KayıtTarihi  from siparis s,DevamDurumu d, renkler r,hammadde h where r.id=s.renk and s.devamDurumu=d.id and h.id=s.hammadde and devamDurumu=2";
                    com = true;
                }
                if(com){
                    command += " order by s.id desc";
                    SqlCommand ara = new SqlCommand(command, veritabani.conn);
                    da = new SqlDataAdapter(ara);
                    ds = new DataSet();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds;
                    kacAdetSiparisVar();
                     }

            }
        
        }

        private void btnTarihAra_Click(object sender, EventArgs e)
        {

            int yyyy;
            int mm;
            int dd;
            int h;
            int m;
            int se;
            DateTime dtBaslangic = DateTime.Now;
            DateTime dtBitis = DateTime.Now;
            yyyy = dtBaslangic.Year;
            mm = dtBaslangic.Month;
            dd = dtBaslangic.Day;
            h = dtBaslangic.Hour;
            m = dtBaslangic.Minute;
            se = dtBaslangic.Second;

            DateTime tarihBaslangic = new DateTime(yyyy, mm, dd, h, m, se);
            yyyy = dtBitis.Year;
            mm = dtBitis.Month;
            dd = dtBitis.Day;
            h = dtBitis.Hour;
            m = dtBitis.Minute;
            se = dtBitis.Second;
            DateTime tarihBitis = new DateTime(yyyy, mm, dd, h, m, se);


            if (dtBitis < dtBaslangic)
            {
                MessageBox.Show("Bitiş tarihi,başlangıç tarihinden küçük olamaz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else {
                MessageBox.Show("bas "+tarihBaslangic+"   bitis  "+tarihBitis);
                SqlCommand ara = new SqlCommand("select s.id,urunKod as ÜrünKodu,siparisKod as SiparişKodu,firmaAdi as FirmaAdı,h.adi as hammadde,oncelikSirasi as OncelikSırası,boy,adet,r.renkAdi as renk,baslangicTarihi,bitisTarihi,toplamSure,gerekenUrunMiktari,kullanilacakHat HATNO,durum,kayitTarihi as KayıtTarihi  from siparis s,DevamDurumu d, renkler r,hammadde h where r.id=s.renk and s.devamDurumu=d.id and h.id=s.hammadde and baslangictarihi>='" + tarihBaslangic + "' or bitistarihi>='" + tarihBitis + "'", veritabani.conn);
                da = new SqlDataAdapter(ara);
                ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds;
            
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            listelemeKriteri();
            
        }
        public void listelemeKriteri() {
            string command;
            indeks = comboBox2.SelectedIndex;
            switch (indeks)
            {
               
                case 1:
                    command = "select s.id,urunKod as ÜrünKodu,siparisKod as SiparişKodu,firmaAdi as FirmaAdı,h.adi as hammadde,oncelikSirasi as OncelikSırası,boy,adet,r.renkAdi as renk,baslangicTarihi,bitisTarihi,toplamSure,gerekenUrunMiktari,kullanilacakHat HATNO,durum,kayitTarihi as KayıtTarihi  from siparis s,DevamDurumu d, renkler r,hammadde h where r.id=s.renk and s.devamDurumu=d.id and h.id=s.hammadde and s.devamDurumu=1";
                    switchCaseGoreCommandiTetikleyenFonksiyon(command);
                    break;
                case 2:
                    command = "select s.id,urunKod as ÜrünKodu,siparisKod as SiparişKodu,firmaAdi as FirmaAdı,h.adi as hammadde,oncelikSirasi as OncelikSırası,boy,adet,r.renkAdi as renk,baslangicTarihi,bitisTarihi,toplamSure,gerekenUrunMiktari,kullanilacakHat HATNO,durum,kayitTarihi as KayıtTarihi  from siparis s,DevamDurumu d, renkler r,hammadde h where r.id=s.renk and s.devamDurumu=d.id and h.id=s.hammadde and s.devamDurumu=2";
                    switchCaseGoreCommandiTetikleyenFonksiyon(command);
                    break;
                   
                case 3:
                    command = "select s.id,urunKod as ÜrünKodu,siparisKod as SiparişKodu,firmaAdi as FirmaAdı,h.adi as hammadde,oncelikSirasi as OncelikSırası,boy,adet,r.renkAdi as renk,baslangicTarihi,bitisTarihi,toplamSure,gerekenUrunMiktari,kullanilacakHat HATNO,durum,kayitTarihi as KayıtTarihi  from siparis s,DevamDurumu d, renkler r,hammadde h where r.id=s.renk and s.devamDurumu=d.id and h.id=s.hammadde and s.devamDurumu=3";
                    switchCaseGoreCommandiTetikleyenFonksiyon(command);
                    break;
                default: gridDoldur();
                    kacAdetSiparisVar();
                    break;

            }
            
        }
        void switchCaseGoreCommandiTetikleyenFonksiyon(string command) {
            command += " order by s.id desc";
            SqlCommand ara1 = new SqlCommand(command, veritabani.conn);
            da = new SqlDataAdapter(ara1);
            ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            dataGridView1.DataSource = ds;
            kacAdetSiparisVar();
        
        }

        private void btnSiparisSİl_Click(object sender, EventArgs e)
        {
            string devamDurumu;
            veritabani.baglan();
           
            DialogResult cevap;
              int sayi= dataGridView1.SelectedRows.Count;
              if (sayi == 0)
              {
                  MessageBox.Show("Lütfen silmek istediğiniz siparişi seçin.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                  return;
              }else
                    devamDurumu = dataGridView1.CurrentRow.Cells[14].Value.ToString();
             
            if (devamDurumu == "Beklemede" || devamDurumu == "Devam Ediyor...")
            {
                MessageBox.Show("Bu sipariş işleme alındığından dolayı silinemez!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }else 
            {
                cevap = MessageBox.Show("Bu işlem geri alınamaz! Kaydı kalıcı olarak silmek istediğinizden emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (cevap == DialogResult.Yes)
                {

                    SqlCommand sill = new SqlCommand("delete from siparis where id='" + dataGridView1.CurrentRow.Cells[0].Value + "'", veritabani.conn);
                    sill.ExecuteNonQuery();


                    SqlCommand ara = new SqlCommand("select s.id,urunKod as ÜrünKodu,siparisKod as SiparişKodu,firmaAdi as FirmaAdı,h.adi as hammadde,oncelikSirasi as OncelikSırası,boy,adet,r.renkAdi as renk,baslangicTarihi,bitisTarihi,toplamSure,gerekenUrunMiktari,kullanilacakHat HATNO,durum,kayitTarihi as KayıtTarihi  from siparis s,DevamDurumu d, renkler r,hammadde h where r.id=s.renk and s.devamDurumu=d.id and h.id=s.hammadde order by s.id desc", veritabani.conn);


                    gridDoldur();
                    MessageBox.Show("Sipariş kaydı başarıyla silindi!", "BİLGİ", MessageBoxButtons.OK);
                }
            }
        }

        private void btnKodAra_Click(object sender, EventArgs e)
        {
            if (txtKod.Text != "")
                kodaGoreAra(txtKod.Text);
            else
                MessageBox.Show("Aranacak kodu giriniz!","UYARI",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }

       
       

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            CellMouseClick();
            


        }
        void CellMouseClick() {
            if (dataGridView1.RowCount > 0)
            {
                lblUrunKod.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                lblSiparisKod.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                lblFirmaAd.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                lblHammadde.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                lblOncelik.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                lblBoy.Text = String.Format("{0:0,0}",Convert.ToInt32(dataGridView1.CurrentRow.Cells[6].Value))+" Milimetre";
                lblAdet.Text = String.Format("{0:0,0}", Convert.ToInt32(dataGridView1.CurrentRow.Cells[7].Value));
                lblRenk.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();

                lblBasTarihi.Text = String.Format("{0:f}", Convert.ToDateTime(dataGridView1.CurrentRow.Cells[9].Value));
                lblBitTarihi.Text = String.Format("{0:f}", Convert.ToDateTime(dataGridView1.CurrentRow.Cells[10].Value));

                lblToplamSure.Text = String.Format("{0:0,0}",Convert.ToInt32(dataGridView1.CurrentRow.Cells[11].Value)) + " Saat";
                lblUrunMiktari.Text = String.Format("{0:0,0}",Convert.ToInt32(dataGridView1.CurrentRow.Cells[12].Value)) + " Gram";
                lblHat.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
                lblDevamDur.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();
                lblKayitTarihi.Text = String.Format("{0:f}", Convert.ToDateTime(dataGridView1.CurrentRow.Cells[15].Value));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {


        }
       
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnlGelismisArama.Visible = true;
           
            foreach (Control ct in pnlGelismisArama.Controls)
            {
                if (ct is TextBox)
                {
                    ct.Text = "";
                    ct.Enabled = false;
                }
                else if (ct is ComboBox)
                {
                    ct.Enabled = false;
                }
                else if (ct is CheckBox)
                    ((CheckBox)ct).Checked = false;

            }
            grpTarihAraligi.Enabled = false;

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            gridDoldur();

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            CellMouseClick();
        }
        long tumSiparisSayisi;
        int sayfaSayisi;
        void TumSiparisSayi() {
            SqlCommand oku = new SqlCommand("select count(id) from siparis");
            tumSiparisSayisi = Convert.ToInt64( oku.ExecuteScalar());
            sayfaSayisi = (int)tumSiparisSayisi / gosterilecekKayitSayisi;
            sayfaSayisi = sayfaSayisi + 1;
        
        }

        private void btnGelismisArama_Click(object sender, EventArgs e)
        {
            
                fonksyionGelismisArama();
                
            

        }
       
        public void fonksyionGelismisArama()
        {
            string asilSorgu = "select s.id,urunKod as ÜrünKodu,siparisKod as SiparişKodu,firmaAdi as FirmaAdı,adi as Hammadde,oncelikSirasi as OncelikSırası,boy,adet,renkAdi as renk,baslangicTarihi,bitisTarihi,toplamSure,gerekenUrunMiktari,kullanilacakHat HATNO,durum,kayitTarihi as KayıtTarihi from siparis s,DevamDurumu d,renkler r,hammadde h where r.id=s.renk and s.devamDurumu=d.id and h.id=s.hammadde ";
            veritabani.baglan();

            sorgu = "";
                sadeceSiparisKodu();
                sadeceUrunKodu();
         
                sadeceFirmaAdi();
                sadeceHammadde();
                sadeceRenk();
                sadeceHatNo();
                sadeceBoy();
                sadeceAdet();
                sadeceTarihAraligi();
                asilSorgu += sorgu;
                asilSorgu += " ";
                if (sorgulansinMi)
                {
                    asilSorgu += " order by s.id desc";
                    SqlCommand gelismisAra = new SqlCommand(asilSorgu, veritabani.conn);
                    SqlDataAdapter da = new SqlDataAdapter(gelismisAra);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    pnlGelismisArama.Visible = false;
                }

            


        }
        string sorgu = "";
        bool sorgulansinMi = true;
        public void sadeceUrunKodu()
        {
            if (chcUrunKod.Checked)
            {
                if (txtUrunKodd.Text != "")
                {
                    sorgu += " and urunKod=" + txtUrunKodd.Text + "  ";
                    
                }
                else
                {
                    sorgulansinMi = false;
                    toolTip1.Show("Lütfen Ürün kodunu giriniz!", txtUrunKodd);
                   
                }
            }
        }

        public void sadeceSiparisKodu()
        {
            if(chcSiparisKodu.Checked)
                if (txtSiparisKodd.Text != "")
                    sorgu += " and siparisKod='" + txtSiparisKodd.Text + "' ";
                else {
                    sorgulansinMi = false;
                    toolTip1.Show("Lütfen Sipariş kodunu giriniz!", txtSiparisKodd);
                }
                    
        }
        public void sadeceFirmaAdi()
        {
            if(chcFirmaAdi.Checked)
                if (txtFirmaAdi.Text != "")
                    sorgu += " and firmaAdi='" + txtFirmaAdi.Text + "' ";
                else
                {
                    sorgulansinMi = false;
                    toolTip1.Show("Lütfen Firma adını giriniz!", txtFirmaAdi);
                }
        }
        public void sadeceHammadde()
        {
            if (chcHammadde.Checked)
                
            sorgu += " and hammadde=" + Convert.ToInt16(cmbHammdde.SelectedValue) + " ";
        }
        public void sadeceRenk()
        {
            if (chcRenk.Checked)
            sorgu += " and renk=" + Convert.ToInt16(cmbRebk.SelectedValue) + " ";
        }
        public void sadeceAdet()
        {
            if (chcAdet.Checked)
                if (txtAdet.Text != "")
                    sorgu += " and adet=" + Convert.ToInt32(txtAdet.Text) + " ";
                else {
                    sorgulansinMi = false;
                    toolTip1.Show("Lütfen Boyu giriniz", txtAdet);
                }
        }
        public void sadeceBoy()
        {
            if (chcBoy.Checked)
                if (txtBoy.Text != "")
                    sorgu += " and boy=" + Convert.ToInt32(txtBoy.Text) + " ";
                else {
                    sorgulansinMi = false;
                    toolTip1.Show("Lütfen Boyu giriniz", txtBoy);
                }
        }
        public void sadeceHatNo()
        {
            if (chcHatNo.Checked)
            sorgu += " and kullanilacakHat=" + Convert.ToInt16(cmbHatNo.SelectedValue) + " ";

        }
        public void sadeceTarihAraligi()
        {
            if (chcTarihAraligi.Checked)
            {
                if (dtIlkTarih.Value >= dtSonTarih.Value) {
                    sorgulansinMi = false;
                    toolTip1.Show("İlk Tari, Son Tarihten büyük ve eşit olamaz!",dtSonTarih);
                }else
                sorgu += " and '" + dtIlkTarih.Value.ToString("yyyy-MM-dd hh:mm:ss") + "'<=baslangicTarihi and '" + dtSonTarih.Value.ToString("yyyy-MM-dd hh:mm:ss") + "'>=bitisTarihi ";
               
            }
        }
        private void chcUrunKod_CheckedChanged(object sender, EventArgs e)
        {
            if (chcUrunKod.Checked)
                txtUrunKodd.Enabled = true;
            else
                txtUrunKodd.Enabled = false;
        }

        private void chcSiparisKodu_CheckedChanged(object sender, EventArgs e)
        {
            if (chcSiparisKodu.Checked)
                txtSiparisKodd.Enabled = true;
            else
                txtSiparisKodd.Enabled = false;
        }

        private void chcFirmaAdi_CheckedChanged(object sender, EventArgs e)
        {
            if (chcFirmaAdi.Checked)
                txtFirmaAdi.Enabled = true;
            else
                txtFirmaAdi.Enabled = false;
        }

        private void chcHammadde_CheckedChanged(object sender, EventArgs e)
        {
            if (chcHammadde.Checked)
                cmbHammdde.Enabled = true;
            else
                cmbHammdde.Enabled = false;
        }

        private void chcRenk_CheckedChanged(object sender, EventArgs e)
        {
            if (chcRenk.Checked)
                cmbRebk.Enabled = true;
            else
                cmbRebk.Enabled = false;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void chcAdet_CheckedChanged(object sender, EventArgs e)
        {
            if (chcAdet.Checked)
                txtAdet.Enabled = true;
            else
                txtAdet.Enabled = false;

        }

        private void chcBoy_CheckedChanged(object sender, EventArgs e)
        {
            if (chcBoy.Checked)
                txtBoy.Enabled = true;
            else
                txtBoy.Enabled = false;
        }

        private void chcHatNo_CheckedChanged(object sender, EventArgs e)
        {
            if (chcHatNo.Checked)
                cmbHatNo.Enabled = true;
            else
                cmbHatNo.Enabled = false;
        }

        private void chcTarihAraligi_CheckedChanged(object sender, EventArgs e)
        {
            if (chcTarihAraligi.Checked)
                grpTarihAraligi.Enabled = true;
            else
                grpTarihAraligi.Enabled = false;
        }

        private void pnlGelismisArama_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void txtSiparisKodd_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (sender) as TextBox;
            if (txt.Text != "") {
                toolTip1.Hide(txt);
            }
        }

        private void lblOncekiSayfa_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            deger = deger - gosterilecekKayitSayisi;
            if (deger < 0) {
                deger = 0;
            }
            ds.Clear();
            da.Fill(ds,deger,gosterilecekKayitSayisi,"siparis");
            
        }

        private void lblSonraki_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            deger = deger + gosterilecekKayitSayisi;
            if (deger >=satirSayisi)
            {
                deger = satirSayisi - 1;
            }
            ds.Clear();
            da.Fill(ds, deger, gosterilecekKayitSayisi, "siparis");
        }
        frmUrunResmi urunResimGorm ;
        private void lblUrunResmi_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Image urunResim=null;
            veritabani.baglan();
            SqlCommand urunResmi = new SqlCommand("select resim from urunler where kod in(select urunKod from siparis where siparisKod='"+lblSiparisKod.Text+"')",veritabani.conn);
            SqlDataReader urunResmiOku = urunResmi.ExecuteReader();
            if(urunResmiOku.Read()){
               
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

        private void button1_Click_2(object sender, EventArgs e)
        {
            pnlGelismisArama.Visible = false;
        }
       
       
       


    }
}
