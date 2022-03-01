namespace uretimPlanlamaProgrami.RadFormlari
{
    partial class radGiris
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(radGiris));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnIptal = new Telerik.WinControls.UI.RadButton();
            this.btnGiris = new Telerik.WinControls.UI.RadButton();
            this.textBox2 = new Telerik.WinControls.UI.RadTextBoxControl();
            this.textBox1 = new Telerik.WinControls.UI.RadTextBoxControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDurum = new Telerik.WinControls.UI.RadLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.aquaTheme1 = new Telerik.WinControls.Themes.AquaTheme();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSiteyeGit = new Telerik.WinControls.UI.RadButton();
            this.breezeTheme1 = new Telerik.WinControls.Themes.BreezeTheme();
            this.panel3 = new System.Windows.Forms.Panel();
            this.radSeparator1 = new Telerik.WinControls.UI.RadSeparator();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnIptal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGiris)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDurum)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSiteyeGit)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.groupBox1.Controls.Add(this.btnIptal);
            this.groupBox1.Controls.Add(this.btnGiris);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.groupBox1.Location = new System.Drawing.Point(3, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(690, 297);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Giriş Bilgileri";
            // 
            // btnIptal
            // 
            this.btnIptal.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnIptal.Font = new System.Drawing.Font("Verdana", 13F);
            this.btnIptal.Location = new System.Drawing.Point(182, 192);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(185, 59);
            this.btnIptal.TabIndex = 6;
            this.btnIptal.Text = "İPTAL";
            this.btnIptal.ThemeName = "Aqua";
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // btnGiris
            // 
            this.btnGiris.BackColor = System.Drawing.Color.Transparent;
            this.btnGiris.Font = new System.Drawing.Font("Verdana", 13F);
            this.btnGiris.Location = new System.Drawing.Point(380, 192);
            this.btnGiris.Name = "btnGiris";
            this.btnGiris.Size = new System.Drawing.Size(185, 59);
            this.btnGiris.TabIndex = 6;
            this.btnGiris.Text = "GİRİŞ";
            this.btnGiris.ThemeName = "Aqua";
            this.btnGiris.Click += new System.EventHandler(this.btnGiris_Click_1);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Verdana", 21F);
            this.textBox2.Location = new System.Drawing.Point(182, 112);
            this.textBox2.MaxLength = 8;
            this.textBox2.Name = "textBox2";
            this.textBox2.NullText = "Parola";
            this.textBox2.Size = new System.Drawing.Size(383, 48);
            this.textBox2.TabIndex = 5;
            this.textBox2.ThemeName = "Aqua";
            this.textBox2.UseSystemPasswordChar = true;
            this.textBox2.Enter += new System.EventHandler(this.textBox1_Enter);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Verdana", 21F);
            this.textBox1.Location = new System.Drawing.Point(182, 42);
            this.textBox1.Name = "textBox1";
            this.textBox1.NullText = "Kullanıcı adı";
            this.textBox1.Size = new System.Drawing.Size(383, 48);
            this.textBox1.TabIndex = 5;
            this.textBox1.ThemeName = "Aqua";
            this.textBox1.Enter += new System.EventHandler(this.textBox1_Enter);
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(32, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 26);
            this.label1.TabIndex = 4;
            this.label1.Text = "Kullanıcı Adı :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(83, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 26);
            this.label2.TabIndex = 4;
            this.label2.Text = "Parola  :";
            // 
            // lblDurum
            // 
            this.lblDurum.Font = new System.Drawing.Font("Verdana", 15F);
            this.lblDurum.Location = new System.Drawing.Point(185, 312);
            this.lblDurum.Name = "lblDurum";
            this.lblDurum.Size = new System.Drawing.Size(30, 29);
            this.lblDurum.TabIndex = 7;
            this.lblDurum.Text = "ra";
            this.lblDurum.ThemeName = "Aqua";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btnSiteyeGit);
            this.panel2.Location = new System.Drawing.Point(10, 390);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(683, 91);
            this.panel2.TabIndex = 9;
            // 
            // btnSiteyeGit
            // 
            this.btnSiteyeGit.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.btnSiteyeGit.Location = new System.Drawing.Point(3, 10);
            this.btnSiteyeGit.Name = "btnSiteyeGit";
            this.btnSiteyeGit.Size = new System.Drawing.Size(672, 65);
            this.btnSiteyeGit.TabIndex = 0;
            this.btnSiteyeGit.Text = "Siteye Git";
            this.btnSiteyeGit.ThemeName = "Breeze";
            this.btnSiteyeGit.Click += new System.EventHandler(this.btnSiteyeGit_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.radSeparator1);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.lblDurum);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(696, 498);
            this.panel3.TabIndex = 10;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // radSeparator1
            // 
            this.radSeparator1.Location = new System.Drawing.Point(10, 356);
            this.radSeparator1.Name = "radSeparator1";
            this.radSeparator1.Size = new System.Drawing.Size(677, 13);
            this.radSeparator1.TabIndex = 10;
            this.radSeparator1.Text = "radSeparator1";
            // 
            // radGiris
            // 
            this.AcceptButton = this.btnGiris;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnIptal;
            this.ClientSize = new System.Drawing.Size(696, 524);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(704, 557);
            this.MinimumSize = new System.Drawing.Size(664, 365);
            this.Name = "radGiris";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.RootElement.MaxSize = new System.Drawing.Size(704, 557);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TAYSAN ÜRETİM PLANLAMA GİRİŞ FORMU";
            this.ThemeName = "Breeze";
            this.Activated += new System.EventHandler(this.radGiris_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.radGiris_FormClosed);
            this.Load += new System.EventHandler(this.radGiris_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnIptal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGiris)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDurum)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnSiteyeGit)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Telerik.WinControls.UI.RadTextBoxControl textBox2;
        private Telerik.WinControls.UI.RadTextBoxControl textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Telerik.WinControls.UI.RadLabel lblDurum;
        private Telerik.WinControls.UI.RadButton btnGiris;
        private Telerik.WinControls.UI.RadButton btnIptal;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private Telerik.WinControls.Themes.AquaTheme aquaTheme1;
        private System.Windows.Forms.Panel panel2;
        private Telerik.WinControls.UI.RadButton btnSiteyeGit;
        private Telerik.WinControls.Themes.BreezeTheme breezeTheme1;
        private System.Windows.Forms.Panel panel3;
        private Telerik.WinControls.UI.RadSeparator radSeparator1;
    }
}
