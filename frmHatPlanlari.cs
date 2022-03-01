using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using uretimPlanlamaProgrami.RadFormlari;
using Microsoft.Office.Interop.Excel;
using System.IO;
namespace uretimPlanlamaProgrami
{
    public partial class frmHatPlanlari : Form
    {
        string gelenUrunKodu,siparisKodu,firmaAdi;
        string[,] siparisKodlari;
        int saatTotal,hammadde,renk;
        long adet, boy;
        float gerekliUrunMiktari;
        public bool eklemeBasariliMi = false;
        public frmHatPlanlari(string urunKodu,int saatTotal,long adet,long boy,string siparisKodu,string firmaAdi,int hammadde,int renk,float gerekliUrunMiktari)
        {
            InitializeComponent();
            this.gelenUrunKodu = urunKodu;
            this.saatTotal = saatTotal;
            this.adet = adet;
            this.boy = boy;
            this.siparisKodu = siparisKodu;
            this.firmaAdi = firmaAdi;
            this.hammadde = hammadde;
            this.renk = renk;
            this.gerekliUrunMiktari = gerekliUrunMiktari;
        }
        int ilk = 0;
        int oncekiSatir;
        int oncekiSutun;
        HatRenkleri HatRenkleri = new HatRenkleri();
        private void frmHatPlanlari_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'genelDataSet.urunUretimHatlari' table. You can move, or remove it, as needed.
          //  this.urunUretimHatlariTableAdapter.Fill(this.genelDataSet.urunUretimHatlari);
            // TODO: This line of code loads data into the 'genelDataSet.urunUretimHatlari' table. You can move, or remove it, as needed.
            veritabani.baglan();

            Fonksiyonlar fonksiyon = new Fonksiyonlar();
            string command =" select * from urunUretimHatlari ur,uretimHatti u where u.numara=ur.hatNo and ur.urunKod='"+gelenUrunKodu+"' and u.kullanilabilirmi=1";
            pnlCollapsiblePanel.Visible = false;
            SqlCommand getir = new SqlCommand(command, veritabani.conn);
            SqlDataAdapter da = new SqlDataAdapter(getir);
            System.Data.DataTable dt = new System.Data.DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

         

            //urunUretimHatlariBindingSource.Filter = "urunKod=" + gelenUrunKodu;
            //this.urunUretimHatlariTableAdapter.Fill(this.genelDataSet.urunUretimHatlari);
       
            
          
            
      
           
            pnlSiparisDetay.Visible = false;
           
            dtGridSutunDoldur();
            for (int i = 1; i <= dataGridView1.ColumnCount - 1; i++)
            {
                for (int j = 0; j <= dataGridView1.RowCount - 1; j++)
                {
                    dataGridView1[i, j].Style.BackColor = Color.White;
                }


            }

            lblTarih.Text = String.Format("{0:D}",DateTime.Now);

            dataGridDoldur(DateTime.Now);
            
        }

        //KULLANILMAYAN FONKSİYON
        public void pasifHattiBoya()
        {
            int hatNo;
            DateTime bas, bitis;
            int kacSaat, basSaat, bitSaat, hatNumarasi;
            //MessageBox.Show(datetimepicker1.ToShortDateString());
            SqlCommand sor = new SqlCommand("select * from HatPasifTarihleri where pasifBasShortDate='" + radCalendar1.SelectedDate.ToShortDateString() + "' or (pasifBaslangicTarihi<'" + radCalendar1.SelectedDate + "' and pasifBitisTarihi>'" + radCalendar1.SelectedDate + "') ", veritabani.conn);
            SqlDataReader oku = sor.ExecuteReader();
            while (oku.Read())
            {
                bas = Convert.ToDateTime(oku["pasifBaslangicTarihi"]);
                bitis = Convert.ToDateTime(oku["pasifBitisTarihi"]);
                kacSaat = Convert.ToInt32(oku["saat"]);
                basSaat = bas.Hour;
                bitSaat = bitis.Hour;
                hatNumarasi = Convert.ToInt32(oku["hatNo"]);

                satir = satirIndeksBul(hatNumarasi.ToString());
                if (bas.ToShortDateString() == radCalendar1.SelectedDate.ToShortDateString() && bitis.ToShortDateString() == radCalendar1.SelectedDate.ToShortDateString())
                {

                    for (int i = (basSaat * 2 + 3); i < (basSaat * 2 + 3) + kacSaat * 2; i++)
                    {

                        dataGridView1[i, satir].Style.BackColor = Color.Black;
                        //siparisKodlari[satir, i] = siparisKodu;

                    }
                }
                else if (radCalendar1.SelectedDate.ToShortDateString() == bitis.ToShortDateString())
                {

                    for (int i = 3; i <= (bitSaat * 2 + 3); i++)
                    {

                        dataGridView1[i, satir].Style.BackColor = Color.Black;
                        //siparisKodlari[satir, i] = siparisKodu;

                    }


                }
                else if (bas.ToShortDateString() == radCalendar1.SelectedDate.ToShortDateString() && bitis.ToShortDateString() != radCalendar1.SelectedDate.ToShortDateString())
                {
                    for (int i = (basSaat * 2 + 3); i < dataGridView1.ColumnCount - 1; i++)
                    {

                        dataGridView1[i, satir].Style.BackColor = Color.Black;
                        //siparisKodlari[satir, i] = siparisKodu;

                    }

                }


            }


        }

