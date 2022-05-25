using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;

namespace Diplom
{
    public partial class Form1 : Form
    {        
        public Form1()
        {
            InitializeComponent();
        }

        string progpath = AppDomain.CurrentDomain.BaseDirectory;
        string connectionString = "", path = "";
        private OleDbConnection connection;
        string[] exsamplesPath;
        double avgBrightness = 127.5;
        Bitmap selBitmap = null;
        OleDbCommand dbCommand = new OleDbCommand();
        pixelAnalyse analyse;

        private void connect_Click(object sender, EventArgs e) //Соединение с БД
        {
            if(connectionString == "")
            {
                базуДанныхToolStripMenuItem_Click(sender, e);
            }
            else
            {
                makeConnection(connectionString, connect_status);
            }            
        }
        public void makeConnection(string newconnectionString, PictureBox status)
        {
            try
            {
                connection = new OleDbConnection(newconnectionString);
                connection.Open();
                connectionString = newconnectionString;
                status.BackColor = Color.Green;
                conStatusLbl.Text = "Соединено с:" + connectionString;
                fillFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
                connection = null;
                status.BackColor = Color.Red;
                return;
            }            
        }

        public void clearForms()
        {
            chart1.Series[0].Points.Clear();
            chart2.Series[0].Points.Clear();
            chart3.Series[0].Points.Clear();
            chart4.Series[0].Points.Clear();
            comboBox1.Items.Clear();

            pictureBox2.Image = null;
            progressBar1.Value = 0;
            avgLabel.Text = "Средняя яркость:";
            DeflRLabel.Text = "Ср.кв.откл R:";
            DeflGLabel.Text = "Ср.кв.откл G:";
            DeflBLabel.Text = "Ср.кв.откл B:";

            MedRLabel.Text = "Медиана R:";
            MedGLabel.Text = "Медиана G:";
            MedBLabel.Text = "Медиана B:";            
        }

        int GetId(string path)
        {
            string query = "SELECT ID FROM Exsamples WHERE Path='" + path + "'";
            dbCommand = new OleDbCommand(query, connection);
            dbCommand.ExecuteNonQuery();

            OleDbDataReader reader = dbCommand.ExecuteReader();
            reader.Read();
            int id = (int)reader["ID"];
            reader.Close();
            return id;            
        }

        public void ScanFile(string path, string diagnose)
        {
            Bitmap image;
            try
            {
                image = new Bitmap(path);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\nВозможно неподдерживаемое разрешение: " + Path.GetExtension(path), "Ошибка при представлении изображения");
                return;
            }

            var dn = Path.GetDirectoryName(path);
            dn = dn.Substring(dn.LastIndexOf('\\') + 1); //Имя последней папки

            string query = "INSERT INTO Exsamples (Path, Diagnose) VALUES ('" + Path.Combine(dn, Path.GetFileName(path)) + "', '" + diagnose + "')";
            dbCommand = new OleDbCommand(query, connection);
            dbCommand.ExecuteNonQuery();            

            string varPos = "";
            string varRGB = "";

            try
            {
                for (int i = 0; i < image.Width; ++i)
                {
                    for (int j = 0; j < image.Height; ++j)
                    {
                        if (image.GetPixel(i, j).R == 255 && image.GetPixel(i, j).G == 255 && image.GetPixel(i, j).B == 255)
                        {
                            continue;
                        }
                        else
                        {
                            //addData(image.GetPixel(i, j).R, image.GetPixel(i, j).G, image.GetPixel(i, j).B, Path.Combine(dn, Path.GetFileName(path)), diagnose, i, j);
                            varPos += i + ":" + j + ":";
                            varRGB += image.GetPixel(i, j).R + ":" + image.GetPixel(i, j).G + ":" + image.GetPixel(i, j).B + ":";
                        }
                    }
                }
                varPos = varPos.Substring(0, varPos.Length - 1);
                varRGB = varRGB.Substring(0, varRGB.Length - 1);
                addData(varPos, varRGB, GetId(Path.Combine(dn, Path.GetFileName(path))));
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Встречен сложный запрос: " + ex.Message);
                Debug.WriteLine("Встречен сложный запрос: " + ex.Message);
                query = "DELETE FROM Exsamples WHERE Path='" + Path.Combine(dn, Path.GetFileName(path)) + "'";
                dbCommand = new OleDbCommand(query, connection);
                dbCommand.ExecuteNonQuery();
            }
        }

