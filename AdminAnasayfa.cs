using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace uretimPlanlamaProgrami
{
    public partial class AdminAnasayfa : Form 
    {
        public AdminAnasayfa()
        {
            InitializeComponent();
        }
        bool acikmi;
        frmUrunEkle ekle;
        frmUrunDuzenle frm1;
        
        private void eKLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
               
                acikmi = fonksiyonFormAciklikKontrol(ekle);
                if (!acikmi)
                {
                    ekle = new frmUrunEkle();
                    ekle.MdiParent = this;
                    panel1.Controls.Add(ekle);
                    ekle.Show();
                }
                else {
                    MessageBox.Show("Form Açık durumda");
                }
           
        }
        
        private void dUZENLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            acikmi = fonksiyonFormAciklikKontrol(frm1);
            if (!acikmi)
            {
                frm1 = new frmUrunDuzenle();
                frm1.MdiParent = this;
                panel1.Controls.Add(frm1);
                frm1.Show();
            }
            else {

                MessageBox.Show("Form Açık durumda");
            }
        }

        private void AdminAnasayfa_Load(object sender, EventArgs e)
        {
           
            anlikBitirmeKontrol.anlikKontrol();
           // SetBackGroundColorOfMDIForm();
        }
        private void SetBackGroundColorOfMDIForm()
        {
            foreach (Control ctl in this.Controls)
            {
                if ((ctl) is MdiClient)

                //Burada ana formu yakalayıp arka plan rengini değiştiriyoruz
                {
                    ctl.BackColor = System.Drawing.Color.PaleGreen;
                }
            }
        }
        frmUretimHattiEkle frmHatEkle;
        private void eKLEToolStripMenuItem1_Click(object sender, EventArgs e)
        {


            if (frmHatEkle == null || frmHatEkle.IsDisposed)
            {

                frmHatEkle = new frmUretimHattiEkle();
                frmHatEkle.MdiParent = this;
                panel1.Controls.Add(frmHatEkle);
                frmHatEkle.Show();
            }
            else
                MessageBox.Show("Form açık durumda!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        frmHatDuzenle frmHatDuzenle;
        private void dUZENLEToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmHatDuzenle == null || frmHatDuzenle.IsDisposed)
            {

                frmHatDuzenle = new frmHatDuzenle();
                frmHatDuzenle.MdiParent = this;
                panel1.Controls.Add(frmHatDuzenle);
                frmHatDuzenle.Show();
            }
            else
                MessageBox.Show("Form açık durumda!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);

           
        }

        private void AdminAnasayfa_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();

        }
        
        private void eKLEToolStripMenuItem2_Click(object sender, EventArgs e)
        {
           
        }

        private void hAMMADDEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        frmHammaddeEkle frmHamEkle;
        private void eKLEToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (frmHamEkle == null || frmHamEkle.IsDisposed)
            {

                frmHamEkle = new frmHammaddeEkle();
                frmHamEkle.MdiParent = this;
                panel1.Controls.Add(frmHamEkle);
                frmHamEkle.Show();
            }
            else
                MessageBox.Show("Form açık durumda!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        frmHammaddeDuzenle frmHamDuz;
        private void dUZENLEToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (frmHamDuz == null || frmHamDuz.IsDisposed)
            {

                frmHamDuz = new frmHammaddeDuzenle();
              
                frmHamDuz.MdiParent = this;
                panel1.Controls.Add(frmHamDuz);
                frmHamDuz.Show();
            }
            else
                MessageBox.Show("Form açık durumda!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        frmSiparisDuzenle frmSipDuz;
        DataSet ds;
        private void dUZENLEToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (frmSipDuz == null || frmSipDuz.IsDisposed)
            {
                
                frmSipDuz = new frmSiparisDuzenle();
                frmSipDuz.MdiParent = this;
                panel1.Controls.Add(frmSipDuz);
              
                
                frmSipDuz.Show();
            }
            else
                MessageBox.Show("Form açık durumda!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        frmRenkEkle frmRenkEkle;
        private void eKLEToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (frmRenkEkle == null || frmRenkEkle.IsDisposed)
            {

                frmRenkEkle = new frmRenkEkle();
                frmRenkEkle.MdiParent = this;
                panel1.Controls.Add(frmRenkEkle);
                frmRenkEkle.Show();
            }
            else
                MessageBox.Show("Form açık durumda!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        frmRenkDuzenle frmRenkDuzenle;
        private void dUZENLEToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (frmRenkDuzenle == null || frmRenkDuzenle.IsDisposed)
            {

                frmRenkDuzenle = new frmRenkDuzenle();
                frmRenkDuzenle.MdiParent = this;
                panel1.Controls.Add(frmRenkDuzenle);
                frmRenkDuzenle.Show();
            }
            else
                MessageBox.Show("Form açık durumda!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void eKLEToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            
        }

        private void dUZENLEToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            
        }

        private void menuStrip1_MouseHover(object sender, EventArgs e)
        {
           
        }

        private void gÜVENLİCIKIŞToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult cevap = MessageBox.Show("Uygulama kapatılsın mı?", "UYARI", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes)
                Application.Exit();
            
        }

        private void günlükToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRAPORLAR frm = new frmRAPORLAR(1);
            frm.Show();
        }
        frmKullaniciEkle frmKulEkle;
        private void eKLEToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (frmKulEkle == null || frmKulEkle.IsDisposed)
            {

                frmKulEkle = new frmKullaniciEkle();
                frmKulEkle.MdiParent = this;
                panel1.Controls.Add(frmKulEkle);
                frmKulEkle.Show();
            }
            else
                MessageBox.Show("Form açık durumda!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        frmKullaniciDuzenle frmKulDuz;
        private void dUZENLEToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (frmKulDuz == null || frmKulDuz.IsDisposed)
            {

                frmKulDuz = new frmKullaniciDuzenle();
                frmKulDuz.MdiParent = this;
                panel1.Controls.Add(frmKulDuz);
                frmKulDuz.Show();
            }
            else
                MessageBox.Show("Form açık durumda!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private bool fonksiyonFormAciklikKontrol(Form frm)
        {

            if (frm==null || frm.IsDisposed)
            {
                return false;

            }
            else
            {
                return true;
            }


        }

        private void kULLANICIPANELİToolStripMenuItem_Click(object sender, EventArgs e)
        {
            radPlanFormu radd = new radPlanFormu();
            radd.Show();

        }
        frmAyarlar frmAyarlar;
        private void tATİLGÜNÜNÜDEĞİŞTİRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmAyarlar == null || frmAyarlar.IsDisposed)
            {

                frmAyarlar = new frmAyarlar();
                frmAyarlar.MdiParent = this;
                panel1.Controls.Add(frmAyarlar);
                frmAyarlar.Show();
            }
            else
                MessageBox.Show("Form açık durumda!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);


        }

        private void hAFTALIKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRAPORLAR frm = new frmRAPORLAR(2);

            frm.Show();
        }

        private void aYLIKToolStripMenuItem_Click(object sender, EventArgs e)
        {
              frmRAPORLAR frm = new frmRAPORLAR(3);
              frm.Show();
        }

        private void yILLIKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRAPORLAR frm = new frmRAPORLAR(4);
            frm.Show();
        }

        private void hAMMADDELERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRAPORLAR frm = new frmRAPORLAR(5);
            frm.Show();
        }

        private void yEDEKALMAİŞLEMLERİToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmYedekAl frm = new frmYedekAl();
            frm.Show();
        }
        frmSiparisEkle frmSiparisEkle;
        private void normalSiparişToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSiparisEkle == null || frmSiparisEkle.IsDisposed)
            {

                frmSiparisEkle = new frmSiparisEkle();
                frmSiparisEkle.MdiParent = this;
                panel1.Controls.Add(frmSiparisEkle);
                frmSiparisEkle.Show();
            }
            else
                MessageBox.Show("Form açık durumda!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        frmOzelSiparisekle frmOzelSiparisEkle;
        private void özelSiparişToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmOzelSiparisEkle == null || frmOzelSiparisEkle.IsDisposed)
            {

                frmOzelSiparisEkle = new frmOzelSiparisekle();
                frmOzelSiparisEkle.MdiParent = this;
                panel1.Controls.Add(frmOzelSiparisEkle);
                frmOzelSiparisEkle.Show();
            }
            else
                MessageBox.Show("Form açık durumda!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        
        private void iSTATİSTİKLERToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }
        frmAylikRaporr frmAylikRapor;
        private void aylıkRaporToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmAylikRapor == null || frmAylikRapor.IsDisposed)
            {

                frmAylikRapor = new frmAylikRaporr();
                frmAylikRapor.MdiParent = this;
                panel1.Controls.Add(frmAylikRapor);
                frmAylikRapor.Show();
            }
            else
                MessageBox.Show("Form açık durumda!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        
    }
}
