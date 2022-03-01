namespace uretimPlanlamaProgrami.RadFormlari
{
    partial class radRenkEkle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(radRenkEkle));
            this.Renk = new System.Windows.Forms.GroupBox();
            this.txtRenkAdi = new Telerik.WinControls.UI.RadTextBoxControl();
            this.txtRenkKodu = new Telerik.WinControls.UI.RadTextBoxControl();
            this.btnKaydet = new Telerik.WinControls.UI.RadButton();
            this.lblAd = new System.Windows.Forms.Label();
            this.lblKod = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.aquaTheme1 = new Telerik.WinControls.Themes.AquaTheme();
            this.breezeTheme1 = new Telerik.WinControls.Themes.BreezeTheme();
            this.Renk.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRenkAdi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRenkKodu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnKaydet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // Renk
            // 
            this.Renk.BackColor = System.Drawing.Color.Bisque;
            this.Renk.Controls.Add(this.txtRenkAdi);
            this.Renk.Controls.Add(this.txtRenkKodu);
            this.Renk.Controls.Add(this.btnKaydet);
            this.Renk.Controls.Add(this.lblAd);
            this.Renk.Controls.Add(this.lblKod);
            this.Renk.Controls.Add(this.label2);
            this.Renk.Controls.Add(this.label1);
            this.Renk.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Renk.Location = new System.Drawing.Point(12, 23);
            this.Renk.Name = "Renk";
            this.Renk.Size = new System.Drawing.Size(890, 278);
            this.Renk.TabIndex = 0;
            this.Renk.TabStop = false;
            this.Renk.Text = "Renk Bilgileri";
            this.Renk.Enter += new System.EventHandler(this.Renk_Enter);
            // 
            // txtRenkAdi
            // 
            this.txtRenkAdi.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRenkAdi.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.txtRenkAdi.Location = new System.Drawing.Point(137, 105);
            this.txtRenkAdi.Name = "txtRenkAdi";
            this.txtRenkAdi.NullText = "Renk adı";
            this.txtRenkAdi.Size = new System.Drawing.Size(371, 40);
            this.txtRenkAdi.TabIndex = 5;
            this.txtRenkAdi.TextChanged += new System.EventHandler(this.txtRenkAdi_TextChanged);
            // 
            // txtRenkKodu
            // 
            this.txtRenkKodu.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.txtRenkKodu.Location = new System.Drawing.Point(138, 43);
            this.txtRenkKodu.Name = "txtRenkKodu";
            this.txtRenkKodu.NullText = "Renk kodu";
            this.txtRenkKodu.Size = new System.Drawing.Size(370, 39);
            this.txtRenkKodu.TabIndex = 5;
            this.txtRenkKodu.TextChanged += new System.EventHandler(this.txtRenkKodu_TextChanged);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Font = new System.Drawing.Font("Verdana", 15F);
            this.btnKaydet.Location = new System.Drawing.Point(701, 202);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(183, 70);
            this.btnKaydet.TabIndex = 4;
            this.btnKaydet.Text = "RENK EKLE";
            this.btnKaydet.ThemeName = "Aqua";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // lblAd
            // 
            this.lblAd.AutoSize = true;
            this.lblAd.ForeColor = System.Drawing.Color.Red;
            this.lblAd.Location = new System.Drawing.Point(550, 105);
            this.lblAd.Name = "lblAd";
            this.lblAd.Size = new System.Drawing.Size(0, 24);
            this.lblAd.TabIndex = 3;
            // 
            // lblKod
            // 
            this.lblKod.AutoSize = true;
            this.lblKod.ForeColor = System.Drawing.Color.Red;
            this.lblKod.Location = new System.Drawing.Point(550, 43);
            this.lblKod.Name = "lblKod";
            this.lblKod.Size = new System.Drawing.Size(0, 24);
            this.lblKod.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(24, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Renk Adı :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(7, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Renk Kodu :";
            // 
            // radRenkEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(914, 325);
            this.Controls.Add(this.Renk);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(922, 358);
            this.Name = "radRenkEkle";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.RootElement.MaxSize = new System.Drawing.Size(922, 358);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Renk Ekle";
            this.ThemeName = "Breeze";
            this.Renk.ResumeLayout(false);
            this.Renk.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRenkAdi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRenkKodu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnKaydet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Renk;
        private Telerik.WinControls.UI.RadTextBoxControl txtRenkAdi;
        private Telerik.WinControls.UI.RadTextBoxControl txtRenkKodu;
        private Telerik.WinControls.UI.RadButton btnKaydet;
        private System.Windows.Forms.Label lblAd;
        private System.Windows.Forms.Label lblKod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.Themes.AquaTheme aquaTheme1;
        private Telerik.WinControls.Themes.BreezeTheme breezeTheme1;
    }
}
