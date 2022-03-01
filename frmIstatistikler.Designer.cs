namespace uretimPlanlamaProgrami
{
    partial class frmIstatistikler
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
            this.dtUrunler = new Microsoft.TeamFoundation.Client.DataGridViewWithDetails();
            this.urunKod = new System.Windows.Forms.DataGridViewButtonColumn();
            this.miktar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridViewWithDetails2 = new Microsoft.TeamFoundation.Client.DataGridViewWithDetails();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridViewWithDetails3 = new Microsoft.TeamFoundation.Client.DataGridViewWithDetails();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dataGridViewWithDetails4 = new Microsoft.TeamFoundation.Client.DataGridViewWithDetails();
            ((System.ComponentModel.ISupportInitialize)(this.dtUrunler)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWithDetails2)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWithDetails3)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWithDetails4)).BeginInit();
            this.SuspendLayout();
            // 
            // dtUrunler
            // 
            this.dtUrunler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtUrunler.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.urunKod,
            this.miktar});
            this.dtUrunler.DetailsBackColor = System.Drawing.SystemColors.Window;
            this.dtUrunler.DetailsCollapsedImage = null;
            this.dtUrunler.DetailsExpandedImage = null;
            this.dtUrunler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtUrunler.Location = new System.Drawing.Point(3, 16);
            this.dtUrunler.Name = "dtUrunler";
            this.dtUrunler.Size = new System.Drawing.Size(317, 183);
            this.dtUrunler.TabIndex = 1;
            // 
            // urunKod
            // 
            this.urunKod.HeaderText = "Ürün Kodu";
            this.urunKod.Name = "urunKod";
            // 
            // miktar
            // 
            this.miktar.HeaderText = "Kullanılan Miktar";
            this.miktar.Name = "miktar";
            this.miktar.Width = 150;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtUrunler);
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(323, 202);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridViewWithDetails2);
            this.groupBox2.Location = new System.Drawing.Point(355, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(323, 202);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox1";
            // 
            // dataGridViewWithDetails2
            // 
            this.dataGridViewWithDetails2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWithDetails2.DetailsBackColor = System.Drawing.SystemColors.Window;
            this.dataGridViewWithDetails2.DetailsCollapsedImage = null;
            this.dataGridViewWithDetails2.DetailsExpandedImage = null;
            this.dataGridViewWithDetails2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewWithDetails2.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewWithDetails2.Name = "dataGridViewWithDetails2";
            this.dataGridViewWithDetails2.Size = new System.Drawing.Size(317, 183);
            this.dataGridViewWithDetails2.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridViewWithDetails3);
            this.groupBox3.Location = new System.Drawing.Point(708, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(323, 202);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox1";
            // 
            // dataGridViewWithDetails3
            // 
            this.dataGridViewWithDetails3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWithDetails3.DetailsBackColor = System.Drawing.SystemColors.Window;
            this.dataGridViewWithDetails3.DetailsCollapsedImage = null;
            this.dataGridViewWithDetails3.DetailsExpandedImage = null;
            this.dataGridViewWithDetails3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewWithDetails3.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewWithDetails3.Name = "dataGridViewWithDetails3";
            this.dataGridViewWithDetails3.Size = new System.Drawing.Size(317, 183);
            this.dataGridViewWithDetails3.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dataGridViewWithDetails4);
            this.groupBox4.Location = new System.Drawing.Point(9, 230);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(323, 202);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "groupBox1";
            // 
            // dataGridViewWithDetails4
            // 
            this.dataGridViewWithDetails4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWithDetails4.DetailsBackColor = System.Drawing.SystemColors.Window;
            this.dataGridViewWithDetails4.DetailsCollapsedImage = null;
            this.dataGridViewWithDetails4.DetailsExpandedImage = null;
            this.dataGridViewWithDetails4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewWithDetails4.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewWithDetails4.Name = "dataGridViewWithDetails4";
            this.dataGridViewWithDetails4.Size = new System.Drawing.Size(317, 183);
            this.dataGridViewWithDetails4.TabIndex = 1;
            // 
            // frmIstatistikler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1383, 541);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmIstatistikler";
            this.Text = "frmIstatistikler";
            this.Load += new System.EventHandler(this.frmIstatistikler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtUrunler)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWithDetails2)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWithDetails3)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWithDetails4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.TeamFoundation.Client.DataGridViewWithDetails dtUrunler;
        private System.Windows.Forms.DataGridViewButtonColumn urunKod;
        private System.Windows.Forms.DataGridViewTextBoxColumn miktar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private Microsoft.TeamFoundation.Client.DataGridViewWithDetails dataGridViewWithDetails2;
        private System.Windows.Forms.GroupBox groupBox3;
        private Microsoft.TeamFoundation.Client.DataGridViewWithDetails dataGridViewWithDetails3;
        private System.Windows.Forms.GroupBox groupBox4;
        private Microsoft.TeamFoundation.Client.DataGridViewWithDetails dataGridViewWithDetails4;


    }
}