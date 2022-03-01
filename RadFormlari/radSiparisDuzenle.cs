using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using uretimPlanlamaProgrami.RadFormlari;

namespace uretimPlanlamaProgrami
{
    public partial class radSiparisDuzenle : Telerik.WinControls.UI.RadForm
    {
        public radSiparisDuzenle()
        {
            InitializeComponent();
        }
     
        private void radSiparisDuzenle_Load(object sender, EventArgs e)
        {
           
        
          
            // TODO: This line of code loads data into the 'genelDataSet.siparis' table. You can move, or remove it, as needed.
            rdGorunur.CheckState = CheckState.Checked;
            pnlConDetaylar.Visible = false;
            siparisBindingSource.Filter = "sil=0";
            siparisBindingSource.Filter = "FirmaAdı<>'TATİL'";
            this.siparisTableAdapter.Fill(this.genelDataSet.siparis);
            lblKayitSayisi.Text = radGridView2.RowCount + " kayıt listelendi";
           
            

        }

        public void gridYenile() {
            if(rdGorunur.IsChecked==true)
                siparisBindingSource.Filter = "sil=0";
            else if(rdGizli.IsChecked==false)
                siparisBindingSource.Filter = "sil=1";
            else
                siparisBindingSource.Filter = "";
            this.siparisTableAdapter.Fill(this.genelDataSet.siparis);
        
        }


       
        private void radGridView2_CellPaint(object sender, Telerik.WinControls.UI.GridViewCellPaintEventArgs e)
        {
            GridDataCellElement dataCell = e.Cell as GridDataCellElement;

            if (dataCell != null && dataCell.ColumnInfo.Name == "OncelikSırası")
            {
                string value = dataCell.Value.ToString();
                

                Brush brush = value =="Acil" ? Brushes.Red : Brushes.Green;
                Size cellSize = e.Cell.Size;

                using (Font font = new Font("Segoe UI", 17))
                {
                    e.Graphics.DrawString("*", font, brush, Point.Empty);
                }
            }
        }

        private void radGridView2_Click(object sender, EventArgs e)
        {

        }

        private void btnSiparisSİl_Click(object sender, EventArgs e)
        {

        }
        radUrunResimFormu urunResimGorm;
        private void lblUrunResmi_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Image urunResim = null;
                veritabani.baglan();
                SqlCommand urunResmi = new SqlCommand("select resim from urunler where kod='" + lblUrunKod.Text + "'", veritabani.conn);
                SqlDataReader urunResmiOku = urunResmi.ExecuteReader();
                if (urunResmiOku.Read())
                {

                    byte[] resim = (byte[])urunResmiOku["resim"];
                    MemoryStream ms = new MemoryStream(resim, 0, resim.Length);
                    ms.Write(resim, 0, resim.Length);
                    urunResim = Image.FromStream(ms, true);


                    if (urunResimGorm == null || urunResimGorm.IsDisposed)
                    {

                        urunResimGorm = new radUrunResimFormu(urunResim);

                        urunResimGorm.Show();
                    }
                    else
                        MessageBox.Show("Ürün Resmi açık durumda!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);




                }
            }catch{}
        }

        private void radGridView2_CommandCellClick(object sender, EventArgs e)
        {
            try
            {
                pnlConDetaylar.Visible = true;
                lblUrunKod.Text = radGridView2.CurrentRow.Cells[1].Value.ToString();
                lblSiparisKod.Text = radGridView2.CurrentRow.Cells[0].Value.ToString();
                lblFirmaAd.Text = radGridView2.CurrentRow.Cells[2].Value.ToString();
                lblHammadde.Text = radGridView2.CurrentRow.Cells[3].Value.ToString();
                lblOncelik.Text = radGridView2.CurrentRow.Cells[4].Value.ToString();
                lblBoy.Text = String.Format("{0:0,0}", Convert.ToInt32(radGridView2.CurrentRow.Cells[5].Value)) + " Milimetre";
                lblAdet.Text = String.Format("{0:0,0}", Convert.ToInt32(radGridView2.CurrentRow.Cells[6].Value));
                lblRenk.Text = radGridView2.CurrentRow.Cells[7].Value.ToString();

                lblBasTarihi.Text = String.Format("{0:f}", Convert.ToDateTime(radGridView2.CurrentRow.Cells[8].Value));
                lblBitTarihi.Text = String.Format("{0:f}", Convert.ToDateTime(radGridView2.CurrentRow.Cells[9].Value));

                lblToplamSure.Text = String.Format("{0:0,0}", Convert.ToInt32(radGridView2.CurrentRow.Cells[10].Value)) + " Saat";
                lblUrunMiktari.Text = String.Format("{0:0,0}", Convert.ToInt32(radGridView2.CurrentRow.Cells[11].Value)) + " Gram";
                lblHat.Text = radGridView2.CurrentRow.Cells[12].Value.ToString();
                lblDevamDur.Text = radGridView2.CurrentRow.Cells[13].Value.ToString();
                lblKayitTarihi.Text = String.Format("{0:f}", Convert.ToDateTime(radGridView2.CurrentRow.Cells[14].Value));
            }
            catch { }

        }

        

