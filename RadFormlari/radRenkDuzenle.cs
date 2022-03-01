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
    public partial class radRenkDuzenle : Telerik.WinControls.UI.RadForm
    {
        public radRenkDuzenle()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
       
        
        
        private void radRenkDuzenle_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'genelDataSet.renkler' table. You can move, or remove it, as needed.
            this.renklerTableAdapter.Fill(this.genelDataSet.renkler);
            panel1.Visible = false;
            
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            txtAd.Text = radGridView1.CurrentRow.Cells[1].Value.ToString();
            txtKod.Text = radGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void btnSil_Click_1(object sender, EventArgs e)
        {
            veritabani.baglan();
            DialogResult cevap;
            cevap = MessageBox.Show("Kaydı silmek istediğinizden emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes)
            {
                SqlCommand sill = new SqlCommand("delete from renkler where id='" + radGridView1.CurrentRow.Cells[0].Value + "'", veritabani.conn);
                sill.ExecuteNonQuery();

                radGridView1.Rows.Remove(radGridView1.CurrentRow);
                radGridView1.Refresh();
                MessageBox.Show("Kayıt başarıyla silindi!", "BİLGİ", MessageBoxButtons.OK);

            }
        }
        SqlCommand cmd;
        private void btnGuncelle_Click_1(object sender, EventArgs e)
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


                    cmd.CommandText = "update renkler set renkAdi='" + txtAd.Text + "', kod='" + txtKod.Text + "' where id='" + radGridView1.CurrentRow.Cells[0].Value + "'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Renk bilgileri başarıyla güncellendi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    txtKod.Text = "";
                    txtAd.Text = "";
                    radGridView1.Refresh();
                    panel1.Visible = false;
                }
                veritabani.baglantiyiKes();
            }
        }
        
        private void radGridView1_CellValueChanged(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            //this.Validate();
            //this.renklerBindingSource.EndEdit();
            //this.renklerTableAdapter.Update(this.genelDataSet.renkler);
            //
        }

        private void radGridView1_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
        {
            e.RowElement.RowInfo.Height = 60;
        }
    }
}
