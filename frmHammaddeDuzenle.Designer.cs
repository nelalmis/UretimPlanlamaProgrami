namespace uretimPlanlamaProgrami
{
    partial class frmHammaddeDuzenle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHammaddeDuzenle));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.pnlHammaddeDuzenle = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnHammaddeGuncelle = new System.Windows.Forms.Button();
            this.txtHammadde = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnDuzenle = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.pnlHammaddeDuzenle.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Cornsilk;
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.ForeColor = System.Drawing.Color.Brown;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(209, 337);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hammaddeler";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(18, 29);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(147, 284);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // pnlHammaddeDuzenle
            // 
            this.pnlHammaddeDuzenle.BackColor = System.Drawing.Color.SpringGreen;
            this.pnlHammaddeDuzenle.Controls.Add(this.groupBox2);
            this.pnlHammaddeDuzenle.Location = new System.Drawing.Point(237, 216);
            this.pnlHammaddeDuzenle.Name = "pnlHammaddeDuzenle";
            this.pnlHammaddeDuzenle.Size = new System.Drawing.Size(539, 233);
            this.pnlHammaddeDuzenle.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnHammaddeGuncelle);
            this.groupBox2.Controls.Add(this.txtHammadde);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox2.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.groupBox2.Location = new System.Drawing.Point(18, 33);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(484, 151);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hammadde ";
            // 
            // btnHammaddeGuncelle
            // 
            this.btnHammaddeGuncelle.BackColor = System.Drawing.Color.White;
            this.btnHammaddeGuncelle.Image = global::uretimPlanlamaProgrami.Properties.Resources.güncelleme1;
            this.btnHammaddeGuncelle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHammaddeGuncelle.Location = new System.Drawing.Point(241, 66);
            this.btnHammaddeGuncelle.Name = "btnHammaddeGuncelle";
            this.btnHammaddeGuncelle.Size = new System.Drawing.Size(177, 79);
            this.btnHammaddeGuncelle.TabIndex = 2;
            this.btnHammaddeGuncelle.Text = "GÜNCELLE";
            this.btnHammaddeGuncelle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHammaddeGuncelle.UseVisualStyleBackColor = false;
            this.btnHammaddeGuncelle.Click += new System.EventHandler(this.btnHammaddeEkle_Click);
            // 
            // txtHammadde
            // 
            this.txtHammadde.Location = new System.Drawing.Point(182, 34);
            this.txtHammadde.Name = "txtHammadde";
            this.txtHammadde.Size = new System.Drawing.Size(236, 26);
            this.txtHammadde.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hammadde Adı :";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnSil
            // 
            this.btnSil.BackColor = System.Drawing.Color.White;
            this.btnSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSil.ForeColor = System.Drawing.Color.Red;
            this.btnSil.Image = global::uretimPlanlamaProgrami.Properties.Resources.delete;
            this.btnSil.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSil.Location = new System.Drawing.Point(237, 141);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(173, 72);
            this.btnSil.TabIndex = 4;
            this.btnSil.Text = "          SİL";
            this.btnSil.UseVisualStyleBackColor = false;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click_1);
            // 
            // btnDuzenle
            // 
            this.btnDuzenle.BackColor = System.Drawing.Color.White;
            this.btnDuzenle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDuzenle.Font = new System.Drawing.Font("Lucida Console", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDuzenle.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btnDuzenle.Image = global::uretimPlanlamaProgrami.Properties.Resources.güncelleme1;
            this.btnDuzenle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDuzenle.Location = new System.Drawing.Point(237, 55);
            this.btnDuzenle.Name = "btnDuzenle";
            this.btnDuzenle.Size = new System.Drawing.Size(173, 79);
            this.btnDuzenle.TabIndex = 1;
            this.btnDuzenle.Text = "DÜZENLE";
            this.btnDuzenle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDuzenle.UseVisualStyleBackColor = false;
            this.btnDuzenle.Click += new System.EventHandler(this.btnDuzenle_Click);
            // 
            // frmHammaddeDuzenle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkBlue;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.pnlHammaddeDuzenle);
            this.Controls.Add(this.btnDuzenle);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(15, 20);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(900, 500);
            this.Name = "frmHammaddeDuzenle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hammadde Düzenle";
            this.Load += new System.EventHandler(this.frmHammaddeDuzenle_Load);
            this.groupBox1.ResumeLayout(false);
            this.pnlHammaddeDuzenle.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnDuzenle;
        private System.Windows.Forms.Panel pnlHammaddeDuzenle;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnHammaddeGuncelle;
        private System.Windows.Forms.TextBox txtHammadde;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSil;
    }
}