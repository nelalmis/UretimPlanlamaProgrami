using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace uretimPlanlamaProgrami.RadFormlari
{
    public partial class radRaporlar1 : Telerik.WinControls.UI.RadForm
    {
        int gelen;
        public radRaporlar1(int indis)
        {
            this.gelen = indis;
            InitializeComponent();
        }

        private void radRaporlar1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'genelDataSet.hammadde' table. You can move, or remove it, as needed.
            this.hammaddeTableAdapter.Fill(this.genelDataSet.hammadde);
            // TODO: This line of code loads data into the 'genelDataSet.renkler' table. You can move, or remove it, as needed.
            this.renklerTableAdapter.Fill(this.genelDataSet.renkler);
            // TODO: This line of code loads data into the 'genelDataSet.uretimHatti' table. You can move, or remove it, as needed.
            this.uretimHattiTableAdapter.Fill(this.genelDataSet.uretimHatti);
            // TODO: This line of code loads data into the 'genelDataSet.urunler' table. You can move, or remove it, as needed.
            this.urunlerTableAdapter.Fill(this.genelDataSet.urunler);
            // TODO: This line of code loads data into the 'genelDataSet.siparis' table. You can move, or remove it, as needed.
            pnlSiparis.Visible = false;
            pnlUrunler.Visible = false;
            pnlUretimHatlari.Visible = false;
            pnlRenkler.Visible = false;
            pnlHammadde.Visible = false;
            if (gelen == 1)
            {
                this.Text = "SİPARİŞ RAPORU";
                pnlSiparis.Visible = true;
                pnlSiparis.Dock = DockStyle.Fill;
                siparisBindingSource.Filter = "FirmaAdı<>'TATİL'";
                this.siparisTableAdapter.Fill(this.genelDataSet.siparis);


            }
            else if (gelen == 2)
            {
                this.Text = "ÜRÜNLER RAPORU";
                this.Width = 700;
                pnlUrunler.Visible = true;
                pnlUrunler.Dock = DockStyle.Fill;
                reportViewer2.Dock = DockStyle.Fill;
                this.urunlerTableAdapter.Fill(this.genelDataSet.urunler);

            }
            else if (gelen == 3)
            {
                this.Text = "ÜRETİM HATLARI RAPORU";
                this.Width = 700;
                pnlUretimHatlari.Visible = true;

                pnlUretimHatlari.Dock = DockStyle.Fill;
                reportViewer3.Dock = DockStyle.Fill;
                this.uretimHattiTableAdapter.Fill(this.genelDataSet.uretimHatti);


            }
            else if (gelen == 4)
            {
                this.StartPosition = FormStartPosition.CenterScreen;
                this.Text = "RENKLER RAPORU";
                this.Width = 700;
                pnlRenkler.Visible = true;
                pnlRenkler.Dock = DockStyle.Fill;
                this.renklerTableAdapter.Fill(this.genelDataSet.renkler);

            }
            else if (gelen == 5)
            {
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
    }
}
