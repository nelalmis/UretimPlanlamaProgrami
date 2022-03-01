namespace uretimPlanlamaProgrami
{
    partial class frmYedekAl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rdSiparis = new System.Windows.Forms.RadioButton();
            this.rdUrunler = new System.Windows.Forms.RadioButton();
            this.rdUretimHat = new System.Windows.Forms.RadioButton();
            this.rdRenkler = new System.Windows.Forms.RadioButton();
            this.rdHammadde = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdVeritabani = new System.Windows.Forms.RadioButton();
            this.btnYedekAl = new System.Windows.Forms.Button();
            this.lblDurum = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdSiparis
            // 
            this.rdSiparis.AutoSize = true;
            this.rdSiparis.Location = new System.Drawing.Point(21, 29);
            this.rdSiparis.Name = "rdSiparis";
            this.rdSiparis.Size = new System.Drawing.Size(102, 17);
            this.rdSiparis.TabIndex = 0;
            this.rdSiparis.TabStop = true;
            this.rdSiparis.Text = "Siparişler Listesi ";
            this.rdSiparis.UseVisualStyleBackColor = true;
            // 
            // rdUrunler
            // 
            this.rdUrunler.AutoSize = true;
            this.rdUrunler.Location = new System.Drawing.Point(21, 53);
            this.rdUrunler.Name = "rdUrunler";
            this.rdUrunler.Size = new System.Drawing.Size(88, 17);
            this.rdUrunler.TabIndex = 1;
            this.rdUrunler.TabStop = true;
            this.rdUrunler.Text = "Üünler Listesi";
            this.rdUrunler.UseVisualStyleBackColor = true;
            // 
            // rdUretimHat
            // 
            this.rdUretimHat.AutoSize = true;
            this.rdUretimHat.Location = new System.Drawing.Point(21, 76);
            this.rdUretimHat.Name = "rdUretimHat";
            this.rdUretimHat.Size = new System.Drawing.Size(88, 17);
            this.rdUretimHat.TabIndex = 0;
            this.rdUretimHat.TabStop = true;
            this.rdUretimHat.Text = "Üretim Hatları";
            this.rdUretimHat.UseVisualStyleBackColor = true;
            // 
            // rdRenkler
            // 
            this.rdRenkler.AutoSize = true;
            this.rdRenkler.Location = new System.Drawing.Point(21, 100);
            this.rdRenkler.Name = "rdRenkler";
            this.rdRenkler.Size = new System.Drawing.Size(94, 17);
            this.rdRenkler.TabIndex = 1;
            this.rdRenkler.TabStop = true;
            this.rdRenkler.Text = "Renkler Listesi";
            this.rdRenkler.UseVisualStyleBackColor = true;
            // 
            // rdHammadde
            // 
            this.rdHammadde.AutoSize = true;
            this.rdHammadde.Location = new System.Drawing.Point(21, 123);
            this.rdHammadde.Name = "rdHammadde";
            this.rdHammadde.Size = new System.Drawing.Size(116, 17);
            this.rdHammadde.TabIndex = 1;
            this.rdHammadde.TabStop = true;
            this.rdHammadde.Text = "Hammadeler Listesi";
            this.rdHammadde.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdUrunler);
            this.groupBox1.Controls.Add(this.rdVeritabani);
            this.groupBox1.Controls.Add(this.rdHammadde);
            this.groupBox1.Controls.Add(this.rdSiparis);
            this.groupBox1.Controls.Add(this.rdRenkler);
            this.groupBox1.Controls.Add(this.rdUretimHat);
            this.groupBox1.Location = new System.Drawing.Point(35, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(203, 169);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // rdVeritabani
            // 
            this.rdVeritabani.AutoSize = true;
            this.rdVeritabani.Location = new System.Drawing.Point(21, 146);
            this.rdVeritabani.Name = "rdVeritabani";
            this.rdVeritabani.Size = new System.Drawing.Size(152, 17);
            this.rdVeritabani.TabIndex = 1;
            this.rdVeritabani.TabStop = true;
            this.rdVeritabani.Text = "Tüm Veritabanı Yedeğini Al";
            this.rdVeritabani.UseVisualStyleBackColor = true;
            // 
            // btnYedekAl
            // 
            this.btnYedekAl.Location = new System.Drawing.Point(35, 187);
            this.btnYedekAl.Name = "btnYedekAl";
            this.btnYedekAl.Size = new System.Drawing.Size(203, 56);
            this.btnYedekAl.TabIndex = 3;
            this.btnYedekAl.Text = "Yedek Al";
            this.btnYedekAl.UseVisualStyleBackColor = true;
            this.btnYedekAl.Click += new System.EventHandler(this.btnYedekAl_Click);
            // 
            // lblDurum
            // 
            this.lblDurum.AutoSize = true;
            this.lblDurum.Location = new System.Drawing.Point(32, 255);
            this.lblDurum.Name = "lblDurum";
            this.lblDurum.Size = new System.Drawing.Size(35, 13);
            this.lblDurum.TabIndex = 4;
            this.lblDurum.Text = "label1";
            // 
            // frmYedekAl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 431);
            this.Controls.Add(this.lblDurum);
            this.Controls.Add(this.btnYedekAl);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmYedekAl";
            this.Text = "frmYedekAl";
            this.Load += new System.EventHandler(this.frmYedekAl_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdSiparis;
        private System.Windows.Forms.RadioButton rdUrunler;
        private System.Windows.Forms.RadioButton rdUretimHat;
        private System.Windows.Forms.RadioButton rdRenkler;
        private System.Windows.Forms.RadioButton rdHammadde;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdVeritabani;
        private System.Windows.Forms.Button btnYedekAl;
        private System.Windows.Forms.Label lblDurum;
    }
}