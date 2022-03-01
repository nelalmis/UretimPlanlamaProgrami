using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;

namespace uretimPlanlamaProgrami.RadFormlari
{
    public partial class radOzelSiparisEkle : Telerik.WinControls.UI.RadForm
    {
        public radOzelSiparisEkle()
        {
            InitializeComponent();
        }
        hatalar hata = new hatalar();
        string seciliUrunKod, oncelik;
        int renk, ham;
        float gerekliUrunMiktari;
        private void btnSiparisEkle_Click(object sender, EventArgs e)
        {

        }

        private void cmbUrunKod_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbUrunKod_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBoy_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= (char)48) && (e.KeyChar <= (char)59) || (e.KeyChar == (char)8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void radOzelSiparisEkle_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'genelDataSet.FirmaAdlari' table. You can move, or remove it, as needed.
            this.firmaAdlariTableAdapter.Fill(this.genelDataSet.FirmaAdlari);
            // TODO: This line of code loads data into the 'genelDataSet.renkler' table. You can move, or remove it, as needed.
            fonksiyonComboYapilandirma();
            btnYeniEkle.Enabled = false;
           
          
        }
        public void fonksiyonComboYapilandirma()
        {
            try
            {
                lblSiparisKod.Text = "";
                lblUrunKodu.Text = "";
                lblRenk.Text = "";
                //   lblOncelik.Text = "";
                lblHammadde.Text = "";
                lblFirmaAdi.Text = "";
                lblDurum.Text = "";
                lblBoy.Text = "";
                lblAdet.Text = "";



                this.cmbUrunKod.MultiColumnComboBoxElement.DropDownHeight = 300;
                this.cmbUrunKod.MultiColumnComboBoxElement.DropDownWidth = 500;
                this.cmbRenk.MultiColumnComboBoxElement.DropDownHeight = 300;
                this.cmbRenk.MultiColumnComboBoxElement.DropDownWidth = 200;

                this.cmbHammadde.MultiColumnComboBoxElement.DropDownHeight = 300;
                this.cmbHammadde.MultiColumnComboBoxElement.DropDownWidth = 200;
                //  this.cmbOncelikSirasi.MultiColumnComboBoxElement.DropDownWidth = 200;
                //  this.cmbOncelikSirasi.MultiColumnComboBoxElement.DropDownHeight = 200;

                // this.cmbUrunKod.AutoSizeDropDownToBestFit = true;

                //cmmÜrünler için
                this.cmbUrunKod.AutoFilter = true;
                this.cmbUrunKod.DisplayMember = "UrunKodu";
                FilterDescriptor filter = new FilterDescriptor();
                filter.PropertyName = this.cmbUrunKod.DisplayMember;
                filter.Operator = FilterOperator.Contains;
                this.cmbUrunKod.EditorControl.MasterTemplate.FilterDescriptors.Add(filter);

                this.cmbRenk.AutoFilter = true;
                this.cmbRenk.DisplayMember = "renkAdi";
                FilterDescriptor filter1 = new FilterDescriptor();
                filter1.PropertyName = this.cmbRenk.DisplayMember;
                filter1.Operator = FilterOperator.Contains;
                this.cmbRenk.EditorControl.MasterTemplate.FilterDescriptors.Add(filter1);

                this.cmbHammadde.AutoFilter = true;
                this.cmbHammadde.DisplayMember = "adi";
                FilterDescriptor filter2 = new FilterDescriptor();
                filter2.PropertyName = this.cmbHammadde.DisplayMember;
                filter2.Operator = FilterOperator.Contains;
                this.cmbHammadde.EditorControl.MasterTemplate.FilterDescriptors.Add(filter2);

                // cmbOncelikSirasi.DropDownStyle = RadDropDownStyle.DropDownList;
                // cmbOncelikSirasi.Columns.Add("Öncelik Sırası");
                // cmbOncelikSirasi.Columns[0].Width = 200;

                // RadGridView gridViewControl = this.cmbOncelikSirasi.EditorControl;
                //  gridViewControl.MasterTemplate.AutoGenerateColumns = false;

                // gridViewControl.Rows.Add("Önemsiz");
                // gridViewControl.Rows.Add("Normal");
                // gridViewControl.Rows.Add("Acil");

                this.renklerTableAdapter.Fill(this.genelDataSet.renkler);
                // TODO: This line of code loads data into the 'genelDataSet.hammadde' table. You can move, or remove it, as needed.
                this.hammaddeTableAdapter.Fill(this.genelDataSet.hammadde);
                // TODO: This line of code loads data into the 'genelDataSet.urunler' table. You can move, or remove it, as needed.
                this.urunlerTableAdapter.Fill(this.genelDataSet.urunler);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hata.hataKodu = "radÖzelSiparişEkle-fonksiyonComboYapilandirma";
                hata.hataMesajı = ex.Message;
                hata.hataMesajiKaydet();

            }
        }
        Siparis sp = new Siparis();
        frmSiparisEkle nesne = new frmSiparisEkle();
        private bool fonksiyonTextBoxControl()
        {
            bool tammi = false;

            if (txtSiparisKodu.Text == "")
            {
                lblSiparisKod.Text = "Sipariş kodu boş bırakılamaz!";

            }
            else if (txtFirmaAdi.Text == "")
            {

                lblSiparisKod.Text = "";
                lblFirmaAdi.Text = "Firma adı boş bırakılamaz!";

            }
            else if (cmbUrunKod.SelectedIndex == -1)
            {
                lblSiparisKod.Text = "";
                lblFirmaAdi.Text = "";
                lblUrunKodu.Text = "Ürün kodunu seçiniz!";


            }
            else if (cmbHammadde.SelectedIndex == -1)
            {
                lblSiparisKod.Text = "";
                lblFirmaAdi.Text = "";
                lblUrunKodu.Text = "";
                lblHammadde.Text = "Bir hammadde seçiniz!";
            }

            else if (txtBoy.Text == "")
            {
                lblSiparisKod.Text = "";
                lblFirmaAdi.Text = "";
                lblHammadde.Text = "";
                lblUrunKodu.Text = "";
                lblBoy.Text = "Sipariş Boyunu giriniz!";

            }
            else if (txtAdet.Text == "")
            {

                lblFirmaAdi.Text = "";
                lblHammadde.Text = "";
               
                lblBoy.Text = "";
                lblUrunKodu.Text = "";
                lblAdet.Text = "Sipariş adetini giriniz!";

            }
            else if (cmbRenk.SelectedIndex == -1)
            {
                lblUrunKodu.Text = "";
                lblFirmaAdi.Text = "";
                lblHammadde.Text = "";
                
                lblBoy.Text = "";
                lblAdet.Text = "";
                lblRenk.Text = "Siparişin rengini giriniz!";


            }
            else if (0 != nesne.siparisKodkontrol(txtSiparisKodu.Text))
            {
                
                MessageBox.Show("Girilen sipariş kodu kullanılıyor.Lütfen farklı bir kod giriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                lblRenk.Text = "";

            }
            else
            {
                lblRenk.Text = "";
                tammi = true;

            }
            return tammi;
        }
        frmHatPlanlari frmHatPlanlari;
        private void btnHatPlanlari_Click(object sender, EventArgs e)
        {
           

            if (fonksiyonTextBoxControl() == false)
            {
                lblDurum.BackColor = Color.Red;
                lblDurum.ForeColor = Color.White;
                lblDurum.Text = "Lütfen bilgileri tam doldurun! ";
            }
            else
            {
                try
                {
                    lblDurum.Text = "";
                    lblRenk.Text = "";
                    lblAdet.Text = "";
                    lblBoy.Text = "";
                    lblFirmaAdi.Text = "";
                    lblHammadde.Text = "";
                    lblSiparisKod.Text = "";
                    lblUrunKodu.Text = "";
                    ham = Convert.ToInt16(cmbHammadde.SelectedValue);
                    renk = Convert.ToInt16(cmbRenk.SelectedValue);
                    oncelik = "Ozel";


                    seciliUrunKod = cmbUrunKod.SelectedValue.ToString();
                    float sureDakka, gerekliUrunMiktari;
                    sureDakka = 0.0F;
                    gerekliUrunMiktari = 0.0F;
                    int sureSaniye;
                    int saatTotal;
                    sp.adet = Convert.ToInt64(txtAdet.Text);
                    sp.boy = Convert.ToInt64(txtBoy.Text);
                    SqlCommand sor = new SqlCommand("select * from urunler where kod='" + seciliUrunKod + "'", veritabani.conn);
                    SqlDataReader oku = sor.ExecuteReader();

                    if (oku.Read())
                    {
                        sp.gramaj = Convert.ToInt32(oku["gramaj"]);
                        sp.hiz = Convert.ToInt32(oku["hizi"]);
                        sp.fireMiktari = Convert.ToInt32(oku["fireMiktari"]);

                    }

                    sureDakka = (float)(((sp.boy) / 1000) * sp.adet) / sp.hiz;
                    gerekliUrunMiktari = (float)(sp.gramaj * sp.boy) + ((sp.gramaj * sp.boy) * sp.fireMiktari / 100);
                    sureSaniye = (int)sureDakka * 60;
                    if (sureDakka % 60 == 0)
                        saatTotal = (int)sureDakka / 60;
                    else
                    {
                        saatTotal = (int)(sureDakka + (60 - (sureDakka % 60)));

                        saatTotal = saatTotal / 60;
                    }
                    if (saatTotal == 0)
                        saatTotal = 1;

                    seciliUrunKod = cmbUrunKod.SelectedValue.ToString();
                    if (frmHatPlanlari == null || frmHatPlanlari.IsDisposed)
                    {

                        frmHatPlanlari = new frmHatPlanlari(seciliUrunKod, saatTotal, sp.adet, sp.boy, txtSiparisKodu.Text, txtFirmaAdi.Text, ham, renk, gerekliUrunMiktari);
                        frmHatPlanlari.Show();
                        btnYeniEkle.Enabled = true;
                        btnHatPlanlari.Enabled = false;
                    }
                    else
                        MessageBox.Show("Hat Planları formu açık durumda!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    hata.hataKodu = "radÖzelSiparişEkle-btnHatPlanlari_Click";
                    hata.hataMesajı = ex.Message;
                    hata.hataMesajiKaydet();

                }

            }


        }

        private void radMenuButtonItem1_Click(object sender, EventArgs e)
        {
            btnYeniEkle.Enabled = true;
            
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void pnlSiparisTeslimBilgileri_Paint(object sender, PaintEventArgs e)
        {

        }
       
        public void fonksiyonSiparisEkle(string siparisKodu, string firmaAdi, string seciliUrunKod, string oncelik, long adet, long boy, float gerekliUrunMiktari, int hammadde, int renk, DateTime baslangicTarihi, DateTime sonuc, int topSure, int hatNo, int devamDurumu, DateTime Hesaplanan)
        {
            try
            {
                SqlCommand siparisEkle;
                siparisEkle = new SqlCommand();
                siparisEkle.Connection = veritabani.conn;
                veritabani.baglan();
                DateTime kayitTarihi = DateTime.Now;

                string sadeceTarih = sonuc.ToShortDateString();
                int sadeceSaat = sonuc.Hour;
                siparisEkle.CommandText = "insert into siparis(urunKod,siparisKod,firmaAdi,hammadde,oncelikSirasi,boy,adet,renk,baslangicTarihi,bitisTarihi,toplamSure,gerekenUrunMiktari,siparisBittimi,kullanilacakHat,sil,devamDurumu,bitTarih,bitSaat,kayitTarihi,tatilDahilSure) values(@urunKod,@siparisKod,@firmaAdi,@hammadde,@oncelikSirasi,@boy,@adet,@renk,@baslangicTarihi,@bitisTarihi,@toplamSure,@gerekenUrunMiktari,@siparisBittimi,@kullanilacakHat,@sil,@devamDurumu,@bitTarih,@bitSaat,@kayitTarihi,@tatilDahilSure)";
                siparisEkle.Parameters.Clear();
                siparisEkle.Parameters.AddWithValue("@urunKod", seciliUrunKod);
                siparisEkle.Parameters.AddWithValue("@siparisKod", siparisKodu);
                siparisEkle.Parameters.AddWithValue("@firmaAdi", firmaAdi);
                siparisEkle.Parameters.AddWithValue("@hammadde", hammadde);
                siparisEkle.Parameters.AddWithValue("@oncelikSirasi", oncelik);
                siparisEkle.Parameters.AddWithValue("@boy", boy);
                siparisEkle.Parameters.AddWithValue("@adet", adet);
                siparisEkle.Parameters.AddWithValue("@renk", renk);
                siparisEkle.Parameters.AddWithValue("@baslangicTarihi", baslangicTarihi);
                siparisEkle.Parameters.AddWithValue("@bitisTarihi", sonuc);
                siparisEkle.Parameters.AddWithValue("@toplamSure", topSure);
                siparisEkle.Parameters.AddWithValue("@gerekenUrunMiktari", gerekliUrunMiktari);
                siparisEkle.Parameters.AddWithValue("@siparisBittimi", 0);
                siparisEkle.Parameters.AddWithValue("@kullanilacakHat", hatNo);
                siparisEkle.Parameters.AddWithValue("@sil", 0);
                siparisEkle.Parameters.AddWithValue("@devamDurumu", devamDurumu);
                siparisEkle.Parameters.AddWithValue("@bitTarih", sadeceTarih);
                siparisEkle.Parameters.AddWithValue("@bitSaat", sadeceSaat);
                siparisEkle.Parameters.AddWithValue("@kayitTarihi", kayitTarihi);
                siparisEkle.Parameters.AddWithValue("@tatilDahilSure", Hesaplanan.Subtract(baslangicTarihi).TotalHours);

                siparisEkle.ExecuteNonQuery();
                SqlCommand varmiFirmaAdi = new SqlCommand("select * from FirmaAdlari where firmaAdi='" + firmaAdi.ToUpper() + "'", veritabani.conn);
                SqlDataReader varmiOku = varmiFirmaAdi.ExecuteReader();
                if (!varmiOku.Read())
                {
                    SqlCommand firmaAdiEkle = new SqlCommand("insert into FirmaAdlari(firmaAdi) values('" + firmaAdi.ToUpper() + "')", veritabani.conn);
                    firmaAdiEkle.ExecuteNonQuery();
                }


            }
            catch (Exception ex) {
                
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hata.hataKodu = "radÖzelSiparişEkle-fonksiyonSiparisEkle";
                hata.hataMesajı = ex.Message;
                hata.hataMesajiKaydet();
            
            }



        }

        private void txtSiparisKodu_TextChanged(object sender, EventArgs e)
        {
            if (txtSiparisKodu.Text != "")
            {
                lblSiparisKod.Text = "";
                lblDurum.Text = "";
            }
            
        }
        ses s = new ses();
        private void btnYeniEkle_Click(object sender, EventArgs e)
        {
            if (btnHatPlanlari.Enabled == true)
            {
                s.hata_sesi();
                MessageBox.Show("Yeni Sipariş kaydı zaten açık", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }
            else
            {
                txtSiparisKodu.Text = "";
                txtFirmaAdi.Text = "";
                txtBoy.Text = "";
                txtAdet.Text = "";
                btnYeniEkle.Enabled = false;
                btnHatPlanlari.Enabled = true;
            }
        }
        
    }
}
