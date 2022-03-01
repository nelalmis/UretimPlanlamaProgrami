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
    public partial class frmKullaniciDuzenle : Form
    {
        public frmKullaniciDuzenle()
        {
            InitializeComponent();
        }
        ses s = new ses();
        private void btnKulEkle_Click(object sender, EventArgs e)
        {

        }

        private void frmKullaniciDuzenle_Load(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            dataGridDoldur();

           
        }

        private void dtKullanici_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           


        }
        public void dataGridDoldur() {
            veritabani.baglan();
            SqlCommand ara = new SqlCommand("select * from kullanici", veritabani.conn);
            SqlDataAdapter da = new SqlDataAdapter(ara);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dtKullanici.DataSource = dt;
            dtKullanici.Columns["id"].Visible = false;
            veritabani.baglantiyiKes();
        
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            dtKullanici.Enabled = false;

            btnSil.Enabled = false;
            btnDuzenle.Enabled = false;
            txtAdd.Text = dtKullanici.CurrentRow.Cells[1].Value.ToString();
            txtPar.Text = dtKullanici.CurrentRow.Cells[2].Value.ToString();
            string tip;
            if (Convert.ToInt16(dtKullanici.CurrentRow.Cells[3].Value) == 1)
            {
                tip = "Admin";



            }
            else
                tip = "Normal Kullanıcı";
            if (tip != null)
                cmbTur.SelectedItem = cmbTur.GetItemText(tip.ToString());

        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            btnDuzenle.Enabled = true;
            btnSil.Enabled = true;
            dtKullanici.Enabled = true;
                
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (txtAdd.Text == "" || txtYeniPar.Text == "" || txtyeniParTekrar.Text == "" || cmbTur.SelectedIndex == -1)
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
            else {

                try
                {
                    veritabani.baglan();

                    SqlCommand sor = new SqlCommand("update  kullanici set kullaniciAdi='" + txtAdd.Text + "',parola='" + txtYeniPar.Text + "',uyeTip='" + (cmbTur.SelectedIndex + 1) + "' where id='" + Convert.ToInt16(dtKullanici.CurrentRow.Cells["id"].Value) + "' ", veritabani.conn);
                    sor.ExecuteNonQuery();
                    s.onay_sesi();
                    MessageBox.Show("Kullanıcı başarıyla güncellendi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    dataGridDoldur();

                }
                catch (Exception)
                {
                    s.hata_sesi();
                    MessageBox.Show("Bir hata oluştu!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
            }


        }

        private void btnDuzenle_MouseHover(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.Teal;
           
        }

        private void btnDuzenle_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.White;

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int sayi=0;
            if (dtKullanici.CurrentRow.Cells[1].Value.ToString()!=null)
            {
                
                veritabani.baglan();
                if (Convert.ToInt16(dtKullanici.CurrentRow.Cells[3].Value) == 1)
                {
                    SqlCommand sorr = new SqlCommand("select count(uyeTip) from kullanici where uyeTip=1", veritabani.conn);
                    sayi = Convert.ToInt16(sorr.ExecuteScalar());
                    if (sayi <= 1)
                    {
                        MessageBox.Show("Bu kayıt silinemez.Programın kullanılabilmesi için en az bir Admin gerekli!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }else if((Convert.ToInt16(dtKullanici.CurrentRow.Cells[3].Value) == 2)){
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
                    SqlCommand sill = new SqlCommand("delete from kullanici where id='" + dtKullanici.CurrentRow.Cells[0].Value + "'", veritabani.conn);
                    sill.ExecuteNonQuery();

                    dataGridDoldur();
                    s.onay_sesi();
                    MessageBox.Show("Kayıt başarıyla silindi!", "BİLGİ", MessageBoxButtons.OK);

                }
            }
        }
    }
}
