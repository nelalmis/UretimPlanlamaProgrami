using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace uretimPlanlamaProgrami
{
    public partial class frmOzelSiparisekle : Form
    {
        public frmOzelSiparisekle()
        {
            InitializeComponent();
        }
        hatalar hata = new hatalar();
        string seciliUrunKod,oncelik;
        int renk, ham;
        float gerekliUrunMiktari;
        private void frmOzelSiparisekle_Load(object sender, EventArgs e)
        {
            hata.hataMesajı = "Sipariş Ekle Formu açılırken beklenmedik bir hata oluştu.";
            try
            {
               // button1.Enabled = false;
                DataTable table = new DataTable();
                DataTable table2 = new DataTable();
                DataTable table3 = new DataTable();
               // pnlSiparisTeslimBilgileri.Visible = false;
                veritabani.baglan();
                SqlCommand urun = new SqlCommand("select id,kod from urunler", veritabani.conn);
                SqlDataAdapter dpUrun = new SqlDataAdapter(urun);
                dpUrun.Fill(table3);
                cmbUrunKodu.DataSource = new BindingSource(table3, null);
                cmbUrunKodu.DisplayMember = "kod";
                cmbUrunKodu.ValueMember = "id";



                SqlCommand hammadde = new SqlCommand("select id,adi from hammadde", veritabani.conn);
                SqlDataAdapter dpp = new SqlDataAdapter(hammadde);
                dpp.Fill(table);
                cmbHammdde.DataSource = new BindingSource(table, null);
                cmbHammdde.DisplayMember = "adi";
                cmbHammdde.ValueMember = "id";


                SqlCommand renk = new SqlCommand("select id,kod,renkAdi from renkler", veritabani.conn);
                SqlDataAdapter dprenk = new SqlDataAdapter(renk);
                dprenk.Fill(table2);
                cmbRenk.DataSource = new BindingSource(table2, null);
                cmbRenk.DisplayMember = "renkAdi";
                cmbRenk.ValueMember = "id";
            }
            catch (Exception)
            {
                MessageBox.Show(hata.hataMesajı, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hata.hataKodu = "frmSiparisEkleLoad";

            }




        }
        Siparis sp = new Siparis();
        frmSiparisEkle nesne = new frmSiparisEkle();
        private void btnHatTablosu_Click(object sender, EventArgs e)
        {
            if (txtSiparisKodu.Text == "") {
                toolTip1.ToolTipIcon = ToolTipIcon.Warning;
                toolTip1.IsBalloon = true;
                toolTip1.Show("Sipariş Kodu boş bırakılamaz!", txtSiparisKodu);
                return;
            }
            else if (txtBoy.Text == "") {
                toolTip1.ToolTipIcon = ToolTipIcon.Warning;
                toolTip1.IsBalloon = true;
                toolTip1.Show("Boy boş bırakılamaz!", txtBoy);
                return;  
            
            }else if(txtAdet.Text==""){
                toolTip1.ToolTipIcon = ToolTipIcon.Warning;
                toolTip1.IsBalloon = true;
                toolTip1.Show("Adet boş bırakılamaz!", txtAdet);
                return;

            }
            else if (0 != nesne.siparisKodkontrol(txtSiparisKodu.Text))
            {
                toolTip1.Dispose();
                MessageBox.Show("Girilen sipariş kodu kullanılıyor.Lütfen farklı bir kod giriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else
            {
                
                    ham = Convert.ToInt16(cmbHammdde.SelectedValue);
                    renk = Convert.ToInt16(cmbRenk.SelectedValue);
                    oncelik = "Ozel";


                seciliUrunKod = cmbUrunKodu.GetItemText(cmbUrunKodu.SelectedItem);
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

                seciliUrunKod = cmbUrunKodu.GetItemText(cmbUrunKodu.SelectedItem);
                frmHatPlanlari frm = new frmHatPlanlari(seciliUrunKod,saatTotal,sp.adet,sp.boy,txtSiparisKodu.Text,txtFirmaAdi.Text,ham,renk,gerekliUrunMiktari);
                frm.Show();
            }



        }


        public void fonksiyonSiparisEkle(string siparisKodu, string firmaAdi, string seciliUrunKod, string oncelik, long adet, long boy, float gerekliUrunMiktari, int hammadde, int renk, DateTime baslangicTarihi, DateTime sonuc, int topSure, int hatNo, int devamDurumu, DateTime Hesaplanan)
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
                siparisEkle.Parameters.AddWithValue("@urunKod",seciliUrunKod);
                siparisEkle.Parameters.AddWithValue("@siparisKod",siparisKodu);
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
                /*
                lblHatNo.Text = hatNo.ToString();
                lblKayitTarihi.Text = "" + String.Format("{0:f}", DateTime.Now);
                lblBasTarihi.Text = "" + String.Format("{0:f}", baslangicTarihi);
                lblBitTarihi.Text = "" + String.Format("{0:f}", Hesaplanan);

                lblTopSure.Text = "" + String.Format("{0:0,0}", Hesaplanan.Subtract(baslangicTarihi).TotalHours) + " SAAT";
                lblBoyPanel.Text = "" + String.Format("{0:0,0}", sp.boy) + " milimetre";
                lblAdetPanel.Text = "" + String.Format("{0:0,0}", adet);
                lblBitTarihi.Text = sonuc.ToString();

                lblGerekliSure.Text = "" + String.Format("{0:0,0}", topSure) + " SAAT";
                lblHammaddePanel.Text = cmbHammadde.GetItemText(cmbHammadde.SelectedItem);
                lblRenkPanel.Text = cmbRenk.GetItemText(cmbRenk.SelectedItem);
                lblTopMiktar.Text = gerekliUrunMiktari.ToString() + " GRAM" + "  ==" + (gerekliUrunMiktari / 1000) + " KG";
                */
                // btnSiparisEkle.Enabled = false;

            

        }

    }
}
