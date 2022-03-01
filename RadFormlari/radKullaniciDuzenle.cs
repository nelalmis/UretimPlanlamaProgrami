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
    public partial class radKullaniciDuzenle : Telerik.WinControls.UI.RadForm
    {
        public radKullaniciDuzenle()
        {
            InitializeComponent();
        }

        private void dtKullanici_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {

        }

        private void btnDuzenle_MouseLeave(object sender, EventArgs e)
        {

        }

        private void btnDuzenle_MouseHover(object sender, EventArgs e)
        {

        }

        private void btnSil_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {

        }

        private void radKullaniciDuzenle_Load(object sender, EventArgs e)
        {
            pnlAyrinti.Visible = false;
            lblAd.Text = "";
            lblParola.Text = "";
            lblTur.Text = "";
            groupBox3.Visible = false;
            // TODO: This line of code loads data into the 'genelDataSet.kullanici' table. You can move, or remove it, as needed.
           // this.kullaniciBindingSource.Filter = "uyeTip!=3";
            this.kullaniciTableAdapter.Fill(this.genelDataSet.kullanici);
            veritabani.baglan();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {

        }

        private void btnYeniKayit_Click_1(object sender, EventArgs e)
        {

        }

        private void btnDuzenle_Click_1(object sender, EventArgs e)
        {
            groupBox3.Visible = true;
            radGridView1.Enabled = false;

            btnSil.Enabled = false;
            btnDuzenle.Enabled = false;
            txtAdd.Text = radGridView1.CurrentRow.Cells[1].Value.ToString();
            txtPar.Text = radGridView1.CurrentRow.Cells[2].Value.ToString();
            string tip;
            if (Convert.ToInt16(radGridView1.CurrentRow.Cells[3].Value) == 1)
            {
                tip = "Admin";



            }
            else
                tip = "Normal Kullanıcı";
            if (tip != null)
                comboBox1.SelectedItem = comboBox1.GetItemText(tip.ToString());
        }
        ses s = new ses();
        private void btnSil_Click_1(object sender, EventArgs e)
        {
            int sayi = 0;
            if (radGridView1.CurrentRow.Cells[1].Value.ToString() != null)
            {

                veritabani.baglan();
                if (Convert.ToInt16(radGridView1.CurrentRow.Cells[3].Value) == 1)
                {
                    SqlCommand sorr = new SqlCommand("select count(uyeTip) from kullanici where uyeTip=1", veritabani.conn);
                    sayi = Convert.ToInt16(sorr.ExecuteScalar());
                    if (sayi <= 1)
                    {
                        MessageBox.Show("Bu kayıt silinemez.Programın kullanılabilmesi için en az bir Admin gerekli!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else if ((Convert.ToInt16(radGridView1.CurrentRow.Cells[3].Value) == 2))
                {
                    SqlCommand sorr = new SqlCommand("select count(uyeTip) from kullanici where uyeTip=2", veritabani.conn);
                    sayi = Convert.ToInt16(sorr.ExecuteScalar());
                    if (sayi <= 1)
                    {
                        MessageBox.Show("Bu kayıt silinemez.Programın kullanılabilmesi için en az bir Normal Kullanıcı gerekli!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                }
                DialogResult cevap;
                cevap = MessageBox.Show("Kaydı silmek istediğinizden emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes)
                {
                    SqlCommand sill = new SqlCommand("delete from kullanici where id='" + radGridView1.CurrentRow.Cells[0].Value + "'", veritabani.conn);
                    sill.ExecuteNonQuery();

                    radGridView1.Refresh();
                    radGridView1.Rows.Remove(radGridView1.CurrentRow);
                    s.onay_sesi();
                    MessageBox.Show("Kayıt başarıyla silindi!", "BİLGİ", MessageBoxButtons.OK);

                }
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            if (txtAdd.Text == "" || txtYeniPar.Text == "" || txtyeniParTekrar.Text == "" || comboBox1.SelectedIndex == -1)
            {
                s.hata_sesi();
                MessageBox.Show("Lütfen verileri tam giriniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (txtYeniPar.Text != txtyeniParTekrar.Text)
            {
                s.hata_sesi();
                MessageBox.Show("Parolalar aynı değil.Lütfen kontrol ediniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {

                try
                {
                    veritabani.baglan();

                    SqlCommand sor = new SqlCommand("update  kullanici set kullaniciAdi='" + txtAdd.Text + "',parola='" + txtYeniPar.Text + "',uyeTip='" + (comboBox1.SelectedIndex + 1) + "' where id='" + Convert.ToInt16(radGridView1.CurrentRow.Cells["id"].Value) + "' ", veritabani.conn);
                    sor.ExecuteNonQuery();
                    s.onay_sesi();
                    MessageBox.Show("Kullanıcı başarıyla güncellendi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    groupBox3.Visible = false;
                    radGridView1.Enabled = true;

                    btnSil.Enabled = true;
                    btnDuzenle.Enabled =true;
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
            groupBox3.Visible = false;
            radGridView1.Enabled = true;

            btnSil.Enabled = true;
            btnDuzenle.Enabled = true;
        }

        private void radGridView1_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                pnlAyrinti.Visible = true;
                lblAd.Text = radGridView1.CurrentRow.Cells[1].Value.ToString();
                lblParola.Text = radGridView1.CurrentRow.Cells[2].Value.ToString();
                string tip;
                if (Convert.ToInt16(radGridView1.CurrentRow.Cells[3].Value) == 1)
                {
                    tip = "Admin";



                }
                else
                    tip = "Normal Kullanıcı";
                lblTur.Text = tip;
            }
            catch { }
        }

        private void radGridView1_Click(object sender, EventArgs e)
        {

        }
    }
}