        public void dtGridSutunDoldur()
        {
            try
            {
               
                for (int i = 1; i < 51; i++)
                {
                   
                    dataGridView1.Columns[i].Width = 60;
                 
                }

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Height = 50;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hata.hataMesajı = ex.Message;
                hata.hataKodu = "frnGunlukPlan -dtGridSutunDoldur";
                hata.hataMesajiKaydet();

            }    
        }

      
        public void dataGridDoldur(DateTime simdi)
        {
            int hatno;
            
           
            //RENKLER
            if (!tatilGununuSiyahYap(simdi))
            {
                #region
                try
                   
                {
                    Color[] renk = new Color[18];

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

                #endregion
                    veritabani.baglan();

                    #region

                    
                    string siparisKodu,firmaAdi;

                    int yyyy;
                    int mon;
                    int d;
                    int h;
                    int min;
                    int seco;
                    yyyy = simdi.Year;
                    mon = simdi.Month;
                    d = simdi.Day;
                    h = 00;
                    min = 00;
                    seco = 00;
                    int satir;
                 
                   
                    DateTime simdiFormatli = new DateTime(yyyy, mon, d, h, min, seco);
                    DateTime simdiFormatsiz = new DateTime(yyyy, mon, d, h, min, seco);
                    //MessageBox.Show(simdi.ToShortDateString());
                    //BİRİNCİ SEÇENEK BAŞLANGIÇ TARİHİ BUGUNDEN ÖNDE OLMASI,BİTİS TARİHİ BUGÜNÜN İÇİNDE OLMASI
                    //İKİNCİ SECENEK BAŞLANIGÇ TARİHİ BUGUNDEN ONDE OLMASI,BİTİS TARİHİ BUGÜNÜN DIŞINDA OLMASI
                    //ÜÇÜNÜ SEÇENEK BAŞLANGIÇ TARİHİ BUGUNUN İÇİNDE OLMASI BİTİŞ TARİHİ BUGÜNÜN İÇİNDE OLMASI
                    //DÖRDÜNCÜ SEÇENEK BAŞLANGIÇ TARİHİ BUGUNN İÇİNDE ,BİTİŞ TARİHİ BUGÜNÜN DIŞINDA OLMASI
                    #endregion

                    SqlCommand sorSayi = new SqlCommand("select count(HatNo) from urunUretimHatlari where urunKod='" + gelenUrunKodu + "'", veritabani.conn);
                    int sayi = Convert.ToInt32(sorSayi.ExecuteScalar());


                    siparisKodlari = new string[sayi, dataGridView1.ColumnCount];
                    for (int i = 0; i < sayi; i++)
                    {

                        for (int j = 1; j < dataGridView1.ColumnCount; j++)
                        {
                            siparisKodlari[i, j] = "*";

                        }

                    }
                    string bitTarih = simdiFormatli.ToShortDateString();
                    //BİRİNCİ 
                    SqlCommand sor1 = new SqlCommand("select * from siparis where baslangicTarihi<@simdiFormatli and bitTarih=@bitTarih and kullanilacakHat in(select HatNo from urunUretimHatlari where urunKod=@urunKod)", veritabani.conn);
                    sor1.Parameters.Clear();
                    sor1.Parameters.AddWithValue("@simdiFormatli", simdiFormatli);
                    sor1.Parameters.AddWithValue("@bitTarih", simdiFormatli.ToShortDateString());
                    sor1.Parameters.AddWithValue("@urunKod", gelenUrunKodu);
                    SqlDataReader oku1 = sor1.ExecuteReader();

                    while (oku1.Read())
                    {

                        int bitSaat = Convert.ToInt32(oku1["bitSaat"]);
                        hatno = Convert.ToInt32(oku1["kullanilacakHat"]);
                        satir = satirIndeksBul(hatno.ToString());
                        siparisKodu = oku1["siparisKod"].ToString();
                        firmaAdi=oku1["firmaAdi"].ToString();
                        for (int i = 3; i < (bitSaat * 2 + 2); i++)
                        {

                            if (firmaAdi == "TATİL")
                            {
                                dataGridView1[i, satir].Style.BackColor = HatRenkleri.kismenPasifleştirilenHatRengi;

                            }
                            else
                            {
                                dataGridView1[i, satir].Style.BackColor = renk[satir];
                                siparisKodlari[satir, i] = siparisKodu;
                            }
                        }


                    }



                    //İKİNCİ

                    SqlCommand sor2;
                    sor2 = new SqlCommand();
                    sor2.Connection = veritabani.conn;
                    sor2.CommandText = "select * from siparis where  baslangicTarihi>=@simdiFormatli and kullanilacakHat in(select HatNo from urunUretimHatlari where urunKod=@urunKod)";
                    sor2.Parameters.Clear();
                    sor2.Parameters.AddWithValue("@simdiFormatli", simdiFormatli);
                    sor2.Parameters.AddWithValue("@urunKod", gelenUrunKodu);
                    //sor2.Parameters.AddWithValue("@bitTarih",simdiFormatli.ToShortDateString());

                    SqlDataReader oku2 = sor2.ExecuteReader();

                    while (oku2.Read())
                    {
                        string baslangicTarih = Convert.ToDateTime(oku2["baslangicTarihi"]).ToShortDateString();
                        bitTarih = oku2["bitTarih"].ToString();
                        DateTime bitisTarihi = Convert.ToDateTime(oku2["bitisTarihi"]);
                        int basSaat = Convert.ToDateTime(oku2["baslangicTarihi"]).Hour;
                        int bitSaat = Convert.ToInt32(oku2["bitSaat"]);
                        hatno = Convert.ToInt32(oku2["kullanilacakHat"]);
                        firmaAdi = oku2["firmaAdi"].ToString();
                        siparisKodu = oku2["siparisKod"].ToString();
                        satir = satirIndeksBul(hatno.ToString());


                        if (baslangicTarih == simdiFormatli.ToShortDateString() && bitTarih == simdiFormatli.ToShortDateString())
                        {
                            for (int i = (basSaat * 2 + 3); i < (bitSaat * 2 + 2); i++)
                            {
                                if (firmaAdi == "TATİL")
                                {
                                    dataGridView1[i, satir].Style.BackColor = HatRenkleri.kismenPasifleştirilenHatRengi;

                                }
                                else
                                {
                                    dataGridView1[i, satir].Style.BackColor = renk[satir];
                                    siparisKodlari[satir, i] = siparisKodu;
                                }
                            }



                        }
                        else if (baslangicTarih == simdiFormatli.ToShortDateString())
                        {

                            for (int i = (basSaat * 2 + 3); i < (dataGridView1.ColumnCount - 2); i++)
                            {
                                if (firmaAdi == "TATİL")
                                {
                                    dataGridView1[i, satir].Style.BackColor = HatRenkleri.kismenPasifleştirilenHatRengi;

                                }
                                else
                                {
                                    dataGridView1[i, satir].Style.BackColor = renk[satir];
                                    siparisKodlari[satir, i] = siparisKodu;
                                }
                            }


                        }




                    }
                    //ÜÇÜNCÜ
                    //ÜÇÜNCÜ
                    SqlCommand sor3 = new SqlCommand("select * from siparis where baslangicTarihi<@simdiFormatli and bitisTarihi>@simdiFormatli and bitTarih!=@bitTarih and kullanilacakHat in(select HatNo from urunUretimHatlari where urunKod=@urunKod)", veritabani.conn);
                    sor3.Parameters.Clear();
                    sor3.Parameters.AddWithValue("@simdiFormatli", SqlDbType.DateTime).Value = simdiFormatli;
                    sor3.Parameters.AddWithValue("@bittarih", simdiFormatli.ToShortDateString());
                    sor3.Parameters.AddWithValue("@urunKod", gelenUrunKodu);
                    SqlDataReader oku3 = sor3.ExecuteReader();
                    while (oku3.Read())
                    {


                        hatno = Convert.ToInt32(oku3["kullanilacakHat"]);
                        satir = satirIndeksBul(hatno.ToString());
                        siparisKodu = oku3["siparisKod"].ToString();
                        firmaAdi = oku3["firmaAdi"].ToString();
                        for (int i = 3; i < dataGridView1.ColumnCount - 2; i++)
                        {
                            if (firmaAdi == "TATİL")
                            {
                                dataGridView1[i, satir].Style.BackColor = HatRenkleri.kismenPasifleştirilenHatRengi;

                            }

                            else if (dataGridView1[i, satir].Style.BackColor != HatRenkleri.haftalikTatilRengi)
                            {
                                dataGridView1[i, satir].Style.BackColor = renk[satir];
                                siparisKodlari[satir, i] = siparisKodu;
                            }
                            else if (dataGridView1[i + 1, satir].Style.BackColor != HatRenkleri.haftalikTatilRengi)
                                i = i + 1;
                        }


                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    hata.hataMesajı = ex.Message;
                    hata.hataKodu = "frnGunlukPlan -dataGridDoldur";
                    hata.hataMesajiKaydet();
                   
                }    
            }

        }
        bool tatilGunumu;
        public bool tatilGununuSiyahYap(DateTime seciliTarih)
        {
            
            veritabani.baglan();
          
           
            try
            {
                DateTime oncekiGun = seciliTarih.AddDays(-1);
                tatilGunumu = false;
                string seciliGun = String.Format("{0:dddd}", seciliTarih);
                string oncekiGunAdi = String.Format("{0:dddd}", oncekiGun);
                string gun = "";


                string[] gunler = { "PAZARTESİ", "SALI", "ÇARŞAMBA", "PERŞEMBE", "CUMA", "CUMARTESİ", "PAZAR" };


               
                veritabani.baglan();
                Day day;

                

                SqlCommand sor = new SqlCommand("select tatilGunu from Ayarlar", veritabani.conn);
                SqlDataReader oku = sor.ExecuteReader();
                if (oku.Read())
                {
                    gun = oku["tatilGunu"].ToString();

                    if (gun == seciliGun.ToUpper())
                    {
                        tatilGunumu = true;
                        for (int i = 0; i < dataGridView1.RowCount; i++)
                        {
                            for (int j = 2; j < dataGridView1.ColumnCount - 1; j++)
                            {

                                dataGridView1[j, i].Style.BackColor = HatRenkleri.haftalikTatilRengi;

                            }


                        }


                    }

                }

                if (oncekiGunAdi.ToUpper() == gun) {
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        for (int j = 2; j < 18; j++)
                        {

                            dataGridView1[j, i].Style.BackColor = HatRenkleri.haftalikTatilRengi;

                        }
                    }
                    
                
                }


                //Pazartesi için yapıldı Kaldırılabilir
                if (seciliTarih.DayOfWeek == DayOfWeek.Monday)
                {

                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        for (int j = 2; j < 18; j++)
                        {

                            dataGridView1[j, i].Style.BackColor = HatRenkleri.haftalikTatilRengi;

                        }


                    }

                }


                SqlCommand sor2 = new SqlCommand("select tarih from TatilGunleri where tarih='" + radCalendar1.SelectedDate.ToShortDateString() + "'", veritabani.conn);
                SqlDataReader oku2 = sor2.ExecuteReader();
                if (oku2.Read())
                {
                    tatilGunumu = true;
                    
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        for (int j = 2; j < dataGridView1.ColumnCount - 1; j++)
                        {

                            dataGridView1[j, i].Style.BackColor = HatRenkleri.ekTatilRengi;

                        }
                    }
                }
                if (!tatilGunumu)
                {
                    SqlCommand sor3 = new SqlCommand("select tarih from TatilGunleri where tarih='" + oncekiGun.ToShortDateString() + "'", veritabani.conn);
                    SqlDataReader oku3 = sor3.ExecuteReader();
                    if (oku3.Read())
                    {


                        for (int i = 0; i < dataGridView1.RowCount; i++)
                        {
                            for (int j = 2; j < 18; j++)
                            {

                                dataGridView1[j, i].Style.BackColor = HatRenkleri.ekTatilRengi;

                            }
                        }
                    }
                }
                
