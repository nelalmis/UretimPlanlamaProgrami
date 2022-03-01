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
    public partial class frmHammaddeDuzenle : Form
    {
        SqlConnection conn = new SqlConnection("Server=VAIO\\SQLEXPRESS;Database=Planlama; Integrated Security=true; MultipleActiveResultSets=true");
        string hammaddeAdi;
        public frmHammaddeDuzenle()
        {
            InitializeComponent();
        }
        ses s = new ses();
        public void listDoldur() {
            DataTable table = new DataTable();
            SqlCommand hammadde = new SqlCommand("select id,adi from hammadde", conn);
            SqlDataAdapter dp = new SqlDataAdapter(hammadde);
            dp.Fill(table);
            listBox1.DataSource = new BindingSource(table, null);
            listBox1.DisplayMember = "adi";
            listBox1.ValueMember = "id";
        
        }
        private void frmHammaddeDuzenle_Load(object sender, EventArgs e)
        {
            conn.Open();
            listDoldur();
            pnlHammaddeDuzenle.Visible = false;
            listBox1.SelectedItems.Clear();

            if (listBox1.SelectedItems.Count == 0)
            {
                btnSil.Enabled = false;

            }
            else {

                btnSil.Enabled = true;
            }

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
           


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSil.Enabled = true;
        }

        private void btnDuzenle_Click(object sender, EventArgs e)

        {
            if (listBox1.SelectedItems.Count == 0)
            {
                s.hata_sesi();
                MessageBox.Show("Bir hammadde seçiniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else {
                s.onay_sesi();
                pnlHammaddeDuzenle.Visible = true;
                txtHammadde.Text = listBox1.GetItemText(listBox1.SelectedItem);
                hammaddeAdi = txtHammadde.Text;
            }


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
                    SqlCommand sor = new SqlCommand("select count(adi) from hammadde where not exists(select count(adi) from hammadde where adi='" + txtHammadde.Text + "')", conn);
                    int sayi = Convert.ToInt16(sor.ExecuteScalar());
                    if (sayi == 0)
                    {
                        SqlCommand ekle = new SqlCommand("update hammadde set adi='"+txtHammadde.Text+"' where adi='"+hammaddeAdi+"' ", conn);
                        ekle.ExecuteNonQuery();
                        s.onay_sesi();
                        MessageBox.Show("Hammadde başarıyla güncellendi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        txtHammadde.Text = "";
                        pnlHammaddeDuzenle.Visible = false;
                        listDoldur();
                    }
                    else
                    {
                        s.hata_sesi();
                        MessageBox.Show("Bu hammadde mevcut!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void btnSil_Click_1(object sender, EventArgs e)
        {

        }
    }
}
