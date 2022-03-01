namespace uretimPlanlamaProgrami
{
    partial class frmHammaddeEkle
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnHammaddeEkle = new System.Windows.Forms.Button();
            this.txtHammadde = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.AliceBlue;
            this.groupBox1.Controls.Add(this.btnHammaddeEkle);
            this.groupBox1.Controls.Add(this.txtHammadde);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.groupBox1.Location = new System.Drawing.Point(27, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(464, 175);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hammadde ";
            // 
            // btnHammaddeEkle
            // 
            this.btnHammaddeEkle.BackColor = System.Drawing.Color.White;
            this.btnHammaddeEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnHammaddeEkle.Image = global::uretimPlanlamaProgrami.Properties.Resources.save;
            this.btnHammaddeEkle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHammaddeEkle.Location = new System.Drawing.Point(253, 83);
            this.btnHammaddeEkle.Name = "btnHammaddeEkle";
            this.btnHammaddeEkle.Size = new System.Drawing.Size(165, 86);
            this.btnHammaddeEkle.TabIndex = 2;
            this.btnHammaddeEkle.Text = "EKLE";
            this.btnHammaddeEkle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHammaddeEkle.UseVisualStyleBackColor = false;
            this.btnHammaddeEkle.Click += new System.EventHandler(this.btnHammaddeEkle_Click);
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(287, 88);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 43);
            this.button1.TabIndex = 2;
            this.button1.Text = "EKLE";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(182, 34);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(236, 20);
            this.textBox1.TabIndex = 0;
            // 
            // frmHammaddeEkle
            // 
            this.AcceptButton = this.btnHammaddeEkle;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkBlue;
            this.ClientSize = new System.Drawing.Size(527, 211);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Location = new System.Drawing.Point(15, 20);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 250);
            this.Name = "frmHammaddeEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmHammaddeEkle";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.frmHammaddeEkle_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnHammaddeEkle;
        private System.Windows.Forms.TextBox txtHammadde;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;

    }
}