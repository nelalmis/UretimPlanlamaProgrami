namespace uretimPlanlamaProgrami
{
    partial class frmSiparisEkle
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
            this.txtFirmaAdi = new System.Windows.Forms.TextBox();
            this.txtSiparisKodu = new System.Windows.Forms.TextBox();
            this.cmbHammadde = new System.Windows.Forms.ComboBox();
            this.cmbOncelikSirasi = new System.Windows.Forms.ComboBox();
            this.txtBoy = new System.Windows.Forms.TextBox();
            this.txtAdet = new System.Windows.Forms.TextBox();
            this.cmbRenk = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lblFirmaAdi = new System.Windows.Forms.Label();
            this.lblRenk = new System.Windows.Forms.Label();
            this.lblAdet = new System.Windows.Forms.Label();
            this.lblKod = new System.Windows.Forms.Label();
            this.lblBoy = new System.Windows.Forms.Label();
            this.lblOncelik = new System.Windows.Forms.Label();
            this.lblHammadde = new System.Windows.Forms.Label();
            this.btnSiparisEkle = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbUrunKod = new System.Windows.Forms.ComboBox();
            this.pnlSiparisTeslimBilgileri = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnPnlKapat = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.lblUrunKoduPanel = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblKayitTarihi = new System.Windows.Forms.Label();
            this.lblHatNo = new System.Windows.Forms.Label();
            this.lblSiparisKoduPanel = new System.Windows.Forms.Label();
            this.lblTopMiktar = new System.Windows.Forms.Label();
            this.lblRenkPanel = new System.Windows.Forms.Label();
            this.lblBoyPanel = new System.Windows.Forms.Label();
            this.lblGerekliSure = new System.Windows.Forms.Label();
            this.lblAdetPanel = new System.Windows.Forms.Label();
            this.lblTopSure = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblBitTarihi = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblHammaddePanel = new System.Windows.Forms.Label();
            this.lblBasTarihi = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.evetHayirTableAdapter1 = new uretimPlanlamaProgrami.genelDataSetTableAdapters.evetHayirTableAdapter();
            this.groupBox1.SuspendLayout();
            this.pnlSiparisTeslimBilgileri.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFirmaAdi
            // 
            this.txtFirmaAdi.Location = new System.Drawing.Point(173, 126);
            this.txtFirmaAdi.Name = "txtFirmaAdi";
            this.txtFirmaAdi.Size = new System.Drawing.Size(248, 20);
            this.txtFirmaAdi.TabIndex = 0;
            // 
            // txtSiparisKodu
            // 
            this.txtSiparisKodu.Location = new System.Drawing.Point(173, 90);
            this.txtSiparisKodu.Name = "txtSiparisKodu";
            this.txtSiparisKodu.Size = new System.Drawing.Size(248, 20);
            this.txtSiparisKodu.TabIndex = 0;
            // 
            // cmbHammadde
            // 
            this.cmbHammadde.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbHammadde.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbHammadde.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbHammadde.FormattingEnabled = true;
            this.cmbHammadde.Location = new System.Drawing.Point(173, 164);
            this.cmbHammadde.Name = "cmbHammadde";
            this.cmbHammadde.Size = new System.Drawing.Size(121, 28);
            this.cmbHammadde.TabIndex = 1;
            this.cmbHammadde.Text = "Seçiniz";
            // 
            // cmbOncelikSirasi
            // 
            this.cmbOncelikSirasi.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbOncelikSirasi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbOncelikSirasi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbOncelikSirasi.FormattingEnabled = true;
            this.cmbOncelikSirasi.Items.AddRange(new object[] {
            "Önemsiz",
            "Normal",
            "Acil"});
            this.cmbOncelikSirasi.Location = new System.Drawing.Point(174, 212);
            this.cmbOncelikSirasi.Name = "cmbOncelikSirasi";
            this.cmbOncelikSirasi.Size = new System.Drawing.Size(121, 28);
            this.cmbOncelikSirasi.TabIndex = 1;
            this.cmbOncelikSirasi.Text = "Seçiniz";
            // 
            // txtBoy
            // 
            this.txtBoy.Location = new System.Drawing.Point(173, 256);
            this.txtBoy.MaxLength = 500000;
            this.txtBoy.Name = "txtBoy";
            this.txtBoy.Size = new System.Drawing.Size(248, 20);
            this.txtBoy.TabIndex = 0;
            this.toolTip1.SetToolTip(this.txtBoy, "Boyu milimetre cinsinden giriniz");
            this.txtBoy.TextChanged += new System.EventHandler(this.txtBoy_TextChanged);
            this.txtBoy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoy_KeyPress);
            // 
            // txtAdet
            // 
            this.txtAdet.Location = new System.Drawing.Point(173, 294);
            this.txtAdet.MaxLength = 500000;
            this.txtAdet.Name = "txtAdet";
            this.txtAdet.Size = new System.Drawing.Size(248, 20);
            this.txtAdet.TabIndex = 0;
            this.txtAdet.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAdet_KeyPress);
            // 
            // cmbRenk
            // 
            this.cmbRenk.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbRenk.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbRenk.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbRenk.FormattingEnabled = true;
            this.cmbRenk.Location = new System.Drawing.Point(173, 335);
            this.cmbRenk.Name = "cmbRenk";
            this.cmbRenk.Size = new System.Drawing.Size(121, 28);
            this.cmbRenk.TabIndex = 1;
            this.cmbRenk.Text = "Seçiniz";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Bright", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkGreen;
            this.label1.Location = new System.Drawing.Point(26, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sipariş Kodu :";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Bright", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkGreen;
            this.label2.Location = new System.Drawing.Point(52, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Firma Adı :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Adobe Fan Heiti Std B", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkGreen;
            this.label3.Location = new System.Drawing.Point(6, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 24);
            this.label3.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Bright", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkGreen;
            this.label4.Location = new System.Drawing.Point(36, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 22);
            this.label4.TabIndex = 2;
            this.label4.Text = "Hammadde :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lucida Bright", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkGreen;
            this.label5.Location = new System.Drawing.Point(15, 213);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 22);
            this.label5.TabIndex = 2;
            this.label5.Text = "Öncelik Sırası :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Lucida Bright", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkGreen;
            this.label6.Location = new System.Drawing.Point(111, 252);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 22);
            this.label6.TabIndex = 2;
            this.label6.Text = "Boy :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Lucida Bright", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkGreen;
            this.label7.Location = new System.Drawing.Point(103, 290);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 22);
            this.label7.TabIndex = 2;
            this.label7.Text = "Adet :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Lucida Bright", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkGreen;
            this.label8.Location = new System.Drawing.Point(98, 336);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 22);
            this.label8.TabIndex = 2;
            this.label8.Text = "Renk :";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.lblFirmaAdi);
            this.groupBox1.Controls.Add(this.lblRenk);
            this.groupBox1.Controls.Add(this.lblAdet);
            this.groupBox1.Controls.Add(this.lblKod);
            this.groupBox1.Controls.Add(this.lblBoy);
            this.groupBox1.Controls.Add(this.lblOncelik);
            this.groupBox1.Controls.Add(this.lblHammadde);
            this.groupBox1.Controls.Add(this.btnSiparisEkle);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtFirmaAdi);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtBoy);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtAdet);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtSiparisKodu);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbUrunKod);
            this.groupBox1.Controls.Add(this.cmbHammadde);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbRenk);
            this.groupBox1.Controls.Add(this.cmbOncelikSirasi);
            this.groupBox1.ForeColor = System.Drawing.Color.DarkBlue;
            this.groupBox1.Location = new System.Drawing.Point(38, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(937, 476);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SİPARİŞ BİLGİLERİ";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Image = global::uretimPlanlamaProgrami.Properties.Resources.ekleNew;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(317, 390);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(227, 80);
            this.button1.TabIndex = 7;
            this.button1.Text = "Yeni Sipariş Ekle";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblFirmaAdi
            // 
            this.lblFirmaAdi.AutoSize = true;
            this.lblFirmaAdi.ForeColor = System.Drawing.Color.Red;
            this.lblFirmaAdi.Location = new System.Drawing.Point(428, 129);
            this.lblFirmaAdi.Name = "lblFirmaAdi";
            this.lblFirmaAdi.Size = new System.Drawing.Size(0, 13);
            this.lblFirmaAdi.TabIndex = 5;
            // 
            // lblRenk
            // 
            this.lblRenk.AutoSize = true;
            this.lblRenk.ForeColor = System.Drawing.Color.Red;
            this.lblRenk.Location = new System.Drawing.Point(301, 343);
            this.lblRenk.Name = "lblRenk";
            this.lblRenk.Size = new System.Drawing.Size(0, 13);
            this.lblRenk.TabIndex = 5;
            // 
            // lblAdet
            // 
            this.lblAdet.AutoSize = true;
            this.lblAdet.ForeColor = System.Drawing.Color.Red;
            this.lblAdet.Location = new System.Drawing.Point(427, 297);
            this.lblAdet.Name = "lblAdet";
            this.lblAdet.Size = new System.Drawing.Size(0, 13);
            this.lblAdet.TabIndex = 5;
            // 
            // lblKod
            // 
            this.lblKod.AutoSize = true;
            this.lblKod.ForeColor = System.Drawing.Color.Red;
            this.lblKod.Location = new System.Drawing.Point(427, 93);
            this.lblKod.Name = "lblKod";
            this.lblKod.Size = new System.Drawing.Size(0, 13);
            this.lblKod.TabIndex = 5;
            // 
            // lblBoy
            // 
            this.lblBoy.AutoSize = true;
            this.lblBoy.ForeColor = System.Drawing.Color.Red;
            this.lblBoy.Location = new System.Drawing.Point(427, 259);
            this.lblBoy.Name = "lblBoy";
            this.lblBoy.Size = new System.Drawing.Size(0, 13);
            this.lblBoy.TabIndex = 5;
            // 
            // lblOncelik
            // 
            this.lblOncelik.AutoSize = true;
            this.lblOncelik.ForeColor = System.Drawing.Color.Red;
            this.lblOncelik.Location = new System.Drawing.Point(301, 220);
            this.lblOncelik.Name = "lblOncelik";
            this.lblOncelik.Size = new System.Drawing.Size(0, 13);
            this.lblOncelik.TabIndex = 5;
            // 
            // lblHammadde
            // 
            this.lblHammadde.AutoSize = true;
            this.lblHammadde.ForeColor = System.Drawing.Color.Red;
            this.lblHammadde.Location = new System.Drawing.Point(301, 172);
            this.lblHammadde.Name = "lblHammadde";
            this.lblHammadde.Size = new System.Drawing.Size(0, 13);
            this.lblHammadde.TabIndex = 5;
            // 
            // btnSiparisEkle
            // 
            this.btnSiparisEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSiparisEkle.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnSiparisEkle.Image = global::uretimPlanlamaProgrami.Properties.Resources.save;
            this.btnSiparisEkle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSiparisEkle.Location = new System.Drawing.Point(696, 389);
            this.btnSiparisEkle.Name = "btnSiparisEkle";
            this.btnSiparisEkle.Size = new System.Drawing.Size(235, 80);
            this.btnSiparisEkle.TabIndex = 4;
            this.btnSiparisEkle.Text = "Siparişi Kaydet";
            this.btnSiparisEkle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSiparisEkle.UseVisualStyleBackColor = true;
            this.btnSiparisEkle.Click += new System.EventHandler(this.btnSiparisEkle_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Lucida Bright", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.DarkGreen;
            this.label13.Location = new System.Drawing.Point(25, 47);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(126, 22);
            this.label13.TabIndex = 2;
            this.label13.Text = "Ürün Kodu :";
            this.label13.Click += new System.EventHandler(this.label1_Click);
            // 
            // cmbUrunKod
            // 
            this.cmbUrunKod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbUrunKod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbUrunKod.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbUrunKod.FormattingEnabled = true;
            this.cmbUrunKod.Location = new System.Drawing.Point(173, 46);
            this.cmbUrunKod.Name = "cmbUrunKod";
            this.cmbUrunKod.Size = new System.Drawing.Size(121, 28);
            this.cmbUrunKod.TabIndex = 1;
            this.cmbUrunKod.Text = "Seçiniz";
            // 
            // pnlSiparisTeslimBilgileri
            // 
            this.pnlSiparisTeslimBilgileri.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.pnlSiparisTeslimBilgileri.Controls.Add(this.groupBox2);
            this.pnlSiparisTeslimBilgileri.Location = new System.Drawing.Point(38, 494);
            this.pnlSiparisTeslimBilgileri.Name = "pnlSiparisTeslimBilgileri";
            this.pnlSiparisTeslimBilgileri.Size = new System.Drawing.Size(937, 348);
            this.pnlSiparisTeslimBilgileri.TabIndex = 6;
            this.pnlSiparisTeslimBilgileri.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlSiparisTeslimBilgileri_Paint);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.groupBox2.Controls.Add(this.btnPnlKapat);
            this.groupBox2.Controls.Add(this.label26);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.lblUrunKoduPanel);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.lblKayitTarihi);
            this.groupBox2.Controls.Add(this.lblHatNo);
            this.groupBox2.Controls.Add(this.lblSiparisKoduPanel);
            this.groupBox2.Controls.Add(this.lblTopMiktar);
            this.groupBox2.Controls.Add(this.lblRenkPanel);
            this.groupBox2.Controls.Add(this.lblBoyPanel);
            this.groupBox2.Controls.Add(this.lblGerekliSure);
            this.groupBox2.Controls.Add(this.lblAdetPanel);
            this.groupBox2.Controls.Add(this.lblTopSure);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.lblBitTarihi);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.lblHammaddePanel);
            this.groupBox2.Controls.Add(this.lblBasTarihi);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox2.Location = new System.Drawing.Point(13, 22);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(896, 298);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sipariş  Bilgileri";
            // 
            // btnPnlKapat
            // 
            this.btnPnlKapat.Location = new System.Drawing.Point(764, 247);
            this.btnPnlKapat.Name = "btnPnlKapat";
            this.btnPnlKapat.Size = new System.Drawing.Size(126, 45);
            this.btnPnlKapat.TabIndex = 1;
            this.btnPnlKapat.Text = "KAPAT";
            this.btnPnlKapat.UseVisualStyleBackColor = true;
            this.btnPnlKapat.Click += new System.EventHandler(this.btnPnlKapat_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BackColor = System.Drawing.Color.White;
            this.label26.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label26.Location = new System.Drawing.Point(112, 70);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(105, 22);
            this.label26.TabIndex = 0;
            this.label26.Text = "Ürün Kodu:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.White;
            this.label24.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label24.Location = new System.Drawing.Point(96, 33);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(121, 22);
            this.label24.TabIndex = 0;
            this.label24.Text = "Sipariş Kodu:";
            // 
            // lblUrunKoduPanel
            // 
            this.lblUrunKoduPanel.AutoSize = true;
            this.lblUrunKoduPanel.BackColor = System.Drawing.Color.White;
            this.lblUrunKoduPanel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblUrunKoduPanel.Location = new System.Drawing.Point(223, 70);
            this.lblUrunKoduPanel.Name = "lblUrunKoduPanel";
            this.lblUrunKoduPanel.Size = new System.Drawing.Size(35, 22);
            this.lblUrunKoduPanel.TabIndex = 0;
            this.lblUrunKoduPanel.Text = "laa";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label21.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label21.Location = new System.Drawing.Point(6, 270);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(196, 22);
            this.label21.TabIndex = 0;
            this.label21.Text = "Gerekli Ürün Miktarı :";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label22.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label22.Location = new System.Drawing.Point(63, 206);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(154, 22);
            this.label22.TabIndex = 0;
            this.label22.Text = "Kullanılacak Hat:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label12.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label12.Location = new System.Drawing.Point(21, 174);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(196, 22);
            this.label12.TabIndex = 0;
            this.label12.Text = "Gerekli Ürün Miktarı :";
            // 
            // lblKayitTarihi
            // 
            this.lblKayitTarihi.AutoSize = true;
            this.lblKayitTarihi.BackColor = System.Drawing.Color.White;
            this.lblKayitTarihi.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKayitTarihi.Location = new System.Drawing.Point(208, 270);
            this.lblKayitTarihi.Name = "lblKayitTarihi";
            this.lblKayitTarihi.Size = new System.Drawing.Size(35, 22);
            this.lblKayitTarihi.TabIndex = 0;
            this.lblKayitTarihi.Text = "laa";
            // 
            // lblHatNo
            // 
            this.lblHatNo.AutoSize = true;
            this.lblHatNo.BackColor = System.Drawing.Color.White;
            this.lblHatNo.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblHatNo.Location = new System.Drawing.Point(226, 206);
            this.lblHatNo.Name = "lblHatNo";
            this.lblHatNo.Size = new System.Drawing.Size(35, 22);
            this.lblHatNo.TabIndex = 0;
            this.lblHatNo.Text = "laa";
            // 
            // lblSiparisKoduPanel
            // 
            this.lblSiparisKoduPanel.AutoSize = true;
            this.lblSiparisKoduPanel.BackColor = System.Drawing.Color.White;
            this.lblSiparisKoduPanel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSiparisKoduPanel.Location = new System.Drawing.Point(223, 33);
            this.lblSiparisKoduPanel.Name = "lblSiparisKoduPanel";
            this.lblSiparisKoduPanel.Size = new System.Drawing.Size(35, 22);
            this.lblSiparisKoduPanel.TabIndex = 0;
            this.lblSiparisKoduPanel.Text = "laa";
            // 
            // lblTopMiktar
            // 
            this.lblTopMiktar.AutoSize = true;
            this.lblTopMiktar.BackColor = System.Drawing.Color.White;
            this.lblTopMiktar.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTopMiktar.Location = new System.Drawing.Point(226, 174);
            this.lblTopMiktar.Name = "lblTopMiktar";
            this.lblTopMiktar.Size = new System.Drawing.Size(35, 22);
            this.lblTopMiktar.TabIndex = 0;
            this.lblTopMiktar.Text = "laa";
            // 
            // lblRenkPanel
            // 
            this.lblRenkPanel.AutoSize = true;
            this.lblRenkPanel.BackColor = System.Drawing.Color.White;
            this.lblRenkPanel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblRenkPanel.Location = new System.Drawing.Point(694, 70);
            this.lblRenkPanel.Name = "lblRenkPanel";
            this.lblRenkPanel.Size = new System.Drawing.Size(25, 22);
            this.lblRenkPanel.TabIndex = 0;
            this.lblRenkPanel.Text = "la";
            // 
            // lblBoyPanel
            // 
            this.lblBoyPanel.AutoSize = true;
            this.lblBoyPanel.BackColor = System.Drawing.Color.White;
            this.lblBoyPanel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBoyPanel.Location = new System.Drawing.Point(694, 108);
            this.lblBoyPanel.Name = "lblBoyPanel";
            this.lblBoyPanel.Size = new System.Drawing.Size(25, 22);
            this.lblBoyPanel.TabIndex = 0;
            this.lblBoyPanel.Text = "la";
            // 
            // lblGerekliSure
            // 
            this.lblGerekliSure.AutoSize = true;
            this.lblGerekliSure.BackColor = System.Drawing.Color.White;
            this.lblGerekliSure.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblGerekliSure.Location = new System.Drawing.Point(694, 174);
            this.lblGerekliSure.Name = "lblGerekliSure";
            this.lblGerekliSure.Size = new System.Drawing.Size(25, 22);
            this.lblGerekliSure.TabIndex = 0;
            this.lblGerekliSure.Text = "la";
            // 
            // lblAdetPanel
            // 
            this.lblAdetPanel.AutoSize = true;
            this.lblAdetPanel.BackColor = System.Drawing.Color.White;
            this.lblAdetPanel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAdetPanel.Location = new System.Drawing.Point(694, 140);
            this.lblAdetPanel.Name = "lblAdetPanel";
            this.lblAdetPanel.Size = new System.Drawing.Size(25, 22);
            this.lblAdetPanel.TabIndex = 0;
            this.lblAdetPanel.Text = "la";
            // 
            // lblTopSure
            // 
            this.lblTopSure.AutoSize = true;
            this.lblTopSure.BackColor = System.Drawing.Color.White;
            this.lblTopSure.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTopSure.Location = new System.Drawing.Point(694, 206);
            this.lblTopSure.Name = "lblTopSure";
            this.lblTopSure.Size = new System.Drawing.Size(25, 22);
            this.lblTopSure.TabIndex = 0;
            this.lblTopSure.Text = "la";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.White;
            this.label20.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label20.Location = new System.Drawing.Point(641, 108);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(47, 22);
            this.label20.TabIndex = 0;
            this.label20.Text = "Boy:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label14.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label14.Location = new System.Drawing.Point(568, 174);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(120, 22);
            this.label14.TabIndex = 0;
            this.label14.Text = "Gerekli Süre:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.White;
            this.label19.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label19.Location = new System.Drawing.Point(635, 140);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(53, 22);
            this.label19.TabIndex = 0;
            this.label19.Text = "Adet:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label11.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label11.Location = new System.Drawing.Point(569, 206);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(119, 22);
            this.label11.TabIndex = 0;
            this.label11.Text = "Toplam Süre:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.White;
            this.label18.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label18.Location = new System.Drawing.Point(694, 70);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(0, 22);
            this.label18.TabIndex = 0;
            this.label18.Click += new System.EventHandler(this.label10_Click);
            // 
            // lblBitTarihi
            // 
            this.lblBitTarihi.AutoSize = true;
            this.lblBitTarihi.BackColor = System.Drawing.Color.White;
            this.lblBitTarihi.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBitTarihi.Location = new System.Drawing.Point(223, 140);
            this.lblBitTarihi.Name = "lblBitTarihi";
            this.lblBitTarihi.Size = new System.Drawing.Size(0, 22);
            this.lblBitTarihi.TabIndex = 0;
            this.lblBitTarihi.Click += new System.EventHandler(this.label10_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.White;
            this.label17.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label17.Location = new System.Drawing.Point(629, 70);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(59, 22);
            this.label17.TabIndex = 0;
            this.label17.Text = "Renk:";
            this.label17.Click += new System.EventHandler(this.label10_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Red;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label10.Location = new System.Drawing.Point(24, 140);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(193, 22);
            this.label10.TabIndex = 0;
            this.label10.Text = "Planlanan Bitiş Tarihi:";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // lblHammaddePanel
            // 
            this.lblHammaddePanel.AutoSize = true;
            this.lblHammaddePanel.BackColor = System.Drawing.Color.White;
            this.lblHammaddePanel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblHammaddePanel.Location = new System.Drawing.Point(694, 33);
            this.lblHammaddePanel.Name = "lblHammaddePanel";
            this.lblHammaddePanel.Size = new System.Drawing.Size(25, 22);
            this.lblHammaddePanel.TabIndex = 0;
            this.lblHammaddePanel.Text = "la";
            // 
            // lblBasTarihi
            // 
            this.lblBasTarihi.AutoSize = true;
            this.lblBasTarihi.BackColor = System.Drawing.Color.White;
            this.lblBasTarihi.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBasTarihi.Location = new System.Drawing.Point(223, 108);
            this.lblBasTarihi.Name = "lblBasTarihi";
            this.lblBasTarihi.Size = new System.Drawing.Size(25, 22);
            this.lblBasTarihi.TabIndex = 0;
            this.lblBasTarihi.Text = "la";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.White;
            this.label15.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label15.Location = new System.Drawing.Point(580, 33);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(108, 22);
            this.label15.TabIndex = 0;
            this.label15.Text = "Hammadde:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Lime;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(6, 108);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(211, 22);
            this.label9.TabIndex = 0;
            this.label9.Text = "Sipariş Başlangıç Tarihi:";
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // evetHayirTableAdapter1
            // 
            this.evetHayirTableAdapter1.ClearBeforeFill = true;
            // 
            // frmSiparisEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Brown;
            this.ClientSize = new System.Drawing.Size(1012, 853);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pnlSiparisTeslimBilgileri);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1300, 1200);
            this.Name = "frmSiparisEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSiparisEkle";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSiparisEkle_FormClosed);
            this.Load += new System.EventHandler(this.frmSiparisEkle_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlSiparisTeslimBilgileri.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtFirmaAdi;
        private System.Windows.Forms.TextBox txtSiparisKodu;
        private System.Windows.Forms.ComboBox cmbHammadde;
        private System.Windows.Forms.ComboBox cmbOncelikSirasi;
        private System.Windows.Forms.TextBox txtBoy;
        private System.Windows.Forms.TextBox txtAdet;
        private System.Windows.Forms.ComboBox cmbRenk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSiparisEkle;
        private System.Windows.Forms.Label lblFirmaAdi;
        private System.Windows.Forms.Label lblRenk;
        private System.Windows.Forms.Label lblAdet;
        private System.Windows.Forms.Label lblKod;
        private System.Windows.Forms.Label lblBoy;
        private System.Windows.Forms.Label lblOncelik;
        private System.Windows.Forms.Label lblHammadde;
        private System.Windows.Forms.Panel pnlSiparisTeslimBilgileri;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblTopMiktar;
        private System.Windows.Forms.Label lblTopSure;
        private System.Windows.Forms.Label lblBitTarihi;
        private System.Windows.Forms.Label lblBasTarihi;
        private System.Windows.Forms.Button btnPnlKapat;
        private System.Windows.Forms.ComboBox cmbUrunKod;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label lblSiparisKoduPanel;
        private System.Windows.Forms.Label lblBoyPanel;
        private System.Windows.Forms.Label lblGerekliSure;
        private System.Windows.Forms.Label lblAdetPanel;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblHammaddePanel;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label lblUrunKoduPanel;
        private System.Windows.Forms.Label lblRenkPanel;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lblKayitTarihi;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblHatNo;
        private genelDataSetTableAdapters.evetHayirTableAdapter evetHayirTableAdapter1;
    }
}