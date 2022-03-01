using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Data.SqlClient;
using System.Drawing.Printing;
namespace uretimPlanlamaProgrami.RadFormlari
{
    public partial class radSiparisOzeti : Telerik.WinControls.UI.RadForm
    {
        string urunKodu, siparisKodu, firmaAdi;
        int saatTotal, hammadde, renk,hatNo;
        long adet, boy;
        float gerekliUrunMiktari;
        DateTime bas, bit, kayitTarihi;

        public radSiparisOzeti(DateTime bas, DateTime bit, DateTime kayitTarihi, string siparisKodu, string urunKodu, int saatTotal, long adet, long boy, string firmaAdi, int hammadde, int renk,int hatNo, float gerekliUrunMiktari)
        {
            this.urunKodu = urunKodu;
            this.saatTotal = saatTotal;
            this.adet = adet;
            this.boy = boy;
            this.siparisKodu = siparisKodu;
            this.firmaAdi = firmaAdi;
            this.hammadde = hammadde;
            this.renk = renk;
            this.hatNo = hatNo;
            this.gerekliUrunMiktari = gerekliUrunMiktari;
            this.bas = bas;
            this.bit = bit;
            this.kayitTarihi = kayitTarihi;
            InitializeComponent();
        }

        private void radSiparisOzeti_Load(object sender, EventArgs e)
        {
            veritabani.baglan();
            string hammaddeAdi="",renkAdi="";
            veritabani.baglan();
            SqlCommand hammaddeAl = new SqlCommand("select adi from hammadde where id='"+hammadde+"' ",veritabani.conn);
            SqlDataReader hammaddeOku = hammaddeAl.ExecuteReader();
            if (hammaddeOku.Read()) { 
                hammaddeAdi=hammaddeOku["adi"].ToString();
            }
            SqlCommand renkAl = new SqlCommand("select renkAdi from renkler where id='" + renk + "' ", veritabani.conn);
            SqlDataReader renkOku = renkAl.ExecuteReader();
            if (renkOku.Read())
            {
                renkAdi = renkOku["renkAdi"].ToString();
            }
           

            lblSiparisKodu.Text = siparisKodu;
            lblUrunKodu.Text = urunKodu;

            lblHatNo.Text = hatNo.ToString();
            lblKayitTarihi.Text = "" + String.Format("{0:f}", DateTime.Now);
            lblBaslangicTarihi.Text = "" + String.Format("{0:f}", bas);
            lblBitisTarihi.Text = "" + String.Format("{0:f}", bit);

            lblToplamSure.Text = "" + String.Format("{0:0,0}", bit.Subtract(bas).TotalHours) + " SAAT";
            lblBoy.Text = "" + String.Format("{0:0,0}", boy) + " milimetre";
            lblAdet.Text = "" + String.Format("{0:0,0}", adet);


            lblGerekliSure.Text = "" + String.Format("{0:0,0}", saatTotal) + " SAAT";
            lblHammadde.Text = hammaddeAdi;
            lblRenk.Text = renkAdi;
            lblUrunMiktari.Text = gerekliUrunMiktari.ToString() + " GRAM" + "  ==" + (gerekliUrunMiktari / 1000) + " KG";
        }

        private void radMenuButtonItem2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radMenuButtonItem1_Click(object sender, EventArgs e)
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
        
    }
}
