using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using uretimPlanlamaProgrami.RadFormlari;

namespace uretimPlanlamaProgrami
{
    public partial class frmHaftalikPlanNEw : Form
    {
        
        public frmHaftalikPlanNEw()
        {
            InitializeComponent();
        }
        hatalar hata = new hatalar();
        Fonksiyonlar fonksiyon = new Fonksiyonlar();

        HatRenkleri HatRenkleri = new HatRenkleri();
        private void frmHaftalikPlanNEw_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'genelDataSet.uretimHatti' table. You can move, or remove it, as needed.
            this.uretimHattiTableAdapter.Fill(this.genelDataSet.uretimHatti);
            // TODO: This line of code loads data into the 'genelDataSet.siparis' table. You can move, or remove it, as needed.
            newsutunOlusturma();
            pnlSiparisDetay.Visible = false;
            pnlTatilAciklamasi.Visible = false;
            DataGridViewCellStyle style = dtGrid.ColumnHeadersDefaultCellStyle;
            style.Font = new Font(FontFamily.GenericSansSerif, 30F, FontStyle.Bold, GraphicsUnit.World, 12, false);
            dtGrid.Columns[0].HeaderCell.Style.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
            dtGrid.Columns[0].DefaultCellStyle.BackColor = Color.PowderBlue;

            lblCalendar.Text = String.Format("{0:D}", fonksiyonHaftaBasiBul(DateTime.Now));
        }

        
        int satir, x, y;
        int sutun;
        int hatno;
        string seciliSiparisKodu;
        
        ContextMenu cm;
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                dataGridView1[sutun, satir].Style.SelectionBackColor = dataGridView1[sutun, satir].Style.BackColor;
                satir = Convert.ToInt32(dataGridView1.CurrentCell.RowIndex);
                sutun = Convert.ToInt32(dataGridView1.CurrentCell.ColumnIndex);
                hatno = Convert.ToInt32(dataGridView1.Rows[satir].Cells[0].Value);
                //  MessageBox.Show(satir.ToString()+"  "+sutun.ToString());
                if (dataGridView1[sutun, satir].Style.BackColor == HatRenkleri.ekTatilRengi && sutun != 0 && ilk != 0)
                {
                    if (e.RowIndex != -1 && e.ColumnIndex != -1) // başlık yeri dışında bir satırsa
                    {
                        if (e.Button == MouseButtons.Left)
                        { //sag tuşbasıldıysa

                            seciliSiparisKodu = siparisKodlari[satir, sutun];

                            var mouseninyeri = dataGridView1.PointToClient(Cursor.Position);
                            x = mouseninyeri.X;
                            y = mouseninyeri.Y;
                            cm = new ContextMenu();

                            System.Windows.Forms.MenuItem m2 = new System.Windows.Forms.MenuItem("Tatil Açıklaması");
                            cm.MenuItems.Add(m2);
                            m2.Click += new EventHandler(m2_Click);

                            cm.Show(dataGridView1, mouseninyeri);



                            //tıklanan hücrede menu açma

                        }
                    }

                }

