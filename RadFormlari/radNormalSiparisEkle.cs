using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;
using uretimPlanlamaProgrami.RadFormlari;


namespace uretimPlanlamaProgrami
{
    public partial class radNormalSiparisEkle : Telerik.WinControls.UI.RadForm
    {
        public radNormalSiparisEkle()
        {
            InitializeComponent();
        }
        hatalar hata = new hatalar();
        DateTime hatBitisTarihi;

        SqlCommand siparisEkle;
        SqlCommand hatBitisTarihiEkle;
        string urunKod;
        int ham;
        int renk;
        string oncelik;
        int sureDakka;
        float gerekliUrunMiktari = 0.0F;
        Siparis sp = new Siparis();
        bool kayitBasarilimi;
        DateTime Hesaplanan;
        int yyyy;
        int mm;
        int dd;
        int hour;
        int minute;
        private void radNormalSiparisEkle_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'genelDataSet.FirmaAdlari' table. You can move, or remove it, as needed.
            this.firmaAdlariTableAdapter.Fill(this.genelDataSet.FirmaAdlari);
            fonksiyonComboYapilandirma();

            pnlSiparisTeslimBilgileri.Visible = false;
            // TODO: This line of code loads data into the 'genelDataSet.renkler' table. You can move, or remove it, as needed.
            btnYeniEkle.Enabled = false;

        }
        public void fonksiyonComboYapilandirma()
        {
            try
            {
                lblSiparisKod.Text = "";
                lblUrunKodu.Text = "";
                lblRenk.Text = "";
                lblOncelik.Text = "";
                lblHammadde.Text = "";
                lblFirmaAdi.Text = "";
                lblDurum.Text = "";
                lblBoy.Text = "";
                lblAdet.Text = "";



                this.cmbUrunKod.MultiColumnComboBoxElement.DropDownHeight = 300;
                this.cmbUrunKod.MultiColumnComboBoxElement.DropDownWidth = 500;
                this.cmbRenk.MultiColumnComboBoxElement.DropDownHeight = 300;
                this.cmbRenk.MultiColumnComboBoxElement.DropDownWidth = 200;

                this.cmbHammadde.MultiColumnComboBoxElement.DropDownHeight = 300;
                this.cmbHammadde.MultiColumnComboBoxElement.DropDownWidth = 200;
                this.cmbOncelikSirasi.MultiColumnComboBoxElement.DropDownWidth = 200;
                this.cmbOncelikSirasi.MultiColumnComboBoxElement.DropDownHeight = 200;

                // this.cmbUrunKod.AutoSizeDropDownToBestFit = true;

                //cmmÜrünler için
                this.cmbUrunKod.AutoFilter = true;
                this.cmbUrunKod.DisplayMember = "UrunKodu";
                FilterDescriptor filter = new FilterDescriptor();
                filter.PropertyName = this.cmbUrunKod.DisplayMember;
                filter.Operator = FilterOperator.Contains;
                this.cmbUrunKod.EditorControl.MasterTemplate.FilterDescriptors.Add(filter);

                this.cmbRenk.AutoFilter = true;
                this.cmbRenk.DisplayMember = "renkAdi";
                FilterDescriptor filter1 = new FilterDescriptor();
                filter1.PropertyName = this.cmbRenk.DisplayMember;
                filter1.Operator = FilterOperator.Contains;
                this.cmbRenk.EditorControl.MasterTemplate.FilterDescriptors.Add(filter1);

                this.cmbHammadde.AutoFilter = true;
                this.cmbHammadde.DisplayMember = "adi";
                FilterDescriptor filter2 = new FilterDescriptor();
                filter2.PropertyName = this.cmbHammadde.DisplayMember;
                filter2.Operator = FilterOperator.Contains;
                this.cmbHammadde.EditorControl.MasterTemplate.FilterDescriptors.Add(filter2);

                cmbOncelikSirasi.DropDownStyle = RadDropDownStyle.DropDownList;
                cmbOncelikSirasi.Columns.Add("Öncelik Sırası");
                cmbOncelikSirasi.Columns[0].Width = 200;

                RadGridView gridViewControl = this.cmbOncelikSirasi.EditorControl;
                gridViewControl.MasterTemplate.AutoGenerateColumns = false;

                gridViewControl.Rows.Add("Önemsiz");
                gridViewControl.Rows.Add("Normal");
                gridViewControl.Rows.Add("Acil");

                this.renklerTableAdapter.Fill(this.genelDataSet.renkler);
                // TODO: This line of code loads data into the 'genelDataSet.hammadde' table. You can move, or remove it, as needed.
                this.hammaddeTableAdapter.Fill(this.genelDataSet.hammadde);
                // TODO: This line of code loads data into the 'genelDataSet.urunler' table. You can move, or remove it, as needed.
                this.urunlerTableAdapter.Fill(this.genelDataSet.urunler);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hata.hataKodu = "radNormalSiparisEkle-fonksiyonComboYapilandirma";
                hata.hataMesajı = ex.Message;
                hata.hataMesajiKaydet();

            }


        }

