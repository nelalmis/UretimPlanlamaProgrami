using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace uretimPlanlamaProgrami.RadFormlari
{
    public partial class radFrmTemaAyarlari : Form
    {
        public radFrmTemaAyarlari()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ColorDialog colorDialog1 = new ColorDialog();
            colorDialog1.Color = lblHaaftalik.BackColor;
            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK && colorDialog1.Color != lblHaaftalik.BackColor)
            {
                lblHaaftalik.BackColor = colorDialog1.Color;
            }

            hatRenkleri.haftalikTatilRengi = lblTamamen.BackColor;
        }
        HatRenkleri hatRenkleri = new HatRenkleri();
        Fonksiyonlar fonksiyon = new Fonksiyonlar();
        private void radFrmTemaAyarlari_Load(object sender, EventArgs e)
        {
            
            lblHaaftalik.BackColor = hatRenkleri.haftalikTatilRengi;
            lblEk.BackColor = hatRenkleri.ekTatilRengi;
            lblTamamen.BackColor = hatRenkleri.tamamenPasiflestirilenHatRengi;
            lblTamamen.BackColor = hatRenkleri.kismenPasifleştirilenHatRengi;
        }
    }
}
