
namespace Diplom
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.connect = new System.Windows.Forms.Button();
            this.disconnect = new System.Windows.Forms.Button();
            this.connect_status = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.conStatusLbl = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.фотоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.базуДанныхToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.очиститьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.очиститьВсёToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.очиститьПоляToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьГистограммToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.avgLabel = new System.Windows.Forms.Label();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart4 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.avR = new System.Windows.Forms.Label();
            this.avG = new System.Windows.Forms.Label();
            this.avB = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.FilterButton = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.DeflRLabel = new System.Windows.Forms.Label();
            this.DeflGLabel = new System.Windows.Forms.Label();
            this.DeflBLabel = new System.Windows.Forms.Label();
            this.MedRLabel = new System.Windows.Forms.Label();
            this.MedGLabel = new System.Windows.Forms.Label();
            this.MedBLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.connect_status)).BeginInit();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart4)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // connect
            // 
            this.connect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.connect.Location = new System.Drawing.Point(3, 3);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(49, 23);
            this.connect.TabIndex = 0;
            this.connect.Text = "db con";
            this.connect.UseVisualStyleBackColor = true;
            this.connect.Click += new System.EventHandler(this.connect_Click);
            // 
            // disconnect
            // 
            this.disconnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.disconnect.Location = new System.Drawing.Point(58, 3);
            this.disconnect.Name = "disconnect";
            this.disconnect.Size = new System.Drawing.Size(47, 23);
            this.disconnect.TabIndex = 1;
            this.disconnect.Text = "db dis";
            this.disconnect.UseVisualStyleBackColor = true;
            this.disconnect.Click += new System.EventHandler(this.disconnect_Click);
            // 
            // connect_status
            // 
            this.connect_status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.connect_status.BackColor = System.Drawing.Color.Red;
            this.connect_status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.connect_status.Location = new System.Drawing.Point(111, 3);
            this.connect_status.Name = "connect_status";
            this.connect_status.Size = new System.Drawing.Size(23, 23);
            this.connect_status.TabIndex = 2;
            this.connect_status.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Controls.Add(this.conStatusLbl);
            this.panel1.Controls.Add(this.connect);
            this.panel1.Controls.Add(this.connect_status);
            this.panel1.Controls.Add(this.disconnect);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 819);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1068, 32);
            this.panel1.TabIndex = 3;
            // 
            // conStatusLbl
            // 
            this.conStatusLbl.AutoSize = true;
            this.conStatusLbl.Location = new System.Drawing.Point(140, 8);
            this.conStatusLbl.Name = "conStatusLbl";
            this.conStatusLbl.Size = new System.Drawing.Size(155, 13);
            this.conStatusLbl.TabIndex = 3;
            this.conStatusLbl.Text = "Статус: нет соединения с БД";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.очиститьToolStripMenuItem,
            this.сохранитьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1068, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.фотоToolStripMenuItem,
            this.базуДанныхToolStripMenuItem});
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.открытьToolStripMenuItem.Text = "Открыть";
            // 
            // фотоToolStripMenuItem
            // 
            this.фотоToolStripMenuItem.Name = "фотоToolStripMenuItem";
            this.фотоToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.фотоToolStripMenuItem.Text = "Папку";
            this.фотоToolStripMenuItem.Click += new System.EventHandler(this.фотоToolStripMenuItem_Click);
            // 
            // базуДанныхToolStripMenuItem
            // 
            this.базуДанныхToolStripMenuItem.Name = "базуДанныхToolStripMenuItem";
            this.базуДанныхToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.базуДанныхToolStripMenuItem.Text = "Базу данных";
            this.базуДанныхToolStripMenuItem.Click += new System.EventHandler(this.базуДанныхToolStripMenuItem_Click);
            // 
            // очиститьToolStripMenuItem
            // 
            this.очиститьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.очиститьВсёToolStripMenuItem,
            this.очиститьПоляToolStripMenuItem});
            this.очиститьToolStripMenuItem.Name = "очиститьToolStripMenuItem";
            this.очиститьToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.очиститьToolStripMenuItem.Text = "Очистить";
            // 
            // очиститьВсёToolStripMenuItem
            // 
            this.очиститьВсёToolStripMenuItem.Name = "очиститьВсёToolStripMenuItem";
            this.очиститьВсёToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.очиститьВсёToolStripMenuItem.Text = "Очистить БД";
            this.очиститьВсёToolStripMenuItem.Click += new System.EventHandler(this.очиститьВсёToolStripMenuItem_Click);
            // 
            // очиститьПоляToolStripMenuItem
            // 
            this.очиститьПоляToolStripMenuItem.Name = "очиститьПоляToolStripMenuItem";
            this.очиститьПоляToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.очиститьПоляToolStripMenuItem.Text = "Очистить поля";
            this.очиститьПоляToolStripMenuItem.Click += new System.EventHandler(this.очиститьПоляToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьГистограммToolStripMenuItem,
            this.загрузитьToolStripMenuItem});
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.сохранитьToolStripMenuItem.Text = "Гистограммы";
            // 
            // сохранитьГистограммToolStripMenuItem
            // 
            this.сохранитьГистограммToolStripMenuItem.Name = "сохранитьГистограммToolStripMenuItem";
            this.сохранитьГистограммToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.сохранитьГистограммToolStripMenuItem.Text = "Сохранить";
            this.сохранитьГистограммToolStripMenuItem.Click += new System.EventHandler(this.сохранитьГистограммToolStripMenuItem_Click);
            // 
            // загрузитьToolStripMenuItem
            // 
            this.загрузитьToolStripMenuItem.Name = "загрузитьToolStripMenuItem";
            this.загрузитьToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.загрузитьToolStripMenuItem.Text = "Загрузить";
            this.загрузитьToolStripMenuItem.Click += new System.EventHandler(this.загрузитьToolStripMenuItem_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(0, 804);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1068, 15);
            this.progressBar1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Список изображений:";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(10, 178);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(243, 615);
            this.listBox1.TabIndex = 7;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(259, 61);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(410, 320);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(256, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Изображение из БД:";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(259, 387);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(410, 70);
            this.button1.TabIndex = 12;
            this.button1.Text = "Обработать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chart1
            // 
            chartArea5.AxisX.Maximum = 255D;
            chartArea5.AxisX.Minimum = 0D;
            chartArea5.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.chart1.Legends.Add(legend5);
            this.chart1.Location = new System.Drawing.Point(675, 61);
            this.chart1.Name = "chart1";
            series7.ChartArea = "ChartArea1";
            series7.Color = System.Drawing.Color.Red;
            series7.Legend = "Legend1";
            series7.Name = "R";
            this.chart1.Series.Add(series7);
            this.chart1.Size = new System.Drawing.Size(381, 195);
            this.chart1.TabIndex = 13;
            this.chart1.Text = "chart1";
            // 
            // avgLabel
            // 
            this.avgLabel.AutoSize = true;
            this.avgLabel.Location = new System.Drawing.Point(3, 11);
            this.avgLabel.Name = "avgLabel";
            this.avgLabel.Size = new System.Drawing.Size(97, 13);
            this.avgLabel.TabIndex = 14;
            this.avgLabel.Text = "Средняя яркость:";
            // 
            // chart2
            // 
            chartArea6.AxisX.Maximum = 255D;
            chartArea6.AxisX.Minimum = 0D;
            chartArea6.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.chart2.Legends.Add(legend6);
            this.chart2.Location = new System.Drawing.Point(675, 262);
            this.chart2.Name = "chart2";
            series8.ChartArea = "ChartArea1";
            series8.Color = System.Drawing.Color.Lime;
            series8.Legend = "Legend1";
            series8.Name = "G";
            this.chart2.Series.Add(series8);
            this.chart2.Size = new System.Drawing.Size(381, 195);
            this.chart2.TabIndex = 15;
            this.chart2.Text = "chart2";
            // 
            // chart3
            // 
            chartArea7.AxisX.Maximum = 255D;
            chartArea7.AxisX.Minimum = 0D;
            chartArea7.Name = "ChartArea1";
            this.chart3.ChartAreas.Add(chartArea7);
            legend7.Name = "Legend1";
            this.chart3.Legends.Add(legend7);
            this.chart3.Location = new System.Drawing.Point(675, 463);
            this.chart3.Name = "chart3";
            series9.ChartArea = "ChartArea1";
            series9.Color = System.Drawing.Color.Blue;
            series9.Legend = "Legend1";
            series9.Name = "B";
            this.chart3.Series.Add(series9);
            this.chart3.Size = new System.Drawing.Size(381, 195);
            this.chart3.TabIndex = 16;
            this.chart3.Text = "chart3";
            // 
            // chart4
            // 
            chartArea8.AxisX.Maximum = 255D;
            chartArea8.AxisX.Minimum = 0D;
            chartArea8.Name = "ChartArea1";
            this.chart4.ChartAreas.Add(chartArea8);
            legend8.Name = "Legend1";
            this.chart4.Legends.Add(legend8);
            this.chart4.Location = new System.Drawing.Point(259, 463);
            this.chart4.Name = "chart4";
            series10.ChartArea = "ChartArea1";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series10.Color = System.Drawing.Color.Red;
            series10.Legend = "Legend1";
            series10.Name = "R";
            series11.ChartArea = "ChartArea1";
            series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series11.Color = System.Drawing.Color.Lime;
            series11.Legend = "Legend1";
            series11.Name = "G";
            series12.ChartArea = "ChartArea1";
            series12.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series12.Color = System.Drawing.Color.Blue;
            series12.Legend = "Legend1";
            series12.Name = "B";
            this.chart4.Series.Add(series10);
            this.chart4.Series.Add(series11);
            this.chart4.Series.Add(series12);
            this.chart4.Size = new System.Drawing.Size(410, 195);
            this.chart4.TabIndex = 17;
            this.chart4.Text = "chart4";
            // 
            // avR
            // 
            this.avR.AutoSize = true;
            this.avR.Location = new System.Drawing.Point(6, 43);
            this.avR.Name = "avR";
            this.avR.Size = new System.Drawing.Size(64, 13);
            this.avR.TabIndex = 18;
            this.avR.Text = "Среднее R:";
            // 
            // avG
            // 
            this.avG.AutoSize = true;
            this.avG.Location = new System.Drawing.Point(146, 43);
            this.avG.Name = "avG";
            this.avG.Size = new System.Drawing.Size(64, 13);
            this.avG.TabIndex = 19;
            this.avG.Text = "Среднее G:";
            // 
            // avB
            // 
            this.avB.AutoSize = true;
            this.avB.Location = new System.Drawing.Point(275, 43);
            this.avB.Name = "avB";
            this.avB.Size = new System.Drawing.Size(63, 13);
            this.avB.TabIndex = 20;
            this.avB.Text = "Среднее B:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Controls.Add(this.FilterButton);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(10, 61);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(243, 105);
            this.panel2.TabIndex = 21;
            // 
            // FilterButton
            // 
            this.FilterButton.Location = new System.Drawing.Point(156, 62);
            this.FilterButton.Name = "FilterButton";
            this.FilterButton.Size = new System.Drawing.Size(84, 31);
            this.FilterButton.TabIndex = 2;
            this.FilterButton.Text = "Применить";
            this.FilterButton.UseVisualStyleBackColor = true;
            this.FilterButton.Click += new System.EventHandler(this.FilterButton_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(5, 35);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(235, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Фильтрация:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(672, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Гистограммы:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.MedBLabel);
            this.panel3.Controls.Add(this.MedGLabel);
            this.panel3.Controls.Add(this.MedRLabel);
            this.panel3.Controls.Add(this.DeflBLabel);
            this.panel3.Controls.Add(this.DeflGLabel);
            this.panel3.Controls.Add(this.DeflRLabel);
            this.panel3.Controls.Add(this.avgLabel);
            this.panel3.Controls.Add(this.avB);
            this.panel3.Controls.Add(this.avR);
            this.panel3.Controls.Add(this.avG);
            this.panel3.Location = new System.Drawing.Point(259, 665);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(410, 125);
            this.panel3.TabIndex = 24;
            // 
            // DeflRLabel
            // 
            this.DeflRLabel.AutoSize = true;
            this.DeflRLabel.Location = new System.Drawing.Point(6, 103);
            this.DeflRLabel.Name = "DeflRLabel";
            this.DeflRLabel.Size = new System.Drawing.Size(75, 13);
            this.DeflRLabel.TabIndex = 21;
            this.DeflRLabel.Text = "Ср.кв.откл R:";
            // 
            // DeflGLabel
            // 
            this.DeflGLabel.AutoSize = true;
            this.DeflGLabel.Location = new System.Drawing.Point(135, 103);
            this.DeflGLabel.Name = "DeflGLabel";
            this.DeflGLabel.Size = new System.Drawing.Size(75, 13);
            this.DeflGLabel.TabIndex = 22;
            this.DeflGLabel.Text = "Ср.кв.откл G:";
            // 
            // DeflBLabel
            // 
            this.DeflBLabel.AutoSize = true;
            this.DeflBLabel.Location = new System.Drawing.Point(263, 103);
            this.DeflBLabel.Name = "DeflBLabel";
            this.DeflBLabel.Size = new System.Drawing.Size(74, 13);
            this.DeflBLabel.TabIndex = 23;
            this.DeflBLabel.Text = "Ср.кв.откл B:";
            // 
            // MedRLabel
            // 
            this.MedRLabel.AutoSize = true;
            this.MedRLabel.Location = new System.Drawing.Point(6, 76);
            this.MedRLabel.Name = "MedRLabel";
            this.MedRLabel.Size = new System.Drawing.Size(66, 13);
            this.MedRLabel.TabIndex = 24;
            this.MedRLabel.Text = "Медиана R:";
            // 
            // MedGLabel
            // 
            this.MedGLabel.AutoSize = true;
            this.MedGLabel.Location = new System.Drawing.Point(144, 76);
            this.MedGLabel.Name = "MedGLabel";
            this.MedGLabel.Size = new System.Drawing.Size(66, 13);
            this.MedGLabel.TabIndex = 25;
            this.MedGLabel.Text = "Медиана G:";
            // 
            // MedBLabel
            // 
            this.MedBLabel.AutoSize = true;
            this.MedBLabel.Location = new System.Drawing.Point(271, 76);
            this.MedBLabel.Name = "MedBLabel";
            this.MedBLabel.Size = new System.Drawing.Size(65, 13);
            this.MedBLabel.TabIndex = 26;
            this.MedBLabel.Text = "Медиана B:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 851);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chart4);
            this.Controls.Add(this.chart3);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Анализ фото";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.connect_status)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart4)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button connect;
        private System.Windows.Forms.Button disconnect;
        private System.Windows.Forms.PictureBox connect_status;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem фотоToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem очиститьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem очиститьВсёToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label avgLabel;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart3;
        private System.Windows.Forms.ToolStripMenuItem базуДанныхToolStripMenuItem;
        private System.Windows.Forms.Label conStatusLbl;
        public System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ToolStripMenuItem очиститьПоляToolStripMenuItem;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart4;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьГистограммToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьToolStripMenuItem;
        public System.Windows.Forms.Label avR;
        public System.Windows.Forms.Label avG;
        public System.Windows.Forms.Label avB;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button FilterButton;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label DeflRLabel;
        private System.Windows.Forms.Label DeflBLabel;
        private System.Windows.Forms.Label DeflGLabel;
        private System.Windows.Forms.Label MedRLabel;
        private System.Windows.Forms.Label MedBLabel;
        private System.Windows.Forms.Label MedGLabel;
    }
}

