using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Data;
using Telerik.WinControls.Keyboard;
using Telerik.WinControls.UI;

namespace uretimPlanlamaProgrami.RadFormlari
{
    public partial class radSiparisDuzenleButonFormu : Telerik.WinControls.UI.RadForm 
    {
        string siparisKod, urunKod, firmaAdi, hammadde, renk, oncelik,devamDurumu;
        int toplamSaat, hammaddeId, renkId, hatNo;
        float gerekenUrunMiktari;
        long boy, adet;
        DateTime bas, bit;
        
        public radSiparisDuzenleButonFormu(string siparisKod,string urunKod,string firmaAdi,string hammadde,string renk,long boy,long adet,string oncelik,DateTime bas,DateTime bit,int toplamSaat,int hatNo,float gerekenUrunMiktari,string devamDurumu)
        {
           
            this.siparisKod = siparisKod;
            this.urunKod = urunKod;
            this.firmaAdi = firmaAdi;
            this.hammadde = hammadde;
            this.renk = hammadde;
            this.boy = boy;
            this.adet = adet;
            this.oncelik = oncelik;
            this.bas = bas;
            this.bit = bit;
            this.toplamSaat = toplamSaat;
            this.hatNo = hatNo;
            this.gerekenUrunMiktari = gerekenUrunMiktari;
            this.devamDurumu = devamDurumu;
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtSiparisKodu2.Visible = true;
            txtSiparisKodu2.Text = txtSiparisKodu.Text;
            button1.Visible = true;
            btnSipKaydet.Visible = true;

        }
        DateTime geciciBas ;
        DateTime geciciBit;
        private void radSiparisDuzenleButonFormu_Load(object sender, EventArgs e)
        {
            try
            {
                linkLabel8.Visible = false;
                this.cmbUrunler.AutoFilter = true;
                this.cmbUrunler.DisplayMember = "UrunKodu";
                FilterDescriptor filter = new FilterDescriptor();
                filter.PropertyName = this.cmbUrunler.DisplayMember;
                filter.Operator = FilterOperator.Contains;
                this.cmbUrunler.EditorControl.MasterTemplate.FilterDescriptors.Add(filter);

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

                cmbOncelik.DropDownStyle = RadDropDownStyle.DropDownList;
                cmbOncelik.Columns.Add("Öncelik Sırası");
                cmbOncelik.Columns[0].Width = 200;

                RadGridView gridViewControl = this.cmbOncelik.EditorControl;
                gridViewControl.MasterTemplate.AutoGenerateColumns = false;


                gridViewControl.Rows.Add("Acil");
                gridViewControl.Rows.Add("Önemsiz");
                gridViewControl.Rows.Add("Normal");
                txtSiparisKodu.Text = siparisKod;
                txtUrunKod.Text = urunKod;
                txtFirmaAdi.Text = firmaAdi;
                txtBoy.Text = boy.ToString();
                txtAdet.Text = adet.ToString();
                txtHammadde.Text = hammadde;
                txtOncelik.Text = oncelik;
                txtRenk.Text = renk;
                txtBasTar.Text = bas.ToShortDateString();
                txtBasSaat.Text = bas.Hour.ToString();
                txtBitTar.Text = bit.ToShortDateString();
                txtBitSaat.Text = bit.Hour.ToString();
                txtToplamSaat.Text = toplamSaat.ToString();

                this.urunlerTableAdapter.Fill(this.genelDataSet.urunler);
                this.renklerTableAdapter.Fill(this.genelDataSet.renkler);
                this.hammaddeTableAdapter.Fill(this.genelDataSet.hammadde);
                txtSiparisKodu2.Visible = false;
                txtFirmaAdi2.Visible = false;
                txtBoy2.Visible = false;
                txtAdet2.Visible = false;
                cmbHammadde.Visible = false;
                cmbRenk.Visible = false;
                cmbUrunler.Visible = false;
                cmbOncelik.Visible = false;
                btnAdKayde.Visible = false;
                btnBoyKaydet.Visible = false;
                btnFirmaKaydet.Visible = false;
                btnHamKayd.Visible = false;
                btnOnKayde.Visible = false;
                btnReKayde.Visible = false;
                btnSipKaydet.Visible = false;
                btnUrKaydet.Visible = false;
                btnNumeric.Visible = false;
                numericUpDown1.Visible = false;

                foreach (Control btn in groupBox1.Controls)
                {
                    if (btn is Button)
                        btn.Visible = false;

                }

                geciciBas = bas;
                geciciBit = bit;
                veritabani.baglan();
                SqlCommand renkAl = new SqlCommand("select id from renkler where renkAdi='" + renk + "'", veritabani.conn);
                SqlDataReader renkOku = renkAl.ExecuteReader();
                if (renkOku.Read())
                    renkId = Convert.ToInt32(renkOku["id"]);

                SqlCommand hammaddeAl = new SqlCommand("select id from hammadde where adi='" + hammadde + "'", veritabani.conn);
                SqlDataReader hamOku = hammaddeAl.ExecuteReader();
                if (hamOku.Read())
                    hammaddeId = Convert.ToInt32(hamOku["id"]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hata.hataMesajı = ex.Message;
                hata.hataKodu = "radSiparisDuzenleButonFormu-radSiparisDuzenleButonFormu_Load";
                hata.hataMesajiKaydet();
            }
        }

        private void btnPanelKaydet_Click(object sender, EventArgs e)
        {
            
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            button2.Visible = true;
            btnUrKaydet.Visible = true;
            cmbUrunler.SelectedValue = urunKod;
            cmbUrunler.Visible = true;
        }

        private void txtSiparisKodu2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            button3.Visible = true;
            btnFirmaKaydet.Visible = true;
            txtFirmaAdi2.Visible = true;
            txtFirmaAdi2.Text = txtFirmaAdi.Text;

        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            button4.Visible = true;
            btnHamKayd.Visible = true;
            cmbHammadde.SelectedValue = hammaddeId;
            cmbHammadde.Visible = true;
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            button5.Visible = true;
            btnReKayde.Visible = true;
            cmbRenk.SelectedValue = renkId;
            cmbRenk.Visible = true;
        }
        Siparis sp = new Siparis();
        float sureDakka;
        int saatTotal;
        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {



            button6.Visible = true;
            btnBoyKaydet.Visible = true;
            txtBoy2.Visible = true;
            txtBoy2.Text = txtBoy.Text;

            
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            button7.Visible = true;
            btnAdKayde.Visible = true;
            txtAdet2.Visible = true;
            txtAdet2.Text = txtAdet.Text;
        }

