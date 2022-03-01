namespace uretimPlanlamaProgrami
{
    partial class frmAyarlar
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAyarlariKaydet = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.grpTatilGunleri = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listDigerTatilGunleri = new System.Windows.Forms.ListBox();
            this.txtKayitliAciklama = new System.Windows.Forms.TextBox();
            this.btnAciklamaGuncelle = new System.Windows.Forms.Button();
            this.btnTatilGUnuPasif = new System.Windows.Forms.Button();
            this.btnTatilGunuSil = new System.Windows.Forms.Button();
            this.txtAciklama = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnTatilGunuEkle = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.grpKullanilamayan = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.listKullanilamayanHatlar = new System.Windows.Forms.ListBox();
            this.grpKullanilabilen = new System.Windows.Forms.GroupBox();
            this.btnPasiflestir = new System.Windows.Forms.Button();
            this.lisKullanilabilirHatlar = new System.Windows.Forms.ListBox();
            this.chcDigerTatilGun = new System.Windows.Forms.CheckBox();
            this.chcHatPasiflestirilsinmi = new System.Windows.Forms.CheckBox();
            this.cmbGunler = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.rdGorunurOlanlar = new System.Windows.Forms.RadioButton();
            this.rdGizli = new System.Windows.Forms.RadioButton();
            this.rdHerIkisi = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.grpTatilGunleri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpKullanilamayan.SuspendLayout();
            this.grpKullanilabilen.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox1.Controls.Add(this.btnAyarlariKaydet);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.grpTatilGunleri);
            this.groupBox1.Controls.Add(this.grpKullanilamayan);
            this.groupBox1.Controls.Add(this.grpKullanilabilen);
            this.groupBox1.Controls.Add(this.chcDigerTatilGun);
            this.groupBox1.Controls.Add(this.chcHatPasiflestirilsinmi);
            this.groupBox1.Controls.Add(this.cmbGunler);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(12, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1099, 473);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ayarlar";
            // 
            // btnAyarlariKaydet
            // 
            this.btnAyarlariKaydet.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAyarlariKaydet.Location = new System.Drawing.Point(957, 416);
            this.btnAyarlariKaydet.Name = "btnAyarlariKaydet";
            this.btnAyarlariKaydet.Size = new System.Drawing.Size(136, 51);
            this.btnAyarlariKaydet.TabIndex = 1;
            this.btnAyarlariKaydet.Text = "AYARLARI KAYDET";
            this.btnAyarlariKaydet.UseVisualStyleBackColor = true;
            this.btnAyarlariKaydet.Click += new System.EventHandler(this.btnAyarlariKaydet_Click);
            // 
            // button3
            // 
            this.button3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button3.Location = new System.Drawing.Point(817, 417);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(134, 50);
            this.button3.TabIndex = 2;
            this.button3.Text = "KAYDETMEDEN ÇIK";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // grpTatilGunleri
            // 
            this.grpTatilGunleri.Controls.Add(this.rdHerIkisi);
            this.grpTatilGunleri.Controls.Add(this.rdGizli);
            this.grpTatilGunleri.Controls.Add(this.rdGorunurOlanlar);
            this.grpTatilGunleri.Controls.Add(this.splitContainer1);
            this.grpTatilGunleri.Controls.Add(this.btnAciklamaGuncelle);
            this.grpTatilGunleri.Controls.Add(this.btnTatilGUnuPasif);
            this.grpTatilGunleri.Controls.Add(this.btnTatilGunuSil);
            this.grpTatilGunleri.Controls.Add(this.txtAciklama);
            this.grpTatilGunleri.Controls.Add(this.dateTimePicker1);
            this.grpTatilGunleri.Controls.Add(this.btnTatilGunuEkle);
            this.grpTatilGunleri.Controls.Add(this.label3);
            this.grpTatilGunleri.Location = new System.Drawing.Point(418, 58);
            this.grpTatilGunleri.Name = "grpTatilGunleri";
            this.grpTatilGunleri.Size = new System.Drawing.Size(675, 352);
            this.grpTatilGunleri.TabIndex = 9;
            this.grpTatilGunleri.TabStop = false;
            this.grpTatilGunleri.Text = "Tatil Gunleri Ekle";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(287, 39);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listDigerTatilGunleri);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtKayitliAciklama);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Size = new System.Drawing.Size(228, 301);
            this.splitContainer1.SplitterDistance = 170;
            this.splitContainer1.TabIndex = 10;
            // 
            // listDigerTatilGunleri
            // 
            this.listDigerTatilGunleri.FormattingEnabled = true;
            this.listDigerTatilGunleri.ItemHeight = 18;
            this.listDigerTatilGunleri.Location = new System.Drawing.Point(3, 3);
            this.listDigerTatilGunleri.Name = "listDigerTatilGunleri";
            this.listDigerTatilGunleri.Size = new System.Drawing.Size(222, 166);
            this.listDigerTatilGunleri.TabIndex = 4;
            this.listDigerTatilGunleri.SelectedIndexChanged += new System.EventHandler(this.listDigerTatilGunleri_SelectedIndexChanged);
            // 
            // txtKayitliAciklama
            // 
            this.txtKayitliAciklama.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtKayitliAciklama.Location = new System.Drawing.Point(3, 3);
            this.txtKayitliAciklama.Multiline = true;
            this.txtKayitliAciklama.Name = "txtKayitliAciklama";
            this.txtKayitliAciklama.Size = new System.Drawing.Size(223, 120);
            this.txtKayitliAciklama.TabIndex = 9;
            // 
            // btnAciklamaGuncelle
            // 
            this.btnAciklamaGuncelle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAciklamaGuncelle.Location = new System.Drawing.Point(519, 295);
            this.btnAciklamaGuncelle.Name = "btnAciklamaGuncelle";
            this.btnAciklamaGuncelle.Size = new System.Drawing.Size(142, 45);
            this.btnAciklamaGuncelle.TabIndex = 2;
            this.btnAciklamaGuncelle.Text = "Açıklamayı Güncelle";
            this.btnAciklamaGuncelle.UseVisualStyleBackColor = true;
            this.btnAciklamaGuncelle.Click += new System.EventHandler(this.btnAciklamaGuncelle_Click);
            // 
            // btnTatilGUnuPasif
            // 
            this.btnTatilGUnuPasif.Location = new System.Drawing.Point(519, 116);
            this.btnTatilGUnuPasif.Name = "btnTatilGUnuPasif";
            this.btnTatilGUnuPasif.Size = new System.Drawing.Size(142, 50);
            this.btnTatilGUnuPasif.TabIndex = 2;
            this.btnTatilGUnuPasif.Text = "Seçili Tarihi Gizle";
            this.btnTatilGUnuPasif.UseVisualStyleBackColor = true;
            this.btnTatilGUnuPasif.Click += new System.EventHandler(this.btnTatilGUnuPasif_Click);
            // 
            // btnTatilGunuSil
            // 
            this.btnTatilGunuSil.Location = new System.Drawing.Point(521, 63);
            this.btnTatilGunuSil.Name = "btnTatilGunuSil";
            this.btnTatilGunuSil.Size = new System.Drawing.Size(142, 50);
            this.btnTatilGunuSil.TabIndex = 2;
            this.btnTatilGunuSil.Text = "Secili Tatil Gününü Sil";
            this.btnTatilGunuSil.UseVisualStyleBackColor = true;
            this.btnTatilGunuSil.Click += new System.EventHandler(this.btnTatilGunuSil_Click);
            // 
            // txtAciklama
            // 
            this.txtAciklama.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtAciklama.Location = new System.Drawing.Point(10, 116);
            this.txtAciklama.Multiline = true;
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(255, 189);
            this.txtAciklama.TabIndex = 9;
            this.txtAciklama.TextChanged += new System.EventHandler(this.txtAciklama_TextChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(10, 56);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(255, 24);
            this.dateTimePicker1.TabIndex = 8;
            // 
            // btnTatilGunuEkle
            // 
            this.btnTatilGunuEkle.BackColor = System.Drawing.Color.Blue;
            this.btnTatilGunuEkle.ForeColor = System.Drawing.Color.White;
            this.btnTatilGunuEkle.Location = new System.Drawing.Point(10, 311);
            this.btnTatilGunuEkle.Name = "btnTatilGunuEkle";
            this.btnTatilGunuEkle.Size = new System.Drawing.Size(255, 29);
            this.btnTatilGunuEkle.TabIndex = 5;
            this.btnTatilGunuEkle.Text = "Tatil Günlerine Ekle";
            this.btnTatilGunuEkle.UseVisualStyleBackColor = false;
            this.btnTatilGunuEkle.Click += new System.EventHandler(this.btnTatilGunuEkle_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(6, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Açıklama";
            // 
            // grpKullanilamayan
            // 
            this.grpKullanilamayan.BackColor = System.Drawing.Color.Red;
            this.grpKullanilamayan.Controls.Add(this.button1);
            this.grpKullanilamayan.Controls.Add(this.listKullanilamayanHatlar);
            this.grpKullanilamayan.Location = new System.Drawing.Point(215, 128);
            this.grpKullanilamayan.Name = "grpKullanilamayan";
            this.grpKullanilamayan.Size = new System.Drawing.Size(168, 219);
            this.grpKullanilamayan.TabIndex = 7;
            this.grpKullanilamayan.TabStop = false;
            this.grpKullanilamayan.Text = "Kullanılamayan Hatlar";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Lime;
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(6, 190);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 29);
            this.button1.TabIndex = 6;
            this.button1.Text = "Seçili Hattı Aktifleştir";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listKullanilamayanHatlar
            // 
            this.listKullanilamayanHatlar.FormattingEnabled = true;
            this.listKullanilamayanHatlar.ItemHeight = 18;
            this.listKullanilamayanHatlar.Location = new System.Drawing.Point(6, 23);
            this.listKullanilamayanHatlar.Name = "listKullanilamayanHatlar";
            this.listKullanilamayanHatlar.Size = new System.Drawing.Size(150, 166);
            this.listKullanilamayanHatlar.TabIndex = 5;
            // 
            // grpKullanilabilen
            // 
            this.grpKullanilabilen.BackColor = System.Drawing.Color.Lime;
            this.grpKullanilabilen.Controls.Add(this.btnPasiflestir);
            this.grpKullanilabilen.Controls.Add(this.lisKullanilabilirHatlar);
            this.grpKullanilabilen.Location = new System.Drawing.Point(47, 128);
            this.grpKullanilabilen.Name = "grpKullanilabilen";
            this.grpKullanilabilen.Size = new System.Drawing.Size(162, 219);
            this.grpKullanilabilen.TabIndex = 6;
            this.grpKullanilabilen.TabStop = false;
            this.grpKullanilabilen.Text = "Kullanılabilen Hatlar";
            // 
            // btnPasiflestir
            // 
            this.btnPasiflestir.BackColor = System.Drawing.Color.Red;
            this.btnPasiflestir.ForeColor = System.Drawing.Color.White;
            this.btnPasiflestir.Location = new System.Drawing.Point(6, 190);
            this.btnPasiflestir.Name = "btnPasiflestir";
            this.btnPasiflestir.Size = new System.Drawing.Size(150, 29);
            this.btnPasiflestir.TabIndex = 5;
            this.btnPasiflestir.Text = "Seçili Hattı Pasifleştir";
            this.btnPasiflestir.UseVisualStyleBackColor = false;
            this.btnPasiflestir.Click += new System.EventHandler(this.btnPasiflestir_Click);
            // 
            // lisKullanilabilirHatlar
            // 
            this.lisKullanilabilirHatlar.FormattingEnabled = true;
            this.lisKullanilabilirHatlar.ItemHeight = 18;
            this.lisKullanilabilirHatlar.Location = new System.Drawing.Point(6, 23);
            this.lisKullanilabilirHatlar.Name = "lisKullanilabilirHatlar";
            this.lisKullanilabilirHatlar.Size = new System.Drawing.Size(150, 166);
            this.lisKullanilabilirHatlar.TabIndex = 4;
            // 
            // chcDigerTatilGun
            // 
            this.chcDigerTatilGun.AutoSize = true;
            this.chcDigerTatilGun.Location = new System.Drawing.Point(402, 35);
            this.chcDigerTatilGun.Name = "chcDigerTatilGun";
            this.chcDigerTatilGun.Size = new System.Drawing.Size(144, 22);
            this.chcDigerTatilGun.TabIndex = 3;
            this.chcDigerTatilGun.Text = "Diğer Tatil Günleri";
            this.chcDigerTatilGun.UseVisualStyleBackColor = true;
            this.chcDigerTatilGun.CheckedChanged += new System.EventHandler(this.chcDigerTatilGun_CheckedChanged);
            // 
            // chcHatPasiflestirilsinmi
            // 
            this.chcHatPasiflestirilsinmi.AutoSize = true;
            this.chcHatPasiflestirilsinmi.Location = new System.Drawing.Point(47, 100);
            this.chcHatPasiflestirilsinmi.Name = "chcHatPasiflestirilsinmi";
            this.chcHatPasiflestirilsinmi.Size = new System.Drawing.Size(284, 22);
            this.chcHatPasiflestirilsinmi.TabIndex = 3;
            this.chcHatPasiflestirilsinmi.Text = "HAT AKTİFLEŞİRME/PASİFLEŞTİRME";
            this.chcHatPasiflestirilsinmi.UseVisualStyleBackColor = true;
            this.chcHatPasiflestirilsinmi.CheckedChanged += new System.EventHandler(this.chcHatPasiflestirilsinmi_CheckedChanged);
            // 
            // cmbGunler
            // 
            this.cmbGunler.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbGunler.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGunler.FormattingEnabled = true;
            this.cmbGunler.Location = new System.Drawing.Point(211, 35);
            this.cmbGunler.Name = "cmbGunler";
            this.cmbGunler.Size = new System.Drawing.Size(155, 26);
            this.cmbGunler.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(112, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tatil Günü";
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            this.toolTip1.ToolTipTitle = "Uyarı";
            // 
            // rdGorunurOlanlar
            // 
            this.rdGorunurOlanlar.AutoSize = true;
            this.rdGorunurOlanlar.Location = new System.Drawing.Point(264, 11);
            this.rdGorunurOlanlar.Name = "rdGorunurOlanlar";
            this.rdGorunurOlanlar.Size = new System.Drawing.Size(132, 22);
            this.rdGorunurOlanlar.TabIndex = 11;
            this.rdGorunurOlanlar.TabStop = true;
            this.rdGorunurOlanlar.Text = "Görünür Olanlar";
            this.rdGorunurOlanlar.UseVisualStyleBackColor = true;
            this.rdGorunurOlanlar.CheckedChanged += new System.EventHandler(this.rdGorunurOlanlar_CheckedChanged);
            // 
            // rdGizli
            // 
            this.rdGizli.AutoSize = true;
            this.rdGizli.Location = new System.Drawing.Point(399, 11);
            this.rdGizli.Name = "rdGizli";
            this.rdGizli.Size = new System.Drawing.Size(106, 22);
            this.rdGizli.TabIndex = 11;
            this.rdGizli.TabStop = true;
            this.rdGizli.Text = "Gizli Olanlar";
            this.rdGizli.UseVisualStyleBackColor = true;
            this.rdGizli.CheckedChanged += new System.EventHandler(this.rdGizli_CheckedChanged);
            // 
            // rdHerIkisi
            // 
            this.rdHerIkisi.AutoSize = true;
            this.rdHerIkisi.Location = new System.Drawing.Point(511, 11);
            this.rdHerIkisi.Name = "rdHerIkisi";
            this.rdHerIkisi.Size = new System.Drawing.Size(79, 22);
            this.rdHerIkisi.TabIndex = 11;
            this.rdHerIkisi.TabStop = true;
            this.rdHerIkisi.Text = "Her İkisi";
            this.rdHerIkisi.UseVisualStyleBackColor = true;
            this.rdHerIkisi.CheckedChanged += new System.EventHandler(this.rdHerIkisi_CheckedChanged);
            // 
            // frmAyarlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.CancelButton = this.button3;
            this.ClientSize = new System.Drawing.Size(1177, 541);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "frmAyarlar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AYARLAR";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAyarlar_FormClosed);
            this.Load += new System.EventHandler(this.frmAyarlar_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpTatilGunleri.ResumeLayout(false);
            this.grpTatilGunleri.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grpKullanilamayan.ResumeLayout(false);
            this.grpKullanilabilen.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbGunler;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpKullanilamayan;
        private System.Windows.Forms.ListBox listKullanilamayanHatlar;
        private System.Windows.Forms.GroupBox grpKullanilabilen;
        private System.Windows.Forms.ListBox lisKullanilabilirHatlar;
        private System.Windows.Forms.CheckBox chcHatPasiflestirilsinmi;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnPasiflestir;
        private System.Windows.Forms.Button btnAyarlariKaydet;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox grpTatilGunleri;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnTatilGunuEkle;
        private System.Windows.Forms.ListBox listDigerTatilGunleri;
        private System.Windows.Forms.CheckBox chcDigerTatilGun;
        private System.Windows.Forms.TextBox txtAciklama;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtKayitliAciklama;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnTatilGunuSil;
        private System.Windows.Forms.Button btnAciklamaGuncelle;
        private System.Windows.Forms.Button btnTatilGUnuPasif;
        private System.Windows.Forms.RadioButton rdHerIkisi;
        private System.Windows.Forms.RadioButton rdGizli;
        private System.Windows.Forms.RadioButton rdGorunurOlanlar;
    }
}