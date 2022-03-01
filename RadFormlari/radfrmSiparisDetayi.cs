using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace uretimPlanlamaProgrami.RadFormlari
{
    public partial class radfrmSiparisDetayi : Form
    {

        string siparisKodu;
        public radfrmSiparisDetayi(string siparisKodu)
        {
            this.siparisKodu = siparisKodu;
            InitializeComponent();
        }


        private void radMenuButtonItem1_Click(object sender, EventArgs e)
        {

        }

        private void radMenuButtonItem2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
       
        Fonksiyonlar fonksiyon = new Fonksiyonlar();
        private void radfrmSiparisDetayi_Load(object sender, EventArgs e)
        {
           
            string command = "select * from siparis s,hammadde h,renkler r where s.hammadde=h.id and s.renk=r.id and siparisKod='" + siparisKodu + "'";
            List<ClassSiparis> liste = fonksiyon.fonksiyonSiparisSorgu(command);

            veritabani.baglan();
            string hammaddeAdi="", renkAdi="";
            SqlCommand hammaddeAl = new SqlCommand("select adi from hammadde where id='" + liste[0].hammadde + "' ", veritabani.conn);
            SqlDataReader hammaddeOku = hammaddeAl.ExecuteReader();
            if (hammaddeOku.Read())
            {
                hammaddeAdi = hammaddeOku["adi"].ToString();
            }
            SqlCommand renkAl = new SqlCommand("select renkAdi from renkler where id='" + liste[0].renk + "' ", veritabani.conn);
            SqlDataReader renkOku = renkAl.ExecuteReader();
            if (renkOku.Read())
            {
                renkAdi = renkOku["renkAdi"].ToString();
            }
           
            lblSiparisKodu.Text = liste[0].firmaAdi;
            lblUrunKodu.Text = liste[0].urunKod;
            lblHatNo.Text = liste[0].kullanilacakHat.ToString();
            lblKayitTarihi.Text = "" + String.Format("{0:f}", liste[0].kayitTarihi);
            lblBaslangicTarihi.Text = "" + String.Format("{0:f}", liste[0].baslangicTarihi);
            lblBitisTarihi.Text = "" + String.Format("{0:f}", liste[0].bitisTarihi);
            lblToplamSure.Text = "" + String.Format("{0:0,0}", liste[0].bitisTarihi.Subtract(liste[0].baslangicTarihi).TotalHours) + " SAAT";
            lblBoy.Text = "" + String.Format("{0:0,0}", liste[0].boy) + " milimetre";
            lblAdet.Text = "" + String.Format("{0:0,0}", liste[0].adet);
            lblGerekliSure.Text = "" + String.Format("{0:0,0}", liste[0].toplamSure) + " SAAT";
            lblHammadde.Text = hammaddeAdi;
            lblRenk.Text = renkAdi;
            lblUrunMiktari.Text = liste[0].gerekenUrunMiktari.ToString() + " GRAM" + "  ==" + (liste[0].gerekenUrunMiktari / 1000) + " KG";

            int toplamSure=liste[0].toplamSure;
            int devamDurumu=liste[0].devamDurumu;

            DateTime simdi = DateTime.Now;
                int yyyy;
                int mon;
                int d;
                int h;
                int min;
               
                yyyy = simdi.Year;
                mon = simdi.Month;
                d = simdi.Day;
                h = simdi.Hour;
                min = simdi.Minute;
               
                DateTime simdiFormatli = new DateTime(yyyy, mon, d, h, min, 00);


            if (devamDurumu == 2)
            {
                lblKalan.Text = "% 0";
                lblIslenen.Text = "% 100";
                progIslenenn.Value = 0;
                progIslenenn.Minimum = 0;
                progIslenenn.Maximum = toplamSure * 60;
                progIslenenn.Step = 1;
                while (progIslenenn.Value != toplamSure * 60)
                {
                    progIslenenn.Value = progIslenenn.Value += 1;

                }

            }

            else if (devamDurumu == 1)
            {
                int kalanDakka = Convert.ToInt32(liste[0].bitisTarihi.Subtract(simdiFormatli).TotalMinutes);
                int kalan = (100 * kalanDakka) / (toplamSure * 60);
                int Islenen = (100 - (((100 * kalanDakka) / (toplamSure * 60))));
                lblKalan.Text = "% " + ((100 * kalanDakka) / (toplamSure * 60)).ToString();
                lblIslenen.Text = "% " + (100 - (((100 * kalanDakka) / (toplamSure * 60)))).ToString();
                progIslenenn.Minimum = 0;
                progIslenenn.Value = kalan;
                progIslenenn.Maximum = 100;
                progIslenenn.Step = 1;
                if (progIslenenn.Value != 100)
                {
                    progIslenenn.Value = Islenen;

                }

            }
            else
            {

                lblIslenen.Text = "% 0";
                lblKalan.Text = "% 100";
                progIslenenn.Value = 0;

            }

             }
        
    }
}
