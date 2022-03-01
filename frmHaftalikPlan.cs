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
    public partial class frmHaftalikPlan : Form
    {
        public frmHaftalikPlan()
        {
            InitializeComponent();
        }
        int yil;
        int ay=1;
        int gun=1;

        ContextMenu cm;
      
        int hafta;
        int gunSayisi;
        string[,] siparisKodlari;
        int ilk = 0;
        private void frmHaftalikPlan_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'genelDataSet.uretimHatti' table. You can move, or remove it, as needed.
            panel2.Scroll += (s, ev) => panel2.HorizontalScroll.Value = dataGridView1.HorizontalScrollingOffset;
            try
            {
                // TODO: This line of code loads data into the 'planlamaDataSet7.uretimHatti' table. You can move, or remove it, as needed.
              
                lblGun.Text = "";
                lblTarih.Text = "";
                this.Top = 100;
                this.Left = 0;
               
                newsutunOlusturma();
                this.uretimHattiTableAdapter.Fill(this.genelDataSet.uretimHatti);
                //buHafta();
               
                pnlSiparisDetay.Visible = false;
                veritabani.baglan();
           
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
                hata.hataMesajı = ex.Message;
                hata.hataKodu = "frmHaftalikPlan -frmHaftalikPlan_Load";
                hata.hataMesajiKaydet();
            
            
            }
          
           
           
           
            veritabani.baglantiyiKes();
        

        }
        DateTime tarih;
        private void btnTariheGit_Click(object sender, EventArgs e)
        {
           


            
        }
        public void newsutunOlusturma(){
          
            int onlar = 0,on=0,bir=0;
            int birler = 0;
            int k=50;
            for (int j = 1; j < 6; j++) {
                onlar = 0;
                birler = 0;
                for (int i = 0; i < 24; i++) {
                    
                    if (i % 4 == 0)
                    {
                        on = onlar / 10;
                        bir = birler % 10;
                        dataGridView1.Columns.Add("colu" + i.ToString(), on + "" + bir + "" + ":" + "00");
                        dataGridView1.Columns[k++].Width = 50;
                        birler += 4;
                        onlar += 4;

                    }
                    else {
                        dataGridView1.Columns.Add("colum" + i.ToString(), " ");
                        dataGridView1.Columns[k++].Width = 10;
                    }
                   
                
                }
            
            }
         
          
        
        }
    
        hatalar hata = new hatalar();
        Hashtable hashtable = new Hashtable();
        public void tatilGununuSiyahYap(DateTime seciliTarih,DateTime Bitis)
        {
            try
            {
                int yil = seciliTarih.Year;
                DateTime gecici = new DateTime(yil, 1, 1);


                string haftaninBasi = String.Format("{0:dddd}", gecici);
                haftaninBasi = haftaninBasi.ToUpper();
                string gun = "";

                string[] gunler = { "PAZARTESİ", "SALI", "ÇARŞAMBA", "PERŞEMBE", "CUMA", "CUMARTESİ", "PAZAR" };


                int kacinciGun;
                veritabani.baglan();

                SqlCommand sor = new SqlCommand("select tatilGunu from Ayarlar", veritabani.conn);
                SqlDataReader oku = sor.ExecuteReader();
                if (oku.Read())
                {
                    gun = oku["tatilGunu"].ToString();



                }
                int i = 0;
                while ((i <= 6) && (haftaninBasi != gunler[i]))
                {
                    i = i + 1;

                }
                int pzrTesi;

                pzrTesi = 8 - i;

                if (i == 0)
                    pzrTesi = 1;


                int j = 0;
                while (j <= 6 && gun.ToUpper() != gunler[j])
                    j = j + 1;

                //  MessageBox.Show("i:"+i.ToString()+" j:"+j.ToString());

                if (i == j)
                    kacinciGun = 1;

                else if (i > j)
                {

                    kacinciGun = 8 - (i - j);
                }
                else
                    kacinciGun = j - i + 1;

               // MessageBox.Show(pzrTesi.ToString());

                int nerden = kacinciGun * 48 - 46;
                int nereye = nerden + 48;
                for (i = 0; i < dataGridView1.RowCount; i++)
                {

                    for (j = 2 + (kacinciGun * 48) - 48; j <= kacinciGun * 48 + 1; j++)
                    {

                        dataGridView1[j, i].Style.BackColor = Color.Black;
                    }

                }

                for (i = 0; i < dataGridView1.RowCount; i++)
                {

                    for (j = 2 + (pzrTesi * 48) - 48; j <= (pzrTesi * 48) - 30; j++)
                    {

                        dataGridView1[j, i].Style.BackColor = Color.Black;
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
                    SqlCommand digerTatilGunleri = new SqlCommand("select * from TatilGunleri where tarih= '" + bas.ToShortDateString() + "'", veritabani.conn);

                    SqlDataReader digerTatilOku = digerTatilGunleri.ExecuteReader();
                    if (digerTatilOku.Read())
                    {
                        DateTime tarh = Convert.ToDateTime(digerTatilOku["tarih"]);
                        int saatFark = Convert.ToInt32(tarh.Subtract(seciliTarih).TotalHours);
                        hashtable[saatFark * 2 + 2] = digerTatilOku["aciklama"].ToString();
                        for (k = saatFark * 2 + 2; k < saatFark * 2 + 50; k++)
                        {

                            for (i = 0; i < dataGridView1.RowCount; i++)
                            {
                                dataGridView1[k, i].Style.BackColor = Color.DarkGray;



                            }


                        }

                    }
                    bas = bas.AddDays(1);
                }


            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
                hata.hataMesajı = ex.Message;
                hata.hataKodu = "frmHaftalikPlan -tatilGununuSiyahYap";
                hata.hataMesajiKaydet();
            
            
            }


        }   
        public void cmbYilDoldur() {
            try
            {
                for (int i = 2015; i <= 2050; i++)
                {
                   // comboBox1.Items.Add(i.ToString());

                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
                hata.hataMesajı = ex.Message;
                hata.hataKodu = "frmHaftalikPlan -cmbYilDoldur";
                hata.hataMesajiKaydet();
            
            }
        
        }
        public void cmbHaftaDoldur() {
            try
            {
                for (int i = 1; i <= 52; i++)
                {
                    //comboBox2.Items.Add(i.ToString());
                }
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message);
                hata.hataMesajı = ex.Message;
                hata.hataKodu = "frmHaftalikPlan -cmbHaftaDoldur";
                hata.hataMesajiKaydet();
            
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
            }catch(Exception ex){
                MessageBox.Show(ex.Message);
                hata.hataMesajı = ex.Message;
                hata.hataKodu = "frmHaftalikPlan -satirIndexBul";
                hata.hataMesajiKaydet();
                return -1;
            
            }
        }
        public void hatRenkDoldur(DateTime bas, DateTime bitis)
        {
            try
            {
                tatilGununuSiyahYap(bas, bitis);
                ilk = 1;
                veritabani.baglan();

                frmGunlukPlan f = new frmGunlukPlan();
                //renk[9] = Color.Ivory; bu renk datagrdi le aynı renkte

                string siparisKodu;
                //RENKLER
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
                DateTime bitisTar;
                DateTime basTarihi;

                int saatSayisi;
                int hatNo;
                int satir;
                int k = 0;

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
                SqlCommand sor = new SqlCommand("select * from siparis where ('" + bas.ToString("yyyy-MM-dd hh:mm:ss") + "' between baslangicTarihi and bitisTarihi)", veritabani.conn);
                SqlDataReader oku = sor.ExecuteReader();

                while (oku.Read())
                {
                    siparisKodu = oku["siparisKod"].ToString();
                    bitisTar = Convert.ToDateTime(oku["bitisTarihi"]);
                    hatNo = Convert.ToInt32(oku["kullanilacakHat"]);
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
                            if (dataGridView1[i, satir].Style.BackColor != Color.Black && dataGridView1[i, satir].Style.BackColor != Color.DarkGray)
                            {
                                dataGridView1[i, satir].Style.BackColor = renk[hatNo - 1];
                                siparisKodlari[satir, i] = siparisKodu;
                            }

                        }
                        k++;


                    }

                }
                SqlCommand sor2 = new SqlCommand("select * from siparis where baslangicTarihi between '" + bas.ToString("yyyy-MM-dd hh:mm:ss") + "' and '" + bitis.ToString("yyyy-MM-dd hh:mm:ss") + "'", veritabani.conn);
                SqlDataReader oku2 = sor2.ExecuteReader();

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

                    if ((168 - farkSaat) >= totalSaat)
                    {

                        for (int i = farkSaat * 2 + 3; j < totalSaat * 2 - 1; i++)
                        {
                            if (dataGridView1[i, satir].Style.BackColor != Color.Black && dataGridView1[i, satir].Style.BackColor != Color.DarkGray)
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
                            if (dataGridView1[i, satir].Style.BackColor != Color.Black && dataGridView1[i, satir].Style.BackColor != Color.DarkGray)
                            {
                                dataGridView1[i, satir].Style.BackColor = renk[hatNo - 1];
                                siparisKodlari[satir, i] = siparisKodu;
                            }

                        }
                        k++;
                    }

                }
            }catch(Exception ex){

                MessageBox.Show(ex.Message);
                hata.hataMesajı = ex.Message;
                hata.hataKodu = "frmHaftalikPlan -hatRenkDoldur";
                hata.hataMesajiKaydet();
            
            }
        }

        private void btnBuHafta_Click(object sender, EventArgs e)
        {
           // buHafta();
           
        }
        //public void buHafta() {
        //    try
        //    {
        //        int yill = DateTime.Now.Year;
        //        int haftaSayisi;
        //        comboBox1.SelectedItem = comboBox1.GetItemText(yill.ToString());


        //        //comboBox1.Text = yil.ToString();
        //        DateTime haf = DateTime.Now;
        //        DateTime yilbasi = new DateTime(yill, 1, 1, 0, 0, 0);

        //        int cikar = Convert.ToInt32(DateTime.Now.Subtract(yilbasi).TotalDays);
        //        haftaSayisi = cikar / 7 + 1;

        //        comboBox2.SelectedItem = comboBox2.GetItemText(haftaSayisi.ToString());
        //    }catch(Exception ex){
        //        MessageBox.Show(ex.Message);
        //        hata.hataMesajı = ex.Message;
        //        hata.hataKodu = "frmHaftalikPlan -buHafta";
        //        hata.hataMesajiKaydet();
            
        //    }
            
        
        //}

        private void btnSonraki_Click(object sender, EventArgs e)
        {
           // int secili = Convert.ToInt32(comboBox2.GetItemText(comboBox2.SelectedItem));
          //  comboBox2.SelectedItem = comboBox2.GetItemText((secili+1).ToString());
        }

        private void btnOnceki_Click(object sender, EventArgs e)
        {
            //int secili = Convert.ToInt32(comboBox2.GetItemText(comboBox2.SelectedItem));
           // comboBox2.SelectedItem = comboBox2.GetItemText((secili - 1).ToString());
        }

        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
           
               

            try
            {
                int satirScrool = dataGridView1.FirstDisplayedScrollingRowIndex;
                int sutunScrool = dataGridView1.FirstDisplayedScrollingColumnIndex;
                int gecenGun = sutunScrool / 48;
                if (ilk != 0)
                {
                    //lblGun.Text = tarih.AddDays(gecenGun).ToShortDateString();
                    lblGun.Text = "" + String.Format("{0:D}", tarih.AddDays(gecenGun));
                }
                else
                    lblGun.Text = "";
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
                hata.hataMesajı = ex.Message;
                hata.hataKodu = "frmHaftalikPlan -dataGridView1_Scroll";
                hata.hataMesajiKaydet();
            
            }


            //MessageBox.Show(satirScrool.ToString()+" "+sutunScrool.ToString());


        }
        int satir,x,y;
        int sutun;
        int hatno;
        string seciliSiparisKodu;
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                dataGridView1[sutun, satir].Style.SelectionBackColor = dataGridView1[sutun, satir].Style.BackColor;
                satir = Convert.ToInt32(dataGridView1.CurrentCell.RowIndex);
                sutun = Convert.ToInt32(dataGridView1.CurrentCell.ColumnIndex);
                hatno = Convert.ToInt32(dataGridView1.Rows[satir].Cells[0].Value);
                //  MessageBox.Show(satir.ToString()+"  "+sutun.ToString());
                if (dataGridView1[sutun, satir].Style.BackColor == Color.DarkGray && sutun != 0 && ilk != 0)
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

                else if (dataGridView1[sutun, satir].Style.BackColor != Color.White && sutun != 0 && ilk != 0 && dataGridView1[sutun, satir].Style.BackColor != Color.Black)
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
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
                hata.hataMesajı = ex.Message;
                hata.hataKodu = "frmHaftalikPlanCellMouseClick";
                hata.hataMesajiKaydet();
            
            }
        }
        private void m2_Click(object sender, EventArgs e) {
            int blok=sutun / 49;
           
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
              
                yyyy = simdi.Year;
                mon = simdi.Month;
                d = simdi.Day;
                h = simdi.Hour;
                min = simdi.Minute;
               
                DateTime simdiFormatli = new DateTime(yyyy, mon, d, h, min, 00);
                //Sipariş detayları
                veritabani.baglan();
                if (siparisKodlari[satir, sutun] != "*")
                {

                    // pnlSiparisDetay.SetBounds(x, y,393,326);
                    kontrolPasiflestir();
                    pnlSiparisDetay.Visible = true;
                    dataGridView1.Enabled = false;
                    SqlCommand siparis = new SqlCommand("select * from siparis s,hammadde h,renkler r where s.hammadde=h.id and s.renk=r.id and siparisKod='" + seciliSiparisKodu + "'", veritabani.conn);
                    SqlDataReader siparisOku = siparis.ExecuteReader();
                    if (siparisOku.Read())
                    {
                        lblHammadde.Text = siparisOku["adi"].ToString();
                        lblKayitTarihi.Text = "" + String.Format("{0:f}", Convert.ToDateTime(siparisOku["kayitTarihi"]));
                        lblRenk.Text = siparisOku["renkAdi"].ToString();
                        lblFirmaAdi.Text = siparisOku["firmaAdi"].ToString();
                        //lblBoy.Text = siparisOku["boy"].ToString()+" milimetre";
                        lblAdet.Text = "" + String.Format("{0:0,0}", Convert.ToDecimal(siparisOku["adet"]));
                        devamDurumu = Convert.ToInt16(siparisOku["devamDurumu"]);
                        lblSiparisKodu.Text = siparisOku["siparisKod"].ToString();
                        lblBoy.Text = "" + String.Format("{0:0,0}", Convert.ToDecimal(siparisOku["boy"])) + " milimetre";
                        lblBaslangicTarihi.Text = "" + String.Format("{0:f}", Convert.ToDateTime(siparisOku["baslangicTarihi"]));
                        lblBitisTarihi.Text = "" + String.Format("{0:f}", Convert.ToDateTime(siparisOku["bitisTarihi"]));
                        lblUrunKodu.Text = siparisOku["urunKod"].ToString();
                        lblHatNO.Text = siparisOku["kullanilacakHat"].ToString();
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
                            int Islenen = (100 - (((100 * kalanDakka) / (toplamSure * 60))));
                            lblKalan.Text = "% " + ((100 * kalanDakka) / (toplamSure * 60)).ToString();
                            lblIslenen.Text = "% " + (100 - (((100 * kalanDakka) / (toplamSure * 60)))).ToString();
                            progIslenen.Minimum = 0;
                            progIslenen.Value = kalan;
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
            }catch(Exception ex){
                MessageBox.Show(ex.Message);
                hata.hataMesajı = ex.Message;
                hata.hataKodu = "frmHaftalikPlan_M1_Click";
                hata.hataMesajiKaydet();
            }


        }

        private void btnPnlkapat_Click(object sender, EventArgs e)
        {
            pnlSiparisDetay.Visible = false;
            dataGridView1.Enabled = true;
            kontrolAktiflestir();
        }

        private void kontrolPasiflestir() {
            btnBuHafta.Enabled = false;
            btnOnceki.Enabled = false;
            btnSonraki.Enabled = false;
          
        }
        private void kontrolAktiflestir()
        {
            btnBuHafta.Enabled = true;
            btnOnceki.Enabled = true;
            btnSonraki.Enabled = true;
           
        }
        frmUrunResmi urunResimGorm;
        radUrunResimFormu radUrunResmiFormu;
         
        private void lblUrunResmiGor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Image urunResim = null;
                veritabani.baglan();
                SqlCommand urunResmi = new SqlCommand("select resim from urunler where kod='" + lblUrunKodu.Text + "'", veritabani.conn);
                SqlDataReader urunResmiOku = urunResmi.ExecuteReader();
                if (urunResmiOku.Read())
                {

                    byte[] resim = (byte[])urunResmiOku["resim"];
                    MemoryStream ms = new MemoryStream(resim, 0, resim.Length);
                    ms.Write(resim, 0, resim.Length);
                    urunResim = Image.FromStream(ms, true);

                    if (urunResimGorm == null || urunResimGorm.IsDisposed)
                    {

                        radUrunResmiFormu = new radUrunResimFormu(urunResim);

                        radUrunResmiFormu.Show();
                    }
                    else
                        MessageBox.Show("Ürün Resmi açık durumda!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);



                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
                hata.hataMesajı = ex.Message;
                hata.hataKodu = "frmHaftalikPlan-lblUrunResmiGor_LinkClicked";
                hata.hataMesajiKaydet();
            }

        }

        private void panel2_Scroll(object sender, ScrollEventArgs e)
        {
          
        }

       
        
       
    }
}
