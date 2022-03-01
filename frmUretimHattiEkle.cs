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
    public partial class frmUretimHattiEkle : Form
    {
        SqlConnection conn = new SqlConnection("Server=VAIO\\SQLEXPRESS;Database=Planlama; Integrated Security=true; MultipleActiveResultSets=true");
        public frmUretimHattiEkle()
        {
            InitializeComponent();
        }

        private void frmUretimHattiEkle_Load(object sender, EventArgs e)
        {
            conn.Open();
            
        }

        private void btnHatEkle_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                lblHat.Text = "Hat numarası giriniz!";
            }
            else
            {
                SqlCommand sor = new SqlCommand("select numara from uretimHatti where numara='" + textBox1.Text + "'", conn);
                SqlDataReader oku = sor.ExecuteReader();
                if (oku.Read())
                {
                    MessageBox.Show("Bu hat mevcut.Lütfen başka bir hat numarası giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else {
                    SqlCommand ekle = new SqlCommand("insert into uretimHatti(numara,aktiflik,kullanilabilirmi) values('"+textBox1.Text+"',0,1)",conn);
                    ekle.ExecuteNonQuery();

                    SqlCommand ekle2 = new SqlCommand("insert into hatBitisTarih(hatNo) values('"+textBox1.Text+"')",conn);
                    ekle2.ExecuteNonQuery();

                    MessageBox.Show("HAT numarası başarıyla eklendi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    textBox1.Text = "";
                    
                
                }
            }


        }

        private void frmUretimHattiEkle_FormClosed(object sender, FormClosedEventArgs e)
        {
            conn.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= (char)48) && (e.KeyChar <= (char)59) || (e.KeyChar == (char)8))
                e.Handled = false;
            else
                e.Handled = true;
        }
    }
}
