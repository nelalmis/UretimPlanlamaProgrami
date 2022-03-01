namespace uretimPlanlamaProgrami
{
    partial class frmUrunDuzenle
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kodDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hiziDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gramajDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fireMiktariDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grpEklenecekHatlar = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.listEklenecekHatlar = new System.Windows.Forms.ListBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.listHatlar = new System.Windows.Forms.ListBox();
            this.pnlDurum = new System.Windows.Forms.Panel();
            this.lblDurum = new System.Windows.Forms.Label();
            this.pnlGuncelleme = new System.Windows.Forms.Panel();
            this.btnPnlKapat = new System.Windows.Forms.Button();
            this.btnPanaldeGuncelle = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.pr = new System.Windows.Forms.PictureBox();
            this.txtFireMiktari = new System.Windows.Forms.TextBox();
            this.txtGramaj = new System.Windows.Forms.TextBox();
            this.txtUrunHiz = new System.Windows.Forms.TextBox();
            this.txtUrunKod = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblFire = new System.Windows.Forms.Label();
            this.lblGramaj = new System.Windows.Forms.Label();
            this.lblHiz = new System.Windows.Forms.Label();
            this.lblKod = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnAra = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lblUrunREsmiGor = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.grpEklenecekHatlar.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.pnlDurum.SuspendLayout();
            this.pnlGuncelleme.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pr)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Linen;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.kodDataGridViewTextBoxColumn,
            this.hiziDataGridViewTextBoxColumn,
            this.gramajDataGridViewTextBoxColumn,
            this.fireMiktariDataGridViewTextBoxColumn});
            this.dataGridView1.Location = new System.Drawing.Point(54, 84);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(563, 299);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEnter);
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // kodDataGridViewTextBoxColumn
            // 
            this.kodDataGridViewTextBoxColumn.DataPropertyName = "kod";
            this.kodDataGridViewTextBoxColumn.HeaderText = "kod";
            this.kodDataGridViewTextBoxColumn.Name = "kodDataGridViewTextBoxColumn";
            this.kodDataGridViewTextBoxColumn.ReadOnly = true;
            this.kodDataGridViewTextBoxColumn.Width = 150;
            // 
            // hiziDataGridViewTextBoxColumn
            // 
            this.hiziDataGridViewTextBoxColumn.DataPropertyName = "hizi";
            this.hiziDataGridViewTextBoxColumn.HeaderText = "hizi";
            this.hiziDataGridViewTextBoxColumn.Name = "hiziDataGridViewTextBoxColumn";
            this.hiziDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // gramajDataGridViewTextBoxColumn
            // 
            this.gramajDataGridViewTextBoxColumn.DataPropertyName = "gramaj";
            this.gramajDataGridViewTextBoxColumn.HeaderText = "gramaj";
            this.gramajDataGridViewTextBoxColumn.Name = "gramajDataGridViewTextBoxColumn";
            this.gramajDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fireMiktariDataGridViewTextBoxColumn
            // 
            this.fireMiktariDataGridViewTextBoxColumn.DataPropertyName = "fireMiktari";
            this.fireMiktariDataGridViewTextBoxColumn.HeaderText = "fireMiktari";
            this.fireMiktariDataGridViewTextBoxColumn.Name = "fireMiktariDataGridViewTextBoxColumn";
            this.fireMiktariDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(147, 11);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(273, 26);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(43, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ürün Kodu :";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Moccasin;
            this.groupBox1.Controls.Add(this.grpEklenecekHatlar);
            this.groupBox1.Controls.Add(this.pnlGuncelleme);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.pnlDurum);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.btnAra);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(32, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(920, 732);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ürünler";
            // 
            // grpEklenecekHatlar
            // 
            this.grpEklenecekHatlar.BackColor = System.Drawing.Color.White;
            this.grpEklenecekHatlar.Controls.Add(this.button3);
            this.grpEklenecekHatlar.Controls.Add(this.listEklenecekHatlar);
            this.grpEklenecekHatlar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grpEklenecekHatlar.Location = new System.Drawing.Point(623, 385);
            this.grpEklenecekHatlar.Name = "grpEklenecekHatlar";
            this.grpEklenecekHatlar.Size = new System.Drawing.Size(214, 228);
            this.grpEklenecekHatlar.TabIndex = 0;
            this.grpEklenecekHatlar.TabStop = false;
            this.grpEklenecekHatlar.Text = "ÜRETİM HATLARI EKLE";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Lime;
            this.button3.ForeColor = System.Drawing.Color.MediumBlue;
            this.button3.Location = new System.Drawing.Point(6, 195);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(192, 29);
            this.button3.TabIndex = 1;
            this.button3.Text = "Seçili Hattı Ürüne Ekle";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // listEklenecekHatlar
            // 
            this.listEklenecekHatlar.FormattingEnabled = true;
            this.listEklenecekHatlar.ItemHeight = 20;
            this.listEklenecekHatlar.Location = new System.Drawing.Point(10, 25);
            this.listEklenecekHatlar.Name = "listEklenecekHatlar";
            this.listEklenecekHatlar.Size = new System.Drawing.Size(182, 164);
            this.listEklenecekHatlar.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.White;
            this.groupBox5.Controls.Add(this.button2);
            this.groupBox5.Controls.Add(this.listHatlar);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox5.Location = new System.Drawing.Point(425, 389);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(192, 228);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "MEVCUT ÜRETİM HATLARI";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Location = new System.Drawing.Point(0, 195);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(186, 29);
            this.button2.TabIndex = 1;
            this.button2.Text = "Seçili Hattı Sil";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // listHatlar
            // 
            this.listHatlar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.listHatlar.FormattingEnabled = true;
            this.listHatlar.ItemHeight = 20;
            this.listHatlar.Location = new System.Drawing.Point(6, 25);
            this.listHatlar.Name = "listHatlar";
            this.listHatlar.Size = new System.Drawing.Size(180, 164);
            this.listHatlar.TabIndex = 0;
            // 
            // pnlDurum
            // 
            this.pnlDurum.BackColor = System.Drawing.Color.White;
            this.pnlDurum.Controls.Add(this.lblDurum);
            this.pnlDurum.Location = new System.Drawing.Point(85, 41);
            this.pnlDurum.Name = "pnlDurum";
            this.pnlDurum.Size = new System.Drawing.Size(434, 37);
            this.pnlDurum.TabIndex = 9;
            // 
            // lblDurum
            // 
            this.lblDurum.AutoSize = true;
            this.lblDurum.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDurum.Location = new System.Drawing.Point(32, 9);
            this.lblDurum.Name = "lblDurum";
            this.lblDurum.Size = new System.Drawing.Size(24, 22);
            this.lblDurum.TabIndex = 0;
            this.lblDurum.Text = "la";
            // 
            // pnlGuncelleme
            // 
            this.pnlGuncelleme.BackColor = System.Drawing.Color.Aquamarine;
            this.pnlGuncelleme.Controls.Add(this.btnPnlKapat);
            this.pnlGuncelleme.Controls.Add(this.btnPanaldeGuncelle);
            this.pnlGuncelleme.Controls.Add(this.groupBox4);
            this.pnlGuncelleme.ForeColor = System.Drawing.Color.Brown;
            this.pnlGuncelleme.Location = new System.Drawing.Point(394, 7);
            this.pnlGuncelleme.Name = "pnlGuncelleme";
            this.pnlGuncelleme.Size = new System.Drawing.Size(405, 583);
            this.pnlGuncelleme.TabIndex = 8;
            // 
            // btnPnlKapat
            // 
            this.btnPnlKapat.BackColor = System.Drawing.Color.White;
           // this.btnPnlKapat.BackgroundImage = global::uretimPlanlamaProgrami.Properties.Resources.Kapat1;
            this.btnPnlKapat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPnlKapat.Location = new System.Drawing.Point(369, 0);
            this.btnPnlKapat.Name = "btnPnlKapat";
            this.btnPnlKapat.Size = new System.Drawing.Size(33, 33);
            this.btnPnlKapat.TabIndex = 8;
            this.btnPnlKapat.UseVisualStyleBackColor = false;
            this.btnPnlKapat.Click += new System.EventHandler(this.btnPnlKapat_Click);
            // 
            // btnPanaldeGuncelle
            // 
            this.btnPanaldeGuncelle.BackColor = System.Drawing.Color.White;
            this.btnPanaldeGuncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
          //  this.btnPanaldeGuncelle.Image = global::uretimPlanlamaProgrami.Properties.Resources.güncelleme1;
            this.btnPanaldeGuncelle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPanaldeGuncelle.Location = new System.Drawing.Point(192, 494);
            this.btnPanaldeGuncelle.Name = "btnPanaldeGuncelle";
            this.btnPanaldeGuncelle.Size = new System.Drawing.Size(187, 78);
            this.btnPanaldeGuncelle.TabIndex = 7;
            this.btnPanaldeGuncelle.Text = "GÜNCELLE";
            this.btnPanaldeGuncelle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPanaldeGuncelle.UseVisualStyleBackColor = false;
            this.btnPanaldeGuncelle.Click += new System.EventHandler(this.btnPanaldeGuncelle_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox4.Controls.Add(this.button4);
            this.groupBox4.Controls.Add(this.pr);
            this.groupBox4.Controls.Add(this.txtFireMiktari);
            this.groupBox4.Controls.Add(this.txtGramaj);
            this.groupBox4.Controls.Add(this.txtUrunHiz);
            this.groupBox4.Controls.Add(this.txtUrunKod);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox4.Location = new System.Drawing.Point(13, 27);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(359, 461);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Ürün Güncelle";
            // 
            // button4
            // 
            this.button4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button4.Location = new System.Drawing.Point(122, 174);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(211, 27);
            this.button4.TabIndex = 3;
            this.button4.Text = "Resim Seç";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // pr
            // 
            this.pr.Location = new System.Drawing.Point(122, 207);
            this.pr.Name = "pr";
            this.pr.Size = new System.Drawing.Size(211, 241);
            this.pr.TabIndex = 2;
            this.pr.TabStop = false;
            // 
            // txtFireMiktari
            // 
            this.txtFireMiktari.Location = new System.Drawing.Point(122, 131);
            this.txtFireMiktari.Name = "txtFireMiktari";
            this.txtFireMiktari.Size = new System.Drawing.Size(211, 27);
            this.txtFireMiktari.TabIndex = 1;
            // 
            // txtGramaj
            // 
            this.txtGramaj.Location = new System.Drawing.Point(122, 100);
            this.txtGramaj.Name = "txtGramaj";
            this.txtGramaj.Size = new System.Drawing.Size(211, 27);
            this.txtGramaj.TabIndex = 1;
            // 
            // txtUrunHiz
            // 
            this.txtUrunHiz.Location = new System.Drawing.Point(122, 69);
            this.txtUrunHiz.Name = "txtUrunHiz";
            this.txtUrunHiz.Size = new System.Drawing.Size(211, 27);
            this.txtUrunHiz.TabIndex = 1;
            // 
            // txtUrunKod
            // 
            this.txtUrunKod.Location = new System.Drawing.Point(122, 35);
            this.txtUrunKod.Name = "txtUrunKod";
            this.txtUrunKod.Size = new System.Drawing.Size(211, 27);
            this.txtUrunKod.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(9, 180);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 18);
            this.label6.TabIndex = 0;
            this.label6.Text = "Ürün Resmi :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(13, 135);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 18);
            this.label10.TabIndex = 0;
            this.label10.Text = "Fire Miktarı :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(43, 104);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 18);
            this.label11.TabIndex = 0;
            this.label11.Text = "Gramaj :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(28, 73);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(88, 18);
            this.label12.TabIndex = 0;
            this.label12.Text = "Ürün Hızı :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(18, 39);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(98, 18);
            this.label13.TabIndex = 0;
            this.label13.Text = "Ürün Kodu :";
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.BackColor = System.Drawing.Color.LightBlue;
            this.groupBox2.Controls.Add(this.lblUrunREsmiGor);
            this.groupBox2.Controls.Add(this.lblFire);
            this.groupBox2.Controls.Add(this.lblGramaj);
            this.groupBox2.Controls.Add(this.lblHiz);
            this.groupBox2.Controls.Add(this.lblKod);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox2.Location = new System.Drawing.Point(60, 389);
            this.groupBox2.MaximumSize = new System.Drawing.Size(359, 500);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(359, 234);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ayrıntılar";
            // 
            // lblFire
            // 
            this.lblFire.AutoSize = true;
            this.lblFire.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblFire.ForeColor = System.Drawing.Color.Navy;
            this.lblFire.Location = new System.Drawing.Point(136, 149);
            this.lblFire.Name = "lblFire";
            this.lblFire.Size = new System.Drawing.Size(24, 22);
            this.lblFire.TabIndex = 1;
            this.lblFire.Text = "la";
            // 
            // lblGramaj
            // 
            this.lblGramaj.AutoSize = true;
            this.lblGramaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblGramaj.ForeColor = System.Drawing.Color.Navy;
            this.lblGramaj.Location = new System.Drawing.Point(136, 118);
            this.lblGramaj.Name = "lblGramaj";
            this.lblGramaj.Size = new System.Drawing.Size(24, 22);
            this.lblGramaj.TabIndex = 1;
            this.lblGramaj.Text = "la";
            // 
            // lblHiz
            // 
            this.lblHiz.AutoSize = true;
            this.lblHiz.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblHiz.ForeColor = System.Drawing.Color.Navy;
            this.lblHiz.Location = new System.Drawing.Point(136, 91);
            this.lblHiz.Name = "lblHiz";
            this.lblHiz.Size = new System.Drawing.Size(24, 22);
            this.lblHiz.TabIndex = 1;
            this.lblHiz.Text = "la";
            // 
            // lblKod
            // 
            this.lblKod.AutoSize = true;
            this.lblKod.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKod.ForeColor = System.Drawing.Color.Navy;
            this.lblKod.Location = new System.Drawing.Point(136, 56);
            this.lblKod.Name = "lblKod";
            this.lblKod.Size = new System.Drawing.Size(24, 22);
            this.lblKod.TabIndex = 1;
            this.lblKod.Text = "la";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(27, 180);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 18);
            this.label7.TabIndex = 0;
            this.label7.Text = "Ürün Resmi";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(27, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 18);
            this.label5.TabIndex = 0;
            this.label5.Text = "Fire Miktarı :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(57, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "Gramaj :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(42, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ürün Hızı :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(32, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ürün Kodu :";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Lime;
            this.groupBox3.Controls.Add(this.btnSil);
            this.groupBox3.Controls.Add(this.btnGuncelle);
            this.groupBox3.Location = new System.Drawing.Point(629, 130);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(198, 204);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "İŞLEMLER";
            // 
            // btnSil
            // 
            this.btnSil.BackColor = System.Drawing.Color.White;
            this.btnSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
           // this.btnSil.Image = global::uretimPlanlamaProgrami.Properties.Resources.delete;
            this.btnSil.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnSil.Location = new System.Drawing.Point(6, 103);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(186, 78);
            this.btnSil.TabIndex = 5;
            this.btnSil.Text = "           SİL";
            this.btnSil.UseVisualStyleBackColor = false;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.BackColor = System.Drawing.Color.White;
            this.btnGuncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
          ///  this.btnGuncelle.Image = global::uretimPlanlamaProgrami.Properties.Resources.güncelleme1;
            this.btnGuncelle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuncelle.Location = new System.Drawing.Point(6, 19);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(186, 78);
            this.btnGuncelle.TabIndex = 5;
            this.btnGuncelle.Text = "DÜZENLE";
            this.btnGuncelle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuncelle.UseVisualStyleBackColor = false;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnAra
            // 
            this.btnAra.BackColor = System.Drawing.Color.White;
            this.btnAra.Image = global::uretimPlanlamaProgrami.Properties.Resources.Bul;
            this.btnAra.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAra.Location = new System.Drawing.Point(426, 7);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(93, 30);
            this.btnAra.TabIndex = 2;
            this.btnAra.Text = "    Ara";
            this.btnAra.UseVisualStyleBackColor = false;
            this.btnAra.Click += new System.EventHandler(this.btnAra_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
           // this.button1.Image = global::uretimPlanlamaProgrami.Properties.Resources.yenileme;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(946, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 92);
            this.button1.TabIndex = 4;
            this.button1.Text = "Sayfayı Yenile";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lblUrunREsmiGor
            // 
            this.lblUrunREsmiGor.AutoSize = true;
            this.lblUrunREsmiGor.Location = new System.Drawing.Point(130, 180);
            this.lblUrunREsmiGor.Name = "lblUrunREsmiGor";
            this.lblUrunREsmiGor.Size = new System.Drawing.Size(187, 26);
            this.lblUrunREsmiGor.TabIndex = 2;
            this.lblUrunREsmiGor.TabStop = true;
            this.lblUrunREsmiGor.Text = "Ürün Resmini Gör";
            this.lblUrunREsmiGor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblUrunREsmiGor_LinkClicked);
            // 
            // frmUrunDuzenle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Brown;
            this.ClientSize = new System.Drawing.Size(1084, 816);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1100, 900);
            this.Name = "frmUrunDuzenle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmUrunDuzenle";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmUrunDuzenle_FormClosed);
            this.Load += new System.EventHandler(this.frmUrunDuzenle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpEklenecekHatlar.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.pnlDurum.ResumeLayout(false);
            this.pnlDurum.PerformLayout();
            this.pnlGuncelleme.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pr)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnAra;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblFire;
        private System.Windows.Forms.Label lblGramaj;
        private System.Windows.Forms.Label lblHiz;
        private System.Windows.Forms.Label lblKod;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel pnlGuncelleme;
        private System.Windows.Forms.Button btnPnlKapat;
        private System.Windows.Forms.Button btnPanaldeGuncelle;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtFireMiktari;
        private System.Windows.Forms.TextBox txtGramaj;
        private System.Windows.Forms.TextBox txtUrunHiz;
        private System.Windows.Forms.TextBox txtUrunKod;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel pnlDurum;
        private System.Windows.Forms.Label lblDurum;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kodDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hiziDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gramajDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fireMiktariDataGridViewTextBoxColumn;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ListBox listHatlar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox grpEklenecekHatlar;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox listEklenecekHatlar;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.PictureBox pr;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.LinkLabel lblUrunREsmiGor;
       
    }
}