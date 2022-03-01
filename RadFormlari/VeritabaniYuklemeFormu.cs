using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace uretimPlanlamaProgrami.RadFormlari
{
    public partial class VeritabaniYuklemeFormu : Form
    {
        public VeritabaniYuklemeFormu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ac = new OpenFileDialog();
            ac.Filter = "SQL Script (*.sql) |*.sql";
            ac.Multiselect = false;
            if (ac.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                txtDosya.Text = ac.FileName;
            else
                txtDosya.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            progressBar1.Value++;
            Thread t = new Thread(new ThreadStart(VeritabanıKurulumu));
            t.Start();
        }

        private void VeritabaniYuklemeFormu_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            progressBar1.Minimum = 0;
        }
        void VeritabanıKurulumu()
        {
            SqlConnection baglanti = new SqlConnection(BaglantiOlustur());
            string dosya = File.ReadAllText(txtDosya.Text);
            string[] komutlar = Regex.Split(dosya, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);
            baglanti.Open();
            progressBar1.Maximum = komutlar.Length;
            bool sonuc = true;
            foreach (string komut in komutlar)
            {
                if (komut.Trim() != "")
                {
                    try
                    {
                        new SqlCommand(komut, baglanti).ExecuteNonQuery();
                        progressBar1.Value++;
                    }
                    catch
                    {
                        sonuc = false;
                        MessageBox.Show("Bu Veritabanı Zaten Var!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                }
            }
            if (sonuc)
            {

                veritabani.baglan();
                string command = "insert into kullanici(kullaniciAdi,parola,uyeTip) values('taysan','taysan','1')";
                SqlCommand kullanici = new SqlCommand(command, veritabani.conn);
                kullanici.ExecuteNonQuery();

                command = "insert into Ayarlar(tatilGunu) values('YOK')";
                SqlCommand Ayarlar = new SqlCommand(command,veritabani.conn);
                Ayarlar.ExecuteNonQuery();

                command = "insert into DevamDurumu(id,durum) values(1,'Devam Ediyor...')";

                SqlCommand DevamDurumu = new SqlCommand(command,veritabani.conn);
                DevamDurumu.ExecuteNonQuery();

                command = "insert into DevamDurumu(id,durum) values(2,'Bitti.')";
                SqlCommand DevamDurumu1 = new SqlCommand(command, veritabani.conn);
                DevamDurumu1.ExecuteNonQuery();

                command = "insert into DevamDurumu(id,durum) values(3,'Beklemede')";
                SqlCommand DevamDurumu2= new SqlCommand(command, veritabani.conn);
                DevamDurumu2.ExecuteNonQuery();


                command = "insert into evetHayir(durum,karsilik) values('True','EVET') ";
                SqlCommand evetHayir = new SqlCommand(command, veritabani.conn);
                evetHayir.ExecuteNonQuery();

                command = "insert into evetHayir(durum,karsilik) values('False','HAYIR') ";
                SqlCommand evetHayir1 = new SqlCommand(command, veritabani.conn);
                evetHayir1.ExecuteNonQuery();

                MessageBox.Show("Script Başarıyla Çalıştırıldı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                




            }
            baglanti.Close();
        }
        string BaglantiOlustur()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = Environment.MachineName;
            builder.InitialCatalog = "master";
            builder.IntegratedSecurity = true;
            return builder.ConnectionString;
        }

        private void VeritabaniYuklemeFormu_FormClosed(object sender, FormClosedEventArgs e)
        {
            veritabani.baglantiyiKes();
        }
    }
}
