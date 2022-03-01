namespace uretimPlanlamaProgrami.RadFormlari
{
    partial class radHatEkle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(radHatEkle));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtHatNo = new Telerik.WinControls.UI.RadTextBoxControl();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.label1 = new System.Windows.Forms.Label();
            this.lblHat = new System.Windows.Forms.Label();
            this.breezeTheme1 = new Telerik.WinControls.Themes.BreezeTheme();
            this.aquaTheme1 = new Telerik.WinControls.Themes.AquaTheme();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtHatNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightSlateGray;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.groupBox1.Controls.Add(this.txtHatNo);
            this.groupBox1.Controls.Add(this.radButton1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblHat);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(685, 189);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Üretim Hattı";
            // 
            // txtHatNo
            // 
            this.txtHatNo.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.txtHatNo.IsReadOnly = true;
            this.txtHatNo.Location = new System.Drawing.Point(169, 29);
            this.txtHatNo.Name = "txtHatNo";
            this.txtHatNo.NullText = "Hat no";
            this.txtHatNo.Size = new System.Drawing.Size(221, 36);
            this.txtHatNo.TabIndex = 5;
            this.txtHatNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHatNo_KeyPress);
            // 
            // radButton1
            // 
            this.radButton1.Font = new System.Drawing.Font("Verdana", 15F);
            this.radButton1.Location = new System.Drawing.Point(431, 118);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(248, 65);
            this.radButton1.TabIndex = 4;
            this.radButton1.Text = "HAT EKLE";
            this.radButton1.ThemeName = "Aqua";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
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
            // lblHat
            // 
            this.lblHat.AutoSize = true;
            this.lblHat.ForeColor = System.Drawing.Color.Red;
            this.lblHat.Location = new System.Drawing.Point(428, 40);
            this.lblHat.Name = "lblHat";
            this.lblHat.Size = new System.Drawing.Size(0, 25);
            this.lblHat.TabIndex = 3;
            // 
            // radHatEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(706, 210);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(714, 243);
            this.Name = "radHatEkle";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.RootElement.MaxSize = new System.Drawing.Size(714, 243);
            this.Text = "Hat Ekle";
            this.ThemeName = "Breeze";
            this.Load += new System.EventHandler(this.radHatEkle_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtHatNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblHat;
        private Telerik.WinControls.UI.RadTextBoxControl txtHatNo;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.Themes.BreezeTheme breezeTheme1;
        private Telerik.WinControls.Themes.AquaTheme aquaTheme1;
    }
}
