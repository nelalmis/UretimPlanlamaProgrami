using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace uretimPlanlamaProgrami
{
    class anlikBitirmeKontrol 

    {
        

        public static SqlConnection conn = new SqlConnection("Server=VAIO\\SQLEXPRESS;Database=Planlama; Integrated Security=true; MultipleActiveResultSets=true");

       
  
       
         public static void baglan()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }
        public static void baglantiyiKes()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
        public static void anlikKontrol(){
            baglan();
           DateTime simdi = DateTime.Now;

           int yyyy;
           int mon;
           int d;
           int h;
           int min;
           int seco;
           yyyy = simdi.Year;
           mon = simdi.Month;
           d = simdi.Day;
           h = simdi.Hour;
           min = simdi.Minute;
           seco = simdi.Second;

            
           //DateTime simdiFormatli = new DateTime(yyyy, mon, d, h, min, seco);

          // SqlCommand guncelle = new SqlCommand("update siparis set siparisBittimi=1,devamDurumu=2 where bitisTarihi<='"+simdi.ToString("yyyy-MM-dd hh:mm:ss")+"'", conn);
           SqlCommand guncelle = new SqlCommand("update siparis set siparisBittimi=1,devamDurumu=2 where bitisTarihi<GETDATE()",conn);
           guncelle.ExecuteNonQuery();
           SqlCommand hatKontrol = new SqlCommand("update hatBitisTarih  set bitisTarihi=NULL,siparisKodu=NULL, tarih=NULL,saat=NULL where hatNo in(select hatNo from siparis s,hatBitisTarih h where devamDurumu=2 and s.bitisTarihi=h.bitisTarihi and s.kullanilacakHat=h.hatNo)",conn);
           hatKontrol.ExecuteNonQuery();
           SqlCommand hatAktiflikKontrol = new SqlCommand("update uretimHatti set aktiflik=0 where numara in(select hatNo from hatBitisTarih where tarih is null and saat is null and bitisTarihi is null)",conn);
           hatAktiflikKontrol.ExecuteNonQuery();


           SqlCommand guncelle1 = new SqlCommand("update siparis set devamDurumu=1 where GETDATE() between baslangicTarihi and bitisTarihi", conn);
        guncelle1.ExecuteNonQuery();

        //SqlCommand guncelle2 = new SqlCommand("update siparis set devamDurumu=3 where baslangicTarihi>'" + simdi.ToString("yyyy-MM-dd hh:mm:ss") + "'",conn);
        //guncelle2.ExecuteNonQuery();
        ///SqlCommand al = new SqlCommand("select hatNo from hatBitisTarih where bitisTarihi<='" + simdi.ToString("yyyy-MM-dd hh:mm:ss") + "'", conn);
        //SqlDataReader oku = al.ExecuteReader();

        SqlCommand gun = new SqlCommand("update hatBitisTarih set bitisTarihi=NULL where bitisTarihi<=GETDATE()", conn);
        gun.ExecuteNonQuery();

           /* while(oku.Read()){
                SqlCommand gunc = new SqlCommand("update uretimHatti set aktiflik=0 where numara='"+Convert.ToInt32(oku["hatNo"])+"'",conn);
                gunc.ExecuteNonQuery();
            
            }
            */
            baglantiyiKes();

        
        }
        
        

    }
    

    

}