                else if (dataGridView1[sutun, satir].Style.BackColor != Color.White && sutun != 0 && ilk != 0 && dataGridView1[sutun, satir].Style.BackColor != HatRenkleri.haftalikTatilRengi)
                {
                    if (e.RowIndex != -1 && e.ColumnIndex != -1) // başlık yeri dışında bir satırsa
                    {
                        if (e.Button == MouseButtons.Left)
                        { //sag tuşbasıldıysa

                            seciliSiparisKodu = siparisKodlari[satir, sutun];

                            var mouseninyeri = dataGridView1.PointToClient(Cursor.Position);
                            x = mouseninyeri.X;
                            y = mouseninyeri.Y;
                            cm = new ContextMenu();

                            System.Windows.Forms.MenuItem m1 = new System.Windows.Forms.MenuItem("Sipariş Detayları");
                            cm.MenuItems.Add(m1);
                            m1.Click += new EventHandler(m1_Click);

                            cm.Show(dataGridView1, mouseninyeri);



                            //tıklanan hücrede menu açma

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                hata.hataMesajı = ex.Message;
                hata.hataKodu = "frmHaftalikPlanCellMouseClick";
                hata.hataMesajiKaydet();

            }
        }
        private void m2_Click(object sender, EventArgs e)
        {
            int blok = sutun / 49;
            pnlTatilAciklamasi.Location = new Point(x, y);
            pnlTatilAciklamasi.Visible = true;
          //  dataGridView1.Enabled = false;
            DateTime seciliTatilGunu = haftaBasi.AddDays(blok);
            lblTatilGunu.Text =  "" + String.Format("{0:D}",seciliTatilGunu);
            
            txtTatilAciklama.Text = hashtable[blok * 48 + 2].ToString();
            // MessageBox.Show(hashtable[blok*48+2].ToString());
        }
        private void m1_Click(object sender, EventArgs e)
        {
            try
            {
                int devamDurumu;
                DateTime simdi = DateTime.Now;
                int yyyy;
                int mon;
                int d;
                int h;
                int min;
                int seco;
                yyyy = simdi.Year;
                mon = simdi.Month;
                d = simdi.Day;
                h = simdi.Hour;
                min = simdi.Minute;
                seco = 00;
                DateTime simdiFormatli = new DateTime(yyyy, mon, d, h, min, 00);
                //Sipariş detayları
                veritabani.baglan();
                decimal gerekenUrunMiktari;
                if (siparisKodlari[satir, sutun] != "*")
                {

                    // pnlSiparisDetay.SetBounds(x, y,393,326);
                    
                    pnlSiparisDetay.Visible = true;
                    //pnlSiparisDetay.Location = new Point(x-380, y);
                    dataGridView1.Enabled = false;
                    SqlCommand siparis = new SqlCommand("select * from siparis s,hammadde h,renkler r where s.hammadde=h.id and s.renk=r.id and siparisKod='" + seciliSiparisKodu + "'", veritabani.conn);
                    SqlDataReader siparisOku = siparis.ExecuteReader();
                    if (siparisOku.Read())
                    {
                        gerekenUrunMiktari = Convert.ToDecimal(siparisOku["gerekenUrunMiktari"]);
                        lblGerekliUrunMiktari.Text = "" + String.Format("{0:0,0}", gerekenUrunMiktari) + "= " +String.Format("{0:0,0}", (gerekenUrunMiktari/1000))+ " kg";
                        lblHammadde.Text = siparisOku["adi"].ToString();
                        lblKayitTarihi.Text = "" + String.Format("{0:f}", Convert.ToDateTime(siparisOku["kayitTarihi"]));
                        lblRenk.Text = siparisOku["renkAdi"].ToString();
                        lblFirmaAdi.Text = siparisOku["firmaAdi"].ToString();
                        //lblBoy.Text = siparisOku["boy"].ToString()+" milimetre";
                        lblAdet.Text = "" + String.Format("{0:0,0}", Convert.ToDecimal(siparisOku["adet"]));
                        devamDurumu = Convert.ToInt16(siparisOku["devamDurumu"]);
                        lblSiparisKodu.Text = siparisOku["siparisKod"].ToString();
                        lblBoy.Text = "" + String.Format("{0:0,0}", Convert.ToDecimal(siparisOku["boy"])) + " milimetre";
                        lblBaslangıçTarihi.Text = "" + String.Format("{0:f}", Convert.ToDateTime(siparisOku["baslangicTarihi"]));
                        lblBitisTarihi.Text = "" + String.Format("{0:f}", Convert.ToDateTime(siparisOku["bitisTarihi"]));
                        lblUrunKod.Text = siparisOku["urunKod"].ToString();
                        lblHatNO.Text = siparisOku["kullanilacakHat"].ToString();

                        lblGerekliUrunMiktari.Text = String.Format("{0:0,0}", Convert.ToInt32(siparisOku["gerekenUrunMiktari"]) / 1000) + " kg";
                        int toplamSure = Convert.ToInt32(siparisOku["tatilDahilSure"]);

                        if (devamDurumu == 2)
                        {
                            lblKalan.Text = "% 0";
                            lblIslenen.Text = "% 100";
                            progIslenen.Value = 0;
                            progIslenen.Minimum = 0;
                            progIslenen.Maximum = toplamSure * 60;
                            progIslenen.Step = 1;
                            while (progIslenen.Value != toplamSure * 60)
                            {
                                progIslenen.Value = progIslenen.Value += 1;

                            }

                        }
                        else if (devamDurumu == 1)
                        {

                            int kalanDakka = Convert.ToInt32(Convert.ToDateTime(siparisOku["bitisTarihi"]).Subtract(simdiFormatli).TotalMinutes);
                            int kalan = (100 * kalanDakka) / (toplamSure * 60);
                            int Islenen = 100-kalan;
                            lblKalan.Text = "% " + (kalan).ToString();
                            lblIslenen.Text = "% " +Islenen.ToString();
                            progIslenen.Minimum = 0;
                            progIslenen.Value = Islenen;
                            progIslenen.Maximum = 100;
                            progIslenen.Step = 1;
                            if (progIslenen.Value != 100)
                            {
                                progIslenen.Value = Islenen;

                            }
                        }
                        else
                        {
                            lblIslenen.Text = "% 0";
                            lblKalan.Text = "% 100";
                            progIslenen.Value = 0;
                        }

                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                hata.hataMesajı = ex.Message;
                hata.hataKodu = "frmHaftalikPlan_M1_Click";
                hata.hataMesajiKaydet();
            }


        }
        
        
        radUrunResimFormu radUrunResmiFormu;
        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            dtGrid.HorizontalScrollingOffset = dataGridView1.HorizontalScrollingOffset;
            pnlTatilAciklamasi.Visible = false;
        }
        public void newsutunOlusturma()
        {
           
            
            int onlar = 0, on = 0, bir = 0;
            int birler = 0;
            int k = 2;
            for (int j = 0; j < 7; j++)
            {
                
                for (int i = 0; i < 24; i++)
                {

                   
                    
                        dataGridView1.Columns.Add("colum" + i.ToString(), " ");
                        dataGridView1.Columns[k++].Width = 20;
                        dataGridView1.Columns.Add("column" + i.ToString(), " ");
                        dataGridView1.Columns[k++].Width = 5;
                    


                }

            }



            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Height = 50;
            }


        }
        DateTime haftaBasi;
        public DateTime fonksiyonHaftaBasiBul(DateTime dt) {
            int bugunKacinciGun = (int)dt.DayOfWeek;
            if (bugunKacinciGun == 0) //Haftanın ilk günü Pazar kabul ettiğinden
            {
                haftaBasi = dt.AddDays(-6); // İşte hafta başı pazartesi
                //    dt.AddDays(1).ToShortDateString(); // Ve işte sonraki hafta başı Pazartesi
            }
            else // Gün Pazar değilse;
            {
                haftaBasi = dt.AddDays(1 - bugunKacinciGun); ; // İşte hafta başı pazartesi
                //txtTarih2.Text = Convert.ToDateTime(txtTarih1.Text).AddDays(7).ToShortDateString();// Ve işte sonraki hafta başı Pazartesi
            }
            return haftaBasi;
        }
        private void radCalendar1_SelectionChanged(object sender, EventArgs e)
        {
            DateTime dt = radCalendar1.SelectedDate;

           haftaBasi= fonksiyonHaftaBasiBul(dt);
           

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {

                for (int j = 2; j <dataGridView1.ColumnCount; j++)
                {
                    if (dataGridView1[j, i].Style.BackColor != HatRenkleri.haftalikTatilRengi)
                        dataGridView1[j, i].Style.BackColor = Color.White;
                }

            }
            lblCalendar.Text = String.Format("{0:D}", haftaBasi);
            hatRenkDoldur(haftaBasi,haftaBasi.AddDays(7));


        }
        Hashtable hashtable = new Hashtable();
        string[] gunler = { "PAZARTESİ", "SALI", "ÇARŞAMBA", "PERŞEMBE", "CUMA", "CUMARTESİ", "PAZAR" };

        public void tatilGununuSiyahYap(DateTime seciliTarih, DateTime Bitis)
        {
            try
            {
                int yil = seciliTarih.Year;
                DateTime gecici = new DateTime(yil, 1, 1);

                string gun = "";
               
               


                int kacinciGun;
                veritabani.baglan();
                string command = "select tatilGunu from Ayarlar";
               // SqlCommand sor = new SqlCommand("select tatilGunu from Ayarlar", veritabani.conn);
                SqlDataReader oku = fonksiyon.fonksiyonSorgu(command);
                if (oku.Read())
                {
                    gun = oku["tatilGunu"].ToString();
                }
               
                int j = 0;
                while (j <= 6 && gun.ToUpper() != gunler[j])
                    j = j + 1;

                kacinciGun = j;

                
                int i = 0;
               // MessageBox.Show(kacinciGun.ToString());
                for (i = 0; i < dataGridView1.RowCount; i++)
                {

                    for (j = 2 + (kacinciGun * 48); j <= kacinciGun * 48 + 49; j++)
                    {

                        dataGridView1[j, i].Style.BackColor = HatRenkleri.haftalikTatilRengi;
                    }

                }

                for (i = 0; i < dataGridView1.RowCount; i++)
                {

                    for (j = 2; j <16; j++)
                    {

                        dataGridView1[j, i].Style.BackColor = HatRenkleri.haftalikTatilRengi;
                    }

                }
                

                //Dier Tatil Gunleri
                DateTime bas = seciliTarih;
                int k = 0;
                DateTime[] DigerTatiller = new DateTime[7];
                DigerTatiller = null;

                int a = 0;
               
                while (bas <= Bitis)
                {

                    command="select * from TatilGunleri where tarih= '" + bas.ToShortDateString() + "'";
                   // SqlCommand digerTatilGunleri = new SqlCommand("select * from TatilGunleri where tarih= '" + bas.ToShortDateString() + "'", veritabani.conn);

                    SqlDataReader digerTatilOku = fonksiyon.fonksiyonSorgu(command);
                    if (digerTatilOku.Read())
                    {
                        DateTime tarh = Convert.ToDateTime(digerTatilOku["tarih"]);
                        int saatFark = Convert.ToInt32(tarh.Subtract(seciliTarih).TotalHours);
                        hashtable[saatFark * 2 + 2] = digerTatilOku["aciklama"].ToString();
                        for (k = saatFark * 2 + 2; k < saatFark * 2 + 50; k++)
                        {

                            for (i = 0; i < dataGridView1.RowCount; i++)
                            {
                                dataGridView1[k, i].Style.BackColor = HatRenkleri.ekTatilRengi;



                            }


                        }

                    }
                    bas = bas.AddDays(1);
                }


                //pasifHattiBoya(seciliTarih,Bitis);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                hata.hataMesajı = ex.Message;
                hata.hataKodu = "frmHaftalikPlan -tatilGununuSiyahYap";
                hata.hataMesajiKaydet();


            }

            
        }
        public void pasifHattiBoya(DateTime bas,DateTime bitis)
        {
            try
            {
                string command;
                
                ilk = 1;
                veritabani.baglan();

                string siparisKodu;
                //RENKLER
                #region
                


                #endregion
                DateTime bitisTar;
                DateTime basTarihi;

                int saatSayisi;
                int hatNo;
                int satir;
                int k = 0;

                //SqlCommand sorSayi = new SqlCommand(" select count(*) from uretimHatti  ", veritabani.conn);
                command = " select count(*) from uretimHatti  ";
                int sayi = fonksiyon.fonksiyonSorguSayi(command);
                siparisKodlari = new string[sayi, dataGridView1.ColumnCount];
                for (int i = 0; i < sayi; i++)
                {
                    for (int j = 1; j < dataGridView1.ColumnCount; j++)
                    {
                        siparisKodlari[i, j] = "*";

                    }

                }
                command = "select * from HatPasifTarihleri where ('" + bas.ToString("yyyy-MM-dd hh:mm:ss") + "' between pasifBaslangicTarihi and pasifBitisTarihi)";
                //SqlCommand sor = new SqlCommand("select * from siparis where ('" + bas.ToString("yyyy-MM-dd hh:mm:ss") + "' between baslangicTarihi and bitisTarihi)", veritabani.conn);
                SqlDataReader oku = fonksiyon.fonksiyonSorgu(command);

                while (oku.Read())
                {
                    
                    bitisTar = Convert.ToDateTime(oku["pasifBitisTarihi"]);
                    hatNo = Convert.ToInt32(oku["hatNo"]);
                    //int tatilDahilSaat = Convert.ToInt32(oku["tatilDahilSaat"]);


                    // saatSayisi = Convert.ToInt32(bitisTar.Subtract(bas));
                    saatSayisi = 0;
                    TimeSpan cikar = bitisTar.Subtract(bas);
                    saatSayisi = Convert.ToInt32(cikar.TotalHours);



                    satir = satirIndeksBul(hatNo.ToString());
                    if (saatSayisi <= 168)
                    {
                        //MessageBox.Show(saatSayisi.ToString());
                        for (int i = 2; i <= saatSayisi * 2 + 1; i++)
                        {
                            if (dataGridView1[i, satir].Style.BackColor != Color.Black && dataGridView1[i, satir].Style.BackColor != Color.DarkGray)
                            {
                                dataGridView1[i, satir].Style.BackColor = Color.Black;
                               
                            }

                        }


                        k++;
                    }
                    else
                    {
                        // MessageBox.Show("2");
                        for (int i = 2; i < dataGridView1.ColumnCount; i++)
                        {
                            if (dataGridView1[i, satir].Style.BackColor != Color.Black && dataGridView1[i, satir].Style.BackColor != Color.DarkGray)
                            {
                                dataGridView1[i, satir].Style.BackColor = Color.Black;
                               
                            }

                        }
                        k++;


                    }

                }
                // SqlCommand sor2 = new SqlCommand("select * from siparis where baslangicTarihi between '" + bas.ToString("yyyy-MM-dd hh:mm:ss") + "' and '" + bitis.ToString("yyyy-MM-dd hh:mm:ss") + "'", veritabani.conn);
                command = "select * from HatPasifTarihleri where pasifBaslangicTarihi between '" + bas.ToString("yyyy-MM-dd hh:mm:ss") + "' and '" + bitis.ToString("yyyy-MM-dd hh:mm:ss") + "'";
                SqlDataReader oku2 = fonksiyon.fonksiyonSorgu(command);

                while (oku2.Read())
                {
                    int j = 0;
                    int farkSaat;
                    int totalSaat;
                    
                    bitisTar = Convert.ToDateTime(oku2["pasifBitisTarihi"]);
                    basTarihi = Convert.ToDateTime(oku2["pasifBaslangicTarihi"]);
                    TimeSpan cikar = basTarihi.Subtract(bas);
                    farkSaat = Convert.ToInt32(cikar.TotalHours);
                    totalSaat = Convert.ToInt32(oku2["saat"]);
                    hatNo = Convert.ToInt32(oku2["hatNo"]);
                    // saatSayisi = Convert.ToInt32(bitisTar.Subtract(bas));
                    saatSayisi = 0;
                    //cikar = bitisTar.Subtract(bas);
                    // saatSayisi = Convert.ToInt32(cikar.TotalHours);
                    if (k == 18)
                        k = 0;
                    satir = satirIndeksBul(hatNo.ToString());

                    if ((168 - farkSaat) >= totalSaat)
                    {

                        for (int i = farkSaat * 2 + 3; j < totalSaat * 2 - 1; i++)
                        {
                            if (dataGridView1[i, satir].Style.BackColor != Color.Black && dataGridView1[i, satir].Style.BackColor != Color.DarkGray)
                            {
                                dataGridView1[i, satir].Style.BackColor = Color.Black;
                                j++;
                                
                            }


                        }
                        k++;

                    }
                    else
                    {


                        //MessageBox.Show("total= "+totalSaat.ToString()+"  farkSa= "+farkSaat.ToString());
                        for (int i = farkSaat * 2 + 3; i < dataGridView1.ColumnCount; i++)
                        {
                            if (dataGridView1[i, satir].Style.BackColor != Color.Black && dataGridView1[i, satir].Style.BackColor != Color.DarkGray)
                            {
                                dataGridView1[i, satir].Style.BackColor = Color.Black;
                                
                            }

                        }
                        k++;
                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                hata.hataMesajı = ex.Message;
                hata.hataKodu = "frmHaftalikPlan -hatRenkDoldur";
                hata.hataMesajiKaydet();

            }


        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            pnlTatilAciklamasi.Visible = false;
        }
        public int satirIndeksBul(string searchValue)
        {

            try
            {

                int rowIndex = -1;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value.ToString().Equals(searchValue))
                    {
                        rowIndex = row.Index;
                        break;
                    }
                }

                return rowIndex;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                hata.hataMesajı = ex.Message;
                hata.hataKodu = "frmHaftalikPlan -satirIndexBul";
                hata.hataMesajiKaydet();
                return -1;

            }
        }
        string[,] siparisKodlari;
        int ilk = 0;
        public void hatRenkDoldur(DateTime bas, DateTime bitis)
        {
            try
            {
                string command,firmaAdi;
                tatilGununuSiyahYap(bas, bitis);
                ilk = 1;
                veritabani.baglan();

               
                //renk[9] = Color.Ivory; bu renk datagrdi le aynı renkte

                string siparisKodu;
                //RENKLER
                #region
                Color[] renk = new Color[22];

                renk[0] = Color.Brown;
                renk[1] = Color.Bisque;
                renk[2] = Color.Blue;
                renk[3] = Color.Chocolate;
                renk[4] = Color.DarkCyan;
                renk[5] = Color.DarkOrange;
                renk[6] = Color.DarkTurquoise;
                renk[7] = Color.DodgerBlue;
                renk[8] = Color.GreenYellow;
                renk[9] = Color.SaddleBrown;
                renk[10] = Color.LawnGreen;
                renk[11] = Color.LightGray;
                renk[12] = Color.LightSeaGreen;
                renk[13] = Color.Magenta;
                renk[14] = Color.MediumTurquoise;
                renk[15] = Color.PaleVioletRed;
                renk[16] = Color.Red;
                renk[17] = Color.SeaShell;

                renk[18] = Color.MistyRose;
                renk[19] = Color.Coral;
                renk[20] = Color.Cornsilk;
                renk[21] = Color.Gold;

                #endregion
                DateTime bitisTar;
                DateTime basTarihi;

                int saatSayisi;
                int hatNo;
                int satir;
                int k = 0;

                //SqlCommand sorSayi = new SqlCommand(" select count(*) from uretimHatti  ", veritabani.conn);
                command = " select count(*) from uretimHatti  ";
                int sayi = fonksiyon.fonksiyonSorguSayi(command);
                siparisKodlari = new string[sayi, dataGridView1.ColumnCount];
                for (int i = 0; i < sayi; i++)
                {
                    for (int j = 1; j < dataGridView1.ColumnCount; j++)
                    {
                        siparisKodlari[i, j] = "*";

                    }

                }
                command = "select * from siparis where ('" + bas.ToString("yyyy-MM-dd hh:mm:ss") + "' between baslangicTarihi and bitisTarihi)";
                //SqlCommand sor = new SqlCommand("select * from siparis where ('" + bas.ToString("yyyy-MM-dd hh:mm:ss") + "' between baslangicTarihi and bitisTarihi)", veritabani.conn);
                SqlDataReader oku = fonksiyon.fonksiyonSorgu(command);
                //BİRİNCİ
                while (oku.Read())
                {
                    siparisKodu = oku["siparisKod"].ToString();
                    bitisTar = Convert.ToDateTime(oku["bitisTarihi"]);
                    hatNo = Convert.ToInt32(oku["kullanilacakHat"]);
                    //int tatilDahilSaat = Convert.ToInt32(oku["tatilDahilSaat"]);
                    firmaAdi=oku["firmaAdi"].ToString();

                    // saatSayisi = Convert.ToInt32(bitisTar.Subtract(bas));
                    saatSayisi = 0;
                    TimeSpan cikar = bitisTar.Subtract(bas);
                    saatSayisi = Convert.ToInt32(cikar.TotalHours);



                    satir = satirIndeksBul(hatNo.ToString());
                    if (saatSayisi <= 168)
                    {
                        //MessageBox.Show(saatSayisi.ToString());
                        for (int i = 2; i <= saatSayisi * 2 + 1; i++)
                        {
                            if (firmaAdi == "TATİL")
                            {
                                dataGridView1[i, satir].Style.BackColor = HatRenkleri.kismenPasifleştirilenHatRengi;
                            }
                            
                            else if (dataGridView1[i, satir].Style.BackColor != HatRenkleri.haftalikTatilRengi && dataGridView1[i, satir].Style.BackColor !=HatRenkleri.ekTatilRengi)
                            {
                                dataGridView1[i, satir].Style.BackColor = renk[hatNo - 1];
                                siparisKodlari[satir, i] = siparisKodu;
                            }

                        }


                        k++;
                    }
                    else
                    {
                        // MessageBox.Show("2");
                        for (int i = 2; i < dataGridView1.ColumnCount; i++)
                        {
                            if (firmaAdi == "TATİL")
                            {
                                dataGridView1[i, satir].Style.BackColor = HatRenkleri.kismenPasifleştirilenHatRengi;
                            }
                           
                            else  if (dataGridView1[i, satir].Style.BackColor != HatRenkleri.haftalikTatilRengi && dataGridView1[i, satir].Style.BackColor != HatRenkleri.ekTatilRengi)
                            {
                                dataGridView1[i, satir].Style.BackColor = renk[hatNo - 1];
                                siparisKodlari[satir, i] = siparisKodu;
                            }

                        }
                        k++;


                    }

                }
               // SqlCommand sor2 = new SqlCommand("select * from siparis where baslangicTarihi between '" + bas.ToString("yyyy-MM-dd hh:mm:ss") + "' and '" + bitis.ToString("yyyy-MM-dd hh:mm:ss") + "'", veritabani.conn);
                command = "select * from siparis where baslangicTarihi between '" + bas.ToString("yyyy-MM-dd hh:mm:ss") + "' and '" + bitis.ToString("yyyy-MM-dd hh:mm:ss") + "'";
                SqlDataReader oku2 = fonksiyon.fonksiyonSorgu(command);

                while (oku2.Read())
                {
                    int j = 0;
                    int farkSaat;
                    int totalSaat;
                    siparisKodu = oku2["siparisKod"].ToString();
                    bitisTar = Convert.ToDateTime(oku2["bitisTarihi"]);
                    basTarihi = Convert.ToDateTime(oku2["baslangicTarihi"]);
                    TimeSpan cikar = basTarihi.Subtract(bas);
                    farkSaat = Convert.ToInt32(cikar.TotalHours);
                    totalSaat = Convert.ToInt32(oku2["toplamSure"]);
                    hatNo = Convert.ToInt32(oku2["kullanilacakHat"]);
                    // saatSayisi = Convert.ToInt32(bitisTar.Subtract(bas));
                    saatSayisi = 0;
                    //cikar = bitisTar.Subtract(bas);
                    // saatSayisi = Convert.ToInt32(cikar.TotalHours);
                    if (k == 18)
                        k = 0;
                    satir = satirIndeksBul(hatNo.ToString());
                    firmaAdi = oku2["firmaAdi"].ToString();

                    if ((168 - farkSaat) >= totalSaat)
                    {

                        for (int i = farkSaat * 2 + 3; j < totalSaat * 2 - 1; i++)
                        {
                            if (firmaAdi == "TATİL")
                            {
                                dataGridView1[i, satir].Style.BackColor = HatRenkleri.kismenPasifleştirilenHatRengi;
                                j++;
                            }
                           
                            else if (dataGridView1[i, satir].Style.BackColor != HatRenkleri.haftalikTatilRengi && dataGridView1[i, satir].Style.BackColor != HatRenkleri.ekTatilRengi)
                            {
                                dataGridView1[i, satir].Style.BackColor = renk[hatNo - 1];
                                j++;
                                siparisKodlari[satir, i] = siparisKodu;
                            }


                        }
                        k++;

                    }
                    else
                    {


                        //MessageBox.Show("total= "+totalSaat.ToString()+"  farkSa= "+farkSaat.ToString());
                        for (int i = farkSaat * 2 + 3; i < dataGridView1.ColumnCount; i++)
                        {
                            if (firmaAdi == "TATİL")
                            {
                                dataGridView1[i, satir].Style.BackColor = HatRenkleri.kismenPasifleştirilenHatRengi;
                            }
                             
                            else if (dataGridView1[i, satir].Style.BackColor != HatRenkleri.haftalikTatilRengi && dataGridView1[i, satir].Style.BackColor != HatRenkleri.ekTatilRengi)
                            {
                                dataGridView1[i, satir].Style.BackColor = renk[hatNo - 1];
                                siparisKodlari[satir, i] = siparisKodu;
                            }

                        }
                        k++;
                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                hata.hataMesajı = ex.Message;
                hata.hataKodu = "frmHaftalikPlan -hatRenkDoldur";
                hata.hataMesajiKaydet();

            }
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.uretimHattiTableAdapter.FillBy(this.genelDataSet.uretimHatti);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillBy1ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.uretimHattiTableAdapter.FillBy1(this.genelDataSet1.uretimHatti);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void lblUrunResmiGor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!fonksiyon.fonksiyonUrunResmiGor(lblUrunKod.Text)) {
                MessageBox.Show("Ürün Resmi açık durumda!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
            }
         
        }

        private void btnPnlkapat_Click(object sender, EventArgs e)
        {
            pnlSiparisDetay.Visible = false;
            dataGridView1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pnlTatilAciklamasi.Visible = false;
            //dataGridView1.Enabled = true;
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            pnlTatilAciklamasi.Visible = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!fonksiyon.fonksiyonUrunResmiGor(lblUrunKod.Text))
            {
                MessageBox.Show("Ürün Resmi açık durumda!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void btnOncekiGun_Click_2(object sender, EventArgs e)
        {
            DateTime dt = radCalendar1.SelectedDate;
            dt=dt.AddDays(-7);
            haftaBasi= fonksiyonHaftaBasiBul(dt);
            radCalendar1.SelectedDate =haftaBasi;
        }

        private void btnSonraki_Click(object sender, EventArgs e)
        {
            DateTime dt = radCalendar1.SelectedDate;
            dt = dt.AddDays(7);
            haftaBasi = fonksiyonHaftaBasiBul(dt);
            radCalendar1.SelectedDate = haftaBasi;
        }

        private void btnBugun_Click_1(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            haftaBasi = fonksiyonHaftaBasiBul(dt);
            radCalendar1.SelectedDate = haftaBasi;
        }

    }
}