        private void cmbUrunKod_TextChanged(object sender, EventArgs e)
        {


        }

        private void cmbUrunKod_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private bool fonksiyonTextBoxControl()
        {
            bool tammi = false;

            if (txtSiparisKodu.Text == "")
            {
                lblSiparisKod.Text = "Sipariş kodu boş bırakılamaz!";

            }
            else if (txtFirmaAdi.Text == "")
            {

                lblSiparisKod.Text = "";
                lblFirmaAdi.Text = "Firma adı boş bırakılamaz!";

            }
            else if (cmbUrunKod.SelectedIndex == -1)
            {
                lblSiparisKod.Text = "";
                lblFirmaAdi.Text = "";
                lblUrunKodu.Text = "Ürün kodunu seçiniz!";


            }
            else if (cmbHammadde.SelectedIndex == -1)
            {
                lblSiparisKod.Text = "";
                lblFirmaAdi.Text = "";
                lblUrunKodu.Text = "";
                lblHammadde.Text = "Bir hammadde seçiniz!";
            }

            else if (txtBoy.Text == "")
            {
                lblSiparisKod.Text = "";
                lblFirmaAdi.Text = "";
                lblHammadde.Text = "";
                lblUrunKodu.Text = "";
                lblBoy.Text = "Sipariş Boyunu giriniz!";

            }
            else if (txtAdet.Text == "")
            {

                lblFirmaAdi.Text = "";
                lblHammadde.Text = "";
                lblOncelik.Text = "";
                lblBoy.Text = "";
                lblUrunKodu.Text = "";
                lblAdet.Text = "Sipariş adetini giriniz!";

            }
            else if (cmbRenk.SelectedIndex == -1)
            {
                lblUrunKodu.Text = "";
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
                lblRenk.Text = "";
            }
            else
            {
                lblRenk.Text = "";
                tammi = true;

            }
            return tammi;
        }
        private void btnSiparisEkle_Click(object sender, EventArgs e)
        {
            DialogResult cevap = MessageBox.Show("Sipariş kaydedilecek.Bu işlemi onaylıyor musunuz?", "BİLGİ", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes)
            {
                this.Cursor = Cursors.WaitCursor;
                hata.hataMesajı = "Sipariş eklenirken bir hata oluştu.";
                veritabani.baglan();

                int second;
               
                #region
                if (fonksiyonTextBoxControl() == false)
                {
                    this.Cursor = Cursors.Default;
                    lblDurum.BackColor = Color.Red;
                    lblDurum.ForeColor = Color.White;
                    lblDurum.Text = "Lütfen bilgileri tam doldurun! ";
                }
                #endregion//KONTTROLLER
                else
                {
                    this.Cursor = Cursors.WaitCursor;
                    try
                    {

                        lblDurum.Text = "";
                        #region

                        int saatTotal;
                        int topSure;
                        urunKod = cmbUrunKod.SelectedValue.ToString();
                        ham = Convert.ToInt16(cmbHammadde.SelectedValue);

                        renk = Convert.ToInt16(cmbRenk.SelectedValue);
                        oncelik = cmbOncelikSirasi.GetPlainText();

                        //sureDakka = 0.0F;
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
                        else
                        {
                            hour = hour + 1;

                        }


                        bugunTarihSaat = new DateTime(yyyy, mm, dd, hour, 00, 00);
                        string sadeceTarih;
                        int sadeceSaat;



                        int sureSaniye = 0;
                        sp.adet = Convert.ToInt64(txtAdet.Text);
                        sp.boy = Convert.ToInt64(txtBoy.Text);
                        SqlCommand sor = new SqlCommand("select * from urunler where kod='" + cmbUrunKod.GetPlainText() + "'", veritabani.conn);
                        SqlDataReader oku = sor.ExecuteReader();

                        if (oku.Read())
                        {
                            sp.gramaj = Convert.ToInt32(oku["gramaj"]);
                            sp.hiz = Convert.ToInt32(oku["hizi"]);
                            sp.fireMiktari = Convert.ToInt32(oku["fireMiktari"]);

                        }
                        float boyMetre = ((float)(sp.boy) / 1000);
                        boyMetre = (boyMetre) * (float)(sp.fireMiktari + 100) / 100;

                        float boyMetreAdet = boyMetre * sp.adet;
                        float boyMetreBoluHiz =(float) boyMetreAdet / sp.hiz;


                        sureDakka = (int)boyMetreBoluHiz;
                        //sureDakka =(float) ( * sp.adet) / sp.hiz;

                        float gramaj = boyMetreAdet * sp.gramaj;
                        float gramajYuzde = gramaj * (float)sp.fireMiktari / 100;
                        gerekliUrunMiktari = gramaj + gramajYuzde;
                      //  gerekliUrunMiktari = (float)gerekliUrunMiktari / 1000;
                      //  gerekliUrunMiktari = (float)((float)sp.gramaj * sp.boy) + (float)((((float)sp.gramaj * sp.boy) * (float)sp.fireMiktari / 100));

                   

                        sureSaniye = (int)sureDakka * 60;
                        if (sureDakka % 60 == 0)
                            saatTotal = (int)sureDakka / 60;
                        else
                        {
                            sureDakka = (int)(sureDakka + (60 - (sureDakka % 60)));

                            saatTotal = (int)sureDakka / 60;
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
                        hata.hataKodu = "radNormalSiparisEkle hesaplama kısmı";

                        #endregion
                        int uygunHatVarmi = uygunHatBul(urunKod);

                        if (uygunHatVarmi != -1)
                        {
                            try
                            {

                                #region
                                veritabani.baglan();
                                //hatlardan boş olana hemen kayıt
                                //direk kayıt
                                if (bugunTarihSaat > DateTime.Now)
                                    devamDurumu = 3;

                                //fonksiyonDirekKayit;


                                while (baslangictarihiTatileDenkGeliyormu(bugunTarihSaat))
                                {

                                    bugunTarihSaat = bugunTarihSaat.AddDays(1);
                                    yyyy = bugunTarihSaat.Year;
                                    mm = bugunTarihSaat.Month;
                                    dd = bugunTarihSaat.Day;
                                    hour = bugunTarihSaat.Hour;
                                    bugunTarihSaat = new DateTime(yyyy, mm, dd, 08, 00, 00);


                                }
                                bugunTarihSaat = fonksiyonBaslangicPazartesiMi(bugunTarihSaat);
                                Hesaplanan = fonksiyon.fonksiyonSiparisBitisTarihiBul (bugunTarihSaat, topSure);

                                fonksiyonSiparisEkle(sp.adet, bugunTarihSaat, Hesaplanan, topSure, uygunHatVarmi, devamDurumu);
                                fonksiyonHatBitisTarihiGuncelle(Hesaplanan, uygunHatVarmi, txtSiparisKodu.Text);
                                fonksyionUretimHattiAktiflestirme(uygunHatVarmi);

                                //BURDAYIZZZZZZZ
                                kayitBasarilimi = true;
                                //lblBasTarihi.Text = bugunTarihSaat.ToString();
                            }
                            catch (Exception)
                            {
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


                                        while (baslangictarihiTatileDenkGeliyormu(hatBitisTarihi))
                                        {

                                            hatBitisTarihi = hatBitisTarihi.AddDays(1);
                                            yyyy = hatBitisTarihi.Year;
                                            mm = hatBitisTarihi.Month;
                                            dd = hatBitisTarihi.Day;
                                            hour = hatBitisTarihi.Hour;
                                            hatBitisTarihi = new DateTime(yyyy, mm, dd, 08, 00, 00);

                                        }
                                        hatBitisTarihi = fonksiyonBaslangicPazartesiMi(hatBitisTarihi);
                                        Hesaplanan = fonksiyon.fonksiyonSiparisBitisTarihiBul(hatBitisTarihi, topSure);
                                        sonuc = hatBitisTarihi.AddHours(topSure);

                                        fonksiyonSiparisEkle(sp.adet, hatBitisTarihi, Hesaplanan, topSure, hatno, 3);
                                        // fonksiyonSonrakiSiparisKoduIcinSiparisGuncelle(sonrakiIcinSiparisKodu);
                                       // fonksiyonHatBitisTarihiGuncelle(Hesaplanan, hatno, txtSiparisKodu.Text);
                                        fonksiyon.fonksiyonHatBitisTarihiGuncelle(Hesaplanan, hatno, txtSiparisKodu.Text);
                                        fonksiyonSonrakiSiparisKoduIcinSiparisGuncelle(sonrakiIcinSiparisKodu, txtSiparisKodu.Text);
                                        kayitBasarilimi = true;

                                    }
                                    catch (Exception)
                                    {
                                        MessageBox.Show(hata.hataMesajı, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        hata.hataKodu = "radNormalSiparisEkle ACİL DEĞİLSE EKLEME KISMI";


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
                            enabled(false);
                          

                            this.Cursor = Cursors.Default;
                            MessageBox.Show("Sipariş kaydı başarılı.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            pnlSiparisTeslimBilgileri.Visible = true;


                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                            MessageBox.Show("Sipariş kaydında bir hata meydana geldi!", "------HATA-------", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                        #endregion
                        veritabani.baglantiyiKes();
                    }
                    catch (Exception ex)
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        hata.hataKodu = "radNormalSiparisEkle-btnSiparisEkle_Click";
                        hata.hataMesajı = ex.Message;
                        hata.hataMesajiKaydet();

                    }
                }
            }

        }
        public void fonksyionUretimHattiAktiflestirme(int HatNo)
        {
            try
            {
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hata.hataKodu = "radNormalSiparisEkle-fonksyionUretimHattiAktiflestirme";
                hata.hataMesajı = ex.Message;
                hata.hataMesajiKaydet();

            }

        }
        public void fonksyionSiparisSureBul() { 
                
        
        }
        private string fonksiyonSonrakiSiparisleriGuncelle(string siparisKodu, DateTime baslangicTarihi, DateTime bitisTarihi)
        {
            try
            {
                string donenecekDeger;
                SqlCommand siparisGuncelle = new SqlCommand();
                siparisGuncelle.Connection = veritabani.conn;
                veritabani.baglan();
                string bitTarih = bitisTarihi.ToShortDateString();
                int bitSaat = bitisTarihi.Hour;


                siparisGuncelle.CommandText = "update siparis set baslangicTarihi=@baslangicTarihi,bitisTarihi=@bitisTarihi,bitTarih=@bitTarih,bitSaat=@bitSaat where siparisKod=@siparisKod";
                siparisGuncelle.Parameters.Clear();
                siparisGuncelle.Parameters.AddWithValue("@baslangicTarihi", baslangicTarihi);
                siparisGuncelle.Parameters.AddWithValue("@bitisTarihi", bitisTarihi);
                siparisGuncelle.Parameters.AddWithValue("@bitTarih", bitTarih);
                siparisGuncelle.Parameters.AddWithValue("@bitSaat", bitSaat);
                siparisGuncelle.Parameters.AddWithValue("@siparisKod", siparisKodu);
                siparisGuncelle.ExecuteNonQuery();


                SqlCommand birSonrakiSiparisKoduAl = new SqlCommand("select sonrakiSiparisKodu from siparis where siparisKod='" + siparisKodu + "'", veritabani.conn);
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hata.hataKodu = "radNormalSiparisEkle-fonksiyonSonrakiSiparisleriGuncelle";
                hata.hataMesajı = ex.Message;
                hata.hataMesajiKaydet();
                return "NULL";
            }


        }


        private void frmSiparisEkle_FormClosed(object sender, FormClosedEventArgs e)
        {
            veritabani.baglantiyiKes();
        }


        public void fonksiyonSonrakiSiparisKoduIcinSiparisGuncelle(string siparisKodu, string sonrakiSiparisKodu)
        {

            try
            {
                SqlCommand guncelle = new SqlCommand();
                guncelle.Connection = veritabani.conn;
                veritabani.baglan();
                guncelle.CommandText = "update siparis set sonrakiSiparisKodu=@sonrakiSiparisKodu where siparisKod=@siparisKod";
                guncelle.Parameters.Clear();
                guncelle.Parameters.AddWithValue("@sonrakiSiparisKodu", sonrakiSiparisKodu);
                guncelle.Parameters.AddWithValue("@siparisKod", siparisKodu);

                guncelle.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hata.hataKodu = "radNormalSiparisEkle-fonksiyonSonrakiSiparisKoduIcinSiparisGuncelle";
                hata.hataMesajı = ex.Message;
                hata.hataMesajiKaydet();

            }




        }
        public int uygunHatBul(string urunKod)
        {
            veritabani.baglan();
            try
            {
                int i = 0, var;
                SqlCommand bul = new SqlCommand("select top 1 numara as numara from urunUretimHatlari ur,uretimHatti h where ur.urunKod='" + urunKod + "' and h.aktiflik=0 and h.kullanilabilirmi=1 and ur.HatNo=h.numara order by numara", veritabani.conn);
                SqlDataReader ok = bul.ExecuteReader();
                if (ok.Read())
                    var = Convert.ToInt32(ok["numara"]);
                else
                    var = -1;


                return var;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hata.hataKodu = "radNormalSiparisEkle-uygunHatBul";
                hata.hataMesajı = ex.Message;
                hata.hataMesajiKaydet();
                return -1;
            }

        }
        string sonrakiIcinSiparisKodu;
        public int bitisTarihiEnYakinHatBul(string urunKod)
        {
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hata.hataKodu = "radNormalSiparisEkle-bitisTarihiEnYakinHatBul";
                hata.hataMesajı = ex.Message;
                hata.hataMesajiKaydet();
                return -1;
            }
        }
        public int siparisKodkontrol(string girilenKod)
        {
            try
            {
                int donus;
                veritabani.baglan();
                SqlCommand sor = new SqlCommand("select count(siparisKod) from siparis where siparisKod='" + girilenKod + "'", veritabani.conn);
                donus = Convert.ToInt32(sor.ExecuteScalar());
                return donus;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hata.hataKodu = "radNormalSiparisEkle-siparisKodkontrol";
                hata.hataMesajı = ex.Message;
                hata.hataMesajiKaydet();
                return -1;
            }

        }
        public void fonksiyonSiparisEkle(long adet, DateTime baslangicTarihi, DateTime sonuc, int topSure, int hatNo, int devamDurumu)
        {
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
                siparisEkle.Parameters.AddWithValue("@urunKod", cmbUrunKod.GetPlainText());
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
                SqlCommand varmiFirmaAdi = new SqlCommand("select * from FirmaAdlari where firmaAdi='" + txtFirmaAdi.Text.ToUpper() + "'", veritabani.conn);
                SqlDataReader varmiOku = varmiFirmaAdi.ExecuteReader();
                if (!varmiOku.Read())
                {
                    SqlCommand firmaAdiEkle = new SqlCommand("insert into FirmaAdlari(firmaAdi) values('" + txtFirmaAdi.Text.ToUpper() + "')", veritabani.conn);
                    firmaAdiEkle.ExecuteNonQuery();
                }
                lblHatNo.Text = hatNo.ToString();
                lblKayitTarihi.Text = "" + String.Format("{0:f}", DateTime.Now);
                lblBasTarihi.Text = "" + String.Format("{0:f}", baslangicTarihi);
                lblBitTarihi.Text = "" + String.Format("{0:f}", Hesaplanan);
                lblSiparisKoduPanel.Text = txtSiparisKodu.Text;
                lblUrunKoduPanel.Text = cmbUrunKod.GetPlainText();
                lblTopSure.Text = "" + String.Format("{0:0,0}", Hesaplanan.Subtract(baslangicTarihi).TotalHours) + " SAAT";
                lblBoyPanel.Text = "" + String.Format("{0:0,0}", sp.boy) + " milimetre";
                lblAdetPanel.Text = "" + String.Format("{0:0,0}", adet);


                lblGerekliSure.Text = "" + String.Format("{0:0,0}", topSure) + " SAAT";
                lblHammaddePanel.Text = cmbHammadde.GetPlainText();
                lblRenkPanel.Text = cmbRenk.GetPlainText();
                lblTopMiktar.Text = gerekliUrunMiktari.ToString() + " GRAM" + "  ==" + (gerekliUrunMiktari / 1000) + " KG";

                btnSiparisEkle.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hata.hataKodu = "radNormalSiparisEkle-fonksiyonSiparisEkle";
                hata.hataMesajı = ex.Message;
                hata.hataMesajiKaydet();

            }

        }
        public void fonksiyonHatBitisTarihiGuncelle(DateTime bitisTarih, int hatNo, string siparisKodu)
        {
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hata.hataKodu = "radNormalSiparisEkle-fonksiyonHatBitisTarihiGuncelle";
                hata.hataMesajı = ex.Message;
                hata.hataMesajiKaydet();

            }

            veritabani.baglantiyiKes();
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
             */

        }

        bool sonuc;
        Fonksiyonlar fonksiyon = new Fonksiyonlar(); 
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
                        //MessageBox.Show("one");
                        okunanBaslangicTarihi = Convert.ToDateTime(onemsizOku["baslangicTarihi"]);
                        karsilacatirilacakBitisTarihi = Convert.ToDateTime(bitisTarihiEnYakinOku["bitisTarihi"]);

                        if (okunanBaslangicTarihi < karsilacatirilacakBitisTarihi)
                        {//önemsizin yerine 
                            // MessageBox.Show("1");
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

                                while (baslangictarihiTatileDenkGeliyormu(okunanBaslangicTarihi))
                                {

                                    okunanBaslangicTarihi = okunanBaslangicTarihi.AddDays(1);
                                    yyyy = okunanBaslangicTarihi.Year;
                                    mm = okunanBaslangicTarihi.Month;
                                    dd = okunanBaslangicTarihi.Day;
                                    hour = okunanBaslangicTarihi.Hour;
                                    okunanBaslangicTarihi = new DateTime(yyyy, mm, dd, 08, 00, 00);

                                }
                                okunanBaslangicTarihi = fonksiyonBaslangicPazartesiMi(okunanBaslangicTarihi);
                                Hesaplanan = fonksiyon.fonksiyonSiparisBitisTarihiBul (okunanBaslangicTarihi, yeniToplamSure);
                                fonksiyonSiparisEkle(sp.adet, okunanBaslangicTarihi, Hesaplanan, yeniToplamSure, okunanHatNo, 3);
                                //bu siparişten sonra önemsiz geldiği için önemsizi işaret ediyor
                                fonksiyonSonrakiSiparisKoduIcinSiparisGuncelle(txtSiparisKodu.Text, okunanSiparisKodu);

                                fonksiyon.fonksiyonSonrakiSiparisleriGuncelle(txtSiparisKodu.Text, yeniUrunKod, okunanSiparisKodu, Hesaplanan, okunanHatNo);
                                #endregion
                               
                                // ÖNEMSİZİ GÜNCELLİYOR
                              


                          
                                        /*
                                        SqlCommand gun = new SqlCommand("update siparis set baslangicTarihi=DATEADD(hour," + yeniToplamSure + ",baslangicTarihi),bitisTarihi=DATEADD(hour," + yeniToplamSure + ",bitisTarihi),bitTarih=convert(nvarchar(10),DATEADD(hour," + yeniToplamSure + ",bitisTarihi),104),bitSaat=DATEPART(HOUR, DATEADD(hour," + yeniToplamSure + ",bitisTarihi)) where siparisKod='" + okunanSiparisKodu + "'", veritabani.conn);

                                        gun.ExecuteNonQuery();
                                       */
                                      
                                /*
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        hata.hataKodu = "radNormalSiparisEkle siparisAcilEkle 1.ifin while da önemsizdensonrakiler güncellenirken";
                                        hata.hataMesajı = ex.Message;
                                        hata.hataMesajiKaydet();
                                        return false;
                                    }


                                }
                                 */
                            




                            #endregion
                                // MessageBox.Show("1.kayıt");
                                //başarılı
                                sonuc = true;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                hata.hataMesajı = ex.Message;
                                hata.hataKodu = "radNormalSiparisEkle siparisAcilEkle 1.ifin 1.ifi";
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
                                    while (baslangictarihiTatileDenkGeliyormu(hatBitisTarihi))
                                    {

                                        hatBitisTarihi = hatBitisTarihi.AddDays(1);
                                        yyyy = hatBitisTarihi.Year;
                                        mm = hatBitisTarihi.Month;
                                        dd = hatBitisTarihi.Day;
                                        hour = hatBitisTarihi.Hour;
                                        hatBitisTarihi = new DateTime(yyyy, mm, dd, 08, 00, 00);

                                    }
                                    hatBitisTarihi = fonksiyonBaslangicPazartesiMi(hatBitisTarihi);
                                    Hesaplanan =  fonksiyon.fonksiyonSiparisBitisTarihiBul (hatBitisTarihi, yeniToplamSure);
                                    // sonuc = hatBitisTarihi.AddHours(yeniToplamSure);

                                    fonksiyonSiparisEkle(sp.adet, hatBitisTarihi, Hesaplanan, yeniToplamSure, hatno, 3);
                                    // fonksiyonSonrakiSiparisKoduIcinSiparisGuncelle(sonrakiIcinSiparisKodu);
                                    fonksiyonHatBitisTarihiGuncelle(Hesaplanan, hatno, txtSiparisKodu.Text);

                                    fonksiyonSonrakiSiparisKoduIcinSiparisGuncelle(sonrakiIcinSiparisKodu, txtSiparisKodu.Text);
                                    kayitBasarilimi = true;
                                }

                                sonuc = true;


                                #endregion
                                // MessageBox.Show("2.kayıt");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                hata.hataKodu = "radNormalSiparisEkle siparisAcilEkle sonrasına kayıt kısmı";
                                hata.hataMesajı = ex.Message;
                                hata.hataMesajiKaydet();
                                return false;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        hata.hataKodu = "radNormalSiparisEkle siparisAcilEkle 1.if";
                        hata.hataMesajı = ex.Message;
                        hata.hataMesajiKaydet();
                        return false;
                    }
                }
                else if (bitisTarihiEnYakinOku.Read() && !onemsizOku.Read())
                {
                    try
                    {
                        //  MessageBox.Show("3");
                        //sonrasına kayıt
                        #region
                        okunanBitisTarihi = Convert.ToDateTime(bitisTarihiEnYakinOku["bitisTarihi"]);
                        okunanHatNo = Convert.ToInt32(bitisTarihiEnYakinOku["kullanilacakHat"]);
                        okunanUrunKod = bitisTarihiEnYakinOku["kod"].ToString();
                        okunanSiparisKodu = bitisTarihiEnYakinOku["siparisKod"].ToString();
                        //fonksiyonsiparisEkle sonrasına;

                        if (okunanUrunKod != yeniUrunKod)
                            okunanBitisTarihi = okunanBitisTarihi.AddHours(2);
                        while (baslangictarihiTatileDenkGeliyormu(okunanBitisTarihi))
                        {

                            okunanBitisTarihi = okunanBitisTarihi.AddDays(1);
                            yyyy = okunanBitisTarihi.Year;
                            mm = okunanBitisTarihi.Month;
                            dd = okunanBitisTarihi.Day;
                            hour = okunanBitisTarihi.Hour;
                            okunanBitisTarihi = new DateTime(yyyy, mm, dd, 08, 00, 00);

                        }
                        okunanBitisTarihi = fonksiyonBaslangicPazartesiMi(okunanBitisTarihi);
                        Hesaplanan = fonksiyon.fonksiyonSiparisBitisTarihiBul(okunanBitisTarihi, yeniToplamSure);



                        fonksiyonSiparisEkle(sp.adet, okunanBitisTarihi, Hesaplanan, yeniToplamSure, okunanHatNo, 3);
                        //fonksiyonsiparisEkle sonrasına;

                        fonksiyonHatBitisTarihiGuncelle(Hesaplanan, okunanHatNo, okunanSiparisKodu);
                        //fonksiyonhatBitisTarihGuncelle
                        fonksiyonSonrakiSiparisKoduIcinSiparisGuncelle(okunanSiparisKodu, txtSiparisKodu.Text);
                        #endregion

                        sonuc = true;
                        // MessageBox.Show("3.kayıt");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        hata.hataKodu = "radNormalSiparisEkle siparisAcilEkle 1.elseifi sonrasına kayıt kısmı";
                        hata.hataMesajı = ex.Message;
                        hata.hataMesajiKaydet();
                        return false;
                    }
                }
                else if (onemsizOku.Read() && !bitisTarihiEnYakinOku.Read())
                {//Önemsizin yerine
                    try
                    {
                        //MessageBox.Show("4");
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
                        while (baslangictarihiTatileDenkGeliyormu(okunanBaslangicTarihi))
                        {

                            okunanBaslangicTarihi = okunanBaslangicTarihi.AddDays(1);
                            yyyy = okunanBaslangicTarihi.Year;
                            mm = okunanBaslangicTarihi.Month;
                            dd = okunanBaslangicTarihi.Day;
                            hour = okunanBaslangicTarihi.Hour;
                            okunanBaslangicTarihi = new DateTime(yyyy, mm, dd, 08, 00, 00);

                        }
                        okunanBaslangicTarihi = fonksiyonBaslangicPazartesiMi(okunanBaslangicTarihi);
                        Hesaplanan = fonksiyon.fonksiyonSiparisBitisTarihiBul (okunanBaslangicTarihi, yeniToplamSure);

                        fonksiyonSiparisEkle(sp.adet, okunanBaslangicTarihi, Hesaplanan, yeniToplamSure, okunanHatNo, 3);
                        //bu siparişten sonra önemsiz geldiği için önemsizi işaret ediyor
                        fonksiyonSonrakiSiparisKoduIcinSiparisGuncelle(txtSiparisKodu.Text, okunanSiparisKodu);

                        fonksiyon.fonksiyonSonrakiSiparisleriGuncelle(txtSiparisKodu.Text, yeniUrunKod, okunanSiparisKodu, Hesaplanan, okunanHatNo);



                        
                        #endregion



                        //  MessageBox.Show("4.kayıt");
                        sonuc = true;



                        #endregion

            
                        #region
                        int i = 0;
              
                
              
                        #endregion
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        hata.hataMesajı = ex.Message;
                        hata.hataKodu = "radNormalSiparisEkle siparisAcilEkle 2.else if önemsizin yerine kayıt genel";
                        hata.hataMesajiKaydet();
                        return false;

                    }
                }

