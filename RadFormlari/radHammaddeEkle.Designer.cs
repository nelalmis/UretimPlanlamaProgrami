namespace uretimPlanlamaProgrami.RadFormlari
{
    partial class radHammaddeEkle
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(radHammaddeEkle));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnlMaddeler = new System.Windows.Forms.Panel();
            this.pnlDurum = new System.Windows.Forms.Panel();
            this.lblKalan = new System.Windows.Forms.Label();
            this.lblKalanMiktar = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTemizle = new Telerik.WinControls.UI.RadButton();
            this.btnOranBelirle = new Telerik.WinControls.UI.RadButton();
            this.radCheckedListBox1 = new Telerik.WinControls.UI.RadCheckedListBox();
            this.ıcerikBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.genelDataSet = new uretimPlanlamaProgrami.genelDataSet();
            this.btnYeniHammadde = new Telerik.WinControls.UI.RadButton();
            this.btnKaydet = new Telerik.WinControls.UI.RadButton();
            this.txtHammadde = new Telerik.WinControls.UI.RadTextBoxControl();
            this.label1 = new System.Windows.Forms.Label();
            this.aquaTheme1 = new Telerik.WinControls.Themes.AquaTheme();
            this.breezeTheme1 = new Telerik.WinControls.Themes.BreezeTheme();
            this.icerikTableAdapter = new uretimPlanlamaProgrami.genelDataSetTableAdapters.IcerikTableAdapter();
            this.groupBox1.SuspendLayout();
            this.pnlMaddeler.SuspendLayout();
            this.pnlDurum.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnTemizle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOranBelirle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckedListBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ıcerikBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.genelDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnYeniHammadde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnKaydet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHammadde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightSlateGray;
            this.groupBox1.Controls.Add(this.pnlMaddeler);
            this.groupBox1.Controls.Add(this.btnYeniHammadde);
            this.groupBox1.Controls.Add(this.btnKaydet);
            this.groupBox1.Controls.Add(this.txtHammadde);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(803, 602);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hammadde ";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // pnlMaddeler
            // 
            this.pnlMaddeler.AutoScroll = true;
            this.pnlMaddeler.Controls.Add(this.pnlDurum);
            this.pnlMaddeler.Controls.Add(this.panel1);
            this.pnlMaddeler.Controls.Add(this.label2);
            this.pnlMaddeler.Controls.Add(this.btnTemizle);
            this.pnlMaddeler.Controls.Add(this.btnOranBelirle);
            this.pnlMaddeler.Controls.Add(this.radCheckedListBox1);
            this.pnlMaddeler.Location = new System.Drawing.Point(53, 81);
            this.pnlMaddeler.Name = "pnlMaddeler";
            this.pnlMaddeler.Size = new System.Drawing.Size(735, 408);
            this.pnlMaddeler.TabIndex = 6;
            // 
            // pnlDurum
            // 
            this.pnlDurum.Controls.Add(this.lblKalan);
            this.pnlDurum.Controls.Add(this.lblKalanMiktar);
            this.pnlDurum.Location = new System.Drawing.Point(190, 4);
            this.pnlDurum.Name = "pnlDurum";
            this.pnlDurum.Size = new System.Drawing.Size(404, 30);
            this.pnlDurum.TabIndex = 0;
            // 
            // lblKalan
            // 
            this.lblKalan.AutoSize = true;
            this.lblKalan.Location = new System.Drawing.Point(147, 4);
            this.lblKalan.Name = "lblKalan";
            this.lblKalan.Size = new System.Drawing.Size(51, 20);
            this.lblKalan.TabIndex = 8;
            this.lblKalan.Text = "label3";
            // 
            // lblKalanMiktar
            // 
            this.lblKalanMiktar.AutoSize = true;
            this.lblKalanMiktar.Location = new System.Drawing.Point(15, 4);
            this.lblKalanMiktar.Name = "lblKalanMiktar";
            this.lblKalanMiktar.Size = new System.Drawing.Size(126, 20);
            this.lblKalanMiktar.TabIndex = 7;
            this.lblKalanMiktar.Text = "Kalan / Toplam =";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(190, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(542, 362);
            this.panel1.TabIndex = 6;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label2.Location = new System.Drawing.Point(3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "         İÇERİKLER           ";
            // 
            // btnTemizle
            // 
            this.btnTemizle.Location = new System.Drawing.Point(600, 4);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(132, 29);
            this.btnTemizle.TabIndex = 4;
            this.btnTemizle.Text = "Maddeleri Yenile";
            this.btnTemizle.ThemeName = "Breeze";
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // btnOranBelirle
            // 
            this.btnOranBelirle.Location = new System.Drawing.Point(3, 361);
            this.btnOranBelirle.Name = "btnOranBelirle";
            this.btnOranBelirle.Size = new System.Drawing.Size(180, 41);
            this.btnOranBelirle.TabIndex = 3;
            this.btnOranBelirle.Text = "SEÇ";
            this.btnOranBelirle.Click += new System.EventHandler(this.btnOranBelirle_Click);
            // 
            // radCheckedListBox1
            // 
            this.radCheckedListBox1.DataSource = this.ıcerikBindingSource;
            this.radCheckedListBox1.DisplayMember = "icerikAdi";
            this.radCheckedListBox1.Location = new System.Drawing.Point(3, 27);
            this.radCheckedListBox1.Name = "radCheckedListBox1";
            this.radCheckedListBox1.Size = new System.Drawing.Size(180, 328);
            this.radCheckedListBox1.TabIndex = 0;
            this.radCheckedListBox1.Text = "radCheckedListBox1";
            this.radCheckedListBox1.ThemeName = "Aqua";
            this.radCheckedListBox1.ValueMember = "id";
            // 
            // ıcerikBindingSource
            // 
            this.ıcerikBindingSource.DataMember = "Icerik";
            this.ıcerikBindingSource.DataSource = this.genelDataSet;
            // 
            // genelDataSet
            // 
            this.genelDataSet.DataSetName = "genelDataSet";
            this.genelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnYeniHammadde
            // 
            this.btnYeniHammadde.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.btnYeniHammadde.Location = new System.Drawing.Point(437, 535);
            this.btnYeniHammadde.Name = "btnYeniHammadde";
            this.btnYeniHammadde.Size = new System.Drawing.Size(177, 61);
            this.btnYeniHammadde.TabIndex = 4;
            this.btnYeniHammadde.Text = "YENİ HAMMADDE";
            this.btnYeniHammadde.ThemeName = "Aqua";
            this.btnYeniHammadde.Click += new System.EventHandler(this.btnYeniHammadde_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.btnKaydet.Location = new System.Drawing.Point(620, 535);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(177, 61);
            this.btnKaydet.TabIndex = 4;
            this.btnKaydet.Text = "KAYDET";
            this.btnKaydet.ThemeName = "Aqua";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // txtHammadde
            // 
            this.txtHammadde.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.txtHammadde.Location = new System.Drawing.Point(182, 25);
            this.txtHammadde.Name = "txtHammadde";
            this.txtHammadde.NullText = "Hammadde adı";
            this.txtHammadde.Size = new System.Drawing.Size(335, 40);
            this.txtHammadde.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.ForeColor = System.Drawing.Color.SeaGreen;
            this.label1.Location = new System.Drawing.Point(49, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hammadde Adı :";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // icerikTableAdapter
            // 
            this.icerikTableAdapter.ClearBeforeFill = true;
            // 
            // radHammaddeEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 626);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "radHammaddeEkle";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.RootElement.MaxSize = new System.Drawing.Size(0, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hammadde Ekle";
            this.ThemeName = "Breeze";
            this.Load += new System.EventHandler(this.radHammaddeEkle_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlMaddeler.ResumeLayout(false);
            this.pnlMaddeler.PerformLayout();
            this.pnlDurum.ResumeLayout(false);
            this.pnlDurum.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnTemizle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOranBelirle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckedListBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ıcerikBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.genelDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnYeniHammadde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnKaydet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHammadde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Telerik.WinControls.UI.RadButton btnKaydet;
        private Telerik.WinControls.UI.RadTextBoxControl txtHammadde;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.Themes.AquaTheme aquaTheme1;
        private Telerik.WinControls.Themes.BreezeTheme breezeTheme1;
        private System.Windows.Forms.Panel pnlMaddeler;
        private Telerik.WinControls.UI.RadCheckedListBox radCheckedListBox1;
        private genelDataSet genelDataSet;
        private System.Windows.Forms.BindingSource ıcerikBindingSource;
        private genelDataSetTableAdapters.IcerikTableAdapter icerikTableAdapter;
        private Telerik.WinControls.UI.RadButton btnOranBelirle;
        private Telerik.WinControls.UI.RadButton btnTemizle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private Telerik.WinControls.UI.RadButton btnYeniHammadde;
        private System.Windows.Forms.Panel pnlToplamMiktarBelirle;
        private System.Windows.Forms.Label lblKalanMiktar;
        private System.Windows.Forms.Panel pnlDurum;
        private System.Windows.Forms.Label lblKalan;
    }
}
