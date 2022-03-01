using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace uretimPlanlamaProgrami
{
    public partial class Anasayfa : Form
    {
        public Anasayfa()
        {

            InitializeComponent();
            
        }
        frmGunlukPlan dn;
        frmHaftalikPlan hft;
        Thread thread1;
        Thread thread2;
        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            thread1 = new Thread(new ThreadStart(islem));
            if (hft == null || hft.IsDisposed)
            {
                thread1.Start();
                btnPasiflestir();
                hft = new frmHaftalikPlan();
                hft.MdiParent = this;
                hft.Show();
                kapat(thread1);
                btnAktiflestir();

            }
            else
            {
                MessageBox.Show("Form zaten açık durumda!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void islem()
        {
            beklemeFormu bkl = new beklemeFormu();
            bkl.ShowDialog();



        }
        public void kapat(Thread th) {
            th.Abort();
            beklemeFormu bkl = new beklemeFormu();
            bkl.Visible = false;

        
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                thread2 = new Thread(new ThreadStart(islem));

                if (dn == null || dn.IsDisposed)
                {
                    thread2.Start();
                    btnPasiflestir();
                    dn = new frmGunlukPlan();
                    dn.MdiParent = this;
                    dn.Show();
                    kapat(thread2);
                    btnAktiflestir();

                }
                else
                {
                    MessageBox.Show("Form zaten açık durumda!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }catch{
            
            
            }
        }
        private void btnPasiflestir() {
            btnHaftalik.Enabled = false;
            btnAylik.Enabled = false;
            btnAdminPaneli.Enabled = false;
            btnCikis.Enabled = false;
            btnGunluk.Enabled = false;
        
        }
        private void btnAktiflestir() {

            btnHaftalik.Enabled = true;
            btnAylik.Enabled = true;
            btnAdminPaneli.Enabled = true;
            btnCikis.Enabled = true;
            btnGunluk.Enabled = true;
        }
        private void Anasayfa_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'planlamaDataSet7.uretimHatti' table. You can move, or remove it, as needed.
            
            anlikBitirmeKontrol.anlikKontrol();
        }

        private void tbGunluk_Click(object sender, EventArgs e)
        {
            



        }
        Giris gir;
        private void button3_Click_1(object sender, EventArgs e)
        {
            if (gir == null || gir.IsDisposed)
            {

                gir = new Giris();

                gir.Show();
            }
            else
                MessageBox.Show("Form açık durumda!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
           
            gir.Show();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            btnPasiflestir();
            DialogResult cevap=MessageBox.Show("Uygulama kapatılsın mı?","UYARI",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes)
                Application.Exit();
            else
                btnAktiflestir();
        }

        private void btnGunluk_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.LightSkyBlue;
        }

        private void btnGunluk_MouseHover(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.SeaGreen;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.LawnGreen;
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.MediumTurquoise;
        }

        private void btnCikis_MouseHover(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.RoyalBlue;
        }

        private void btnCikis_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.Red;
        }
      
        

    }
}
