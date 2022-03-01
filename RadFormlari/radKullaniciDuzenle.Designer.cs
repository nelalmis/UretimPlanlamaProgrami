namespace uretimPlanlamaProgrami.RadFormlari
{
    partial class radKullaniciDuzenle
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
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn1 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn2 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor1 = new Telerik.WinControls.Data.SortDescriptor();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(radKullaniciDuzenle));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSil = new Telerik.WinControls.UI.RadButton();
            this.btnDuzenle = new Telerik.WinControls.UI.RadButton();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.kullaniciBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.genelDataSet = new uretimPlanlamaProgrami.genelDataSet();
            this.kullaniciTableAdapter = new uretimPlanlamaProgrami.genelDataSetTableAdapters.kullaniciTableAdapter();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.aquaTheme1 = new Telerik.WinControls.Themes.AquaTheme();
            this.breezeTheme1 = new Telerik.WinControls.Themes.BreezeTheme();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnPnlKapat = new System.Windows.Forms.Button();
            this.txtyeniParTekrar = new Telerik.WinControls.UI.RadTextBoxControl();
            this.txtYeniPar = new Telerik.WinControls.UI.RadTextBoxControl();
            this.txtPar = new Telerik.WinControls.UI.RadTextBoxControl();
            this.txtAdd = new Telerik.WinControls.UI.RadTextBoxControl();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTur = new System.Windows.Forms.Label();
            this.lblParola = new System.Windows.Forms.Label();
            this.lblAd = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlAyrinti = new Telerik.WinControls.UI.RadCollapsiblePanel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDuzenle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kullaniciBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.genelDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtyeniParTekrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYeniPar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAdd)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAyrinti)).BeginInit();
            this.pnlAyrinti.PanelContainer.SuspendLayout();
            this.pnlAyrinti.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.groupBox1.Controls.Add(this.btnSil);
            this.groupBox1.Controls.Add(this.btnDuzenle);
            this.groupBox1.Controls.Add(this.radGridView1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(22, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(672, 248);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kullanıcı Bilgileri";
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(473, 90);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(161, 60);
            this.btnSil.TabIndex = 8;
            this.btnSil.Text = "SİL";
            this.btnSil.ThemeName = "Aqua";
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click_1);
            // 
            // btnDuzenle
            // 
            this.btnDuzenle.Location = new System.Drawing.Point(473, 25);
            this.btnDuzenle.Name = "btnDuzenle";
            this.btnDuzenle.Size = new System.Drawing.Size(161, 59);
            this.btnDuzenle.TabIndex = 8;
            this.btnDuzenle.Text = "DÜZENLE";
            this.btnDuzenle.ThemeName = "Aqua";
            this.btnDuzenle.Click += new System.EventHandler(this.btnDuzenle_Click_1);
            // 
            // radGridView1
            // 
            this.radGridView1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.radGridView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.radGridView1.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.radGridView1.ForeColor = System.Drawing.Color.Black;
            this.radGridView1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radGridView1.Location = new System.Drawing.Point(6, 25);
            // 
            // 
            // 
            this.radGridView1.MasterTemplate.AllowAddNewRow = false;
            gridViewDecimalColumn1.DataType = typeof(int);
            gridViewDecimalColumn1.EnableExpressionEditor = false;
            gridViewDecimalColumn1.FieldName = "id";
            gridViewDecimalColumn1.HeaderText = "id";
            gridViewDecimalColumn1.IsAutoGenerated = true;
            gridViewDecimalColumn1.IsVisible = false;
            gridViewDecimalColumn1.Name = "id";
            gridViewDecimalColumn1.ReadOnly = true;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "kullaniciAdi";
            gridViewTextBoxColumn1.HeaderText = "Kullanıcı Adı";
            gridViewTextBoxColumn1.IsAutoGenerated = true;
            gridViewTextBoxColumn1.Name = "kullaniciAdi";
            gridViewTextBoxColumn1.Width = 196;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "parola";
            gridViewTextBoxColumn2.HeaderText = "Parola";
            gridViewTextBoxColumn2.IsAutoGenerated = true;
            gridViewTextBoxColumn2.Name = "parola";
            gridViewTextBoxColumn2.Width = 142;
            gridViewDecimalColumn2.DataType = typeof(int);
            gridViewDecimalColumn2.EnableExpressionEditor = false;
            gridViewDecimalColumn2.FieldName = "uyeTip";
            gridViewDecimalColumn2.HeaderText = "Üye Tipi";
            gridViewDecimalColumn2.IsAutoGenerated = true;
            gridViewDecimalColumn2.Name = "uyeTip";
            gridViewDecimalColumn2.SortOrder = Telerik.WinControls.UI.RadSortOrder.Ascending;
            gridViewDecimalColumn2.Width = 87;
            this.radGridView1.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewDecimalColumn1,
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewDecimalColumn2});
            this.radGridView1.MasterTemplate.DataSource = this.kullaniciBindingSource;
            this.radGridView1.MasterTemplate.EnableFiltering = true;
            this.radGridView1.MasterTemplate.EnableGrouping = false;
            this.radGridView1.MasterTemplate.EnablePaging = true;
            this.radGridView1.MasterTemplate.PageSize = 5;
            sortDescriptor1.PropertyName = "uyeTip";
            this.radGridView1.MasterTemplate.SortDescriptors.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor1});
            this.radGridView1.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.ReadOnly = true;
            this.radGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radGridView1.Size = new System.Drawing.Size(461, 217);
            this.radGridView1.TabIndex = 7;
            this.radGridView1.Text = "radGridView1";
            this.radGridView1.ThemeName = "Aqua";
            this.radGridView1.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.radGridView1_CellClick);
            this.radGridView1.Click += new System.EventHandler(this.radGridView1_Click);
            // 
            // kullaniciBindingSource
            // 
            this.kullaniciBindingSource.DataMember = "kullanici";
            this.kullaniciBindingSource.DataSource = this.genelDataSet;
            // 
            // genelDataSet
            // 
            this.genelDataSet.DataSetName = "genelDataSet";
            this.genelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // kullaniciTableAdapter
            // 
            this.kullaniciTableAdapter.ClearBeforeFill = true;
            // 
            // radButton1
            // 
            this.radButton1.Location = new System.Drawing.Point(652, 244);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(207, 72);
            this.radButton1.TabIndex = 8;
            this.radButton1.Text = "GÜNCELLE";
            this.radButton1.ThemeName = "Breeze";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.InfoText;
            this.groupBox3.Controls.Add(this.radButton1);
            this.groupBox3.Controls.Add(this.btnPnlKapat);
            this.groupBox3.Controls.Add(this.txtyeniParTekrar);
            this.groupBox3.Controls.Add(this.txtYeniPar);
            this.groupBox3.Controls.Add(this.txtPar);
            this.groupBox3.Controls.Add(this.txtAdd);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.comboBox1);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox3.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.groupBox3.Location = new System.Drawing.Point(28, 266);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(865, 322);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Kullanıcı bilgileri";
            // 
            // btnPnlKapat
            // 
            this.btnPnlKapat.BackColor = System.Drawing.Color.White;
            this.btnPnlKapat.BackgroundImage = global::uretimPlanlamaProgrami.Properties.Resources.Kapat1;
            this.btnPnlKapat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPnlKapat.Location = new System.Drawing.Point(832, 0);
            this.btnPnlKapat.Name = "btnPnlKapat";
            this.btnPnlKapat.Size = new System.Drawing.Size(33, 33);
            this.btnPnlKapat.TabIndex = 8;
            this.btnPnlKapat.UseVisualStyleBackColor = false;
            this.btnPnlKapat.Click += new System.EventHandler(this.btnPnlKapat_Click);
            // 
            // txtyeniParTekrar
            // 
            this.txtyeniParTekrar.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.txtyeniParTekrar.Location = new System.Drawing.Point(216, 201);
            this.txtyeniParTekrar.Name = "txtyeniParTekrar";
            this.txtyeniParTekrar.NullText = "Parola tekrarı";
            this.txtyeniParTekrar.Size = new System.Drawing.Size(331, 29);
            this.txtyeniParTekrar.TabIndex = 7;
            this.txtyeniParTekrar.UseSystemPasswordChar = true;
            // 
            // txtYeniPar
            // 
            this.txtYeniPar.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.txtYeniPar.Location = new System.Drawing.Point(216, 155);
            this.txtYeniPar.Name = "txtYeniPar";
            this.txtYeniPar.NullText = "Yeni Parola";
            this.txtYeniPar.Size = new System.Drawing.Size(331, 29);
            this.txtYeniPar.TabIndex = 7;
            this.txtYeniPar.UseSystemPasswordChar = true;
            // 
            // txtPar
            // 
            this.txtPar.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.txtPar.IsReadOnly = true;
            this.txtPar.Location = new System.Drawing.Point(216, 69);
            this.txtPar.Name = "txtPar";
            this.txtPar.NullText = "Parola";
            this.txtPar.Size = new System.Drawing.Size(331, 29);
            this.txtPar.TabIndex = 7;
            this.txtPar.UseSystemPasswordChar = true;
            // 
            // txtAdd
            // 
            this.txtAdd.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.txtAdd.Location = new System.Drawing.Point(216, 34);
            this.txtAdd.Name = "txtAdd";
            this.txtAdd.NullText = "Kullanıcı adı";
            this.txtAdd.Size = new System.Drawing.Size(331, 29);
            this.txtAdd.TabIndex = 7;
            this.txtAdd.ThemeName = "Aqua";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(570, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 20);
            this.label6.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(570, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 20);
            this.label7.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(570, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 20);
            this.label8.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(92, 34);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(118, 22);
            this.label9.TabIndex = 1;
            this.label9.Text = "Kullanıcı Adı :";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Admin",
            "Normal Kullanıcı"});
            this.comboBox1.Location = new System.Drawing.Point(216, 112);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(331, 28);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.Text = "Seçiniz";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label14.Location = new System.Drawing.Point(38, 204);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(172, 22);
            this.label14.TabIndex = 1;
            this.label14.Text = "Parolayı Tekrar Gir :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.Location = new System.Drawing.Point(158, 115);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 22);
            this.label10.TabIndex = 1;
            this.label10.Text = "Tür :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label13.Location = new System.Drawing.Point(92, 162);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(113, 22);
            this.label13.TabIndex = 1;
            this.label13.Text = "Yeni Parola :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label12.Location = new System.Drawing.Point(133, 69);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 22);
            this.label12.TabIndex = 1;
            this.label12.Text = "Parola  :";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSlateGray;
            this.panel1.Controls.Add(this.lblTur);
            this.panel1.Controls.Add(this.lblParola);
            this.panel1.Controls.Add(this.lblAd);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(3, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(414, 137);
            this.panel1.TabIndex = 4;
            // 
            // lblTur
            // 
            this.lblTur.AutoSize = true;
            this.lblTur.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblTur.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTur.Location = new System.Drawing.Point(139, 74);
            this.lblTur.Name = "lblTur";
            this.lblTur.Size = new System.Drawing.Size(22, 21);
            this.lblTur.TabIndex = 2;
            this.lblTur.Text = "la";
            // 
            // lblParola
            // 
            this.lblParola.AutoSize = true;
            this.lblParola.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblParola.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblParola.Location = new System.Drawing.Point(139, 43);
            this.lblParola.Name = "lblParola";
            this.lblParola.Size = new System.Drawing.Size(22, 21);
            this.lblParola.TabIndex = 2;
            this.lblParola.Text = "la";
            // 
            // lblAd
            // 
            this.lblAd.AutoSize = true;
            this.lblAd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblAd.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblAd.Location = new System.Drawing.Point(139, 11);
            this.lblAd.Name = "lblAd";
            this.lblAd.Size = new System.Drawing.Size(22, 21);
            this.lblAd.TabIndex = 2;
            this.lblAd.Text = "la";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(15, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kullanıcı Adı :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(56, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Parola  :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(85, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 22);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tür :";
            // 
            // pnlAyrinti
            // 
            this.pnlAyrinti.Location = new System.Drawing.Point(700, 21);
            this.pnlAyrinti.Name = "pnlAyrinti";
            // 
            // pnlAyrinti.PanelContainer
            // 
            this.pnlAyrinti.PanelContainer.Controls.Add(this.panel1);
            this.pnlAyrinti.PanelContainer.Size = new System.Drawing.Size(424, 172);
            this.pnlAyrinti.Size = new System.Drawing.Size(426, 200);
            this.pnlAyrinti.TabIndex = 5;
            this.pnlAyrinti.Text = "radCollapsiblePanel1";
            // 
            // radKullaniciDuzenle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 613);
            this.Controls.Add(this.pnlAyrinti);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1134, 646);
            this.Name = "radKullaniciDuzenle";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.RootElement.MaxSize = new System.Drawing.Size(1134, 646);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kullanıcı Düzenle";
            this.ThemeName = "Breeze";
            this.Load += new System.EventHandler(this.radKullaniciDuzenle_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnSil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDuzenle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kullaniciBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.genelDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtyeniParTekrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYeniPar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAdd)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlAyrinti.PanelContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlAyrinti)).EndInit();
            this.pnlAyrinti.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Telerik.WinControls.UI.RadGridView radGridView1;
        private genelDataSet genelDataSet;
        private System.Windows.Forms.BindingSource kullaniciBindingSource;
        private genelDataSetTableAdapters.kullaniciTableAdapter kullaniciTableAdapter;
        private Telerik.WinControls.UI.RadButton btnSil;
        private Telerik.WinControls.UI.RadButton btnDuzenle;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.Themes.AquaTheme aquaTheme1;
        private Telerik.WinControls.Themes.BreezeTheme breezeTheme1;
        private System.Windows.Forms.GroupBox groupBox3;
        private Telerik.WinControls.UI.RadTextBoxControl txtyeniParTekrar;
        private Telerik.WinControls.UI.RadTextBoxControl txtYeniPar;
        private Telerik.WinControls.UI.RadTextBoxControl txtPar;
        private Telerik.WinControls.UI.RadTextBoxControl txtAdd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnPnlKapat;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTur;
        private System.Windows.Forms.Label lblParola;
        private System.Windows.Forms.Label lblAd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Telerik.WinControls.UI.RadCollapsiblePanel pnlAyrinti;
    }
}
