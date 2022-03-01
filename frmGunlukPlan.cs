using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Drawing.Text;
using System.Drawing.Drawing2D;
using System.IO;
using uretimPlanlamaProgrami.RadFormlari;
using System.Collections;


namespace uretimPlanlamaProgrami
{
    public partial class frmGunlukPlan : Form
    {
        public frmGunlukPlan()
        {
            InitializeComponent();
          
            
        }
        Fonksiyonlar fonksiyon = new Fonksiyonlar();
        HatRenkleri HatRenkleri = new HatRenkleri();
        ContextMenu cm;
        int ilk = 0;
        private void denemeGridview_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'planlamaDataSet6.uretimHatti' table. You can move, or remove it, as needed.
            try
            {
                this.uretimHattiTableAdapter.Fill(this.planlamaDataSet6.uretimHatti);

                pnlTatilAciklamasi.Visible = false;
                pnlSiparisDetay.Visible = false;


                sutunGenislikAyarla();

                Anasayfa n = new Anasayfa();
                this.Top = 200;
                this.Left = 0;
                //  this.uretimHattiTableAdapter.Fill(this.planlamaDataSet7.uretimHatti);
                // TODO: This line of code loads data into the 'planlamaDataSet6.uretimHatti' table. You can move, or remove it, as needed.




                this.Top = 100;

            }
            catch (Exception ex){ 
                  MessageBox.Show(ex.Message);
                hata.hataMesajı = ex.Message;
                hata.hataKodu = "frnGunlukPlan -denemeGridviewLoad";
                hata.hataMesajiKaydet();
            }

        }
        bool tatilGunumu=false;
        
