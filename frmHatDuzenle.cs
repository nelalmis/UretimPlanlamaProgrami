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
    public partial class frmHatDuzenle : Form
    {
        SqlConnection conn = new SqlConnection("Server=VAIO\\SQLEXPRESS;Database=Planlama; Integrated Security=true; MultipleActiveResultSets=true");
        int no;
        public frmHatDuzenle()
        {
            InitializeComponent();
        }

        private void frmHatDuzenle_Load(object sender, EventArgs e)
        {
            conn.Open();
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
            SqlCommand al = new SqlCommand("select numara from uretimHatti", conn);
            SqlDataReader oku = al.ExecuteReader();
            while (oku.Read())
            {
                listBox1.Items.Add("HAT-" + oku["numara"]);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult cevap;
                cevap = MessageBox.Show("Üretim Hattını silmek istediğinizden emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes)
                {

                    SqlCommand sor = new SqlCommand("delete from uretimHatti where numara='" + listBox1.SelectedItem.ToString().Substring(4) + "' ", conn);
                    sor.ExecuteNonQuery();
                    SqlCommand sor2 = new SqlCommand("delete from hatBitisTarih where hatNo='" + listBox1.SelectedItem.ToString().Substring(4) + "' ", conn);
                    sor2.ExecuteNonQuery();
                    listBox1.Items.Remove(listBox1.SelectedItem);
                    MessageBox.Show("Hat başarıyla silindi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Bu Hat Kullanılıyor!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count != 0)
            {
                panel1.Visible = true;

                textBox1.Text = listBox1.SelectedItem.ToString().Substring(4);
                no = Convert.ToInt32(textBox1.Text);
            }
            else
            {
                MessageBox.Show("Bir hat numarası seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
            {
                lblHatno.Text = "Hat numarası giriniz!";
            }
            else
            {
                try
                {
                    SqlCommand sor = new SqlCommand("select numara from uretimHatti where numara='" + textBox1.Text + "'", conn);
                    SqlDataReader oku = sor.ExecuteReader();

                    if (oku.Read())
                    {
                        MessageBox.Show("Bu hat mevcut.Lütfen başka bir hat numarası giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                    else
                    {
                        SqlCommand gun = new SqlCommand("update urunUretimHatlari set HatNo='" + Convert.ToInt32(textBox1.Text) + "' where HatNo='" + no + "'", conn);
                        gun.ExecuteNonQuery();

                        SqlCommand ekle = new SqlCommand("update uretimHatti set numara='" + Convert.ToInt32(textBox1.Text) + "' where numara='" + no + "'", conn);

                        ekle.ExecuteNonQuery();

                        listBox1.Items.Clear();
                        listBOxDoldur();

                        MessageBox.Show("HAT numarası başarıyla güncellendi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        textBox1.Text = "";
                        panel1.Visible = false;

                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Bir hata oluştu", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmHatDuzenle_FormClosed(object sender, FormClosedEventArgs e)
        {
            conn.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSil.Enabled = true;
        }

    }
}
