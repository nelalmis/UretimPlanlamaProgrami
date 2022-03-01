using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using uretimPlanlamaProgrami.Rad_Formlari;
using uretimPlanlamaProgrami.RadFormlari;
using Telerik.WinControls.UI;
namespace uretimPlanlamaProgrami
{
    public partial class radAnasayfa : Telerik.WinControls.UI.RadRibbonForm
    {
        int tip;
        
        public radAnasayfa(int tip)
        {
            this.tip = tip;
            InitializeComponent();
        }

        private void radRibbonBarGroup1_Click(object sender, EventArgs e)
        {
            
        }

        private void toolWindow1_Click(object sender, EventArgs e)
        {

        }

        private void radButtonElement2_Click(object sender, EventArgs e)
        {
            radSiparisDuzenle rad = new radSiparisDuzenle();

            rad.MdiParent = this;
            panel1.Controls.Add(rad);
            rad.Show();

        }

        private void ribbonTab10_Click(object sender, EventArgs e)
        {
            
        }
        radNormalSiparisEkle radNormalSiparisEkle;
        private void radButtonElement1_Click(object sender, EventArgs e)
        {

            if (radNormalSiparisEkle == null || radNormalSiparisEkle.IsDisposed)
            {

                radNormalSiparisEkle = new radNormalSiparisEkle();
                radNormalSiparisEkle.MdiParent = this;
                panel1.Controls.Add(radNormalSiparisEkle);
                radNormalSiparisEkle.Show();
            }
            else
                MessageBox.Show("Form açık durumda!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        radUrunDuzenle radUrunDuzenle;
        private void radButtonElement4_Click(object sender, EventArgs e)
        {
            if (radUrunDuzenle == null || radUrunDuzenle.IsDisposed)
            {

                radUrunDuzenle = new radUrunDuzenle();
                radUrunDuzenle.MdiParent = this;
                panel1.Controls.Add(radUrunDuzenle);
                radUrunDuzenle.Show();
            }
            else
                MessageBox.Show("Form açık durumda!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        radUrunEkle radUrunEkle;
        private void radButtonElement3_Click(object sender, EventArgs e)
        {
            if (radUrunEkle == null || radUrunEkle.IsDisposed)
            {

                radUrunEkle = new radUrunEkle();
                radUrunEkle.MdiParent = this;
                panel1.Controls.Add(radUrunEkle);
                radUrunEkle.Show();
            }
            else
                MessageBox.Show("Form açık durumda!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void radRibbonBar1_Click(object sender, EventArgs e)
        {

        }

        private void radAnasayfa_Load(object sender, EventArgs e)
        {
            veritabani.baglan();
            anlikBitirmeKontrol.anlikKontrol();
            if (tip == 2)
            {
                ribbonTab1.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
                ribbonTab2.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
                ribbonTab3.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
                ribbonTab4.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
                ribbonTab5.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
                ribbonTab7.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
                ribbonTab8.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
                ribbonTab9.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;

            }
            else {
                ribbonTab1.Visibility = Telerik.WinControls.ElementVisibility.Visible;
                ribbonTab2.Visibility = Telerik.WinControls.ElementVisibility.Visible;
                ribbonTab3.Visibility = Telerik.WinControls.ElementVisibility.Visible;
                ribbonTab4.Visibility = Telerik.WinControls.ElementVisibility.Visible;
                ribbonTab5.Visibility = Telerik.WinControls.ElementVisibility.Visible;
                ribbonTab8.Visibility = Telerik.WinControls.ElementVisibility.Visible;
                ribbonTab10.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            
            }
            ribbonTab9.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            ribbonTab7.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            radButtonElement28.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
          

        }
        radHatEkle radHatEkle;
        private void radButtonElement5_Click(object sender, EventArgs e)
        {
            if (radHatEkle == null || radHatEkle.IsDisposed)
            {

                radHatEkle = new radHatEkle();
                radHatEkle.MdiParent = this;
                panel1.Controls.Add(radHatEkle);
                radHatEkle.Show();
            }
            else
                MessageBox.Show("Form açık durumda!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        radHatDuzenle radHatDuzenle;
        private void radButtonElement6_Click(object sender, EventArgs e)
        {
            if (radHatDuzenle == null || radHatDuzenle.IsDisposed)
            {

                radHatDuzenle = new radHatDuzenle();
                radHatDuzenle.MdiParent = this;
                panel1.Controls.Add(radHatDuzenle);
                radHatDuzenle.Show();
            }
            else
                MessageBox.Show("Form açık durumda!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        radHammaddeEkle radHammaddeEkle;
        private void radButtonElement7_Click(object sender, EventArgs e)
        {
            if (radHammaddeEkle == null || radHammaddeEkle.IsDisposed)
            {

                radHammaddeEkle = new radHammaddeEkle();
                radHammaddeEkle.MdiParent = this;
                panel1.Controls.Add(radHammaddeEkle);
                radHammaddeEkle.Show();
            }
            else
                MessageBox.Show("Form açık durumda!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        radHammaddeDuzenle radHammaddeDuzenle;
        private void radButtonElement8_Click(object sender, EventArgs e)
        {
            if (radHammaddeDuzenle == null || radHammaddeDuzenle.IsDisposed)
            {

                radHammaddeDuzenle = new radHammaddeDuzenle();
                radHammaddeDuzenle.MdiParent = this;
                panel1.Controls.Add(radHammaddeDuzenle);
                radHammaddeDuzenle.Show();
            }
            else
                MessageBox.Show("Form açık durumda!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        radRenkEkle radRenkEkle;
        private void radButtonElement9_Click(object sender, EventArgs e)
        {
            if (radRenkEkle == null || radRenkEkle.IsDisposed)
            {

                radRenkEkle = new radRenkEkle();
                radRenkEkle.MdiParent = this;
                panel1.Controls.Add(radRenkEkle);
                radRenkEkle.Show();
            }
            else
                MessageBox.Show("Form açık durumda!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        radRenkDuzenle radRenkDuzenle;
        private void radButtonElement10_Click(object sender, EventArgs e)
        {
            if (radRenkDuzenle == null || radRenkDuzenle.IsDisposed)
            {

                radRenkDuzenle = new radRenkDuzenle();
                radRenkDuzenle.MdiParent = this;
                panel1.Controls.Add(radRenkDuzenle);
                radRenkDuzenle.Show();
            }
            else
                MessageBox.Show("Form açık durumda!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        radRaporlar1 radRaporlar1;
        private void radButtonElement12_Click(object sender, EventArgs e)
        {
            if (radRaporlar1 == null || radRaporlar1.IsDisposed)
            {

                radRaporlar1 = new radRaporlar1(1);
                radRaporlar1.MdiParent = this;
                panel1.Controls.Add(radRaporlar1);
                radRaporlar1.Show();
            }
            else
                MessageBox.Show("Form açık durumda!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        
        private void radButtonElement13_Click(object sender, EventArgs e)
        {
            if (radRaporlar1 == null || radRaporlar1.IsDisposed)
            {

                radRaporlar1 = new radRaporlar1(2);
                radRaporlar1.MdiParent = this;
                panel1.Controls.Add(radRaporlar1);
                radRaporlar1.Show();
            }
            else
                MessageBox.Show("Form açık durumda!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void radButtonElement14_Click(object sender, EventArgs e)
        {
            if (radRaporlar1 == null || radRaporlar1.IsDisposed)
            {

                radRaporlar1 = new radRaporlar1(3);
                radRaporlar1.MdiParent = this;
                panel1.Controls.Add(radRaporlar1);
                radRaporlar1.Show();
            }
            else
                MessageBox.Show("Form açık durumda!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void radButtonElement15_Click(object sender, EventArgs e)
        {
            if (radRaporlar1 == null || radRaporlar1.IsDisposed)
            {

                radRaporlar1 = new radRaporlar1(5);
                radRaporlar1.MdiParent = this;
                panel1.Controls.Add(radRaporlar1);
                radRaporlar1.Show();
            }
            else
                MessageBox.Show("Form açık durumda!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void radButtonElement11_Click(object sender, EventArgs e)
        {
            if (radRaporlar1 == null || radRaporlar1.IsDisposed)
            {

                radRaporlar1 = new radRaporlar1(4);
                radRaporlar1.MdiParent = this;
                panel1.Controls.Add(radRaporlar1);
                radRaporlar1.Show();
            }
            else
                MessageBox.Show("Form açık durumda!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void radRibbonBarGroup17_Click(object sender, EventArgs e)
        {

        }
        radKullaniciEkle radKullaniciEkle;
        private void radButtonElement16_Click(object sender, EventArgs e)
        {
            if (radKullaniciEkle == null || radKullaniciEkle.IsDisposed)
            {

                radKullaniciEkle = new radKullaniciEkle();
                radKullaniciEkle.MdiParent = this;
                panel1.Controls.Add(radKullaniciEkle);
                radKullaniciEkle.Show();
            }
            else
                MessageBox.Show("Form açık durumda!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
        radKullaniciDuzenle radKullaniciDuzenle;
        private void radButtonElement18_Click(object sender, EventArgs e)
        {
            if (radKullaniciDuzenle == null || radKullaniciDuzenle.IsDisposed)
            {

                radKullaniciDuzenle = new radKullaniciDuzenle();
                radKullaniciDuzenle.MdiParent = this;
                panel1.Controls.Add(radKullaniciDuzenle);
                radKullaniciDuzenle.Show();
            }
            else
                MessageBox.Show("Form açık durumda!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        radSistemAyarlari radSistemAyarlari;
        private void radButtonElement17_Click(object sender, EventArgs e)
        {
            if (radSistemAyarlari == null || radSistemAyarlari.IsDisposed)
            {

                radSistemAyarlari = new radSistemAyarlari();
                radSistemAyarlari.MdiParent = this;
                panel1.Controls.Add(radSistemAyarlari);
                radSistemAyarlari.Show();
            }
            else
                MessageBox.Show("Form açık durumda!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        radPlanFormu radPlanFormu;
           
        private void radButtonElement19_Click(object sender, EventArgs e)
        {
            if (radPlanFormu == null || radPlanFormu.IsDisposed)
            {

                radPlanFormu = new radPlanFormu();
                radPlanFormu.MdiParent = this;
                panel1.Controls.Add(radPlanFormu);
                radPlanFormu.Show();
            }
            else
                MessageBox.Show("Form açık durumda!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        frmGunlukPlan frmGunlukPlan;
        private void radButtonElement20_Click(object sender, EventArgs e)
        {
           
        }
        frmHaftalikPlanNEw frmHaftalikPlan;
        private void radButtonElement21_Click(object sender, EventArgs e)
        {
            
        }

        private void radRibbonBarGroup3_Click(object sender, EventArgs e)
        {

        }

        private void btnCikisYap_Click(object sender, EventArgs e)
        {
           
           
        }

        private void radButtonElement13_Click_1(object sender, EventArgs e)
        {
            if (frmGunlukPlan == null || frmGunlukPlan.IsDisposed)
            {

                frmGunlukPlan = new frmGunlukPlan();
                frmGunlukPlan.MdiParent = this;
                panel1.Controls.Add(frmGunlukPlan);
                frmGunlukPlan.Show();
            }
            else
                MessageBox.Show("Form açık durumda!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
           
        }

        private void radButtonElement20_Click_1(object sender, EventArgs e)
        {
            if (frmHaftalikPlan == null || frmHaftalikPlan.IsDisposed)
            {

                frmHaftalikPlan = new frmHaftalikPlanNEw();
                frmHaftalikPlan.MdiParent = this;
                panel1.Controls.Add(frmHaftalikPlan);
                frmHaftalikPlan.Show();
            }
            else
                MessageBox.Show("Form açık durumda!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void radButtonElement22_Click(object sender, EventArgs e)
        {
            DialogResult cevap = MessageBox.Show("Program kapatılacak!","UYARI",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes)
            {
                Application.Exit();
                veritabani.baglantiyiKes();
            }
        }
        radYedekAl radYedekAl;
        private void radButtonElement21_Click_1(object sender, EventArgs e)
        {
            if (radYedekAl == null || radYedekAl.IsDisposed)
            {

                radYedekAl = new radYedekAl();
                radYedekAl.MdiParent = this;
                panel1.Controls.Add(radYedekAl);
                radYedekAl.Show();
            }
            else
                MessageBox.Show("Form açık durumda!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        radIHammaddecerikEkle radIHammaddecerikEkle;
        private void radButtonElement23_Click(object sender, EventArgs e)
        {
            if (radIHammaddecerikEkle == null || radIHammaddecerikEkle.IsDisposed)
            {

                radIHammaddecerikEkle = new radIHammaddecerikEkle();
                radIHammaddecerikEkle.MdiParent = this;
                panel1.Controls.Add(radIHammaddecerikEkle);
                radIHammaddecerikEkle.Show();
            }
            else
                MessageBox.Show("Form açık durumda!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        radOzelSiparisEkle radOzelSiparisEkle;
        private void radButtonElement25_Click(object sender, EventArgs e)
        {
            if (radOzelSiparisEkle == null || radOzelSiparisEkle.IsDisposed)
            {

                radOzelSiparisEkle = new radOzelSiparisEkle();
                radOzelSiparisEkle.MdiParent = this;
                panel1.Controls.Add(radOzelSiparisEkle);
                radOzelSiparisEkle.Show();
            }
            else
                MessageBox.Show("Form açık durumda!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
        radHammaddeIcerikDuzenle radHammaddeIcerikDuzenle;
        private void radButtonElement24_Click(object sender, EventArgs e)
        {
            if (radHammaddeIcerikDuzenle == null || radHammaddeIcerikDuzenle.IsDisposed)
            {

                radHammaddeIcerikDuzenle = new radHammaddeIcerikDuzenle();
                radHammaddeIcerikDuzenle.MdiParent = this;
                panel1.Controls.Add(radHammaddeIcerikDuzenle);
                radHammaddeIcerikDuzenle.Show();
            }
            else
                MessageBox.Show("Form açık durumda!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void radButtonElement26_Click(object sender, EventArgs e)
        {
            if (radRaporlar1 == null || radRaporlar1.IsDisposed)
            {

                radRaporlar1 = new radRaporlar1(2);
                radRaporlar1.MdiParent = this;
                panel1.Controls.Add(radRaporlar1);
                radRaporlar1.Show();
            }
            else
                MessageBox.Show("Form açık durumda!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void radButtonElement27_Click(object sender, EventArgs e)
        {
           
        }
        frmHatPasiflestir frmHatPasiflestir;
        private void radButtonElement27_Click_1(object sender, EventArgs e)
        {
            if (frmHatPasiflestir == null || frmHatPasiflestir.IsDisposed)
            {

                frmHatPasiflestir = new frmHatPasiflestir();
                frmHatPasiflestir.MdiParent = this;
                panel1.Controls.Add(frmHatPasiflestir);
                frmHatPasiflestir.Show();
            }
            else
                MessageBox.Show("Form açık durumda!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
        radFrmTemaAyarlari radFrmTemaAyarlari;
        private void radButtonElement28_Click(object sender, EventArgs e)
        {
            if (radFrmTemaAyarlari == null || radFrmTemaAyarlari.IsDisposed)
            {

                radFrmTemaAyarlari = new radFrmTemaAyarlari();
                radFrmTemaAyarlari.MdiParent = this;
                panel1.Controls.Add(radFrmTemaAyarlari);
                radFrmTemaAyarlari.Show();
            }
            else
                MessageBox.Show("Form açık durumda!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void radAnasayfa_FormClosed(object sender, FormClosedEventArgs e)
        {
            veritabani.baglantiyiKes();
        }
    }
}
