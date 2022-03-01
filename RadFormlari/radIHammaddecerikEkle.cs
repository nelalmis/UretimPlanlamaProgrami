using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace uretimPlanlamaProgrami.RadFormlari
{
    public partial class radIHammaddecerikEkle : Telerik.WinControls.UI.RadForm
    {
        public radIHammaddecerikEkle()
        {
            InitializeComponent();
        }
        ses s = new ses();
        private void btnKaydet_Click(object sender, EventArgs e)
        {

            veritabani.baglan();
            if (txtHammadde.Text == "")
            {
                s.hata_sesi();
                MessageBox.Show("İçerik ismi boş bırakılamaz", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                try
                {
                    SqlCommand sor = new SqlCommand("select count(icerikAdi) from Icerik where icerikAdi='" + txtHammadde.Text + "'", veritabani.conn);
                    int sayi = Convert.ToInt16(sor.ExecuteScalar());
                    if (sayi == 0)
                    {
                        SqlCommand ekle = new SqlCommand("insert into Icerik(icerikAdi) values('" + txtHammadde.Text + "')", veritabani.conn);
                        ekle.ExecuteNonQuery();
                        s.onay_sesi();
                        MessageBox.Show("İçerik başarıyla eklendi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        txtHammadde.Text = "";
                    }
                    else
                    {
                        s.hata_sesi();
                        MessageBox.Show("Bu içerik mevcut!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception)
                {
                    s.hata_sesi();
                    MessageBox.Show("Bir hata oluştu!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
