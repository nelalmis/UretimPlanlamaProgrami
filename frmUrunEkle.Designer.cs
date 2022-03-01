namespace uretimPlanlamaProgrami
{
    partial class frmUrunEkle
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
            this.txtUrunKod = new System.Windows.Forms.TextBox();
            this.txtUrunHiz = new System.Windows.Forms.TextBox();
            this.txtGramaj = new System.Windows.Forms.TextBox();
            this.txtFileMiktari = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnUrunEkle = new System.Windows.Forms.Button();
            this.lblKod = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblGramaj = new System.Windows.Forms.Label();
            this.lblFile = new System.Windows.Forms.Label();
            this.lblHiz = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pr = new System.Windows.Forms.PictureBox();
            this.btnResimSec = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pr)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUrunKod
            // 
            this.txtUrunKod.Location = new System.Drawing.Point(136, 33);
            this.txtUrunKod.Name = "txtUrunKod";
            this.txtUrunKod.Size = new System.Drawing.Size(238, 37);
            this.txtUrunKod.TabIndex = 0;
            this.txtUrunKod.TextChanged += new System.EventHandler(this.txtUrunKod_TextChanged);
            // 
            // txtUrunHiz
            // 
            this.txtUrunHiz.Location = new System.Drawing.Point(136, 89);
            this.txtUrunHiz.Name = "txtUrunHiz";
            this.txtUrunHiz.Size = new System.Drawing.Size(238, 37);
            this.txtUrunHiz.TabIndex = 0;
            this.txtUrunHiz.TextChanged += new System.EventHandler(this.txtUrunKod_TextChanged);
            this.txtUrunHiz.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUrunKod_KeyPress);
            // 
            // txtGramaj
            // 
            this.txtGramaj.Location = new System.Drawing.Point(136, 135);
            this.txtGramaj.Name = "txtGramaj";
            this.txtGramaj.Size = new System.Drawing.Size(238, 37);
            this.txtGramaj.TabIndex = 0;
            this.txtGramaj.TextChanged += new System.EventHandler(this.txtUrunKod_TextChanged);
            this.txtGramaj.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUrunKod_KeyPress);
            // 
            // txtFileMiktari
            // 
            this.txtFileMiktari.Location = new System.Drawing.Point(134, 184);
            this.txtFileMiktari.Name = "txtFileMiktari";
            this.txtFileMiktari.Size = new System.Drawing.Size(238, 37);
            this.txtFileMiktari.TabIndex = 0;
            this.txtFileMiktari.TextChanged += new System.EventHandler(this.txtUrunKod_TextChanged);
            this.txtFileMiktari.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUrunKod_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(46, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ürün Kodu :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(53, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fire Miktarı :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(64, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Ürün Hızı :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(73, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Gramajı :";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 19;
            this.listBox1.Location = new System.Drawing.Point(144, 237);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox1.Size = new System.Drawing.Size(177, 289);
            this.listBox1.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(1, 237);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Kullanılacak Hatlar:";
            // 
            // btnUrunEkle
            // 
            this.btnUrunEkle.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnUrunEkle.ForeColor = System.Drawing.Color.Red;
            this.btnUrunEkle.Location = new System.Drawing.Point(541, 558);
            this.btnUrunEkle.Name = "btnUrunEkle";
            this.btnUrunEkle.Size = new System.Drawing.Size(164, 58);
            this.btnUrunEkle.TabIndex = 3;
            this.btnUrunEkle.Text = "ÜRÜNÜ EKLE";
            this.btnUrunEkle.UseVisualStyleBackColor = false;
            this.btnUrunEkle.Click += new System.EventHandler(this.btnUrunEkle_Click);
            // 
            // lblKod
            // 
            this.lblKod.AutoSize = true;
            this.lblKod.Location = new System.Drawing.Point(414, 40);
            this.lblKod.Name = "lblKod";
            this.lblKod.Size = new System.Drawing.Size(0, 19);
            this.lblKod.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(426, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 19);
            this.label7.TabIndex = 4;
            // 
            // lblGramaj
            // 
            this.lblGramaj.AutoSize = true;
            this.lblGramaj.Location = new System.Drawing.Point(429, 138);
            this.lblGramaj.Name = "lblGramaj";
            this.lblGramaj.Size = new System.Drawing.Size(0, 19);
            this.lblGramaj.TabIndex = 4;
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(414, 187);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(0, 19);
            this.lblFile.TabIndex = 4;
            // 
            // lblHiz
            // 
            this.lblHiz.AutoSize = true;
            this.lblHiz.Location = new System.Drawing.Point(429, 92);
            this.lblHiz.Name = "lblHiz";
            this.lblHiz.Size = new System.Drawing.Size(0, 19);
            this.lblHiz.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label12.Location = new System.Drawing.Point(380, 92);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 15);
            this.label12.TabIndex = 4;
            this.label12.Text = "m/dk";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(380, 138);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 19);
            this.label13.TabIndex = 4;
            this.label13.Text = "gr/m";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label14.Location = new System.Drawing.Point(378, 187);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(20, 17);
            this.label14.TabIndex = 4;
            this.label14.Text = "%";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Bisque;
            this.groupBox1.Controls.Add(this.btnResimSec);
            this.groupBox1.Controls.Add(this.pr);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtUrunKod);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.txtUrunHiz);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtGramaj);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtFileMiktari);
            this.groupBox1.Controls.Add(this.lblHiz);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblFile);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblGramaj);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblKod);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnUrunEkle);
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Font = new System.Drawing.Font("Adobe Fangsong Std R", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(61, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(711, 622);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ürün Bilgileri";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(357, 237);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "Ürün Resmi :";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // pr
            // 
            this.pr.BackColor = System.Drawing.Color.White;
            this.pr.Location = new System.Drawing.Point(453, 248);
            this.pr.Name = "pr";
            this.pr.Size = new System.Drawing.Size(252, 278);
            this.pr.TabIndex = 5;
            this.pr.TabStop = false;
            // 
            // btnResimSec
            // 
            this.btnResimSec.Location = new System.Drawing.Point(470, 214);
            this.btnResimSec.Name = "btnResimSec";
            this.btnResimSec.Size = new System.Drawing.Size(208, 28);
            this.btnResimSec.TabIndex = 6;
            this.btnResimSec.Text = "Ürün Resmi Seç";
            this.btnResimSec.UseVisualStyleBackColor = true;
            this.btnResimSec.Click += new System.EventHandler(this.btnResimSec_Click);
            // 
            // frmUrunEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 661);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 700);
            this.Name = "frmUrunEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ÜRÜN EKLE";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmUrunEkle_FormClosed);
            this.Load += new System.EventHandler(this.frmUrunEkle_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pr)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtUrunKod;
        private System.Windows.Forms.TextBox txtUrunHiz;
        private System.Windows.Forms.TextBox txtGramaj;
        private System.Windows.Forms.TextBox txtFileMiktari;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnUrunEkle;
        private System.Windows.Forms.Label lblKod;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblGramaj;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.Label lblHiz;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox pr;
        private System.Windows.Forms.Button btnResimSec;
    }
}