        //void addData(byte R, byte G, byte B, string path, string diagnose, int x, int y) //Заполнение информации о пикселях изображений
        void addData(string Pos, string RGB, int id) //Заполнение информации о пикселях изображений
        {
            /*string query = "INSERT INTO Spot_info (ID_photo, X_point, Y_point, R, G, B) "
                + "VALUES ('" + path + "', " + x + ", " + y + ", " + R + ", " + G + ", " + B + ")";*/
            string query = "INSERT INTO Spot_info (ID_photo, PosXY, RGB) "
                + "VALUES ('" + id + "', '" + Pos + "', '" + RGB + "')";
            dbCommand = new OleDbCommand(query, connection);
            dbCommand.ExecuteNonQuery();
        }

        bool checkPath(string path) //True - есть запись, False - нет
        {
            string query = "SELECT * FROM Exsamples WHERE Path='" + path + "'";
            dbCommand = new OleDbCommand(query, connection);
            OleDbDataReader reader = dbCommand.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Close();
                return true;
            }
            else
            {
                reader.Close();
                return false;
            }
        }

        private void disconnect_Click(object sender, EventArgs e) //Сброс соединения с БД
        {
            if (connectionString == "") { return; }
            try
            {
                connection.Close();
                connect_status.BackColor = Color.Red;
                listBox1.Items.Clear();
                conStatusLbl.Text = "Статус: нет соединения с БД";
                connectionString = "";
                clearForms();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
                return;
            }           
        }

        private void fillListbox() //Формирует список имен файлов с бд
        {            
            exsamplesPath = GetPath();            
        }

