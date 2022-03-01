using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace uretimPlanlamaProgrami
{
    public partial class radPlanFormu : Telerik.WinControls.UI.RadForm
    {

         
        public radPlanFormu()
        {
            InitializeComponent();
        }
        hatalar hata = new hatalar();
        private void radPlanFormu_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'genelDataSet.siparis' table. You can move, or remove it, as needed.
           //this.siparisTableAdapter.Fill(this.genelDataSet.siparis);
           
            //this.siparisTableAdapter.Fill(this.planlamaDataSet6.siparis);
          
            //urunlerBindingSource.Filter = "kod="+genelDataSet.siparis[2];
            
            radLabel1.Text = "";
            
            veritabani.baglan();
            try
            {
                SqlCommand al = new SqlCommand("select numara from uretimHatti order by numara desc", veritabani.conn);
                SqlDataReader oku = al.ExecuteReader();
                RadButton rdBut;

                while (oku.Read())
                {

                    rdBut = new RadButton();
                    rdBut.Width = 121;
                    rdBut.Height = 45;
                    rdBut.Dock = DockStyle.Top;

                    rdBut.Text = "HAT " + oku["numara"].ToString();
                    rdBut.Font = new Font(rdBut.Font.FontFamily.Name, 18);
                    rdBut.Name = oku["numara"].ToString();
                    rdBut.ThemeName = "Breeze";
                    splitContainer1.Panel1.Controls.Add(rdBut);

                    rdBut.Click += new EventHandler(dinamikMetod);
                }



                //SqlCommand al = new SqlCommand("select numara from uretimHatti order by numara desc", veritabani.conn);
                //SqlDataReader oku = al.ExecuteReader();
                //Resource reource = new Resource();
                //while(oku.Read()){
                //    reource = new Resource(Convert.ToInt32(oku["numara"]), "HAT-"+oku["numara"].ToString());
                //    reource.Color = Color.Red;
                //    radScheduler1.Resources.Add(reource);

                //}

                //radScheduler1.GroupType = GroupType.Resource;
                //radScheduler1.ActiveView.ResourcesPerView = 3;

                radScheduler1.GetDayView().DayCount = 1;
                radScheduler1.HeaderFormat = "MMM dd,yyyy dddd";
                radScheduler1.AppointmentTitleFormat = "{0}---{1} -- Sipariş Kodu: {2} Firma Adı: {3} ";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hata.hataKodu = "radPlanFormu-radPlanFormu_Load";
                hata.hataMesajı = ex.Message;
                hata.hataMesajiKaydet();

            }
        }
        protected void dinamikMetod(object sender, EventArgs e)
        {
            RadButton dinamikButon = (sender as RadButton);
            int hatNo =  Convert.ToInt16( dinamikButon.Name);

            
            siparisBindingSource.Filter = "HATNO="+hatNo;
         
           this.siparisTableAdapter.Fill(this.genelDataSet.siparis);
           //urunlerBindingSource.Filter = "kod="+genelDataSet.siparis[2];
          // this.urunlerTableAdapter.Fill(this.genelDataSet.urunler);
           radLabel1.Text = "HAT " + hatNo + " AİT PLANLAMA...";
        }
        
        
        
        
        private void radButton1_Click(object sender, EventArgs e)
        {
            radScheduler1.ActiveView = radScheduler1.ActiveView.GetNextView();
        }

        private void radCalendar1_SelectionChanged_1(object sender, EventArgs e)
        {
            radScheduler1.ActiveView.StartDate = radCalendar1.SelectedDate;
            if (radLabel1.Text == "") {
                radLabel1.Text = "Lütfen planlamasını görmek istediğiniz hattı seçiniz.";
            }
        }

        private void radMenu1_Click(object sender, EventArgs e)
        {

        }

        private void radPopupContainer1_PanelContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            radScheduler1.ActiveView = radScheduler1.ActiveView.GetPreviousView();
        }

        private void radPanel1_Paint(object sender, PaintEventArgs e)
        {

        }




    }
}
