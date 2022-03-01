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
    public partial class frmRenkEkle : Form
    {
        SqlCommand cmd;
         

        public frmRenkEkle()
        {
            InitializeComponent();
        }

        private void frmRenkEkle_Load(object sender, EventArgs e)
        {
            

        }

        private void btnRenkEkle_Click(object sender, EventArgs e)
        {
           


            if (txtRenKodu.Text == "") {
                lblKod.Text = "Renk kodu boş bırakılamaz!";
            }
            else if (txtRenkAdi.Text =="")
            {
                lblKod.Text = "";
                lblAd.Text = "Renk adı boş bırakılamaz!";
            }
            else {
                cmd = new SqlCommand();
                cmd.Connection = veritabani.conn;
                veritabani.baglan();
                cmd.CommandText = "select * from renkler where renkAdi='"+txtRenkAdi.Text+"' or kod='"+txtRenKodu.Text+"'" ;
                SqlDataReader read = cmd.ExecuteReader();
                if (read.Read())
                {
                    MessageBox.Show("Renk adı veya kodu sistemde mevcut! Başka bir renk adı veya kod giriniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    cmd.Connection.Close();
                    cmd.Connection.Open();
                    

                    cmd.CommandText = "insert into renkler(renkAdi,kod) values(@renkAdi,@kod)";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@renkAdi", txtRenkAdi.Text);
                    cmd.Parameters.AddWithValue("@kod", txtRenKodu.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Renk bilgileri başarıyla eklendi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    txtRenkAdi.Text = "";
                    txtRenKodu.Text = "";
                   
                }
                veritabani.baglantiyiKes();
            }



        }

        private void txtRenKodu_TextChanged(object sender, EventArgs e)
        {
            lblKod.Text = "";
        }
    }
}
