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
    public partial class radHammaddeIcerikDuzenle : Telerik.WinControls.UI.RadForm
    {
        public radHammaddeIcerikDuzenle()
        {
            InitializeComponent();
        }
        string icerikAdi;
        private void btnOranGuncelle_Click(object sender, EventArgs e)
        {

        }

        private void listBox2_Click(object sender, EventArgs e)
        {

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            veritabani.baglan();
            icerikAdi = listBox1.SelectedItem.ToString();
            int id = Convert.ToInt32(listBox1.SelectedValue);
            DialogResult cevap;
            cevap = MessageBox.Show("Seçili İçeriği silmek istediğinizden emin misiniz?", "UYARI", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes)
            {
               
                     SqlCommand hammaddeIcerik = new SqlCommand("delete from hammaddeIcerikTablosu where maddeID="+id+"",veritabani.conn);
                     hammaddeIcerik.ExecuteNonQuery();
                    SqlCommand sil = new SqlCommand("delete from Icerik where id='" + id + "'", veritabani.conn);
                    sil.ExecuteNonQuery();
                    listDoldur();
                    MessageBox.Show("İçerik başarıyla silindi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

               


            }
        }
       
        ses s = new ses();
        private void btnDuzenle_Click_1(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count == 0)
            {
                s.hata_sesi();
                MessageBox.Show("Bir İçerik seçiniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                s.onay_sesi();
                panel1.Visible = true;
                txtAd.Text = listBox1.GetItemText(listBox1.SelectedItem);
                icerikAdi = txtAd.Text;
            }

        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnGuncelle_Click_1(object sender, EventArgs e)
        {
            veritabani.baglan();
            if (txtAd.Text == "")
            {
                s.hata_sesi();
                MessageBox.Show("Hammadde ismi boş bırakılamaz", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                    
                    SqlCommand sor = new SqlCommand("select count(icerikAdi) from Icerik where not exists(select count(icerikAdi) from Icerik where icerikAdi='" + txtAd.Text + "')", veritabani.conn);
                    int sayi = Convert.ToInt16(sor.ExecuteScalar());
                    if (sayi == 0)
                    {
                        SqlCommand ekle = new SqlCommand("update Icerik set icerikAdi='" + txtAd.Text + "' where icerikAdi='" + icerikAdi + "' ", veritabani.conn);
                        ekle.ExecuteNonQuery();
                        s.onay_sesi();
                        listDoldur();
                        MessageBox.Show("Icerik başarıyla güncellendi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        
                        panel1.Visible = false;
                    }
                    else
                    {
                        s.hata_sesi();
                        MessageBox.Show("Bu Icerik mevcut!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void radHammaddeIcerikDuzenle_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            listDoldur();
            if (listBox1.SelectedItems.Count == 0)
            {
                btnSil.Enabled = false;

            }
            else
            {

                btnSil.Enabled = true;
            }
        }
        public void listDoldur()
        {
            veritabani.baglan();
            DataTable table = new DataTable();
            SqlCommand hammadde = new SqlCommand("select id,icerikAdi from Icerik", veritabani.conn);
            SqlDataAdapter dp = new SqlDataAdapter(hammadde);
            dp.Fill(table);
            listBox1.DataSource = new BindingSource(table, null);
            listBox1.DisplayMember = "icerikAdi";
            listBox1.ValueMember = "id";

        }
    }
}
