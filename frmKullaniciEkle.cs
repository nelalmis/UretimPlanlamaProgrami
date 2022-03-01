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
    public partial class frmKullaniciEkle : Form
    {
        public frmKullaniciEkle()
        {
            InitializeComponent();
        }
        ses s = new ses();
        private void btnKulEkle_Click(object sender, EventArgs e)
        {
            if(txtAd.Text==""){
                lblAd.Text="Kullanıcı adı boş bırakılamaz!";
   
            }
            else if (txtParola.Text == "")
            {
                lblAd.Text = "";
                lblParola.Text = "Parola boş bırakılamaz!";


            }
            else if(comboBox1.SelectedIndex==-1){

                lblParola.Text = "";
                lblTur.Text = "Uye türünü seçiniz!";
            }else if(txtParola.Text!=txtParolaTekrar.Text){
                s.hata_sesi();
                MessageBox.Show("Parolalar aynı değil.Lütfen kontrol ediniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            
            } 
            
            else{
                try
                {
                    txtAd.Enabled = false;
                    txtParola.Enabled = false;
                    txtParolaTekrar.Enabled = false;
                    btnKulEkle.Enabled = false;

                    veritabani.baglan();
                    lblTur.Text = "";
                    lblAd.Text = "";
                    lblParola.Text = "";
                    SqlCommand sor = new SqlCommand("insert into kullanici(KullaniciAdi,parola,uyeTip) values('" + txtAd.Text + "','" + txtParola.Text + "','" + (comboBox1.SelectedIndex+1) + "')", veritabani.conn);
                    sor.ExecuteNonQuery();
                    s.onay_sesi();
                    MessageBox.Show("Yeni üye başarıyla eklendi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);



                }
                catch (Exception)
                {
                    MessageBox.Show("Bir hata oluştu!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
            }
        }

        private void btnYeniKayit_Click(object sender, EventArgs e)
        {
            if (btnKulEkle.Enabled == true)
            {
                s.hata_sesi();
                MessageBox.Show("Yeni kullanıcı kaydı zaten açık", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }
            else {
                txtAd.Text = "";
                txtAd.Enabled = true;
                txtParola.Text = "";
                txtParola.Enabled = true;
                txtParolaTekrar.Text = "";
                txtParolaTekrar.Enabled = true;
                btnKulEkle.Enabled = true;
                
            
            }
        }

        private void frmKullaniciEkle_Load(object sender, EventArgs e)
        {

        }
    }
}
