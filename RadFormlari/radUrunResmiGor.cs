using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace uretimPlanlamaProgrami.RadFormlari
{
    public partial class radUrunResmiGor : Telerik.WinControls.UI.ShapedForm
    {
        Image resim;
        public radUrunResmiGor(Image resim)
        {
            this.resim = resim;
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void radUrunResmiGor_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = resim;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            pictureBox1.Dock = DockStyle.Fill;
            linkLabel1.Visible = false;
        }

        private void linkLabel2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
