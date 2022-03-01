using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace uretimPlanlamaProgrami
{
    public partial class frmUrunEkle : Form
    {
        SqlConnection conn = new SqlConnection("Server=VAIO\\SQLEXPRESS;Database=Planlama; Integrated Security=true; MultipleActiveResultSets=true");

        // SqlConnection conn = new SqlConnection("Data Source=VAIO\\SQLEXPRESS;" + "Initial Catalog=MultiUpload; Database=Planlama;Integrated Security=true");

        public frmUrunEkle()
        {
            InitializeComponent();
        }

        private void frmUrunEkle_Load(object sender, EventArgs e)
        {
          
            conn.Open();
            listBox1.SelectedItem = false;
            SqlCommand hatlar = new SqlCommand("select numara from uretimHatti",conn);
            SqlDataReader hatOku = hatlar.ExecuteReader();
            SqlCommand hatSayi = new SqlCommand("select count(numara)  from uretimHatti", conn);
            int sayi = Convert.ToInt16(hatSayi.ExecuteScalar());
           
            
    

            while (hatOku.Read())
            {
                listBox1.Items.Add("hat-" + hatOku["numara"].ToString());

            }

        }

        private void frmUrunEkle_FormClosed(object sender, FormClosedEventArgs e)
        {
            conn.Close();
        }

        private void btnUrunEkle_Click(object sender, EventArgs e)
        {
            if (txtUrunKod.Text == "")
            {
                lblKod.ForeColor = Color.Red;
                lblKod.Text = "Ürün kodu boş geçilemez!";
            }
            else if (txtUrunHiz.Text == "")
            {
                lblHiz.ForeColor = Color.Red;
                lblHiz.Text = "Ürün hızı boş geçilemez!";
                lblKod.Text = "";
            }
            else if (txtGramaj.Text == "")
            {
                lblGramaj.ForeColor = Color.Red;
                lblGramaj.Text = "Gramaj boş geçilemez!";
                lblHiz.Text = "";
                lblKod.Text = "";
            }
            else if (txtFileMiktari.Text == "")
            {
                lblFile.ForeColor = Color.Red;
                lblFile.Text = "File Miktarı boş geçilemez!";
                lblHiz.Text = "";
                lblKod.Text = "";
                lblFile.Text = "";
            }
            else if (listBox1.SelectedItems.Count == 0)
            {
                MessageBox.Show("En az bir adet hat seçmelisiniz");

            }
            else {
                try
                {
                    int sayi=0;

                    SqlCommand sor = new SqlCommand("select count(kod) from urunler where kod='" + txtUrunKod.Text + "'",conn);
                    sayi = Convert.ToInt32(sor.ExecuteScalar());
                    if (sayi == 0)
                    {

                        FileStream fs = new FileStream(resim, FileMode.Open, FileAccess.Read);
                        BinaryReader br = new BinaryReader(fs);

                        byte[] resimm = br.ReadBytes((int)fs.Length);

                        br.Close();

                        fs.Close();
                        SqlCommand insertt = new SqlCommand("insert into urunler(kod,hizi,gramaj,fireMiktari,resim,sil) values('" + txtUrunKod.Text + "','" + txtUrunHiz.Text + "','" + txtGramaj.Text + "','" + txtFileMiktari.Text + "',@image,0) ", conn);
                        insertt.Parameters.Add("@image", SqlDbType.Image, resimm.Length).Value = resimm;
                        insertt.ExecuteNonQuery();

                        SqlCommand ekle = new SqlCommand("insert into urunRapor(urunKod,miktar,boy,adet) values('" +txtUrunKod.Text + "',0,0,0)", veritabani.conn);
                        ekle.ExecuteNonQuery();

                        int[] dizi = new int[listBox1.SelectedItems.Count];
                        int i = 0;
                        foreach (object listItem in listBox1.SelectedItems)
                        {
                            dizi[i++] = Convert.ToInt16(listItem.ToString().Substring(4));
                           


                        }
                        for (i = 0; i < listBox1.SelectedItems.Count; i++)
                        {

                            SqlCommand insertUrunHat = new SqlCommand("insert into urunUretimHatlari(urunKod,HatNo) values('" + txtUrunKod.Text.ToString() + "','" + dizi[i].ToString() + "')", conn);
                            insertUrunHat.ExecuteNonQuery();


                        }

                        

                        MessageBox.Show("Ürün başarıyla eklendi", "Durum", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        txtUrunKod.Text = "";
                        txtUrunHiz.Text = "";
                        txtGramaj.Text = "";
                        txtFileMiktari.Text = "";
                        listBox1.SelectedItems.Clear();

                    }
                    else
                    {
                        MessageBox.Show("Bu kod ile kayıtlı başka bir ürün var!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }

                }
                catch (Exception) {

                    MessageBox.Show("Bir hata oluştu!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                    
                
                
            }
                


        }

        private void txtUrunKod_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if ((e.KeyChar >= (char)48) && (e.KeyChar <= (char)59) || (e.KeyChar == (char)8))
                e.Handled = false;
            else
                e.Handled = true;
            

        }

        private void txtUrunKod_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (txt.Text != null) {
                lblKod.Text = "";
                lblHiz.Text = "";
                lblGramaj.Text = "";
                lblFile.Text = "";
                
                }
                
                
                
          }
        string DosyaAdi = "Resimler";
        string resim = string.Empty;
        private void btnResimSec_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Resim Aç";
            
            
             openFileDialog1.Filter = "Jpeg Dosyası (*.jpg)|*.jpg";
            if (openFileDialog1.ShowDialog() == DialogResult.OK){
                pr.Image = Image.FromFile(openFileDialog1.FileName);
                resim = openFileDialog1.FileName.ToString();
            
            }
        
       



        }
            
            



        
    }
}
