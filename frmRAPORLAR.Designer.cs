namespace uretimPlanlamaProgrami
{
    partial class frmRAPORLAR
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource6 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource7 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource8 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource9 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource10 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.urunlerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.genelDataSet = new uretimPlanlamaProgrami.genelDataSet();
            this.siparisBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uretimHattiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pnlSİparis = new System.Windows.Forms.Panel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.pnlUrunler = new System.Windows.Forms.Panel();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.urunlerTableAdapter = new uretimPlanlamaProgrami.genelDataSetTableAdapters.urunlerTableAdapter();
            this.siparisTableAdapter = new uretimPlanlamaProgrami.genelDataSetTableAdapters.siparisTableAdapter();
            this.pnlUretimHatlari = new System.Windows.Forms.Panel();
            this.reportViewer3 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.uretimHattiTableAdapter = new uretimPlanlamaProgrami.genelDataSetTableAdapters.uretimHattiTableAdapter();
            this.pnlRenkler = new System.Windows.Forms.Panel();
            this.reportViewer4 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.renklerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.renklerTableAdapter = new uretimPlanlamaProgrami.genelDataSetTableAdapters.renklerTableAdapter();
            this.pnlHammadde = new System.Windows.Forms.Panel();
            this.reportViewer5 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.hammaddeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hammaddeTableAdapter = new uretimPlanlamaProgrami.genelDataSetTableAdapters.hammaddeTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.urunlerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.genelDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.siparisBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uretimHattiBindingSource)).BeginInit();
            this.pnlSİparis.SuspendLayout();
            this.pnlUrunler.SuspendLayout();
            this.pnlUretimHatlari.SuspendLayout();
            this.pnlRenkler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.renklerBindingSource)).BeginInit();
            this.pnlHammadde.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hammaddeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // urunlerBindingSource
            // 
            this.urunlerBindingSource.DataMember = "urunler";
            this.urunlerBindingSource.DataSource = this.genelDataSet;
            // 
            // genelDataSet
            // 
            this.genelDataSet.DataSetName = "genelDataSet";
            this.genelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // siparisBindingSource
            // 
            this.siparisBindingSource.DataMember = "siparis";
            this.siparisBindingSource.DataSource = this.genelDataSet;
            // 
            // uretimHattiBindingSource
            // 
            this.uretimHattiBindingSource.DataMember = "uretimHatti";
            this.uretimHattiBindingSource.DataSource = this.genelDataSet;
            // 
            // pnlSİparis
            // 
            this.pnlSİparis.Controls.Add(this.reportViewer1);
            this.pnlSİparis.Location = new System.Drawing.Point(12, 12);
            this.pnlSİparis.Name = "pnlSİparis";
            this.pnlSİparis.Size = new System.Drawing.Size(337, 139);
            this.pnlSİparis.TabIndex = 1;
            // 
            // reportViewer1
            // 
            this.reportViewer1.AutoScroll = true;
            this.reportViewer1.AutoSize = true;
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.ForeColor = System.Drawing.Color.Black;
            reportDataSource6.Name = "DataSet1";
            reportDataSource6.Value = this.siparisBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource6);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "uretimPlanlamaProgrami.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(337, 139);
            this.reportViewer1.TabIndex = 0;
            // 
            // pnlUrunler
            // 
            this.pnlUrunler.Controls.Add(this.reportViewer2);
            this.pnlUrunler.Location = new System.Drawing.Point(368, 12);
            this.pnlUrunler.Name = "pnlUrunler";
            this.pnlUrunler.Size = new System.Drawing.Size(442, 139);
            this.pnlUrunler.TabIndex = 2;
            // 
            // reportViewer2
            // 
            this.reportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource7.Name = "DataSet1";
            reportDataSource7.Value = this.urunlerBindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource7);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "uretimPlanlamaProgrami.Report2.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(0, 0);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.Size = new System.Drawing.Size(442, 139);
            this.reportViewer2.TabIndex = 0;
            this.reportViewer2.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.FullPage;
            // 
            // urunlerTableAdapter
            // 
            this.urunlerTableAdapter.ClearBeforeFill = true;
            // 
            // siparisTableAdapter
            // 
            this.siparisTableAdapter.ClearBeforeFill = true;
            // 
            // pnlUretimHatlari
            // 
            this.pnlUretimHatlari.Controls.Add(this.reportViewer3);
            this.pnlUretimHatlari.Location = new System.Drawing.Point(12, 157);
            this.pnlUretimHatlari.Name = "pnlUretimHatlari";
            this.pnlUretimHatlari.Size = new System.Drawing.Size(299, 236);
            this.pnlUretimHatlari.TabIndex = 3;
            // 
            // reportViewer3
            // 
            this.reportViewer3.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource8.Name = "DataSet1";
            reportDataSource8.Value = this.uretimHattiBindingSource;
            this.reportViewer3.LocalReport.DataSources.Add(reportDataSource8);
            this.reportViewer3.LocalReport.ReportEmbeddedResource = "uretimPlanlamaProgrami.Report3.rdlc";
            this.reportViewer3.Location = new System.Drawing.Point(0, 0);
            this.reportViewer3.Name = "reportViewer3";
            this.reportViewer3.Size = new System.Drawing.Size(299, 236);
            this.reportViewer3.TabIndex = 0;
            // 
            // uretimHattiTableAdapter
            // 
            this.uretimHattiTableAdapter.ClearBeforeFill = true;
            // 
            // pnlRenkler
            // 
            this.pnlRenkler.Controls.Add(this.reportViewer4);
            this.pnlRenkler.Location = new System.Drawing.Point(368, 171);
            this.pnlRenkler.Name = "pnlRenkler";
            this.pnlRenkler.Size = new System.Drawing.Size(459, 194);
            this.pnlRenkler.TabIndex = 4;
            // 
            // reportViewer4
            // 
            this.reportViewer4.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource9.Name = "DataSet1";
            reportDataSource9.Value = this.renklerBindingSource;
            this.reportViewer4.LocalReport.DataSources.Add(reportDataSource9);
            this.reportViewer4.LocalReport.ReportEmbeddedResource = "uretimPlanlamaProgrami.Report4.rdlc";
            this.reportViewer4.Location = new System.Drawing.Point(0, 0);
            this.reportViewer4.Name = "reportViewer4";
            this.reportViewer4.Size = new System.Drawing.Size(459, 194);
            this.reportViewer4.TabIndex = 0;
            // 
            // renklerBindingSource
            // 
            this.renklerBindingSource.DataMember = "renkler";
            this.renklerBindingSource.DataSource = this.genelDataSet;
            // 
            // renklerTableAdapter
            // 
            this.renklerTableAdapter.ClearBeforeFill = true;
            // 
            // pnlHammadde
            // 
            this.pnlHammadde.Controls.Add(this.reportViewer5);
            this.pnlHammadde.Location = new System.Drawing.Point(883, 24);
            this.pnlHammadde.Name = "pnlHammadde";
            this.pnlHammadde.Size = new System.Drawing.Size(270, 237);
            this.pnlHammadde.TabIndex = 5;
            // 
            // reportViewer5
            // 
            this.reportViewer5.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource10.Name = "DataSet1";
            reportDataSource10.Value = this.hammaddeBindingSource;
            this.reportViewer5.LocalReport.DataSources.Add(reportDataSource10);
            this.reportViewer5.LocalReport.ReportEmbeddedResource = "uretimPlanlamaProgrami.Report5.rdlc";
            this.reportViewer5.Location = new System.Drawing.Point(0, 0);
            this.reportViewer5.Name = "reportViewer5";
            this.reportViewer5.Size = new System.Drawing.Size(270, 237);
            this.reportViewer5.TabIndex = 0;
            // 
            // hammaddeBindingSource
            // 
            this.hammaddeBindingSource.DataMember = "hammadde";
            this.hammaddeBindingSource.DataSource = this.genelDataSet;
            // 
            // hammaddeTableAdapter
            // 
            this.hammaddeTableAdapter.ClearBeforeFill = true;
            // 
            // frmRAPORLAR
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1684, 547);
            this.Controls.Add(this.pnlHammadde);
            this.Controls.Add(this.pnlRenkler);
            this.Controls.Add(this.pnlUretimHatlari);
            this.Controls.Add(this.pnlUrunler);
            this.Controls.Add(this.pnlSİparis);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmRAPORLAR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmGunlukRapor";
            this.Load += new System.EventHandler(this.frmGunlukRapor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.urunlerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.genelDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.siparisBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uretimHattiBindingSource)).EndInit();
            this.pnlSİparis.ResumeLayout(false);
            this.pnlSİparis.PerformLayout();
            this.pnlUrunler.ResumeLayout(false);
            this.pnlUretimHatlari.ResumeLayout(false);
            this.pnlRenkler.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.renklerBindingSource)).EndInit();
            this.pnlHammadde.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hammaddeBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private genelDataSet genelDataSet;
        private System.Windows.Forms.Panel pnlSİparis;
        private System.Windows.Forms.Panel pnlUrunler;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private System.Windows.Forms.BindingSource urunlerBindingSource;
        private genelDataSetTableAdapters.urunlerTableAdapter urunlerTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource siparisBindingSource;
        private genelDataSetTableAdapters.siparisTableAdapter siparisTableAdapter;
        private System.Windows.Forms.Panel pnlUretimHatlari;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer3;
        private System.Windows.Forms.BindingSource uretimHattiBindingSource;
        private genelDataSetTableAdapters.uretimHattiTableAdapter uretimHattiTableAdapter;
        private System.Windows.Forms.Panel pnlRenkler;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer4;
        private System.Windows.Forms.BindingSource renklerBindingSource;
        private genelDataSetTableAdapters.renklerTableAdapter renklerTableAdapter;
        private System.Windows.Forms.Panel pnlHammadde;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer5;
        private System.Windows.Forms.BindingSource hammaddeBindingSource;
        private genelDataSetTableAdapters.hammaddeTableAdapter hammaddeTableAdapter;



    }
}