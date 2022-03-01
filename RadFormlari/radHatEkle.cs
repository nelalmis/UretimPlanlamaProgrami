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
    public partial class radHatEkle : Telerik.WinControls.UI.RadForm
    {
        public radHatEkle()
        {
            InitializeComponent();
        }

        hatalar hata = new hatalar();

        private void radButton1_Click(object sender, EventArgs e)
        {
            veritabani.baglan();

            try
            {
                if (txtHatNo.Text == "")
                {
                    lblHat.Text = "Hat numarası giriniz!";
                }
                else
                {
                    SqlCommand sor = new SqlCommand("select numara from uretimHatti where numara='" + txtHatNo.Text + "'", veritabani.conn);
                    SqlDataReader oku = sor.ExecuteReader();
                    if (oku.Read())
                    {
                        MessageBox.Show("Bu hat mevcut.Lütfen başka bir hat numarası giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else
                    {
                        SqlCommand ekle = new SqlCommand("insert into uretimHatti(numara,aktiflik,kullanilabilirmi) values('" + txtHatNo.Text + "',0,1)", veritabani.conn);
                        ekle.ExecuteNonQuery();

                        SqlCommand ekle2 = new SqlCommand("insert into hatBitisTarih(hatNo) values('" + txtHatNo.Text + "')", veritabani.conn);
                        ekle2.ExecuteNonQuery();

                        MessageBox.Show("HAT numarası başarıyla eklendi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        fonksiyonHatNoBul();


                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hata.hataKodu = "radHatEkle-radButton1_Click";
                hata.hataMesajı = ex.Message;
                hata.hataMesajiKaydet();

            }
        }

        private void txtHatNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= (char)48) && (e.KeyChar <= (char)59) || (e.KeyChar == (char)8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void radHatEkle_Load(object sender, EventArgs e)
        {
            fonksiyonHatNoBul();
           
        }
        private void fonksiyonHatNoBul() {
            try
            {
                veritabani.baglan();
                SqlCommand hatlarAl = new SqlCommand("select numara from uretimHatti order by numara asc", veritabani.conn);
                SqlDataReader hatlariOlu = hatlarAl.ExecuteReader();
                //SqlCommand hatSayisiAl = new SqlCommand("select max(numara) from uretimHatti",veritabani.conn);
                //int hatSayisi = Convert.ToInt32(hatSayisiAl.ExecuteScalar());
                int i = 1;
                while (hatlariOlu.Read())
                {
                    if (i == Convert.ToInt32(hatlariOlu["numara"]))
                    {
                        i++;

                    }
                    else

                        break;


                }

                txtHatNo.Text = i.ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hata.hataKodu = "radHatEkle-fonksiyonHatNoBul";
                hata.hataMesajı = ex.Message;
                hata.hataMesajiKaydet();

            }
        
        }
    }
}
