namespace uretimPlanlamaProgrami.RadFormlari
{
    partial class radKullaniciEkle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(radKullaniciEkle));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnKaydet = new Telerik.WinControls.UI.RadButton();
            this.btnYeniKayit = new Telerik.WinControls.UI.RadButton();
            this.txtParolaTekrar = new Telerik.WinControls.UI.RadTextBoxControl();
            this.txtParola = new Telerik.WinControls.UI.RadTextBoxControl();
            this.txtAd = new Telerik.WinControls.UI.RadTextBoxControl();
            this.lblParola = new System.Windows.Forms.Label();
            this.lblTur = new System.Windows.Forms.Label();
            this.lblAd = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTur = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.aquaTheme1 = new Telerik.WinControls.Themes.AquaTheme();
            this.breezeTheme1 = new Telerik.WinControls.Themes.BreezeTheme();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnKaydet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnYeniKayit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtParolaTekrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtParola)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox1.Controls.Add(this.btnKaydet);
            this.groupBox1.Controls.Add(this.btnYeniKayit);
            this.groupBox1.Controls.Add(this.txtParolaTekrar);
            this.groupBox1.Controls.Add(this.txtParola);
            this.groupBox1.Controls.Add(this.txtAd);
            this.groupBox1.Controls.Add(this.lblParola);
            this.groupBox1.Controls.Add(this.lblTur);
            this.groupBox1.Controls.Add(this.lblAd);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbTur);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.groupBox1.Location = new System.Drawing.Point(12, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(886, 297);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kullanıcı bilgileri";
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(399, 200);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(148, 56);
            this.btnKaydet.TabIndex = 8;
            this.btnKaydet.Text = "KAYDET";
            this.btnKaydet.ThemeName = "Aqua";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnYeniKayit
            // 
            this.btnYeniKayit.Location = new System.Drawing.Point(253, 200);
            this.btnYeniKayit.Name = "btnYeniKayit";
            this.btnYeniKayit.Size = new System.Drawing.Size(140, 56);
            this.btnYeniKayit.TabIndex = 8;
            this.btnYeniKayit.Text = "YENİ KAYIT";
            this.btnYeniKayit.ThemeName = "Aqua";
            this.btnYeniKayit.Click += new System.EventHandler(this.btnYeniKayit_Click_1);
            // 
            // txtParolaTekrar
            // 
            this.txtParolaTekrar.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.txtParolaTekrar.Location = new System.Drawing.Point(216, 110);
            this.txtParolaTekrar.MaxLength = 8;
            this.txtParolaTekrar.Name = "txtParolaTekrar";
            this.txtParolaTekrar.NullText = "Parola tekrarı";
            this.txtParolaTekrar.Size = new System.Drawing.Size(331, 29);
            this.txtParolaTekrar.TabIndex = 7;
            this.txtParolaTekrar.UseSystemPasswordChar = true;
            // 
            // txtParola
            // 
            this.txtParola.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.txtParola.Location = new System.Drawing.Point(216, 69);
            this.txtParola.MaxLength = 8;
            this.txtParola.Name = "txtParola";
            this.txtParola.NullText = "Parola";
            this.txtParola.Size = new System.Drawing.Size(331, 29);
            this.txtParola.TabIndex = 7;
            this.txtParola.UseSystemPasswordChar = true;
            // 
            // txtAd
            // 
            this.txtAd.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.txtAd.Location = new System.Drawing.Point(216, 34);
            this.txtAd.Name = "txtAd";
            this.txtAd.NullText = "Kullanıcı adı";
            this.txtAd.Size = new System.Drawing.Size(331, 29);
            this.txtAd.TabIndex = 7;
            this.txtAd.ThemeName = "Aqua";
            // 
            // lblParola
            // 
            this.lblParola.AutoSize = true;
            this.lblParola.ForeColor = System.Drawing.Color.Red;
            this.lblParola.Location = new System.Drawing.Point(570, 69);
            this.lblParola.Name = "lblParola";
            this.lblParola.Size = new System.Drawing.Size(0, 20);
            this.lblParola.TabIndex = 4;
            // 
            // lblTur
            // 
            this.lblTur.AutoSize = true;
            this.lblTur.ForeColor = System.Drawing.Color.Red;
            this.lblTur.Location = new System.Drawing.Point(570, 115);
            this.lblTur.Name = "lblTur";
            this.lblTur.Size = new System.Drawing.Size(0, 20);
            this.lblTur.TabIndex = 4;
            // 
            // lblAd
            // 
            this.lblAd.AutoSize = true;
            this.lblAd.ForeColor = System.Drawing.Color.Red;
            this.lblAd.Location = new System.Drawing.Point(570, 43);
            this.lblAd.Name = "lblAd";
            this.lblAd.Size = new System.Drawing.Size(0, 20);
            this.lblAd.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(92, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kullanıcı Adı :";
            // 
            // cmbTur
            // 
            this.cmbTur.FormattingEnabled = true;
            this.cmbTur.Items.AddRange(new object[] {
            "Admin",
            "Normal Kullanıcı"});
            this.cmbTur.Location = new System.Drawing.Point(216, 149);
            this.cmbTur.Name = "cmbTur";
            this.cmbTur.Size = new System.Drawing.Size(331, 28);
            this.cmbTur.TabIndex = 2;
            this.cmbTur.Text = "Seçiniz";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(158, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 22);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tür :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(38, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(172, 22);
            this.label4.TabIndex = 1;
            this.label4.Text = "Parolayı Tekrar Gir :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(133, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Parola  :";
            // 
            // radKullaniciEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 347);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(918, 380);
            this.Name = "radKullaniciEkle";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.RootElement.MaxSize = new System.Drawing.Size(918, 380);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kullanıcı Ekle";
            this.ThemeName = "Breeze";
            this.Load += new System.EventHandler(this.radKullaniciEkle_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnKaydet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnYeniKayit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtParolaTekrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtParola)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Telerik.WinControls.UI.RadButton btnKaydet;
        private Telerik.WinControls.UI.RadButton btnYeniKayit;
        private Telerik.WinControls.UI.RadTextBoxControl txtParolaTekrar;
        private Telerik.WinControls.UI.RadTextBoxControl txtParola;
        private Telerik.WinControls.UI.RadTextBoxControl txtAd;
        private System.Windows.Forms.Label lblParola;
        private System.Windows.Forms.Label lblTur;
        private System.Windows.Forms.Label lblAd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTur;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private Telerik.WinControls.Themes.AquaTheme aquaTheme1;
        private Telerik.WinControls.Themes.BreezeTheme breezeTheme1;
    }
}
