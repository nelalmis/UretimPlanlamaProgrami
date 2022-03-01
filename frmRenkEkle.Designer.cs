namespace uretimPlanlamaProgrami
{
    partial class frmRenkEkle
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
            this.Renk = new System.Windows.Forms.GroupBox();
            this.lblAd = new System.Windows.Forms.Label();
            this.lblKod = new System.Windows.Forms.Label();
            this.btnRenkEkle = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRenkAdi = new System.Windows.Forms.TextBox();
            this.txtRenKodu = new System.Windows.Forms.TextBox();
            this.Renk.SuspendLayout();
            this.SuspendLayout();
            // 
            // Renk
            // 
            this.Renk.BackColor = System.Drawing.Color.Bisque;
            this.Renk.Controls.Add(this.lblAd);
            this.Renk.Controls.Add(this.lblKod);
            this.Renk.Controls.Add(this.btnRenkEkle);
            this.Renk.Controls.Add(this.label2);
            this.Renk.Controls.Add(this.label1);
            this.Renk.Controls.Add(this.txtRenkAdi);
            this.Renk.Controls.Add(this.txtRenKodu);
            this.Renk.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Renk.Location = new System.Drawing.Point(12, 21);
            this.Renk.Name = "Renk";
            this.Renk.Size = new System.Drawing.Size(710, 278);
            this.Renk.TabIndex = 0;
            this.Renk.TabStop = false;
            this.Renk.Text = "Renk Bilgileri";
            // 
            // lblAd
            // 
            this.lblAd.AutoSize = true;
            this.lblAd.ForeColor = System.Drawing.Color.Red;
            this.lblAd.Location = new System.Drawing.Point(381, 89);
            this.lblAd.Name = "lblAd";
            this.lblAd.Size = new System.Drawing.Size(0, 24);
            this.lblAd.TabIndex = 3;
            // 
            // lblKod
            // 
            this.lblKod.AutoSize = true;
            this.lblKod.ForeColor = System.Drawing.Color.Red;
            this.lblKod.Location = new System.Drawing.Point(381, 51);
            this.lblKod.Name = "lblKod";
            this.lblKod.Size = new System.Drawing.Size(0, 24);
            this.lblKod.TabIndex = 3;
            // 
            // btnRenkEkle
            // 
            this.btnRenkEkle.BackColor = System.Drawing.Color.White;
            this.btnRenkEkle.Image = global::uretimPlanlamaProgrami.Properties.Resources.save;
            this.btnRenkEkle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRenkEkle.Location = new System.Drawing.Point(197, 126);
            this.btnRenkEkle.Name = "btnRenkEkle";
            this.btnRenkEkle.Size = new System.Drawing.Size(178, 91);
            this.btnRenkEkle.TabIndex = 2;
            this.btnRenkEkle.Text = "KAYDET";
            this.btnRenkEkle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRenkEkle.UseVisualStyleBackColor = false;
            this.btnRenkEkle.Click += new System.EventHandler(this.btnRenkEkle_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(24, 81);
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
            this.label1.Location = new System.Drawing.Point(6, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Renk Kodu :";
            // 
            // txtRenkAdi
            // 
            this.txtRenkAdi.Location = new System.Drawing.Point(137, 86);
            this.txtRenkAdi.Name = "txtRenkAdi";
            this.txtRenkAdi.Size = new System.Drawing.Size(238, 29);
            this.txtRenkAdi.TabIndex = 0;
            // 
            // txtRenKodu
            // 
            this.txtRenKodu.Location = new System.Drawing.Point(137, 48);
            this.txtRenKodu.Name = "txtRenKodu";
            this.txtRenKodu.Size = new System.Drawing.Size(238, 29);
            this.txtRenKodu.TabIndex = 0;
            this.txtRenKodu.TextChanged += new System.EventHandler(this.txtRenKodu_TextChanged);
            // 
            // frmRenkEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkBlue;
            this.ClientSize = new System.Drawing.Size(734, 311);
            this.Controls.Add(this.Renk);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(750, 350);
            this.Name = "frmRenkEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Renk Ekle";
            this.Load += new System.EventHandler(this.frmRenkEkle_Load);
            this.Renk.ResumeLayout(false);
            this.Renk.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Renk;
        private System.Windows.Forms.Button btnRenkEkle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRenkAdi;
        private System.Windows.Forms.TextBox txtRenKodu;
        private System.Windows.Forms.Label lblAd;
        private System.Windows.Forms.Label lblKod;
    }
}