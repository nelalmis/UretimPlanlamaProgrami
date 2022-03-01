namespace uretimPlanlamaProgrami
{
    partial class frmUretimHattiEkle
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblHat = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnHatEkle = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(6, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "ÜRETİM HAT NO :";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(164, 29);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(167, 30);
            this.textBox1.TabIndex = 1;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // lblHat
            // 
            this.lblHat.AutoSize = true;
            this.lblHat.ForeColor = System.Drawing.Color.Red;
            this.lblHat.Location = new System.Drawing.Point(348, 32);
            this.lblHat.Name = "lblHat";
            this.lblHat.Size = new System.Drawing.Size(0, 25);
            this.lblHat.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Bisque;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblHat);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.btnHatEkle);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 173);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Üretim Hattı";
            // 
            // btnHatEkle
            // 
            this.btnHatEkle.BackColor = System.Drawing.Color.White;
            this.btnHatEkle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnHatEkle.Image = global::uretimPlanlamaProgrami.Properties.Resources.save;
            this.btnHatEkle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHatEkle.Location = new System.Drawing.Point(370, 72);
            this.btnHatEkle.Name = "btnHatEkle";
            this.btnHatEkle.Size = new System.Drawing.Size(184, 95);
            this.btnHatEkle.TabIndex = 2;
            this.btnHatEkle.Text = "KAYDET";
            this.btnHatEkle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHatEkle.UseVisualStyleBackColor = false;
            this.btnHatEkle.Click += new System.EventHandler(this.btnHatEkle_Click);
            // 
            // frmUretimHattiEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Brown;
            this.ClientSize = new System.Drawing.Size(584, 211);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 250);
            this.Name = "frmUretimHattiEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Üretim Hattı  Ekleme";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmUretimHattiEkle_FormClosed);
            this.Load += new System.EventHandler(this.frmUretimHattiEkle_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnHatEkle;
        private System.Windows.Forms.Label lblHat;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}