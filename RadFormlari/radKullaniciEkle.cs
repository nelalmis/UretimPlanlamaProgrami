using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace uretimPlanlamaProgrami.RadFormlari
{
    public partial class radKullaniciEkle : Telerik.WinControls.UI.RadForm
    {
        public radKullaniciEkle()
        {
            InitializeComponent();
        }

        private void btnYeniKayit_Click(object sender, EventArgs e)
        {

        }

        private void btnKulEkle_Click(object sender, EventArgs e)
        {

        }
        ses s = new ses();
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtAd.Text == "")
            {
                lblAd.Text = "Kullanıcı adı boş bırakılamaz!";

            }
            else if (txtParola.Text == "")
            {
                lblAd.Text = "";
                lblParola.Text = "Parola boş bırakılamaz!";


            }
            else if (cmbTur.SelectedIndex == -1)
            {

                lblParola.Text = "";
                lblTur.Text = "Uye türünü seçiniz!";
            }
            else if (txtParola.Text != txtParolaTekrar.Text)
            {
                s.hata_sesi();
                MessageBox.Show("Parolalar aynı değil.Lütfen kontrol ediniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }

            else
            {
                try
                {
                    txtAd.Enabled = false;
                    txtParola.Enabled = false;
                    txtParolaTekrar.Enabled = false;
                    btnKaydet.Enabled = false;

                    veritabani.baglan();
                    lblTur.Text = "";
                    lblAd.Text = "";
                    lblParola.Text = "";
                    SqlCommand sor = new SqlCommand("insert into kullanici(KullaniciAdi,parola,uyeTip) values('" + txtAd.Text + "','" + txtParola.Text + "','" + (cmbTur.SelectedIndex + 1) + "')", veritabani.conn);
                    sor.ExecuteNonQuery();
                    s.onay_sesi();
                    MessageBox.Show("Yeni üye başarıyla eklendi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);



                }
                catch (Exception)
                {
                    MessageBox.Show("Bir hata oluştu!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnYeniKayit_Click_1(object sender, EventArgs e)
        {
            if (btnKaydet.Enabled == true)
            {
                s.hata_sesi();
                MessageBox.Show("Yeni kullanıcı kaydı zaten açık", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }
            else
            {
                txtAd.Text = "";
                txtAd.Enabled = true;
                txtParola.Text = "";
                txtParola.Enabled = true;
                txtParolaTekrar.Text = "";
                txtParolaTekrar.Enabled = true;
                btnKaydet.Enabled = true;


            }
        }

        private void radKullaniciEkle_Load(object sender, EventArgs e)
        {
           
        }
        
       
    }
}
