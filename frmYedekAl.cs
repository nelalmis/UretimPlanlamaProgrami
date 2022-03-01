using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace uretimPlanlamaProgrami
{
    public partial class frmYedekAl : Form
    {
        public frmYedekAl()
        {
            InitializeComponent();
        }
        DataGridView dataGrid;
        private void frmYedekAl_Load(object sender, EventArgs e)
        {

            dataGrid = new DataGridView();
            this.Controls.Add(dataGrid);
            dataGrid.Visible = false;
        }

        void excele_aktar(DataGridView dg)
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

        private void btnYedekAl_Click(object sender, EventArgs e)
        {
            SqlCommand ara = new SqlCommand();
            ara.Connection = veritabani.conn;
            ara.CommandText = "select";
            veritabani.baglan();
            if (rdSiparis.Checked) {

              ara.CommandText="select * from siparis";
                

            }
            else if (rdUrunler.Checked) {

                ara.CommandText = "select * from urunler";
            
            }else if(rdUretimHat.Checked){
                ara.CommandText= "select * from uretimHatti";

            }
            else if (rdRenkler.Checked) {

                ara.CommandText = "select * from renkler";

            }
            else if (rdHammadde.Checked) {

                ara.CommandText = "select * from hammadde";
            }else if(rdVeritabani.Checked){

                database_yedek();
                return;
            }
           
                SqlDataAdapter da = new SqlDataAdapter(ara);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGrid.DataSource = dt;
                excele_aktar(dataGrid);

        }
        void database_yedek()
        {


            CreateDumpDevice();



            //Hangi database yedeklemek istiyorsak onu combobox dan seciyoruz.

            string databasename = "Planlama";

            //yedekleme işlemini yapacak SQL komutumuz.

            //bu komut sectigimiz databasei daha once olusturdugumuz device’e yazıyor.

            //Bir device uzerinde farklı databaseleri yedekleyebiliriz.

            string command = "BACKUP DATABASE " + databasename + " TO sqlBackUp";

           

            SqlCommand myCommand = new SqlCommand(command, veritabani.conn);

           

            try
            {

                myCommand.ExecuteNonQuery();

                lblDurum.Text = "Yedekleme işlemi tamamlandı.";

            }

            catch (Exception err)
            {

                MessageBox.Show(err.Message, "Hata");

            }
           
            
          //www.kodcuyuz.com
        }
        private void CreateDumpDevice()
        {

            //yedek alinacak dizini tanımlıyoruz.

            string path = "C:\\";



            //dump device icin siz istediginiz isimi verebilirsiniz.

            //ben isim olarak sqlBackUp ismini verdim.

            string command = "EXEC sp_addumpdevice 'disk', 'sqlBackUP', '" + path + "yedek.bak'";



            // bu komut sqlBackUp diye bir device oluşturacak ve

            // yedekleme işlemi için  C:/yedek.bak diye bir dosya oluşturulacak.



            // şimdi komutumuzu işletelim.

           

            SqlCommand myCommand = new SqlCommand(command, veritabani.conn);

            veritabani.baglan();

            try
            {

                myCommand.ExecuteNonQuery();

            }

            catch (Exception err)
            {

                if (err.ToString().IndexOf("already exist") > 0)
                {

                    //eger bu device zaten mevcut ise birşey yapmıyoruz. 
                    MessageBox.Show("Dump Device Zeten Mevcuttu.");

                    return;

                }

                else
                {

                    MessageBox.Show(err.Message, "Hata");

                }

            }

            
        }
            

        
    }
}