                return tatilGunumu;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hata.hataMesajı = ex.Message;
                hata.hataKodu = "frmHatPlanlari -tatilGununuSiyahYap";
                hata.hataMesajiKaydet();
                return tatilGunumu;

            }    
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
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hata.hataKodu = "frmHatPlanlari-satirIndedsBul";
                hata.hataMesajı = ex.Message;
                hata.hataMesajiKaydet();
                return -1;

            }

        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            for (int i = 1; i <= dataGridView1.ColumnCount - 1; i++)
            {
                for (int j = 0; j <= dataGridView1.RowCount - 1; j++)
                {
                    dataGridView1[i, j].Style.BackColor = Color.White;
                }


            }
            DateTime simdi = DateTime.Now;
           // dateTimePicker1.MinDate = simdi;

            DateTime value = radCalendar1.SelectedDate;

            if (value > DateTime.Now)
                btnOncekiGun.Enabled = true;
            else
                btnOncekiGun.Enabled = false;

            dataGridDoldur(value);
        }

        private void btnBugun_Click(object sender, EventArgs e)
        {
            radCalendar1.SelectedDate = DateTime.Now;
            
        }

        private void btnOncekiGun_Click(object sender, EventArgs e)
        {
            if (radCalendar1.SelectedDate > DateTime.Now)
                radCalendar1.SelectedDate = radCalendar1.SelectedDate.AddDays(-1);
            else
                btnOncekiGun.Enabled = false;
        }

        private void btnSonrakiGun_Click(object sender, EventArgs e)
        {
            radCalendar1.SelectedDate = radCalendar1.SelectedDate.AddDays(1);

        }
        string seciliSiparisKodu;
        int satir;
        int sutun;
        int hatno, x, y;
        ContextMenu cm;
        int simdininSaati = DateTime.Now.Hour;
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DateTime baslangicTarihi = radCalendar1.SelectedDate;
                int yyyy;
                int MM;
                int dd;
                yyyy = baslangicTarihi.Year;
                MM = baslangicTarihi.Month;
                dd = baslangicTarihi.Day;
                seciliSaat = e.ColumnIndex / 2 - 1;

                if (seciliSaat != 24 && e.ColumnIndex != 0)
                    baslangicTarihi = new DateTime(yyyy, MM, dd, seciliSaat, 0, 0);
                else
                {
                    MessageBox.Show("Geçersiz saat seçimi");
                    return;
                }
                DateTime simdi = DateTime.Now;
           
            
                satir = Convert.ToInt32(dataGridView1.CurrentCell.RowIndex);
                sutun = Convert.ToInt32(dataGridView1.CurrentCell.ColumnIndex);
                hatno = Convert.ToInt32(dataGridView1.Rows[satir].Cells[0].Value);
                //  MessageBox.Show(satir.ToString()+"  "+sutun.ToString());
                dataGridView1[sutun, satir].Style.SelectionBackColor = dataGridView1[sutun, satir].Style.BackColor;
                Color gozRengi = dataGridView1[sutun, satir].Style.BackColor;
                if (dataGridView1[sutun, satir].Style.BackColor != Color.White && sutun != 0 && gozRengi != HatRenkleri.haftalikTatilRengi && gozRengi != Color.Tomato && gozRengi!=HatRenkleri.ekTatilRengi)
                {
                    if (e.RowIndex != -1 && e.ColumnIndex != -1) // başlık yeri dışında bir satırsa
                    {
                        if (e.Button == MouseButtons.Left)
                        { //sag tuşbasıldıysa

                            seciliSiparisKodu = siparisKodlari[satir, sutun];

                            var mouseninyeri = dataGridView1.PointToClient(Cursor.Position);
                          
                            cm = new ContextMenu();
                            
                            System.Windows.Forms.MenuItem m1 = new System.Windows.Forms.MenuItem("Sipariş Detayları");

                            cm.MenuItems.Add(m1);
                            m1.Click += new EventHandler(m1_Click);
                           
                           

                            if (e.ColumnIndex % 2 == 0 && dataGridView1[sutun-1,satir].Style.BackColor==Color.White &&  baslangicTarihi>=simdi) {
                                System.Windows.Forms.MenuItem m2 = new System.Windows.Forms.MenuItem("Siparişin Başlangıç Saati Yap");

                                cm.MenuItems.Add(m2);
                                m2.Click += new EventHandler(m2_Click);
                            
                            }

                            cm.Show(dataGridView1, mouseninyeri);

                            //tıklanan hücrede menu açma

                        }
                    }
                }
                else if (gozRengi != HatRenkleri.haftalikTatilRengi &&gozRengi!=HatRenkleri.ekTatilRengi && gozRengi!=HatRenkleri.kismenPasifleştirilenHatRengi && gozRengi!=HatRenkleri.tamamenPasiflestirilenHatRengi && sutun != 0)
                {

                    if (e.RowIndex != -1 && e.ColumnIndex != -1 && e.ColumnIndex % 2 == 0 && baslangicTarihi >= simdi)
                    {
                       
                        if (e.Button == MouseButtons.Left)
                        {
                            cm = new ContextMenu();
                            var mouseninyeri = dataGridView1.PointToClient(Cursor.Position);
                            System.Windows.Forms.MenuItem m2 = new System.Windows.Forms.MenuItem("Siparişin Başlangıç Saati Yap");
                            cm.MenuItems.Clear();
                            cm.MenuItems.Add(m2);
                            m2.Click += new EventHandler(m2_Click);

                            cm.Show(dataGridView1, mouseninyeri);

                        }


                    }


                }
                

               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hata.hataKodu = "frmHatPlanlari-dataGridView1_CellMouseClick";
                hata.hataMesajı = ex.Message;
                hata.hataMesajiKaydet();

            }
        }
        int seciliSaat=-1,seciliHatNo;

        Fonksiyonlar fonksiyon = new Fonksiyonlar();
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
               
                yyyy = simdi.Year;
                mon = simdi.Month;
                d = simdi.Day;
                h = simdi.Hour;
                min = simdi.Minute;
               
                DateTime simdiFormatli = new DateTime(yyyy, mon, d, h, min, 00);
                //Sipariş detayları
                veritabani.baglan();
                if (siparisKodlari[satir, sutun] != "*" && sutun != 0)
                {

                    

                   pnlSiparisDetay.Visible = true;

                    dataGridView1.Enabled = false;

                    dataGridView1.Enabled = false;
                    btnBugun.Enabled = false;
                    btnSonrakiGun.Enabled = false;
                    btnOncekiGun.Enabled = false;
                    radCalendar1.Enabled = false;

                    SqlCommand siparis = new SqlCommand("select * from siparis s,hammadde h,renkler r where s.hammadde=h.id and s.renk=r.id and siparisKod='" + seciliSiparisKodu + "'", veritabani.conn);
                    SqlDataReader siparisOku = siparis.ExecuteReader();
                   // string command = "select * from siparis s,hammadde h,renkler r where s.hammadde=h.id and s.renk=r.id and siparisKod='" + seciliSiparisKodu + "'";
                   //List<ClassSiparis> liste= fonksiyon.fonksiyonSiparisSorgu(command);
                   //radfrmSiparisDetayi radfrmSiparisDetayi = new radfrmSiparisDetayi(seciliSiparisKodu);
                   //radfrmSiparisDetayi.Show();
                    if (siparisOku.Read())
                    {
                        

                        lblHammadde.Text = siparisOku["adi"].ToString();
                        lblKayitTarihi.Text = "" + String.Format("{0:f}", Convert.ToDateTime(siparisOku["kayitTarihi"]));
                        lblRenk.Text = siparisOku["renkAdi"].ToString();
                        lblFirmaAdi.Text = siparisOku["firmaAdi"].ToString();
                        // lblBoy.Text = siparisOku["boy"].ToString() + " milimetre"
                        lblBoy.Text = "" + String.Format("{0:0,0}", Convert.ToInt32(siparisOku["boy"])) + " milimetre";
                        lblAdet.Text = "" + String.Format("{0:0,0}", Convert.ToInt32(siparisOku["adet"]));
                        devamDurumu = Convert.ToInt16(siparisOku["devamDurumu"]);
                        lblSiparisKodu.Text = siparisOku["siparisKod"].ToString();
                        lblBaslangıçTarihi.Text = "" + String.Format("{0:f}", Convert.ToDateTime(siparisOku["baslangicTarihi"]));
                        lblBitisTarihi.Text = "" + String.Format("{0:f}", Convert.ToDateTime(siparisOku["bitisTarihi"]));
                        lblUrunKod.Text = siparisOku["urunKod"].ToString();
                        lblHatNO.Text = siparisOku["kullanilacakHat"].ToString();
                        int toplamSure = Convert.ToInt32(siparisOku["toplamSure"]);
                        lblGerekliUrunMiktari.Text = String.Format("{0:0,0}", Convert.ToInt32(siparisOku["gerekenUrunMiktari"])/1000) + " kg";
                        lblIsSure.Text = "" + String.Format("{0:0,0}",toplamSure);
                       
                        lblToplamSure.Text = "" + String.Format("{0:0,0}", Convert.ToDecimal(siparisOku["tatilDahilSure"])) + " SAAT";
                        
                        

                        if (devamDurumu == 2)
                        {
                            lblKalan.Text = "% 0";
                            lblIslenen.Text = "% 100";
                            progIslenenn.Value = 0;
                            progIslenenn.Minimum = 0;
                            progIslenenn.Maximum = toplamSure * 60;
                            progIslenenn.Step = 1;
                            while (progIslenenn.Value != toplamSure * 60)
                            {
                                progIslenenn.Value = progIslenenn.Value += 1;

                            }

                        }

                        else if (devamDurumu == 1)
                        {
                            int kalanDakka = Convert.ToInt32(Convert.ToDateTime(siparisOku["bitisTarihi"]).Subtract(simdiFormatli).TotalMinutes);
                            int kalan = (100 * kalanDakka) / (toplamSure * 60);
                            int Islenen = (100 - (((100 * kalanDakka) / (toplamSure * 60))));
                            lblKalan.Text = "% " + ((100 * kalanDakka) / (toplamSure * 60)).ToString();
                            lblIslenen.Text = "% " + (100 - (((100 * kalanDakka) / (toplamSure * 60)))).ToString();
                            progIslenenn.Minimum = 0;
                            progIslenenn.Value = kalan;
                            progIslenenn.Maximum = 100;
                            progIslenenn.Step = 1;
                            if (progIslenenn.Value != 100)
                            {
                                progIslenenn.Value = Islenen;

                            }

                        }
                        else
                        {

                            lblIslenen.Text = "% 0";
                            lblKalan.Text = "% 100";
                            progIslenenn.Value = 0;

                        }

                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hata.hataKodu = "frmHatPlanlari-m1_Click";
                hata.hataMesajı = ex.Message;
                hata.hataMesajiKaydet();

            }
        }
        int bir = 0;
        private void m2_Click(object sender, EventArgs e)
        {
            try
            {
                if (bir == 0)
                {
                    dataGridView1[sutun, satir].Style.BackColor = Color.Tomato;
                    oncekiSatir = satir;
                    oncekiSutun = sutun;
                    seciliSaat = sutun / 2 - 1;
                    seciliHatNo = Convert.ToInt32(dataGridView1[0, satir].Value);
                    bir = 1;

                }
                else if (bir == 1)
                {
                    dataGridView1[oncekiSutun, oncekiSatir].Style.BackColor = Color.White;
                    oncekiSatir = satir;
                    oncekiSutun = sutun;
                    seciliSaat = sutun / 2 - 1;
                    dataGridView1[sutun, satir].Style.BackColor = Color.Tomato;
                    seciliHatNo = Convert.ToInt32(dataGridView1[0, satir].Value);

                }

                pnlCollapsiblePanel.Visible = true;
                DateTime baslangicTarihi = radCalendar1.SelectedDate;
                int yyyy;
                int MM;
                int dd;
                yyyy = baslangicTarihi.Year;
                MM = baslangicTarihi.Month;
                dd = baslangicTarihi.Day;
                baslangicTarihi = new DateTime(yyyy, MM, dd, seciliSaat, 0, 0);
                lblCollasableBaslangicTarihi.Text = String.Format("{0:f}",baslangicTarihi);
                lblCollasableHatNo.Text = "HAT  "+seciliHatNo.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hata.hataKodu = "frmHatPlanlari-m2_Click";
                hata.hataMesajı = ex.Message;
                hata.hataMesajiKaydet();

            }

        }

        private void btnPnlkapat_Click(object sender, EventArgs e)
        {
            pnlSiparisDetay.Visible = false;
            dataGridView1.Enabled = true;
            btnBugun.Enabled = true;
            btnOncekiGun.Enabled = true;
            btnSonrakiGun.Enabled = true;
            radCalendar1.Enabled = true;
        }
        radOzelSiparisEkle nesneOzel = new radOzelSiparisEkle();
        radNormalSiparisEkle nesneNormal = new radNormalSiparisEkle();
        hatalar hata = new hatalar();
        string okunanUrunKod, okunanSiparisKodu, oncekiUrunKod;
        int okunanToplamSure;
        DateTime okunanBitisTarihi, okunanBaslangicTarihi;
   
        private void btnSeciliSaatiAta_Click(object sender, EventArgs e)
        {
            try
            {

                DateTime bitisTarihi, Hesaplanan;

                DateTime baslangicTarihi = radCalendar1.SelectedDate;
                int yyyy;
                int MM;
                int dd;
                yyyy = baslangicTarihi.Year;
                MM = baslangicTarihi.Month;
                dd = baslangicTarihi.Day;

                DialogResult cevap;
                if (seciliSaat == -1)
                {
                    MessageBox.Show("Başlangıç Tarihini ve Saatini seçmediniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                baslangicTarihi = new DateTime(yyyy, MM, dd, seciliSaat, 0, 0);

                cevap = MessageBox.Show("Siparişin; \nBAŞLANGIÇ TARİHİ=" + String.Format("{0:f}", baslangicTarihi) + " \n KULLANILACAK HAT NUMARASI=" + seciliHatNo.ToString() + "\n Bu işlemi onaylıyor musunuz?", "ONAY", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes)
                {

                    SqlCommand sorOnceki = new SqlCommand("select top 1 * from siparis where bitisTarihi<=@bitisTarihi and kullanilacakHat=@kullanilacakHat order by bitisTarihi desc", veritabani.conn);
                    sorOnceki.Parameters.Clear();
                    sorOnceki.Parameters.AddWithValue("@bitisTarihi", baslangicTarihi);
                    sorOnceki.Parameters.AddWithValue("@kullanilacakHat", hatno);
                    SqlDataReader okuOnceki = sorOnceki.ExecuteReader();

                    if (okuOnceki.Read())
                    {
                        string SonrakiSiparisKodu = "";
                        string okunanUrunKod = okuOnceki["urunKod"].ToString();


                        if (okuOnceki["sonrakiSiparisKodu"].ToString() != "")
                            SonrakiSiparisKodu = okuOnceki["sonrakiSiparisKodu"].ToString();


                        fonksiyonSonrakiSiparisKoduIcinSiparisGuncelle(okuOnceki["siparisKod"].ToString(), siparisKodu);

                        if (okunanUrunKod != gelenUrunKodu && okuOnceki["bitTarih"].ToString() == baslangicTarihi.ToShortDateString() && seciliSaat - Convert.ToInt32(okuOnceki["bitSaat"]) < 2)
                        {
                            DialogResult cevap1;
                            cevap1 = MessageBox.Show("Seçtiğiniz saatten hemen önce ürün kodu farklı bir sipariş mevcut. Diğer siparişin başlaması için en az iki saatlik bir hazırlık evresi gerekir.Sistemin otomatik ayarlama yapmasını istermisiniz?", "UYARI", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                            if (cevap1 == DialogResult.Yes)
                                baslangicTarihi = baslangicTarihi.AddHours(2 - (seciliSaat - Convert.ToInt32(okuOnceki["bitSaat"])));


                        }

                        //Hesaplanan = nesneNormal.fonksiyonTatilGunuVarsaGec(baslangicTarihi, saatTotal);
                     Hesaplanan= fonksiyon.fonksiyonSiparisBitisTarihiBul(baslangicTarihi, saatTotal);
                        nesneOzel.fonksiyonSiparisEkle(siparisKodu, firmaAdi, gelenUrunKodu, "OZEL", adet, boy, gerekliUrunMiktari, hammadde, renk, baslangicTarihi, Hesaplanan, saatTotal, hatno, 3, Hesaplanan);
                        if (SonrakiSiparisKodu != "")
                            fonksiyonSonrakiSiparisKoduIcinSiparisGuncelle(siparisKodu, SonrakiSiparisKodu);
                        oncekiUrunKod = gelenUrunKodu;
                        okunanBitisTarihi = Hesaplanan;
                        okunanSiparisKodu = siparisKodu;

                        while (SonrakiSiparisKodu != "")
                        {
                            #region
                            veritabani.baglan();

                            SqlCommand sonrakiSiparisBilgileriniOku = new SqlCommand("select * from siparis where siparisKod='" + SonrakiSiparisKodu + "'", veritabani.conn);
                            SqlDataReader okuSonrakibilgi = sonrakiSiparisBilgileriniOku.ExecuteReader();

                            if (okuSonrakibilgi.Read())
                            {
                                okunanUrunKod = okuSonrakibilgi["urunKod"].ToString();
                                if (oncekiUrunKod != okunanUrunKod)
                                    okunanBitisTarihi = okunanBitisTarihi.AddHours(2);

                                SonrakiSiparisKodu = okuSonrakibilgi["sonrakiSiparisKodu"].ToString();
                                okunanSiparisKodu = okuSonrakibilgi["siparisKod"].ToString();
                                okunanToplamSure = Convert.ToInt32(okuSonrakibilgi["toplamSure"]);



                                oncekiUrunKod = okunanUrunKod;

                                if (nesneNormal.baslangictarihiTatileDenkGeliyormu(okunanBitisTarihi))
                                {
                                    int hour;
                                    okunanBitisTarihi = okunanBitisTarihi.AddDays(1);
                                    yyyy = okunanBitisTarihi.Year;
                                    MM = okunanBitisTarihi.Month;
                                    dd = okunanBitisTarihi.Day;
                                    hour = okunanBitisTarihi.Hour;
                                    okunanBitisTarihi = new DateTime(yyyy, MM, dd, 00, 00, 00);

                                }
                                okunanBaslangicTarihi = okunanBitisTarihi;
                              //  okunanBitisTarihi = nesneNormal.fonksiyonTatilGunuVarsaGec(okunanBitisTarihi, okunanToplamSure);
                                okunanBitisTarihi = fonksiyon.fonksiyonSiparisBitisTarihiBul(okunanBitisTarihi, okunanToplamSure);

                                SqlCommand onemsizGuncelle1 = new SqlCommand();
                                onemsizGuncelle1.Connection = veritabani.conn;
                                onemsizGuncelle1.CommandText = "update siparis set baslangicTarihi=@baslangicTarihi,bitisTarihi=@bitisTarihi,bitTarih=@bitTarih,bitSaat=@bitSaat where siparisKod=@siparisKod";
                                onemsizGuncelle1.Parameters.Clear();
                                onemsizGuncelle1.Parameters.AddWithValue("@baslangicTarihi", okunanBaslangicTarihi);
                                onemsizGuncelle1.Parameters.AddWithValue("@bitisTarihi", okunanBitisTarihi);
                                onemsizGuncelle1.Parameters.AddWithValue("@bitTarih", okunanBitisTarihi.ToShortDateString());
                                onemsizGuncelle1.Parameters.AddWithValue("@bitSaat", okunanBitisTarihi.Hour);
                                onemsizGuncelle1.Parameters.AddWithValue("@siparisKod", okunanSiparisKodu);
                                onemsizGuncelle1.ExecuteNonQuery();


                            }



                            #endregion

                        }
                        nesneNormal.fonksiyonHatBitisTarihiGuncelle(okunanBitisTarihi, hatno, siparisKodu);



                    }
                    else
                    {

                        Hesaplanan = fonksiyon.fonksiyonSiparisBitisTarihiBul (baslangicTarihi, saatTotal);
                       // Hesaplanan = fonksiyon.fonksiyonSiparisBitisTarihiBul(baslangicTarihi, saatTotal);
                        nesneOzel.fonksiyonSiparisEkle(siparisKodu, firmaAdi, gelenUrunKodu, "OZEL", adet, boy, gerekliUrunMiktari, hammadde, renk, baslangicTarihi, Hesaplanan, saatTotal, hatno, 3, Hesaplanan);
                        nesneNormal.fonksiyonHatBitisTarihiGuncelle(Hesaplanan, hatno, siparisKodu);
                        nesneNormal.fonksyionUretimHattiAktiflestirme(hatno);
                    }

                    dataGridView1[sutun, satir].Style.BackColor = Color.White;
                    dataGridDoldur(radCalendar1.SelectedDate);

                    MessageBox.Show("Sipariş başarıyla eklendi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.Close();
                    radSiparisOzeti radSiparisOzeti = new radSiparisOzeti(baslangicTarihi, Hesaplanan, DateTime.Now, siparisKodu, gelenUrunKodu, saatTotal, adet, boy, firmaAdi, hammadde, renk, hatno, gerekliUrunMiktari);

                    radSiparisOzeti.Show();
                    eklemeBasariliMi = true;

                    siparisDegerleri siparisDegerleriNesne = new siparisDegerleri();
                    siparisDegerleriNesne.baslangic = baslangicTarihi;
                    siparisDegerleriNesne.bitis = Hesaplanan;
                    siparisDegerleriNesne.hatNo = hatno;
                    siparisDegerleriNesne.toplamSure = saatTotal;
                    siparisDegerleriNesne.gerekliUrunMiktari = gerekliUrunMiktari;




                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hata.hataKodu = "frmHatPlanlari-btnSeciliSaatiAta_Click";
                hata.hataMesajı = ex.Message;
                hata.hataMesajiKaydet();
                
            }
            
        }

        public void fonksiyonSonrakiSiparisKoduIcinSiparisGuncelle(string siparisKodu, string sonrakiSiparisKodu)
        {

            try
            {
                SqlCommand guncelle = new SqlCommand();
                guncelle.Connection = veritabani.conn;
                veritabani.baglan();
                guncelle.CommandText = "update siparis set sonrakiSiparisKodu=@sonrakiSiparisKodu where siparisKod=@siparisKod";
                guncelle.Parameters.Clear();
                guncelle.Parameters.AddWithValue("@sonrakiSiparisKodu", sonrakiSiparisKodu);
                guncelle.Parameters.AddWithValue("@siparisKod", siparisKodu);

                guncelle.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hata.hataKodu = "frmHatPlanlari-fonksiyonSonrakiSiparisKoduIcinSiparisGuncelle";
                hata.hataMesajı = ex.Message;
                hata.hataMesajiKaydet();

            }



        }

        private void btnExceleAktar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult cevap = MessageBox.Show("Bilgiler excele aktarılacak.", "BİLGİ", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                if (cevap == DialogResult.Yes)
                {
                    Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                    excel.Visible = true;
                    object Missing = Type.Missing;
                    Workbook workbook = excel.Workbooks.Add(Missing);
                    Worksheet sheet1 = (Worksheet)workbook.Sheets[1];
                    int StartCol = 1;
                    int StartRow = 1;
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        Range myRange = (Range)sheet1.Cells[StartRow, StartCol + j];
                        myRange.Value2 = dataGridView1.Columns[j].HeaderText;
                    }
                    StartRow++;
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {

                            Range myRange = (Range)sheet1.Cells[StartRow + i, StartCol + j];

                            if (dataGridView1[j, i].Style.BackColor != Color.White && j != 0)
                                myRange.Interior.Color = dataGridView1[j, i].Style.BackColor;
                            else
                                myRange.Value2 = dataGridView1[j, i].Value == null ? "" : dataGridView1[j, i].Value;


                            myRange.Select();


                        }
                    }

                }
                MessageBox.Show("Excele aktarım işlemi başarılı", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception)
            {


            }


        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {

        }


        public class siparisDegerleri{

            public DateTime baslangic { get; set; }
            public DateTime bitis { get; set; }
            public int hatNo { get; set; }
            public int toplamSure { get; set; }
            public float gerekliUrunMiktari { get; set; }
            
        
        }

        public void frmHatPlanlari_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

      

        private void radCalendar1_SelectionChanged(object sender, EventArgs e)
        {
            
            for (int i = 1; i <= dataGridView1.ColumnCount - 1; i++)
            {
                for (int j = 0; j <= dataGridView1.RowCount - 1; j++)
                {
                    dataGridView1[i, j].Style.BackColor = Color.White;
                }


            }
            DateTime simdi = DateTime.Now;
            // dateTimePicker1.MinDate = simdi;
            radCalendar1.RangeMinDate = simdi;
            DateTime value = radCalendar1.SelectedDate;

            if (value > DateTime.Now)
                btnOncekiGun.Enabled = true;
            else
                btnOncekiGun.Enabled = false;
            lblTarih.Text = String.Format("{0:D}",value);
            dataGridDoldur(value);
        }

        private void dataGridView1_CellMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        radUrunResimFormu radUrunResmiFormu;
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!fonksiyon.fonksiyonUrunResmiGor(lblUrunKod.Text))
            {
                MessageBox.Show("Ürün Resmi açık durumda!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
        
    }
}
