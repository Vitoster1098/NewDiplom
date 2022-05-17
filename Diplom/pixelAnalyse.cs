using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Diplom
{
    class pixelAnalyse
    {
        private Bitmap bitmap = new Bitmap(100, 100);
        private double avgBrightness = 0;
        private double[] Sg = new double[3];
        private double[] Med = new double[3];
        public double[] avR = new double[256];
        public double[] avG = new double[256];
        public double[] avB = new double[256];

        public double[] wR = new double[256];
        public double[] wG = new double[256];
        public double[] wB = new double[256];

        public Info[] data = new Info[1];

        ProgressBar bar = null;

        public struct Info //Хранение данных о месте на битмап и его цвета
        {
            private Point pos;
            private Color color;

            public Info(Point pos, Color color) 
            {
                this.pos = pos;
                this.color = color;
            }
            public void setPos(Point pos)
            {
                this.pos = pos;
            }
            public void setColor(Color color)
            {
                this.color = color;
            }
            public Point getPoint()
            {
                return pos;
            }
            public Color getColor()
            {
                return color;
            }
        }

        public pixelAnalyse(ProgressBar bar)
        {
            this.bar = bar;
        }

        public Bitmap getBitmap()
        {
            return bitmap;
        }

        public pixelAnalyse(Bitmap bitmap) //инициализаця старым способом, пока посидит
        {
            this.bitmap = bitmap;
            initInfo();
        }

        private void initInfo() //установка значений в структуру на основе битмапа, поддержка старого способа
        {
            for(int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    Color clr = bitmap.GetPixel(i, j);
                    setInfo(new Point(i, j), clr);
                }                   
            }
        }

        public void setInfo(Point pos, Color color) //установка значений в структуру
        {
            data[data.Length-1] = new Info(new Point(pos.X, pos.Y), color);
            setAvgColor(color);
            Array.Resize(ref data, data.Length + 1);
        }
        public int getMax(bool XorY) //Если передаём True - ищет по X, иначе по Y - возвращает максимальное значения
        {
            int ret = -1;
            if (XorY)
                ret= data[0].getPoint().X;
            else
                ret = data[0].getPoint().Y;

            for (int i = 0; i < data.Length - 1; i++)
            {
                if (ret < data[i].getPoint().X && XorY)
                {
                    ret = data[i].getPoint().X;
                }
                if(ret < data[i].getPoint().Y && !XorY)
                {
                    ret = data[i].getPoint().Y;
                }
            }
            
            return ret;
        }

        public Bitmap getBitmapByInfo(Bitmap temp) //на основе данных структуры формирует и возвращает битмап (на входе данные о размере битмапа)
        {
            bar.Maximum = data.Count();
            bar.Value = 1;

            for(int i = 0; i < data.Length - 1; i++)
            {
                temp.SetPixel(data[i].getPoint().X, data[i].getPoint().Y, data[i].getColor());
                bar.Value++;
            }
            this.bitmap = temp;
            return temp;
        }

        public void setAvgBrightness(double avgBrightness)
        {
            this.avgBrightness = avgBrightness;
        }

        public double getAvgBrightness()
        {
            return avgBrightness;
        }

        public void setSg(int index, double Sg)
        {
            this.Sg[index] = Sg;
        }
        
        public double[] getSg()
        {
            return Sg;
        }

        public void setMed(int index, double Med)
        {
            this.Med[index] = Med;
        }

        public double[] getMed()
        {
            return Med;
        }

        public void setAvgColor(Color avg) //заполнение данных гистограмм
        {
            avR[avg.R]++;
            avG[avg.G]++;
            avB[avg.B]++;
        }

        public void clearAvg() //очистка данных гистограмм
        {
            for (int i = 0; i < avR.Length - 1; avR[i++] = 0) { }
            for (int i = 0; i < avG.Length - 1; avG[i++] = 0) { }
            for (int i = 0; i < avB.Length - 1; avB[i++] = 0) { }
        }

        public double getAverageBrightness() //расчет нового значения средней яркости на основе данных структуры
        {
            double sum = 0;
            for (int i = 0; i < data.Length - 1; i++)
            {
                sum += (data[i].getColor().R * 0.2126) + (data[i].getColor().G * 0.7152) + (data[i].getColor().B * 0.0722);
            }
            avgBrightness = sum / data.Length;
            return sum / data.Length;
        }

        public void changeBrightness() //изменение яркости с сохранением в структуру
        {
            avgBrightness = getAvgBrightness();           
            bar.Maximum = data.Count();
            bar.Value = 0;             
            clearAvg();

            for (int i = 0; i < data.Length - 1; i++)
            {
                Color newclr = newBrightness(data[i].getColor(), avgBrightness);
                setAvgColor(newclr);
                data[i].setColor(newclr);
                bar.Value++;
            }
        }

        public void calcDefl()
        {
            double y = 0, D = 0;

            for (int i = 0; i < 256; ++i)
            {
                y += wR[i] * i;
            }
            //MessageBox.Show("Среднее:"+y);
            for (int i = 0; i < 256; ++i)
            {
                //D += (i * i * wR[i]) - (y * y);
                D += Math.Pow((i - y), 2) * wR[i];
            }            
            setSg(0, Math.Sqrt(D));
            //MessageBox.Show("Дисперсия R:" + D + "\r\nОтклонение:" + Sg[0]);

            y = 0;
            D = 0;
            for (int i = 0; i < 256; ++i)
            {
                y += wG[i] * i;
            }
            //MessageBox.Show("Среднее:"+y);
            for (int i = 0; i < 256; ++i)
            {
                //D += (i * i * wG[i]) - (y * y);
                D += Math.Pow((i - y), 2) * wG[i];
            }
            
            setSg(1, Math.Sqrt(D));
            //MessageBox.Show("Дисперсия G:" + D + "\r\nОтклонение:" + Sg[1]);

            y = 0;
            D = 0;
            for (int i = 0; i < 256; ++i)
            {
                y += wB[i] * i;
            }
            //MessageBox.Show("Среднее:"+y);
            for (int i = 0; i < 256; ++i)
            {
                //D += (i * i * wB[i]) - (y * y);
                D += Math.Pow((i - y), 2) * wB[i];
            }            
            setSg(2, Math.Sqrt(D));
            //MessageBox.Show("Дисперсия B:" + D + "\r\nОтклонение:" + Sg[2]);
        }

        public void calcMed()
        {
            double sum = 0;
            double[] w = getAvgFrequency("R");
            int index = 0;
            for (int i = 0; i < 255; ++i)
            {
                if (sum < 0.5)
                {
                    sum += w[i];
                    index = i;
                }
                else
                {
                    break;
                }
            }
            setMed(0,index - 0.5);

            sum = 0;
            w = getAvgFrequency("G");
            index = 0;
            for (int i = 0; i < 255; ++i)
            {
                if (sum < 0.5)
                {
                    sum += w[i];
                    index = i;
                }
                else
                {
                    break;
                }
            }
            setMed(1, index - 0.5);

            sum = 0;
            w = getAvgFrequency("B");
            index = 0;
            for (int i = 0; i < 255; ++i)
            {
                if (sum < 0.5)
                {
                    sum += w[i];
                    index = i;
                }
                else
                {
                    break;
                }
            }
            setMed(2, index - 0.5);
        }

        public void setRGB(Chart r, Chart g, Chart b, Chart rgb) //отрисовка гистограмм
        {
            r.Series[0].Points.Clear();
            g.Series[0].Points.Clear();
            b.Series[0].Points.Clear();
            rgb.Series[0].Points.Clear();
            rgb.Series[1].Points.Clear();
            rgb.Series[2].Points.Clear();

            for (int i = 0; i < avR.Length - 1; ++i)
            {
                r.Series[0].Points.AddXY(i, avR[i] / data.Length);
                g.Series[0].Points.AddXY(i, avG[i] / data.Length);
                b.Series[0].Points.AddXY(i, avB[i] / data.Length);
                rgb.Series[0].Points.AddXY(i, avR[i] / data.Length);
                rgb.Series[1].Points.AddXY(i, avG[i] / data.Length);
                rgb.Series[2].Points.AddXY(i, avB[i] / data.Length);
            }
        }

        public double getAverageGistogramm(string type) //Получение среднего значения гистограммы по R G B
        {
            double av = 0;

            switch (type)
            {
                case "R":
                    {
                        for (int i = 0; i < 256; ++i)
                        {
                            av += wR[i]  * i;
                        }
                        break;
                    }
                case "G":
                    {
                        for (int i = 0; i < 256; ++i)
                        {
                            av += wG[i] * i;
                        }
                        break;
                    }
                case "B":
                    {
                        for (int i = 0; i < 256; ++i)
                        {
                            av += wB[i] * i;
                        }
                        break;
                    }
            }
            return av;
        }

        public double[] getAvgFrequency(string type)
        {
            double sum = 0;
            double[] freq = new double[256];
            switch (type)
            {
                case "R":
                    {
                        for (int i = 0; i < 255; ++i)
                        {
                            sum += avR[i];
                        }
                        for(int i = 0; i < 255; ++i)
                        {
                            freq[i] = avR[i] / sum;
                        }
                        break;
                    }
                case "G":
                    {
                        for (int i = 0; i < 255; ++i)
                        {
                            sum += avG[i];
                        }
                        for (int i = 0; i < 255; ++i)
                        {
                            freq[i] = avG[i] / sum;
                        }
                        break;
                    }
                case "B":
                    {
                        for (int i = 0; i < 255; ++i)
                        {
                            sum += avB[i];
                        }
                        for (int i = 0; i < 255; ++i)
                        {
                            freq[i] = avB[i] / sum;
                        }
                        break;
                    }                    
            }
            return freq;
        }

        public Color newBrightness(Color point, double q) //расчет новой яркости
        {
            byte R = 0, G = 0, B = 0;
            int[] mx = { point.R, point.G, point.B };
            int max = mx.Max();
            double q_new = q;
            q_new = 127.5 / q;
            
            double q1 = q_new;
            double max1 = max * q1;

            if(max1 > 255)
            {
                q1 = 255 / max;
            }

            R = (byte)(point.R * q1);
            G = (byte)(point.G * q1);
            B = (byte)(point.B * q1);
            
            Color newColor = Color.FromArgb(255, R, G, B);
            return newColor;
        }
    }
}
