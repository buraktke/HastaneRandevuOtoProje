namespace HastaneOtomasyonProjesi
{
    partial class FrmDoktorDetayPaneli
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDoktorDetayPaneli));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelTcKimlikNo = new System.Windows.Forms.Label();
            this.labelDoktorAdSoyad = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxRandevuTurleri = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.buttonTarihAralıgı = new System.Windows.Forms.Button();
            this.dateTimePickerBitis = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.dateTimePickerBaslangic = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonDuyurular = new System.Windows.Forms.Button();
            this.buttonBilgiDuzenle = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.richTextBoxHastaSikayet = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonHastaDetay = new System.Windows.Forms.Button();
            this.buttonTahlilEkle = new System.Windows.Forms.Button();
            this.buttonTeshisEkle = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button7);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1460, 48);
            this.panel1.TabIndex = 1;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Location = new System.Drawing.Point(1322, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 40);
            this.button2.TabIndex = 13;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Transparent;
            this.button7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button7.BackgroundImage")));
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button7.Location = new System.Drawing.Point(1368, 3);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(40, 40);
            this.button7.TabIndex = 7;
            this.button7.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(1414, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 40);
            this.button1.TabIndex = 6;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelTcKimlikNo);
            this.groupBox1.Controls.Add(this.labelDoktorAdSoyad);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(5, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(443, 142);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Profil";
            // 
            // labelTcKimlikNo
            // 
            this.labelTcKimlikNo.AutoSize = true;
            this.labelTcKimlikNo.Location = new System.Drawing.Point(159, 87);
            this.labelTcKimlikNo.Name = "labelTcKimlikNo";
            this.labelTcKimlikNo.Size = new System.Drawing.Size(120, 24);
            this.labelTcKimlikNo.TabIndex = 3;
            this.labelTcKimlikNo.Text = "00000000000";
            // 
            // labelDoktorAdSoyad
            // 
            this.labelDoktorAdSoyad.AutoSize = true;
            this.labelDoktorAdSoyad.Location = new System.Drawing.Point(159, 38);
            this.labelDoktorAdSoyad.Name = "labelDoktorAdSoyad";
            this.labelDoktorAdSoyad.Size = new System.Drawing.Size(81, 24);
            this.labelDoktorAdSoyad.TabIndex = 2;
            this.labelDoktorAdSoyad.Text = "Null Null";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 24);
            this.label3.TabIndex = 1;
            this.label3.Text = "TC Kimlik No :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ad-Soyad :";
            // 
            // comboBoxRandevuTurleri
            // 
            this.comboBoxRandevuTurleri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRandevuTurleri.FormattingEnabled = true;
            this.comboBoxRandevuTurleri.Items.AddRange(new object[] {
            "Geçmiş Randevular",
            "Aktif Randevular"});
            this.comboBoxRandevuTurleri.Location = new System.Drawing.Point(784, 101);
            this.comboBoxRandevuTurleri.Name = "comboBoxRandevuTurleri";
            this.comboBoxRandevuTurleri.Size = new System.Drawing.Size(204, 32);
            this.comboBoxRandevuTurleri.TabIndex = 3;
            this.comboBoxRandevuTurleri.SelectedIndexChanged += new System.EventHandler(this.comboBoxRandevuTurleri_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(780, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 24);
            this.label4.TabIndex = 4;
            this.label4.Text = "Randevu Türü";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.comboBoxRandevuTurleri);
            this.groupBox2.Location = new System.Drawing.Point(454, 54);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(994, 781);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Randevu Takip";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.buttonTarihAralıgı);
            this.groupBox5.Controls.Add(this.dateTimePickerBitis);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.dateTimePickerBaslangic);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Location = new System.Drawing.Point(26, 50);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(675, 83);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Tarih Aralığı Seçiniz";
            // 
            // buttonTarihAralıgı
            // 
            this.buttonTarihAralıgı.Location = new System.Drawing.Point(513, 36);
            this.buttonTarihAralıgı.Name = "buttonTarihAralıgı";
            this.buttonTarihAralıgı.Size = new System.Drawing.Size(109, 37);
            this.buttonTarihAralıgı.TabIndex = 8;
            this.buttonTarihAralıgı.Text = "Seç";
            this.buttonTarihAralıgı.UseVisualStyleBackColor = true;
            this.buttonTarihAralıgı.Click += new System.EventHandler(this.buttonTarihAralıgı_Click);
            // 
            // dateTimePickerBitis
            // 
            this.dateTimePickerBitis.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerBitis.Location = new System.Drawing.Point(357, 40);
            this.dateTimePickerBitis.Name = "dateTimePickerBitis";
            this.dateTimePickerBitis.Size = new System.Drawing.Size(128, 29);
            this.dateTimePickerBitis.TabIndex = 5;
            this.dateTimePickerBitis.ValueChanged += new System.EventHandler(this.dateTimePickerBitis_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(280, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 24);
            this.label9.TabIndex = 7;
            this.label9.Text = "Hedef :";
            // 
            // dateTimePickerBaslangic
            // 
            this.dateTimePickerBaslangic.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerBaslangic.Location = new System.Drawing.Point(129, 40);
            this.dateTimePickerBaslangic.Name = "dateTimePickerBaslangic";
            this.dateTimePickerBaslangic.Size = new System.Drawing.Size(128, 29);
            this.dateTimePickerBaslangic.TabIndex = 4;
            this.dateTimePickerBaslangic.ValueChanged += new System.EventHandler(this.dateTimePickerBaslangic_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 24);
            this.label8.TabIndex = 6;
            this.label8.Text = "Başlangıç :";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(26, 139);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(962, 626);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonDuyurular);
            this.groupBox3.Controls.Add(this.buttonBilgiDuzenle);
            this.groupBox3.Location = new System.Drawing.Point(12, 735);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(436, 100);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Hızlı Erişim";
            // 
            // buttonDuyurular
            // 
            this.buttonDuyurular.Location = new System.Drawing.Point(222, 33);
            this.buttonDuyurular.Name = "buttonDuyurular";
            this.buttonDuyurular.Size = new System.Drawing.Size(201, 51);
            this.buttonDuyurular.TabIndex = 1;
            this.buttonDuyurular.Text = "Duyurular";
            this.buttonDuyurular.UseVisualStyleBackColor = true;
            this.buttonDuyurular.Click += new System.EventHandler(this.buttonDuyurular_Click);
            // 
            // buttonBilgiDuzenle
            // 
            this.buttonBilgiDuzenle.Location = new System.Drawing.Point(13, 33);
            this.buttonBilgiDuzenle.Name = "buttonBilgiDuzenle";
            this.buttonBilgiDuzenle.Size = new System.Drawing.Size(201, 51);
            this.buttonBilgiDuzenle.TabIndex = 0;
            this.buttonBilgiDuzenle.Text = "Bilgi Düzenle";
            this.buttonBilgiDuzenle.UseVisualStyleBackColor = true;
            this.buttonBilgiDuzenle.Click += new System.EventHandler(this.buttonBilgiDuzenle_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.richTextBoxHastaSikayet);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.buttonHastaDetay);
            this.groupBox4.Controls.Add(this.buttonTahlilEkle);
            this.groupBox4.Controls.Add(this.buttonTeshisEkle);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.textBoxId);
            this.groupBox4.Location = new System.Drawing.Point(5, 202);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(443, 527);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Randevu Hareketleri";
            // 
            // richTextBoxHastaSikayet
            // 
            this.richTextBoxHastaSikayet.Location = new System.Drawing.Point(10, 332);
            this.richTextBoxHastaSikayet.Name = "richTextBoxHastaSikayet";
            this.richTextBoxHastaSikayet.Size = new System.Drawing.Size(420, 173);
            this.richTextBoxHastaSikayet.TabIndex = 6;
            this.richTextBoxHastaSikayet.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 305);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 24);
            this.label5.TabIndex = 5;
            this.label5.Text = "Hastanın Şikayeti";
            // 
            // buttonHastaDetay
            // 
            this.buttonHastaDetay.Location = new System.Drawing.Point(67, 235);
            this.buttonHastaDetay.Name = "buttonHastaDetay";
            this.buttonHastaDetay.Size = new System.Drawing.Size(300, 45);
            this.buttonHastaDetay.TabIndex = 4;
            this.buttonHastaDetay.Text = "Hasta Raporu";
            this.buttonHastaDetay.UseVisualStyleBackColor = true;
            this.buttonHastaDetay.Click += new System.EventHandler(this.buttonHastaDetay_Click);
            // 
            // buttonTahlilEkle
            // 
            this.buttonTahlilEkle.Location = new System.Drawing.Point(67, 115);
            this.buttonTahlilEkle.Name = "buttonTahlilEkle";
            this.buttonTahlilEkle.Size = new System.Drawing.Size(300, 45);
            this.buttonTahlilEkle.TabIndex = 3;
            this.buttonTahlilEkle.Text = "Tahlil Ekle/Güncelle";
            this.buttonTahlilEkle.UseVisualStyleBackColor = true;
            this.buttonTahlilEkle.Click += new System.EventHandler(this.buttonTahlilEkle_Click);
            // 
            // buttonTeshisEkle
            // 
            this.buttonTeshisEkle.Location = new System.Drawing.Point(67, 175);
            this.buttonTeshisEkle.Name = "buttonTeshisEkle";
            this.buttonTeshisEkle.Size = new System.Drawing.Size(300, 45);
            this.buttonTeshisEkle.TabIndex = 2;
            this.buttonTeshisEkle.Text = "Teşhis Ekle/Güncelle";
            this.buttonTeshisEkle.UseVisualStyleBackColor = true;
            this.buttonTeshisEkle.Click += new System.EventHandler(this.buttonTeshisEkle_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Randevu No :";
            // 
            // textBoxId
            // 
            this.textBoxId.Enabled = false;
            this.textBoxId.Location = new System.Drawing.Point(134, 55);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(163, 29);
            this.textBoxId.TabIndex = 0;
            // 
            // FrmDoktorDetayPaneli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1460, 847);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FrmDoktorDetayPaneli";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Doktor Detay Paneli";
            this.Load += new System.EventHandler(this.FrmDoktorDetayPaneli_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelTcKimlikNo;
        private System.Windows.Forms.Label labelDoktorAdSoyad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxRandevuTurleri;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button buttonBilgiDuzenle;
        private System.Windows.Forms.Button buttonDuyurular;
        private System.Windows.Forms.Button buttonTahlilEkle;
        private System.Windows.Forms.Button buttonTeshisEkle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.Button buttonHastaDetay;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.RichTextBox richTextBoxHastaSikayet;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DateTimePicker dateTimePickerBitis;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dateTimePickerBaslangic;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonTarihAralıgı;
    }
}