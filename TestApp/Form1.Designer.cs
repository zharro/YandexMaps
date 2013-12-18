namespace TestApp
{
    partial class Form1
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
            this.localeTb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ZoomNumeric = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.WidthNumeric = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.HeightNumeric = new System.Windows.Forms.NumericUpDown();
            this.downloadImageBtn = new System.Windows.Forms.Button();
            this.resultsGbox = new System.Windows.Forms.GroupBox();
            this.locationInfoTbox = new System.Windows.Forms.TextBox();
            this.countOfFoundObjectsLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.paramsGbox = new System.Windows.Forms.GroupBox();
            this.labelColorCmbbox = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.oneLocationRbtn = new System.Windows.Forms.RadioButton();
            this.locationsFromFileRbtn = new System.Windows.Forms.RadioButton();
            this.locationsFilenameTbox = new System.Windows.Forms.TextBox();
            this.selectLocationsFileBtn = new System.Windows.Forms.Button();
            this.foundObjectsInfoPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ZoomNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeightNumeric)).BeginInit();
            this.resultsGbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.paramsGbox.SuspendLayout();
            this.foundObjectsInfoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // localeTb
            // 
            this.localeTb.Location = new System.Drawing.Point(143, 45);
            this.localeTb.Name = "localeTb";
            this.localeTb.Size = new System.Drawing.Size(349, 20);
            this.localeTb.TabIndex = 2;
            this.localeTb.Text = "Москва, ул. Тверская, дом 7";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(303, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Zoom:";
            // 
            // ZoomNumeric
            // 
            this.ZoomNumeric.Location = new System.Drawing.Point(346, 19);
            this.ZoomNumeric.Maximum = new decimal(new int[] {
            17,
            0,
            0,
            0});
            this.ZoomNumeric.Name = "ZoomNumeric";
            this.ZoomNumeric.Size = new System.Drawing.Size(50, 20);
            this.ZoomNumeric.TabIndex = 4;
            this.ZoomNumeric.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Размер карты:";
            // 
            // WidthNumeric
            // 
            this.WidthNumeric.Location = new System.Drawing.Point(143, 19);
            this.WidthNumeric.Maximum = new decimal(new int[] {
            650,
            0,
            0,
            0});
            this.WidthNumeric.Name = "WidthNumeric";
            this.WidthNumeric.Size = new System.Drawing.Size(50, 20);
            this.WidthNumeric.TabIndex = 6;
            this.WidthNumeric.Value = new decimal(new int[] {
            650,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(206, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "x";
            // 
            // HeightNumeric
            // 
            this.HeightNumeric.Location = new System.Drawing.Point(224, 19);
            this.HeightNumeric.Maximum = new decimal(new int[] {
            450,
            0,
            0,
            0});
            this.HeightNumeric.Name = "HeightNumeric";
            this.HeightNumeric.Size = new System.Drawing.Size(50, 20);
            this.HeightNumeric.TabIndex = 8;
            this.HeightNumeric.Value = new decimal(new int[] {
            450,
            0,
            0,
            0});
            // 
            // downloadImageBtn
            // 
            this.downloadImageBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.downloadImageBtn.Location = new System.Drawing.Point(569, 124);
            this.downloadImageBtn.Name = "downloadImageBtn";
            this.downloadImageBtn.Size = new System.Drawing.Size(75, 23);
            this.downloadImageBtn.TabIndex = 9;
            this.downloadImageBtn.Text = "Загрузить";
            this.downloadImageBtn.UseVisualStyleBackColor = true;
            this.downloadImageBtn.Click += new System.EventHandler(this.downloadImageBtn_Click);
            // 
            // resultsGbox
            // 
            this.resultsGbox.Controls.Add(this.pictureBox1);
            this.resultsGbox.Controls.Add(this.foundObjectsInfoPanel);
            this.resultsGbox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.resultsGbox.Location = new System.Drawing.Point(0, 153);
            this.resultsGbox.Name = "resultsGbox";
            this.resultsGbox.Size = new System.Drawing.Size(656, 534);
            this.resultsGbox.TabIndex = 10;
            this.resultsGbox.TabStop = false;
            this.resultsGbox.Text = "Результаты";
            this.resultsGbox.Visible = false;
            // 
            // locationInfoTbox
            // 
            this.locationInfoTbox.Location = new System.Drawing.Point(153, 27);
            this.locationInfoTbox.Name = "locationInfoTbox";
            this.locationInfoTbox.ReadOnly = true;
            this.locationInfoTbox.Size = new System.Drawing.Size(488, 20);
            this.locationInfoTbox.TabIndex = 5;
            // 
            // countOfFoundObjectsLabel
            // 
            this.countOfFoundObjectsLabel.AutoSize = true;
            this.countOfFoundObjectsLabel.Location = new System.Drawing.Point(150, 9);
            this.countOfFoundObjectsLabel.Name = "countOfFoundObjectsLabel";
            this.countOfFoundObjectsLabel.Size = new System.Drawing.Size(0, 13);
            this.countOfFoundObjectsLabel.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Первый объект:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Всего найдено объектов:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pictureBox1.Location = new System.Drawing.Point(3, 77);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(650, 454);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // paramsGbox
            // 
            this.paramsGbox.Controls.Add(this.label1);
            this.paramsGbox.Controls.Add(this.selectLocationsFileBtn);
            this.paramsGbox.Controls.Add(this.locationsFilenameTbox);
            this.paramsGbox.Controls.Add(this.locationsFromFileRbtn);
            this.paramsGbox.Controls.Add(this.oneLocationRbtn);
            this.paramsGbox.Controls.Add(this.labelColorCmbbox);
            this.paramsGbox.Controls.Add(this.label9);
            this.paramsGbox.Controls.Add(this.label6);
            this.paramsGbox.Controls.Add(this.localeTb);
            this.paramsGbox.Controls.Add(this.label2);
            this.paramsGbox.Controls.Add(this.HeightNumeric);
            this.paramsGbox.Controls.Add(this.ZoomNumeric);
            this.paramsGbox.Controls.Add(this.label4);
            this.paramsGbox.Controls.Add(this.label3);
            this.paramsGbox.Controls.Add(this.WidthNumeric);
            this.paramsGbox.Dock = System.Windows.Forms.DockStyle.Top;
            this.paramsGbox.Location = new System.Drawing.Point(0, 0);
            this.paramsGbox.Name = "paramsGbox";
            this.paramsGbox.Size = new System.Drawing.Size(656, 118);
            this.paramsGbox.TabIndex = 11;
            this.paramsGbox.TabStop = false;
            this.paramsGbox.Text = "Параметры";
            // 
            // labelColorCmbbox
            // 
            this.labelColorCmbbox.FormattingEnabled = true;
            this.labelColorCmbbox.Items.AddRange(new object[] {
            "Зеленый",
            "Желтый",
            "Красный"});
            this.labelColorCmbbox.Location = new System.Drawing.Point(573, 45);
            this.labelColorCmbbox.Name = "labelColorCmbbox";
            this.labelColorCmbbox.Size = new System.Drawing.Size(70, 21);
            this.labelColorCmbbox.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(498, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Цвет метки:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(270, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "(адрес или координаты)";
            // 
            // oneLocationRbtn
            // 
            this.oneLocationRbtn.AutoSize = true;
            this.oneLocationRbtn.Checked = true;
            this.oneLocationRbtn.Location = new System.Drawing.Point(14, 44);
            this.oneLocationRbtn.Name = "oneLocationRbtn";
            this.oneLocationRbtn.Size = new System.Drawing.Size(99, 17);
            this.oneLocationRbtn.TabIndex = 12;
            this.oneLocationRbtn.TabStop = true;
            this.oneLocationRbtn.Text = "Одна локация:";
            this.oneLocationRbtn.UseVisualStyleBackColor = true;
            // 
            // locationsFromFileRbtn
            // 
            this.locationsFromFileRbtn.AutoSize = true;
            this.locationsFromFileRbtn.Location = new System.Drawing.Point(14, 85);
            this.locationsFromFileRbtn.Name = "locationsFromFileRbtn";
            this.locationsFromFileRbtn.Size = new System.Drawing.Size(122, 17);
            this.locationsFromFileRbtn.TabIndex = 13;
            this.locationsFromFileRbtn.Text = "Локации из файла:";
            this.locationsFromFileRbtn.UseVisualStyleBackColor = true;
            // 
            // locationsFilenameTbox
            // 
            this.locationsFilenameTbox.Location = new System.Drawing.Point(143, 85);
            this.locationsFilenameTbox.Name = "locationsFilenameTbox";
            this.locationsFilenameTbox.Size = new System.Drawing.Size(461, 20);
            this.locationsFilenameTbox.TabIndex = 14;
            // 
            // selectLocationsFileBtn
            // 
            this.selectLocationsFileBtn.Location = new System.Drawing.Point(610, 85);
            this.selectLocationsFileBtn.Name = "selectLocationsFileBtn";
            this.selectLocationsFileBtn.Size = new System.Drawing.Size(33, 23);
            this.selectLocationsFileBtn.TabIndex = 15;
            this.selectLocationsFileBtn.Text = "...";
            this.selectLocationsFileBtn.UseVisualStyleBackColor = true;
            this.selectLocationsFileBtn.Click += new System.EventHandler(this.selectLocationsFileBtn_Click);
            // 
            // foundObjectsInfoPanel
            // 
            this.foundObjectsInfoPanel.Controls.Add(this.locationInfoTbox);
            this.foundObjectsInfoPanel.Controls.Add(this.countOfFoundObjectsLabel);
            this.foundObjectsInfoPanel.Controls.Add(this.label7);
            this.foundObjectsInfoPanel.Controls.Add(this.label5);
            this.foundObjectsInfoPanel.Location = new System.Drawing.Point(3, 20);
            this.foundObjectsInfoPanel.Name = "foundObjectsInfoPanel";
            this.foundObjectsInfoPanel.Size = new System.Drawing.Size(650, 52);
            this.foundObjectsInfoPanel.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(141, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(470, 12);
            this.label1.TabIndex = 16;
            this.label1.Text = "(Формат файла: одна строка-одна локация. Формат строки: \'местоположение:0-2\', где" +
    " 0=Зел,1=Желт,2=Кр)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 687);
            this.Controls.Add(this.paramsGbox);
            this.Controls.Add(this.resultsGbox);
            this.Controls.Add(this.downloadImageBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "YandexMaps API test app";
            ((System.ComponentModel.ISupportInitialize)(this.ZoomNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeightNumeric)).EndInit();
            this.resultsGbox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.paramsGbox.ResumeLayout(false);
            this.paramsGbox.PerformLayout();
            this.foundObjectsInfoPanel.ResumeLayout(false);
            this.foundObjectsInfoPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox localeTb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown ZoomNumeric;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown WidthNumeric;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown HeightNumeric;
        private System.Windows.Forms.Button downloadImageBtn;
        private System.Windows.Forms.GroupBox resultsGbox;
        private System.Windows.Forms.GroupBox paramsGbox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label countOfFoundObjectsLabel;
        private System.Windows.Forms.TextBox locationInfoTbox;
        private System.Windows.Forms.ComboBox labelColorCmbbox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button selectLocationsFileBtn;
        private System.Windows.Forms.TextBox locationsFilenameTbox;
        private System.Windows.Forms.RadioButton locationsFromFileRbtn;
        private System.Windows.Forms.RadioButton oneLocationRbtn;
        private System.Windows.Forms.Panel foundObjectsInfoPanel;
        private System.Windows.Forms.Label label1;
    }
}

