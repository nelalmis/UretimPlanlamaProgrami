namespace uretimPlanlamaProgrami.RadFormlari
{
    partial class radUrunEkle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(radUrunEkle));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radCheckedListBox1 = new Telerik.WinControls.UI.RadCheckedListBox();
            this.txtFireMiktari = new Telerik.WinControls.UI.RadTextBoxControl();
            this.txtGramaj = new Telerik.WinControls.UI.RadTextBoxControl();
            this.txtHiz = new Telerik.WinControls.UI.RadTextBoxControl();
            this.txtKod = new Telerik.WinControls.UI.RadTextBoxControl();
            this.btnUrunEkle = new Telerik.WinControls.UI.RadButton();
            this.btnResimSec = new Telerik.WinControls.UI.RadButton();
            this.pr = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblHiz = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFile = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblGramaj = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblKod = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.aquaTheme1 = new Telerik.WinControls.Themes.AquaTheme();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.breezeTheme1 = new Telerik.WinControls.Themes.BreezeTheme();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckedListBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFireMiktari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGramaj)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHiz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUrunEkle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnResimSec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightSlateGray;
            this.groupBox1.Controls.Add(this.radCheckedListBox1);
            this.groupBox1.Controls.Add(this.txtFireMiktari);
            this.groupBox1.Controls.Add(this.txtGramaj);
            this.groupBox1.Controls.Add(this.txtHiz);
            this.groupBox1.Controls.Add(this.txtKod);
            this.groupBox1.Controls.Add(this.btnUrunEkle);
            this.groupBox1.Controls.Add(this.btnResimSec);
            this.groupBox1.Controls.Add(this.pr);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.lblHiz);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblFile);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblGramaj);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblKod);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Adobe Fangsong Std R", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(24, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(785, 685);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ürün Bilgileri";
            // 
            // radCheckedListBox1
            // 
            this.radCheckedListBox1.EnableFiltering = true;
            this.radCheckedListBox1.EnableSorting = true;
            this.radCheckedListBox1.Location = new System.Drawing.Point(122, 266);
            this.radCheckedListBox1.Name = "radCheckedListBox1";
            this.radCheckedListBox1.Size = new System.Drawing.Size(213, 345);
            this.radCheckedListBox1.TabIndex = 9;
            this.radCheckedListBox1.Text = "radCheckedListBox1";
            this.radCheckedListBox1.ThemeName = "Aqua";
            // 
            // txtFireMiktari
            // 
            this.txtFireMiktari.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.txtFireMiktari.Location = new System.Drawing.Point(136, 187);
            this.txtFireMiktari.Name = "txtFireMiktari";
            this.txtFireMiktari.NullText = "Fire miktarı";
            this.txtFireMiktari.Size = new System.Drawing.Size(311, 38);
            this.txtFireMiktari.TabIndex = 8;
            this.txtFireMiktari.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHiz_KeyPress);
            // 
            // txtGramaj
            // 
            this.txtGramaj.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.txtGramaj.Location = new System.Drawing.Point(136, 138);
            this.txtGramaj.Name = "txtGramaj";
            this.txtGramaj.NullText = "Ürün gramajı";
            this.txtGramaj.Size = new System.Drawing.Size(311, 38);
            this.txtGramaj.TabIndex = 8;
            this.txtGramaj.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHiz_KeyPress);
            // 
            // txtHiz
            // 
            this.txtHiz.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.txtHiz.Location = new System.Drawing.Point(136, 88);
            this.txtHiz.Name = "txtHiz";
            this.txtHiz.NullText = "Ürün hızı";
            this.txtHiz.Size = new System.Drawing.Size(311, 38);
            this.txtHiz.TabIndex = 8;
            this.txtHiz.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHiz_KeyPress);
            // 
            // txtKod
            // 
            this.txtKod.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.txtKod.Location = new System.Drawing.Point(136, 36);
            this.txtKod.Name = "txtKod";
            this.txtKod.NullText = "Ürün kodu";
            this.txtKod.Size = new System.Drawing.Size(311, 38);
            this.txtKod.TabIndex = 8;
            // 
            // btnUrunEkle
            // 
            this.btnUrunEkle.Font = new System.Drawing.Font("Verdana", 13F);
            this.btnUrunEkle.Location = new System.Drawing.Point(527, 617);
            this.btnUrunEkle.Name = "btnUrunEkle";
            this.btnUrunEkle.Size = new System.Drawing.Size(252, 62);
            this.btnUrunEkle.TabIndex = 7;
            this.btnUrunEkle.Text = "Ürün Ekle";
            this.btnUrunEkle.ThemeName = "Aqua";
            this.btnUrunEkle.Click += new System.EventHandler(this.btnUrunEkle_Click_1);
            // 
            // btnResimSec
            // 
            this.btnResimSec.Font = new System.Drawing.Font("Adobe Fangsong Std R", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnResimSec.Location = new System.Drawing.Point(398, 262);
            this.btnResimSec.Name = "btnResimSec";
            this.btnResimSec.Size = new System.Drawing.Size(252, 40);
            this.btnResimSec.TabIndex = 7;
            this.btnResimSec.Text = "Resim Seç";
            this.btnResimSec.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.btnResimSec.ThemeName = "Breeze";
            this.btnResimSec.Click += new System.EventHandler(this.btnResimSec_Click_1);
            // 
            // pr
            // 
            this.pr.BackColor = System.Drawing.Color.White;
            this.pr.Location = new System.Drawing.Point(398, 308);
            this.pr.Name = "pr";
            this.pr.Size = new System.Drawing.Size(252, 303);
            this.pr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pr.TabIndex = 5;
            this.pr.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.MintCream;
            this.label1.Location = new System.Drawing.Point(13, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ürün Kodu :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(426, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 19);
            this.label7.TabIndex = 4;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label14.Location = new System.Drawing.Point(453, 192);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(23, 20);
            this.label14.TabIndex = 4;
            this.label14.Text = "%";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label13.Font = new System.Drawing.Font("Adobe Fangsong Std R", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label13.Location = new System.Drawing.Point(453, 144);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(45, 20);
            this.label13.TabIndex = 4;
            this.label13.Text = "gr/m";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(453, 96);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 20);
            this.label12.TabIndex = 4;
            this.label12.Text = "m/dk";
            // 
            // lblHiz
            // 
            this.lblHiz.AutoSize = true;
            this.lblHiz.BackColor = System.Drawing.Color.Red;
            this.lblHiz.ForeColor = System.Drawing.Color.White;
            this.lblHiz.Location = new System.Drawing.Point(510, 98);
            this.lblHiz.Name = "lblHiz";
            this.lblHiz.Size = new System.Drawing.Size(21, 19);
            this.lblHiz.TabIndex = 4;
            this.lblHiz.Text = "la";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.MintCream;
            this.label2.Location = new System.Drawing.Point(10, 187);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fire Miktarı :";
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.BackColor = System.Drawing.Color.Red;
            this.lblFile.ForeColor = System.Drawing.Color.White;
            this.lblFile.Location = new System.Drawing.Point(510, 193);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(21, 19);
            this.lblFile.TabIndex = 4;
            this.lblFile.Tag = "";
            this.lblFile.Text = "la";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.Color.MintCream;
            this.label6.Location = new System.Drawing.Point(393, 234);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 25);
            this.label6.TabIndex = 1;
            this.label6.Text = "Ürün Resmi :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.MintCream;
            this.label5.Location = new System.Drawing.Point(105, 234);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(217, 29);
            this.label5.TabIndex = 1;
            this.label5.Text = "Kullanılacak Hatlar:";
            // 
            // lblGramaj
            // 
            this.lblGramaj.AutoSize = true;
            this.lblGramaj.BackColor = System.Drawing.Color.Red;
            this.lblGramaj.ForeColor = System.Drawing.Color.White;
            this.lblGramaj.Location = new System.Drawing.Point(510, 144);
            this.lblGramaj.Name = "lblGramaj";
            this.lblGramaj.Size = new System.Drawing.Size(21, 19);
            this.lblGramaj.TabIndex = 4;
            this.lblGramaj.Text = "la";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.MintCream;
            this.label4.Location = new System.Drawing.Point(40, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 25);
            this.label4.TabIndex = 1;
            this.label4.Text = "Gramajı :";
            // 
            // lblKod
            // 
            this.lblKod.AutoSize = true;
            this.lblKod.BackColor = System.Drawing.Color.Red;
            this.lblKod.ForeColor = System.Drawing.Color.White;
            this.lblKod.Location = new System.Drawing.Point(510, 46);
            this.lblKod.Name = "lblKod";
            this.lblKod.Size = new System.Drawing.Size(21, 19);
            this.lblKod.TabIndex = 4;
            this.lblKod.Text = "la";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.MintCream;
            this.label3.Location = new System.Drawing.Point(28, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Ürün Hızı :";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // radUrunEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 697);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(830, 730);
            this.Name = "radUrunEkle";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.RootElement.MaxSize = new System.Drawing.Size(830, 730);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ürün Ekle";
            this.ThemeName = "Breeze";
            this.Load += new System.EventHandler(this.radUrunEkle_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckedListBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFireMiktari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGramaj)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHiz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUrunEkle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnResimSec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Telerik.WinControls.UI.RadButton btnUrunEkle;
        private Telerik.WinControls.UI.RadButton btnResimSec;
        private System.Windows.Forms.PictureBox pr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblHiz;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblGramaj;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblKod;
        private System.Windows.Forms.Label label3;
        private Telerik.WinControls.Themes.AquaTheme aquaTheme1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Telerik.WinControls.UI.RadTextBoxControl txtFireMiktari;
        private Telerik.WinControls.UI.RadTextBoxControl txtGramaj;
        private Telerik.WinControls.UI.RadTextBoxControl txtHiz;
        private Telerik.WinControls.UI.RadTextBoxControl txtKod;
        private Telerik.WinControls.UI.RadCheckedListBox radCheckedListBox1;
        private Telerik.WinControls.Themes.BreezeTheme breezeTheme1;
    }
}
