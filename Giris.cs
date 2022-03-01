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
    public partial class Giris : Form
    {
        
        public Giris()
        {
            InitializeComponent();
           
        }
        ses s = new ses();
        private void btnGiris_Click(object sender, EventArgs e)
        {
          
            if ((textBox1.Text == "") && (textBox2.Text == ""))
            {
                label3.Text = "Kullanıcı Adı ve Şifre Boş Geçilemez.";
                textBox1.Focus();
                lbl1();
            }
            else if ((textBox1.Text == "") && (textBox2.Text != ""))
            {
                label3.Text = "Kullanıcı Adı Boş Geçilemez.";
                textBox1.Focus();
                lbl1();
            }
            else if ((textBox1.Text != "") && (textBox2.Text == ""))
            {
                label3.Text = "Şifre Boş Geçilemez.";
                textBox2.Focus();
                lbl1();
            }
            else
            {
                
                
                bool onay=false;
                veritabani.baglan();
                SqlCommand sql = new SqlCommand("select * from kullanici where kullaniciAdi='" + textBox1.Text + "' and parola='"+textBox2.Text+"'", veritabani.conn);
                SqlDataReader dr = sql.ExecuteReader();
               
               if(dr.Read()){
                   if (((dr["kullaniciAdi"].ToString() == textBox1.Text) && (dr["parola"].ToString() == textBox2.Text && (Convert.ToInt16(dr["uyeTip"]) == 2))))
                   {
                       //kullanıcı
                       onay = true;
                       lbl2();
                      
                       timer3.Start();
                     
                      
                   }
                   else if (((dr["kullaniciAdi"].ToString() == textBox1.Text) && (dr["parola"].ToString() == textBox2.Text && (Convert.ToInt16(dr["uyeTip"]) == 1))))
                   {
                       //admin
                       onay = true;
                      
                       lbl2();
                       
                       timer1.Start();
                      

                      
                   }
                  

                }
               if (onay == false)
               {
                  
                   label3.Text = "Kullanıcı Adı veya Şifre Yanlıştır.";
                   textBox1.Clear();
                   textBox2.Clear();
                   textBox1.Focus();
                   lbl1();
               }
            }
            veritabani.baglantiyiKes();
            }
        
        void lbl1()
        {
            label3.BackColor = Color.Red;
            label3.ForeColor = Color.White;
            s.hata_sesi();
        }
        void lbl2()
        {
            label3.BackColor = Color.Lime;
            label3.ForeColor = Color.Black;
            s.onay_sesi();
        }

        private void Giris_Load(object sender, EventArgs e)
        {
            //AdminAnasayfa ad = new AdminAnasayfa();
           //ad.Show();

        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
          
            timer2.Start();
            lbl2();

        }
        void Titret()
        {
            for (int i = 0; i <= 300; i++)
            {
                this.Left += 10;
                this.Top += 10;
                this.Left -= 10;
                this.Top -= 10;
            }
        }
         void enabled_false()
        {
            btnGiris.Enabled = false;
            btnIptal.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
           
        }
        int i=0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            enabled_false();
            
            timer1.Interval = 1000;
            i++;
            if (i == 1)
            {
                label3.Text = "Veriler Onaylandı.";
            }
            else if (i == 2)
            {
                label3.Text = "Lütfen Bekleyin...";
            }
            else if (i == 3)
            {
                label3.Text = "Admin Anasayfası Yükleniyor...";

            }
            else
            {
                timer1.Stop();
                AdminAnasayfa ad = new AdminAnasayfa();
                ad.Show();
                this.Hide();
            }
        }
        int j = 0;

        private void timer2_Tick(object sender, EventArgs e)
        {

            enabled_false();
            timer2.Interval = 1000;
            j++;
            if (j == 1)
            {
                label3.Text = "Program Kapatılıyor.";
            }
            else if (j == 2)
            {
                label3.Text = "Hoşçakalın...";
            }
            else
            {
                timer2.Stop();
                Application.Exit();
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            TextBox t = sender as TextBox;
            t.BackColor = Color.DeepSkyBlue;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            TextBox t = sender as TextBox;
            t.BackColor = Color.White;
        }

        private void btnGiris_Leave(object sender, EventArgs e)
        {
            Button b = sender as Button;
            b.BackColor = Color.Bisque;
        }

        private void btnGiris_Enter(object sender, EventArgs e)
        {
            Button b = sender as Button;
            b.BackColor = Color.DeepSkyBlue;
        }
        int k=0;
        private void timer3_Tick(object sender, EventArgs e)
        {
            enabled_false();
            timer3.Interval = 1000;
            k++;
            if (k == 1)
            {
                label3.Text = "Veriler Onaylandı.";
            }
            else if (k == 2)
            {
                label3.Text = "Lütfen Bekleyin...";
            }
            else if (k == 3)
            {
                label3.Text = "Kullanıcı Anasayfası Yükleniyor...";
            }
            else
            {
                timer3.Stop();
                Anasayfa kul = new Anasayfa();
                kul.Show();
                this.Hide();
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Giris g = new Giris();
            g.Visible = false;
            
        }
        
        }
    
}


