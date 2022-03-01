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

namespace uretimPlanlamaProgrami.RadFormlari
{
    public partial class radSistemAyarlari : Telerik.WinControls.UI.RadForm
    {
        public radSistemAyarlari()
        {
            InitializeComponent();
        }
        string gun;
        string kayitliHaftalikTatilGunu;
        string saat;
        Hashtable kayitliTatiller = new Hashtable();
        Hashtable eklenenTatiller = new Hashtable();
        Hashtable silinenTatiller = new Hashtable();
        ses s = new ses();
        private void btnAyarlariKaydet_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void rdHerIkisi_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdGizli_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdGorunurOlanlar_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void listDigerTatilGunleri_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAciklamaGuncelle_Click(object sender, EventArgs e)
        {

        }

        private void btnTatilGUnuPasif_Click(object sender, EventArgs e)
        {

        }

        private void btnTatilGunuSil_Click(object sender, EventArgs e)
        {

        }

        private void txtAciklama_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTatilGunuEkle_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnPasiflestir_Click(object sender, EventArgs e)
        {

        }

        private void chcDigerTatilGun_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chcHatPasiflestirilsinmi_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radSistemAyarlari_Load(object sender, EventArgs e)
        {
            veritabani.baglan();
            radDateTimePicker1.Value = DateTime.Now;
            cmbGunler.Items.Add("YOK");
            //cmbGunler.Items.Add("PAZARTESİ");
            //cmbGunler.Items.Add("SALI");
            //cmbGunler.Items.Add("ÇARŞAMBA");
            //cmbGunler.Items.Add("PERŞEMBE");
            //cmbGunler.Items.Add("CUMA");
            cmbGunler.Items.Add("CUMARTESİ");
            cmbGunler.Items.Add("PAZAR");
            /*
            cmbSaatler.Items.Add("YOK");
            for (int i = 0; i <= 23; i++) {

                cmbSaatler.Items.Add(i.ToString());
            
            }
            */
            SqlCommand sor = new SqlCommand("select * from Ayarlar", veritabani.conn);
            SqlDataReader oku = sor.ExecuteReader();
            if (oku.Read())
            {
                cmbGunler.SelectedItem = cmbGunler.GetItemText(oku["tatilGunu"].ToString());
                //  cmbSaatler.SelectedItem = cmbSaatler.GetItemText(oku["mesaiSaati"].ToString());

            }


            gun = cmbGunler.GetItemText(cmbGunler.SelectedItem);
            // saat =cmbSaatler.GetItemText(cmbSaatler.SelectedItem);
            kayitliHaftalikTatilGunu = gun;


            listTatilGunleriDoldur(true);

            listBoxDoldur(true, 1);
            listBoxDoldur(false, 2);

            if (chcAktifPasif.Checked == false)
            {
                lisKullanilabilirHatlar.Enabled = false;
                listKullanilamayanHatlar.Enabled = false;
                grpKullanilabilen.Enabled = false;
                grpKullanilamayan.Enabled = false;


            }
            if (chcDigerTatilGunleri.Checked == false)
            {
                grpTatilGunleri.Enabled = false;
                listDigerTatilGunleri.Enabled = false;
                radDateTimePicker1.Enabled = false;
            }
        }
        private int fonksiyonDiziBoyutlariAl(int deger)
        {

            try
            {
                veritabani.baglan();
                int boyut;
                SqlCommand oku = new SqlCommand("select count(numara) from uretimHatti where kullanilabilirmi=" + deger + "", veritabani.conn);
                boyut = Convert.ToInt32(oku.ExecuteScalar());

                return boyut;
            }
            catch (Exception)
            {

                return -1;
            }

        }
        private void listBoxDoldur(bool deger, int hangiListe)
        {
            int i = 0;
            veritabani.baglan();
            SqlCommand al = new SqlCommand("select numara from uretimHatti where kullanilabilirmi='" + deger + "'", veritabani.conn);
            SqlDataReader oku = al.ExecuteReader();
            while (oku.Read())
            {
                if (hangiListe == 1)
                {
                    lisKullanilabilirHatlar.Items.Add("HAT-" + oku["numara"]);

                }
                else
                {
                    listKullanilamayanHatlar.Items.Add("HAT-" + oku["numara"]);

                }
            }
        }

