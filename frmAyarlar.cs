using System;
using System.Collections;
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
    public partial class frmAyarlar : Form
    {
        public frmAyarlar()
        {
            InitializeComponent();
        }
       

        string gun;
        string saat;
        Hashtable kayitliTatiller = new Hashtable();
        Hashtable eklenenTatiller = new Hashtable();
        Hashtable silinenTatiller = new Hashtable();
        private void frmAyarlar_Load(object sender, EventArgs e)
        {
            veritabani.baglan();
            cmbGunler.Items.Add("YOK");
            cmbGunler.Items.Add("PAZARTESİ");
            cmbGunler.Items.Add("SALI");
            cmbGunler.Items.Add("ÇARŞAMBA");
            cmbGunler.Items.Add("PERŞEMBE");
            cmbGunler.Items.Add("CUMA");
            cmbGunler.Items.Add("CUMARTESİ");
            cmbGunler.Items.Add("PAZAR");
            /*
            cmbSaatler.Items.Add("YOK");
            for (int i = 0; i <= 23; i++) {

                cmbSaatler.Items.Add(i.ToString());
            
            }
            */
            SqlCommand sor = new SqlCommand("select * from Ayarlar",veritabani.conn);
            SqlDataReader oku = sor.ExecuteReader();
            if (oku.Read()) {
                cmbGunler.SelectedItem = cmbGunler.GetItemText(oku["tatilGunu"].ToString());
              //  cmbSaatler.SelectedItem = cmbSaatler.GetItemText(oku["mesaiSaati"].ToString());
            
            }

            
            gun = cmbGunler.GetItemText(cmbGunler.SelectedItem);
           // saat =cmbSaatler.GetItemText(cmbSaatler.SelectedItem);



            listTatilGunleriDoldur(true);

            listBoxDoldur(true, 1);
            listBoxDoldur(false, 2);
            
            if (chcHatPasiflestirilsinmi.Checked == false)
            {
                lisKullanilabilirHatlar.Enabled = false;
                listKullanilamayanHatlar.Enabled = false;
                grpKullanilabilen.Enabled = false;
                grpKullanilamayan.Enabled = false;
                

            }
            if (chcDigerTatilGun.Checked == false) {
                grpTatilGunleri.Enabled = false;
                listDigerTatilGunleri.Enabled = false;
                dateTimePicker1.Enabled = false;
            }
           
        }
        private int fonksiyonDiziBoyutlariAl(int deger){

            try
            {
                veritabani.baglan();
                int boyut;
                SqlCommand oku = new SqlCommand("select count(numara) from uretimHatti where kullanilabilirmi=" + deger + "", veritabani.conn);
                boyut = Convert.ToInt32(oku.ExecuteScalar());

                return boyut;
            }catch(Exception){

                return -1;
            }
            
        }
        private void listBoxDoldur(bool deger,int hangiListe)
        {
            int i = 0;
            veritabani.baglan();
            SqlCommand al = new SqlCommand("select numara from uretimHatti where kullanilabilirmi='"+deger+"'", veritabani.conn);
            SqlDataReader oku = al.ExecuteReader();
            while (oku.Read())
            {
                if (hangiListe == 1)
                {
                    lisKullanilabilirHatlar.Items.Add("HAT-" + oku["numara"]);
                   
                }
                else
                {
                    listKullanilamayanHatlar.Items.Add("HAT-" + oku["numara"]);
                  
                }
            }
        }

        private void listTatilGunleriDoldur(bool gorunurluk) {
            veritabani.baglantiyiKes();
            veritabani.baglan();
            listDigerTatilGunleri.Items.Clear();
            SqlCommand al = new SqlCommand("select * from TatilGunleri where gorunurluk='"+gorunurluk+"'", veritabani.conn);
            SqlDataReader oku = al.ExecuteReader();
            while (oku.Read()) {
                kayitliTatiller[oku["tarih"].ToString()] = oku["aciklama"].ToString();
                hashtable[oku["tarih"].ToString()] = oku["aciklama"].ToString();
                listDigerTatilGunleri.Items.Add(String.Format("{0:D}",Convert.ToDateTime( oku["tarih"])));
            }
        
        }


        private void chcHatPasiflestirilsinmi_CheckedChanged(object sender, EventArgs e)
        {
            if (chcHatPasiflestirilsinmi.Checked == false)
            {
                lisKullanilabilirHatlar.Enabled = false;
                listKullanilamayanHatlar.Enabled = false;
                grpKullanilabilen.Enabled = false;
                grpKullanilabilen.Enabled = false;

            }
             else {
                grpKullanilabilen.Enabled = true;
                grpKullanilamayan.Enabled = true;
                lisKullanilabilirHatlar.Enabled = true;
                listKullanilamayanHatlar.Enabled = true;

               
            }

        }
        ses s = new ses();
        private void btnPasiflestir_Click(object sender, EventArgs e)
        {
            try
            {
                int toplamhatSayisi = lisKullanilabilirHatlar.Items.Count;
              
                DialogResult cevap;
                int hatno = Convert.ToInt16(lisKullanilabilirHatlar.SelectedItem.ToString().Substring(4));
                cevap = MessageBox.Show("Seçili Hattı pasifleştirmek istediğinizden emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes)
                {

                    if (toplamhatSayisi > 1)
                    {

                        SqlCommand sor = new SqlCommand("select count(*) from siparis where devamDurumu!=2 and kullanilacakHat='" + hatno + "'", veritabani.conn);
                        int sayi = Convert.ToInt32(sor.ExecuteScalar());
                        if (sayi == 0)
                        {
                          
                            listKullanilamayanHatlar.Items.Add("HAT-" + hatno.ToString());
                            lisKullanilabilirHatlar.Items.Remove("HAT-" + hatno.ToString());
                            s.onay_sesi();
                           // MessageBox.Show("Seçili hat pasifleştirildi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            s.hata_sesi();
                            MessageBox.Show("Bu hat kullanıldığından dolayı pasifleştirilemez.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        s.hata_sesi();
                        MessageBox.Show("Hat pasifleştirme işlemi başarısız.En az bir hat kullanilabilir olmalı!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }


                }
            }
            catch (Exception)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listKullanilamayanHatlar.SelectedItems.Count == 1)
            {
                DialogResult cevap;
                int hatno = Convert.ToInt16(listKullanilamayanHatlar.SelectedItem.ToString().Substring(4));
                cevap = MessageBox.Show("Seçili Hattı aktifleştimek istediğinizden emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes)
                {
                    listKullanilamayanHatlar.Items.Remove("HAT-" + hatno.ToString());
                    lisKullanilabilirHatlar.Items.Add("HAT-" + hatno.ToString());
                    s.onay_sesi();
                   // MessageBox.Show("Seçili hat aktifleştirildi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void btnAyarlariKaydet_Click(object sender, EventArgs e)
        {
            //tatil tarihini değiştirirseniz siparişler bundan etkilenecek;
                veritabani.baglan();
                DialogResult cevap;
                int hatno;
                cevap = MessageBox.Show("Değişiklikleri kaydet?", "Uyarı", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes)
                {
                    
                    for (int l = 0; l < lisKullanilabilirHatlar.Items.Count;l++ )
                    {
                        hatno = Convert.ToInt32(lisKullanilabilirHatlar.Items[l].ToString().Substring(4));
                         SqlCommand updateUrunHat = new SqlCommand("update uretimHatti set kullanilabilirmi=1 where numara='" + hatno + "' ", veritabani.conn);
                         updateUrunHat.ExecuteNonQuery();
                    }
                    for (int l = 0; l< listKullanilamayanHatlar.Items.Count; l++)
                    {
                        hatno = Convert.ToInt32(listKullanilamayanHatlar.Items[l].ToString().Substring(4));
                        SqlCommand updateUrunHat = new SqlCommand("update uretimHatti set kullanilabilirmi=0 where numara='" + hatno + "' ", veritabani.conn);
                       updateUrunHat.ExecuteNonQuery();

                    }
                    gun= cmbGunler.GetItemText(cmbGunler.SelectedItem);
                   // saat = cmbSaatler.GetItemText(cmbSaatler.SelectedItem);
                    SqlCommand ayarlarGuncelle = new SqlCommand("update Ayarlar set tatilGunu='"+gun+"',mesaiSaati='"+saat+"'",veritabani.conn);
                    ayarlarGuncelle.ExecuteNonQuery();

                    SqlCommand tatilGunleriSil = new SqlCommand("delete from TatilGunleri",veritabani.conn);
                    tatilGunleriSil.ExecuteNonQuery();

                    for (int l = 0; l < listDigerTatilGunleri.Items.Count; l++)
                    {
                        DateTime tarih = Convert.ToDateTime(listDigerTatilGunleri.Items[l]);
                        string tarihString = tarih.ToShortDateString();
                        SqlCommand tatilGunleriEkle = new SqlCommand("insert into tatilGunleri(tarih,aciklama) values('"+tarihString+"','"+hashtable[tarihString]+"')",veritabani.conn);
                        tatilGunleriEkle.ExecuteNonQuery();

                    }
                    
                    fonksiyonYeniTatilGunuIcinSiparisGuncelle();
                    fonksiyonSilinenTatilGunuIcinSiparisGuncelle();

                    foreach (string items in pasiflestirilecekler)
                    {
                        SqlCommand pasiflestir = new SqlCommand("update TatilGunleri set gorunurluk=0 where tarih='" + items + "'", veritabani.conn);
                        pasiflestir.ExecuteNonQuery();
                    }
                    MessageBox.Show("Değişiklikler kaydedildi.");
                    


                }
                else if (cevap == DialogResult.No){
                    lisKullanilabilirHatlar.Items.Clear();
                    listKullanilamayanHatlar.Items.Clear();
                    eklenenTatiller.Clear();
                    silinenTatiller.Clear();
                    listBoxDoldur(true, 1);
                    listBoxDoldur(false, 2);
                    frmAyarlar frm = new  frmAyarlar();
                    frm.Close();
                }






        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chcDigerTatilGun_CheckedChanged(object sender, EventArgs e)
        {
            if (chcDigerTatilGun.Checked == true)
            {
                grpTatilGunleri.Enabled = true;
                listDigerTatilGunleri.Enabled = true;
                dateTimePicker1.Enabled = true;
            }
            else {

                grpTatilGunleri.Enabled = false;
                listDigerTatilGunleri.Enabled = false;
                dateTimePicker1.Enabled = false;
            
            }



        }
        Hashtable hashtable = new Hashtable();
        private void btnTatilGunuEkle_Click(object sender, EventArgs e)
        {
            if (txtAciklama.Text == "")
            {
                
                //toolTip1.SetToolTip(txtAciklama, "Açıklama alanı zorunludur");
                toolTip1.Active = true;
                toolTip1.Show("Açıklama alanı zorunludur", txtAciklama);
            }
            else if (dateTimePicker1.Value <= DateTime.Now)
            {
                MessageBox.Show("Geçmiş tarihler tatil günü olarak eklenemez! Lütfen ileriki bir tarihi seçiniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            else
            {
               
                veritabani.baglan();
                SqlCommand sor = new SqlCommand("select * from Ayarlar", veritabani.conn);
                SqlDataReader oku = sor.ExecuteReader();
                if (oku.Read()) {
                    if (oku["TatilGunu"].ToString() == String.Format("{0:dddd}", dateTimePicker1.Value).ToUpper()) {
                        MessageBox.Show("Seçilen gün, tatil günü zaten!","UYARI",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        return;
                    }
                
                }
                if(!kayitliTatiller.ContainsKey(dateTimePicker1.Value.ToShortDateString()))
                    eklenenTatiller[dateTimePicker1.Value.ToShortDateString()]=txtAciklama.Text;

                     // MessageBox.Show( hashtable.ContainsKey(dateTimePicker1.Value.ToShortDateString()).ToString());
                if (!hashtable.ContainsKey(dateTimePicker1.Value.ToShortDateString()))
                    {
                        eklenenTatiller[dateTimePicker1.Value.ToShortDateString()] = txtAciklama.Text;
                        hashtable[dateTimePicker1.Value.ToShortDateString()] = txtAciklama.Text;
                        listDigerTatilGunleri.Items.Add(String.Format("{0:D}", dateTimePicker1.Value));
                        txtAciklama.Text = "";

                    }
                    else
                        MessageBox.Show("Sistemde böyle bir tatil günü mevcut zaten!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listDigerTatilGunleri.SelectedItems.Count == 1)
            {
                string seciliTarih = listDigerTatilGunleri.SelectedItem.ToString();
                listDigerTatilGunleri.Items.Remove(seciliTarih);
            }
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listDigerTatilGunleri_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime tarih = Convert.ToDateTime(listDigerTatilGunleri.SelectedItem);
                string tarihString = tarih.ToShortDateString();
                txtKayitliAciklama.Text = hashtable[tarihString].ToString();
            }
            catch { }
        }

        private void txtAciklama_TextChanged(object sender, EventArgs e)
        {
            if (txtAciklama.Text != "")
                toolTip1.Active = false;
        }

        private void btnAciklamaGuncelle_Click(object sender, EventArgs e)
        {
            DateTime tarih = Convert.ToDateTime(listDigerTatilGunleri.SelectedItem);
            string tarihString = tarih.ToShortDateString();
            hashtable[tarihString] = txtKayitliAciklama.Text;
            MessageBox.Show("Açıklama güncellendi.","BİLGİ",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
        }
        frmSiparisEkle siparisEkleNesne = new frmSiparisEkle();
        public void fonksiyonBugundenSonrakiSiparisleriGuncelle() {
            veritabani.baglan();
            int yyyy, mm, dd, hour;
                //yeni tatil için için guncelle
            foreach (DictionaryEntry entry in eklenenTatiller) {
                DateTime tarih = Convert.ToDateTime( entry.Key);
                SqlCommand bulSayi = new SqlCommand("select * from siparis where @tarih>=baslangicTarihi and @tarih<=bitisTarihi order by kullanilacakHat,bitisTarihi desc ", veritabani.conn);
                bulSayi.Parameters.Clear();
                bulSayi.Parameters.AddWithValue("@tarih", tarih.ToString("yyyy-MM-dd hh:mm:ss"));
                int sayi = Convert.ToInt32(bulSayi.ExecuteScalar());
                SqlCommand bul = new SqlCommand("select * from siparis where @tarih>=baslangicTarihi and @tarih<=bitisTarihi order by kullanilacakHat,bitisTarihi desc ",veritabani.conn);
                bul.Parameters.Clear();
                bul.Parameters.AddWithValue("@tarih",tarih);
                SqlDataReader oku = bul.ExecuteReader();
                string[] siparisKodlari=new string[sayi];
                int i=0;
                while (oku.Read()) {
                    DateTime baslangicTarihi = Convert.ToDateTime( oku["baslangicTarihi"]);
                    DateTime bitisTarihi;
                    string siparisKodu = oku["siparisKod"].ToString();
                    int toplamSure = Convert.ToInt32(oku["toplamSure"]);
                    string urunKod = oku["urunKod"].ToString();
                    siparisKodlari[i++]=oku["siparisKod"].ToString();
                    string sonrakiSiparisKodu=oku["sonrakiSiparisKodu"].ToString();
                     int hatno=Convert.ToInt32( oku["kullanilacakHat"]);
                    if (siparisEkleNesne.baslangictarihiTatileDenkGeliyormu(baslangicTarihi))
                    {

                        baslangicTarihi = baslangicTarihi.AddDays(1);
                        yyyy = baslangicTarihi.Year;
                        mm = baslangicTarihi.Month;
                        dd = baslangicTarihi.Day;
                        hour = baslangicTarihi.Hour;
                        baslangicTarihi = new DateTime(yyyy, mm, dd, 00, 00, 00);

                    }
                    baslangicTarihi = siparisEkleNesne.fonksiyonBaslangicPazartesiMi(baslangicTarihi);
                    bitisTarihi = siparisEkleNesne.fonksiyonTatilGunuVarsaGec(baslangicTarihi, toplamSure);
                    SqlCommand onemsizGuncelle1 = new SqlCommand();
                    onemsizGuncelle1.Connection = veritabani.conn;
                    onemsizGuncelle1.CommandText = "update siparis set baslangicTarihi=@baslangicTarihi,bitisTarihi=@bitisTarihi,bitTarih=@bitTarih,bitSaat=@bitSaat,tatilDahilSure=@tatilDahilSure where siparisKod=@siparisKod";
                    onemsizGuncelle1.Parameters.Clear();
                    onemsizGuncelle1.Parameters.AddWithValue("@baslangicTarihi", baslangicTarihi);
                    onemsizGuncelle1.Parameters.AddWithValue("@bitisTarihi", bitisTarihi);
                    onemsizGuncelle1.Parameters.AddWithValue("@bitTarih", bitisTarihi.ToShortDateString());
                    onemsizGuncelle1.Parameters.AddWithValue("@bitSaat", bitisTarihi.Hour);
                    onemsizGuncelle1.Parameters.AddWithValue("@siparisKod", siparisKodu);
                    onemsizGuncelle1.Parameters.AddWithValue("@tatilDahilSure",Convert.ToInt32( bitisTarihi.Subtract(baslangicTarihi).TotalHours));
                    onemsizGuncelle1.ExecuteNonQuery();
                   
                    while (sonrakiSiparisKodu != "")
                    {
                        baslangicTarihi=bitisTarihi;
                        SqlCommand sonrakileriBul = new SqlCommand("select * from siparis where siparisKod='" + sonrakiSiparisKodu + "'", veritabani.conn);
                        SqlDataReader sonrakileriOku = sonrakileriBul.ExecuteReader();
                        if (sonrakileriOku.Read()) {

                            sonrakiSiparisKodu = sonrakileriOku["sonrakiSiparisKodu"].ToString();
                            siparisKodu=sonrakileriOku["siparisKod"].ToString();
                            if (sonrakileriOku["urunKod"].ToString() != urunKod)
                                baslangicTarihi = baslangicTarihi.AddHours(2);

                            if (siparisEkleNesne.baslangictarihiTatileDenkGeliyormu(baslangicTarihi))
                            {

                                baslangicTarihi = baslangicTarihi.AddDays(1);
                                yyyy = baslangicTarihi.Year;
                                mm = baslangicTarihi.Month;
                                dd = baslangicTarihi.Day;
                                hour = baslangicTarihi.Hour;
                                baslangicTarihi = new DateTime(yyyy, mm, dd, 00, 00, 00);

                            }
                            baslangicTarihi = siparisEkleNesne.fonksiyonBaslangicPazartesiMi(baslangicTarihi);
                            bitisTarihi = siparisEkleNesne.fonksiyonTatilGunuVarsaGec(baslangicTarihi, toplamSure);
                            SqlCommand sonrakileriGuncelle = new SqlCommand();
                            sonrakileriGuncelle.Connection = veritabani.conn;
                            sonrakileriGuncelle.CommandText = "update siparis set baslangicTarihi=@baslangicTarihi,bitisTarihi=@bitisTarihi,bitTarih=@bitTarih,bitSaat=@bitSaat,tatilDahilSure=@tatilDahilSure where siparisKod=@siparisKod";
                            sonrakileriGuncelle.Parameters.Clear();
                            sonrakileriGuncelle.Parameters.AddWithValue("@baslangicTarihi", baslangicTarihi);
                            sonrakileriGuncelle.Parameters.AddWithValue("@bitisTarihi", bitisTarihi);
                            sonrakileriGuncelle.Parameters.AddWithValue("@bitTarih", bitisTarihi.ToShortDateString());
                            sonrakileriGuncelle.Parameters.AddWithValue("@bitSaat", bitisTarihi.Hour);
                            sonrakileriGuncelle.Parameters.AddWithValue("@siparisKod", siparisKodu);
                            sonrakileriGuncelle.Parameters.AddWithValue("@tatilDahilSure", Convert.ToInt32(bitisTarihi.Subtract(baslangicTarihi).TotalHours));
                            sonrakileriGuncelle.ExecuteNonQuery();

                             hatno=Convert.ToInt32( sonrakileriOku["kullanilacakHat"]);
                        
                        }
                        

                    }
                    
                    siparisEkleNesne.fonksiyonHatBitisTarihiGuncelle(bitisTarihi,hatno,siparisKodu );
                
                
                }
                    
            }
            MessageBox.Show("Siparişler başarıyla güncellendi");
        
        }

        private void btnTatilGunuSil_Click(object sender, EventArgs e)
        {
           
            if(listDigerTatilGunleri.SelectedItems.Count>0){
             DateTime tarih = Convert.ToDateTime(listDigerTatilGunleri.SelectedItem);
                string tarihString = tarih.ToShortDateString();
             if (tarih < DateTime.Now)
             {
                 MessageBox.Show("Geçmiş tarihlerdeki tatil gunleri silinemez!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 return;
             }
             else {
                 if (kayitliTatiller.ContainsKey(tarihString))
                     silinenTatiller[tarihString] = hashtable[tarihString].ToString();
                listDigerTatilGunleri.Items.Remove(listDigerTatilGunleri.SelectedItem);
                txtKayitliAciklama.Text = "";
                 hashtable.Remove(tarihString);

             
             }

            }

            
        }
        public void fonksiyonYeniTatilGunuIcinSiparisGuncelle() {
            veritabani.baglantiyiKes();
            try
            {
                foreach (DictionaryEntry entry in eklenenTatiller)
                {

                    veritabani.baglan();
                    DateTime tarih = Convert.ToDateTime(entry.Key);
                    SqlCommand bulSayi = new SqlCommand("select count(*) from siparis where @tarih>=baslangicTarihi and @tarih<=bitisTarihi ", veritabani.conn);
                    bulSayi.Parameters.Clear();
                    bulSayi.Parameters.AddWithValue("@tarih", SqlDbType.DateTime).Value = tarih;
                    int sayi = Convert.ToInt32(bulSayi.ExecuteScalar());
                    SqlCommand bul = new SqlCommand("select * from siparis where @tarih>=baslangicTarihi and @tarih<=bitisTarihi order by kullanilacakHat,bitisTarihi desc ", veritabani.conn);
                    bul.Parameters.Clear();
                    bul.Parameters.AddWithValue("@tarih", SqlDbType.DateTime).Value = tarih;
                    SqlDataReader oku = bul.ExecuteReader();
                    string[] siparisKodlari = new string[sayi];
                    int i = 0;
                    frmSiparisEkle siparisNesne = new frmSiparisEkle();
                    veritabani.baglan();
                    while (oku.Read())
                    {

                        DateTime baslangicTarihi = Convert.ToDateTime(oku["baslangicTarihi"]);
                        DateTime bitisTarihi = Convert.ToDateTime(oku["bitisTarihi"]);
                        string siparisKodu = oku["siparisKod"].ToString();
                        int toplamSure = Convert.ToInt32(oku["toplamSure"]);
                        string urunKod = oku["urunKod"].ToString();
                        siparisKodlari[i++] = oku["siparisKod"].ToString();
                        string sonrakiSiparisKodu = oku["sonrakiSiparisKodu"].ToString();
                        int hatno = Convert.ToInt32(oku["kullanilacakHat"]);
                        if (baslangicTarihi.ToShortDateString() == tarih.ToShortDateString())
                            baslangicTarihi = tarih.AddHours(32);

                        baslangicTarihi = fonksyionBitisTarihiTatilGununeDenkGeliyorMu(baslangicTarihi);
                        bitisTarihi = fonksyionBitisTarihiTatilGununeDenkGeliyorMu(bitisTarihi);


                        fonksiyonVeritabaniSiparisGuncelle(siparisKodu, baslangicTarihi, bitisTarihi);

                        while (sonrakiSiparisKodu != "")
                        {

                            SqlCommand sonrakileriBul = new SqlCommand("select * from siparis where siparisKod='" + sonrakiSiparisKodu + "'", veritabani.conn);
                            SqlDataReader sonrakileriOku = sonrakileriBul.ExecuteReader();
                            if (sonrakileriOku.Read())
                            {
                                DateTime bas = Convert.ToDateTime(sonrakileriOku["baslangicTarihi"]);
                                DateTime bit = Convert.ToDateTime(sonrakileriOku["bitisTarihi"]);
                                sonrakiSiparisKodu = sonrakileriOku["sonrakiSiparisKodu"].ToString();
                                siparisKodu = sonrakileriOku["siparisKod"].ToString();

                                bas = bas.AddHours(eklenenSure);
                                bit = bit.AddHours(eklenenSure);

                                bas = fonksyionBitisTarihiTatilGununeDenkGeliyorMu(bas);

                                bit = fonksyionBitisTarihiTatilGununeDenkGeliyorMu(bit);
                                fonksiyonVeritabaniSiparisGuncelle(siparisKodu, bas, bit);

                                hatno = Convert.ToInt32(sonrakileriOku["kullanilacakHat"]);
                                if (sonrakiSiparisKodu == "")
                                {
                                    siparisEkleNesne.fonksiyonHatBitisTarihiGuncelle(bit, hatno, siparisKodu);
                                }

                            }


                        }
                    }




                }
            }
            catch { }
        }

        private void frmAyarlar_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
        int eklenenSure=0;
        public DateTime fonksyionBitisTarihiTatilGununeDenkGeliyorMu(DateTime tarih) {
             string gun;

             eklenenSure = 0;
                tarih = tarih.AddHours(24);
               SqlCommand ayarlardanSor = new SqlCommand("select * from Ayarlar ", veritabani.conn);
               SqlDataReader ayarlardanOku = ayarlardanSor.ExecuteReader();
                DayOfWeek denkGelenGun = tarih.DayOfWeek ;
                SqlCommand tatilGunleriSor = new SqlCommand("select * from TatilGunleri where tarih='"+tarih.ToShortDateString()+"'",veritabani.conn);
                SqlDataReader tatilGunleriOku = tatilGunleriSor.ExecuteReader();
               // MessageBox.Show(denkGelenGun.ToString());
                if (tatilGunleriOku.Read())
                {
                    tarih = tarih.AddHours(24);
                    eklenenSure += 24;
                }
                if (denkGelenGun == DayOfWeek.Monday)
                {
                    tarih = tarih.AddHours(8);
                    eklenenSure += 8;
                }
               
               if (ayarlardanOku.Read())
               {
                   gun = ayarlardanOku["tatilGunu"].ToString();
                   if (gun.ToUpper() == "YOK")
                   {
                       return tarih;
                       
                      
                   }
                   else
                   {
                       switch (gun)
                       {
                           #region

                           case "PAZARTESİ":
                               if (denkGelenGun == DayOfWeek.Monday)
                               {
                                   tarih = tarih.AddHours(24);
                                   eklenenSure += 24;
                               }
                                break;


                           case "SALI":
                                if (denkGelenGun == DayOfWeek.Tuesday)
                                {
                                    tarih = tarih.AddHours(24);
                                    eklenenSure += 24;
                                }
                               break;

                           case "ÇARŞAMBA":
                               if (denkGelenGun == DayOfWeek.Wednesday)
                               {
                                   tarih = tarih.AddHours(24);
                                   eklenenSure += 24;
                               }
                             break;
                           case "PERŞEMBE":
                             if (denkGelenGun == DayOfWeek.Thursday)
                             {
                                 tarih = tarih.AddHours(24);
                                 eklenenSure += 24;
                             }
                              break;
                           case "CUMA":
                              if (denkGelenGun == DayOfWeek.Friday)
                              {
                                  tarih = tarih.AddHours(24);
                                  eklenenSure += 24;
                              }
                               break;
                           case "CUMARTESİ":
                               if (denkGelenGun == DayOfWeek.Saturday)
                               {
                                   tarih = tarih.AddHours(24);
                                   eklenenSure += 24;
                               }
                              break;
                           case "PAZAR":
                              if (denkGelenGun == DayOfWeek.Sunday)
                              {
                                  tarih = tarih.AddHours(24);
                                  eklenenSure += 24;
                              }
                               break;
                            
                                        
                           
                          
                           #endregion
                       }


                   }


               }


               return tarih;
        
        
        }

        public void fonksiyonVeritabaniSiparisGuncelle(string siparisKodu, DateTime baslangic, DateTime bitis) {

            SqlCommand sonrakileriGuncelle = new SqlCommand();
            sonrakileriGuncelle.Connection = veritabani.conn;
            veritabani.baglan();

            int tatilDahilSure = Convert.ToInt32( bitis.Subtract(baslangic).TotalHours);

            sonrakileriGuncelle.CommandText = "update siparis set baslangicTarihi=@baslangicTarihi,bitisTarihi=@bitisTarihi,bitTarih=@bitTarih,bitSaat=@bitSaat,tatilDahilSure=@tatilDahilSure where siparisKod=@siparisKod";
            sonrakileriGuncelle.Parameters.Clear();
            sonrakileriGuncelle.Parameters.AddWithValue("@baslangicTarihi", SqlDbType.DateTime).Value=baslangic;
            sonrakileriGuncelle.Parameters.AddWithValue("@bitisTarihi", SqlDbType.DateTime).Value = bitis;
            sonrakileriGuncelle.Parameters.AddWithValue("@bitTarih", bitis.ToShortDateString());
            sonrakileriGuncelle.Parameters.AddWithValue("@bitSaat", bitis.Hour);
            sonrakileriGuncelle.Parameters.AddWithValue("@siparisKod", siparisKodu);
            sonrakileriGuncelle.Parameters.AddWithValue("@tatilDahilSure",tatilDahilSure);
            sonrakileriGuncelle.ExecuteNonQuery();
            
        
        }

        public void fonksiyonSilinenTatilGunuIcinSiparisGuncelle() {
            try
            {
                foreach (DictionaryEntry entry in silinenTatiller)
                {
                    veritabani.baglan();
                    DateTime tarih = Convert.ToDateTime(entry.Key);
                    SqlCommand bulSayi = new SqlCommand("select count(*) from siparis where @tarih>=baslangicTarihi and @tarih<=bitisTarihi ", veritabani.conn);
                    bulSayi.Parameters.Clear();
                    bulSayi.Parameters.AddWithValue("@tarih", SqlDbType.DateTime).Value = tarih;
                    int sayi = Convert.ToInt32(bulSayi.ExecuteScalar());
                    SqlCommand bul = new SqlCommand("select * from siparis where @tarih>=baslangicTarihi and @tarih<=bitisTarihi order by kullanilacakHat,bitisTarihi desc ", veritabani.conn);
                    bul.Parameters.Clear();
                    bul.Parameters.AddWithValue("@tarih", SqlDbType.DateTime).Value = tarih;
                    SqlDataReader oku = bul.ExecuteReader();
                    string[] siparisKodlari = new string[sayi];
                    int i = 0;
                    frmSiparisEkle siparisNesne = new frmSiparisEkle();
                    veritabani.baglan();
                    while (oku.Read())
                    {

                        DateTime baslangicTarihi = Convert.ToDateTime(oku["baslangicTarihi"]);
                        DateTime bitisTarihi = Convert.ToDateTime(oku["bitisTarihi"]);
                        string siparisKodu = oku["siparisKod"].ToString();
                        int toplamSure = Convert.ToInt32(oku["toplamSure"]);
                        string urunKod = oku["urunKod"].ToString();
                        siparisKodlari[i++] = oku["siparisKod"].ToString();
                        string sonrakiSiparisKodu = oku["sonrakiSiparisKodu"].ToString();
                        int hatno = Convert.ToInt32(oku["kullanilacakHat"]);
                       
                        bitisTarihi = silinentatilGunuIcinIslemYap(bitisTarihi);


                        fonksiyonVeritabaniSiparisGuncelle(siparisKodu, baslangicTarihi, bitisTarihi);

                        while (sonrakiSiparisKodu != "")
                        {

                            SqlCommand sonrakileriBul = new SqlCommand("select * from siparis where siparisKod='" + sonrakiSiparisKodu + "'", veritabani.conn);
                            SqlDataReader sonrakileriOku = sonrakileriBul.ExecuteReader();
                            if (sonrakileriOku.Read())
                            {
                                DateTime bas = Convert.ToDateTime(sonrakileriOku["baslangicTarihi"]);
                                DateTime bit = Convert.ToDateTime(sonrakileriOku["bitisTarihi"]);
                                sonrakiSiparisKodu = sonrakileriOku["sonrakiSiparisKodu"].ToString();
                                siparisKodu = sonrakileriOku["siparisKod"].ToString();

                                bas = bas.AddHours(eklenenSure);
                                bit = bit.AddHours(eklenenSure);

                                bas = silinentatilGunuIcinIslemYap(bas);

                                bit = silinentatilGunuIcinIslemYap(bit);
                                fonksiyonVeritabaniSiparisGuncelle(siparisKodu, bas, bit);

                                hatno = Convert.ToInt32(sonrakileriOku["kullanilacakHat"]);
                                if (sonrakiSiparisKodu == "")
                                {
                                    siparisEkleNesne.fonksiyonHatBitisTarihiGuncelle(bit, hatno, siparisKodu);
                                }

                            }


                        }
                    }



                }

            }
            catch { }
        
        }

        public DateTime silinentatilGunuIcinIslemYap(DateTime tarih) {
           
            eklenenSure = 0;
            tarih = tarih.AddHours(-24);
            SqlCommand ayarlardanSor = new SqlCommand("select * from Ayarlar ", veritabani.conn);
            SqlDataReader ayarlardanOku = ayarlardanSor.ExecuteReader();
            DayOfWeek denkGelenGun = tarih.DayOfWeek;
            SqlCommand tatilGunleriSor = new SqlCommand("select * from TatilGunleri where tarih='" + tarih.ToShortDateString() + "'", veritabani.conn);
            SqlDataReader tatilGunleriOku = tatilGunleriSor.ExecuteReader();
            // MessageBox.Show(denkGelenGun.ToString());
            if (tatilGunleriOku.Read())
            {
                tarih = tarih.AddHours(24);
                eklenenSure += 24;
            }
            if (denkGelenGun == DayOfWeek.Monday)
            {
                tarih = tarih.AddHours(8);
                eklenenSure += 8;
            }

            if (ayarlardanOku.Read())
            {
                gun = ayarlardanOku["tatilGunu"].ToString();
                if (gun.ToUpper() == "YOK")
                {
                    return tarih;


                }
                else
                {
                    switch (gun)
                    {
                        #region

                        case "PAZARTESİ":
                            if (denkGelenGun == DayOfWeek.Monday)
                            {
                                tarih = tarih.AddHours(24);
                                eklenenSure += 24;
                            }
                            break;


                        case "SALI":
                            if (denkGelenGun == DayOfWeek.Tuesday)
                            {
                                tarih = tarih.AddHours(24);
                                eklenenSure += 24;
                            }
                            break;

                        case "ÇARŞAMBA":
                            if (denkGelenGun == DayOfWeek.Wednesday)
                            {
                                tarih = tarih.AddHours(24);
                                eklenenSure += 24;
                            }
                            break;
                        case "PERŞEMBE":
                            if (denkGelenGun == DayOfWeek.Thursday)
                            {
                                tarih = tarih.AddHours(24);
                                eklenenSure += 24;
                            }
                            break;
                        case "CUMA":
                            if (denkGelenGun == DayOfWeek.Friday)
                            {
                                tarih = tarih.AddHours(24);
                                eklenenSure += 24;
                            }
                            break;
                        case "CUMARTESİ":
                            if (denkGelenGun == DayOfWeek.Saturday)
                            {
                                tarih = tarih.AddHours(24);
                                eklenenSure += 24;
                            }
                            break;
                        case "PAZAR":
                            if (denkGelenGun == DayOfWeek.Sunday)
                            {
                                tarih = tarih.AddHours(24);
                                eklenenSure += 24;
                            }
                            break;




                        #endregion
                    }


                }


            }


            return tarih;



        }
        List<string> pasiflestirilecekler = new List<string>();

        private void btnTatilGUnuPasif_Click(object sender, EventArgs e)
        {
            DateTime tarih = Convert.ToDateTime(listDigerTatilGunleri.SelectedItem);
            string tarihString = tarih.ToShortDateString();
            pasiflestirilecekler.Add(tarihString);
            hashtable[tarihString] = txtKayitliAciklama.Text;
            listDigerTatilGunleri.Items.Remove(listDigerTatilGunleri.SelectedItem);
            txtKayitliAciklama.Text = "";

          

        }

        private void rdGorunurOlanlar_CheckedChanged(object sender, EventArgs e)
        {
            txtKayitliAciklama.Text = "";
            listTatilGunleriDoldur(true);
        }

        private void rdGizli_CheckedChanged(object sender, EventArgs e)
        {
            txtKayitliAciklama.Text = "";
            listTatilGunleriDoldur(false);
        }

        private void rdHerIkisi_CheckedChanged(object sender, EventArgs e)
        {
            txtKayitliAciklama.Text = "";
            listDigerTatilGunleri.Items.Clear();
            SqlCommand al = new SqlCommand("select * from TatilGunleri", veritabani.conn);
            SqlDataReader oku = al.ExecuteReader();
            while (oku.Read())
            {
                kayitliTatiller[oku["tarih"].ToString()] = oku["aciklama"].ToString();
                hashtable[oku["tarih"].ToString()] = oku["aciklama"].ToString();
                listDigerTatilGunleri.Items.Add(String.Format("{0:D}", Convert.ToDateTime(oku["tarih"])));
            }
        }

    }
}
