using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace uretimPlanlamaProgrami.RadFormlari
{
    public partial class radHammaddeDuzenle : Telerik.WinControls.UI.RadForm
    {
        public radHammaddeDuzenle()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSil.Enabled = true;
        }

        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSil_Click_1(object sender, EventArgs e)
        {

        }
        ses s = new ses();
        public void listDoldur()
        {
            veritabani.baglan();
            DataTable table = new DataTable();
            SqlCommand hammadde = new SqlCommand("select id,adi from hammadde", veritabani.conn);
            SqlDataAdapter dp = new SqlDataAdapter(hammadde);
            dp.Fill(table);
            listBox1.DataSource = new BindingSource(table, null);
            listBox1.DisplayMember = "adi";
            listBox1.ValueMember = "id";

        }
        private void radHammaddeDuzenle_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'genelDataSet.hammadde' table. You can move, or remove it, as needed.

            pnlMaddeDetay.Visible = false;
            listDoldur();
            pnlHammaddeDuzenle.Visible = false;
            listBox1.SelectedItems.Clear();

            if (listBox1.SelectedItems.Count == 0)
            {
                btnSil.Enabled = false;

            }
            else
            {

                btnSil.Enabled = true;
            }
        }
        string hammaddeAdi;
        private void btnDuzenle_Click_1(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count == 0)
            {
                s.hata_sesi();
                MessageBox.Show("Bir hammadde seçiniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                s.onay_sesi();
                pnlHammaddeDuzenle.Visible = true;
                txtHammadde.Text = listBox1.GetItemText(listBox1.SelectedItem);
                hammaddeAdi = txtHammadde.Text;
            }

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            veritabani.baglan();
            hammaddeAdi = listBox1.SelectedItem.ToString();
            int id=Convert.ToInt32(listBox1.SelectedValue);
            DialogResult cevap;
            cevap = MessageBox.Show("Seçili hammaddeyi silmek istediğinizden emin misiniz?","UYARI",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes) {
                SqlCommand sor = new SqlCommand("select count(*) from siparis where devamDurumu!=2 and hammadde='"+id+"'",veritabani.conn);
                int sayi = Convert.ToInt32(sor.ExecuteScalar());
                if (sayi == 0)
                {
                    SqlCommand sil = new SqlCommand("delete from hammadde where id='"+id+"'",veritabani.conn);
                    sil.ExecuteNonQuery();
                    listDoldur();
                    MessageBox.Show("Hammadde başarıyla silindi","BİLGİ",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);

                }
                else {
                    MessageBox.Show("Bu hammadde kullanıldığından dolayı silinemedi.","BİLGİ",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                
                }
            
            
            }
            
        }

       

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            bool bilgilerTamMi = true;
            veritabani.baglan();
            if (txtHammadde.Text == "")
            {
                s.hata_sesi();
                MessageBox.Show("Hammadde ismi boş bırakılamaz", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                try
                {
                    SqlCommand sor = new SqlCommand("select count(adi) from hammadde where not exists(select count(adi) from hammadde where adi='" + txtHammadde.Text + "')", veritabani.conn);
                    int sayi = Convert.ToInt16(sor.ExecuteScalar());
                    if (sayi == 0)
                    {
                        SqlCommand ekle = new SqlCommand("update hammadde set adi='" + txtHammadde.Text + "' where adi='" + hammaddeAdi + "' ", veritabani.conn);
                        ekle.ExecuteNonQuery();
                        foreach (Control c in panel1.Controls)
                        {
                            if (c is RadTextBoxControl)
                            {
                                if (c.Text == "")
                                {
                                    bilgilerTamMi = false;
                                    MessageBox.Show("Boş oran bırakılamaz!");
                                    return;


                                }
                            }

                        }
                        if (bilgilerTamMi == true)
                        {
                            foreach (Control c in panel1.Controls)
                            {
                                if (c is RadTextBoxControl)
                                {
                                    int madddeId = Convert.ToInt32(c.Name);
                                    SqlCommand hammaddeIdOgren = new SqlCommand("select id from hammadde where adi='"+txtHammadde.Text+"'", veritabani.conn);
                                    int hammaddeId = Convert.ToInt32(hammaddeIdOgren.ExecuteScalar());

                                    int oran = Convert.ToInt32(c.Text);
                                    SqlCommand hammaddeIcerikEkle = new SqlCommand("insert into hammaddeIcerikTablosu(maddeID,hammaddeID,oranYuzde) values(" + madddeId + "," + hammaddeId + "," + oran + ")", veritabani.conn);
                                    hammaddeIcerikEkle.ExecuteNonQuery();


                                }


                            }


                        }


                        s.onay_sesi();
                        MessageBox.Show("Hammadde başarıyla güncellendi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        txtHammadde.Text = "";
                        groupBox1.Enabled = true;
                        panel1.Controls.Clear();
                        pnlHammaddeDuzenle.Visible = false;
                        listDoldur();
                    }
                    else
                    {
                        s.hata_sesi();
                        MessageBox.Show("Bu hammadde mevcut!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception)
                {
                    s.hata_sesi();
                    MessageBox.Show("Bir hata oluştu!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnPnlKapat_Click(object sender, EventArgs e)
        {
            pnlHammaddeDuzenle.Visible = false;
            groupBox1.Enabled = true;
            panel1.Controls.Clear();
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                veritabani.baglan();
                int id = Convert.ToInt32(listBox1.SelectedValue);
               


                SqlCommand maddelerAl = new SqlCommand("select icerikAdi,i.id from Icerik i,hammaddeIcerikTablosu h where h.maddeID=i.id and h.hammaddeID=" + id + "", veritabani.conn);
                SqlDataAdapter da = new SqlDataAdapter(maddelerAl);
                DataTable ds = new DataTable();
                ///ds.Clear();
                da.Fill(ds);
                listBox2.DataSource = new BindingSource(ds, null);
                listBox2.ValueMember = "id";
                listBox2.DisplayMember = "icerikAdi";
               

                

                btnSil.Enabled = true;
            }
        }
        Hashtable hashMaddeler = new Hashtable();
        private void btnOranBelirle_Click(object sender, EventArgs e)
        {
            btnTemizle.Enabled = true;
            btnTemizle.Visible = true;
            List<int> checkedItems = new List<int>();

            List<string> checkedItemsText = new List<string>();
            checkedItems.Clear();
            checkedItemsText.Clear();
           

            foreach (var item in radCheckedListBox1.CheckedItems)
            {
                hashMaddeler[item.Text.ToString()] = item.Value;
                checkedItems.Add(Convert.ToInt32(item.Value.ToString()));
                checkedItemsText.Add((item.Text.ToString()));
            }
            Label lbl,lblBirim;

            int lblX = 80;
            int lblY = 47;
            int txtX = 180;
            int txtY = 44;
            int lblBirimX = 340;
            int lblBirimY = 47;

            RadTextBoxControl txt;
            foreach (string eleman in checkedItemsText)
            {
                lblBirim = new Label();
                lbl = new Label();
                txt = new RadTextBoxControl();
                lbl.Font.Size.Equals(13);
                lbl.Location = new Point(lblX, lblY);
                lblY += 48;

                lblBirim.Font.Size.Equals(13);
                lblBirim.Location = new Point(lblBirimX, lblBirimY);
                lblBirimY += 48;
                lblBirim.Text = "gr";
                panel1.Controls.Add(lblBirim);

                lbl.Text = eleman.ToString() + " :";
                panel1.Controls.Add(lbl);
                txt.Size = new Size(153, 39);
                txt.NullText = "gram...";
                txt.Font = new Font(txt.Font.FontFamily, 16);
                //txt.MaxLength = 2;


                txt.Name = hashMaddeler[eleman.ToString()].ToString();
                txt.Location = new Point(txtX, txtY);
                txt.KeyPress += new KeyPressEventHandler(txt_KeyPress);
                txtY += 41;
                panel1.Controls.Add(txt);

            }
            btnOranBelirle.Enabled = false;
            radCheckedListBox1.Enabled = false;
            btnTemizle.Enabled = true;
            btnTemizle.Visible = true;
        }
        protected void txt_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ((e.KeyChar >= (char)48) && (e.KeyChar <= (char)59) || (e.KeyChar == (char)8))
                e.Handled = false;
            else
                e.Handled = true;

        }
        private void pnlHammaddeDuzenle_Paint(object sender, PaintEventArgs e)
        {
            groupBox1.Enabled = false;
            groupBox3.Enabled = true;
            
            radCheckedListBox1.Enabled = true;
            btnOranBelirle.Enabled = true;
            btnTemizle.Visible = false;
            int id = Convert.ToInt32(listBox1.SelectedValue);
            
            SqlCommand eklenebilirMaddeler = new SqlCommand("select id,icerikAdi from Icerik where id not in(select i.id from Icerik i,hammaddeIcerikTablosu h where h.maddeID=i.id and h.hammaddeID="+id+")", veritabani.conn);
            SqlDataAdapter da = new SqlDataAdapter(eklenebilirMaddeler);
            DataTable ds = new DataTable();
            ///ds.Clear();
            da.Fill(ds);
            radCheckedListBox1.DataSource = new BindingSource(ds, null);
        }

        
        private void btnIceikSil_Click(object sender, EventArgs e)
        {
            
        }

        private void radCheckedListBox1_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void radCheckedListBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            groupBox6.Enabled = true;
        }

        private void radListView1_Click(object sender, EventArgs e)
        {
            


        }

        private void btnOranGuncelle_Click(object sender, EventArgs e)
        {
            DialogResult cevap = MessageBox.Show("İçerik oranını güncellemek istediğinizden emin misiniz?","UYARI",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes)
            {
                if (txtMaddeOrani.Text != "")
                {
                    veritabani.baglan();
                    int icerikId = Convert.ToInt32(listBox2.SelectedValue);
                    int hammaddeId = Convert.ToInt32(listBox1.SelectedValue);
                    int oran = Convert.ToInt32(txtMaddeOrani.Text);
                    SqlCommand icerikGuncelle = new SqlCommand("update hammaddeIcerikTablosu set oranYuzde=" + oran + " where hammaddeID=" + hammaddeId + " and maddeID=" + icerikId + "", veritabani.conn);
                    icerikGuncelle.ExecuteNonQuery();
                    MessageBox.Show("İçerik oranı başarıyla güncellendi.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    pnlMaddeDetay.Visible = false;
                }
            }
        }

        private void listBox2_Click(object sender, EventArgs e)
        {
            try
            {
                veritabani.baglan();
                pnlMaddeDetay.Visible = true;
                lblMaddeAdi.Text = listBox2.GetItemText(listBox2.SelectedItem);
                int icerikId = Convert.ToInt32(listBox2.SelectedValue);
                int hammaddeId = Convert.ToInt32(listBox1.SelectedValue);

                SqlCommand icerikOranAl = new SqlCommand("select oranYuzde from hammaddeIcerikTablosu where hammaddeID=" + hammaddeId + " and maddeID=" + icerikId + "", veritabani.conn);
                int oran = Convert.ToInt32(icerikOranAl.ExecuteScalar());
                txtMaddeOrani.Text = oran.ToString();
            }
            catch { }
        }
    }
}