        string tatilAciklamasi="";
        public bool tatilGununuSiyahYap(DateTime seciliTarih) {
            try
            {
                tatilGunumu = false;
                string seciliGun = String.Format("{0:dddd}", seciliTarih);
                string gun = "";


                string[] gunler = { "PAZARTESİ", "SALI", "ÇARŞAMBA", "PERŞEMBE", "CUMA", "CUMARTESİ", "PAZAR" };


              
                veritabani.baglan();
                Day day;
                bool tatilGunuVarmi = true;
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

                SqlCommand sor2 = new SqlCommand("select tarih,aciklama from TatilGunleri where tarih='" + dateTimePicker1.Value.ToShortDateString() + "'", veritabani.conn);
                SqlDataReader oku2 = sor2.ExecuteReader();
                if (oku2.Read())
                {
                   
                   tatilAciklamasi=oku2["aciklama"].ToString();
                   
                    tatilGunumu = true;
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        for (int j = 2; j < dataGridView1.ColumnCount - 1; j++)
                        {

                            dataGridView1[j, i].Style.BackColor = HatRenkleri.ekTatilRengi;

                        }
                    }
                }

             //   pasifHattiBoya();

                return tatilGunumu;

            }catch(Exception ex){
                MessageBox.Show(ex.Message);
                hata.hataMesajı = ex.Message;
                hata.hataKodu = "frnGunlukPlan -tatilGununuSiyahYap";
                hata.hataMesajiKaydet();
                return tatilGunumu;
            
            }    
                    
        }
        public void pasifHattiBoya()
        {
            int hatNo;
            DateTime bas, bitis;
            int kacSaat, basSaat, bitSaat, hatNumarasi;
            //MessageBox.Show(datetimepicker1.ToShortDateString());
            SqlCommand sor = new SqlCommand("select * from HatPasifTarihleri where pasifBasShortDate='" + dateTimePicker1.Value.ToShortDateString() + "' or (pasifBaslangicTarihi<'" + dateTimePicker1.Value + "' and pasifBitisTarihi>'" + dateTimePicker1.Value + "') ", veritabani.conn);
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
                if (bas.ToShortDateString() == dateTimePicker1.Value.ToShortDateString() && bitis.ToShortDateString() == dateTimePicker1.Value.ToShortDateString())
                {

                    for (int i = (basSaat * 2 + 3); i < (basSaat * 2 + 3) + kacSaat * 2; i++)
                    {

                        dataGridView1[i, satir].Style.BackColor = Color.Black;
                        //siparisKodlari[satir, i] = siparisKodu;

                    }
                }
                else if (dateTimePicker1.Value.ToShortDateString() == bitis.ToShortDateString())
                {

                    for (int i = 3; i <= (bitSaat * 2 + 3); i++)
                    {

                        dataGridView1[i, satir].Style.BackColor = Color.Black;
                        //siparisKodlari[satir, i] = siparisKodu;

                    }


                }
                else if (bas.ToShortDateString() == dateTimePicker1.Value.ToShortDateString() && bitis.ToShortDateString() != dateTimePicker1.Value.ToShortDateString())
                {
                    for (int i = (basSaat * 2 + 3); i < dataGridView1.ColumnCount - 1; i++)
                    {

                        dataGridView1[i, satir].Style.BackColor = Color.Black;
                        //siparisKodlari[satir, i] = siparisKodu;

                    }

                }


            }


        }
         

        public void sutunGenislikAyarla() {
            try
            {
                for (int i = 3; i < dataGridView1.ColumnCount; i = i + 2)
                {

                    dataGridView1.Columns[i].Width = 60;
                    dataGridView1.Columns[i - 1].Width = 60;

                }
                for (int i = 1; i <= dataGridView1.ColumnCount - 1; i++)
                {
                    for (int j = 0; j <= dataGridView1.RowCount - 1; j++)
                    {
                        dataGridView1[i, j].Style.BackColor = Color.White;
                    }


                }

            }catch(Exception ex){
                MessageBox.Show(ex.Message);
                hata.hataMesajı = ex.Message;
                hata.hataKodu = "frnGunlukPlan -sutunGenislikAyarla";
                hata.hataMesajiKaydet();
            }


        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public int satirIndeksBul(string searchValue){

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
            }catch(Exception ex){
                MessageBox.Show(ex.Message);
                hata.hataMesajı = ex.Message;
                hata.hataKodu = "frnGunlukPlan -satirIndexBul";
                hata.hataMesajiKaydet();
                return -1;
            }
        }

        string[,] siparisKodlari;
        public void dataGridDoldur(DateTime simdi) {
            try
            {
                ilk = 1;
                //RENKLER
                if (!tatilGununuSiyahYap(simdi))
                {
                    if (simdi.DayOfWeek == DayOfWeek.Monday)
                    {
                        for (int i = 0; i < dataGridView1.RowCount; i++)
                        {
                            for (int j = 2; j < 18; j++)
                            {

                                dataGridView1[j, i].Style.BackColor = HatRenkleri.haftalikTatilRengi;

                            }


                        }
                    }


                    #region


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
                    string firmaAdi = "";
                    #region
                    int tatilDahilSure;
                   
                    DateTime bas;
                    DateTime son;
                    int hatNo;
                    string siparisKodu;

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
                    int baslangicSaati;
                   
                    DateTime simdiFormatli = new DateTime(yyyy, mon, d, h, min, seco);
                    DateTime simdiFormatsiz = new DateTime(yyyy, mon, d, h, min, seco);
                    //MessageBox.Show(simdi.ToShortDateString());
                    //BİRİNCİ SEÇENEK BAŞLANGIÇ TARİHİ BUGUNDEN ÖNDE OLMASI,BİTİS TARİHİ BUGÜNÜN İÇİNDE OLMASI
                    //İKİNCİ SECENEK BAŞLANIGÇ TARİHİ BUGUNDEN ONDE OLMASI,BİTİS TARİHİ BUGÜNÜN DIŞINDA OLMASI
                    //ÜÇÜNÜ SEÇENEK BAŞLANGIÇ TARİHİ BUGUNUN İÇİNDE OLMASI BİTİŞ TARİHİ BUGÜNÜN İÇİNDE OLMASI
                    //DÖRDÜNCÜ SEÇENEK BAŞLANGIÇ TARİHİ BUGUNN İÇİNDE ,BİTİŞ TARİHİ BUGÜNÜN DIŞINDA OLMASI
                    #endregion

                    SqlCommand sorSayi = new SqlCommand(" select count(*) from uretimHatti  ", veritabani.conn);
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
                    SqlCommand sor1 = new SqlCommand("select * from siparis where baslangicTarihi<@simdiFormatli and bitTarih=@bitTarih",veritabani.conn);
                    sor1.Parameters.Clear();
                    sor1.Parameters.AddWithValue("@simdiFormatli",simdiFormatli);
                    sor1.Parameters.AddWithValue("@bitTarih",simdiFormatli.ToShortDateString());

                    SqlDataReader oku1 = sor1.ExecuteReader();
                    
                    while(oku1.Read()){
                        
                        int bitSaat = Convert.ToInt32(oku1["bitSaat"]);
                        hatno = Convert.ToInt32(oku1["kullanilacakHat"]);
                        satir = satirIndeksBul(hatno.ToString());
                        siparisKodu = oku1["siparisKod"].ToString();
                        firmaAdi = oku1["firmaAdi"].ToString();

                        for (int i = 3; i < (bitSaat * 2 + 2); i++) {
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
                                i++;
                        }

                    
                    }
                 

                    
                    //İKİNCİ
                    
                    SqlCommand sor2;
                    sor2 = new SqlCommand();
                    sor2.Connection = veritabani.conn;
                    sor2.CommandText = "select * from siparis where  baslangicTarihi>=@simdiFormatli";
                    sor2.Parameters.Clear();
                    sor2.Parameters.AddWithValue("@simdiFormatli", simdiFormatli);
                    //sor2.Parameters.AddWithValue("@bitTarih",simdiFormatli.ToShortDateString());
                   
                    SqlDataReader oku2 = sor2.ExecuteReader();

                    while(oku2.Read()){
                        string baslangicTarih = Convert.ToDateTime(oku2["baslangicTarihi"]).ToShortDateString();
                        bitTarih = oku2["bitTarih"].ToString();
                        DateTime bitisTarihi=Convert.ToDateTime(oku2["bitisTarihi"]);
                        int basSaat = Convert.ToDateTime(oku2["baslangicTarihi"]).Hour;
                        int bitSaat = Convert.ToInt32(oku2["bitSaat"]);
                        hatno = Convert.ToInt32(oku2["kullanilacakHat"]);
                        siparisKodu = oku2["siparisKod"].ToString();
                        satir = satirIndeksBul(hatno.ToString());
                        firmaAdi = oku2["firmaAdi"].ToString();

                        if (baslangicTarih == simdiFormatli.ToShortDateString() && bitTarih==simdiFormatli.ToShortDateString()) {
                            for (int i =( basSaat * 2 + 3); i < (bitSaat * 2 + 2); i++)
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
                                    i++;
                            }



                        }
                        else if (baslangicTarih == simdiFormatli.ToShortDateString()) {
                            
                            for (int i = (basSaat * 2 + 3); i < (dataGridView1.ColumnCount-2); i++)
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
                                     i++;

                            }
                        
                        
                        }


                        

                    }
                    //ÜÇÜNCÜ
                    SqlCommand sor3 = new SqlCommand("select * from siparis where baslangicTarihi<@simdiFormatli and bitisTarihi>@simdiFormatli and bitTarih!=@bitTarih", veritabani.conn);
                    sor3.Parameters.Clear();
                    sor3.Parameters.AddWithValue("@simdiFormatli", SqlDbType.DateTime).Value=simdiFormatli;
                    sor3.Parameters.AddWithValue("@bittarih",simdiFormatli.ToShortDateString());
                    
                    SqlDataReader oku3 = sor3.ExecuteReader();
                    while (oku3.Read())
                    {

                       
                        hatno = Convert.ToInt32(oku3["kullanilacakHat"]);
                        satir = satirIndeksBul(hatno.ToString());
                        siparisKodu = oku3["siparisKod"].ToString();
                        firmaAdi = oku3["firmaAdi"].ToString();
                        for (int i = 3; i < dataGridView1.ColumnCount-2; i++)
                        {
                            if (firmaAdi == "TATİL") {
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
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
                hata.hataMesajı = ex.Message;
                hata.hataKodu = "frnGunlukPlan -dataGridDoldur";
                hata.hataMesajiKaydet();
            
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
            for(int i=1;i<=dataGridView1.ColumnCount-1;i++){
                for (int j = 0; j <= dataGridView1.RowCount-1; j++)
                {
                    dataGridView1[i, j].Style.BackColor = Color.White;
                }
            
            
            }

            DateTime simdi = dateTimePicker1.Value;
          
            dataGridDoldur(simdi);
        }

        private void btnExceleAktar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult cevap = MessageBox.Show("Bilgiler excele aktarılacak.","BİLGİ",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Information);
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
                MessageBox.Show("Excele aktarım işlemi başarılı","BİLGİ",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            }catch(Exception){
            
            
            }

        }
        int satir,sutun,hatno;
        int x,y;
        hatalar hata = new hatalar();
        string seciliSiparisKodu;
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //try
            //{
                satir = Convert.ToInt32(dataGridView1.CurrentCell.RowIndex);
                sutun = Convert.ToInt32(dataGridView1.CurrentCell.ColumnIndex);
                hatno = Convert.ToInt32(dataGridView1.Rows[satir].Cells[0].Value);
                //  MessageBox.Show(satir.ToString()+"  "+sutun.ToString());
                dataGridView1[sutun, satir].Style.SelectionBackColor = dataGridView1[sutun, satir].Style.BackColor;
                Color gozRengi=dataGridView1[sutun, satir].Style.BackColor;
                if (dataGridView1[sutun, satir].Style.BackColor != Color.White && sutun != 0 && ilk != 0 && gozRengi != HatRenkleri.haftalikTatilRengi && gozRengi!=HatRenkleri.kismenPasifleştirilenHatRengi && gozRengi!=HatRenkleri.ekTatilRengi)
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

                else if (gozRengi == HatRenkleri.ekTatilRengi && sutun != 0 && ilk != 0)
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

                
                

            //}catch(Exception ex){
            //    MessageBox.Show(ex.Message);
            //    hata.hataMesajı = ex.Message;
            //    hata.hataKodu = "frnGunlukPlan -dataGridView1_CellMouseClick";
            //    hata.hataMesajiKaydet();
            
            
            //}

        }

       
       
        private void contextmenum()
        {
            ContextMenu cm = new ContextMenu();

            System.Windows.Forms.MenuItem m1 = new System.Windows.Forms.MenuItem("Sipariş Detayları");
            //System.Windows.Forms.MenuItem m2 = new System.Windows.Forms.MenuItem("Kullanılan Ürün Deta");
            //System.Windows.Forms.MenuItem m3 = new System.Windows.Forms.MenuItem("kirlet");
            //System.Windows.Forms.MenuItem m4 = new System.Windows.Forms.MenuItem("zıpla");

            cm.MenuItems.Add(m1);
           // cm.MenuItems.Add(m2);
            //cm.MenuItems.Add(m3);
            //cm.MenuItems.Add(m4);

            m1.Click += new EventHandler(m1_Click);
            //m2.Click += new EventHandler(m2_Click);
            //m3.Click += new EventHandler(m3_Click);
            //m4.Click += new EventHandler(m4_Click);

            this.ContextMenu = cm;

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

                    // pnlSiparisDetay.SetBounds(x, y,393,326);

                    pnlSiparisDetay.Visible = true;

                    dataGridView1.Enabled = false;

                    dataGridView1.Enabled = false;
                    btnBugun.Enabled = false;
                    btnSonrakiGun.Enabled = false;
                    btnOncekiGun.Enabled = false;
                    dateTimePicker1.Enabled = false;
                    btnExceleAktar.Enabled = false;
                    SqlCommand siparis = new SqlCommand("select * from siparis s,hammadde h,renkler r where s.hammadde=h.id and s.renk=r.id and siparisKod='" + seciliSiparisKodu + "'", veritabani.conn);
                    SqlDataReader siparisOku = siparis.ExecuteReader();
                    if (siparisOku.Read())
                    {
                        
                        lblHammadde.Text = siparisOku["adi"].ToString();
                        lblKayitTarihi.Text = "" + String.Format("{0:f}", Convert.ToDateTime(siparisOku["kayitTarihi"]));
                        lblRenk.Text = siparisOku["renkAdi"].ToString();
                        lblFirmaAdi.Text = siparisOku["firmaAdi"].ToString();
                        
                        lblBoy.Text = "" + String.Format("{0:0,0}", Convert.ToInt32(siparisOku["boy"])) + " milimetre"; 
                        lblAdet.Text = "" + String.Format("{0:0,0}", Convert.ToInt32(siparisOku["adet"]));
                        devamDurumu = Convert.ToInt16(siparisOku["devamDurumu"]);
                        lblSiparisKodu.Text = siparisOku["siparisKod"].ToString();
                        lblBaslangıçTarihi.Text = "" + String.Format("{0:f}", Convert.ToDateTime(siparisOku["baslangicTarihi"]));
                        lblBitisTarihi.Text = "" + String.Format("{0:f}", Convert.ToDateTime(siparisOku["bitisTarihi"]));
                        lblUrunKod.Text = siparisOku["urunKod"].ToString();
                        lblHatNO.Text = siparisOku["kullanilacakHat"].ToString();

                        lblIsSure.Text = siparisOku["toplamSure"].ToString()+" SAAT";
                        lblToplamSure.Text = siparisOku["tatilDahilSure"].ToString()+" SAAT";
                        lblGerekliUrunMiktari.Text = String.Format("{0:0,0}", Convert.ToInt32(siparisOku["gerekenUrunMiktari"]) / 1000) + " kg"; 
                        int toplamSure = Convert.ToInt32(siparisOku["tatilDahilSure"]);
                        
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
                                progIslenenn.Value += 1;

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
            }catch(Exception ex){
                MessageBox.Show(ex.Message);
                hata.hataMesajı = ex.Message;
                hata.hataKodu = "frnGunlukPlan -m1_Click";
                hata.hataMesajiKaydet();
            }
            
        }

        private void m2_Click(object sender, EventArgs e)
        {
            pnlTatilAciklamasi.Visible = true;
            txtTatilAciklama.Text = tatilAciklamasi;
         
            pnlTatilAciklamasi.Location = new System.Drawing.Point(x, y);
            pnlTatilAciklamasi.Visible = true;
            //  dataGridView1.Enabled = false;
           
            lblTatilGunu.Text = "" + String.Format("{0:D}",dateTimePicker1.Value );

            
           

        }

        private void m3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("kirlet özelliği");
        }

        private void m4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("zıpla özelliği");
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
           
        }

        private void btnPnlkapat_Click(object sender, EventArgs e)
        {
            pnlSiparisDetay.Visible = false;
            dataGridView1.Enabled = true;
            btnSonrakiGun.Enabled = true;
            btnOncekiGun.Enabled = true;
            dateTimePicker1.Enabled = true;
            btnBugun.Enabled = true;
            btnExceleAktar.Enabled = true;
        }

        private void btnSimdi_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
        }

        private void btnOncekiGun_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = dateTimePicker1.Value.AddDays(-1);
        }

        private void btnSonrakiGun_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = dateTimePicker1.Value.AddDays(1);
        }

        frmUrunResmi urunResimGorm;
        radUrunResimFormu radUrunResimFormu;
        

        private void btnBugun_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
        }

        private void btnSonrakiGun_Click_1(object sender, EventArgs e)
        {
            dateTimePicker1.Value = dateTimePicker1.Value.AddDays(1);
        }

        private void btnOncekiGun_Click_1(object sender, EventArgs e)
        {
            dateTimePicker1.Value = dateTimePicker1.Value.AddDays(-1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pnlTatilAciklamasi.Visible = false;
        }

        private void dataGridView1_Click(object sender, EventArgs e)
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

        

            
       

            
        
        
        
    }
}