        private void listTatilGunleriDoldur(bool gorunurluk)
        {
            
            veritabani.baglantiyiKes();
            veritabani.baglan();
            listDigerTatilGunleri.Items.Clear();
            SqlCommand al = new SqlCommand("select * from TatilGunleri where gorunurluk='" + gorunurluk + "'", veritabani.conn);
            SqlDataReader oku = al.ExecuteReader();
            while (oku.Read())
            {
                kayitliTatiller[oku["tarih"].ToString()] = oku["aciklama"].ToString();
                hashtable[oku["tarih"].ToString()] = oku["aciklama"].ToString();
                listDigerTatilGunleri.Items.Add(String.Format("{0:D}", Convert.ToDateTime(oku["tarih"])));
            }

        }

        private void chcAktifPasif_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chcAktifPasif.Checked == false)
            {
                lisKullanilabilirHatlar.Enabled = false;
                listKullanilamayanHatlar.Enabled = false;
                grpKullanilabilen.Enabled = false;
                grpKullanilabilen.Enabled = false;

            }
            else
            {
                grpKullanilabilen.Enabled = true;
                grpKullanilamayan.Enabled = true;
                lisKullanilabilirHatlar.Enabled = true;
                listKullanilamayanHatlar.Enabled = true;


            }
        }

        private void btnPasiflestir_Click_1(object sender, EventArgs e)
        {
            try
            {
                int toplamhatSayisi = lisKullanilabilirHatlar.Items.Count;

                DialogResult cevap;
                int hatno = Convert.ToInt16(lisKullanilabilirHatlar.SelectedItem.ToString().Substring(4));
                cevap = MessageBox.Show("Seçili Hattı pasifleştirmek istediğinizden emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes)
                {

                    if (toplamhatSayisi > 1)
                    {

                        SqlCommand sor = new SqlCommand("select count(*) from siparis where devamDurumu!=2 and kullanilacakHat='" + hatno + "'", veritabani.conn);
                        int sayi = Convert.ToInt32(sor.ExecuteScalar());
                        if (sayi == 0)
                        {

                            listKullanilamayanHatlar.Items.Add("HAT-" + hatno.ToString());
                            lisKullanilabilirHatlar.Items.Remove("HAT-" + hatno.ToString());
                            s.onay_sesi();
                            // MessageBox.Show("Seçili hat pasifleştirildi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            s.hata_sesi();
                            MessageBox.Show("Bu hat kullanıldığından dolayı pasifleştirilemez.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        s.hata_sesi();
                        MessageBox.Show("Hat pasifleştirme işlemi başarısız.En az bir hat kullanilabilir olmalı!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }


                }
            }
            catch (Exception)
            {

            }
        }

        private void btnHatAktiflestir_Click(object sender, EventArgs e)
        {
            if (listKullanilamayanHatlar.SelectedItems.Count == 1)
            {
                DialogResult cevap;
                int hatno = Convert.ToInt16(listKullanilamayanHatlar.SelectedItem.ToString().Substring(4));
                cevap = MessageBox.Show("Seçili Hattı aktifleştimek istediğinizden emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes)
                {
                    listKullanilamayanHatlar.Items.Remove("HAT-" + hatno.ToString());
                    lisKullanilabilirHatlar.Items.Add("HAT-" + hatno.ToString());
                    s.onay_sesi();
                    // MessageBox.Show("Seçili hat aktifleştirildi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            //tatil tarihini değiştirirseniz siparişler bundan etkilenecek;
            beklemeFormu beklemeFormu = new uretimPlanlamaProgrami.beklemeFormu();
            
            veritabani.baglan();
            DialogResult cevap;
            int hatno;
            cevap = MessageBox.Show("Değişiklikler kaydedilsin mi?", "Uyarı", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes)
            {
                try
                {
                    veritabani.baglan();
                    this.Cursor = Cursors.WaitCursor;
                    for (int l = 0; l < lisKullanilabilirHatlar.Items.Count; l++)
                    {
                        hatno = Convert.ToInt32(lisKullanilabilirHatlar.Items[l].ToString().Substring(4));
                        SqlCommand updateUrunHat = new SqlCommand("update uretimHatti set kullanilabilirmi=1 where numara='" + hatno + "' ", veritabani.conn);
                        updateUrunHat.ExecuteNonQuery();
                    }
                    for (int l = 0; l < listKullanilamayanHatlar.Items.Count; l++)
                    {
                        hatno = Convert.ToInt32(listKullanilamayanHatlar.Items[l].ToString().Substring(4));
                        SqlCommand updateUrunHat = new SqlCommand("update uretimHatti set kullanilabilirmi=0 where numara='" + hatno + "' ", veritabani.conn);
                        updateUrunHat.ExecuteNonQuery();

                    }
                    gun = cmbGunler.GetItemText(cmbGunler.SelectedItem);
                    // saat = cmbSaatler.GetItemText(cmbSaatler.SelectedItem);
                    SqlCommand ayarlarGuncelle = new SqlCommand("update Ayarlar set tatilGunu='" + gun + "'", veritabani.conn);
                    ayarlarGuncelle.ExecuteNonQuery();

                    SqlCommand tatilGunleriZamanlarAl = new SqlCommand("select max(id) from TatilGunleriZamanlar",veritabani.conn);
                    int TatilGunleriZamanlarId = Convert.ToInt32(tatilGunleriZamanlarAl.ExecuteScalar());

                    if (gun != kayitliHaftalikTatilGunu) {
                        SqlCommand TatilGunleriZamanlar = new SqlCommand("update TatilGunleriZamanlar set tatilGunuBitis='" + DateTime.Now + "' where id='"+TatilGunleriZamanlarId+"'", veritabani.conn);
                        TatilGunleriZamanlar.ExecuteNonQuery();

                        SqlCommand tatilGunleriZamanlarEkle = new SqlCommand("insert into TatilGunleriZamanlar(tatilGunuBaslangic,tatilGunu) values('"+DateTime.Now+"','"+gun+"')");
                        tatilGunleriZamanlarEkle.ExecuteNonQuery();
                    }


                    fonksiyonYeniTatilGunuIcinSiparisGuncelle();
                    fonksiyonSilinenTatilGunuIcinSiparisGuncelle();

                    foreach (string items in pasiflestirilecekler)
                    {
                        SqlCommand pasiflestir = new SqlCommand("update TatilGunleri set gorunurluk=0 where tarih='" + items + "'", veritabani.conn);
                        pasiflestir.ExecuteNonQuery();
                    }
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("Değişiklikler kaydedildi.");

                }
                catch (Exception ex)
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    hata.hataKodu = "radSistemAyalari-btnKaydet_Click";
                    hata.hataMesajı = ex.Message;
                    hata.hataMesajiKaydet();


                }

            }
            else if (cevap == DialogResult.No)
            {
                lisKullanilabilirHatlar.Items.Clear();
                listKullanilamayanHatlar.Items.Clear();
                eklenenTatiller.Clear();
                silinenTatiller.Clear();
                listBoxDoldur(true, 1);
                listBoxDoldur(false, 2);
                radSistemAyarlari frm = new radSistemAyarlari();
                frm.Close();
            }


        }

        private void btnKaydetmedenCik_Click(object sender, EventArgs e)
        {
            try
            {
                veritabani.baglan();
                foreach (DictionaryEntry entry in eklenenTatiller)
                {
                    SqlCommand sil = new SqlCommand("delete from TatilGunleri where tarih='" + entry.Key + "'", veritabani.conn);
                    sil.ExecuteNonQuery();

                }
                foreach (DictionaryEntry entry in silinenTatiller)
                {
                    string tarihString = entry.Key.ToString();

                    SqlCommand tatilGunleriEkle = new SqlCommand("insert into tatilGunleri(tarih,aciklama) values('" + tarihString + "','" + silinenTatiller[tarihString] + "')", veritabani.conn);
                    tatilGunleriEkle.ExecuteNonQuery();

                }

            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hata.hataKodu = "radSistemAyalari-btnKaydetmedenCik_Click";
                hata.hataMesajı = ex.Message;
                hata.hataMesajiKaydet();


            }

            this.Close();
        }
        Hashtable hashtable = new Hashtable();
        private void chcDigerTatilGunleri_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chcDigerTatilGunleri.Checked == true)
            {
                grpTatilGunleri.Enabled = true;
                listDigerTatilGunleri.Enabled = true;
                radDateTimePicker1.Enabled = true;
            }
            else
            {

                grpTatilGunleri.Enabled = false;
                listDigerTatilGunleri.Enabled = false;
                radDateTimePicker1.Enabled = false;

            }
        }

        private void btnTatillereEkle_Click(object sender, EventArgs e)
        {
            if (txtAciklama.Text == "")
            {

                //toolTip1.SetToolTip(txtAciklama, "Açıklama alanı zorunludur");
                toolTip1.Active = true;
                toolTip1.Show("Açıklama alanı zorunludur", txtAciklama);
            }
            else if (radDateTimePicker1.Value <= DateTime.Now)
            {
                MessageBox.Show("Geçmiş tarihler tatil günü olarak eklenemez! Lütfen ileriki bir tarihi seçiniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                try
                {
                    veritabani.baglan();
                    SqlCommand sor = new SqlCommand("select * from Ayarlar", veritabani.conn);
                    SqlDataReader oku = sor.ExecuteReader();
                    if (oku.Read())
                    {
                        if (oku["TatilGunu"].ToString() == String.Format("{0:dddd}", radDateTimePicker1.Value).ToUpper())
                        {
                            MessageBox.Show("Seçilen gün, tatil günü zaten!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                    }
                    if (!kayitliTatiller.ContainsKey(radDateTimePicker1.Value.ToShortDateString()))
                        eklenenTatiller[radDateTimePicker1.Value.ToShortDateString()] = txtAciklama.Text;

                    // MessageBox.Show( hashtable.ContainsKey(dateTimePicker1.Value.ToShortDateString()).ToString());
                    if (!hashtable.ContainsKey(radDateTimePicker1.Value.ToShortDateString()))
                    {
                        eklenenTatiller[radDateTimePicker1.Value.ToShortDateString()] = txtAciklama.Text;
                        hashtable[radDateTimePicker1.Value.ToShortDateString()] = txtAciklama.Text;
                        listDigerTatilGunleri.Items.Add(String.Format("{0:D}", radDateTimePicker1.Value));
                        DateTime tarih = radDateTimePicker1.Value;
                        string tarihString = tarih.ToShortDateString();
                        SqlCommand tatilGunleriEkle = new SqlCommand("insert into tatilGunleri(tarih,aciklama) values('" + tarihString + "','" + hashtable[tarihString] + "')", veritabani.conn);
                        tatilGunleriEkle.ExecuteNonQuery();
                        txtAciklama.Text = "";

                    }
                    else
                        MessageBox.Show("Sistemde böyle bir tatil günü mevcut zaten!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    hata.hataKodu = "radSistemAyalari-btnTatillereEkle_Click";
                    hata.hataMesajı = ex.Message;
                    hata.hataMesajiKaydet();


                }

            }
        }

        private void btnTatilGunuSil_Click_1(object sender, EventArgs e)
        {
            try
            {
                veritabani.baglan();
                if (listDigerTatilGunleri.SelectedItems.Count > 0)
                {
                    DateTime tarih = Convert.ToDateTime(listDigerTatilGunleri.SelectedItem);
                    string tarihString = tarih.ToShortDateString();
                    if (tarih < DateTime.Now)
                    {
                        MessageBox.Show("Geçmiş tarihlerdeki tatil gunleri silinemez!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        if (kayitliTatiller.ContainsKey(tarihString))
                            silinenTatiller[tarihString] = hashtable[tarihString].ToString();
                        SqlCommand sil = new SqlCommand("delete from TatilGunleri where tarih='" + tarihString + "'", veritabani.conn);
                        sil.ExecuteNonQuery();
                        listDigerTatilGunleri.Items.Remove(listDigerTatilGunleri.SelectedItem);
                        txtKayitliAciklama.Text = "";
                        hashtable.Remove(tarihString);


                    }


                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hata.hataKodu = "radSistemAyalari-btnTatilGunuSil_Click_1";
                hata.hataMesajı = ex.Message;
                hata.hataMesajiKaydet();


            }
        }
        List<string> pasiflestirilecekler = new List<string>();
        private void btnTarihGizle_Click(object sender, EventArgs e)
        {
            DateTime tarih = Convert.ToDateTime(listDigerTatilGunleri.SelectedItem);
            string tarihString = tarih.ToShortDateString();
            pasiflestirilecekler.Add(tarihString);
            hashtable[tarihString] = txtKayitliAciklama.Text;
            listDigerTatilGunleri.Items.Remove(listDigerTatilGunleri.SelectedItem);
            txtKayitliAciklama.Text = "";
        }

        private void rdGorunur_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            txtKayitliAciklama.Text = "";
            listTatilGunleriDoldur(true);
            btnTarihGorunurYap.Enabled = false;
            btnTarihGizle.Enabled = true;
        }

        private void rdGizliOlanlar_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            txtKayitliAciklama.Text = "";
            listTatilGunleriDoldur(false);
            btnTarihGizle.Enabled = false;
            btnTarihGorunurYap.Enabled = true;
        }

        private void rdHepsi_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try
            {
                btnTarihGizle.Enabled = true;
                btnTarihGorunurYap.Enabled = true;
                txtKayitliAciklama.Text = "";
                listDigerTatilGunleri.Items.Clear();
                SqlCommand al = new SqlCommand("select * from TatilGunleri", veritabani.conn);
                SqlDataReader oku = al.ExecuteReader();
                while (oku.Read())
                {
                    kayitliTatiller[oku["tarih"].ToString()] = oku["aciklama"].ToString();
                    hashtable[oku["tarih"].ToString()] = oku["aciklama"].ToString();
                    listDigerTatilGunleri.Items.Add(String.Format("{0:D}", Convert.ToDateTime(oku["tarih"])));
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hata.hataKodu = "radSistemAyalari-rdHepsi_ToggleStateChanged";
                hata.hataMesajı = ex.Message;
                hata.hataMesajiKaydet();


            }
        }
        Fonksiyonlar fonksiyon = new Fonksiyonlar();
        public void fonksiyonSilinenTatilGunuIcinSiparisGuncelle()
        {
            try
            {
                foreach (DictionaryEntry entry in silinenTatiller)
                {
                    veritabani.baglan();
                    DateTime tarih = Convert.ToDateTime(entry.Key);
                    SqlCommand bulSayi = new SqlCommand("select count(*) from siparis where @tarih>=baslangicTarihi and @tarih<=bitisTarihi ", veritabani.conn);
                    bulSayi.Parameters.Clear();
                    bulSayi.Parameters.AddWithValue("@tarih", SqlDbType.DateTime).Value = tarih;
                    int sayi = Convert.ToInt32(bulSayi.ExecuteScalar());
                    SqlCommand bul = new SqlCommand("select * from siparis where @tarih>=baslangicTarihi and @tarih<=bitisTarihi order by kullanilacakHat,bitisTarihi desc ", veritabani.conn);
                    bul.Parameters.Clear();
                    bul.Parameters.AddWithValue("@tarih", SqlDbType.DateTime).Value = tarih;
                    SqlDataReader oku = bul.ExecuteReader();
                    string[] siparisKodlari = new string[sayi];
                    int i = 0;
                    radNormalSiparisEkle siparisNesne = new radNormalSiparisEkle();
                    veritabani.baglan();
                    while (oku.Read())
                    {

                        DateTime baslangicTarihi = Convert.ToDateTime(oku["baslangicTarihi"]);
                        DateTime bitisTarihi = Convert.ToDateTime(oku["bitisTarihi"]);
                        string siparisKodu = oku["siparisKod"].ToString();
                        int toplamSure = Convert.ToInt32(oku["toplamSure"]);
                        string urunKod = oku["urunKod"].ToString();
                        siparisKodlari[i++] = oku["siparisKod"].ToString();
                        string sonrakiSiparisKodu = oku["sonrakiSiparisKodu"].ToString();
                        int hatno = Convert.ToInt32(oku["kullanilacakHat"]);
                        while (nesne.baslangictarihiTatileDenkGeliyormu(baslangicTarihi))
                        {

                            baslangicTarihi = baslangicTarihi.AddDays(1);
                            int yyyy = baslangicTarihi.Year;
                            int mm = baslangicTarihi.Month;
                            int dd = baslangicTarihi.Day;
                            int hour = baslangicTarihi.Hour;
                            baslangicTarihi = new DateTime(yyyy, mm, dd, 08, 00, 00);


                        }
                        baslangicTarihi = nesne.fonksiyonBaslangicPazartesiMi(baslangicTarihi);
                        //bitisTarihi = nesne.fonksiyonTatilGunuVarsaGec(baslangicTarihi, toplamSure);
                        bitisTarihi = fonksiyon.fonksiyonSiparisBitisTarihiBul(baslangicTarihi, toplamSure);
                       


                        fonksiyonVeritabaniSiparisGuncelle(siparisKodu, baslangicTarihi, bitisTarihi);
                        fonksiyonSonrakiSiparisGuncelle(sonrakiSiparisKodu, siparisKodu, urunKod, bitisTarihi);


                    }



                }



            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hata.hataKodu = "radSistemAyalari-fonksiyonSilinenTatilGunuIcinSiparisGuncelle";
                hata.hataMesajı = ex.Message;
                hata.hataMesajiKaydet();


            }
        }
        public void fonksiyonVeritabaniSiparisGuncelle(string siparisKodu, DateTime baslangic, DateTime bitis)
        {
            try
            {
                SqlCommand sonrakileriGuncelle = new SqlCommand();
                sonrakileriGuncelle.Connection = veritabani.conn;
                veritabani.baglan();

                int tatilDahilSure = Convert.ToInt32(bitis.Subtract(baslangic).TotalHours);

                sonrakileriGuncelle.CommandText = "update siparis set baslangicTarihi=@baslangicTarihi,bitisTarihi=@bitisTarihi,bitTarih=@bitTarih,bitSaat=@bitSaat,tatilDahilSure=@tatilDahilSure where siparisKod=@siparisKod";
                sonrakileriGuncelle.Parameters.Clear();
                sonrakileriGuncelle.Parameters.AddWithValue("@baslangicTarihi", SqlDbType.DateTime).Value = baslangic;
                sonrakileriGuncelle.Parameters.AddWithValue("@bitisTarihi", SqlDbType.DateTime).Value = bitis;
                sonrakileriGuncelle.Parameters.AddWithValue("@bitTarih", bitis.ToShortDateString());
                sonrakileriGuncelle.Parameters.AddWithValue("@bitSaat", bitis.Hour);
                sonrakileriGuncelle.Parameters.AddWithValue("@siparisKod", siparisKodu);
                sonrakileriGuncelle.Parameters.AddWithValue("@tatilDahilSure", tatilDahilSure);
                sonrakileriGuncelle.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hata.hataKodu = "radSistemAyalari-fonksiyonVeritabaniSiparisGuncelle";
                hata.hataMesajı = ex.Message;
                hata.hataMesajiKaydet();


            }

        }
        
        
        int eklenenSure = 0;
        
        public void fonksiyonYeniTatilGunuIcinSiparisGuncelle()
        {
            veritabani.baglantiyiKes();
            try
            {
                foreach (DictionaryEntry entry in eklenenTatiller)
                {

                    veritabani.baglan();
                    DateTime tarih = Convert.ToDateTime(entry.Key);
                    SqlCommand bulSayi = new SqlCommand("select count(*) from siparis where @tarih>=baslangicTarihi and @tarih<=bitisTarihi ", veritabani.conn);
                    bulSayi.Parameters.Clear();
                    bulSayi.Parameters.AddWithValue("@tarih", SqlDbType.DateTime).Value = tarih;
                    int sayi = Convert.ToInt32(bulSayi.ExecuteScalar());
                    SqlCommand bul = new SqlCommand("select * from siparis where @tarih>=baslangicTarihi and @tarih<=bitisTarihi order by kullanilacakHat,bitisTarihi desc ", veritabani.conn);
                    bul.Parameters.Clear();
                    bul.Parameters.AddWithValue("@tarih", SqlDbType.DateTime).Value = tarih;
                    SqlDataReader oku = bul.ExecuteReader();
                    string[] siparisKodlari = new string[sayi];
                    int i = 0;
                    // radNormalSiparisEkle siparisNesne = new radNormalSiparisEkle();
                    veritabani.baglan();
                    while (oku.Read())
                    {

                        DateTime baslangicTarihi = Convert.ToDateTime(oku["baslangicTarihi"]);
                        DateTime bitisTarihi = Convert.ToDateTime(oku["bitisTarihi"]);
                        string siparisKodu = oku["siparisKod"].ToString();
                        int toplamSure = Convert.ToInt32(oku["toplamSure"]);
                        string urunKod = oku["urunKod"].ToString();
                        string oncekiUrunKod = urunKod;
                        siparisKodlari[i++] = oku["siparisKod"].ToString();
                        string sonrakiSiparisKodu = oku["sonrakiSiparisKodu"].ToString();
                        int hatno = Convert.ToInt32(oku["kullanilacakHat"]);

                        while (nesne.baslangictarihiTatileDenkGeliyormu(baslangicTarihi))
                        {

                            baslangicTarihi = baslangicTarihi.AddDays(1);
                            int yyyy = baslangicTarihi.Year;
                            int mm = baslangicTarihi.Month;
                            int dd = baslangicTarihi.Day;
                            int hour = baslangicTarihi.Hour;
                            baslangicTarihi = new DateTime(yyyy, mm, dd, 08, 00, 00);


                        }
                        baslangicTarihi = nesne.fonksiyonBaslangicPazartesiMi(baslangicTarihi);
                       // bitisTarihi = nesne.fonksiyonTatilGunuVarsaGec(baslangicTarihi, toplamSure);
                        bitisTarihi = fonksiyon.fonksiyonSiparisBitisTarihiBul(baslangicTarihi, toplamSure);
                        DateTime oncekiBitisTarihi = bitisTarihi;

                        fonksiyonVeritabaniSiparisGuncelle(siparisKodu, baslangicTarihi, bitisTarihi);
                        fonksiyonSonrakiSiparisGuncelle(sonrakiSiparisKodu, siparisKodu, urunKod, bitisTarihi);

                    }




                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hata.hataKodu = "radSistemAyalari-fonksiyonYeniTatilGunuIcinSiparisGuncelle";
                hata.hataMesajı = ex.Message;
                hata.hataMesajiKaydet();


            }
        }

        private void btnTarihGorunurYap_Click(object sender, EventArgs e)
        {
            DateTime tarih = Convert.ToDateTime(listDigerTatilGunleri.SelectedItem);
            string tarihString = tarih.ToShortDateString();
            pasiflestirilecekler.Remove(tarihString);
            hashtable.Remove(tarihString);
            listDigerTatilGunleri.Items.Remove(listDigerTatilGunleri.SelectedItem);
            txtKayitliAciklama.Text = "";
        }
        radNormalSiparisEkle nesne = new radNormalSiparisEkle();
        hatalar hata = new hatalar();
        public void fonksiyonSonrakiSiparisGuncelle(string okunanSonrakiSiparisKodu, string okunanSiparisKodu, string oncekiUrunKod, DateTime okunanBitisTarihi)
        {
            
            int yyyy, mm, dd, hour;
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

                        while (nesne.baslangictarihiTatileDenkGeliyormu(okunanBitisTarihi))
                        {

                            okunanBitisTarihi = okunanBitisTarihi.AddDays(1);
                            yyyy = okunanBitisTarihi.Year;
                            mm = okunanBitisTarihi.Month;
                            dd = okunanBitisTarihi.Day;
                            hour = okunanBitisTarihi.Hour;
                            okunanBitisTarihi = new DateTime(yyyy, mm, dd, 00, 00, 00);

                        }
                        okunanBaslangicTarihi = okunanBitisTarihi;
                        okunanBaslangicTarihi = nesne.fonksiyonBaslangicPazartesiMi(okunanBaslangicTarihi);
                        okunanBitisTarihi = nesne.fonksiyonBaslangicPazartesiMi(okunanBitisTarihi);
                       // okunanBitisTarihi = nesne.fonksiyonTatilGunuVarsaGec(okunanBitisTarihi, okunanToplamSure);

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


                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    hata.hataMesajı = ex.Message;
                    hata.hataKodu = "radSistemAyarlari-fonksiyonSonrakiSiparisGuncelle";
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hata.hataMesajı = ex.Message;
                hata.hataKodu = "radSistemAyarlari-fonksiyonSonrakiSiparisGuncelle-HatBitisTarihGuncelle";
                hata.hataMesajiKaydet();

            }
            #endregion

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
