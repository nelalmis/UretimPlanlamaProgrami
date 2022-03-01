using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uretimPlanlamaProgrami
{
    class silinenFonksiyonlar
    {
        /*
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
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hata.hataKodu = "radNormalSiparisEkle TatilGunuMu";
                hata.hataMesajı = ex.Message;
                hata.hataMesajiKaydet();
                return false;
            }

        }
        
        public DateTime fonksiyonTatilGunuVarsaGec(DateTime baslangic, int totalSure)
        {
            try
            {
                veritabani.baglan();

                string gun;
                int sayi = 1, step = 1, tatilGunuSayisi, bir = 0;
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
                            if (TatilGunuMu(bitis.AddHours(step).ToShortDateString()))
                            {
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
                                        bitis = bitis.AddHours(32);
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
                                        bitis = bitis.AddHours(32);
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

                                    else if (bitis.AddHours(step).DayOfWeek == DayOfWeek.Monday && bitis.Hour < 8)
                                    {
                                        bitis = bitis.AddHours(8 - bitis.Hour);


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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hata.hataKodu = "radNormalSiparisEkle fonksiyonTatilGunuVarsaGec fonksiyonu";
                hata.hataMesajı = ex.Message;
                hata.hataMesajiKaydet();
                return DateTime.Now;

            }
        }
         */

        /*
         *  public void fonksiyonSiparisEkle(long adet, DateTime baslangicTarihi, DateTime sonuc, int topSure, int hatNo, int devamDurumu)
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
               siparisEkle.Parameters.AddWithValue("@urunKod",cmbUrunKod.GetPlainText());
               siparisEkle.Parameters.AddWithValue("@siparisKod", txtSiparisKodu.Text.Trim());
               siparisEkle.Parameters.AddWithValue("@firmaAdi", txtFirmaAdi.Text.Trim());
             //  siparisEkle.Parameters.AddWithValue("@hammadde", ham);
              // siparisEkle.Parameters.AddWithValue("@oncelikSirasi", oncelik);
               siparisEkle.Parameters.AddWithValue("@boy", txtBoy.Text.Trim());
               siparisEkle.Parameters.AddWithValue("@adet", adet);
              // siparisEkle.Parameters.AddWithValue("@renk", renk);
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
               SqlCommand varmiFirmaAdi = new SqlCommand("select * from FirmaAdlari where firmaAdi='"+txtFirmaAdi.Text.ToUpper()+"'",veritabani.conn);
               SqlDataReader varmiOku = varmiFirmaAdi.ExecuteReader();
               if (!varmiOku.Read())
               {
                   SqlCommand firmaAdiEkle = new SqlCommand("insert into FirmaAdlari(firmaAdi) values('" + txtFirmaAdi.Text.ToUpper()+ "')",veritabani.conn);
                   firmaAdiEkle.ExecuteNonQuery();
               }
               

           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               hata.hataKodu = "radNormalSiparisEkle-fonksiyonSiparisEkle";
               hata.hataMesajı = ex.Message;
               hata.hataMesajiKaydet();
                
           }

       }
          */

    }
}
