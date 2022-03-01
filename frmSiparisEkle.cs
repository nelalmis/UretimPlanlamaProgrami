using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace uretimPlanlamaProgrami
{
    public partial class frmSiparisEkle : Form
    {
        
        DateTime hatBitisTarihi;
       
        SqlCommand siparisEkle;
        SqlCommand hatBitisTarihiEkle;
        string urunKod;
        int ham;
        int renk;
        string oncelik;
        float sureDakka = 0.0F;
        float gerekliUrunMiktari = 0.0F;



        public frmSiparisEkle()
        {
            InitializeComponent();
        }
        hatalar hata = new hatalar();
        
        private void frmSiparisEkle_Load(object sender, EventArgs e)
        {
            hata.hataMesajı = "Sipariş Ekle Formu açılırken beklenmedik bir hata oluştu.";
          try{
                button1.Enabled = false;
                DataTable table = new DataTable();
                DataTable table2 = new DataTable();
                DataTable table3 = new DataTable();
                pnlSiparisTeslimBilgileri.Visible = false;
                veritabani.baglan();
                SqlCommand urun = new SqlCommand("select id,kod from urunler", veritabani.conn);
                SqlDataAdapter dpUrun = new SqlDataAdapter(urun);
                dpUrun.Fill(table3);
                cmbUrunKod.DataSource = new BindingSource(table3, null);
                cmbUrunKod.DisplayMember = "kod";
                cmbUrunKod.ValueMember = "id";



                SqlCommand hammadde = new SqlCommand("select id,adi from hammadde", veritabani.conn);
                SqlDataAdapter dpp = new SqlDataAdapter(hammadde);
                dpp.Fill(table);
                cmbHammadde.DataSource = new BindingSource(table,null);
                cmbHammadde.DisplayMember = "adi";
                cmbHammadde.ValueMember = "id";


                SqlCommand renk = new SqlCommand("select id,kod,renkAdi from renkler", veritabani.conn);
                SqlDataAdapter dprenk = new SqlDataAdapter(renk);
                dprenk.Fill(table2);
                cmbRenk.DataSource = new BindingSource(table2, null);
                cmbRenk.DisplayMember = "renkAdi";
                cmbRenk.ValueMember = "id";
          }catch(Exception){
              MessageBox.Show(hata.hataMesajı,"HATA",MessageBoxButtons.OK,MessageBoxIcon.Warning);
              hata.hataKodu = "frmSiparisEkleLoad";
            
            }

        }
        Siparis sp = new Siparis();
        bool kayitBasarilimi;
        DateTime Hesaplanan;
        int yyyy;
        int mm;
        int dd;
        int hour;
        int minute;
        private void btnSiparisEkle_Click(object sender, EventArgs e)
        {
            hata.hataMesajı = "Sipariş eklenirken bir hata oluştu.";
            veritabani.baglan();
           
            int second;

            #region
            if (txtSiparisKodu.Text == "")
            {
                lblKod.Text = "Sipariş kodu boş bırakılamaz!";
            }
            else if (txtFirmaAdi.Text == "")
            {
                
                lblKod.Text = "";
                lblFirmaAdi.Text = "Firma adı boş bırakılamaz!";

            }
            else if (cmbHammadde.SelectedIndex==-1)
            {
                lblKod.Text = "";
                lblFirmaAdi.Text = "";
                lblHammadde.Text = "Bir hammadde seçiniz!";
            }
            else if (cmbOncelikSirasi.SelectedIndex == -1) {
                lblKod.Text = "";
                lblFirmaAdi.Text = "";
                lblHammadde.Text = "";
                lblOncelik.Text = "Öncelik sırası seçiniz!";
            }
            else if (txtBoy.Text == "") {
                lblKod.Text = "";
                lblFirmaAdi.Text = "";
                lblHammadde.Text = "";
                lblOncelik.Text = "";
                lblBoy.Text = "Boyu giriniz!";
                
            }else if(txtAdet.Text==""){
                lblKod.Text = "";
                lblFirmaAdi.Text = "";
                lblHammadde.Text = "";
                lblOncelik.Text = "";
                lblBoy.Text = "";
                lblAdet.Text = "Sipariş adetini giriniz!";
            
            }
            else if (cmbRenk.SelectedIndex == -1)
            {
                lblKod.Text = "";
                lblFirmaAdi.Text = "";
                lblHammadde.Text = "";
                lblOncelik.Text = "";
                lblBoy.Text = "";
                lblAdet.Text = "";
                lblRenk.Text = "Siparişin rengini giriniz!";


            }
            else if ((0 != siparisKodkontrol(txtSiparisKodu.Text)))
            {

                MessageBox.Show("Girilen sipariş kodu kullanılıyor.Lütfen farklı bir kod giriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            #endregion//KONTTROLLER
            else
            {
                #region
                
                    int saatTotal;
                    int topSure;
                    urunKod = (cmbUrunKod.GetItemText(cmbUrunKod.SelectedItem).ToString());
                    ham = Convert.ToInt16(cmbHammadde.SelectedValue);
                    renk = Convert.ToInt16(cmbRenk.SelectedValue);
                    oncelik = cmbOncelikSirasi.SelectedItem.ToString();
                    sureDakka = 0.0F;
                    gerekliUrunMiktari = 0.0F;

                    DateTime bugunTarihSaat = DateTime.Now;

                    int dakka = Convert.ToInt32(bugunTarihSaat.Minute);
                    int bugunSaat = Convert.ToInt32(bugunTarihSaat.Hour);
                    bugunSaat = bugunSaat + 1;

                    yyyy = bugunTarihSaat.Year;
                    mm = bugunTarihSaat.Month;
                    dd = bugunTarihSaat.Day;
                    hour = bugunTarihSaat.Hour;
                   

                    if (hour == 23)
                    {
                        bugunTarihSaat = bugunTarihSaat.AddHours(1);
                        hour = bugunTarihSaat.Hour;

                    }
                    else {
                        hour = hour + 1;
                        
                    }

                   
                    bugunTarihSaat = new DateTime(yyyy, mm, dd, hour, 00, 00);
                    string sadeceTarih;
                    int sadeceSaat;

                   

                    int sureSaniye = 0;
                    sp.adet = Convert.ToInt64(txtAdet.Text);
                    sp.boy = Convert.ToInt64(txtBoy.Text);
                    SqlCommand sor = new SqlCommand("select * from urunler where kod='" + cmbUrunKod.GetItemText(cmbUrunKod.SelectedItem) + "'", veritabani.conn);
                    SqlDataReader oku = sor.ExecuteReader();

                    if (oku.Read())
                    {
                        sp.gramaj = Convert.ToInt32(oku["gramaj"]);
                        sp.hiz = Convert.ToInt32(oku["hizi"]);
                        sp.fireMiktari = Convert.ToInt32(oku["fireMiktari"]);

                    }

                    sureDakka = (float)(((sp.boy) / 1000) * sp.adet) / sp.hiz;
                    gerekliUrunMiktari = (float)(sp.gramaj * sp.boy) + ((sp.gramaj * sp.boy) * sp.fireMiktari / 100);
                    sureSaniye = (int)sureDakka * 60;
                    if (sureDakka % 60 == 0)
                        saatTotal = (int)sureDakka / 60;
                    else
                    {
                        saatTotal = (int)(sureDakka + (60 - (sureDakka % 60)));

                        saatTotal = saatTotal / 60;
                    }
                    if (saatTotal == 0)
                        saatTotal = 1;



                    TimeSpan eklenecekSure = new TimeSpan(saatTotal, 0, 0);
                    topSure = saatTotal;
                    DateTime sonuc = bugunTarihSaat.Add(eklenecekSure);

                    int devamDurumu = 3;



                    sadeceTarih = sonuc.ToShortDateString();
                    sadeceSaat = sonuc.Hour;

                    new Exception(hata.hataMesajı);
                    hata.hataKodu = "frmSiparisEkle hesaplama kısmı";
                
                #endregion
                    int uygunHatVarmi = uygunHatBul(urunKod);

                    if (uygunHatVarmi != -1)
                    {
                        try{
                        
                            #region
                            veritabani.baglan();
                            //hatlardan boş olana hemen kayıt
                            //direk kayıt
                            if (bugunTarihSaat > DateTime.Now)
                                devamDurumu = 3;

                            //fonksiyonDirekKayit;
                           

                            while(baslangictarihiTatileDenkGeliyormu(bugunTarihSaat))
                            {

                                bugunTarihSaat = bugunTarihSaat.AddDays(1);
                                yyyy = bugunTarihSaat.Year;
                                mm = bugunTarihSaat.Month;
                                dd = bugunTarihSaat.Day;
                                hour = bugunTarihSaat.Hour;
                                bugunTarihSaat = new DateTime(yyyy, mm, dd, 00, 00, 00);


                            }
                            bugunTarihSaat = fonksiyonBaslangicPazartesiMi(bugunTarihSaat);
                            Hesaplanan = fonksiyonTatilGunuVarsaGec(bugunTarihSaat, topSure);
                            
                            fonksiyonSiparisEkle(sp.adet, bugunTarihSaat, Hesaplanan, topSure, uygunHatVarmi, devamDurumu);
                            fonksiyonHatBitisTarihiGuncelle(Hesaplanan, uygunHatVarmi, txtSiparisKodu.Text);
                            fonksyionUretimHattiAktiflestirme(uygunHatVarmi);

                            //BURDAYIZZZZZZZ
                            kayitBasarilimi = true;
                            lblBasTarihi.Text = bugunTarihSaat.ToString();
                       }catch(Exception){
                            MessageBox.Show(hata.hataMesajı, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            hata.hataKodu = "frmSiparişEkle Boş hat varsa ekleme kısmı";
                            hata.hataMesajiKaydet();
                        }
                        #endregion
                    }
                    else
                    {
                        if (oncelik == "Acil")
                        {
                            kayitBasarilimi = siparisAcilEkle(urunKod, topSure);

                        }
                        //SONRASINA KAYIT
                        else
                        {
                            #region

                            int hatno = bitisTarihiEnYakinHatBul(urunKod);
                            if (hatno != -1)
                            {
                                try
                                {
                                    SqlCommand farkIcinSSor = new SqlCommand("select urunKod from siparis where siparisKod='" + sonrakiIcinSiparisKodu + "'", veritabani.conn);
                                    SqlDataReader okuBunu = farkIcinSSor.ExecuteReader();
                                    if (okuBunu.Read())
                                    {
                                        if (urunKod != okuBunu["urunKod"].ToString())
                                            hatBitisTarihi = hatBitisTarihi.AddHours(2);
                                    }


                                   while(baslangictarihiTatileDenkGeliyormu(hatBitisTarihi))
                                    {

                                        hatBitisTarihi = hatBitisTarihi.AddDays(1);
                                        yyyy = hatBitisTarihi.Year;
                                        mm = hatBitisTarihi.Month;
                                        dd = hatBitisTarihi.Day;
                                        hour = hatBitisTarihi.Hour;
                                        hatBitisTarihi = new DateTime(yyyy, mm, dd, 00, 00, 00);

                                    }
                                    hatBitisTarihi = fonksiyonBaslangicPazartesiMi(hatBitisTarihi);
                                    Hesaplanan = fonksiyonTatilGunuVarsaGec(hatBitisTarihi, topSure);
                                    sonuc = hatBitisTarihi.AddHours(topSure);

                                    fonksiyonSiparisEkle(sp.adet, hatBitisTarihi, Hesaplanan, topSure, hatno, 3);
                                    // fonksiyonSonrakiSiparisKoduIcinSiparisGuncelle(sonrakiIcinSiparisKodu);
                                    fonksiyonHatBitisTarihiGuncelle(Hesaplanan, hatno, txtSiparisKodu.Text);

                                    fonksiyonSonrakiSiparisKoduIcinSiparisGuncelle(sonrakiIcinSiparisKodu, txtSiparisKodu.Text);
                                    kayitBasarilimi = true;

                                }
                                catch (Exception)
                                {
                                    MessageBox.Show(hata.hataMesajı, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    hata.hataKodu = "frmSiparisEkle ACİL DEĞİLSE EKLEME KISMI";


                                }
                                //bit fonksiyonla hangi hattın bitis tarihi en yakınsa ona ekle.
                            #endregion
                            }
                            //Başarılı
                        }

                    }
                    #region
                    if (kayitBasarilimi)
                    {
                        /*
                        txtAdet.Enabled = false;
                        txtFirmaAdi.Enabled = false;
                        txtSiparisKodu.Enabled = false;
                        txtBoy.Enabled = false;
                        cmbHammadde.Enabled = false;
                        cmbOncelikSirasi.Enabled = false;
                        cmbRenk.Enabled = false;
                        cmbUrunKod.Enabled = false;
                         * */
                        MessageBox.Show("Sipariş kaydı başarılı.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        pnlSiparisTeslimBilgileri.Visible = true;


                    }
                    else
                        MessageBox.Show("Sipariş kaydında bir hata meydana geldi!", "------HATA-------", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    #endregion
                    veritabani.baglantiyiKes();
                

            }

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
        private void fonksyionUretimHattiAktiflestirme(int HatNo) {

            veritabani.baglantiyiKes();
            SqlCommand aktiflestir = new SqlCommand();
            aktiflestir.Connection = veritabani.conn;
            veritabani.baglan();
            aktiflestir.CommandText = "update uretimHatti set aktiflik=@true where numara=@numara";
            aktiflestir.Parameters.Clear();
            aktiflestir.Parameters.AddWithValue("@true", 1);
            aktiflestir.Parameters.AddWithValue("@numara", HatNo);
            aktiflestir.ExecuteNonQuery();
                            
        }
        private string fonksiyonSonrakiSiparisleriGuncelle(string siparisKodu,DateTime baslangicTarihi,DateTime bitisTarihi) {
            string donenecekDeger;
            SqlCommand siparisGuncelle = new SqlCommand();
            siparisGuncelle.Connection = veritabani.conn;
            veritabani.baglan();
            string bitTarih = bitisTarihi.ToShortDateString();
            int bitSaat = bitisTarihi.Hour;


            siparisGuncelle.CommandText = "update siparis set baslangicTarihi=@baslangicTarihi,bitisTarihi=@bitisTarihi,bitTarih=@bitTarih,bitSaat=@bitSaat where siparisKod=@siparisKod";
            siparisGuncelle.Parameters.Clear();
            siparisGuncelle.Parameters.AddWithValue("@baslangicTarihi",baslangicTarihi);
            siparisGuncelle.Parameters.AddWithValue("@bitisTarihi",bitisTarihi);
            siparisGuncelle.Parameters.AddWithValue("@bitTarih",bitTarih);
            siparisGuncelle.Parameters.AddWithValue("@bitSaat",bitSaat);
            siparisGuncelle.Parameters.AddWithValue("@siparisKod",siparisKodu);
            siparisGuncelle.ExecuteNonQuery();


            SqlCommand birSonrakiSiparisKoduAl = new SqlCommand("select sonrakiSiparisKodu from siparis where siparisKod='"+siparisKodu+"'",veritabani.conn);
            SqlDataReader birSonrakiOku = birSonrakiSiparisKoduAl.ExecuteReader();
            if (birSonrakiOku.Read())
            {
                donenecekDeger = birSonrakiOku["sonrakiSiparisKodu"].ToString();
               
                veritabani.baglantiyiKes();
                return donenecekDeger;
               
                
            }
            else
            {
                veritabani.baglantiyiKes();
                return "NULL";
                
            }
         

            

           
        
        }
        private void btnPnlKapat_Click(object sender, EventArgs e)
        {
           // button1.Enabled = true;
            
            pnlSiparisTeslimBilgileri.Visible = false;
        }

        private void frmSiparisEkle_FormClosed(object sender, FormClosedEventArgs e)
        {
            veritabani.baglantiyiKes();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void fonksiyonSonrakiSiparisKoduIcinSiparisGuncelle(string siparisKodu,string sonrakiSiparisKodu) {
           
           try{
                SqlCommand guncelle = new SqlCommand();
                guncelle.Connection = veritabani.conn;
                veritabani.baglan();
                guncelle.CommandText = "update siparis set sonrakiSiparisKodu=@sonrakiSiparisKodu where siparisKod=@siparisKod";
                guncelle.Parameters.Clear();
                guncelle.Parameters.AddWithValue("@sonrakiSiparisKodu", sonrakiSiparisKodu);
                guncelle.Parameters.AddWithValue("@siparisKod", siparisKodu);

                guncelle.ExecuteNonQuery();
            
            }
            catch (Exception) {
                MessageBox.Show(hata.hataMesajı, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hata.hataKodu = "frmSiparisEkle fonksiyonSiparisKoduIcimSiparisGuncelle ";
                hata.hataMesajiKaydet();
            
            }
            
              
            
        
        }
        public int uygunHatBul(string urunKod) {
            veritabani.baglan();
            try
            {
                int var;
                SqlCommand bul = new SqlCommand("select top 1 numara as numara from urunUretimHatlari ur,uretimHatti h where ur.urunKod='" + urunKod + "' and h.aktiflik=0 and h.kullanilabilirmi=1 and ur.HatNo=h.numara order by numara", veritabani.conn);
                SqlDataReader ok = bul.ExecuteReader();
                if (ok.Read())
                    var = Convert.ToInt32(ok["numara"]);
                else
                    var = -1;

            
                return var;
            }
            catch (Exception)
            {
                MessageBox.Show(hata.hataMesajı, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hata.hataKodu = "frmSiparisEkle uygunHatBul fonksiyonu";
                hata.hataMesajiKaydet();
                return -1;

            }
            
        }
        string sonrakiIcinSiparisKodu;
        public int bitisTarihiEnYakinHatBul(string urunKod) {
            try
            {
                veritabani.baglan();
                int hatno;

                SqlCommand bul = new SqlCommand("select top 1 hb.hatNo,hb.bitisTarihi,siparisKodu from hatBitisTarih hb,urunler ur,urunUretimHatlari uh,uretimHatti u where ur.kod='" + urunKod + "' and ur.kod=uh.urunKod and uh.HatNo=hb.hatNo and bitisTarihi is not null order by hb.bitisTarihi asc", veritabani.conn);
                SqlDataReader al = bul.ExecuteReader();
                if (al.Read())
                {
                    sonrakiIcinSiparisKodu = al["siparisKodu"].ToString();
                    hatno = Convert.ToInt32(al["hatNo"]);
                    hatBitisTarihi = Convert.ToDateTime((al["bitisTarihi"]));




                    // MessageBox.Show(hatBitisTarihi.ToString());
                }
                else
                    hatno = -1;


                return hatno;
            }catch(Exception){
                MessageBox.Show(hata.hataMesajı, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hata.hataKodu = "frmSiparisEkle bitisTarihiEnYakinHatBul fonksyionu";
                hata.hataMesajiKaydet();
                return -1;
                    
            
            }
        }
        public int siparisKodkontrol(string girilenKod) {
            try
            {
                int donus;
                veritabani.baglan();
                SqlCommand sor = new SqlCommand("select count(siparisKod) from siparis where siparisKod='" + girilenKod + "'", veritabani.conn);
                donus = Convert.ToInt32(sor.ExecuteScalar());
                return donus;
            }
            catch (SqlException) {
                MessageBox.Show(hata.hataMesajı, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hata.hataKodu = "frmSiparisEkle siparisKodKontrol";
                return -1;
            }
               
            
        }
        public void fonksiyonSiparisEkle(long adet,DateTime baslangicTarihi,DateTime sonuc,int topSure,int hatNo,int devamDurumu){
            try
            {
                siparisEkle = new SqlCommand();
                siparisEkle.Connection = veritabani.conn;
                veritabani.baglan();
                DateTime kayitTarihi = DateTime.Now;

                string sadeceTarih = sonuc.ToShortDateString();
                int sadeceSaat = sonuc.Hour;
                siparisEkle.CommandText = "insert into siparis(urunKod,siparisKod,firmaAdi,hammadde,oncelikSirasi,boy,adet,renk,baslangicTarihi,bitisTarihi,toplamSure,gerekenUrunMiktari,siparisBittimi,kullanilacakHat,sil,devamDurumu,bitTarih,bitSaat,kayitTarihi,tatilDahilSure) values(@urunKod,@siparisKod,@firmaAdi,@hammadde,@oncelikSirasi,@boy,@adet,@renk,@baslangicTarihi,@bitisTarihi,@toplamSure,@gerekenUrunMiktari,@siparisBittimi,@kullanilacakHat,@sil,@devamDurumu,@bitTarih,@bitSaat,@kayitTarihi,@tatilDahilSure)";
                siparisEkle.Parameters.Clear();
                siparisEkle.Parameters.AddWithValue("@urunKod", cmbUrunKod.GetItemText(cmbUrunKod.SelectedItem));
                siparisEkle.Parameters.AddWithValue("@siparisKod", txtSiparisKodu.Text.Trim());
                siparisEkle.Parameters.AddWithValue("@firmaAdi", txtFirmaAdi.Text.Trim());
                siparisEkle.Parameters.AddWithValue("@hammadde", ham);
                siparisEkle.Parameters.AddWithValue("@oncelikSirasi", oncelik);
                siparisEkle.Parameters.AddWithValue("@boy", txtBoy.Text.Trim());
                siparisEkle.Parameters.AddWithValue("@adet", adet);
                siparisEkle.Parameters.AddWithValue("@renk", renk);
                siparisEkle.Parameters.AddWithValue("@baslangicTarihi", baslangicTarihi);
                siparisEkle.Parameters.AddWithValue("@bitisTarihi", sonuc);
                siparisEkle.Parameters.AddWithValue("@toplamSure", topSure);
                siparisEkle.Parameters.AddWithValue("@gerekenUrunMiktari", gerekliUrunMiktari);
                siparisEkle.Parameters.AddWithValue("@siparisBittimi", 0);
                siparisEkle.Parameters.AddWithValue("@kullanilacakHat", hatNo);
                siparisEkle.Parameters.AddWithValue("@sil", 0);
                siparisEkle.Parameters.AddWithValue("@devamDurumu", devamDurumu);
                siparisEkle.Parameters.AddWithValue("@bitTarih", sadeceTarih);
                siparisEkle.Parameters.AddWithValue("@bitSaat", sadeceSaat);
                siparisEkle.Parameters.AddWithValue("@kayitTarihi", kayitTarihi);
                siparisEkle.Parameters.AddWithValue("@tatilDahilSure", Hesaplanan.Subtract(baslangicTarihi).TotalHours);

                siparisEkle.ExecuteNonQuery();
               
                lblHatNo.Text = hatNo.ToString();
                lblKayitTarihi.Text = "" + String.Format("{0:f}", DateTime.Now);
                lblBasTarihi.Text = "" + String.Format("{0:f}", baslangicTarihi);
                lblBitTarihi.Text = "" + String.Format("{0:f}", Hesaplanan);
                lblSiparisKoduPanel.Text = txtSiparisKodu.Text;
                lblUrunKoduPanel.Text = cmbUrunKod.GetItemText(cmbUrunKod.SelectedItem);
                lblTopSure.Text = "" + String.Format("{0:0,0}", Hesaplanan.Subtract(baslangicTarihi).TotalHours) + " SAAT";
                lblBoyPanel.Text = "" + String.Format("{0:0,0}", sp.boy) + " milimetre";
                lblAdetPanel.Text = "" + String.Format("{0:0,0}", adet);
                lblBitTarihi.Text = sonuc.ToString();

                lblGerekliSure.Text = "" + String.Format("{0:0,0}", topSure) + " SAAT";
                lblHammaddePanel.Text = cmbHammadde.GetItemText(cmbHammadde.SelectedItem);
                lblRenkPanel.Text = cmbRenk.GetItemText(cmbRenk.SelectedItem);
                lblTopMiktar.Text = gerekliUrunMiktari.ToString() + " GRAM" + "  ==" + (gerekliUrunMiktari / 1000) + " KG";

               // btnSiparisEkle.Enabled = false;

            }catch(Exception){
                MessageBox.Show(hata.hataMesajı, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hata.hataKodu = "frmSiparisEkle fonksiyonSiparisEkle";
            
            }                

        }
        public void fonksiyonHatBitisTarihiGuncelle(DateTime bitisTarih,int hatNo,string siparisKodu) {
            try
            {
                hatBitisTarihiEkle = new SqlCommand();
                hatBitisTarihiEkle.Connection = veritabani.conn;
                veritabani.baglan();
                string tarih;
                int saat;
                tarih = bitisTarih.ToShortDateString();
                saat = bitisTarih.Hour;
                hatBitisTarihiEkle.CommandText = "update hatBitisTarih set bitisTarihi=@bitisTarihi,tarih=@tarih,saat=@saat,siparisKodu=@siparisKodu where hatNo=@hatNo";
                hatBitisTarihiEkle.Parameters.Clear();
                hatBitisTarihiEkle.Parameters.AddWithValue("@bitisTarihi", bitisTarih);
                hatBitisTarihiEkle.Parameters.AddWithValue("@tarih", tarih);
                hatBitisTarihiEkle.Parameters.AddWithValue("@saat", saat);
                hatBitisTarihiEkle.Parameters.AddWithValue("@hatNo", hatNo);
                hatBitisTarihiEkle.Parameters.AddWithValue("@siparisKodu", txtSiparisKodu.Text);
                hatBitisTarihiEkle.ExecuteNonQuery();
            }catch(Exception){
                MessageBox.Show(hata.hataMesajı, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hata.hataKodu = "frmSiparisEkle fonksiyonHatBitisTarihGuncelle";
            }

            veritabani.baglantiyiKes();
        }
      

        private void pnlSiparisTeslimBilgileri_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtBoy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= (char)48) && (e.KeyChar <= (char)59) || (e.KeyChar == (char)8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtAdet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= (char)48) && (e.KeyChar <= (char)59) || (e.KeyChar == (char)8))
                e.Handled = false;
            else
                e.Handled = true;
        }
        ses s = new ses();
        private void button1_Click(object sender, EventArgs e)
        {
            /*
            if (btnSiparisEkle.Enabled == true)
            {
                s.hata_sesi();
                MessageBox.Show("Yeni kullanıcı kaydı zaten açık", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }
            else {
                btnSiparisEkle.Enabled = true;
                txtAdet.Enabled = true;

                txtFirmaAdi.Enabled = true;
                txtSiparisKodu.Enabled = true;
                txtBoy.Enabled = true;
                cmbHammadde.Enabled = true;
                cmbOncelikSirasi.Enabled = true;
                cmbRenk.Enabled = true;
                cmbUrunKod.Enabled = true;
                txtAdet.Text = "";
                txtFirmaAdi.Text = "";
                txtSiparisKodu.Text = "";
                txtBoy.Text = "";
            
            }
             * */
        }

        bool sonuc;
        public bool siparisAcilEkle(string yeniUrunKod, int yeniToplamSure)
        {
            try
            {
                veritabani.baglan();
                //onemsizlerTablosu beklemede olan siparişleri tutan bir viewdir

                SqlCommand onemsizlertablosundanOku = new SqlCommand("select top 1 * from onemsizlerTablosu where kullanilacakHat in(select hatNo from urunler u,urunUretimHatlari h where u.kod=h.urunKod and u.kod='" + yeniUrunKod + "' ) order by baslangicTarihi", veritabani.conn);
                SqlDataReader onemsizOku = onemsizlertablosundanOku.ExecuteReader();

                SqlCommand bitisTarihiEnYakin = new SqlCommand("select top 1 * from hatBitisTarih ht,urunler u,urunUretimHatlari h,siparis s where  u.kod=h.urunKod and h.HatNo=ht.hatNo and s.siparisKod=ht.siparisKodu and u.kod='" + yeniUrunKod + "' order by ht.bitisTarihi asc", veritabani.conn);
                SqlDataReader bitisTarihiEnYakinOku = bitisTarihiEnYakin.ExecuteReader();

                DateTime okunanBaslangicTarihi;
                DateTime okunanBitisTarihi;
                string okunanSiparisKodu;
                string okunanSonrakiSiparisKodu;
                int okunanToplamSure;
                string okunanUrunKod;
                int okunanHatNo;
                string oncekiUrunKod;
                DateTime karsilacatirilacakBitisTarihi;


                if (onemsizOku.Read() && bitisTarihiEnYakinOku.Read())
                {
                    try
                    {
                        MessageBox.Show("one");
                        okunanBaslangicTarihi = Convert.ToDateTime(onemsizOku["baslangicTarihi"]);
                        karsilacatirilacakBitisTarihi = Convert.ToDateTime(bitisTarihiEnYakinOku["bitisTarihi"]);

                        if (okunanBaslangicTarihi < karsilacatirilacakBitisTarihi)
                        {//önemsizin yerine 
                            MessageBox.Show("1");
                            #region
                            try
                            {

                                okunanSonrakiSiparisKodu = onemsizOku["sonrakiSiparisKodu"].ToString();
                                okunanSiparisKodu = onemsizOku["siparisKod"].ToString();
                                okunanToplamSure = Convert.ToInt32(onemsizOku["toplamSure"]);
                                okunanBitisTarihi = Convert.ToDateTime(onemsizOku["bitisTarihi"]);
                                okunanHatNo = Convert.ToInt32(onemsizOku["kullanilacakHat"]);
                                okunanUrunKod = onemsizOku["urunKod"].ToString();
                                oncekiUrunKod = okunanUrunKod;
                                //dınguye girmden acilden sonra gelen siparis kodu güncelleniyor;
                                sonrakiIcinSiparisKodu = okunanSiparisKodu;

                                //İLK ÖNCE YENİ SİPARİŞ EKLENİYOr
                                #region
                                SqlCommand oncekiSiparisKoduSor = new SqlCommand("select urunKod from siparis where sonrakiSiparisKodu='" + okunanSiparisKodu + "'", veritabani.conn);
                                SqlDataReader okuu = oncekiSiparisKoduSor.ExecuteReader();
                                if (okuu.Read())
                                {
                                    if (okuu["urunKod"].ToString() != yeniUrunKod)
                                    {
                                        okunanBaslangicTarihi = okunanBaslangicTarihi.AddHours(2);
                                    }

                                }
                               while(baslangictarihiTatileDenkGeliyormu(okunanBaslangicTarihi))
                                {

                                    okunanBaslangicTarihi = okunanBaslangicTarihi.AddDays(1);
                                    yyyy = okunanBaslangicTarihi.Year;
                                    mm = okunanBaslangicTarihi.Month;
                                    dd = okunanBaslangicTarihi.Day;
                                    hour = okunanBaslangicTarihi.Hour;
                                    okunanBaslangicTarihi = new DateTime(yyyy, mm, dd, 00, 00, 00);

                                }
                                okunanBaslangicTarihi = fonksiyonBaslangicPazartesiMi(okunanBaslangicTarihi);
                                Hesaplanan = fonksiyonTatilGunuVarsaGec(okunanBaslangicTarihi, yeniToplamSure);

                                fonksiyonSiparisEkle(sp.adet, okunanBaslangicTarihi, Hesaplanan, yeniToplamSure, okunanHatNo, 3);
                                //bu siparişten sonra önemsiz geldiği için önemsizi işaret ediyor
                                fonksiyonSonrakiSiparisKoduIcinSiparisGuncelle(txtSiparisKodu.Text, okunanSiparisKodu);


                                #endregion
                                int i = 0;
                                // ÖNEMSİZİ GÜNCELLİYOR
                                #region

                                //önemsiz için bir kere giriyor;
                                okunanBitisTarihi = Hesaplanan;
                                if (okunanUrunKod != yeniUrunKod)
                                    okunanBitisTarihi = Hesaplanan.AddHours(2);

                               while(baslangictarihiTatileDenkGeliyormu(okunanBitisTarihi))
                                {

                                    okunanBitisTarihi = okunanBitisTarihi.AddDays(1);
                                    yyyy = okunanBitisTarihi.Year;
                                    mm = okunanBitisTarihi.Month;
                                    dd = okunanBitisTarihi.Day;
                                    hour = okunanBitisTarihi.Hour;
                                    okunanBitisTarihi = new DateTime(yyyy, mm, dd, 00, 00, 00);

                                }
                                okunanBaslangicTarihi = okunanBitisTarihi;
                                okunanBaslangicTarihi = fonksiyonBaslangicPazartesiMi(okunanBaslangicTarihi);
                                okunanBitisTarihi = fonksiyonBaslangicPazartesiMi(okunanBitisTarihi);
                                okunanBitisTarihi = fonksiyonTatilGunuVarsaGec(okunanBitisTarihi, okunanToplamSure);

                                SqlCommand onemsizGuncelle = new SqlCommand();
                                onemsizGuncelle.Connection = veritabani.conn;
                                onemsizGuncelle.CommandText = "update siparis set baslangicTarihi=@baslangicTarihi,bitisTarihi=@bitisTarihi,bitTarih=@bitTarih,bitSaat=@bitSaat where siparisKod=@siparisKod";
                                onemsizGuncelle.Parameters.Clear();
                                onemsizGuncelle.Parameters.AddWithValue("@baslangicTarihi", okunanBaslangicTarihi);
                                onemsizGuncelle.Parameters.AddWithValue("@bitisTarihi", okunanBitisTarihi);
                                onemsizGuncelle.Parameters.AddWithValue("@bitTarih", okunanBitisTarihi.ToShortDateString());
                                onemsizGuncelle.Parameters.AddWithValue("@bitSaat", okunanBitisTarihi.Hour);
                                onemsizGuncelle.Parameters.AddWithValue("@siparisKod", okunanSiparisKodu);
                                onemsizGuncelle.ExecuteNonQuery();

                                /*
                                SqlCommand gunOnemsiz = new SqlCommand("update siparis set baslangicTarihi=DATEADD(hour," + yeniToplamSure + ",baslangicTarihi),bitisTarihi=DATEADD(hour," + yeniToplamSure + ",bitisTarihi),bitTarih=convert(nvarchar(10),DATEADD(hour," + yeniToplamSure + ",bitisTarihi),104),bitSaat=DATEPART(HOUR, DATEADD(hour," + yeniToplamSure + ",bitisTarihi)) where siparisKod='" + okunanSiparisKodu + "'", veritabani.conn);

                                gunOnemsiz.ExecuteNonQuery();
                      
                                 */


                                #endregion
                                //ÖNEMSİZDEN SONRAKİLER GÜNCELLENİYOR
                                #region
                                while (okunanSonrakiSiparisKodu != "")
                                {
                                    try
                                    {

                                        veritabani.baglan();

                                        SqlCommand sonrakiSiparisBilgileriniOku = new SqlCommand("select * from siparis where siparisKod='" + okunanSonrakiSiparisKodu + "'", veritabani.conn);
                                        SqlDataReader okuSonrakibilgi = sonrakiSiparisBilgileriniOku.ExecuteReader();

                                        if (okuSonrakibilgi.Read())
                                        {
                                            okunanUrunKod = okuSonrakibilgi["urunKod"].ToString();
                                            if (oncekiUrunKod != okunanUrunKod)
                                                okunanBitisTarihi = okunanBitisTarihi.AddHours(2);

                                            okunanSonrakiSiparisKodu = okuSonrakibilgi["sonrakiSiparisKodu"].ToString();
                                            okunanSiparisKodu = okuSonrakibilgi["siparisKod"].ToString();
                                            okunanToplamSure = Convert.ToInt32(okuSonrakibilgi["toplamSure"]);



                                            oncekiUrunKod = okunanSiparisKodu;

                                           while(baslangictarihiTatileDenkGeliyormu(okunanBitisTarihi))
                                            {

                                                okunanBitisTarihi = okunanBitisTarihi.AddDays(1);
                                                yyyy = okunanBitisTarihi.Year;
                                                mm = okunanBitisTarihi.Month;
                                                dd = okunanBitisTarihi.Day;
                                                hour = okunanBitisTarihi.Hour;
                                                okunanBitisTarihi = new DateTime(yyyy, mm, dd, 00, 00, 00);

                                            }
                                            okunanBaslangicTarihi = okunanBitisTarihi;
                                            okunanBaslangicTarihi = fonksiyonBaslangicPazartesiMi(okunanBaslangicTarihi);
                                            okunanBitisTarihi = fonksiyonBaslangicPazartesiMi(okunanBitisTarihi);
                                            okunanBitisTarihi = fonksiyonTatilGunuVarsaGec(okunanBitisTarihi, okunanToplamSure);

                                            SqlCommand onemsizGuncelle1 = new SqlCommand();
                                            onemsizGuncelle1.Connection = veritabani.conn;
                                            onemsizGuncelle1.CommandText = "update siparis set baslangicTarihi=@baslangicTarihi,bitisTarihi=@bitisTarihi,bitTarih=@bitTarih,bitSaat=@bitSaat where siparisKod=@siparisKod";
                                            onemsizGuncelle1.Parameters.Clear();
                                            onemsizGuncelle1.Parameters.AddWithValue("@baslangicTarihi", okunanBaslangicTarihi);
                                            onemsizGuncelle1.Parameters.AddWithValue("@bitisTarihi", okunanBitisTarihi);
                                            onemsizGuncelle1.Parameters.AddWithValue("@bitTarih", okunanBitisTarihi.ToShortDateString());
                                            onemsizGuncelle1.Parameters.AddWithValue("@bitSaat", okunanBitisTarihi.Hour);
                                            onemsizGuncelle1.Parameters.AddWithValue("@siparisKod", okunanSiparisKodu);
                                            onemsizGuncelle1.ExecuteNonQuery();


                                        }


                                        /*
                                        SqlCommand gun = new SqlCommand("update siparis set baslangicTarihi=DATEADD(hour," + yeniToplamSure + ",baslangicTarihi),bitisTarihi=DATEADD(hour," + yeniToplamSure + ",bitisTarihi),bitTarih=convert(nvarchar(10),DATEADD(hour," + yeniToplamSure + ",bitisTarihi),104),bitSaat=DATEPART(HOUR, DATEADD(hour," + yeniToplamSure + ",bitisTarihi)) where siparisKod='" + okunanSiparisKodu + "'", veritabani.conn);

                                        gun.ExecuteNonQuery();
                                       */
                                        /*
                                            SqlCommand sor = new SqlCommand("select siparisKod,sonrakiSiparisKodu from siparis where siparisKod='" + okunanSonrakiSiparisKodu + "'",veritabani.conn);
                                            SqlDataReader oku = sor.ExecuteReader();
                                            if (oku.Read())
                                            {
                                                okunanSiparisKodu = oku["siparisKod"].ToString();
                                                okunanSonrakiSiparisKodu = oku["sonrakiSiparisKodu"].ToString();
                                            }
                                          */
                                    }catch(Exception){
                                        MessageBox.Show(hata.hataMesajı, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        hata.hataKodu = "frmSiparisEkle siparisAcilEkle 1.ifin while da önemsizdensonrakiler güncellenirken";
                                        hata.hataMesajiKaydet();
                                        return false;
                                    }


                                }
                                #endregion


                                //HATBİTİSTARİH TABLOSU GÜNCELLNİYOR. EN SON Kİ BİTİŞ TARİHİ YAZILIR
                                #region
                                SqlCommand HatBitisTarihGuncelle = new SqlCommand();
                                HatBitisTarihGuncelle.Connection = veritabani.conn;
                                HatBitisTarihGuncelle.CommandText = "update hatBitisTarih set bitisTarihi=@bitisTarihi,tarih=@tarih,saat=@saat where siparisKodu=@siparisKodu";
                                HatBitisTarihGuncelle.Parameters.Clear();
                                HatBitisTarihGuncelle.Parameters.AddWithValue("@bitisTarihi", okunanBitisTarihi);
                                HatBitisTarihGuncelle.Parameters.AddWithValue("@tarih", okunanBitisTarihi.ToShortDateString());
                                HatBitisTarihGuncelle.Parameters.AddWithValue("@saat", okunanBitisTarihi.Hour);
                                HatBitisTarihGuncelle.Parameters.AddWithValue("@siparisKodu", okunanSiparisKodu);
                                HatBitisTarihGuncelle.ExecuteNonQuery();
                                /*
                                SqlCommand hatBitisTarihGun = new SqlCommand("update hatBitisTarih set bitisTarihi=DATEADD(hour," + yeniToplamSure + ",bitisTarihi),tarih=convert(nvarchar(10),DATEADD(hour," + yeniToplamSure + ",bitisTarihi),104),saat=DATEPART(HOUR, DATEADD(hour," + yeniToplamSure + ",bitisTarihi)) where hatNo='" + okunanHatNo + "'", veritabani.conn);
                                hatBitisTarihGun.ExecuteNonQuery();
                                */
                                #endregion


                            #endregion
                                MessageBox.Show("1.kayıt");
                                //başarılı
                                sonuc = true;
                            }catch(Exception){
                                MessageBox.Show(hata.hataMesajı, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                hata.hataKodu = "frmSiparisEkle siparisAcilEkle 1.ifin 1.ifi";
                                hata.hataMesajiKaydet();
                                return false;
                            }
                        }
                        else
                        { //sonrasına kayıt
                            try
                            {
                                MessageBox.Show("2");
                                #region

                                int hatno = bitisTarihiEnYakinHatBul(yeniUrunKod);
                                if (hatno != -1)
                                {
                                    SqlCommand farkIcinSSor = new SqlCommand("select urunKod from siparis where siparisKod='" + sonrakiIcinSiparisKodu + "'", veritabani.conn);
                                    SqlDataReader okuBunu = farkIcinSSor.ExecuteReader();
                                    if (okuBunu.Read())
                                    {
                                        if (yeniUrunKod != okuBunu["urunKod"].ToString())
                                            hatBitisTarihi = hatBitisTarihi.AddHours(2);
                                    }

                                    // sonuc = hatBitisTarihi.Add(eklenecekSure);
                                   while(baslangictarihiTatileDenkGeliyormu(hatBitisTarihi))
                                    {

                                        hatBitisTarihi = hatBitisTarihi.AddDays(1);
                                        yyyy = hatBitisTarihi.Year;
                                        mm = hatBitisTarihi.Month;
                                        dd = hatBitisTarihi.Day;
                                        hour = hatBitisTarihi.Hour;
                                        hatBitisTarihi = new DateTime(yyyy, mm, dd, 00, 00, 00);

                                    }
                                    hatBitisTarihi = fonksiyonBaslangicPazartesiMi(hatBitisTarihi);
                                    Hesaplanan = fonksiyonTatilGunuVarsaGec(hatBitisTarihi, yeniToplamSure);
                                    // sonuc = hatBitisTarihi.AddHours(yeniToplamSure);

                                    fonksiyonSiparisEkle(sp.adet, hatBitisTarihi, Hesaplanan, yeniToplamSure, hatno, 3);
                                    // fonksiyonSonrakiSiparisKoduIcinSiparisGuncelle(sonrakiIcinSiparisKodu);
                                    fonksiyonHatBitisTarihiGuncelle(Hesaplanan, hatno, txtSiparisKodu.Text);

                                    fonksiyonSonrakiSiparisKoduIcinSiparisGuncelle(sonrakiIcinSiparisKodu, txtSiparisKodu.Text);
                                    kayitBasarilimi = true;
                                }

                                sonuc = true;


                                #endregion
                                MessageBox.Show("2.kayıt");
                            }catch(Exception){
                                MessageBox.Show(hata.hataMesajı, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                hata.hataKodu = "frmSiparisEkle siparisAcilEkle sonrasına kayıt kısmı";
                                hata.hataMesajiKaydet();
                                return false;
                            }
                        }
                    }catch(Exception){
                        MessageBox.Show(hata.hataMesajı, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        hata.hataKodu = "frmSiparisEkle siparisAcilEkle 1.if";
                        hata.hataMesajiKaydet();
                        return false;
                    }
                }
                else if (bitisTarihiEnYakinOku.Read() && !onemsizOku.Read())
                {
                    try
                    {
                        MessageBox.Show("3");
                        //sonrasına kayıt
                        #region
                        okunanBitisTarihi = Convert.ToDateTime(bitisTarihiEnYakinOku["bitisTarihi"]);
                        okunanHatNo = Convert.ToInt32(bitisTarihiEnYakinOku["kullanilacakHat"]);
                        okunanUrunKod = bitisTarihiEnYakinOku["kod"].ToString();
                        okunanSiparisKodu = bitisTarihiEnYakinOku["siparisKod"].ToString();
                        //fonksiyonsiparisEkle sonrasına;

                        if (okunanUrunKod != yeniUrunKod)
                            okunanBitisTarihi = okunanBitisTarihi.AddHours(2);
                       while(baslangictarihiTatileDenkGeliyormu(okunanBitisTarihi))
                        {

                            okunanBitisTarihi = okunanBitisTarihi.AddDays(1);
                            yyyy = okunanBitisTarihi.Year;
                            mm = okunanBitisTarihi.Month;
                            dd = okunanBitisTarihi.Day;
                            hour = okunanBitisTarihi.Hour;
                            okunanBitisTarihi = new DateTime(yyyy, mm, dd, 00, 00, 00);

                        }
                        okunanBitisTarihi = fonksiyonBaslangicPazartesiMi(okunanBitisTarihi);
                        Hesaplanan = fonksiyonTatilGunuVarsaGec(okunanBitisTarihi, yeniToplamSure);



                        fonksiyonSiparisEkle(sp.adet, okunanBitisTarihi, Hesaplanan, yeniToplamSure, okunanHatNo, 3);
                        //fonksiyonsiparisEkle sonrasına;

                        fonksiyonHatBitisTarihiGuncelle(Hesaplanan, okunanHatNo, okunanSiparisKodu);
                        //fonksiyonhatBitisTarihGuncelle
                        fonksiyonSonrakiSiparisKoduIcinSiparisGuncelle(okunanSiparisKodu, txtSiparisKodu.Text);
                        #endregion

                        sonuc = true;
                        MessageBox.Show("3.kayıt");
                    }
                    catch (Exception) {
                        MessageBox.Show(hata.hataMesajı, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        hata.hataKodu = "frmSiparisEkle siparisAcilEkle 1.elseifi sonrasına kayıt kısmı";
                        hata.hataMesajiKaydet();
                        return false;
                    }
                }
                else if (onemsizOku.Read() && !bitisTarihiEnYakinOku.Read())
                {//Önemsizin yerine
                    try
                    {
                        MessageBox.Show("4");
                        #region
                        okunanBaslangicTarihi = Convert.ToDateTime(onemsizOku["baslangicTarihi"]);
                        okunanSonrakiSiparisKodu = onemsizOku["sonrakiSiparisKodu"].ToString();
                        okunanSiparisKodu = onemsizOku["siparisKod"].ToString();
                        okunanToplamSure = Convert.ToInt32(onemsizOku["toplamSure"]);
                        okunanBitisTarihi = Convert.ToDateTime(onemsizOku["bitisTarihi"]);
                        okunanHatNo = Convert.ToInt32(onemsizOku["kullanilacakHat"]);
                        fonksiyonSonrakiSiparisKoduIcinSiparisGuncelle(txtSiparisKodu.Text, okunanSiparisKodu);
                        okunanUrunKod = onemsizOku["urunKod"].ToString();

                        oncekiUrunKod = okunanUrunKod;
                        //dınguye girmden acilden sonra gelen siparis kodu güncelleniyor;
                        sonrakiIcinSiparisKodu = okunanSiparisKodu;

                        //İLK ÖNCE YENİ SİPARİŞ EKLENİYOr
                        #region
                        SqlCommand oncekiSiparisKoduSor = new SqlCommand("select urunKod from siparis where sonrakiSiparisKodu='" + okunanSiparisKodu + "'", veritabani.conn);
                        SqlDataReader okuu = oncekiSiparisKoduSor.ExecuteReader();
                        if (okuu.Read())
                        {
                            if (okuu["urunKod"].ToString() != yeniUrunKod)
                            {
                                okunanBaslangicTarihi = okunanBaslangicTarihi.AddHours(2);
                            }

                        }
                       while(baslangictarihiTatileDenkGeliyormu(okunanBaslangicTarihi))
                        {

                            okunanBaslangicTarihi = okunanBaslangicTarihi.AddDays(1);
                            yyyy = okunanBaslangicTarihi.Year;
                            mm = okunanBaslangicTarihi.Month;
                            dd = okunanBaslangicTarihi.Day;
                            hour = okunanBaslangicTarihi.Hour;
                            okunanBaslangicTarihi = new DateTime(yyyy, mm, dd, 00, 00, 00);

                        }
                        okunanBaslangicTarihi = fonksiyonBaslangicPazartesiMi(okunanBaslangicTarihi);
                        Hesaplanan = fonksiyonTatilGunuVarsaGec(okunanBaslangicTarihi, yeniToplamSure);

                        fonksiyonSiparisEkle(sp.adet, okunanBaslangicTarihi, Hesaplanan, yeniToplamSure, okunanHatNo, 3);
                        //bu siparişten sonra önemsiz geldiği için önemsizi işaret ediyor
                        fonksiyonSonrakiSiparisKoduIcinSiparisGuncelle(txtSiparisKodu.Text, okunanSiparisKodu);


                        #endregion
                        int i = 0;
                        // ÖNEMSİZİ GÜNCELLİYOR
                        #region

                        //önemsiz için bir kere giriyor;
                        okunanBitisTarihi = Hesaplanan;
                        if (okunanUrunKod != yeniUrunKod)
                            okunanBitisTarihi = Hesaplanan.AddHours(2);

                       while(baslangictarihiTatileDenkGeliyormu(okunanBitisTarihi))
                        {

                            okunanBitisTarihi = okunanBitisTarihi.AddDays(1);
                            yyyy = okunanBitisTarihi.Year;
                            mm = okunanBitisTarihi.Month;
                            dd = okunanBitisTarihi.Day;
                            hour = okunanBitisTarihi.Hour;
                            okunanBitisTarihi = new DateTime(yyyy, mm, dd, 00, 00, 00);

                        }
                        okunanBaslangicTarihi = okunanBitisTarihi;
                        okunanBitisTarihi = fonksiyonBaslangicPazartesiMi(okunanBitisTarihi);
                        okunanBitisTarihi = fonksiyonTatilGunuVarsaGec(okunanBitisTarihi, okunanToplamSure);

                        SqlCommand onemsizGuncelle = new SqlCommand();
                        onemsizGuncelle.Connection = veritabani.conn;
                        onemsizGuncelle.CommandText = "update siparis set baslangicTarihi=@baslangicTarihi,bitisTarihi=@bitisTarihi,bitTarih=@bitTarih,bitSaat=@bitSaat where siparisKod=@siparisKod";
                        onemsizGuncelle.Parameters.Clear();
                        onemsizGuncelle.Parameters.AddWithValue("@baslangicTarihi", okunanBaslangicTarihi);
                        onemsizGuncelle.Parameters.AddWithValue("@bitisTarihi", okunanBitisTarihi);
                        onemsizGuncelle.Parameters.AddWithValue("@bitTarih", okunanBitisTarihi.ToShortDateString());
                        onemsizGuncelle.Parameters.AddWithValue("@bitSaat", okunanBitisTarihi.Hour);
                        onemsizGuncelle.Parameters.AddWithValue("@siparisKod", okunanSiparisKodu);
                        onemsizGuncelle.ExecuteNonQuery();

                        /*
                        SqlCommand gunOnemsiz = new SqlCommand("update siparis set baslangicTarihi=DATEADD(hour," + yeniToplamSure + ",baslangicTarihi),bitisTarihi=DATEADD(hour," + yeniToplamSure + ",bitisTarihi),bitTarih=convert(nvarchar(10),DATEADD(hour," + yeniToplamSure + ",bitisTarihi),104),bitSaat=DATEPART(HOUR, DATEADD(hour," + yeniToplamSure + ",bitisTarihi)) where siparisKod='" + okunanSiparisKodu + "'", veritabani.conn);

                        gunOnemsiz.ExecuteNonQuery();
                      
                         */


                        #endregion
                        //ÖNEMSİZDEN SONRAKİLER GÜNCELLENİYOR
                        #region
                        while (okunanSonrakiSiparisKodu != "")
                        {
                            try
                            {
                                veritabani.baglan();

                                SqlCommand sonrakiSiparisBilgileriniOku = new SqlCommand("select * from siparis where siparisKod='" + okunanSonrakiSiparisKodu + "'", veritabani.conn);
                                SqlDataReader okuSonrakibilgi = sonrakiSiparisBilgileriniOku.ExecuteReader();

                                if (okuSonrakibilgi.Read())
                                {
                                    okunanUrunKod = okuSonrakibilgi["urunKod"].ToString();
                                    if (oncekiUrunKod != okunanUrunKod)
                                        okunanBitisTarihi = okunanBitisTarihi.AddHours(2);

                                    okunanSonrakiSiparisKodu = okuSonrakibilgi["sonrakiSiparisKodu"].ToString();
                                    okunanSiparisKodu = okuSonrakibilgi["siparisKod"].ToString();
                                    okunanToplamSure = Convert.ToInt32(okuSonrakibilgi["toplamSure"]);



                                    oncekiUrunKod = okunanSiparisKodu;

                                   while(baslangictarihiTatileDenkGeliyormu(okunanBitisTarihi))
                                    {

                                        okunanBitisTarihi = okunanBitisTarihi.AddDays(1);
                                        yyyy = okunanBitisTarihi.Year;
                                        mm = okunanBitisTarihi.Month;
                                        dd = okunanBitisTarihi.Day;
                                        hour = okunanBitisTarihi.Hour;
                                        okunanBitisTarihi = new DateTime(yyyy, mm, dd, 00, 00, 00);

                                    }
                                    okunanBaslangicTarihi = okunanBitisTarihi;
                                    okunanBitisTarihi = fonksiyonBaslangicPazartesiMi(okunanBitisTarihi);
                                    okunanBitisTarihi = fonksiyonTatilGunuVarsaGec(okunanBitisTarihi, okunanToplamSure);

                                    SqlCommand onemsizGuncelle1 = new SqlCommand();
                                    onemsizGuncelle1.Connection = veritabani.conn;
                                    onemsizGuncelle1.CommandText = "update siparis set baslangicTarihi=@baslangicTarihi,bitisTarihi=@bitisTarihi,bitTarih=@bitTarih,bitSaat=@bitSaat where siparisKod=@siparisKod";
                                    onemsizGuncelle1.Parameters.Clear();
                                    onemsizGuncelle1.Parameters.AddWithValue("@baslangicTarihi", okunanBaslangicTarihi);
                                    onemsizGuncelle1.Parameters.AddWithValue("@bitisTarihi", okunanBitisTarihi);
                                    onemsizGuncelle1.Parameters.AddWithValue("@bitTarih", okunanBitisTarihi.ToShortDateString());
                                    onemsizGuncelle1.Parameters.AddWithValue("@bitSaat", okunanBitisTarihi.Hour);
                                    onemsizGuncelle1.Parameters.AddWithValue("@siparisKod", okunanSiparisKodu);
                                    onemsizGuncelle1.ExecuteNonQuery();


                                }


                                /*
                                SqlCommand gun = new SqlCommand("update siparis set baslangicTarihi=DATEADD(hour," + yeniToplamSure + ",baslangicTarihi),bitisTarihi=DATEADD(hour," + yeniToplamSure + ",bitisTarihi),bitTarih=convert(nvarchar(10),DATEADD(hour," + yeniToplamSure + ",bitisTarihi),104),bitSaat=DATEPART(HOUR, DATEADD(hour," + yeniToplamSure + ",bitisTarihi)) where siparisKod='" + okunanSiparisKodu + "'", veritabani.conn);

                                gun.ExecuteNonQuery();
                               */
                                /*
                                    SqlCommand sor = new SqlCommand("select siparisKod,sonrakiSiparisKodu from siparis where siparisKod='" + okunanSonrakiSiparisKodu + "'",veritabani.conn);
                                    SqlDataReader oku = sor.ExecuteReader();
                                    if (oku.Read())
                                    {
                                        okunanSiparisKodu = oku["siparisKod"].ToString();
                                        okunanSonrakiSiparisKodu = oku["sonrakiSiparisKodu"].ToString();
                                    }
                                  */

                            }catch(Exception){
                                MessageBox.Show(hata.hataMesajı, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                hata.hataKodu = "frmSiparisEkle siparisAcilEkle 2. elseifin while ";
                                hata.hataMesajiKaydet();
                                return false;
                            }

                        }
                        #endregion


                        //HATBİTİSTARİH TABLOSU GÜNCELLNİYOR. EN SON Kİ BİTİŞ TARİHİ YAZILIR
                        #region
                        SqlCommand HatBitisTarihGuncelle = new SqlCommand();
                        HatBitisTarihGuncelle.Connection = veritabani.conn;
                        HatBitisTarihGuncelle.CommandText = "update hatBitisTarih set bitisTarihi=@bitisTarihi,tarih=@tarih,saat=@saat where siparisKodu=@siparisKodu";
                        HatBitisTarihGuncelle.Parameters.Clear();
                        HatBitisTarihGuncelle.Parameters.AddWithValue("@bitisTarihi", okunanBitisTarihi);
                        HatBitisTarihGuncelle.Parameters.AddWithValue("@tarih", okunanBitisTarihi.ToShortDateString());
                        HatBitisTarihGuncelle.Parameters.AddWithValue("@saat", okunanBitisTarihi.Hour);
                        HatBitisTarihGuncelle.Parameters.AddWithValue("@siparisKodu", okunanSiparisKodu);
                        HatBitisTarihGuncelle.ExecuteNonQuery();
                        /*
                        SqlCommand hatBitisTarihGun = new SqlCommand("update hatBitisTarih set bitisTarihi=DATEADD(hour," + yeniToplamSure + ",bitisTarihi),tarih=convert(nvarchar(10),DATEADD(hour," + yeniToplamSure + ",bitisTarihi),104),saat=DATEPART(HOUR, DATEADD(hour," + yeniToplamSure + ",bitisTarihi)) where hatNo='" + okunanHatNo + "'", veritabani.conn);
                        hatBitisTarihGun.ExecuteNonQuery();
                        */
                        #endregion


                        MessageBox.Show("4.kayıt");
                        sonuc = true;



                        #endregion


                        #region
                        /*int i = 0;
                while (i < 1)
                {
                 * //BU KOD BLOGUDA KULLANILABİLİR
                    //önemsiz için bir kere giriyor;
                    SqlCommand gunOnemsiz = new SqlCommand("update siparis set baslangicTarihi=DATEADD(hour," + yeniToplamSure + ",baslangicTarihi),bitisTarihi=DATEADD(hour," + yeniToplamSure + ",bitisTarihi),bitTarih=convert(nvarchar(10),DATEADD(hour," + yeniToplamSure + ",bitisTarihi),104),bitSaat=DATEPART(HOUR, DATEADD(hour," + yeniToplamSure + ",bitisTarihi)) where siparisKod='" + okunanSiparisKodu + "'", veritabani.conn);

                    gunOnemsiz.ExecuteNonQuery();
                    i = 1;

                }
                while (okunanSonrakiSiparisKodu != "")
                {
                    veritabani.baglan();
                    SqlCommand gun = new SqlCommand("update siparis set baslangicTarihi=DATEADD(hour," + yeniToplamSure + ",baslangicTarihi),bitisTarihi=DATEADD(hour," + yeniToplamSure + ",bitisTarihi),bitTarih=convert(nvarchar(10),DATEADD(hour," + yeniToplamSure + ",bitisTarihi),104),bitSaat=DATEPART(HOUR, DATEADD(hour," + yeniToplamSure + ",bitisTarihi)) where siparisKod='" + okunanSiparisKodu + "'", veritabani.conn);

                    gun.ExecuteNonQuery();


                    SqlCommand sor = new SqlCommand("select siparisKod,sonrakiSiparisKodu from siparis where siparisKod='" + okunanSonrakiSiparisKodu + "'", veritabani.conn);
                    SqlDataReader oku = sor.ExecuteReader();
                    if (oku.Read())
                    {
                        okunanSiparisKodu = oku["siparisKod"].ToString();
                        okunanSonrakiSiparisKodu = oku["sonrakiSiparisKodu"].ToString();
                    }




                } 
                
               
                //fonksiyonSiparisekleyiçağır
                
                SqlCommand hatBitisTarihGun = new SqlCommand("update hatBitisTarih set bitisTarihi=DATEADD(hour," + yeniToplamSure + ",bitisTarihi),tarih=convert(nvarchar(10),DATEADD(hour," + yeniToplamSure + ",bitisTarihi),104),saat=DATEPART(HOUR, DATEADD(hour," + yeniToplamSure + ",bitisTarihi)) where hatNo='" + okunanHatNo + "'", veritabani.conn);
                hatBitisTarihGun.ExecuteNonQuery();

                fonksiyonSiparisEkle(sp.adet, okunanBaslangicTarihi, okunanBaslangicTarihi.AddHours(yeniToplamSure), yeniToplamSure, okunanHatNo, 3);
               
                //BURA KALDI
               */
                        #endregion
                    }catch(Exception){
                        MessageBox.Show(hata.hataMesajı, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        hata.hataKodu = "frmSiparisEkle siparisAcilEkle 2.else if önemsizin yerine kayıt genel";
                        hata.hataMesajiKaydet();
                        return false;
                    
                    }
                }

                else
                    sonuc = false;


                return sonuc;
            }catch(Exception){
                return false;
            }
        }

        private void txtBoy_TextChanged(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(txtBoy, "Boyu milimetre cinsinden giriniz");
        }
        int tatilGununeDenkGelenSaatSayisi = 0;

        //kullanılmayan bir fonksyion
       private void kacPazarVar(DateTime baslangic,DateTime bitis){
           int toplamSaat;
           try
           {
               veritabani.baglan();
               SqlCommand ayarlardanSor = new SqlCommand("select * from Ayarlar ", veritabani.conn);
               SqlDataReader ayarlardanOku = ayarlardanSor.ExecuteReader();

               if (ayarlardanOku.Read())
               {
                   string gun = ayarlardanOku["tatilGunu"].ToString();

                   toplamSaat = (int)bitis.Subtract(baslangic).TotalHours;

                   var tarihListe = Enumerable.Range(1, toplamSaat).Select(e => baslangic.AddHours(e));
                   switch (gun)
                   {

                       case "YOK": tatilGununeDenkGelenSaatSayisi = 0; break;
                       case "PAZARTESİ":
                           tatilGununeDenkGelenSaatSayisi = tarihListe.Where(e => e.DayOfWeek == DayOfWeek.Monday).Count(); break;

                       case "SALI":

                           tatilGununeDenkGelenSaatSayisi = tarihListe.Where(e => e.DayOfWeek == DayOfWeek.Tuesday).Count(); break;

                       case "ÇARŞAMBA":

                           tatilGununeDenkGelenSaatSayisi = tarihListe.Where(e => e.DayOfWeek == DayOfWeek.Wednesday).Count(); break;
                       case "PERŞEMBE":
                           tatilGununeDenkGelenSaatSayisi = tarihListe.Where(e => e.DayOfWeek == DayOfWeek.Thursday).Count(); break;
                       case "CUMA":
                           tatilGununeDenkGelenSaatSayisi = tarihListe.Where(e => e.DayOfWeek == DayOfWeek.Friday).Count(); break;
                       case "CUMARTESİ":
                           tatilGununeDenkGelenSaatSayisi = tarihListe.Where(e => e.DayOfWeek == DayOfWeek.Saturday).Count(); break;
                       case "PAZAR":
                           tatilGununeDenkGelenSaatSayisi = tarihListe.Where(e => e.DayOfWeek == DayOfWeek.Sunday).Count(); break;

                   }





               }
           }catch(Exception){
               MessageBox.Show(hata.hataMesajı, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               hata.hataKodu = "frmSiparisEkle kacPazarVar Fonksyionu";
               hata.hataMesajiKaydet();
           }
       }

       private bool TatilGunuMu(string yeniTarih) {
           SqlCommand tatilGunleriOku = new SqlCommand("select count(*) from TatilGunleri where tarih='"+yeniTarih+"' ", veritabani.conn);
           int tatilGunleriSayisi = Convert.ToInt16( tatilGunleriOku.ExecuteScalar());
           if (tatilGunleriSayisi == 1)
               return true;
           else
               return false;
       
       }

       public DateTime fonksiyonTatilGunuVarsaGec(DateTime baslangic,int totalSure) {
           try
           {

               string gun;
               int sayi = 1, step = 1,tatilGunuSayisi,bir=0;
               DateTime bitis = baslangic;
               SqlCommand ayarlardanSor = new SqlCommand("select * from Ayarlar ", veritabani.conn);
               SqlDataReader ayarlardanOku = ayarlardanSor.ExecuteReader();
              

               var tarihListe = Enumerable.Range(1, 0).Select(e => baslangic.AddHours(e));
               if (ayarlardanOku.Read())
               {
                   gun = ayarlardanOku["tatilGunu"].ToString();
                   if (gun.ToUpper() == "YOK")
                   {
                       while (sayi <= totalSure)
                       {    
                           if(TatilGunuMu(bitis.AddHours(step).ToShortDateString())){
                               bitis = bitis.AddHours(32);
                           
                           }
                          
                           else if (bitis.AddHours(step).DayOfWeek == DayOfWeek.Monday)
                           {
                               bitis = bitis.AddHours(8);
                               sayi++;

                           }
                            
                           else
                           {
                               bitis = bitis.AddHours(1);
                               sayi++;
                           }
                       }
                       //bitis = baslangic.AddHours(totalSure);
                      
                      
                   }
                   else
                   {
                       switch (gun)
                       {
                           #region

                           case "PAZARTESİ":
                               while (sayi <= totalSure)
                               {

                                   if (TatilGunuMu(bitis.AddHours(step).ToShortDateString()))
                                   {
                                       bitis = bitis.AddHours(32);

                                   }
                                   else if (bitis.AddHours(step).DayOfWeek == DayOfWeek.Tuesday && bitis.Hour < 8)
                                   {
                                       bitis = bitis.AddHours(8 - bitis.Hour);


                                   }
                                   else if (bitis.AddHours(step).DayOfWeek == DayOfWeek.Monday)
                                   {
                                       bitis = bitis.AddHours(25);
                                       sayi++;

                                   }
                                   else
                                   {
                                       bitis = bitis.AddHours(1);
                                       sayi++;
                                   }
                               } break;


                           case "SALI":

                               while (sayi <= totalSure)
                               {
                                   if (TatilGunuMu(bitis.AddHours(step).ToShortDateString()))
                                   {
                                       bitis = bitis.AddHours(32);

                                   }
                                   else if (bitis.AddHours(step).DayOfWeek == DayOfWeek.Wednesday && bitis.Hour < 8)
                                   {
                                       bitis = bitis.AddHours(8 - bitis.Hour);


                                   }
                                   else if (bitis.AddHours(step).DayOfWeek == DayOfWeek.Tuesday)
                                   {
                                       bitis = bitis.AddHours(25);
                                       sayi++;

                                   }
                                   else
                                   {
                                       bitis = bitis.AddHours(1);
                                       sayi++;
                                   }
                               } break;

                           case "ÇARŞAMBA":

                               while (sayi <= totalSure)
                               {
                                   if (TatilGunuMu(bitis.AddHours(step).ToShortDateString()))
                                   {
                                       bitis = bitis.AddHours(32);

                                   }
                                   else if (bitis.AddHours(step).DayOfWeek == DayOfWeek.Thursday && bitis.Hour < 8)
                                   {
                                       bitis = bitis.AddHours(8 - bitis.Hour);


                                   }
                                   else if (bitis.AddHours(step).DayOfWeek == DayOfWeek.Wednesday)
                                   {
                                       bitis = bitis.AddHours(25);
                                       sayi++;

                                   }
                                   else
                                   {
                                       bitis = bitis.AddHours(1);
                                       sayi++;
                                   }
                               } break;
                           case "PERŞEMBE":
                               while (sayi <= totalSure)
                               {
                                   if (TatilGunuMu(bitis.AddHours(step).ToShortDateString()))
                                   {
                                       bitis = bitis.AddHours(32);

                                   }
                                   else if (bitis.AddHours(step).DayOfWeek == DayOfWeek.Friday && bitis.Hour < 8)
                                   {
                                       bitis = bitis.AddHours(8 - bitis.Hour);


                                   }
                                   else if (bitis.AddHours(step).DayOfWeek == DayOfWeek.Thursday)
                                   {
                                       bitis = bitis.AddHours(25);
                                       sayi++;

                                   }
                                   else
                                   {
                                       bitis = bitis.AddHours(1);
                                       sayi++;
                                   }
                               } break;
                           case "CUMA":
                               while (sayi <= totalSure)
                               {
                                   if (TatilGunuMu(bitis.AddHours(step).ToShortDateString()))
                                   {
                                       bitis = bitis.AddHours(32);

                                   }
                                   else if (bitis.AddHours(step).DayOfWeek == DayOfWeek.Saturday && bitis.Hour < 8)
                                   {
                                       bitis = bitis.AddHours(8 - bitis.Hour);


                                   }
                                   else if (bitis.AddHours(step).DayOfWeek == DayOfWeek.Friday)
                                   {
                                       bitis = bitis.AddHours(25);
                                       sayi++;

                                   }
                                   else
                                   {
                                       bitis = bitis.AddHours(1);
                                       sayi++;
                                   }
                               }; break;
                           case "CUMARTESİ":
                               while (sayi <= totalSure)
                               {
                                   if (TatilGunuMu(bitis.AddHours(step).ToShortDateString()))
                                   {
                                       bitis = bitis.AddHours(32);

                                   }
                                   else if (bitis.AddHours(step).DayOfWeek == DayOfWeek.Sunday && bitis.Hour < 8)
                                   {
                                       bitis = bitis.AddHours(8 - bitis.Hour);


                                   }
                                   else if (bitis.AddHours(step).DayOfWeek == DayOfWeek.Saturday)
                                   {
                                       bitis = bitis.AddHours(25);
                                       sayi++;

                                   }
                                   else
                                   {
                                       bitis = bitis.AddHours(1);
                                       sayi++;
                                   }
                               } break;
                           case "PAZAR":
                               while (sayi <= totalSure)
                               {
                                  
                                   if (TatilGunuMu(bitis.AddHours(step).ToShortDateString()))
                                       bitis = bitis.AddHours(32);

                                   else if (bitis.AddHours(step).DayOfWeek == DayOfWeek.Monday && bitis.Hour<8 )
                                   {
                                       bitis = bitis.AddHours(8-bitis.Hour);
                                      
                                     
                                   }
                                   else if (bitis.AddHours(step).DayOfWeek == DayOfWeek.Sunday)
                                   {
                                       bitis = bitis.AddHours(25);
                                       sayi++;

                                   }
                                   else
                                   {
                                       bitis = bitis.AddHours(1);
                                       sayi++;
                                   }
                                   
                               }
 
                               break;
                            
                                        
                           
                          
                           #endregion
                       }


                   }


               }

               
               return bitis;
           }catch(Exception){
               MessageBox.Show(hata.hataMesajı, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               hata.hataKodu = "frmSiparisEkle fonksiyonTatilGunuVarsaGec fonksiyonu";
               hata.hataMesajiKaydet();
               return DateTime.Now;
           
           }
       }
       public bool baslangictarihiTatileDenkGeliyormu(DateTime baslangic) {
           try
           {
               veritabani.baglan();
               var baslangicGunu = String.Format("{0:dddd}", baslangic);
               bool durum = false;
               string gun;
               SqlCommand ayarlardanSor = new SqlCommand("select * from Ayarlar ", veritabani.conn);
               SqlDataReader ayarlardanOku = ayarlardanSor.ExecuteReader();
              

               if (ayarlardanOku.Read())
               {

                   gun = ayarlardanOku["tatilGunu"].ToString();
                   if (gun.ToUpper() == baslangicGunu.ToUpper())
                   {
                       durum = true;

                   }
                   else
                       durum = false;

               }
               SqlCommand tatilGunlerindenSor = new SqlCommand("select tarih from TatilGunleri where tarih='"+baslangic.ToShortDateString()+"'",veritabani.conn);
               SqlDataReader oku = tatilGunlerindenSor.ExecuteReader();
               if (oku.Read()) {
                   durum = true;
               
               }

               return durum;

           }catch(Exception){
               MessageBox.Show(hata.hataMesajı, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               hata.hataKodu = "frmSiparisEkle baslangictarihiTatileDenkGeliyormu fonksiyonu";
               return false;
           }
       
       }

       public DateTime fonksiyonBaslangicPazartesiMi(DateTime baslangic) {
           if (baslangic.DayOfWeek == DayOfWeek.Monday && baslangic.Hour<8) {
               baslangic = baslangic.AddHours(8-baslangic.Hour);
           }

           return baslangic;
       } 
    }
}