        private void btnSipKaydet_Click(object sender, EventArgs e)
        {
            txtSiparisKodu.Text = txtSiparisKodu2.Text;
            txtSiparisKodu2.Visible = false;
            btnSipKaydet.Visible = false;
            button1.Visible = false;
        }

        private void btnUrKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                txtUrunKod.Text = cmbUrunler.SelectedValue.ToString();
                cmbUrunler.Visible = false;
                btnUrKaydet.Visible = false;
                button2.Visible = false;
                int sureSaniye;
                sp.adet = Convert.ToInt64(txtAdet.Text);
                sp.boy = Convert.ToInt64(txtBoy.Text);
                SqlCommand sor = new SqlCommand("select * from urunler where kod='" + txtUrunKod.Text + "'", veritabani.conn);
                SqlDataReader oku = sor.ExecuteReader();

                if (oku.Read())
                {
                    sp.gramaj = Convert.ToInt32(oku["gramaj"]);
                    sp.hiz = Convert.ToInt32(oku["hizi"]);
                    sp.fireMiktari = Convert.ToInt32(oku["fireMiktari"]);

                }

                sureDakka = (float)(((sp.boy) / 1000) * sp.adet) / sp.adet;
                gerekenUrunMiktari = (float)(sp.gramaj * sp.boy) + ((sp.gramaj * sp.boy) * sp.fireMiktari / 100);
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

