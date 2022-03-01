using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace uretimPlanlamaProgrami
{
    public partial class frmGelismisArama : Form
    {
        public frmGelismisArama()
        {
            InitializeComponent();
        }
        frmSiparisEkle s = new frmSiparisEkle();
        int radio;
        private void btnGelismisArama_Click(object sender, EventArgs e)
        {
            string urunKod = txtUrunKodd.Text;
            string siparisKod = txtSiparisKodd.Text;
            #region
            /*
            if (rdTumSiparis.Checked)
            {
                radio = 1;

            }
            if (rdDevamEdenSipariseler.Checked)
            {
                radio = 2;

            }
            if (tdBeklemedeOlan.Checked)
            {
                radio = 3;

            }
            if (rdBitensiparis.Checked)
            {
                radio = 4;

            }

            if (dtSonTarih.Value < dtIlkTarih.Value)
            {
                MessageBox.Show("Son Tarih ilk tarihden küçük olamaz", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (urunKod != null && siparisKod != null && radio == 1)
            {

                SqlCommand sor = new SqlCommand("select * from siparis where urunKod='" + urunKod + "' and siparisKod='" + siparisKod + "' and ('" + dtIlkTarih.Value.ToString("yyyy-MM-dd hh:mm:ss") + "' between baslangicTarihi and bitisTarihi) and ('" + dtSonTarih.Value.ToString("yyyy-MM-dd hh:mm:ss") + "' between baslangicTarihi and bitisTarihi)", veritabani.conn);

                SqlDataAdapter da = new SqlDataAdapter(sor);
                DataTable dt = new DataTable();
                da.Fill(dt);
               // dataGridView1.DataSource = dt;
                

            }
            else if (urunKod != null)
            {

                SqlCommand sor = new SqlCommand("select * from siparis where urunKod='" + urunKod + "' and ('" + dtIlkTarih.Value.ToString("yyyy-MM-dd hh:mm:ss") + "' between baslangicTarihi and bitisTarihi) and ('" + dtSonTarih.Value.ToString("yyyy-MM-dd hh:mm:ss") + "' between baslangicTarihi and bitisTarihi)", veritabani.conn);

                SqlDataAdapter da = new SqlDataAdapter(sor);
                DataTable dt = new DataTable();
                da.Fill(dt);
               // dataGridView1.DataSource = dt;

            }
            else
            {

                SqlCommand sor = new SqlCommand("select * from siparis where  baslangicTarihi between ('" + dtIlkTarih.Value.ToString("yyyy-MM-dd hh:mm:ss") + "' and '" + dtSonTarih.Value.ToString("yyyy-MM-dd hh:mm:ss") + "') or  bitisTarihi between ('" + dtIlkTarih.Value.ToString("yyyy-MM-dd hh:mm:ss") + "' and '" + dtSonTarih.Value.ToString("yyyy-MM-dd hh:mm:ss") + "')", veritabani.conn);

                SqlDataAdapter da = new SqlDataAdapter(sor);
                DataTable dt = new DataTable();
                da.Fill(dt);
                //dataGridView1.DataSource = dt;


            }

            */
            #endregion
            
           
        }

        private void chcUrunKod_CheckedChanged(object sender, EventArgs e)
        {
            if (chcUrunKod.Checked)
                txtUrunKodd.Enabled = true;
            else
                txtUrunKodd.Enabled = false;
        }

        private void chcSiparisKodu_CheckedChanged(object sender, EventArgs e)
        {
            if (chcSiparisKodu.Checked)
                txtSiparisKodd.Enabled = true;
            else
                txtSiparisKodd.Enabled = false;
        }

        private void chcFirmaAdi_CheckedChanged(object sender, EventArgs e)
        {
            if (chcFirmaAdi.Checked)
                txtFirmaAdi.Enabled = true;
            else
                txtFirmaAdi.Enabled = false;
        }

        private void chcHammadde_CheckedChanged(object sender, EventArgs e)
        {
            if (chcHammadde.Checked)
                cmbHammdde.Enabled = true;
            else
                cmbHammdde.Enabled = false;
        }

        private void chcRenk_CheckedChanged(object sender, EventArgs e)
        {
            if (chcRenk.Checked)
                cmbRebk.Enabled = true;
            else
                cmbRebk.Enabled = false;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void chcAdet_CheckedChanged(object sender, EventArgs e)
        {
            if (chcAdet.Checked)
                txtAdet.Enabled = true;
            else
                txtAdet.Enabled = false;

        }

        private void chcBoy_CheckedChanged(object sender, EventArgs e)
        {
            if (chcBoy.Checked)
                txtBoy.Enabled = true;
            else
                txtBoy.Enabled = false;
        }

        private void chcHatNo_CheckedChanged(object sender, EventArgs e)
        {
            if (chcHatNo.Checked)
                cmbHatNo.Enabled = true;
            else
                cmbHatNo.Enabled = false;
        }

        private void chcTarihAraligi_CheckedChanged(object sender, EventArgs e)
        {
            if (chcTarihAraligi.Checked)
                grpTarihAraligi.Enabled = true;
            else
                grpTarihAraligi.Enabled = false;
        }
       
        private void frmGelismisArama_Load(object sender, EventArgs e)
        {

            foreach (Control ct in this.Controls)
            {
                if (ct is TextBox)
                    ct.Enabled = false;
                else if (ct is ComboBox)
                    ct.Enabled = false;

            }
            grpTarihAraligi.Enabled = false;

        }
        
        
       





    }
}
