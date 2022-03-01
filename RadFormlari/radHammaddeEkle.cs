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
    public partial class radHammaddeEkle : Telerik.WinControls.UI.RadForm
    {
        public radHammaddeEkle()
        {
            InitializeComponent();
        }

       

        private void label1_Click(object sender, EventArgs e)
        {

        }
        ses s = new ses();
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (girilen==toplam)
            {
                veritabani.baglan();
                bool bilgilerTamMi = true;
                try
                {
                    SqlCommand ekle = new SqlCommand("insert into hammadde(adi) values('" + txtHammadde.Text + "')", veritabani.conn);
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
                                SqlCommand hammaddeIdOgren = new SqlCommand("select max(id) from hammadde", veritabani.conn);
                                int hammaddeId = Convert.ToInt32(hammaddeIdOgren.ExecuteScalar());

                                int gram = Convert.ToInt32(c.Text);
                                SqlCommand hammaddeIcerikEkle = new SqlCommand("insert into hammaddeIcerikTablosu(maddeID,hammaddeID,gram) values(" + madddeId + "," + hammaddeId + "," + gram + ")", veritabani.conn);
                                hammaddeIcerikEkle.ExecuteNonQuery();


                            }


                        }


                    }


                    s.onay_sesi();
                    btnKaydet.Enabled = false;
                    btnYeniHammadde.Enabled = true;
                    MessageBox.Show("Hammadde başarıyla eklendi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                   
                    txtHammadde.Text = "";

                }
                catch (Exception)
                {
                    s.hata_sesi();
                    MessageBox.Show("Bir hata oluştu!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }else
                MessageBox.Show("Hammadde kayıt işlemi başarısız.Toplam içerik miktarını veya içerik miktarlarını kontrol edip tekrar deneyiniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            
        }

        private void radHammaddeEkle_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'genelDataSet.Icerik' table. You can move, or remove it, as needed.
            pnlDurum.Visible = false;
            this.icerikTableAdapter.Fill(this.genelDataSet.Icerik);
            btnYeniHammadde.Enabled = false;
            btnKaydet.Enabled = true;
            btnTemizle.Visible = false;
           
        }
        Panel pnlToplamMiktarBelirleee;
        RadTextBoxControl txtToplamMiktar;
        public void pnlToplamMiktarDinamikOlustur() {

            pnlToplamMiktarBelirleee = new Panel();
            pnlToplamMiktarBelirleee.Width = 345;
            pnlToplamMiktarBelirleee.Height = 114;
            pnlToplamMiktarBelirleee.Location = new Point(63, 138);
            pnlToplamMiktarBelirleee.Paint += new PaintEventHandler(pnlToplamMiktarBelirlee_Paint);
            pnlToplamMiktarBelirleee.BorderStyle = BorderStyle.Fixed3D;
            pnlToplamMiktarBelirleee.BackColor = Color.White;

            Label lblToplamMiktarr = new Label();
           
            lblToplamMiktarr.Location = new Point(18, 12);
          //  lblToplamMiktar.BackColor = Color.Blue;
            //lblToplamMiktar.ForeColor = Color.White;
            lblToplamMiktarr.Text = "Toplam İçerik Miktarı";
             txtToplamMiktar = new RadTextBoxControl();
            txtToplamMiktar.Width = 310;
            txtToplamMiktar.Height = 36;
            txtToplamMiktar.NullText = "toplam miktar";
            txtToplamMiktar.Location = new Point(27,40);
            txtToplamMiktar.Font = new Font(txtToplamMiktar.Font.FontFamily, 16);
            txtToplamMiktar.KeyPress += new KeyPressEventHandler(txt_KeyPress);

            RadButton btnDevamEt = new RadButton();
            RadButton btnKapat = new RadButton();
            btnDevamEt.Size = new System.Drawing.Size(127, 29);
            btnDevamEt.Text = "Devam Et";
            btnDevamEt.ThemeName = "Breeza";
            btnDevamEt.Location = new Point(205, 77);
            btnDevamEt.Click += new EventHandler(radButton1_Click);

            btnKapat.Size = new System.Drawing.Size(127, 29);
            btnKapat.Text = "Kapat";
            btnKapat.ThemeName = "Breeza";
            btnKapat.Location = new Point(22, 77);
            btnKapat.Click += new EventHandler(radButton2_Click);

            pnlToplamMiktarBelirleee.Controls.Add(btnDevamEt);
            pnlToplamMiktarBelirleee.Controls.Add(btnKapat);
            pnlToplamMiktarBelirleee.Controls.Add(lblToplamMiktarr);
            pnlToplamMiktarBelirleee.Controls.Add(txtToplamMiktar);
            panel1.Controls.Add(pnlToplamMiktarBelirleee);
        } 
            
            
        

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        Hashtable hashMaddeler = new Hashtable();
       
        private void btnOranBelirle_Click(object sender, EventArgs e)
        {
            
            hashMaddeler.Clear();
            veritabani.baglan();
            if (txtHammadde.Text == "")
            {
                s.hata_sesi();
                MessageBox.Show("Hammadde ismi boş bırakılamaz", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (radCheckedListBox1.CheckedItems.Count == 0) {
                MessageBox.Show("En az bir adet içeirk seçmelisiniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
            }

            else
            {

                try
                {
                  
                    SqlCommand sor = new SqlCommand("select count(adi) from hammadde where adi='" + txtHammadde.Text + "'", veritabani.conn);
                    int sayi = Convert.ToInt16(sor.ExecuteScalar());
                    if (sayi == 0)
                    {
                        btnOranBelirle.Enabled = false;
                        pnlToplamMiktarDinamikOlustur();
                       
                        
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
        public void panel1ControlleriDinamikOlustur() {
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
            Label lblBirim;
            Label lbl;
            int lblX = 100;
            int lblY = 37;
            int txtX = 200;
            int txtY = 27;
            int lblBirimX = 380;
            int lblBirimY = 37;

            RadTextBoxControl txt;
            foreach (string eleman in checkedItemsText)
            {
                lblBirim = new Label();
                lbl = new Label();
                txt = new RadTextBoxControl();
                lbl.Font.Size.Equals(13);
                lbl.Location = new Point(lblX, lblY);
                lblY += 48;
                lbl.Text = eleman.ToString() + " :";
                panel1.Controls.Add(lbl);

                lblBirim.Font.Size.Equals(13);
                lblBirim.Location = new Point(lblBirimX, lblBirimY);
                lblBirimY += 48;
                lblBirim.Text = "gr";
                panel1.Controls.Add(lblBirim);

                txt.Size = new Size(153, 42);
                txt.Text = "0";
                txt.Font = new Font(txt.Font.FontFamily, 16);
                txt.MaxLength = toplam.ToString().Length;


                txt.Name = hashMaddeler[eleman.ToString()].ToString();
                txt.Location = new Point(txtX, txtY);
                txt.KeyPress += new KeyPressEventHandler(txt_KeyPress);
                txt.TextChanged += new EventHandler(txtChanged);
                txtY += 48;

                panel1.Controls.Add(txt);

            }
            btnOranBelirle.Enabled = false;
            radCheckedListBox1.Enabled = false;
            btnTemizle.Enabled = true;
            btnTemizle.Visible = true;
        }
       protected void txt_KeyPress(object sender, KeyPressEventArgs e) {
           
           if ((e.KeyChar >= (char)48) && (e.KeyChar <= (char)59) || (e.KeyChar == (char)8))
               e.Handled = false;
           else
               e.Handled = true;
        
        }
        private void btnTemizle_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            btnOranBelirle.Enabled = true;
            radCheckedListBox1.Enabled = true;
            btnTemizle.Visible = false;
            pnlDurum.Visible = false;
            
            lblKalan.Text = "";
        }

        private void btnYeniHammadde_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            btnOranBelirle.Enabled = true;
            radCheckedListBox1.Enabled = true;
            radCheckedListBox1.CheckedItems.Clear();
            btnTemizle.Visible = false;
            btnKaydet.Enabled = true;
            btnYeniHammadde.Enabled = false;
        }

        private void radTextBoxControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= (char)48) && (e.KeyChar <= (char)59) || (e.KeyChar == (char)8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void pnlToplamMiktarBelirlee_Paint(object sender, PaintEventArgs e)
        {
            radCheckedListBox1.Enabled = false;
            btnOranBelirle.Enabled = false;
           
            
            foreach (Control c in panel1.Controls)
            {
                if (c is RadTextBoxControl)
                {
                    c.Enabled = false;
                }
            }
        }
        int toplam;
        private void radButton1_Click(object sender, EventArgs e)
        {


            if (txtToplamMiktar.Text == "" || txtToplamMiktar.Text=="0")
            {
                MessageBox.Show("Toplam içerik miktarı giriniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                
                radCheckedListBox1.Enabled = false;
                btnOranBelirle.Enabled = false;
                pnlMaddeler.Enabled = true;
                foreach (Control c in panel1.Controls)
                {
                    if (c is RadTextBoxControl)
                    {
                        c.Enabled = true;
                    }
                }
                pnlToplamMiktarBelirleee.Visible = false;
                pnlDurum.Visible = true;
                lblKalan.Text = txtToplamMiktar.Text +"/ "+txtToplamMiktar.Text;
              
                toplam = Convert.ToInt32(txtToplamMiktar.Text);
                panel1ControlleriDinamikOlustur();
            }
        }
       
        private void radButton2_Click(object sender, EventArgs e)
        {
            txtToplamMiktar.Text = "";
            panel1.Controls.Clear();
            btnOranBelirle.Enabled = true;
            radCheckedListBox1.Enabled = true;
            btnTemizle.Visible = false;

        }
        int girilen = 0;
        private void txtChanged(object sender, EventArgs e)
        {
            girilen = 0;
            RadTextBoxControl txt = sender as RadTextBoxControl;
            int deger ,kalan= 0;
            foreach (Control c in panel1.Controls)
            {
                if (c is RadTextBoxControl)
                {
                    if (c.Text == "")
                         deger=0;
                    else
                        deger=Convert.ToInt32(c.Text);
                    girilen += deger;
                }
            }

            
            kalan=toplam-girilen;
            if (girilen > toplam) {
                MessageBox.Show("Toplam içerik miktarını aştınız!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                

            }
            else
            lblKalan.Text = kalan.ToString()+"/"+toplam.ToString();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
