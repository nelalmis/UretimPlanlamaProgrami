using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using System.Linq;

namespace uretimPlanlamaProgrami.RadFormlari
{
    public partial class radGiris : Telerik.WinControls.UI.RadForm
    {
        public radGiris()
        {
            InitializeComponent();
        }



        ses s = new ses();
        public class LoginInfor {
            public string kullaniciAdi { get; set; }
            public string parola { get; set; }
            public int tip { get; set; }
        
        }
        private void btnGiris_Click_1(object sender, EventArgs e)
        {



            if ((textBox1.Text == "") && (textBox2.Text == ""))
            {
                lblDurum.Text = "Kullanıcı Adı ve Şifre Boş Geçilemez.";
                textBox1.Focus();
                lbl1();
            }
            else if ((textBox1.Text == "") && (textBox2.Text != ""))
            {
                lblDurum.Text = "Kullanıcı Adı Boş Geçilemez.";
                textBox1.Focus();
                lbl1();
            }
            else if ((textBox1.Text != "") && (textBox2.Text == ""))
            {
                lblDurum.Text = "Şifre Boş Geçilemez.";
                textBox2.Focus();
                lbl1();
            }
            else
            {
                veritabani.baglan();



                SqlCommand ilkAcilisMi = new SqlCommand("select max(id) as id from TatilGunleriZamanlar",veritabani.conn);
                SqlDataReader ilkAcilisOku = ilkAcilisMi.ExecuteReader();
                if (ilkAcilisOku.Read()) { 
                        string idd=ilkAcilisOku["id"].ToString();
                        if (idd.ToString() == "")
                        {
                            SqlCommand eklee = new SqlCommand("insert into TatilGunleriZamanlar(tatilGunuBaslangic,tatilGunu) values('" + DateTime.Now + "','YOK')", veritabani.conn);
                            eklee.ExecuteNonQuery();

                        }
                }

                

                LoginInfor nesneSinif = new LoginInfor();
                this.Cursor = Cursors.WaitCursor;
                
                bool onay=false;
               
                SqlCommand sql = new SqlCommand("select * from kullanici where kullaniciAdi='" + textBox1.Text + "' and parola='"+textBox2.Text+"'", veritabani.conn);
                SqlDataReader dr = sql.ExecuteReader();
               
               if(dr.Read()){
                   if (((dr["kullaniciAdi"].ToString() == textBox1.Text) && (dr["parola"].ToString() == textBox2.Text && (Convert.ToInt16(dr["uyeTip"]) == 2))))
                   {
                       //kullanıcı
                       onay = true;
                       lbl2();
                       
                       nesneSinif.kullaniciAdi = textBox1.Text;
                       nesneSinif.parola = textBox2.Text;
                       nesneSinif.tip = 2;
                       timer3.Start();
                     
                      
                   }
                   else if (((dr["kullaniciAdi"].ToString() == textBox1.Text) && (dr["parola"].ToString() == textBox2.Text && (Convert.ToInt16(dr["uyeTip"]) == 1))))
                   {
                       //admin
                       onay = true;
                      
                       lbl2();
                       
                       timer1.Start();
                       nesneSinif.kullaniciAdi = textBox1.Text;
                       nesneSinif.parola = textBox2.Text;
                       nesneSinif.tip = 1;

                      
                   }
                  

                }
               if (onay == false)
               {
                   this.Cursor = Cursors.Default;
                   lblDurum.Text = "Kullanıcı Adı veya Şifre Yanlıştır.";
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
            lblDurum.BackColor = Color.Red;
            lblDurum.ForeColor = Color.White;
            s.hata_sesi();
        }
        void lbl2()
        {
            lblDurum.BackColor = Color.Lime;
            lblDurum.ForeColor = Color.Black;
            s.onay_sesi();
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            timer2.Start();
            lbl2();
        }

        private void radGiris_Load(object sender, EventArgs e)
        {
            checkSQL();
            lblDurum.Text = "";
        }
        void enabled_false()
        {
            btnGiris.Enabled = false;
            btnIptal.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            btnSiteyeGit.Enabled = false;

        }
        int i = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            enabled_false();
            this.Cursor = Cursors.WaitCursor;
            timer1.Interval = 1000;
            i++;
            if (i == 1)
            {
                lblDurum.Text = "Veriler Onaylandı.";
            }
            else if (i == 2)
            {
                lblDurum.Text = "Lütfen Bekleyin...";
            }
            else if (i == 3)
            {
                lblDurum.Text = "Admin Anasayfası Yükleniyor...";

            }
            else
            {
                timer1.Stop();
                radAnasayfa ad = new radAnasayfa(1);
                ad.Show();
                this.Cursor = Cursors.Default;
                this.Hide();
            }
        }
        int j = 0;

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            enabled_false();
            timer2.Interval = 1000;
            j++;
            if (j == 1)
            {
                lblDurum.Text = "Program Kapatılıyor.";
            }
            else if (j == 2)
            {
                lblDurum.Text = "Hoşçakalın...";
            }
            else
            {
                timer2.Stop();
                this.Cursor = Cursors.Default;
                Application.Exit();
            }
        }
        int k = 0;
        private void timer3_Tick(object sender, EventArgs e)
        {
            enabled_false();
            this.Cursor = Cursors.WaitCursor;
            timer3.Interval = 1000;
            k++;
            if (k == 1)
            {
                lblDurum.Text = "Veriler Onaylandı.";
            }
            else if (k == 2)
            {
                lblDurum.Text = "Lütfen Bekleyin...";
            }
            else if (k == 3)
            {
                lblDurum.Text = "Kullanıcı Anasayfası Yükleniyor...";
            }
            else
            {
                timer3.Stop();
                radAnasayfa kul = new radAnasayfa(2);
                kul.Show();
                this.Cursor = Cursors.Default;
                this.Hide();

            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            RadTextBoxControl t = sender as RadTextBoxControl;
            t.BackColor = Color.DeepSkyBlue;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            RadTextBoxControl t = sender as RadTextBoxControl;
            t.BackColor = Color.White;
        }

        private void btnSiteyeGit_Click(object sender, EventArgs e)
        {
            ProcessStartInfo adres = new ProcessStartInfo("http://www.taysanplastik.com/");
            Process.Start(adres);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        string[] yuklusqller;
        private void checkSQL()
        {
            veritabani.baglan();
            //HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names

            //Eğer bu bilgisayarda SQL SERVER veya SQLSERVEREXPRESS sürümü yüklendi ise yukarıda regedit bölümünde yüklü SQL SERVER instance'leri yer alacaktır.          



            string[] yuklusqller = (string[])Registry.LocalMachine.OpenSubKey("Software").OpenSubKey("Microsoft").OpenSubKey("Microsoft SQL Server").GetValue("InstalledInstances");

            //Eğer kullanıcının bilgisayarında SQLExpress yüklü değilse

            var yukluozellikler = (from s in yuklusqller

                                   where s.Contains("SQLEXPRESS")

                                   select s).FirstOrDefault();

            if (yukluozellikler == null)
            {

                MessageBox.Show("Programı kullanabilmek için SQLEXPRESS-2012 gereklidir!?", "UYARI", MessageBoxButtons.OK);

                 this.Close();

            }else{
                SqlCommand cmd = new SqlCommand("select * from sys.databases where name = 'Planlama'", veritabani.conn);
                SqlDataReader oku = cmd.ExecuteReader();
                if (oku.Read())
                {
                    

                }
                else
                {
                    groupBox1.Enabled = false;
                    VeritabaniYuklemeFormu veri = new VeritabaniYuklemeFormu();
                    veri.Show();
                    
                }
            }

        }

        private void radGiris_Activated(object sender, EventArgs e)
        {
           // createDB();
        }


        void createDB()
        {

            SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Planlama;Integrated security=true");

            //Aşağıdaki sorgu SQLEXPRESS üzerinde bizim veritabanımızın (SETUPPROJESI) olup olmadığını kontrol ediyor ve eğer yoksa böyle bir veritabanı oluşturuyor.

            SqlCommand cmd = new SqlCommand("if not exists(select * from sys.databases where name = 'Planlama') begin CREATE DATABASE SETUPPROJESI ON PRIMARY (NAME = Planlama_data,FILENAME = 'C:\\Planlama.mdf',SIZE = 30MB,MAXSIZE = 50MB, FILEGROWTH = 10%) LOG ON (NAME = Planlama_Log,FILENAME = 'C:\\Planlama.ldf',SIZE = 1MB,MAXSIZE = 5MB,FILEGROWTH = 10%) end");

            conn.Open();

            cmd.ExecuteNonQuery();

            conn.Close();

            //Şimdi de veritabanımız içerisinde tablomuzun olup olmadığına bakalım ve eğer tablomuz yoksa tablomuzu oluşturalım ve verilerimizi atalım.

            conn.ConnectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=Planlama;Integrated security=true";

            //Aşağıdaki sorgu Kullanicilar tablosunun olup olmadığına bakmakta ve eğer yoksa oluşturarak içerisine kayıtları eklemektedir.

            //cmd.CommandText = "if not exists(select * from sys.tables where name = 'kullanici') begin create table kullanici(TcKimlikNo int primary key,ad nvarchar(50),SoyAd nvarchar(50),yas int ) insert into tbl_temelBilgiler (TcKimlikNo,ad,soyAd,yas) values('64394830987', 'Seref','AKYUZ','22') insert into tbl_temelBilgiler (TcKimlikNo,ad,soyAd,yas) values('64394830987', 'Seref','AKYUZ','22')  end";

            //conn.Open();

            //cmd.ExecuteNonQuery();

            //conn.Close();

        }

        private void radGiris_FormClosed(object sender, FormClosedEventArgs e)
        {
            veritabani.baglantiyiKes();
        }
        
    }
}
