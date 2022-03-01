using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace uretimPlanlamaProgrami
{
    public partial class frmRenkDuzenle : Form
    {
        SqlCommand cmd;
       
        public frmRenkDuzenle()
        {
            InitializeComponent();
        }

        private void frmRenkDuzenle_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'planlamaDataSet4.renkler' table. You can move, or remove it, as needed.
           
            veritabani.baglan();
            kayitGetir();
            panel1.Visible = false;






        }

        private void kayitGetir()
        {
            
            SqlCommand getir = new SqlCommand("select * from renkler", veritabani.conn);
            SqlDataAdapter da = new SqlDataAdapter(getir);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

          

        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            if (textBox1.Text =="") {
                lblArama.Text = "Aranacak kodu girmediniz!";
            }else
            kayitGetir2();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != null)
                lblArama.Text = "";
            
            kayitGetir2();

        }
        private void kayitGetir2()
        {
          
            SqlCommand ara = new SqlCommand("select * from renkler where kod like '"+textBox1.Text+"%'", veritabani.conn);
            SqlDataAdapter dar = new SqlDataAdapter(ara);
            DataTable dtt = new DataTable();
            dar.Fill(dtt);
            dataGridView1.DataSource = dtt;
          

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            veritabani.baglan(); 
            DialogResult cevap;
            cevap = MessageBox.Show("Kaydı silmek istediğinizden emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes)
            {
                SqlCommand sill = new SqlCommand("delete from renkler where id='" + dataGridView1.CurrentRow.Cells[0].Value + "'", veritabani.conn);
                sill.ExecuteNonQuery();
                
                kayitGetir2();
                MessageBox.Show("Kayıt başarıyla silindi!", "BİLGİ", MessageBoxButtons.OK);

            }
            
        }

        private void frmRenkDuzenle_FormClosed(object sender, FormClosedEventArgs e)
        {
            veritabani.baglantiyiKes();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            txtAd.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtKod.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (txtKod.Text == "")
            {
                lblKod.Text = "Renk kodu boş bırakılamaz!";
            }
            else if (txtAd.Text == "")
            {
                lblKod.Text = "";
                lblad.Text = "Renk adı boş bırakılamaz!";
            }
            else
            {
                cmd = new SqlCommand();
                cmd.Connection = veritabani.conn;
                veritabani.baglan();

                cmd.CommandText = "";

                cmd.CommandText = "select * from renkler where not exists (select * from renkler where renkAdi='" + txtAd.Text + "' or kod='" + txtKod.Text + "')";
                SqlDataReader read = cmd.ExecuteReader();
                if (read.Read())
                {
                    MessageBox.Show("Renk adı veya kodu sistemde mevcut! Başka bir renk adı veya kod giriniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    cmd.Connection.Close();
                    cmd.Connection.Open();


                    cmd.CommandText = "update renkler set renkAdi='" + txtAd.Text + "', kod='" + txtKod.Text + "' where id='" + dataGridView1.CurrentRow.Cells[0].Value + "'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Renk bilgileri başarıyla güncellendi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    txtKod.Text = "";
                    txtAd.Text = "";
                    kayitGetir();
                    panel1.Visible = false;
                }
                veritabani.baglantiyiKes();
            }

        }
    }
}
