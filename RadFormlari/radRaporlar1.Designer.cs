namespace uretimPlanlamaProgrami.RadFormlari
{
    partial class radRaporlar1
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(radRaporlar1));
            this.siparisBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.genelDataSet = new uretimPlanlamaProgrami.genelDataSet();
            this.urunlerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uretimHattiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.renklerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hammaddeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reportViewer3 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reportViewer4 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reportViewer5 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.siparisTableAdapter = new uretimPlanlamaProgrami.genelDataSetTableAdapters.siparisTableAdapter();
            this.pnlSiparis = new System.Windows.Forms.Panel();
            this.pnlRenkler = new System.Windows.Forms.Panel();
            this.pnlUrunler = new System.Windows.Forms.Panel();
            this.pnlHammadde = new System.Windows.Forms.Panel();
            this.pnlUretimHatlari = new System.Windows.Forms.Panel();
            this.urunlerTableAdapter = new uretimPlanlamaProgrami.genelDataSetTableAdapters.urunlerTableAdapter();
            this.uretimHattiTableAdapter = new uretimPlanlamaProgrami.genelDataSetTableAdapters.uretimHattiTableAdapter();
            this.renklerTableAdapter = new uretimPlanlamaProgrami.genelDataSetTableAdapters.renklerTableAdapter();
            this.hammaddeTableAdapter = new uretimPlanlamaProgrami.genelDataSetTableAdapters.hammaddeTableAdapter();
            this.breezeTheme1 = new Telerik.WinControls.Themes.BreezeTheme();
            ((System.ComponentModel.ISupportInitialize)(this.siparisBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.genelDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.urunlerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uretimHattiBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.renklerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hammaddeBindingSource)).BeginInit();
            this.pnlSiparis.SuspendLayout();
            this.pnlRenkler.SuspendLayout();
            this.pnlUrunler.SuspendLayout();
            this.pnlHammadde.SuspendLayout();
            this.pnlUretimHatlari.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // siparisBindingSource
            // 
            this.siparisBindingSource.DataMember = "siparis";
            this.siparisBindingSource.DataSource = this.genelDataSet;
            // 
            // genelDataSet
            // 
            this.genelDataSet.DataSetName = "genelDataSet";
            this.genelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // urunlerBindingSource
            // 
            this.urunlerBindingSource.DataMember = "urunler";
            this.urunlerBindingSource.DataSource = this.genelDataSet;
            // 
            // uretimHattiBindingSource
            // 
            this.uretimHattiBindingSource.DataMember = "uretimHatti";
            this.uretimHattiBindingSource.DataSource = this.genelDataSet;
            // 
            // renklerBindingSource
            // 
            this.renklerBindingSource.DataMember = "renkler";
            this.renklerBindingSource.DataSource = this.genelDataSet;
            // 
            // hammaddeBindingSource
            // 
            this.hammaddeBindingSource.DataMember = "hammadde";
            this.hammaddeBindingSource.DataSource = this.genelDataSet;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.siparisBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "uretimPlanlamaProgrami.RadFormlari.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(282, 144);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.FullPage;
            // 
            // reportViewer2
            // 
            this.reportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.urunlerBindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "uretimPlanlamaProgrami.Report2.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(0, 0);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.Size = new System.Drawing.Size(305, 154);
            this.reportViewer2.TabIndex = 1;
            // 
            // reportViewer3
            // 
            this.reportViewer3.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource3.Name = "DataSet1";
            reportDataSource3.Value = this.uretimHattiBindingSource;
            this.reportViewer3.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer3.LocalReport.ReportEmbeddedResource = "uretimPlanlamaProgrami.Report3.rdlc";
            this.reportViewer3.Location = new System.Drawing.Point(0, 0);
            this.reportViewer3.Name = "reportViewer3";
            this.reportViewer3.Size = new System.Drawing.Size(291, 223);
            this.reportViewer3.TabIndex = 1;
            // 
            // reportViewer4
            // 
            this.reportViewer4.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource4.Name = "DataSet1";
            reportDataSource4.Value = this.renklerBindingSource;
            this.reportViewer4.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer4.LocalReport.ReportEmbeddedResource = "uretimPlanlamaProgrami.Report4.rdlc";
            this.reportViewer4.Location = new System.Drawing.Point(0, 0);
            this.reportViewer4.Name = "reportViewer4";
            this.reportViewer4.Size = new System.Drawing.Size(278, 145);
            this.reportViewer4.TabIndex = 1;
            // 
            // reportViewer5
            // 
            this.reportViewer5.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource5.Name = "DataSet1";
            reportDataSource5.Value = this.hammaddeBindingSource;
            this.reportViewer5.LocalReport.DataSources.Add(reportDataSource5);
            this.reportViewer5.LocalReport.ReportEmbeddedResource = "uretimPlanlamaProgrami.Report5.rdlc";
            this.reportViewer5.Location = new System.Drawing.Point(0, 0);
            this.reportViewer5.Name = "reportViewer5";
            this.reportViewer5.Size = new System.Drawing.Size(309, 134);
            this.reportViewer5.TabIndex = 1;
            // 
            // siparisTableAdapter
            // 
            this.siparisTableAdapter.ClearBeforeFill = true;
            // 
            // pnlSiparis
            // 
            this.pnlSiparis.Controls.Add(this.reportViewer1);
            this.pnlSiparis.Location = new System.Drawing.Point(12, 20);
            this.pnlSiparis.Name = "pnlSiparis";
            this.pnlSiparis.Size = new System.Drawing.Size(282, 144);
            this.pnlSiparis.TabIndex = 2;
            // 
            // pnlRenkler
            // 
            this.pnlRenkler.Controls.Add(this.reportViewer4);
            this.pnlRenkler.Location = new System.Drawing.Point(12, 187);
            this.pnlRenkler.Name = "pnlRenkler";
            this.pnlRenkler.Size = new System.Drawing.Size(278, 145);
            this.pnlRenkler.TabIndex = 3;
            // 
            // pnlUrunler
            // 
            this.pnlUrunler.Controls.Add(this.reportViewer2);
            this.pnlUrunler.Location = new System.Drawing.Point(322, 20);
            this.pnlUrunler.Name = "pnlUrunler";
            this.pnlUrunler.Size = new System.Drawing.Size(305, 154);
            this.pnlUrunler.TabIndex = 4;
            // 
            // pnlHammadde
            // 
            this.pnlHammadde.Controls.Add(this.reportViewer5);
            this.pnlHammadde.Location = new System.Drawing.Point(322, 198);
            this.pnlHammadde.Name = "pnlHammadde";
            this.pnlHammadde.Size = new System.Drawing.Size(309, 134);
            this.pnlHammadde.TabIndex = 5;
            // 
            // pnlUretimHatlari
            // 
            this.pnlUretimHatlari.Controls.Add(this.reportViewer3);
            this.pnlUretimHatlari.Location = new System.Drawing.Point(693, 30);
            this.pnlUretimHatlari.Name = "pnlUretimHatlari";
            this.pnlUretimHatlari.Size = new System.Drawing.Size(291, 223);
            this.pnlUretimHatlari.TabIndex = 6;
            // 
            // urunlerTableAdapter
            // 
            this.urunlerTableAdapter.ClearBeforeFill = true;
            // 
            // uretimHattiTableAdapter
            // 
            this.uretimHattiTableAdapter.ClearBeforeFill = true;
            // 
            // renklerTableAdapter
            // 
            this.renklerTableAdapter.ClearBeforeFill = true;
            // 
            // hammaddeTableAdapter
            // 
            this.hammaddeTableAdapter.ClearBeforeFill = true;
            // 
            // radRaporlar1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1238, 591);
            this.Controls.Add(this.pnlUretimHatlari);
            this.Controls.Add(this.pnlHammadde);
            this.Controls.Add(this.pnlUrunler);
            this.Controls.Add(this.pnlRenkler);
            this.Controls.Add(this.pnlSiparis);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "radRaporlar1";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rapor Formu";
            this.ThemeName = "Breeze";
            this.Load += new System.EventHandler(this.radRaporlar1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.siparisBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.genelDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.urunlerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uretimHattiBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.renklerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hammaddeBindingSource)).EndInit();
            this.pnlSiparis.ResumeLayout(false);
            this.pnlRenkler.ResumeLayout(false);
            this.pnlUrunler.ResumeLayout(false);
            this.pnlHammadde.ResumeLayout(false);
            this.pnlUretimHatlari.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer3;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer4;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer5;
        private genelDataSet genelDataSet;
        private System.Windows.Forms.BindingSource siparisBindingSource;
        private genelDataSetTableAdapters.siparisTableAdapter siparisTableAdapter;
        private System.Windows.Forms.Panel pnlSiparis;
        private System.Windows.Forms.Panel pnlRenkler;
        private System.Windows.Forms.Panel pnlUrunler;
        private System.Windows.Forms.Panel pnlHammadde;
        private System.Windows.Forms.Panel pnlUretimHatlari;
        private genelDataSetTableAdapters.urunlerTableAdapter urunlerTableAdapter;
        private System.Windows.Forms.BindingSource urunlerBindingSource;
        private System.Windows.Forms.BindingSource uretimHattiBindingSource;
        private genelDataSetTableAdapters.uretimHattiTableAdapter uretimHattiTableAdapter;
        private System.Windows.Forms.BindingSource renklerBindingSource;
        private genelDataSetTableAdapters.renklerTableAdapter renklerTableAdapter;
        private System.Windows.Forms.BindingSource hammaddeBindingSource;
        private genelDataSetTableAdapters.hammaddeTableAdapter hammaddeTableAdapter;
        private Telerik.WinControls.Themes.BreezeTheme breezeTheme1;
    }
}
