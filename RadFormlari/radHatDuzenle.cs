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
    public partial class radHatDuzenle : Telerik.WinControls.UI.RadForm
    {
        public radHatDuzenle()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSil.Enabled = true;
        }

       

       

        private void radHatDuzenle_Load(object sender, EventArgs e)
        {
            veritabani.baglan();
            panel1.Visible = false;
            listBOxDoldur();
            if (listBox1.SelectedItems.Count == 0)
            {
                btnSil.Enabled = false;

            }
            else
            {

                btnSil.Enabled = true;
            }
        }
        private void listBOxDoldur()
        {
            try
            {
                SqlCommand al = new SqlCommand("select numara from uretimHatti", veritabani.conn);
                SqlDataReader oku = al.ExecuteReader();

                while (oku.Read())
                {
                    listBox1.Items.Add("HAT-" + oku["numara"]);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hata.hataKodu = "radHatEkle-listBOxDoldur";
                hata.hataMesajı = ex.Message;
                hata.hataMesajiKaydet();

            }
        }

        private void btnSil_Click_1(object sender, EventArgs e)
        {
            try
            {
                DialogResult cevap;
                cevap = MessageBox.Show("Üretim Hattını silmek istediğinizden emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes)
                {
                    SqlCommand sor2 = new SqlCommand("delete from hatBitisTarih where hatNo='" + listBox1.SelectedItem.ToString().Substring(4) + "' ", veritabani.conn);
                    sor2.ExecuteNonQuery();
                    SqlCommand sor = new SqlCommand("delete from uretimHatti where numara='" + listBox1.SelectedItem.ToString().Substring(4) + "' ", veritabani.conn);
                    sor.ExecuteNonQuery();
                    
                    listBox1.Items.Remove(listBox1.SelectedItem);
                    MessageBox.Show("Hat başarıyla silindi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Bu Hat Kullanılıyor!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        int no;
        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count != 0)
            {
                panel1.Visible = true;

                txtHatNo.Text = listBox1.SelectedItem.ToString().Substring(4);
                no = Convert.ToInt32(txtHatNo.Text);
            }
            else
            {
                MessageBox.Show("Bir hat numarası seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        hatalar hata = new hatalar();
        private void btnGuncelle_Click_1(object sender, EventArgs e)
        {
            if (txtHatNo.Text == "")
            {
                lblHatno.Text = "Hat numarası giriniz!";
            }
            else
            {
                try
                {
                    string hatno = txtHatNo.Text;
                    SqlCommand sor = new SqlCommand("select numara from uretimHatti where numara='" + txtHatNo.Text + "' and numara!='"+hatno+"' ", veritabani.conn);
                    SqlDataReader oku = sor.ExecuteReader();

                    if (oku.Read())
                    {
                        MessageBox.Show("Bu hat mevcut.Lütfen başka bir hat numarası giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                    else
                    {
                        SqlCommand gun = new SqlCommand("update urunUretimHatlari set HatNo='" + Convert.ToInt32(txtHatNo.Text) + "' where HatNo='" + no + "'", veritabani.conn);
                        gun.ExecuteNonQuery();

                        SqlCommand ekle = new SqlCommand("update uretimHatti set numara='" + Convert.ToInt32(txtHatNo.Text) + "' where numara='" + no + "'", veritabani.conn);

                        ekle.ExecuteNonQuery();

                        listBox1.Items.Clear();
                        listBOxDoldur();

                        MessageBox.Show("HAT numarası başarıyla güncellendi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        txtHatNo.Text = "";
                        panel1.Visible = false;

                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    hata.hataKodu = "radHatDuzenle-btnGuncelle_Click_1";
                    hata.hataMesajı = ex.Message;
                    hata.hataMesajiKaydet();

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }
    }
}