        public string[] GetPath() //Заполняет листбокс именами экземпляров из бд и возвращает список имён файлов
        {
            string query = "SELECT * FROM Exsamples";
            string querycount = "SELECT count(*) as RowCount FROM Exsamples";
            OleDbCommand command = new OleDbCommand(querycount, connection);
            OleDbDataReader reader = command.ExecuteReader();
            reader.Read();
            var rowCount = (int)reader["RowCount"];

            if(comboBox1.Items.Count == 0)
            {
                comboBox1.Items.Add("Все");
                comboBox1.SelectedIndex = 0;
            }
            if(comboBox1.Text != "Все")
            {
                query += " WHERE Diagnose ='" + comboBox1.Text + "'";
            }

            command = new OleDbCommand(query, connection);
            reader = command.ExecuteReader();

            string[] ret = new string[rowCount];
            listBox1.Items.Clear();

            try
            {
                if (rowCount == 0)
                {
                    listBox1.Items.Add("База данных пуста");
                }
                else
                {
                    while (reader.Read())
                    {
                        listBox1.Items.Add('\\' + reader["Path"].ToString());
                        ret[listBox1.Items.Count-1] = '\\' + reader["Path"].ToString();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
            reader.Close();
            return ret;
        }

        private void очиститьВсёToolStripMenuItem_Click(object sender, EventArgs e) //Полное удаление данных в бд
        {
            if (connectionString == "") { return; }
            dbCommand.Connection = connection;
            try
            {
                dbCommand.CommandText = "DELETE FROM Spot_info";
                dbCommand.ExecuteNonQuery();
                dbCommand.CommandText = "DELETE FROM Exsamples";
                dbCommand.ExecuteNonQuery();
                dbCommand.CommandText = "DELETE FROM Gist_info";
                dbCommand.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
            fillListbox();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) //клик по листбоксу
        {
            //MessageBox.Show(progpath.ToString() + listBox1.Items[listBox1.SelectedIndex].ToString(), "Уведомление");
            try 
            {
                string newpath = listBox1.Items[listBox1.SelectedIndex].ToString().Substring(1);

                int id = GetId(newpath);

                string query = "SELECT * FROM Spot_info WHERE ID_photo=" + id;
                dbCommand = new OleDbCommand(query, connection);
                OleDbDataReader reader = dbCommand.ExecuteReader();

                analyse = new pixelAnalyse(progressBar1); //очистка

                reader.Read();                
                
                    //analyse.setInfo(new Point((int)reader["X_point"], (int)reader["Y_point"]), Color.FromArgb(255, (int)reader["R"], (int)reader["G"], (int)reader["B"]));
                    string[] tempImg = (reader["RGB"]).ToString().Split(':');
                    string[] tempPos = (reader["PosXY"]).ToString().Split(':');
                    int countPos = 0, countClr = 0;

                    while (countPos != tempPos.Length)
                    {
                        Color clr = Color.FromArgb(255, Convert.ToInt32(tempImg[countClr]), Convert.ToInt32(tempImg[countClr + 1]), Convert.ToInt32(tempImg[countClr + 2]));
                        Point point = new Point(Convert.ToInt32(tempPos[countPos]), Convert.ToInt32(tempPos[countPos + 1]));
                        analyse.setInfo(point, clr);
                        countPos += 2;
                        countClr += 3;
                    }
                    reader.Close();                                 

                Bitmap fromBase = new Bitmap(analyse.getMax(true) + 1, analyse.getMax(false) + 1);

                selBitmap = analyse.getBitmapByInfo(fromBase);
                pictureBox2.Image = selBitmap;

                ReDisplayInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }            
        }

        private void fillFilter()
        {
            string query = "SELECT DISTINCT Diagnose FROM Exsamples";
            dbCommand = new OleDbCommand(query, connection);
            OleDbDataReader reader = dbCommand.ExecuteReader();

            comboBox1.Items.Add("Все");
            comboBox1.SelectedIndex = 0;

            while (reader.Read())
            {
                comboBox1.Items.Add(reader["Diagnose"]);
            }
            reader.Close();
        }

        private void базуДанныхToolStripMenuItem_Click(object sender, EventArgs e) //Открытие базы данных
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Database files (*.mdb)|*.mdb|All files (*.*)|*.*";
            if(fileDialog.ShowDialog() == DialogResult.OK)
            {
                connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + fileDialog.FileName + "'";                
                makeConnection(connectionString, connect_status);
                fillListbox();
            }
        }

        private void button1_Click(object sender, EventArgs e) //Изменить яркость
        {               
            if(analyse.data.Length == 1) { return; } //если не заполняли данными - остановка

            try
            {
                analyse.changeBrightness();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка задания новой яркости");
                return;
            }

            selBitmap = new Bitmap(analyse.getBitmapByInfo(new Bitmap(selBitmap.Width, selBitmap.Height))); //получение битмапа на основе данных из бд
            pictureBox2.Image = selBitmap;

            ReDisplayInfo();
        }

        private void ReDisplayInfo()
        {
            analyse.wR = analyse.getAvgFrequency("R"); //Заполнение массивов частот
            analyse.wG = analyse.getAvgFrequency("G");
            analyse.wB = analyse.getAvgFrequency("B");

            analyse.calcMed(); //Подсчет медианы
            analyse.calcDefl(); //Подсчет среднеквадратического отклонения

            DeflRLabel.Text = "Ср.кв.откл R:" + Math.Round(analyse.getSg()[0], 3);
            DeflGLabel.Text = "Ср.кв.откл G:" + Math.Round(analyse.getSg()[1], 3);
            DeflBLabel.Text = "Ср.кв.откл B:" + Math.Round(analyse.getSg()[2], 3);

            MedRLabel.Text = "Медиана R:" + Math.Round(analyse.getMed()[0], 3);
            MedGLabel.Text = "Медиана G:" + Math.Round(analyse.getMed()[1], 3);
            MedBLabel.Text = "Медиана B:" + Math.Round(analyse.getMed()[2], 3);

            avgBrightness = analyse.getAverageBrightness();
            avgLabel.Text = "Средняя яркость: " + Math.Round(avgBrightness, 3);
            avR.Text = "Среднее R: " + Math.Round(analyse.getAverageGistogramm("R"), 3);
            avG.Text = "Среднее G: " + Math.Round(analyse.getAverageGistogramm("G"), 3);
            avB.Text = "Среднее B: " + Math.Round(analyse.getAverageGistogramm("B"), 3);

            analyse.setRGB(chart1, chart2, chart3, chart4);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            analyse = new pixelAnalyse(progressBar1);

            chart1.ChartAreas[0].CursorX.IsUserEnabled = true;
            chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart1.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;

            chart2.ChartAreas[0].CursorX.IsUserEnabled = true;
            chart2.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chart2.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart2.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;

            chart3.ChartAreas[0].CursorX.IsUserEnabled = true;
            chart3.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chart3.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart3.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;

            chart4.ChartAreas[0].CursorX.IsUserEnabled = true;
            chart4.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chart4.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart4.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;            
        }

        private void очиститьПоляToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearForms();
        }

        private void сохранитьГистограммToolStripMenuItem_Click(object sender, EventArgs e) //Сохранить данные гистограммы в БД
        {
            if(analyse.data.Length == 1) { return; }
            string path = listBox1.SelectedItem.ToString().Substring(1);
            int id = GetId(path);

            string query = "SELECT COUNT(*) AS num FROM Gist_info WHERE ID_photo=" + id;
            dbCommand = new OleDbCommand(query, connection);
            OleDbDataReader reader = dbCommand.ExecuteReader();

            string imgData = "";
            string posData = "";
            for (int i = 0; i < analyse.data.Length-1; ++i)
            {
                imgData += analyse.data[i].getColor().R + ":" + analyse.data[i].getColor().G + ":" + analyse.data[i].getColor().B + ":";
                posData += analyse.data[i].getPoint().X + ":" + analyse.data[i].getPoint().Y + ":";
            }
            imgData = imgData.Substring(0, imgData.Length - 1); //Удалить : в конце
            posData = posData.Substring(0, posData.Length - 1); //Удалить : в конце

            dbCommand = new OleDbCommand(query, connection);
            dbCommand.ExecuteNonQuery();

            string avRGB = Math.Round(analyse.getAverageGistogramm("R"), 3) + ":" + Math.Round(analyse.getAverageGistogramm("G"), 3) + ":" + Math.Round(analyse.getAverageGistogramm("B"), 3);
            string MedRGB = Math.Round(analyse.getMed()[0], 3) + ":" + Math.Round(analyse.getMed()[1], 3) + ":" + Math.Round(analyse.getMed()[2], 3);
            string SgRGB = Math.Round(analyse.getSg()[0], 3) + ":" + Math.Round(analyse.getSg()[1], 3) + ":" + Math.Round(analyse.getSg()[2], 3);
            
            reader.Read();
            if ((int)reader["num"] != 0) //Если есть запись
            {
                query = "UPDATE Gist_info SET AllBright='" + Math.Round(analyse.getAvgBrightness(), 3) + "', BrightRGB = '"+ avRGB + "', " +
                     "Img='" + imgData + "', Pos='" + posData +"', MedRGB='" + MedRGB + "', SgRGB='"+SgRGB+ "' WHERE ID_photo=" + id + "";
            }
            else
            {
                query = "INSERT INTO Gist_info (ID_photo, AllBright, BrightRGB, Img, Pos, MedRGB, SgRGB) "
               + "VALUES (" + id + ", '" + Math.Round(analyse.getAvgBrightness(), 3) + "', '" + avRGB + "', '" + imgData + "', '" + posData + "', " +
               "'" + MedRGB + "', '" + SgRGB + "')";
            }
            reader.Close();

            try
            {
                dbCommand = new OleDbCommand(query, connection);
                dbCommand.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка сохранения исследования");
                return;
            }
        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e) //Загрузить данные гистограммы из БД
        {
            int id = GetId(listBox1.SelectedItem.ToString().Substring(1));
            string query = @"SELECT * FROM Gist_info WHERE ID_photo =" + id;
            dbCommand = new OleDbCommand(query, connection);
            OleDbDataReader reader = dbCommand.ExecuteReader();

            if (!reader.HasRows)
            {
                MessageBox.Show("В БД нет информации о гистограммах к этому изображению", "Ошибка");
                return;
            }

            reader.Read();
            analyse = new pixelAnalyse(progressBar1); //Очистка и после установка всего нового
            analyse.setAvgBrightness(Convert.ToDouble(reader["AllBright"].ToString()));

            string[] tempImg = (reader["Img"]).ToString().Split(':');
            string[] tempPos = (reader["Pos"]).ToString().Split(':');

            int countPos = 0, countClr = 0;

            while (countPos != tempPos.Length)
            { 
                Color clr = Color.FromArgb(255, Convert.ToInt32(tempImg[countClr]), Convert.ToInt32(tempImg[countClr + 1]), Convert.ToInt32(tempImg[countClr + 2]));
                Point point = new Point(Convert.ToInt32(tempPos[countPos]), Convert.ToInt32(tempPos[countPos + 1]));
                analyse.setInfo(point, clr);
                countPos += 2;
                countClr += 3;
            }
            reader.Close();

            selBitmap = new Bitmap(analyse.getBitmapByInfo(new Bitmap(selBitmap.Width, selBitmap.Height))); //получение битмапа на основе данных из бд
            pictureBox2.Image = selBitmap;

            ReDisplayInfo();         
        }

        private void FilterButton_Click(object sender, EventArgs e) //Применить параметры фильтрации
        {
            if (connectionString == "") { return; }
            fillListbox();
        }

        private void фотоToolStripMenuItem_Click(object sender, EventArgs e) //Загрузить новые экземпляры в бд
        {
            if(connectionString == "")
            {
                MessageBox.Show("Создайте подключение к БД для дальнейшей работы", "Ошибка");
                return;
            }
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.SelectedPath = progpath.Replace("Debug\\", "Release");
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                else
                {
                    path = dialog.SelectedPath;
                }
            }

            List<string> ls = GetRecursFiles(path);
            progressBar1.Value = 0;
            progressBar1.Maximum = ls.Count;

            foreach (string fname in ls)
            {
                if(fname.IndexOf('.') > 0) //Проверка является ли строка файлом
                {
                    var dn = Path.GetDirectoryName(fname);
                    dn = dn.Substring(dn.LastIndexOf('\\') + 1); //Имя последней папки
                    /*MessageBox.Show("Полный путь: " + fname + "\r\nИмя папки: "+ dn + "\r\nИмя файла: " + Path.GetFileName(fname)
                        + "\r\nВместе: " + Path.Combine(dn, Path.GetFileName(fname)), dn);*/
                    if (!checkPath(Path.Combine(dn, Path.GetFileName(fname)))) //Если нет записи о изображении - добавляем, иначе скип
                    {
                        ScanFile(fname, dn); //Вызов функции обработки изображений в папке                    
                    }
                }                
                progressBar1.Value++;
            }
            fillListbox();
        }        

        private List<string> GetRecursFiles(string start_path)
        {
            List<string> ls = new List<string>();
            try
            {
                string[] folders = Directory.GetDirectories(start_path);
                foreach (string folder in folders)
                {
                    ls.Add(folder);
                    ls.AddRange(GetRecursFiles(folder));
                }
                string[] files = Directory.GetFiles(start_path);
                foreach (string filename in files)
                {
                    ls.Add(filename);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return ls;
        }
    }
}