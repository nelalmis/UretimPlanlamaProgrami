using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace uretimPlanlamaProgrami.RadFormlari
{
    public partial class radUrunResimFormu : Telerik.WinControls.UI.RadForm
    {
        Image resim;
        public radUrunResimFormu(Image resim)
        {
            this.resim = resim; 
            InitializeComponent();
        }

        private void radUrunResimFormu_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = resim;

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            pictureBox1.Dock = DockStyle.Fill;
            linkLabel1.Visible = false;

        }
    }
}