        private void radMenuButtonItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblSiparisKod.Text != "")
                {
                    if (brnGizle.Text == "GİZLE")
                    {
                        DialogResult cevap = MessageBox.Show("Siparişi gizlemek istediğinizden emin misiniz?", "UYARI", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (cevap == DialogResult.Yes)
                        {
                            veritabani.baglan();
                            SqlCommand siparisSil = new SqlCommand("update siparis set sil=1 where siparisKod='" + lblSiparisKod.Text + "'", veritabani.conn);
                            siparisSil.ExecuteNonQuery();
                            MessageBox.Show("Sipariş başarıyla gizlendi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            this.siparisTableAdapter.Fill(this.genelDataSet.siparis);
                        }

                    }
                    else if (brnGizle.Text == "GÖRÜNÜR YAP")
                    {
                        DialogResult cevap = MessageBox.Show("Siparişi görünür yapmak istediğinizden emin misiniz?", "UYARI", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (cevap == DialogResult.Yes)
                        {
                            veritabani.baglan();
                            SqlCommand siparisSil = new SqlCommand("update siparis set sil=0 where siparisKod='" + lblSiparisKod.Text + "'", veritabani.conn);
                            siparisSil.ExecuteNonQuery();
                            MessageBox.Show("Sipariş görünür hale getirildi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            this.siparisTableAdapter.Fill(this.genelDataSet.siparis);
                        }

                    }
                }
            }
            catch { }
        }

        private void rdGorunur_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            brnGizle.Visibility = ElementVisibility.Visible;
            siparisBindingSource.Filter = "sil=0";
            this.siparisTableAdapter.Fill(this.genelDataSet.siparis);
            lblKayitSayisi.Text = radGridView2.RowCount + " kayıt listelendi";

        }

        private void rdGizli_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            brnGizle.Visibility = ElementVisibility.Visible;
            siparisBindingSource.Filter = "sil=1";
            this.siparisTableAdapter.Fill(this.genelDataSet.siparis);
            lblKayitSayisi.Text = radGridView2.RowCount + " kayıt listelendi";
            
            brnGizle.Text = "GÖRÜNÜR YAP";
           

            //RadSplitButtonElement but=new RadSplitButtonElement();
            //but.Name="btnGorunur";
            //but.Text="Görünür Yap";
            //radSplitButton1.Items.Add(but);
            //but.Click+=new EventHandler(gorunurYap);
           

        }

        private void rdHerIkisi_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            siparisBindingSource.Filter = "";
            this.siparisTableAdapter.Fill(this.genelDataSet.siparis);
            lblKayitSayisi.Text = radGridView2.RowCount + " kayıt listelendi";
            brnGizle.Visibility = ElementVisibility.Hidden;
        }
        protected void gorunurYap(object sender,EventArgs args) {
            try
            {
                if (lblSiparisKod.Text != "")
                {
                    DialogResult cevap = MessageBox.Show("Siparişi görünür yapmak istediğinizden emin misiniz?", "UYARI", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (cevap == DialogResult.Yes)
                    {
                        veritabani.baglan();
                        SqlCommand siparisSil = new SqlCommand("update siparis set sil=0 where siparisKod='" + lblSiparisKod.Text + "'", veritabani.conn);
                        siparisSil.ExecuteNonQuery();
                        MessageBox.Show("Sipariş görünür hale getirildi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        this.siparisTableAdapter.Fill(this.genelDataSet.siparis);
                    }
                }
            }
            catch { }
        }

        private void radGridView2_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                if (radGridView2.CurrentRow.Index != -1)
                {
                    int kilogramGerekliUrun = Convert.ToInt32(radGridView2.CurrentRow.Cells[11].Value) / 1000;

                    pnlConDetaylar.Visible = true;
                    lblUrunKod.Text = radGridView2.CurrentRow.Cells[1].Value.ToString();
                    lblSiparisKod.Text = radGridView2.CurrentRow.Cells[0].Value.ToString();
                    lblFirmaAd.Text = radGridView2.CurrentRow.Cells[2].Value.ToString();
                    lblHammadde.Text = radGridView2.CurrentRow.Cells[3].Value.ToString();
                    lblOncelik.Text = radGridView2.CurrentRow.Cells[4].Value.ToString();
                    lblBoy.Text = String.Format("{0:0,0}", Convert.ToInt32(radGridView2.CurrentRow.Cells[5].Value)) + " Milimetre";
                    lblAdet.Text = String.Format("{0:0,0}", Convert.ToInt32(radGridView2.CurrentRow.Cells[6].Value));
                    lblRenk.Text = radGridView2.CurrentRow.Cells[7].Value.ToString();

                    lblBasTarihi.Text = String.Format("{0:f}", Convert.ToDateTime(radGridView2.CurrentRow.Cells[8].Value));
                    lblBitTarihi.Text = String.Format("{0:f}", Convert.ToDateTime(radGridView2.CurrentRow.Cells[9].Value));

                    lblToplamSure.Text = String.Format("{0:0,0}", Convert.ToInt32(radGridView2.CurrentRow.Cells[10].Value)) + " Saat";
                    lblUrunMiktari.Text = String.Format("{0:0,0}", Convert.ToInt32(radGridView2.CurrentRow.Cells[11].Value)) + " Gram = " + String.Format("{0:0,0}", kilogramGerekliUrun) + " kg";
                    lblHat.Text = radGridView2.CurrentRow.Cells[12].Value.ToString();
                    lblDevamDur.Text = radGridView2.CurrentRow.Cells[13].Value.ToString();
                    lblKayitTarihi.Text = String.Format("{0:f}", Convert.ToDateTime(radGridView2.CurrentRow.Cells[14].Value));
                }
                else
                    pnlConDetaylar.Visible = false;
            }
            catch { }
        }
        radSiparisDuzenleButonFormu radSiparisDuzenleButonFormu;
        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            try
            {
                
                this.Cursor = Cursors.WaitCursor;
                if (radGridView2.CurrentRow.Index != -1)
                {
                    if (radGridView2.CurrentRow.Cells[13].Value.ToString() != "Bitti.")
                    {
                       

                        if (radSiparisDuzenleButonFormu == null || radSiparisDuzenleButonFormu.IsDisposed)
                        {
                            DateTime bas = Convert.ToDateTime(radGridView2.CurrentRow.Cells[8].Value);
                            DateTime bit = Convert.ToDateTime(radGridView2.CurrentRow.Cells[9].Value);
                            radSiparisDuzenleButonFormu = new radSiparisDuzenleButonFormu(lblSiparisKod.Text, lblUrunKod.Text, lblFirmaAd.Text, lblHammadde.Text, lblRenk.Text, Convert.ToInt32(radGridView2.CurrentRow.Cells[5].Value), Convert.ToInt32(radGridView2.CurrentRow.Cells[6].Value), lblOncelik.Text, bas, bit, Convert.ToInt32(radGridView2.CurrentRow.Cells[10].Value), Convert.ToInt32(lblHat.Text), Convert.ToInt32(radGridView2.CurrentRow.Cells[11].Value), radGridView2.CurrentRow.Cells[13].Value.ToString());
                            radSiparisDuzenleButonFormu.Show();
                            this.Cursor = Cursors.Default;
                        }
                        else
                        {
                            this.Cursor = Cursors.WaitCursor;
                            MessageBox.Show("Form açık durumda!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }

                    }

                    else
                    {
                        this.Cursor = Cursors.WaitCursor;
                        MessageBox.Show("Bitmiş olan bir sipariş düzeltilemez.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                } 
                    else

                    MessageBox.Show("Lütfen düzenleyeceğiniz siparişi seçiniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch { }
        }



        Fonksiyonlar fonksiyon = new Fonksiyonlar();
        private void radMenuButtonItem2_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime bas = Convert.ToDateTime(radGridView2.CurrentRow.Cells[8].Value);
                DateTime bit = Convert.ToDateTime(radGridView2.CurrentRow.Cells[9].Value);

                radSiparisDuzenleButonFormu nesne = new radSiparisDuzenleButonFormu(lblSiparisKod.Text, lblUrunKod.Text, lblFirmaAd.Text, lblHammadde.Text, lblRenk.Text, Convert.ToInt32(radGridView2.CurrentRow.Cells[5].Value), Convert.ToInt32(radGridView2.CurrentRow.Cells[6].Value), lblOncelik.Text, bas, bit, Convert.ToInt32(radGridView2.CurrentRow.Cells[10].Value), Convert.ToInt32(lblHat.Text), Convert.ToInt32(radGridView2.CurrentRow.Cells[11].Value), radGridView2.CurrentRow.Cells[13].Value.ToString());
                veritabani.baglan();
                if (lblDevamDur.Text == "Bitti.")
                {


                    DialogResult cevap = MessageBox.Show("Siparişi kalıcı olarak silmek istediğinizden emin misiniz?", "UYARI", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (cevap == DialogResult.Yes)
                    {
                        SqlCommand bagla = new SqlCommand("select * from siparis where siparisKod='" + lblSiparisKod.Text + "'", veritabani.conn);
                        SqlDataReader baglaOku = bagla.ExecuteReader();
                        if (baglaOku.Read())
                        {
                            if (baglaOku["sonrakiSiparisKodu"].ToString() != "")
                            {
                                SqlCommand update = new SqlCommand("update siparis set sonrakiSiparisKodu='" + baglaOku["sonrakiSiparisKodu"].ToString() + "' where sonrakiSiparisKodu='" + lblSiparisKod.Text + "'", veritabani.conn);
                                update.ExecuteNonQuery();


                            }
                            else
                            {
                                SqlCommand update = new SqlCommand("update siparis set sonrakiSiparisKodu='' where sonrakiSiparisKodu='" + lblSiparisKod.Text + "'", veritabani.conn);
                                update.ExecuteNonQuery();

                            }


                        }

                        SqlCommand delete = new SqlCommand("delete from siparis where siparisKod='" + lblSiparisKod.Text + "'", veritabani.conn);
                        delete.ExecuteNonQuery();
                        this.siparisTableAdapter.Fill(this.genelDataSet.siparis);
                        MessageBox.Show("Sipariş başarıyla silindi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);


                    }
                }

                else if (lblDevamDur.Text == "Beklemede")
                {
                    DialogResult cevap = MessageBox.Show("Bu işlem sonucunda bazı siparişlerin başlangıç ve bitiş tarihleri değişecek. Bu işlemi onaylıyor musunuz?", "UYARI", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (cevap == DialogResult.Yes)
                    {

                        SqlCommand sonrakisiparis = new SqlCommand("select * from siparis where siparisKod='" + lblSiparisKod.Text + "'", veritabani.conn);
                        SqlDataReader sonrakiOku = sonrakisiparis.ExecuteReader();
                        SqlCommand oncekiSiparisbilgileri = new SqlCommand("select * from siparis where sonrakiSiparisKodu='" + lblSiparisKod.Text + "'", veritabani.conn);
                        SqlDataReader oncekiOku = oncekiSiparisbilgileri.ExecuteReader();
                        string siparisKoduu = "";
                        string sonrakiSiparisKoduu = "";
                        string urunKoduu = "";
                        DateTime bitisTarihii = DateTime.Now;
                        if (oncekiOku.Read())
                        {
                            siparisKoduu = oncekiOku["siparisKod"].ToString();
                            urunKoduu = oncekiOku["urunKod"].ToString();
                            bitisTarihii = Convert.ToDateTime(oncekiOku["bitisTarihi"]);


                        }
                        if (sonrakiOku.Read())
                        {
                            if (sonrakiOku["sonrakiSiparisKodu"].ToString() != "")
                            {
                                sonrakiSiparisKoduu = sonrakiOku["sonrakiSiparisKodu"].ToString();
                                SqlCommand update = new SqlCommand("update siparis set sonrakiSiparisKodu='" + sonrakiOku["sonrakiSiparisKodu"].ToString() + "' where siparisKod='" + siparisKoduu + "'", veritabani.conn);
                                update.ExecuteNonQuery();
                                nesne.fonksiyonSonrakiSiparisGuncelle(sonrakiSiparisKoduu, siparisKoduu, urunKoduu, bitisTarihii);
                            }

                        }

                        SqlCommand delete = new SqlCommand("delete from siparis where siparisKod='" + lblSiparisKod.Text + "'", veritabani.conn);
                        delete.ExecuteNonQuery();
                        this.siparisTableAdapter.Fill(this.genelDataSet.siparis);
                        MessageBox.Show("Sipariş başarıyla silindi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);



                    }



                }
                else if (lblDevamDur.Text == "Devam Ediyor...")
                {
                    radNormalSiparisEkle nesne1 = new radNormalSiparisEkle();
                    DialogResult cevap = MessageBox.Show("Devam eden bir sipariş silinecek.Bu işlem sonucunda bazı siparişlerin başlangıç ve bitiş tarihleri değişecek.Bu işlemi onaylıyor musunuz?", "UYARI", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (cevap == DialogResult.Yes)
                    {
                        SqlCommand sonrakisiparis = new SqlCommand("select * from siparis where siparisKod='" + lblSiparisKod.Text + "'", veritabani.conn);
                        SqlDataReader sonrakiOku = sonrakisiparis.ExecuteReader();
                        if (sonrakiOku.Read())
                        {
                            if (sonrakiOku["sonrakiSiparisKodu"].ToString() != "")
                            {
                                string sonrakiSiparisKoduu = sonrakiOku["sonrakiSiparisKodu"].ToString();
                                SqlCommand sonrakiBilgi = new SqlCommand("select * from siparis where siparisKod='" + sonrakiOku["sonrakiSiparisKodu"].ToString() + "'", veritabani.conn);
                                SqlDataReader sonrakiBilgiOku = sonrakiBilgi.ExecuteReader();

                                if (sonrakiBilgiOku.Read())
                                {


                                    DateTime bugunTarihSaat = DateTime.Now;
                                    DateTime okunanBitisTarihi = DateTime.Now;
                                    int okunanToplamSure = Convert.ToInt32(sonrakiBilgiOku["toplamSure"]);
                                    string urunKoduu = sonrakiBilgiOku["urunKod"].ToString();
                                    string siparisKoduu = sonrakiBilgiOku["siparisKod"].ToString();
                                    sonrakiSiparisKoduu = sonrakiBilgiOku["sonrakiSiparisKodu"].ToString();
                                    int dakka = Convert.ToInt32(bugunTarihSaat.Minute);
                                    int bugunSaat = Convert.ToInt32(bugunTarihSaat.Hour);
                                    bugunSaat = bugunSaat + 1;

                                    int yyyy = bugunTarihSaat.Year;
                                    int mm = bugunTarihSaat.Month;
                                    int dd = bugunTarihSaat.Day;
                                    int hour = bugunTarihSaat.Hour;


                                    if (hour == 23)
                                    {
                                        bugunTarihSaat = bugunTarihSaat.AddHours(1);
                                        hour = bugunTarihSaat.Hour;

                                    }
                                    else
                                    {
                                        hour = hour + 1;

                                    }


                                    bugunTarihSaat = new DateTime(yyyy, mm, dd, hour, 00, 00);
                                    while (nesne1.baslangictarihiTatileDenkGeliyormu(bugunTarihSaat))
                                    {

                                        bugunTarihSaat = bugunTarihSaat.AddDays(1);
                                        yyyy = bugunTarihSaat.Year;
                                        mm = bugunTarihSaat.Month;
                                        dd = bugunTarihSaat.Day;
                                        hour = bugunTarihSaat.Hour;
                                        bugunTarihSaat = new DateTime(yyyy, mm, dd, 00, 00, 00);

                                    }

                                    //bugunTarihSaat = nesne1.fonksiyonBaslangicPazartesiMi(bugunTarihSaat);
                                    bugunTarihSaat = nesne1.fonksiyonBaslangicPazartesiMi(bugunTarihSaat);
                                   // okunanBitisTarihi = nesne1.fonksiyonTatilGunuVarsaGec(bugunTarihSaat, okunanToplamSure);
                                    okunanBitisTarihi = fonksiyon.fonksiyonSiparisBitisTarihiBul(bugunTarihSaat, okunanToplamSure);
                                    SqlCommand update = new SqlCommand("update siparis set baslangicTarihi=@baslangicTarihi,bitisTarihi=@bitisTarihi,tatilDahilSure=@tatilDahilSure where siparisKod=@siparisKod", veritabani.conn);
                                    update.Parameters.Clear();
                                    update.Parameters.AddWithValue("@baslangicTarihi", SqlDbType.DateTime).Value = bugunTarihSaat;
                                    update.Parameters.AddWithValue("@bitisTarihi", SqlDbType.DateTime).Value = okunanBitisTarihi;
                                    update.Parameters.AddWithValue("@tatilDahilSure", Convert.ToInt32(okunanBitisTarihi.Subtract(bugunTarihSaat).TotalHours));
                                    update.Parameters.AddWithValue("@siparisKod", siparisKoduu);
                                    nesne.fonksiyonSonrakiSiparisGuncelle(sonrakiSiparisKoduu, siparisKoduu, urunKoduu, okunanBitisTarihi);

                                    SqlCommand delete = new SqlCommand("delete from siparis where siparisKod='" + lblSiparisKod.Text + "'", veritabani.conn);
                                    delete.ExecuteNonQuery();
                                    this.siparisTableAdapter.Fill(this.genelDataSet.siparis);
                                    MessageBox.Show("Sipariş başarıyla silindi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);


                                }
                            }
                            else
                            {
                                SqlCommand updateSonrakibilgi = new SqlCommand("update siparis set sonrakiSiparisKodu='' where sonrakiSiparisKodu='" + lblSiparisKod.Text + "'", veritabani.conn);
                                updateSonrakibilgi.ExecuteNonQuery();
                                SqlCommand hatBitisGuncelle = new SqlCommand("update hatBitisTarih set bitisTarihi='NULL',tarih='NULL',saat='NULL',siparisKodu='NULL'", veritabani.conn);
                                hatBitisGuncelle.ExecuteNonQuery();
                                SqlCommand delete = new SqlCommand("delete from siparis where siparisKod='" + lblSiparisKod.Text + "'", veritabani.conn);
                                delete.ExecuteNonQuery();
                                this.siparisTableAdapter.Fill(this.genelDataSet.siparis);
                                MessageBox.Show("Sipariş başarıyla silindi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);


                            }

                        }


                    }


                }

            }
            catch { }

        }

        private void radMenuButtonItem1_Click_1(object sender, EventArgs e)
        {
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += this.Doc_PrintPage;
            PrintDialog dlgSettings = new PrintDialog();
            dlgSettings.Document = doc;
            if (dlgSettings.ShowDialog() == DialogResult.OK)
            {
                doc.Print();
            }
        }
        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            float x = e.MarginBounds.Left;
            float y = e.MarginBounds.Top;
            Bitmap bmp = new Bitmap(this.groupBox4.Width, this.groupBox4.Height);
            this.groupBox4.DrawToBitmap(bmp, new Rectangle(0, 0, this.groupBox4.Width, this.groupBox4.Height));
            e.Graphics.DrawImage((Image)bmp, x, y);
        }

        private void radGridView2_RowFormatting(object sender, RowFormattingEventArgs e)
        {
            e.RowElement.RowInfo.Height = 60;
            
        }

        private void radGridView2_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.CellElement.ColumnInfo.HeaderText == "Durum")
            {
                if (e.CellElement.RowInfo.Cells["Durum"].Value != null)
                {
                    if (e.CellElement.RowInfo.Cells["Durum"].Value.ToString()=="Bitti.")
                    {
                        e.CellElement.DrawFill = true;
                        e.CellElement.ForeColor = Color.AntiqueWhite;
                        e.CellElement.NumberOfColors = 1;
                        e.CellElement.BackColor = Color.DarkRed;
                    }
                    else if (e.CellElement.RowInfo.Cells["Durum"].Value.ToString() == "Beklemede") {

                        e.CellElement.DrawFill = true;
                        e.CellElement.ForeColor = Color.BlueViolet;
                        e.CellElement.NumberOfColors = 1;
                        e.CellElement.BackColor = Color.DarkOrange;
                    }
                    else
                    {
                        e.CellElement.DrawFill = true;
                        e.CellElement.ForeColor = Color.Yellow;
                        e.CellElement.NumberOfColors = 1;
                        e.CellElement.BackColor = Color.Green;
                    }
                }
            }
            else
            {
                e.CellElement.ResetValue(LightVisualElement.DrawFillProperty, ValueResetFlags.Local);
                e.CellElement.ResetValue(LightVisualElement.ForeColorProperty, ValueResetFlags.Local);
                e.CellElement.ResetValue(LightVisualElement.NumberOfColorsProperty, ValueResetFlags.Local);
                e.CellElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local);
            }

        }

        private void radPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.siparisTableAdapter.FillBy(this.genelDataSet.siparis);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
        


        
    }
}
