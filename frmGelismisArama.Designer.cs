namespace uretimPlanlamaProgrami
{
    partial class frmGelismisArama
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
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.rdTumSiparis = new System.Windows.Forms.RadioButton();
            this.rdBitensiparis = new System.Windows.Forms.RadioButton();
            this.rdDevamEdenSipariseler = new System.Windows.Forms.RadioButton();
            this.tdBeklemedeOlan = new System.Windows.Forms.RadioButton();
            this.txtSiparisKodd = new System.Windows.Forms.TextBox();
            this.txtUrunKodd = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.grpTarihAraligi = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dtIlkTarih = new System.Windows.Forms.DateTimePicker();
            this.dtSonTarih = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.btnGelismisArama = new System.Windows.Forms.Button();
            this.chcUrunKod = new System.Windows.Forms.CheckBox();
            this.chcSiparisKodu = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFirmaAdi = new System.Windows.Forms.TextBox();
            this.chcFirmaAdi = new System.Windows.Forms.CheckBox();
            this.cmbHammdde = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chcHammadde = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chcHatNo = new System.Windows.Forms.CheckBox();
            this.cmbHatNo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chcAdet = new System.Windows.Forms.CheckBox();
            this.txtAdet = new System.Windows.Forms.TextBox();
            this.txtBoy = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chcBoy = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chcRenk = new System.Windows.Forms.CheckBox();
            this.cmbRebk = new System.Windows.Forms.ComboBox();
            this.chcTarihAraligi = new System.Windows.Forms.CheckBox();
            this.groupBox6.SuspendLayout();
            this.grpTarihAraligi.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.Color.LightYellow;
            this.groupBox6.Controls.Add(this.rdTumSiparis);
            this.groupBox6.Controls.Add(this.rdBitensiparis);
            this.groupBox6.Controls.Add(this.rdDevamEdenSipariseler);
            this.groupBox6.Controls.Add(this.tdBeklemedeOlan);
            this.groupBox6.Location = new System.Drawing.Point(50, 28);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(593, 131);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Sipariş Liste Kriteri";
            // 
            // rdTumSiparis
            // 
            this.rdTumSiparis.AutoSize = true;
            this.rdTumSiparis.Location = new System.Drawing.Point(18, 22);
            this.rdTumSiparis.Name = "rdTumSiparis";
            this.rdTumSiparis.Size = new System.Drawing.Size(91, 17);
            this.rdTumSiparis.TabIndex = 0;
            this.rdTumSiparis.TabStop = true;
            this.rdTumSiparis.Text = "Tüm Siparişler";
            this.rdTumSiparis.UseVisualStyleBackColor = true;
            // 
            // rdBitensiparis
            // 
            this.rdBitensiparis.AutoSize = true;
            this.rdBitensiparis.Location = new System.Drawing.Point(18, 103);
            this.rdBitensiparis.Name = "rdBitensiparis";
            this.rdBitensiparis.Size = new System.Drawing.Size(94, 17);
            this.rdBitensiparis.TabIndex = 0;
            this.rdBitensiparis.TabStop = true;
            this.rdBitensiparis.Text = "Biten Siparişler";
            this.rdBitensiparis.UseVisualStyleBackColor = true;
            // 
            // rdDevamEdenSipariseler
            // 
            this.rdDevamEdenSipariseler.AutoSize = true;
            this.rdDevamEdenSipariseler.Location = new System.Drawing.Point(18, 49);
            this.rdDevamEdenSipariseler.Name = "rdDevamEdenSipariseler";
            this.rdDevamEdenSipariseler.Size = new System.Drawing.Size(132, 17);
            this.rdDevamEdenSipariseler.TabIndex = 0;
            this.rdDevamEdenSipariseler.TabStop = true;
            this.rdDevamEdenSipariseler.Text = "Devam Eden Siparişler";
            this.rdDevamEdenSipariseler.UseVisualStyleBackColor = true;
            // 
            // tdBeklemedeOlan
            // 
            this.tdBeklemedeOlan.AutoSize = true;
            this.tdBeklemedeOlan.Location = new System.Drawing.Point(18, 76);
            this.tdBeklemedeOlan.Name = "tdBeklemedeOlan";
            this.tdBeklemedeOlan.Size = new System.Drawing.Size(148, 17);
            this.tdBeklemedeOlan.TabIndex = 0;
            this.tdBeklemedeOlan.TabStop = true;
            this.tdBeklemedeOlan.Text = "Beklemede Olan Siparişler";
            this.tdBeklemedeOlan.UseVisualStyleBackColor = true;
            // 
            // txtSiparisKodd
            // 
            this.txtSiparisKodd.Location = new System.Drawing.Point(50, 284);
            this.txtSiparisKodd.Name = "txtSiparisKodd";
            this.txtSiparisKodd.Size = new System.Drawing.Size(206, 20);
            this.txtSiparisKodd.TabIndex = 4;
            // 
            // txtUrunKodd
            // 
            this.txtUrunKodd.Location = new System.Drawing.Point(50, 212);
            this.txtUrunKodd.Name = "txtUrunKodd";
            this.txtUrunKodd.Size = new System.Drawing.Size(206, 20);
            this.txtUrunKodd.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(50, 196);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Ürün Kodu :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(50, 268);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Sipariş Kodu :";
            // 
            // grpTarihAraligi
            // 
            this.grpTarihAraligi.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.grpTarihAraligi.Controls.Add(this.label12);
            this.grpTarihAraligi.Controls.Add(this.label11);
            this.grpTarihAraligi.Controls.Add(this.label9);
            this.grpTarihAraligi.Controls.Add(this.dtIlkTarih);
            this.grpTarihAraligi.Controls.Add(this.dtSonTarih);
            this.grpTarihAraligi.Controls.Add(this.label10);
            this.grpTarihAraligi.Location = new System.Drawing.Point(50, 479);
            this.grpTarihAraligi.Name = "grpTarihAraligi";
            this.grpTarihAraligi.Size = new System.Drawing.Size(593, 97);
            this.grpTarihAraligi.TabIndex = 6;
            this.grpTarihAraligi.TabStop = false;
            this.grpTarihAraligi.Text = "Tarih Aralığı";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(239, 48);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(23, 13);
            this.label12.TabIndex = 4;
            this.label12.Text = "İLE";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(496, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "ARASI";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(6, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "İlk Tarih";
            // 
            // dtIlkTarih
            // 
            this.dtIlkTarih.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtIlkTarih.Location = new System.Drawing.Point(9, 43);
            this.dtIlkTarih.Name = "dtIlkTarih";
            this.dtIlkTarih.Size = new System.Drawing.Size(206, 20);
            this.dtIlkTarih.TabIndex = 3;
            // 
            // dtSonTarih
            // 
            this.dtSonTarih.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtSonTarih.Location = new System.Drawing.Point(284, 43);
            this.dtSonTarih.Name = "dtSonTarih";
            this.dtSonTarih.Size = new System.Drawing.Size(206, 20);
            this.dtSonTarih.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(281, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Son Tarih";
            // 
            // btnGelismisArama
            // 
            this.btnGelismisArama.Location = new System.Drawing.Point(521, 582);
            this.btnGelismisArama.Name = "btnGelismisArama";
            this.btnGelismisArama.Size = new System.Drawing.Size(122, 44);
            this.btnGelismisArama.TabIndex = 8;
            this.btnGelismisArama.Text = "Filtrele";
            this.btnGelismisArama.UseVisualStyleBackColor = true;
            this.btnGelismisArama.Click += new System.EventHandler(this.btnGelismisArama_Click);
            // 
            // chcUrunKod
            // 
            this.chcUrunKod.AutoSize = true;
            this.chcUrunKod.Location = new System.Drawing.Point(50, 176);
            this.chcUrunKod.Name = "chcUrunKod";
            this.chcUrunKod.Size = new System.Drawing.Size(77, 17);
            this.chcUrunKod.TabIndex = 9;
            this.chcUrunKod.Text = "Ürün Kodu";
            this.chcUrunKod.UseVisualStyleBackColor = true;
            this.chcUrunKod.CheckedChanged += new System.EventHandler(this.chcUrunKod_CheckedChanged);
            // 
            // chcSiparisKodu
            // 
            this.chcSiparisKodu.AutoSize = true;
            this.chcSiparisKodu.Location = new System.Drawing.Point(50, 245);
            this.chcSiparisKodu.Name = "chcSiparisKodu";
            this.chcSiparisKodu.Size = new System.Drawing.Size(85, 17);
            this.chcSiparisKodu.TabIndex = 9;
            this.chcSiparisKodu.Text = "Sipariş Kodu";
            this.chcSiparisKodu.UseVisualStyleBackColor = true;
            this.chcSiparisKodu.CheckedChanged += new System.EventHandler(this.chcSiparisKodu_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(50, 331);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Firma Adı :";
            // 
            // txtFirmaAdi
            // 
            this.txtFirmaAdi.Location = new System.Drawing.Point(50, 347);
            this.txtFirmaAdi.Name = "txtFirmaAdi";
            this.txtFirmaAdi.Size = new System.Drawing.Size(206, 20);
            this.txtFirmaAdi.TabIndex = 4;
            // 
            // chcFirmaAdi
            // 
            this.chcFirmaAdi.AutoSize = true;
            this.chcFirmaAdi.Location = new System.Drawing.Point(50, 310);
            this.chcFirmaAdi.Name = "chcFirmaAdi";
            this.chcFirmaAdi.Size = new System.Drawing.Size(69, 17);
            this.chcFirmaAdi.TabIndex = 9;
            this.chcFirmaAdi.Text = "Firma Adı";
            this.chcFirmaAdi.UseVisualStyleBackColor = true;
            this.chcFirmaAdi.CheckedChanged += new System.EventHandler(this.chcFirmaAdi_CheckedChanged);
            // 
            // cmbHammdde
            // 
            this.cmbHammdde.FormattingEnabled = true;
            this.cmbHammdde.Location = new System.Drawing.Point(50, 411);
            this.cmbHammdde.Name = "cmbHammdde";
            this.cmbHammdde.Size = new System.Drawing.Size(166, 21);
            this.cmbHammdde.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(50, 395);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hammadde :";
            // 
            // chcHammadde
            // 
            this.chcHammadde.AutoSize = true;
            this.chcHammadde.Location = new System.Drawing.Point(50, 375);
            this.chcHammadde.Name = "chcHammadde";
            this.chcHammadde.Size = new System.Drawing.Size(80, 17);
            this.chcHammadde.TabIndex = 9;
            this.chcHammadde.Text = "Hammadde";
            this.chcHammadde.UseVisualStyleBackColor = true;
            this.chcHammadde.CheckedChanged += new System.EventHandler(this.chcHammadde_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(310, 399);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Hat No:";
            // 
            // chcHatNo
            // 
            this.chcHatNo.AutoSize = true;
            this.chcHatNo.Location = new System.Drawing.Point(310, 379);
            this.chcHatNo.Name = "chcHatNo";
            this.chcHatNo.Size = new System.Drawing.Size(60, 17);
            this.chcHatNo.TabIndex = 9;
            this.chcHatNo.Text = "Hat No";
            this.chcHatNo.UseVisualStyleBackColor = true;
            this.chcHatNo.CheckedChanged += new System.EventHandler(this.chcHatNo_CheckedChanged);
            // 
            // cmbHatNo
            // 
            this.cmbHatNo.FormattingEnabled = true;
            this.cmbHatNo.Location = new System.Drawing.Point(310, 415);
            this.cmbHatNo.Name = "cmbHatNo";
            this.cmbHatNo.Size = new System.Drawing.Size(169, 21);
            this.cmbHatNo.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(310, 265);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Adet :";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // chcAdet
            // 
            this.chcAdet.AutoSize = true;
            this.chcAdet.Location = new System.Drawing.Point(310, 245);
            this.chcAdet.Name = "chcAdet";
            this.chcAdet.Size = new System.Drawing.Size(48, 17);
            this.chcAdet.TabIndex = 9;
            this.chcAdet.Text = "Adet";
            this.chcAdet.UseVisualStyleBackColor = true;
            this.chcAdet.CheckedChanged += new System.EventHandler(this.chcAdet_CheckedChanged);
            // 
            // txtAdet
            // 
            this.txtAdet.Location = new System.Drawing.Point(310, 281);
            this.txtAdet.Name = "txtAdet";
            this.txtAdet.Size = new System.Drawing.Size(206, 20);
            this.txtAdet.TabIndex = 3;
            // 
            // txtBoy
            // 
            this.txtBoy.Location = new System.Drawing.Point(310, 353);
            this.txtBoy.Name = "txtBoy";
            this.txtBoy.Size = new System.Drawing.Size(206, 20);
            this.txtBoy.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(310, 337);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Boy :";
            // 
            // chcBoy
            // 
            this.chcBoy.AutoSize = true;
            this.chcBoy.Location = new System.Drawing.Point(310, 317);
            this.chcBoy.Name = "chcBoy";
            this.chcBoy.Size = new System.Drawing.Size(44, 17);
            this.chcBoy.TabIndex = 9;
            this.chcBoy.Text = "Boy";
            this.chcBoy.UseVisualStyleBackColor = true;
            this.chcBoy.CheckedChanged += new System.EventHandler(this.chcBoy_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(310, 196);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Renk :";
            // 
            // chcRenk
            // 
            this.chcRenk.AutoSize = true;
            this.chcRenk.Location = new System.Drawing.Point(310, 176);
            this.chcRenk.Name = "chcRenk";
            this.chcRenk.Size = new System.Drawing.Size(52, 17);
            this.chcRenk.TabIndex = 9;
            this.chcRenk.Text = "Renk";
            this.chcRenk.UseVisualStyleBackColor = true;
            this.chcRenk.CheckedChanged += new System.EventHandler(this.chcRenk_CheckedChanged);
            // 
            // cmbRebk
            // 
            this.cmbRebk.FormattingEnabled = true;
            this.cmbRebk.Location = new System.Drawing.Point(310, 212);
            this.cmbRebk.Name = "cmbRebk";
            this.cmbRebk.Size = new System.Drawing.Size(169, 21);
            this.cmbRebk.TabIndex = 10;
            // 
            // chcTarihAraligi
            // 
            this.chcTarihAraligi.AutoSize = true;
            this.chcTarihAraligi.Location = new System.Drawing.Point(50, 456);
            this.chcTarihAraligi.Name = "chcTarihAraligi";
            this.chcTarihAraligi.Size = new System.Drawing.Size(81, 17);
            this.chcTarihAraligi.TabIndex = 9;
            this.chcTarihAraligi.Text = "Tarih Aralığı";
            this.chcTarihAraligi.UseVisualStyleBackColor = true;
            this.chcTarihAraligi.CheckedChanged += new System.EventHandler(this.chcTarihAraligi_CheckedChanged);
            // 
            // frmGelismisArama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 628);
            this.Controls.Add(this.cmbRebk);
            this.Controls.Add(this.cmbHatNo);
            this.Controls.Add(this.cmbHammdde);
            this.Controls.Add(this.chcUrunKod);
            this.Controls.Add(this.chcSiparisKodu);
            this.Controls.Add(this.chcFirmaAdi);
            this.Controls.Add(this.chcBoy);
            this.Controls.Add(this.chcRenk);
            this.Controls.Add(this.chcAdet);
            this.Controls.Add(this.chcHatNo);
            this.Controls.Add(this.chcTarihAraligi);
            this.Controls.Add(this.chcHammadde);
            this.Controls.Add(this.txtFirmaAdi);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSiparisKodd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGelismisArama);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtBoy);
            this.Controls.Add(this.txtAdet);
            this.Controls.Add(this.txtUrunKodd);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.grpTarihAraligi);
            this.Name = "frmGelismisArama";
            this.Text = "frmGelismisArama";
            this.Load += new System.EventHandler(this.frmGelismisArama_Load);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.grpTarihAraligi.ResumeLayout(false);
            this.grpTarihAraligi.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton rdTumSiparis;
        private System.Windows.Forms.RadioButton rdBitensiparis;
        private System.Windows.Forms.RadioButton rdDevamEdenSipariseler;
        private System.Windows.Forms.RadioButton tdBeklemedeOlan;
        private System.Windows.Forms.TextBox txtSiparisKodd;
        private System.Windows.Forms.TextBox txtUrunKodd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox grpTarihAraligi;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtIlkTarih;
        private System.Windows.Forms.DateTimePicker dtSonTarih;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnGelismisArama;
        private System.Windows.Forms.CheckBox chcUrunKod;
        private System.Windows.Forms.CheckBox chcSiparisKodu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFirmaAdi;
        private System.Windows.Forms.CheckBox chcFirmaAdi;
        private System.Windows.Forms.ComboBox cmbHammdde;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chcHammadde;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chcHatNo;
        private System.Windows.Forms.ComboBox cmbHatNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chcAdet;
        private System.Windows.Forms.TextBox txtAdet;
        private System.Windows.Forms.TextBox txtBoy;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chcBoy;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chcRenk;
        private System.Windows.Forms.ComboBox cmbRebk;
        private System.Windows.Forms.CheckBox chcTarihAraligi;
    }
}