                txtToplamSaat.Text = saatTotal.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hata.hataMesajı = ex.Message;
                hata.hataKodu = "radSiparisDuzenleButonFormu-btnUrKaydet_Click";
                hata.hataMesajiKaydet();
            }
        }

        private void btnFirmaKaydet_Click(object sender, EventArgs e)
        {
            txtFirmaAdi.Text = txtFirmaAdi2.Text;
            txtFirmaAdi2.Visible = false;
            btnFirmaKaydet.Visible = false;
            button3.Visible = false;
        }

        private void btnHamKayd_Click(object sender, EventArgs e)
        {
            hammaddeId =Convert.ToInt32( cmbHammadde.SelectedValue);
            txtHammadde.Text = cmbHammadde.GetPlainText();
            cmbHammadde.Visible = false;
            btnHamKayd.Visible = false;
            button4.Visible = false;
        }

        private void btnReKayde_Click(object sender, EventArgs e)
        {
            renkId = Convert.ToInt32(cmbRenk.SelectedValue);
            txtRenk.Text = cmbRenk.GetPlainText();
            cmbRenk.Visible = false;
            btnReKayde.Visible = false;
            button5.Visible = false;
        }

       
        private void btnBoyKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                int sureSaniye = 0;
                txtBoy.Text = txtBoy2.Text;
                txtBoy2.Visible = false;
                btnBoyKaydet.Visible = false;
                button6.Visible = false;
                sp.adet = Convert.ToInt64(txtAdet.Text);
                sp.boy = Convert.ToInt64(txtBoy.Text);
                SqlCommand sor = new SqlCommand("select * from urunler where kod='" + txtUrunKod.Text + "'", veritabani.conn);
                SqlDataReader oku = sor.ExecuteReader();

                if (oku.Read())
                {
                    sp.gramaj = Convert.ToInt32(oku["gramaj"]);
                    sp.hiz = Convert.ToInt32(oku["hizi"]);
                    sp.fireMiktari = Convert.ToInt32(oku["fireMiktari"]);

                }

                sureDakka = (float)(((sp.boy) / 1000) * sp.adet) / sp.adet;
                gerekenUrunMiktari = (float)(sp.gramaj * sp.boy) + ((sp.gramaj * sp.boy) * sp.fireMiktari / 100);
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

                txtToplamSaat.Text = saatTotal.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hata.hataMesajı = ex.Message;
                hata.hataKodu = "radSiparisDuzenleButonFormu-btnBoyKaydet_Click";
                hata.hataMesajiKaydet();
            }
        }

        private void btnAdKayde_Click(object sender, EventArgs e)
        {
            try
            {
                int sureSaniye;
                txtAdet.Text = txtAdet2.Text;
                txtAdet2.Visible = false;
                btnAdKayde.Visible = false;
                button7.Visible = false;
                sp.adet = Convert.ToInt64(txtAdet.Text);
                sp.boy = Convert.ToInt64(txtBoy.Text);
                SqlCommand sor = new SqlCommand("select * from urunler where kod='" + txtUrunKod.Text + "'", veritabani.conn);
                SqlDataReader oku = sor.ExecuteReader();

                if (oku.Read())
                {
                    sp.gramaj = Convert.ToInt32(oku["gramaj"]);
                    sp.hiz = Convert.ToInt32(oku["hizi"]);
                    sp.fireMiktari = Convert.ToInt32(oku["fireMiktari"]);

                }

                sureDakka = (float)(((sp.boy) / 1000) * sp.adet) / sp.hiz;
                gerekenUrunMiktari = (float)(sp.gramaj * sp.boy) + ((sp.gramaj * sp.boy) * sp.fireMiktari / 100);
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
                txtToplamSaat.Text = saatTotal.ToString();
            }catch(Exception ex){
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hata.hataMesajı = ex.Message;
                hata.hataKodu = "radSiparisDuzenleButonFormu-btnAdKayde_Click";
                hata.hataMesajiKaydet();
            }
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            button8.Visible = true;
            btnOnKayde.Visible = true;
            cmbOncelik.SelectedValue = txtOncelik.Text;
            cmbOncelik.Visible = true;
        }

        private void btnOnKayde_Click(object sender, EventArgs e)
        {
            txtOncelik.Text = cmbOncelik.GetPlainText();
            cmbOncelik.Visible = false;
            btnOnKayde.Visible = false;
            button8.Visible = false;
        }

        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            button9.Visible = true;
            numericUpDown1.Value = Convert.ToInt32( txtToplamSaat.Text);
            numericUpDown1.Visible = true;
            btnNumeric.Visible = true;
          
        }
        hatalar hata;
        radNormalSiparisEkle nesne=new radNormalSiparisEkle();
        private void btnNumeric_Click(object sender, EventArgs e)
        {
            veritabani.baglan();
            btnNumeric.Visible = false;
            numericUpDown1.Visible=false;
            button9.Visible = false;
            txtToplamSaat.Text = numericUpDown1.Value.ToString();

            //geciciBit=nesne.fonksiyonTatilGunuVarsaGec(bas,Convert.ToInt32(numericUpDown1.Value));
            geciciBit = fonksiyon.fonksiyonSiparisBitisTarihiBul(bas, Convert.ToInt32(numericUpDown1.Value));
            txtBitTar.Text = geciciBit.ToShortDateString();
            txtBitSaat.Text = geciciBit.Hour.ToString();
        }
        
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
           

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {



        }
        ses s = new ses();
        radSiparisDuzenle sipDuzNesne = new radSiparisDuzenle();
        Fonksiyonlar fonksiyon = new Fonksiyonlar();
        private void btnDegisikleriKaydet_Click(object sender, EventArgs e)

        {
            //ÜRÜNKODU  BOY    ADET    TOPLAMSAAT   ÖNCELİK SIRASI


            //SadeceToplam Saat
            try
            {
                DialogResult cevap = MessageBox.Show("Değişiklikler kaydedilecek.", "UYARI", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (cevap == DialogResult.Yes)
                {
                    if (txtUrunKod.Text != urunKod && txtToplamSaat.Text == toplamSaat.ToString())
                    {
                        SqlCommand hatNoAl = new SqlCommand("select * from urunUretimHatlari where HatNo='" + hatNo + "'and urunKod='" + txtUrunKod.Text + "' ", veritabani.conn);
                        SqlDataReader hatNoOku = hatNoAl.ExecuteReader();
                        if (hatNoOku.Read())
                        {
                            SqlCommand sonrakiKodal = new SqlCommand("select * from siparis where siparisKod='" + siparisKod + "'", veritabani.conn);
                            SqlDataReader sonrakiOku = sonrakiKodal.ExecuteReader();
                            string sonrakiSiparisKodu = "";
                            if (sonrakiOku.Read())
                            {
                                sonrakiSiparisKodu = sonrakiOku["sonrakiSiparisKodu"].ToString();

                            }
                            fonksiyonSiparisGuncelle(hatNo, gerekenUrunMiktari);

                           // DateTime bitisTarihi = nesne.fonksiyonTatilGunuVarsaGec(bas, Convert.ToInt32(txtToplamSaat.Text));
                            DateTime bitisTarihi = fonksiyon.fonksiyonSiparisBitisTarihiBul(bas, Convert.ToInt32(txtToplamSaat.Text));
                            fonksiyon.fonksiyonHatBitisTarihiGuncelle(bitisTarihi, hatNo, txtSiparisKodu.Text);

                            //SqlCommand HatBitisTarihGuncelle = new SqlCommand();
                            //HatBitisTarihGuncelle.Connection = veritabani.conn;
                            //HatBitisTarihGuncelle.CommandText = "update hatBitisTarih set bitisTarihi=@bitisTarihi,tarih=@tarih,saat=@saat where siparisKodu=@siparisKodu";
                            //HatBitisTarihGuncelle.Parameters.Clear();
                            //HatBitisTarihGuncelle.Parameters.AddWithValue("@bitisTarihi", bitisTarihi);
                            //HatBitisTarihGuncelle.Parameters.AddWithValue("@tarih", bitisTarihi.ToShortDateString());
                            //HatBitisTarihGuncelle.Parameters.AddWithValue("@saat", bitisTarihi.Hour);
                            //HatBitisTarihGuncelle.Parameters.AddWithValue("@siparisKodu", txtSiparisKodu.Text);
                            //HatBitisTarihGuncelle.ExecuteNonQuery();

                            fonksiyon.fonksiyonSonrakiSiparisleriGuncelle(txtSiparisKodu.Text,txtUrunKod.Text,sonrakiSiparisKodu,bitisTarihi,hatNo);
                            //fonksiyonSonrakiSiparisGuncelle(sonrakiSiparisKodu, txtSiparisKodu.Text, txtUrunKod.Text, bitisTarihi);



                            //ertelecnek yada öne alınacak
                            nesneRadSiparisDuzenleFormu.gridYenile();

                        }
                        else
                        {
                            MessageBox.Show("Bu Ürün Kodu ile önceden belirlenen Hat uygun olmadığı için siparişi silip tekrar eklemeniz önerilir.", "UYARI", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                        }


                    }

                    else if (txtToplamSaat.Text != toplamSaat.ToString())
                    {

                        fonksiyonSiparisGuncelle(hatNo, gerekenUrunMiktari);
                        SqlCommand sonrakiVarmi = new SqlCommand("select * from siparis where siparisKod='" + txtSiparisKodu.Text + "'", veritabani.conn);
                        SqlDataReader sonrakiOku = sonrakiVarmi.ExecuteReader();
                        if (sonrakiOku.Read())
                        {
                            if (sonrakiOku["sonrakiSiparisKodu"].ToString() != "")
                            {
                                SqlCommand oncekiSiparis = new SqlCommand("update siparis set sonrakiSiparisKodu='" + txtSiparisKodu.Text + "' where sonrakiSiparisKodu='" + siparisKod + "'", veritabani.conn);
                                oncekiSiparis.ExecuteNonQuery();
                                fonksiyonSonrakiSiparisGuncelle(sonrakiOku["sonrakiSiparisKodu"].ToString(), txtSiparisKodu.Text, txtUrunKod.Text, sonuc);


                            }
                            else
                            {
                                SqlCommand HatBitisTarihGuncelle = new SqlCommand();
                                HatBitisTarihGuncelle.Connection = veritabani.conn;
                                HatBitisTarihGuncelle.CommandText = "update hatBitisTarih set bitisTarihi=@bitisTarihi,tarih=@tarih,saat=@saat where siparisKodu=@siparisKodu";
                                HatBitisTarihGuncelle.Parameters.Clear();
                                HatBitisTarihGuncelle.Parameters.AddWithValue("@bitisTarihi", sonuc);
                                HatBitisTarihGuncelle.Parameters.AddWithValue("@tarih", sonuc.ToShortDateString());
                                HatBitisTarihGuncelle.Parameters.AddWithValue("@saat", sonuc.Hour);
                                HatBitisTarihGuncelle.Parameters.AddWithValue("@siparisKodu", txtSiparisKodu.Text);
                                HatBitisTarihGuncelle.ExecuteNonQuery();


                            }

                        }

                        nesneRadSiparisDuzenleFormu.gridYenile();
                        s.onay_sesi();
                        MessageBox.Show("Sipariş günceleme başarılı!", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    }



                }
            }catch(Exception ex){
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hata.hataMesajı = ex.Message;
                hata.hataKodu = "radSiparisDuzenleButonFormu-btnDegisikleriKaydet_Click";
                hata.hataMesajiKaydet();
            
            }

        }
       
        private void btnKaydetmedenCik_Click(object sender, EventArgs e)
        {
            s.onay_sesi();
            DialogResult cevap = MessageBox.Show("Değişiklikler kaydedilmeyecek! Çıkmak istediğinizden emin misiniz?","UYARI",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes)
                this.Close();
               
            
        }
        DateTime sonuc;
        public void fonksiyonSiparisGuncelle(int hatNo,float gerekenUrunMiktari)
        {
            try
            {
                DateTime baslangicTarihi = Convert.ToDateTime(txtBasTar.Text);
                sonuc = Convert.ToDateTime(txtBitTar.Text);
                int yy, MM, dd, hh;
                yy = baslangicTarihi.Year;
                MM = baslangicTarihi.Month;
                dd = baslangicTarihi.Day;
                hh = Convert.ToInt32(txtBasSaat.Text);
                baslangicTarihi = new DateTime(yy, MM, dd, hh, 0, 0);
                yy = sonuc.Year;
                MM = sonuc.Month;
                dd = sonuc.Day;
                hh = Convert.ToInt32(txtBitSaat.Text);
                sonuc = new DateTime(yy, MM, dd, hh, 0, 0);

                SqlCommand siparisEkle;
                siparisEkle = new SqlCommand();
                siparisEkle.Connection = veritabani.conn;
                veritabani.baglan();
                DateTime kayitTarihi = DateTime.Now;

                string sadeceTarih = sonuc.ToShortDateString();
                int sadeceSaat = sonuc.Hour;
                siparisEkle.CommandText = "update siparis set siparisKod=@siparisKod,urunKod=@urunKod,firmaAdi=@firmaAdi,hammadde=@hammadde,oncelikSirasi=@oncelikSirasi,boy=@boy,adet=@adet,bitisTarihi=@bitisTarihi,toplamSure=@toplamSure,gerekenUrunMiktari=@gerekenUrunMiktari,kullanilacakHat=@kullanilacakHat,bitTarih=@bitTarih,bitSaat=@bitSaat,tatilDahilSure=@tatilDahilSure where siparisKod='" + siparisKod + "'";
                siparisEkle.Parameters.Clear();
                siparisEkle.Parameters.AddWithValue("@urunKod", txtUrunKod.Text);
                siparisEkle.Parameters.AddWithValue("@siparisKod", txtSiparisKodu.Text);
                siparisEkle.Parameters.AddWithValue("@firmaAdi", txtFirmaAdi.Text);
                siparisEkle.Parameters.AddWithValue("@hammadde", hammaddeId);
                siparisEkle.Parameters.AddWithValue("@oncelikSirasi", txtOncelik.Text);
                siparisEkle.Parameters.AddWithValue("@boy", txtBoy.Text);
                siparisEkle.Parameters.AddWithValue("@adet", txtAdet.Text);
                siparisEkle.Parameters.AddWithValue("@renk", txtRenk.Text);
                siparisEkle.Parameters.AddWithValue("@baslangicTarihi", baslangicTarihi);
                siparisEkle.Parameters.AddWithValue("@bitisTarihi", sonuc);
                siparisEkle.Parameters.AddWithValue("@toplamSure", txtToplamSaat.Text);
                siparisEkle.Parameters.AddWithValue("@gerekenUrunMiktari", gerekenUrunMiktari);
                siparisEkle.Parameters.AddWithValue("@siparisBittimi", 0);
                siparisEkle.Parameters.AddWithValue("@kullanilacakHat", hatNo);
                siparisEkle.Parameters.AddWithValue("@sil", 0);
                siparisEkle.Parameters.AddWithValue("@devamDurumu", 3);
                siparisEkle.Parameters.AddWithValue("@bitTarih", sadeceTarih);
                siparisEkle.Parameters.AddWithValue("@bitSaat", sadeceSaat);
                siparisEkle.Parameters.AddWithValue("@kayitTarihi", kayitTarihi);
                siparisEkle.Parameters.AddWithValue("@tatilDahilSure", sonuc.Subtract(baslangicTarihi).TotalHours);

                siparisEkle.ExecuteNonQuery();

                SqlCommand birOncekiGuncelle = new SqlCommand("update siparis set sonrakiSiparisKodu='" + txtSiparisKodu.Text + "' where sonrakiSiparisKodu='" + siparisKod + "'", veritabani.conn);
                birOncekiGuncelle.ExecuteNonQuery();

            }catch(Exception ex){

                MessageBox.Show(ex.Message,"HATA",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                hata.hataMesajı = ex.Message;
                hata.hataKodu = "radSiparisDuzenleButonFormu-fonksiyonSiparisGuncelle";
                hata.hataMesajiKaydet();
            
            
            }

            

        }
        radSiparisDuzenle nesneRadSiparisDuzenleFormu = new radSiparisDuzenle();
        private void txtToplamSaat_TextChanged(object sender, EventArgs e)
        {
           // geciciBit = nesne.fonksiyonTatilGunuVarsaGec(bas,Convert.ToInt32(txtToplamSaat.Text));
            geciciBit = fonksiyon.fonksiyonSiparisBitisTarihiBul(bas, Convert.ToInt32(txtToplamSaat.Text));
            txtBitTar.Text = geciciBit.ToShortDateString();
            txtBitSaat.Text = geciciBit.Hour.ToString();
        }
        public void fonksiyonSonrakiSiparisGuncelle(string okunanSonrakiSiparisKodu,string okunanSiparisKodu,string oncekiUrunKod, DateTime okunanBitisTarihi) {            
            int yyyy,mm,dd,hour;
            DateTime okunanBaslangicTarihi;
            string okunanUrunKod;
            int okunanToplamSure;
                   while (okunanSonrakiSiparisKodu != "")
                                {
                                    try
                                    {

                                        veritabani.baglan();

                                        SqlCommand sonrakiSiparisBilgileriniOku = new SqlCommand("select * from siparis where siparisKod='" + okunanSonrakiSiparisKodu + "'", veritabani.conn);
                                        SqlDataReader okuSonrakibilgi = sonrakiSiparisBilgileriniOku.ExecuteReader();

                                        if (okuSonrakibilgi.Read())
                                        {
                                            okunanUrunKod = okuSonrakibilgi["urunKod"].ToString();
                                            if (oncekiUrunKod != okunanUrunKod)
                                                okunanBitisTarihi = okunanBitisTarihi.AddHours(2);

                                            okunanSonrakiSiparisKodu = okuSonrakibilgi["sonrakiSiparisKodu"].ToString();
                                            okunanSiparisKodu = okuSonrakibilgi["siparisKod"].ToString();
                                            okunanToplamSure = Convert.ToInt32(okuSonrakibilgi["toplamSure"]);



                                            oncekiUrunKod = okunanSiparisKodu;

                                           while(nesne.baslangictarihiTatileDenkGeliyormu(okunanBitisTarihi))
                                            {

                                                okunanBitisTarihi = okunanBitisTarihi.AddDays(1);
                                                yyyy = okunanBitisTarihi.Year;
                                                mm = okunanBitisTarihi.Month;
                                                dd = okunanBitisTarihi.Day;
                                                hour = okunanBitisTarihi.Hour;
                                                okunanBitisTarihi = new DateTime(yyyy, mm, dd, 00, 00, 00);

                                            }
                                            okunanBaslangicTarihi = okunanBitisTarihi;
                                            okunanBaslangicTarihi =nesne.fonksiyonBaslangicPazartesiMi(okunanBaslangicTarihi);
                                            okunanBitisTarihi =nesne.fonksiyonBaslangicPazartesiMi(okunanBitisTarihi);
                                            //okunanBitisTarihi = nesne.fonksiyonTatilGunuVarsaGec(okunanBitisTarihi, okunanToplamSure);
                                            okunanBitisTarihi = fonksiyon.fonksiyonSiparisBitisTarihiBul(okunanBitisTarihi, okunanToplamSure);
                                            SqlCommand onemsizGuncelle1 = new SqlCommand();
                                            onemsizGuncelle1.Connection = veritabani.conn;
                                            onemsizGuncelle1.CommandText = "update siparis set baslangicTarihi=@baslangicTarihi,bitisTarihi=@bitisTarihi,bitTarih=@bitTarih,bitSaat=@bitSaat,tatilDahilSure=@tatilDahilSure where siparisKod=@siparisKod";
                                            onemsizGuncelle1.Parameters.Clear();
                                            onemsizGuncelle1.Parameters.AddWithValue("@baslangicTarihi", okunanBaslangicTarihi);
                                            onemsizGuncelle1.Parameters.AddWithValue("@bitisTarihi", okunanBitisTarihi);
                                            onemsizGuncelle1.Parameters.AddWithValue("@bitTarih", okunanBitisTarihi.ToShortDateString());
                                            onemsizGuncelle1.Parameters.AddWithValue("@bitSaat", okunanBitisTarihi.Hour);
                                            onemsizGuncelle1.Parameters.AddWithValue("@tatilDahilSure", okunanBitisTarihi.Subtract(okunanBaslangicTarihi).TotalHours);
                                            onemsizGuncelle1.Parameters.AddWithValue("@siparisKod", okunanSiparisKodu);
                                            onemsizGuncelle1.ExecuteNonQuery();


                                        }


                                        /*
                                        SqlCommand gun = new SqlCommand("update siparis set baslangicTarihi=DATEADD(hour," + yeniToplamSure + ",baslangicTarihi),bitisTarihi=DATEADD(hour," + yeniToplamSure + ",bitisTarihi),bitTarih=convert(nvarchar(10),DATEADD(hour," + yeniToplamSure + ",bitisTarihi),104),bitSaat=DATEPART(HOUR, DATEADD(hour," + yeniToplamSure + ",bitisTarihi)) where siparisKod='" + okunanSiparisKodu + "'", veritabani.conn);

                                        gun.ExecuteNonQuery();
                                       */
                                        /*
                                            SqlCommand sor = new SqlCommand("select siparisKod,sonrakiSiparisKodu from siparis where siparisKod='" + okunanSonrakiSiparisKodu + "'",veritabani.conn);
                                            SqlDataReader oku = sor.ExecuteReader();
                                            if (oku.Read())
                                            {
                                                okunanSiparisKodu = oku["siparisKod"].ToString();
                                                okunanSonrakiSiparisKodu = oku["sonrakiSiparisKodu"].ToString();
                                            }
                                          */
                                    }catch(Exception ex){
                                        MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        hata.hataMesajı = ex.Message;
                                        hata.hataKodu = "radSiparisDuzenleButonFormu-fonksiyonSonrakiSiparisGuncelle";
                                        hata.hataMesajiKaydet();
                                        
                                    }


                                }
                                


                                //HATBİTİSTARİH TABLOSU GÜNCELLNİYOR. EN SON Kİ BİTİŞ TARİHİ YAZILIR
                                #region
                   try
                   {
                       SqlCommand HatBitisTarihGuncelle = new SqlCommand();
                       HatBitisTarihGuncelle.Connection = veritabani.conn;
                       HatBitisTarihGuncelle.CommandText = "update hatBitisTarih set bitisTarihi=@bitisTarihi,tarih=@tarih,saat=@saat where siparisKodu=@siparisKodu";
                       HatBitisTarihGuncelle.Parameters.Clear();
                       HatBitisTarihGuncelle.Parameters.AddWithValue("@bitisTarihi", okunanBitisTarihi);
                       HatBitisTarihGuncelle.Parameters.AddWithValue("@tarih", okunanBitisTarihi.ToShortDateString());
                       HatBitisTarihGuncelle.Parameters.AddWithValue("@saat", okunanBitisTarihi.Hour);
                       HatBitisTarihGuncelle.Parameters.AddWithValue("@siparisKodu", okunanSiparisKodu);
                       HatBitisTarihGuncelle.ExecuteNonQuery();
                   }catch(Exception ex){
                       MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                       hata.hataMesajı = ex.Message;
                       hata.hataKodu = "radSiparisDuzenleButonFormu-fonksiyonSonrakiSiparisGuncelle-HatBitisTarihGuncelle";
                       hata.hataMesajiKaydet();
                   
                   }
                                #endregion
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtSiparisKodu2.Visible = false;
            btnSipKaydet.Visible = false;
            button1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmbUrunler.Visible = false;
            btnUrKaydet.Visible = false;
            button2.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtFirmaAdi2.Visible = false;
            btnFirmaKaydet.Visible = false;
            button3.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cmbHammadde.Visible = false;
            btnHamKayd.Visible = false;
            button4.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cmbRenk.Visible = false;
            btnReKayde.Visible = false;
            button5.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtBoy2.Visible = false;
            btnBoyKaydet.Visible = false;
            button6.Visible = false;
                

        }

        private void button7_Click(object sender, EventArgs e)
        {
            txtAdet2.Visible = false;
            btnAdKayde.Visible = false;
            button7.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            cmbOncelik.Visible = false;
            btnOnKayde.Visible = false;
            button8.Visible = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            numericUpDown1.Visible = false;
            btnNumeric.Visible = false;
            button9.Visible = false;
        }

    }
}