                else
                    sonuc = false;


                return sonuc;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hata.hataMesajı = ex.Message;
                hata.hataKodu = "radNormalSiparisEkle siparisAcilEkle EnAltCatch(GENEL TRY-CATCH BLOGU)";
                hata.hataMesajiKaydet();

                return false;
            }
        }


        int tatilGununeDenkGelenSaatSayisi = 0;

        //kullanılmayan bir fonksyion
        private void kacPazarVar(DateTime baslangic, DateTime bitis)
        {
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hata.hataMesajı = ex.Message;
                hata.hataKodu = "radNormalSiparisEkle kacPazarVar Fonksyionu";
                hata.hataMesajiKaydet();
            }
        }

       
        public bool baslangictarihiTatileDenkGeliyormu(DateTime baslangic)
        {
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
                SqlCommand tatilGunlerindenSor = new SqlCommand("select tarih from TatilGunleri where tarih='" + baslangic.ToShortDateString() + "'", veritabani.conn);
                SqlDataReader oku = tatilGunlerindenSor.ExecuteReader();
                if (oku.Read())
                {
                    durum = true;

                }

                return durum;

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hata.hataKodu = "radNormalSiparisEkle baslangictarihiTatileDenkGeliyormu fonksiyonu";
                hata.hataMesajı = ex.Message;
                hata.hataMesajiKaydet();
                return false;
            }

        }

        public DateTime fonksiyonBaslangicPazartesiMi(DateTime baslangic)
        {
            if (baslangic.DayOfWeek == DayOfWeek.Monday && baslangic.Hour < 8)
            {
                baslangic = baslangic.AddHours(8 - baslangic.Hour);
            }

            return baslangic;
        }

        private void btnPnlKapat_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void pnlSiparisTeslimBilgileri_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radMenuButtonItem1_Click(object sender, EventArgs e)
        {
            pnlSiparisTeslimBilgileri.Visible = false;
            btnSiparisEkle.Enabled = false;
            btnYeniEkle.Enabled = true;
        }

        private void txtBoy_KeyPress_1(object sender, KeyPressEventArgs e)
        {

            if ((e.KeyChar >= (char)48) && (e.KeyChar <= (char)59) || (e.KeyChar == (char)8))
                e.Handled = false;
            else
                e.Handled = true;

        }

        private void btnYeniEkle_Click(object sender, EventArgs e)
        {
            if (btnSiparisEkle.Enabled == true)
            {
                s.hata_sesi();
                MessageBox.Show("Yeni Sipariş kaydı zaten açık", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }
            else
            {
                enabled(true);

                txtSiparisKodu.Text = "";
                txtFirmaAdi.Text = "";
                txtBoy.Text = "";
                txtAdet.Text = "";
                btnYeniEkle.Enabled = false;
                btnSiparisEkle.Enabled = true;
            }
        }

        private void radMenuButtonItem2_Click(object sender, EventArgs e)
        {
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += this.Doc_PrintPage;
            PrintDialog dlgSettings = new PrintDialog();
            dlgSettings.Document = doc;
            if (dlgSettings.ShowDialog() == DialogResult.OK)
            {
                doc.Print();
            }
        }
        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            float x = e.MarginBounds.Left;
            float y = e.MarginBounds.Top;
            Bitmap bmp = new Bitmap(this.groupBox2.Width, this.groupBox2.Height);
            this.groupBox2.DrawToBitmap(bmp, new Rectangle(0, 0, this.groupBox2.Width, this.groupBox2.Height));
            e.Graphics.DrawImage((Image)bmp, x, y);
        }
        void enabled(bool deger)
        {
            txtAdet.Enabled = deger;
            txtFirmaAdi.Enabled = deger;
            txtSiparisKodu.Enabled = deger;
            txtBoy.Enabled = deger;
            cmbHammadde.Enabled = deger;
            cmbOncelikSirasi.Enabled = deger;
            cmbRenk.Enabled = deger;
            cmbUrunKod.Enabled = deger;

        }
        


    }
}
