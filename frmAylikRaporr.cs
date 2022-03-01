using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace uretimPlanlamaProgrami
{
    public partial class frmAylikRaporr : Form
    {
        public frmAylikRaporr()
        {
            InitializeComponent();
        }
        Hashtable hashtableUrunler = new Hashtable();
        Hashtable hashtableHammadde = new Hashtable();
        private void frmAylikRaporr_Load(object sender, EventArgs e)
        {
            veritabani.baglan();
            fonksiyonUrunlerRapor();
            fonksyionHammaddeRapor();
            fonksyionHatRapor();
        }
        Hashtable hashtableBoy = new Hashtable(); 
        private void fonksiyonUrunlerRapor() {

            SqlCommand urunRaporSifirla = new SqlCommand("update urunRapor set miktar=0,boy=0,adet=0",veritabani.conn);
            urunRaporSifirla.ExecuteNonQuery();
           
           //BİRİNCİ Ay içiden olup biten 
            SqlCommand urunlerIcin = new SqlCommand("select urunKod, sum(gerekenUrunMiktari) as Urunmiktar,sum(boy) as toplamBoy,sum(adet) as toplamAdet from siparis where '2015-8-1 00:00:00'<=baslangicTarihi and bitisTarihi<='2015-8-31 00:00:00' group by urunKod ", veritabani.conn);
            SqlDataReader urunlerIcinOku = urunlerIcin.ExecuteReader();
            while (urunlerIcinOku.Read())
            {

                SqlCommand guncelle = new SqlCommand("update urunRapor set miktar=miktar+@miktar,boy=boy+@boy,adet=adet+@adet where urunKod=@urunKod",veritabani.conn);
                guncelle.Parameters.Clear();
                guncelle.Parameters.AddWithValue("@miktar",Convert.ToInt32(urunlerIcinOku["Urunmiktar"]));
                guncelle.Parameters.AddWithValue("@boy", Convert.ToInt32(urunlerIcinOku["toplamBoy"]));
                guncelle.Parameters.AddWithValue("@adet",Convert.ToInt32(urunlerIcinOku["toplamAdet"]));
                guncelle.Parameters.AddWithValue("@urunKod",urunlerIcinOku["urunKod"].ToString());
                guncelle.ExecuteNonQuery();

            }
            //İKİNCİ sorgulanan ay öncesinde başlayıp bu ayda biten;
            /*
            SqlCommand urunlerIcin2 = new SqlCommand("select urunKod,bitisTarihi,sum(adet) as toplamAdet from siparis where '2015-8-1 00:00:00'>baslangicTarihi and bitisTarihi<='2015-8-31 00:00:00' group by urunKod ", veritabani.conn);
            SqlDataReader urunlerIcinOku2 = urunlerIcin2.ExecuteReader();
            while (urunlerIcinOku2.Read()) { 
                    
            
            }
            */


            SqlCommand tablodaGoster = new SqlCommand("select * from urunRapor",veritabani.conn);
            SqlDataAdapter da = new SqlDataAdapter(tablodaGoster);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dtUrunler.DataSource = ds.Tables[0];

            /*
            dtUrunler.DataSource = hashtableUrunler.Cast<DictionaryEntry>()
                              .Select(x => new
                              {
                                  ÜrünKodu = x.Key.ToString(),
                                  KullanılanÜrünMiktarı = x.Value.ToString(),
                                  TOPLAMBOY=x.Value.ToString(),
                                  TOPLAMADET=x.Value.ToString()
                              })
                              .ToList();
            dtUrunler.Columns[0].Width = 150;
            dtUrunler.Columns[1].Width = 150;
            dtUrunler.Columns[2].Width = 150;
            dtUrunler.Columns[3].Width = 150;
        */
        }
        private void fonksyionHammaddeRapor() {
            SqlCommand tumUrunler = new SqlCommand("select adi from hammadde", veritabani.conn);
            SqlDataReader tumUrunlerOku = tumUrunler.ExecuteReader();
            while (tumUrunlerOku.Read())
            {
                hashtableHammadde[tumUrunlerOku["adi"].ToString()] = 0;

            }



            SqlCommand urunlerIcin = new SqlCommand("select h.adi, sum(gerekenUrunMiktari) as miktar from siparis s,hammadde h where s.hammadde=h.id and '2015-8-1 00:00:00'<=baslangicTarihi and baslangicTarihi<'2015-8-31 00:00:00' group by h.adi", veritabani.conn);
            SqlDataReader urunlerIcinOku = urunlerIcin.ExecuteReader();
            while (urunlerIcinOku.Read())
            {
                int deger = Convert.ToInt32(hashtableHammadde[urunlerIcinOku["adi"].ToString()]);
                deger = deger + Convert.ToInt32(urunlerIcinOku["miktar"]);
                hashtableHammadde[urunlerIcinOku["adi"].ToString()] = deger;
            }

            dtHammadde.DataSource = hashtableHammadde.Cast<DictionaryEntry>()
                              .Select(x => new
                              {
                                  Hammadde = x.Key.ToString(),
                                  KullanılanHammaddeMiktarı = x.Value.ToString()
                              })
                              .ToList();
            dtHammadde.Columns[0].Width = 150;
            dtHammadde.Columns[1].Width = 150;

        }
        private void fonksyionHatRapor()
        {
            Hashtable hashtableHatlar = new Hashtable();
            SqlCommand tumUrunler = new SqlCommand("select numara from uretimHatti  order by numara", veritabani.conn);
            SqlDataReader tumUrunlerOku = tumUrunler.ExecuteReader();
            while (tumUrunlerOku.Read())
            {
                hashtableHatlar[tumUrunlerOku["numara"].ToString()] = 0;

            }



            SqlCommand urunlerIcin = new SqlCommand("select kullanilacakHat, sum(toplamSure) as toplamSure from siparis s,hammadde h where s.hammadde=h.id and '2015-8-1 00:00:00'<=baslangicTarihi and baslangicTarihi<'2015-8-31 00:00:00' group by kullanilacakHat", veritabani.conn);
            SqlDataReader urunlerIcinOku = urunlerIcin.ExecuteReader();
            while (urunlerIcinOku.Read())
            {
                int deger = Convert.ToInt32(hashtableHatlar[urunlerIcinOku["kullanilacakHat"].ToString()]);
                deger = deger + Convert.ToInt32(urunlerIcinOku["toplamSure"]);
                hashtableHatlar[urunlerIcinOku["kullanilacakHat"].ToString()] = deger;
            }

            dtHatCalismaRapor.DataSource = hashtableHatlar.Cast<DictionaryEntry>()
                              .Select(x => new
                              {
                                  HATNO = x.Key.ToString(),
                                  ToplamSüre = x.Value.ToString()
                              })
                              .ToList();
            dtHatCalismaRapor.Columns[0].Width = 150;
            dtHatCalismaRapor.Columns[1].Width = 150;





        }

    }
}
