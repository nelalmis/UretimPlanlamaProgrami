using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace uretimPlanlamaProgrami
{
    public partial class frmRAPORLAR : Form
    {
        int gelen;
        public frmRAPORLAR(int indis)
        {
            this.gelen = indis;
            InitializeComponent();
        }
        DateTime bugun = DateTime.Now;
        
        private void frmGunlukRapor_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'genelDataSet.urunler' table. You can move, or remove it, as needed.
            pnlSİparis.Visible = false;
            pnlUrunler.Visible = false;
            pnlUretimHatlari.Visible = false;
            pnlRenkler.Visible = false;
            pnlHammadde.Visible = false;
            if (gelen == 1)
            {
                this.Text = "SİPARİŞ RAPORU";
                pnlSİparis.Visible = true;
                pnlSİparis.Dock = DockStyle.Fill;
                this.siparisTableAdapter.Fill(this.genelDataSet.siparis);
               

            }
            else if(gelen==2){
                this.Text = "ÜRÜNLER RAPORU";
                this.Width = 700;
                pnlUrunler.Visible = true;
                pnlUrunler.Dock = DockStyle.Fill;
                reportViewer2.Dock = DockStyle.Fill;
                this.urunlerTableAdapter.Fill(this.genelDataSet.urunler);

            }
            else if (gelen == 3) {
                this.Text = "ÜRETİM HATLARI RAPORU";
                this.Width = 700;
                pnlUretimHatlari.Visible = true;

                pnlUretimHatlari.Dock = DockStyle.Fill;
                reportViewer3.Dock = DockStyle.Fill;
                this.uretimHattiTableAdapter.Fill(this.genelDataSet.uretimHatti);


            }
            else if (gelen == 4) {
                this.StartPosition = FormStartPosition.CenterScreen;
                this.Text = "RENKLER RAPORU";
                this.Width = 700;
                pnlRenkler.Visible = true;
                pnlRenkler.Dock = DockStyle.Fill;
                this.renklerTableAdapter.Fill(this.genelDataSet.renkler);

            }
            else if (gelen == 5) {
                this.Text = "HAMMADDELER RAPORU";
                this.Width = 700;
                pnlHammadde.Visible = true;
                pnlHammadde.Dock = DockStyle.Fill;
                this.hammaddeTableAdapter.Fill(this.genelDataSet.hammadde);
            
            }






            this.reportViewer1.RefreshReport();
            this.reportViewer2.RefreshReport();
            this.reportViewer3.RefreshReport();
            this.reportViewer4.RefreshReport();
            this.reportViewer5.RefreshReport();
            this.reportViewer5.RefreshReport();
        }

       
     
       
        /*
        private void listBOxDoldur()
        {
            veritabani.baglan();
            SqlCommand al = new SqlCommand("select numara from uretimHatti", veritabani.conn);
            SqlDataReader oku = al.ExecuteReader();
            while (oku.Read())
            {
                listBox1.Items.Add("HAT-" + oku["numara"]);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int yil, ay, gun, sa;

            yil = bugun.Year;
            ay = bugun.Month;
            gun = bugun.Day;

            DateTime bugunBas = new DateTime(yil, ay, gun, 0, 0, 0);


            int hatno = Convert.ToInt32(listBox1.SelectedItem.ToString().Substring(4));
            SqlCommand sor = new SqlCommand("select * from siparis where '"+bugunBas.ToString("yyyy-MM-dd hh:mm:ss")+"'<bitisTarihi and ('"+bugunBas+"' between baslangicTarihi  and bitisTarihi) ",veritabani.conn);
            SqlDataReader oku = sor.ExecuteReader();

            while (oku.Read()) { 
                            
                    
            
            
            }

        */




        
    }
}
