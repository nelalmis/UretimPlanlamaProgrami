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
    public partial class radRenkEkle : Telerik.WinControls.UI.RadForm
    {
        public radRenkEkle()
        {
            InitializeComponent();
        }
        SqlCommand cmd;
         
        private void btnRenkEkle_Click(object sender, EventArgs e)
        {

        }

        private void txtRenKodu_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtRenkKodu.Text == "")
            {
                lblKod.Text = "Renk kodu boş bırakılamaz!";
            }
            else if (txtRenkAdi.Text == "")
            {
                lblKod.Text = "";
                lblAd.Text = "Renk adı boş bırakılamaz!";
            }
            else
            {
                cmd = new SqlCommand();
                cmd.Connection = veritabani.conn;
                veritabani.baglan();
                cmd.CommandText = "select * from renkler where kod='" + txtRenkKodu.Text + "'";
                SqlDataReader read = cmd.ExecuteReader();
                if (read.Read())
                {
                    MessageBox.Show("Bu kodla kayıtlı başka bir renk sistemde mevcut! Lütfen farklı bir kod giriniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    cmd.Connection.Close();
                    cmd.Connection.Open();


                    cmd.CommandText = "insert into renkler(renkAdi,kod) values(@renkAdi,@kod)";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@renkAdi", txtRenkAdi.Text);
                    cmd.Parameters.AddWithValue("@kod", txtRenkKodu.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Renk bilgileri başarıyla eklendi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    txtRenkAdi.Text = "";
                    txtRenkKodu.Text = "";

                }
                veritabani.baglantiyiKes();
            }
        }

        private void txtRenkKodu_TextChanged(object sender, EventArgs e)
        {
            lblKod.Text = "";
        }

        private void txtRenkAdi_TextChanged(object sender, EventArgs e)
        {
            lblAd.Text = "";
        }

        private void Renk_Enter(object sender, EventArgs e)
        {

        }
    }
}
