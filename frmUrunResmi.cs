using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace uretimPlanlamaProgrami
{
    public partial class frmUrunResmi : Form
    {
        Image resim;
        public frmUrunResmi(Image resim)
        {
            this.resim = resim;
            InitializeComponent();
        }

        private void frmUrunResmi_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = resim;
        }

        private void lblTamBoyutGor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            this.WindowState = FormWindowState.Maximized;
            pictureBox1.Dock = DockStyle.Fill;
            lblTamBoyutGor.Visible = false;
        }
    }
}
