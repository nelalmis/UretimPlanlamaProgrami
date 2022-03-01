using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Documents;
using System.Windows.Forms;
using Telerik.WinControls;

namespace uretimPlanlamaProgrami.RadFormlari
{
    public partial class radUrunEkle : Telerik.WinControls.UI.RadForm
    {
        public radUrunEkle()
        {
            InitializeComponent();
        }

        private void btnResimSec_Click(object sender, EventArgs e)
        {

        }

        private void txtUrunKod_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUrunKod_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnUrunEkle_Click(object sender, EventArgs e)
        {

        }
        string resim = string.Empty;
        private void btnResimSec_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Resim Aç";


            openFileDialog1.Filter = "Jpeg Dosyası (*.jpg)|*.jpg";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pr.Image = Image.FromFile(openFileDialog1.FileName);
                resim = openFileDialog1.FileName.ToString();

            }
        }

        private void btnUrunEkle_Click_1(object sender, EventArgs e)
        {
            veritabani.baglan();
            if (txtKod.Text == "")
            {
                lblKod.ForeColor = Color.Red;
                lblKod.Text = "Ürün kodu boş geçilemez!";
            }
            else if (txtHiz.Text == "")
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
            else if (txtFireMiktari.Text == "")
            {
                lblFile.ForeColor = Color.Red;
                lblFile.Text = "File Miktarı boş geçilemez!";
                lblHiz.Text = "";
                lblKod.Text = "";
                lblFile.Text = "";
            }
            else if (radCheckedListBox1.CheckedItems.Count == 0)
            {
                MessageBox.Show("En az bir adet hat seçmelisiniz!");

            }else if(pr.Image==null){

                MessageBox.Show("Ürün resmini seçiniz!");
            
            }
                
            else
            {
               
                    int sayi = 0;

                    SqlCommand sor = new SqlCommand("select count(kod) from urunler where kod='" + txtKod.Text + "'", veritabani.conn);
                    sayi = Convert.ToInt32(sor.ExecuteScalar());
                    if (sayi == 0)
                    {

                        FileStream fs = new FileStream(resim, FileMode.Open, FileAccess.Read);
                        BinaryReader br = new BinaryReader(fs);

                        byte[] resimm = br.ReadBytes((int)fs.Length);

                        br.Close();

                        fs.Close();
                        SqlCommand insertt = new SqlCommand("insert into urunler(kod,hizi,gramaj,fireMiktari,resim,sil) values('" + txtKod.Text + "','" + txtHiz.Text + "','" + txtGramaj.Text + "','" + txtFireMiktari.Text + "',@image,0) ", veritabani.conn);
                        insertt.Parameters.Add("@image", SqlDbType.Image, resimm.Length).Value = resimm;
                        insertt.ExecuteNonQuery();

                        SqlCommand ekle = new SqlCommand("insert into urunRapor(urunKod,miktar,boy,adet) values('" + txtKod.Text + "',0,0,0)", veritabani.conn);
                        ekle.ExecuteNonQuery();

                        List<int> checkedItems = new List<int>();
                        int[] dizi = new int[radCheckedListBox1.CheckedItems.Count];
                       

                        foreach (var item in radCheckedListBox1.CheckedItems)
                            checkedItems.Add(Convert.ToInt32(item.Value.ToString().Substring(4)));


                        //foreach (DataRowView chcList in radCheckedListBox1.CheckedItems)
                        //{
                           
                        //    dizi[i++] = Convert.ToInt16(chcList.DataView);
                        //}
                        

                        //foreach (object listItem in listBox1.SelectedItems)
                        //{
                        //    dizi[i++] = Convert.ToInt16(listItem.ToString().Substring(4));



                        //}
                        foreach (int eleman in checkedItems)
                        {

                           // MessageBox.Show(eleman.ToString());

                            SqlCommand insertUrunHat = new SqlCommand("insert into urunUretimHatlari(urunKod,HatNo) values('" + txtKod.Text.ToString() + "','" + eleman+ "')", veritabani.conn);
                            insertUrunHat.ExecuteNonQuery();
                        }

                        



                        MessageBox.Show("Ürün başarıyla eklendi", "Durum", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        txtKod.Text = "";
                        txtHiz.Text = "";
                        txtGramaj.Text = "";
                        txtFireMiktari.Text = "";
                        radCheckedListBox1.CheckedItems.Clear();
                        pr.Image = null;
                        //listBox1.SelectedItems.Clear();

                    }
                    else
                    {
                        MessageBox.Show("Bu kod ile kayıtlı başka bir ürün var!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }

               


            }
                
        }

        private void radUrunEkle_Load(object sender, EventArgs e)
        {
            veritabani.baglan();

            radCheckedListBox1.CheckedItems.Clear();
            SqlCommand hatlar = new SqlCommand("select numara from uretimHatti", veritabani.conn);
            SqlDataReader hatOku = hatlar.ExecuteReader();
            SqlCommand hatSayi = new SqlCommand("select count(numara)  from uretimHatti", veritabani.conn);
            int sayi = Convert.ToInt16(hatSayi.ExecuteScalar());

            lblFile.Text = "";
            lblHiz.Text = "";
            lblKod.Text = "";
            lblGramaj.Text = "";


            while (hatOku.Read())
            {
                //listBox1.Items.Add("hat-" + hatOku["numara"].ToString());
                radCheckedListBox1.Items.Add("HAT-" + hatOku["numara"].ToString());

            }
            radCheckedListBox1.ValueMember = "numara";
        }

        private void txtHiz_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (sender) as TextBox;
            if ((e.KeyChar >= (char)48) && (e.KeyChar <= (char)59) || (e.KeyChar == (char)8))
                e.Handled = false;
            else
                e.Handled = true;
            
            
        }
    }
}
