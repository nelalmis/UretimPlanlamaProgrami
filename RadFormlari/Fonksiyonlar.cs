using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace uretimPlanlamaProgrami.RadFormlari
{
    class Fonksiyonlar
    {
        hatalar hata = new hatalar();
        ClassSiparis CsSip = new ClassSiparis();

        
        public bool fonksiyonSiparisEkle(List<ClassSiparis> liste)
        {

            //try
            //{
                
                liste[0].tatilDahilSure = Convert.ToInt32(liste[0].bitisTarihi.Subtract(liste[0].baslangicTarihi).TotalHours);
                liste[0].bitTarih = liste[0].bitisTarihi.ToShortDateString();
                liste[0].bitSaat = liste[0].bitisTarihi.Hour;
                liste[0].kayitTarihi = DateTime.Now;
                liste[0].sil = false;
                liste[0].siparisBittimi = false;
                liste[0].devamDurumu = 3;
                bool basariliMi = true;
                SqlCommand siparisEkle = new SqlCommand();
                siparisEkle.Connection = veritabani.conn;
                veritabani.baglan();



                siparisEkle.CommandText = "insert into siparis(urunKod,siparisKod,firmaAdi,hammadde,oncelikSirasi,boy,adet,renk,baslangicTarihi,bitisTarihi,toplamSure,gerekenUrunMiktari,siparisBittimi,kullanilacakHat,sil,devamDurumu,bitTarih,bitSaat,kayitTarihi,tatilDahilSure) values(@urunKod,@siparisKod,@firmaAdi,@hammadde,@oncelikSirasi,@boy,@adet,@renk,@baslangicTarihi,@bitisTarihi,@toplamSure,@gerekenUrunMiktari,@siparisBittimi,@kullanilacakHat,@sil,@devamDurumu,@bitTarih,@bitSaat,@kayitTarihi,@tatilDahilSure)";
                siparisEkle.Parameters.Clear();
                siparisEkle.Parameters.AddWithValue("@urunKod", liste[0].urunKod);
                siparisEkle.Parameters.AddWithValue("@siparisKod", liste[0].siparisKod);
                siparisEkle.Parameters.AddWithValue("@firmaAdi", liste[0].firmaAdi);
                siparisEkle.Parameters.AddWithValue("@hammadde", liste[0].hammadde);
                siparisEkle.Parameters.AddWithValue("@oncelikSirasi", liste[0].oncelikSirasi);
                siparisEkle.Parameters.AddWithValue("@boy", liste[0].boy);
                siparisEkle.Parameters.AddWithValue("@adet", liste[0].adet);
                siparisEkle.Parameters.AddWithValue("@renk", liste[0].renk);
                siparisEkle.Parameters.AddWithValue("@baslangicTarihi", liste[0].baslangicTarihi);
                siparisEkle.Parameters.AddWithValue("@bitisTarihi", liste[0].bitisTarihi);
                siparisEkle.Parameters.AddWithValue("@toplamSure", liste[0].toplamSure);
                siparisEkle.Parameters.AddWithValue("@gerekenUrunMiktari", liste[0].gerekenUrunMiktari);
                siparisEkle.Parameters.AddWithValue("@siparisBittimi", liste[0].siparisBittimi);
                siparisEkle.Parameters.AddWithValue("@kullanilacakHat", liste[0].kullanilacakHat);
                siparisEkle.Parameters.AddWithValue("@sil", liste[0].sil);
                siparisEkle.Parameters.AddWithValue("@devamDurumu", liste[0].devamDurumu);
                siparisEkle.Parameters.AddWithValue("@bitTarih", liste[0].bitTarih);
                siparisEkle.Parameters.AddWithValue("@bitSaat", liste[0].bitSaat);
                siparisEkle.Parameters.AddWithValue("@kayitTarihi", liste[0].kayitTarihi);
                siparisEkle.Parameters.AddWithValue("@tatilDahilSure", liste[0].tatilDahilSure);

                siparisEkle.ExecuteNonQuery();
                SqlCommand varmiFirmaAdi = new SqlCommand("select * from FirmaAdlari where firmaAdi='" + liste[0].firmaAdi.ToUpper() + "'", veritabani.conn);
                SqlDataReader varmiOku = varmiFirmaAdi.ExecuteReader();
                if (!varmiOku.Read())
                {
                    SqlCommand firmaAdiEkle = new SqlCommand("insert into FirmaAdlari(firmaAdi) values('" + liste[0].firmaAdi.ToUpper() + "')", veritabani.conn);
                    firmaAdiEkle.ExecuteNonQuery();
                }

                
                return basariliMi;

            //}
            //catch (Exception ex)
            //{
            //    return false;
            //    hata.hataKodu = "fonksiyonSiparisEkle";
            //    hata.hataMesajı = ex.Message;
            //    hata.hataMesajiKaydet();

            //}
            

        }
        public bool fonksiyonSiparisGuncelle(List<ClassSiparis> liste)
        {

            try
            {
                SqlCommand siparisGuncelle;
                siparisGuncelle = new SqlCommand();
                siparisGuncelle.Connection = veritabani.conn;
                veritabani.baglan();
                liste[0].tatilDahilSure = Convert.ToInt32(liste[0].bitisTarihi.Subtract(liste[0].baslangicTarihi).TotalHours);
                liste[0].bitTarih = liste[0].bitisTarihi.ToShortDateString();
                liste[0].bitSaat = liste[0].bitisTarihi.Hour;
                liste[0].kayitTarihi = DateTime.Now;
                liste[0].sil = false;
                liste[0].siparisBittimi = false;
                liste[0].devamDurumu = 3;



                siparisGuncelle.CommandText = "update siparis set siparisKod=@siparisKod,urunKod=@urunKod,firmaAdi=@firmaAdi,hammadde=@hammadde,oncelikSirasi=@oncelikSirasi,boy=@boy,adet=@adet,bitisTarihi=@bitisTarihi,toplamSure=@toplamSure,gerekenUrunMiktari=@gerekenUrunMiktari,kullanilacakHat=@kullanilacakHat,bitTarih=@bitTarih,bitSaat=@bitSaat,tatilDahilSure=@tatilDahilSure where siparisKod='" + liste[0].siparisKod + "'";
                siparisGuncelle.Parameters.Clear();

                siparisGuncelle.Parameters.AddWithValue("@urunKod", liste[0].urunKod);
                siparisGuncelle.Parameters.AddWithValue("@siparisKod", liste[0].siparisKod);
                siparisGuncelle.Parameters.AddWithValue("@firmaAdi", liste[0].firmaAdi);
                siparisGuncelle.Parameters.AddWithValue("@hammadde", liste[0].hammadde);
                siparisGuncelle.Parameters.AddWithValue("@oncelikSirasi", liste[0].oncelikSirasi);
                siparisGuncelle.Parameters.AddWithValue("@boy", liste[0].boy);
                siparisGuncelle.Parameters.AddWithValue("@adet", liste[0].adet);
                siparisGuncelle.Parameters.AddWithValue("@renk", liste[0].renk);
                siparisGuncelle.Parameters.AddWithValue("@baslangicTarihi", liste[0].baslangicTarihi);
                siparisGuncelle.Parameters.AddWithValue("@bitisTarihi", liste[0].bitisTarihi);
                siparisGuncelle.Parameters.AddWithValue("@toplamSure", liste[0].toplamSure);
                siparisGuncelle.Parameters.AddWithValue("@gerekenUrunMiktari", liste[0].gerekenUrunMiktari);
                siparisGuncelle.Parameters.AddWithValue("@siparisBittimi", liste[0].siparisBittimi);
                siparisGuncelle.Parameters.AddWithValue("@kullanilacakHat", liste[0].kullanilacakHat);
                siparisGuncelle.Parameters.AddWithValue("@sil", liste[0].sil);
                siparisGuncelle.Parameters.AddWithValue("@devamDurumu", liste[0].devamDurumu);
                siparisGuncelle.Parameters.AddWithValue("@bitTarih", liste[0].bitTarih);
                siparisGuncelle.Parameters.AddWithValue("@bitSaat", liste[0].bitSaat);
                siparisGuncelle.Parameters.AddWithValue("@kayitTarihi", liste[0].kayitTarihi);
                siparisGuncelle.Parameters.AddWithValue("@tatilDahilSure", liste[0].tatilDahilSure);

                siparisGuncelle.ExecuteNonQuery();

                SqlCommand birOncekiGuncelle = new SqlCommand("update siparis set sonrakiSiparisKodu='" + liste[0].siparisKod + "' where sonrakiSiparisKodu='" + liste[0].siparisKod + "'", veritabani.conn);
                birOncekiGuncelle.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                hata.hataMesajı = ex.Message;
                hata.hataKodu = "fonksiyonSiparisGuncelle";
                hata.hataMesajiKaydet();


            }
            veritabani.baglantiyiKes();
        }
        public bool fonksiyonSiparisSil(string siparisKod)
        {
            try
            {
                veritabani.baglan();
                SqlCommand sil = new SqlCommand("delete from siparis where siparisKod=@siparisKod", veritabani.conn);
                sil.Parameters.AddWithValue("@siparisKod", siparisKod);
                sil.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                hata.hataMesajı = ex.Message;
                hata.hataKodu = "fonksiyonSiparisSil";
                hata.hataMesajiKaydet();


            }
            veritabani.baglantiyiKes();


        }
        public List<ClassSiparis> fonksiyonSiparisSorgu(string command)
        {
            //SqlCommand sorgu = new SqlCommand(command, veritabani.conn);
            SqlDataReader oku = fonksiyonSorgu(command);
            
            List<ClassSiparis> liste = new List<ClassSiparis>();
           
              
            while (oku.Read())
            {
                ClassSiparis CssSip = new ClassSiparis
                {
                    adet = Convert.ToInt64(oku["adet"]),
                    baslangicTarihi = Convert.ToDateTime(oku["baslangicTarihi"]),
                    bitisTarihi = Convert.ToDateTime(oku["bitisTarihi"]),
                    bitSaat = Convert.ToInt32(oku["bitSaat"]),
                    bitTarih = oku["bitTarih"].ToString(),
                    boy = Convert.ToInt64(oku["boy"]),
                    devamDurumu = Convert.ToInt32(oku["devamDurumu"]),
                    firmaAdi = oku["firmaAdi"].ToString(),
                    gerekenUrunMiktari = Convert.ToInt32(oku["gerekenUrunMiktari"]),
                    hammadde = Convert.ToInt32(oku["hammadde"]),
                    kayitTarihi = Convert.ToDateTime(oku["kayitTarihi"]),
                    kullanilacakHat = Convert.ToInt32(oku["kullanilacakHat"]),
                    oncelikSirasi = oku["oncelikSirasi"].ToString(),
                    renk = Convert.ToInt32(oku["renk"]),
                    sil = Convert.ToBoolean(oku["sil"]),
                    siparisBittimi = Convert.ToBoolean(oku["siparisBittimi"]),
                    siparisKod = oku["siparisKod"].ToString(),
                    sonrakiSiparisKodu = oku["sonrakiSiparisKodu"].ToString(),
                    tatilDahilSure = Convert.ToInt32(oku["tatilDahilSure"]),
                    toplamSure = Convert.ToInt32(oku["toplamSure"]),
                    urunKod = oku["urunKod"].ToString()

                };


                /*
                 CsSip.adet = Convert.ToInt64(oku["adet"]);
                CsSip.baslangicTarihi = Convert.ToDateTime(oku["baslangicTarihi"]);
                CsSip.bitisTarihi = Convert.ToDateTime(oku["bitisTarihi"]);
                CsSip.bitSaat = Convert.ToInt32(oku["bitSaat"]);
                CsSip.bitTarih = oku["bitTarih"].ToString();
                CsSip.boy = Convert.ToInt64(oku["boy"]);
                CsSip.devamDurumu = Convert.ToInt32(oku["devamDurumu"]);
                CsSip.firmaAdi = oku["firmaAdi"].ToString();
                CsSip.gerekenUrunMiktari = Convert.ToInt32(oku["gerekenUrunMiktari"]);
                CsSip.hammadde = Convert.ToInt32(oku["hammadde"]);
                CsSip.kayitTarihi = Convert.ToDateTime(oku["kayitTarihi"]);
                CsSip.kullanilacakHat = Convert.ToInt32(oku["kullanilacakHat"]);
                CsSip.oncelikSirasi = oku["oncelikSirasi"].ToString();
                CsSip.renk = Convert.ToInt32(oku["renk"]);
                CsSip.sil = Convert.ToBoolean(oku["sil"]);
                CsSip.siparisBittimi = Convert.ToBoolean(oku["siparisBittimi"]);
                CsSip.siparisKod = oku["siparisKod"].ToString();
                CsSip.sonrakiSiparisKodu = oku["sonrakiSiparisKodu"].ToString();
                CsSip.tatilDahilSure = Convert.ToInt32(oku["tatilDahilSure"]);
                CsSip.toplamSure = Convert.ToInt32(oku["toplamSure"]);
                CsSip.urunKod = oku["urunKod"].ToString();
                 */
                liste.Add(CssSip);
                


            }
           
                
            return liste;


        }
       
        public SqlDataReader fonksiyonSorgu(string command)
        {
            veritabani.baglan();
            SqlCommand sorgu = new SqlCommand(command, veritabani.conn);
            SqlDataReader oku = sorgu.ExecuteReader();
            return oku;

        }
        public int fonksiyonSorguSayi(string command)
        {

            SqlCommand sorgu = new SqlCommand(command, veritabani.conn);
            int sayi = Convert.ToInt32(sorgu.ExecuteScalar());
            return sayi;
        }
      
        public ClassSiparis fonksiyonSiparisSorgu2(string command)
        {
            
            SqlCommand sorgu = new SqlCommand(command, veritabani.conn);
            SqlDataReader oku = sorgu.ExecuteReader();

            List<ClassSiparis> liste = new List<ClassSiparis>();
            while (oku.Read())
            {
                  ClassSiparis CssSip = new ClassSiparis
                {
                    adet = Convert.ToInt64(oku["adet"]),
                    baslangicTarihi = Convert.ToDateTime(oku["baslangicTarihi"]),
                    bitisTarihi = Convert.ToDateTime(oku["bitisTarihi"]),
                    bitSaat = Convert.ToInt32(oku["bitSaat"]),
                    bitTarih = oku["bitTarih"].ToString(),
                    boy = Convert.ToInt64(oku["boy"]),
                    devamDurumu = Convert.ToInt32(oku["devamDurumu"]),
                    firmaAdi = oku["firmaAdi"].ToString(),
                    gerekenUrunMiktari = Convert.ToInt32(oku["gerekenUrunMiktari"]),
                    hammadde = Convert.ToInt32(oku["hammadde"]),
                    kayitTarihi = Convert.ToDateTime(oku["kayitTarihi"]),
                    kullanilacakHat = Convert.ToInt32(oku["kullanilacakHat"]),
                    oncelikSirasi = oku["oncelikSirasi"].ToString(),
                    renk = Convert.ToInt32(oku["renk"]),
                    sil = Convert.ToBoolean(oku["sil"]),
                    siparisBittimi = Convert.ToBoolean(oku["siparisBittimi"]),
                    siparisKod = oku["siparisKod"].ToString(),
                    sonrakiSiparisKodu = oku["sonrakiSiparisKodu"].ToString(),
                    tatilDahilSure = Convert.ToInt32(oku["tatilDahilSure"]),
                    toplamSure = Convert.ToInt32(oku["toplamSure"]),
                    urunKod = oku["urunKod"].ToString()

                };


            }
            return CsSip;
        }

        public void fonksiyonSonrakiSiparisleriGuncelle(string siparisKodu, string urunKodu, string sonrakiSiparisKodu, DateTime bitisTarihi,int hatNo)
        {
            string sonrakiSiparisinUrunKodu;
            
            int toplamSure;
            radNormalSiparisEkle nesne = new radNormalSiparisEkle();
            int yyyy, mm, dd, hour;
            DateTime baslangicTarihi = bitisTarihi;
            while (sonrakiSiparisKodu != "")
            {

                veritabani.baglan();

                SqlCommand sonrakiSiparisBilgileriniOku = new SqlCommand("select * from siparis where siparisKod='" + sonrakiSiparisKodu + "'", veritabani.conn);
                SqlDataReader okuSonrakibilgi = sonrakiSiparisBilgileriniOku.ExecuteReader();

                if (okuSonrakibilgi.Read())
                {
                    sonrakiSiparisinUrunKodu = okuSonrakibilgi["urunKod"].ToString();
                    toplamSure = Convert.ToInt32(okuSonrakibilgi["toplamSure"]);
                    siparisKodu = okuSonrakibilgi["siparisKod"].ToString();
                    sonrakiSiparisKodu = okuSonrakibilgi["sonrakiSiparisKodu"].ToString();

                    baslangicTarihi = bitisTarihi;

                    if (sonrakiSiparisinUrunKodu != urunKodu)
                        baslangicTarihi = bitisTarihi.AddHours(2);

                    
                    while (nesne.baslangictarihiTatileDenkGeliyormu(baslangicTarihi))
                    {

                        baslangicTarihi = baslangicTarihi.AddDays(1);
                        yyyy = baslangicTarihi.Year;
                        mm = baslangicTarihi.Month;
                        dd = baslangicTarihi.Day;
                        hour = baslangicTarihi.Hour;
                        baslangicTarihi = new DateTime(yyyy, mm, dd, 00, 00, 00);

                    }

                    baslangicTarihi = nesne.fonksiyonBaslangicPazartesiMi(baslangicTarihi);
                    bitisTarihi = fonksiyonSiparisBitisTarihiBul(baslangicTarihi, toplamSure);
                    fonksiyonSadeceSiparistekiTarihleriGuncelle(baslangicTarihi, bitisTarihi, siparisKodu);

                    urunKodu = sonrakiSiparisinUrunKodu;

                }



            }
            fonksiyonHatBitisTarihiGuncelle(bitisTarihi, hatNo, siparisKodu);
            

        }

        public void fonksiyonSadeceSiparistekiTarihleriGuncelle(DateTime baslangicTarihi, DateTime bitisTarihi, string siparisKod)
        {

            SqlCommand onemsizGuncelle1 = new SqlCommand();
            onemsizGuncelle1.Connection = veritabani.conn;
            onemsizGuncelle1.CommandText = "update siparis set baslangicTarihi=@baslangicTarihi,bitisTarihi=@bitisTarihi,bitTarih=@bitTarih,bitSaat=@bitSaat,tatilDahilSure=@tatilDahilSure where siparisKod=@siparisKod";
            onemsizGuncelle1.Parameters.Clear();
            onemsizGuncelle1.Parameters.AddWithValue("@baslangicTarihi", baslangicTarihi);
            onemsizGuncelle1.Parameters.AddWithValue("@bitisTarihi", bitisTarihi);
            onemsizGuncelle1.Parameters.AddWithValue("@bitTarih", bitisTarihi.ToShortDateString());
            onemsizGuncelle1.Parameters.AddWithValue("@bitSaat", bitisTarihi.Hour);
            onemsizGuncelle1.Parameters.AddWithValue("@tatilDahilSure", bitisTarihi.Subtract(baslangicTarihi).TotalHours);
            onemsizGuncelle1.Parameters.AddWithValue("@siparisKod", siparisKod);
            onemsizGuncelle1.ExecuteNonQuery();



        }

        public void fonksiyonHatBitisTarihiGuncelle(DateTime bitisTarih, int hatNo, string siparisKodu)
        {
            try
            {
             SqlCommand hatBitisTarihiGuncelle = new SqlCommand();
                hatBitisTarihiGuncelle.Connection = veritabani.conn;
                veritabani.baglan();
                string tarih;
                int saat;
                tarih = bitisTarih.ToShortDateString();
                saat = bitisTarih.Hour;
                hatBitisTarihiGuncelle.CommandText = "update hatBitisTarih set bitisTarihi=@bitisTarihi,tarih=@tarih,saat=@saat,siparisKodu=@siparisKodu where hatNo=@hatNo";
                hatBitisTarihiGuncelle.Parameters.Clear();
                hatBitisTarihiGuncelle.Parameters.AddWithValue("@bitisTarihi", bitisTarih);
                hatBitisTarihiGuncelle.Parameters.AddWithValue("@tarih", tarih);
                hatBitisTarihiGuncelle.Parameters.AddWithValue("@saat", saat);
                hatBitisTarihiGuncelle.Parameters.AddWithValue("@hatNo", hatNo);
                hatBitisTarihiGuncelle.Parameters.AddWithValue("@siparisKodu", siparisKodu);
                hatBitisTarihiGuncelle.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                
                hata.hataKodu = "radNormalSiparisEkle-fonksiyonHatBitisTarihiGuncelle";
                hata.hataMesajı = ex.Message;
                hata.hataMesajiKaydet();

            }

            veritabani.baglantiyiKes();
        }

        radUrunResimFormu radUrunResmiFormu;
        public bool fonksiyonUrunResmiGor(string urunKodu) {
            try
            {
                bool sonuc = false;
                string command;
                Image urunResim = null;
                veritabani.baglan();
                // SqlCommand urunResmi = new SqlCommand("select resim from urunler where kod='" + lblUrunKodu.Text + "'", veritabani.conn);
                command = "select resim from urunler where kod='" + urunKodu + "'";
                SqlDataReader urunResmiOku = fonksiyonSorgu(command);
                if (urunResmiOku.Read())
                {

                    byte[] resim = (byte[])urunResmiOku["resim"];
                    MemoryStream ms = new MemoryStream(resim, 0, resim.Length);
                    ms.Write(resim, 0, resim.Length);
                    urunResim = Image.FromStream(ms, true);

                    if (radUrunResmiFormu == null || radUrunResmiFormu.IsDisposed)
                    {

                        radUrunResmiFormu = new radUrunResimFormu(urunResim);

                        radUrunResmiFormu.Show();
                        sonuc= true;
                    }
                    else
                        sonuc= false;

                  

                }
                return sonuc;
            }
            catch (Exception ex)
            {
               
                //MessageBox.Show(ex.Message);
                hata.hataMesajı = ex.Message;
                hata.hataKodu = "Fonksiyonlar-urunResmiGormeFonksiyonu";
                hata.hataMesajiKaydet();
                return false;
            }
        
        
        }

        public DateTime fonksiyonSiparisBitisTarihiBul(DateTime baslangic,int totalSure){
          DateTime bitisTarihi=DateTime.Now;
            string command = "select * from  Ayarlar";
            SqlDataReader tatilGunuOku = fonksiyonSorgu(command);
            if (tatilGunuOku.Read())
            {
                string tatilGunu = tatilGunuOku["tatilGunu"].ToString();
                if (tatilGunu.ToUpper() == "YOK")
                {
                   bitisTarihi= fonksiyonTatilGununeGoreBitisTarihiHesapla(baslangic, DayOfWeek.Monday, DayOfWeek.Monday, totalSure);
                    
                }
                else
                {
                    switch (tatilGunu)
                    {
                        #region

                        case "PAZARTESİ":
                          bitisTarihi=  fonksiyonTatilGununeGoreBitisTarihiHesapla(baslangic, DayOfWeek.Monday, DayOfWeek.Tuesday, totalSure);
                             break;

                        case "SALI":
                           bitisTarihi=  fonksiyonTatilGununeGoreBitisTarihiHesapla(baslangic, DayOfWeek.Tuesday, DayOfWeek.Wednesday, totalSure);
                            break;

                        case "ÇARŞAMBA":
                           bitisTarihi= fonksiyonTatilGununeGoreBitisTarihiHesapla(baslangic, DayOfWeek.Wednesday, DayOfWeek.Thursday, totalSure);
                             break;
                        case "PERŞEMBE":
                           
                             bitisTarihi=  fonksiyonTatilGununeGoreBitisTarihiHesapla(baslangic, DayOfWeek.Thursday, DayOfWeek.Friday, totalSure);
                            break;
                        case "CUMA":
                           bitisTarihi= fonksiyonTatilGununeGoreBitisTarihiHesapla(baslangic, DayOfWeek.Friday, DayOfWeek.Saturday, totalSure);
                                 break;
                        case "CUMARTESİ":
                             bitisTarihi=    fonksiyonTatilGununeGoreBitisTarihiHesapla(baslangic, DayOfWeek.Saturday, DayOfWeek.Sunday, totalSure);
                             break;
                        case "PAZAR":
                           bitisTarihi=  fonksiyonTatilGununeGoreBitisTarihiHesapla(baslangic, DayOfWeek.Sunday, DayOfWeek.Monday, totalSure);
                            break;




                        #endregion
                    }


                }

            }
            return bitisTarihi;
                
          
        
        }
        private DateTime fonksiyonTatilGununeGoreBitisTarihiHesapla(DateTime baslangic, DayOfWeek dayOfWeek,DayOfWeek dayofWeekSonraki,int totalSure) {
            DateTime bitisTarihi = baslangic;
            int sayi = 1,step=1;
            while (sayi <= totalSure)
            {

                if (TatilGunuMu(bitisTarihi.AddHours(step).ToShortDateString()))
                {
                    bitisTarihi = bitisTarihi.AddHours(32);

                }
                else if (bitisTarihi.AddHours(step).DayOfWeek == dayofWeekSonraki && bitisTarihi.Hour < 8)
                {
                    bitisTarihi = bitisTarihi.AddHours(8 - bitisTarihi.Hour);


                }
                else if (bitisTarihi.AddHours(step).DayOfWeek == dayOfWeek)
                {
                    bitisTarihi = bitisTarihi.AddHours(25);
                    sayi++;

                }
                else
                {
                    bitisTarihi = bitisTarihi.AddHours(1);
                    sayi++;
                }
            }

            return bitisTarihi;
        
        }
        private bool TatilGunuMu(string yeniTarih)
        {
            try
            {
                SqlCommand tatilGunleriOku = new SqlCommand("select count(*) from TatilGunleri where tarih='" + yeniTarih + "' ", veritabani.conn);
                int tatilGunleriSayisi = Convert.ToInt16(tatilGunleriOku.ExecuteScalar());
                if (tatilGunleriSayisi == 1)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                
                hata.hataKodu = "radNormalSiparisEkle TatilGunuMu";
                hata.hataMesajı = ex.Message;
                hata.hataMesajiKaydet();
                return false;
            }

        }

      

    }
}