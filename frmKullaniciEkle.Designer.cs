namespace uretimPlanlamaProgrami
{
    partial class frmKullaniciEkle
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
            this.txtAd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnYeniKayit = new System.Windows.Forms.Button();
            this.txtParola = new System.Windows.Forms.MaskedTextBox();
            this.txtParolaTekrar = new System.Windows.Forms.MaskedTextBox();
            this.lblParola = new System.Windows.Forms.Label();
            this.lblTur = new System.Windows.Forms.Label();
            this.lblAd = new System.Windows.Forms.Label();
            this.btnKulEkle = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtAd
            // 
            this.txtAd.Location = new System.Drawing.Point(162, 42);
            this.txtAd.Name = "txtAd";
            this.txtAd.Size = new System.Drawing.Size(136, 26);
            this.txtAd.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(64, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kullanıcı Adı :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(95, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Parola  :";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Admin",
            "Normal Kullanıcı"});
            this.comboBox1.Location = new System.Drawing.Point(162, 134);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 28);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.Text = "Seçiniz";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(118, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tür :";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.AntiqueWhite;
            this.groupBox1.Controls.Add(this.btnYeniKayit);
            this.groupBox1.Controls.Add(this.txtParola);
            this.groupBox1.Controls.Add(this.txtParolaTekrar);
            this.groupBox1.Controls.Add(this.lblParola);
            this.groupBox1.Controls.Add(this.lblTur);
            this.groupBox1.Controls.Add(this.lblAd);
            this.groupBox1.Controls.Add(this.btnKulEkle);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.txtAd);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.groupBox1.Location = new System.Drawing.Point(12, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 297);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kullanıcı bilgileri";
            // 
            // btnYeniKayit
            // 
            this.btnYeniKayit.BackColor = System.Drawing.Color.White;
            this.btnYeniKayit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnYeniKayit.Image = global::uretimPlanlamaProgrami.Properties.Resources.kullaniciEkle;
            this.btnYeniKayit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnYeniKayit.Location = new System.Drawing.Point(162, 186);
            this.btnYeniKayit.Name = "btnYeniKayit";
            this.btnYeniKayit.Size = new System.Drawing.Size(181, 86);
            this.btnYeniKayit.TabIndex = 6;
            this.btnYeniKayit.Text = "Yeni Kayıt";
            this.btnYeniKayit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnYeniKayit.UseVisualStyleBackColor = false;
            this.btnYeniKayit.Click += new System.EventHandler(this.btnYeniKayit_Click);
            // 
            // txtParola
            // 
            this.txtParola.Location = new System.Drawing.Point(162, 71);
            this.txtParola.Name = "txtParola";
            this.txtParola.Size = new System.Drawing.Size(136, 26);
            this.txtParola.TabIndex = 5;
            this.txtParola.UseSystemPasswordChar = true;
            // 
            // txtParolaTekrar
            // 
            this.txtParolaTekrar.Location = new System.Drawing.Point(162, 98);
            this.txtParolaTekrar.Name = "txtParolaTekrar";
            this.txtParolaTekrar.Size = new System.Drawing.Size(136, 26);
            this.txtParolaTekrar.TabIndex = 5;
            this.txtParolaTekrar.UseSystemPasswordChar = true;
            // 
            // lblParola
            // 
            this.lblParola.AutoSize = true;
            this.lblParola.ForeColor = System.Drawing.Color.Red;
            this.lblParola.Location = new System.Drawing.Point(304, 71);
            this.lblParola.Name = "lblParola";
            this.lblParola.Size = new System.Drawing.Size(0, 20);
            this.lblParola.TabIndex = 4;
            // 
            // lblTur
            // 
            this.lblTur.AutoSize = true;
            this.lblTur.ForeColor = System.Drawing.Color.Red;
            this.lblTur.Location = new System.Drawing.Point(298, 141);
            this.lblTur.Name = "lblTur";
            this.lblTur.Size = new System.Drawing.Size(0, 20);
            this.lblTur.TabIndex = 4;
            // 
            // lblAd
            // 
            this.lblAd.AutoSize = true;
            this.lblAd.ForeColor = System.Drawing.Color.Red;
            this.lblAd.Location = new System.Drawing.Point(304, 45);
            this.lblAd.Name = "lblAd";
            this.lblAd.Size = new System.Drawing.Size(0, 20);
            this.lblAd.TabIndex = 4;
            // 
            // btnKulEkle
            // 
            this.btnKulEkle.BackColor = System.Drawing.Color.White;
            this.btnKulEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKulEkle.Image = global::uretimPlanlamaProgrami.Properties.Resources.save;
            this.btnKulEkle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKulEkle.Location = new System.Drawing.Point(360, 184);
            this.btnKulEkle.Name = "btnKulEkle";
            this.btnKulEkle.Size = new System.Drawing.Size(179, 88);
            this.btnKulEkle.TabIndex = 3;
            this.btnKulEkle.Text = "      KAYDET";
            this.btnKulEkle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnKulEkle.UseVisualStyleBackColor = false;
            this.btnKulEkle.Click += new System.EventHandler(this.btnKulEkle_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(20, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Parolayı Tekrar Gir :";
            // 
            // frmKullaniciEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkBlue;
            this.ClientSize = new System.Drawing.Size(584, 331);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 370);
            this.Name = "frmKullaniciEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yeni Kullanıcı Ekle";
            this.Load += new System.EventHandler(this.frmKullaniciEkle_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtAd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnKulEkle;
        private System.Windows.Forms.Label lblParola;
        private System.Windows.Forms.Label lblAd;
        private System.Windows.Forms.Label lblTur;
        private System.Windows.Forms.MaskedTextBox txtParolaTekrar;
        private System.Windows.Forms.MaskedTextBox txtParola;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnYeniKayit;
    }
}