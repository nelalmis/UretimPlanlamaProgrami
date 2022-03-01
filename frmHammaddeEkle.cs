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
    public partial class frmHammaddeEkle : Form
    {
        SqlConnection conn = new SqlConnection("Server=VAIO\\SQLEXPRESS;Database=Planlama; Integrated Security=true; MultipleActiveResultSets=true");
        public frmHammaddeEkle()
        {
            InitializeComponent();
        }
        ses s = new ses();

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmHammaddeEkle_Load(object sender, EventArgs e)
        {
            conn.Open();
        }

        private void btnHammaddeEkle_Click(object sender, EventArgs e)
        {
            if (txtHammadde.Text == "")
            {
                s.hata_sesi();
                MessageBox.Show("Hammadde ismi boş bırakılamaz", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                try
                {
                    SqlCommand sor = new SqlCommand("select count(adi) from hammadde where adi='"+txtHammadde.Text+"'",conn);
                    int sayi = Convert.ToInt16(sor.ExecuteScalar());
                    if (sayi==0)
                    {
                        SqlCommand ekle = new SqlCommand("insert into hammadde(adi) values('" + txtHammadde.Text + "') select adi from hammadde where not exists(select adi from hammadde where adi='" + txtHammadde.Text + "'); ", conn);
                        ekle.ExecuteNonQuery();
                        s.onay_sesi();
                        MessageBox.Show("Hammadde başarıyla eklendi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        txtHammadde.Text = "";
                    }
                    else {
                        s.hata_sesi();
                        MessageBox.Show("Bu hammadde mevcut!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }catch(Exception){
                    s.hata_sesi();
                    MessageBox.Show("Bir hata oluştu!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void txtHammadde_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
