using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
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
    public partial class radYedekAl : Telerik.WinControls.UI.RadForm
    {
        public radYedekAl()
        {
            InitializeComponent();
        }
        DataGridView dataGrid;
         SqlCommand cmd;
         SqlConnection con = new SqlConnection(@"server=.\SQLEXPRESS;Trusted_Connection=yes");
   
      
        void excele_aktar(DataGridView dg)
        {
            try
            {
                dg.AllowUserToAddRows = false;
                System.Globalization.CultureInfo dil = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-us");
                Microsoft.Office.Interop.Excel.Application Tablo = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook kitap = Tablo.Workbooks.Add(true);
                Microsoft.Office.Interop.Excel._Worksheet sayfa = (Microsoft.Office.Interop.Excel.Worksheet)Tablo.ActiveSheet;
                System.Threading.Thread.CurrentThread.CurrentCulture = dil;
                Tablo.Visible = true;
                sayfa = kitap.ActiveSheet;
                for (int i = 0; i < dg.Rows.Count; i++)
                {
                    for (int j = 0; j < dg.ColumnCount; j++)
                    {
                        if (i == 0)
                        {
                            Tablo.Cells[1, j + 1] = dg.Columns[j].HeaderText;
                        }
                        Tablo.Cells[i + 2, j + 1] = dg.Rows[i].Cells[j].Value.ToString();
                    }
                }
                Tablo.Visible = true;
                Tablo.UserControl = true;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hata.hataKodu = "radYedekAl-excele_aktar";
                hata.hataMesajı = ex.Message;
                hata.hataMesajiKaydet();


            }
        }

        private void radMenuButtonItem1_Click(object sender, EventArgs e)
        {


        }
        void database_yedek()
        {
           

            CreateDumpDevice();


            string databasename = "Planlama";

            string command = "BACKUP DATABASE " + databasename + " TO sqlBackUp";


            SqlCommand myCommand = new SqlCommand(command, veritabani.conn);


            
            try
            {

                myCommand.ExecuteNonQuery();

                lblDurum.Text = "Yedekleme işlemi tamamlandı.";

            }

            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hata.hataKodu = "radYedekAl-database_yedek";
                hata.hataMesajı = ex.Message;
                hata.hataMesajiKaydet();

            }

            //www.kodcuyuz.com
        }
        private void CreateDumpDevice()
        {

           
            saveFileDialog1.Filter = "Text files (*.bak)|*.bak|All files (*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                
                query("Backup database Planlama to disk='" + saveFileDialog1.FileName + "'");

               
            }
            
        
       



        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radYedekAl_Load(object sender, EventArgs e)
        {
            lblDurum.Text = "";
            dataGrid = new DataGridView();
            this.Controls.Add(dataGrid);
            dataGrid.Visible = false;
        }
        hatalar hata = new hatalar();
        private void radButton1_Click(object sender, EventArgs e)
        {
            try
            {
               
                SqlCommand ara = new SqlCommand();
                ara.Connection = veritabani.conn;
                ara.CommandText = "select";

                veritabani.baglan();
                if (rdSiparis.IsChecked)
                {

                    ara.CommandText = "select siparisKod as SiparişKodu,urunKod as ÜrünKodu,firmaAdi as FirmaAdı,adi as Hammadde,oncelikSirasi as OncelikSırası,boy,adet,renkAdi as renk,baslangicTarihi,bitisTarihi,toplamSure,gerekenUrunMiktari,kullanilacakHat HATNO,durum,kayitTarihi as KayıtTarihi from siparis s,DevamDurumu d,renkler r,hammadde h where r.id=s.renk and s.devamDurumu=d.id and h.id=s.hammadde order by KayıtTarihi desc";


                }
                else if (rdUrunler.IsChecked)
                {

                    ara.CommandText = "select kod as ÜrünKodu,hizi as ÜrünHızı,gramaj,fireMiktari as FireMiktarı from urunler";

                }
                else if (rdUretimHat.IsChecked)
                {
                    ara.CommandText = "select numara from uretimHatti";

                }
                else if (rdRenkler.IsChecked)
                {

                    ara.CommandText = "select renkAdi,kod from renkler";

                }
                else if (rdHammadde.IsChecked)
                {

                    ara.CommandText = "select adi from hammadde";
                }
                else if (rdVeritabani.IsChecked)
                {
                    //blank("backup");
                    database_yedek();
                    
                    return;
                }
                else
                {
                    MessageBox.Show("Lütfen bir seçeneği seçiniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                this.Cursor = Cursors.WaitCursor;
                SqlDataAdapter da = new SqlDataAdapter(ara);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGrid.DataSource = dt;
                excele_aktar(dataGrid);
                this.Cursor = Cursors.Default;

            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hata.hataKodu = "radYedekAl-radButton1_Click";
                hata.hataMesajı = ex.Message;
                hata.hataMesajiKaydet();


            }

            veritabani.baglantiyiKes();
        }
        //public void BackupDatabase(String databaseName, String serverName, String destinationPath)
        //{
        //    ServerConnection connection = new ServerConnection(serverName);
        //    Server sqlServer = new Server(connection);
        //    BackupDeviceItem deviceItem = new BackupDeviceItem(destinationPath, DeviceType.File);
        //    Backup sqlBackup = new Backup();
        //    sqlBackup.Devices.Add(deviceItem);
        //    sqlBackup.Action = BackupActionType.Database;
        //    sqlBackup.BackupSetDescription = "ArsivDataBase:" + DateTime.Now.ToShortDateString();
        //    sqlBackup.BackupSetName = "Arsiv";
        //    sqlBackup.Database = databaseName;
        //    sqlBackup.Initialize = true;
        //    sqlBackup.Checksum = true;
        //    sqlBackup.ContinueAfterError = true;
        //    sqlBackup.Incremental = false;
        //    sqlBackup.ExpirationDate = DateTime.Now.AddDays(3);
        //    sqlBackup.LogTruncation = BackupTruncateLogType.Truncate;
        //    sqlBackup.FormatMedia = false;
        //    sqlBackup.SqlBackup(sqlServer);
        //    lblDurum.Text = "Yedekleme işlemi başarılı";
        //}

    
        public static void BackupDatabase(string backUpFile)
        {
            ServerConnection con = new ServerConnection(@".\SQLEXPRESS");
            Server server = new Server(con);
            Backup source = new Backup();
            source.Action = BackupActionType.Database;
            source.Database = "Planlama";
            BackupDeviceItem destination = new BackupDeviceItem(backUpFile, DeviceType.File);
            source.Devices.Add(destination);
            source.SqlBackup(server);

            con.Disconnect();
        }
            public void query(string que)

        {

            cmd = new SqlCommand(que,con);
            

            cmd.ExecuteNonQuery();

        }
       
       
        public void blank(string str)
        {
            veritabani.baglan();
            if (string.IsNullOrEmpty(".\\SQLEXPRESS") | string.IsNullOrEmpty("Planlama"))
            {
                MessageBox.Show("Server Name & Database can not be Blank");
                return;
            }
            else
            {
                if (str == "backup")
                {
                    saveFileDialog1.Filter = "Text files (*.bak)|*.bak|All files (*.*)|*.*";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        // the below query get backup of database you specified in combobox
                        query("Backup database Planlama to disk='" + saveFileDialog1.FileName + "'");

                        MessageBox.Show("Database BackUp has been created successful.");
                    }
                }
            }
        }
    }
}
