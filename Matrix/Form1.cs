using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matrix
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        double[,] M1;
        double[,] M2;
        double[,] M3;
        int dist_between_el = 35;
        Bitmap bmp;
        private void button1_Click(object sender, EventArgs e)
        {//побудувати нову матрицю
            panel2.Refresh();
            this.Refresh();
            button1.BackColor = Color.White;
            button1.FlatStyle = FlatStyle.Flat;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button12.Enabled = true;
            Buttons_Colors();
            int h = Convert.ToInt32(textBox1.Text);
            int w = Convert.ToInt32(textBox2.Text);
            M1 = new double[w, h];
            for (int i = 0; i < w; i++)
                for (int j = 0; j < h; j++)
                    if (i != j||button1.Text == "Анулювати матрицю")
                        M1[i, j] = 0;
                    else
                        M1[i, j] = 1;
            button1.Text = "Анулювати матрицю";
            textBox5.Location = new Point(-100, -100);
            panel4.Location = new Point(-1000, -1000);
            label5.Location = new Point(-100, -100);
            do_matrix(M1, w, h, panel2, pictureBox1);
            do_matrix(M1, w, h, panel2, pictureBox1);
        }
        Graphics g, h;
        void do_matrix(double[,] matrix, int W, int H, Panel p, PictureBox pict)
        {
            p.Refresh();
            p.Height = H * dist_between_el;
            bmp = new Bitmap(p.Width, p.Height);
            g = Graphics.FromImage(bmp);
            h = this.CreateGraphics();
            Font f = new Font("Arial", 15, FontStyle.Regular);
            int[] a = new int[W];
            for (int i = 0; i < W; i++)
            {
                a[i] = 0;
                for (int j = 0; j < H; j++)
                {
                    g.DrawString(matrix[i, j].ToString(), f, Brushes.Black, (15 - matrix[i, j].ToString().Length * 15) / 2 + i * dist_between_el + 3, j * dist_between_el + 3);
                    //if (a[j] > a[i])
                    //    a[i] =;
                }
            }
            int wdth = 0;
            //for (int i = 0; i < W; i++)
            //    wdth +=;
            p.Width = W * dist_between_el;
            pict.Image = bmp;
        }

        private void panel2_DoubleClick(object sender, EventArgs e)
        {

        }
        int active_i = 0, active_j = 0;

        private void panel2_Click(object sender, EventArgs e)
        {
            panel2.Refresh();
            double x, y;
            x = Cursor.Position.X - this.Location.X - panel2.Location.X;
            y = Cursor.Position.Y - this.Location.Y - panel2.Location.Y;
            int h = Convert.ToInt32(textBox1.Text);
            int w = Convert.ToInt32(textBox2.Text);
            int i = Convert.ToInt32((x + 7) / dist_between_el) - 1;
            int j = Convert.ToInt32((y + 15) / dist_between_el) - 2;
            textBox5.Width = dist_between_el;
            textBox5.Height = dist_between_el;
            textBox5.Location = new Point(i * dist_between_el, j * dist_between_el);
            try
            {
                textBox5.Text = M1[i, j].ToString();
                active_i = i;
                active_j = j;
            }
            catch { }
            do_matrix(M1, w, h, panel2, pictureBox1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox5.Location = new Point(-1000, -1000);
            panel4.Location = new Point(-1000, -1000);
            label5.Location = new Point(-1000, -1000);
            toolTip1.SetToolTip(button2, "Визначити детермінант \nматриці");
            toolTip1.SetToolTip(button3, "Транспонувати матрицю");
            toolTip1.SetToolTip(button4, "Піднести матрицю до\n"+Convert.ToInt32(textBox3.Text)+"-ого ступеня");
            toolTip1.SetToolTip(button5, "Визначити обернену матрицю");
            toolTip1.SetToolTip(button6, "Домножити матрицю на " + textBox3.Text);
            toolTip1.SetToolTip(button7, "Визначити добуток транспонованої \n матриці на саму матрицю");
            toolTip1.SetToolTip(button8, "Визначити добуток матриці \nна транспоновану матрицю");
            toolTip1.SetToolTip(button9, "Визначити союзну матрицю");
            toolTip1.SetToolTip(button11, "Довідка");
            toolTip1.SetToolTip(button12, "Визначити ранг матриці");
            //toolTip1.SetToolTip(button13, "Налаштування");

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try_change_text();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try_change_text();
        }
        void try_change_text()
        {
            try
            {
                bmp = new Bitmap(1, 1);
                pictureBox1.Refresh();
                this.Refresh();
                button1.Text = "Тиць";
                pictureBox2.Refresh();
                pictureBox1.Image = bmp;
                pictureBox2.Image = bmp;
                //M1 = new double[Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox1.Text)];
                //for (int i = 0; i < Convert.ToInt32(textBox2.Text); i++)
                //    for (int j = 0; j < Convert.ToInt32(textBox1.Text); j++)
                //        M1[i, j] = 0;
                //do_matrix(M1, Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox1.Text), panel2);
            }
            catch
            {

            }
            //if (textBox1.Text == textBox2.Text)
            //{
            //    button2.Enabled = true;
            //    button4.Enabled = true;
            //    button5.Enabled = true;
            //    button9.Enabled = true;
            //    button2.BackColor = Color.White;
            //    button4.BackColor = Color.White;
            //    button5.BackColor = Color.White;
            //    button9.BackColor = Color.White;
            //}
            //else
            //{
            //    button2.Enabled = false;
            //    button4.Enabled = false;
            //    button5.Enabled = false;
            //    button9.Enabled = false;
            //    button2.BackColor = Color.Gray;
            //    button4.BackColor = Color.Gray;
            //    button5.BackColor = Color.Gray;
            //    button9.BackColor = Color.Gray;
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {//детермінанта А
            if (button2.Enabled)
            {
                Buttons_Colors();
                button2.BackColor = Color.Green;
                panel4.Visible = false;
                int size = Convert.ToInt32(textBox1.Text);//размер матрицы
                double det = 10000;//переменная для конечного ответа
                int x = 0, f = -1;
                double a = 1;
                //в первую очередь проверяем матрицу на наличие нулевых строк/столбцов
                for (int i = 0; i < size; i++)
                {
                    //проверка на нулевую строку:
                    x = 0;
                    for (int j = 0; j < size; j++)
                    {
                        if (M1[i, j] == 0)
                            x++;
                        else
                            break;
                    }
                    if (x == size)
                    {
                        det = 0;
                        break;
                    }
                    else
                        x = 0;
                    //проверка на нулевой столбец:
                    for (int j = 0; j < size; j++)
                    {
                        if (M1[j, i] == 0)
                            x++;
                        else
                            break;
                    }
                    if (x == size)
                    {
                        det = 0;
                        break;
                    }
                    else
                        x = 0;
                }
                x = 0;
                if (det != 0)
                {//в случае, если нулевых строк нету:
                    //проверяем матрицу на наличие одинаковых (и эквивалентных) строк и столбцов:
                    for (int i = 0; i < size - 1; i++)
                    {
                        for (int j = i + 1; j < size; j++)
                        {
                            //проверяем строки:
                            again:
                            f++;
                            if (f < size)//устанавливаем коефициент пропорцианальности строк
                                if (M1[j, f] != 0 && M1[i, f] != 0)
                                    a = M1[i, f] / M1[j, f];
                                else
                                    goto again;
                            else
                                a = 1;
                            for (int u = 0; u < size; u++)
                                if (M1[i, u] == a * M1[j, u])
                                    x++;
                            if (x == size)
                            {
                                det = 0;
                                break;
                            }
                            else
                                x = 0;
                            //проверяем столбцы:
                            f = -1;
                            again1:
                            f++;
                            if (f < size)//устанавливаем коефициент пропорцианальности столбцов
                                if (M1[f, j] != 0 && M1[f, i] != 0)
                                    a = M1[f, i] / M1[f, j];
                                else
                                    goto again1;
                            else
                                a = 1;
                            for (int u = 0; u < size; u++)
                                if (M1[u, i] == a * M1[u, j])
                                    x++;
                            if (x == size)
                            {
                                det = 0;
                                break;
                            }
                            else
                                x = 0;
                        }
                        if (x == size)
                        {
                            det = 0;
                            break;
                        }
                        else
                            x = 0;
                    }
                }
                if (det != 0)
                {//если же детерминант все еще не нулевой
                    det = 0;
                    //то считаем его по следствию из теоремы Лапласа:
                    int j = 0;/*j-тый столбец/строка с максимальным количеством нулей*/
                    for(int i=0;i<size;i++)
                    {
                        if (M1[i, j] != 0)
                            det += Math.Pow(-1, (1 + j) + (1 + i)) * M1[i, j] * Determinant(i, j, size - 1, M1);
                        //(-1)^ (1+j)+(1+i), т.к. индекс начинается с 0
                    }
                }
                label5.Visible = true;
                label5.Location = new Point(panel2.Location.X + panel2.Width + 40, panel2.Location.Y - label5.Height);
                label5.Text = "Детермінант(визначник) матриці = " + det.ToString();
            }
            //h.DrawLine(Pens.Black, panel2.Location.X - 1, panel2.Location.Y - 10, panel2.Location.X - 1, panel2.Location.Y + panel2.Width + 10);
            //h.DrawLine(Pens.Black, panel2.Location.X + panel2.Height + 1, panel2.Location.Y - 10, panel2.Location.X + panel2.Height + 1, panel2.Location.Y + panel2.Width + 10);
            button10.Visible = false;
        }
        double Determinant(int i_index, int j_index, int size, double[,] M)
        {
            double answer = 0;
            double[,] a = new double[size, size];
            if (size > 0)
            {
                //присваеваем елементы доп. минора:
                int j, k = 0, k1 = 0;
                for (int i = 0; i < size + 1; i++)
                    if (i != i_index)
                    {
                        k1 = 0;
                        for (j = 0; j < size + 1; j++)
                            if (j != j_index)
                                a[i - k, j - k1] = M[i, j];
                            else
                                k1 = 1;
                    }
                    else
                        k = 1;
                //находим детерминант данного минора по следствию из т. Лапласа:
                j = 0; /*j - тый столбец / строка с максимальным количеством нулей*/
                for (int i = 0; i < size; i++)
                    if (a[i, j] != 0)
                        answer += Math.Pow(-1, (j + 1) + (i + 1)) * a[i, j] * Determinant(i, j, size - 1, a);
            }
            else
            {
                answer = 1;
            }
            return answer;
        }
        private void button3_Click(object sender, EventArgs e)
        {//транспонована матриця до А
            Buttons_Colors();
            button3.BackColor = Color.Green;
            panel4.Visible = true;
            label5.Visible = true;
            panel4.Location = new Point(panel2.Location.X + panel2.Width + 40, panel2.Location.Y);
            label5.Location = new Point(panel2.Location.X + panel2.Width + 40, panel2.Location.Y - label5.Height);
            label5.Text = "Транспонована матриця до А:";
            panel4.Height = panel2.Width;
            panel4.Width = panel2.Height;
            int h = Convert.ToInt32(textBox1.Text);
            int w = Convert.ToInt32(textBox2.Text);
            M3 = new double[h, w];
            for (int i = 0; i < w; i++)
                for (int j = 0; j < h; j++)
                {
                    M3[j, i] = M1[i, j];
                }
            do_matrix(M3, h, w, panel4,pictureBox2);
            button10.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {//матриця у н-ному ступені
            if (button4.Enabled)
            {
                Buttons_Colors();
                button4.BackColor = Color.Green;
                panel4.Visible = true;
                label5.Visible = true;
                panel4.Location = new Point(panel2.Location.X + panel2.Width + 40, panel2.Location.Y);
                label5.Location = new Point(panel2.Location.X + panel2.Width + 40, panel2.Location.Y - label5.Height);
                panel4.Height = panel2.Height;
                panel4.Width = panel2.Height;
                double N = Convert.ToInt32(Math.Floor(Convert.ToDouble(textBox3.Text)));
                label5.Text = "А^" + N.ToString() + " =";
                int w = Convert.ToInt32(textBox1.Text);
                M3 = new double[w, w];
                M2 = new double[w, w];
                for (int i = 0; i < w; i++)
                    for (int j = 0; j < w; j++)
                    {
                        M3[i, j] = M1[i, j];
                        M2[i, j] = M1[i, j];
                    }
                for (int t = 1; t < N; t++)
                {
                    for (int i = 0; i < w; i++)
                        for (int j = 0; j < w; j++)
                            M2[i, j] = M3[i, j];
                    for (int i = 0; i < w; i++)
                        for (int j = 0; j < w; j++)
                        {
                            M3[i, j] = 0;
                            for (int k = 0; k < w; k++)
                                M3[i, j] += M1[i, k] * M2[k, j];
                        }
                }
                do_matrix(M3, w, w, panel4, pictureBox2);
                button10.Visible = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {//обернена матриця до А: (A^-1)
            if (button5.Enabled)
            {
                Buttons_Colors();
                button5.BackColor = Color.Green;
                panel4.Visible = true;
                label5.Visible = true;
                panel4.Location = new Point(panel2.Location.X + panel2.Width + 40, panel2.Location.Y);
                label5.Location = new Point(panel2.Location.X + panel2.Width + 40, panel2.Location.Y - label5.Height);
                panel4.Height = panel2.Height;
                panel4.Width = panel2.Width;
                label5.Text = "Обернена матриця:";
                int h = Convert.ToInt32(textBox1.Text);
                int w = Convert.ToInt32(textBox2.Text);
                M3 = new double[w, w];
                int j = 0;
                double det = 0;
                for (int i = 0; i < h; i++)//знаходимо детермінант...
                    if (M1[i, j] != 0)
                        det += Math.Pow(-1, (1 + j) + (1 + i)) * M1[i, j] * Determinant(i, j, h - 1, M1);
                if (det != 0)//...і якщо він не нульовий, то знаходимо обернену матрицю
                {
                    for (int i = 0; i < w; i++)
                        for (j = 0; j < w; j++)
                            M3[j, i] = Math.Pow(-1, i + j + 2) * Determinant(i, j, w - 1, M1) / det;
                    do_matrix(M3, w, w, panel4, pictureBox2);
                }
                else//інакше кажемо, що об. матриці не існує
                {
                    panel4.Visible = false;
                    label5.Text = "Оберненої матриці до данної матриці не існує, оскільки \n її детермінант = 0!";
                }
                button10.Visible = true;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {//множення матриці на число
            Buttons_Colors();
            button6.BackColor = Color.Green;
            panel4.Visible = true;
            label5.Visible = true;
            panel4.Location = new Point(panel2.Location.X + panel2.Width + 40, panel2.Location.Y);
            label5.Location = new Point(panel2.Location.X + panel2.Width + 40, panel2.Location.Y - label5.Height);
            panel4.Height = panel2.Height;
            panel4.Width = panel2.Width;
            double N = Convert.ToDouble(textBox3.Text);
            label5.Text = N.ToString() + "*А:";
            M3 = new double[Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox1.Text)];
            for (int i = 0; i < Convert.ToInt32(textBox2.Text); i++)
                for (int j = 0; j < Convert.ToInt32(textBox1.Text); j++)
                    M3[i, j] = N * M1[i, j];
            panel4.Visible = true;
            label5.Visible = true;
            panel4.Location = new Point(panel2.Location.X + panel2.Width + 40, panel2.Location.Y);
            label5.Location = new Point(panel2.Location.X + panel2.Width + 40, panel2.Location.Y - label5.Height);
            label5.Text = N.ToString() + "*А:";
            panel4.Height = panel2.Height;
            panel4.Width = panel2.Width;
            do_matrix(M3, Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox1.Text), panel4, pictureBox2);
            button10.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {//множення А^T на А
            Buttons_Colors();
            button7.BackColor = Color.Green;
            panel4.Visible = true;
            label5.Visible = true;
            panel4.Location = new Point(panel2.Location.X + panel2.Width + 40, panel2.Location.Y);
            label5.Location = new Point(panel2.Location.X + panel2.Width + 40, panel2.Location.Y - label5.Height);
            label5.Text = "A^t * A =";
            panel4.Height = panel2.Width;
            panel4.Width = panel2.Width;
            int h = Convert.ToInt32(textBox1.Text);
            int w = Convert.ToInt32(textBox2.Text);
            M2 = new double[h, w];
            for (int i = 0; i < w; i++)
                for (int j = 0; j < h; j++)
                    M2[j, i] = M1[i, j];
            M3 = new double[w, w];
            for (int i = 0; i < w; i++)
                for (int j = 0; j < w; j++)
                {
                    M3[i, j] = 0;
                    for (int k = 0; k < h; k++)
                        M3[i, j] += M1[i, k] * M2[k, j];
                }
            do_matrix(M3, w, w, panel4, pictureBox2);
            button10.Visible = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {//множення А на А^T
            Buttons_Colors();
            button8.BackColor = Color.Green;
            panel4.Visible = true;
            label5.Visible = true;
            panel4.Location = new Point(panel2.Location.X + panel2.Width + 40, panel2.Location.Y);
            label5.Location = new Point(panel2.Location.X + panel2.Width + 40, panel2.Location.Y - label5.Height);
            label5.Text = "А * A^t =";
            panel4.Height = panel2.Height;
            panel4.Width = panel2.Height;
            int h = Convert.ToInt32(textBox1.Text);
            int w = Convert.ToInt32(textBox2.Text);
            M2 = new double[h, w];
            for (int i = 0; i < w; i++)
                for (int j = 0; j < h; j++)
                    M2[j, i] = M1[i, j];
            M3 = new double[h, h];
            for (int i = 0; i < h; i++)
                for (int j = 0; j < h; j++)
                {
                    M3[i, j] = 0;
                    for (int k = 0; k < w; k++)
                        M3[i, j] += M1[k, i] * M2[j, k];
                }

            do_matrix(M3, h, h, panel4, pictureBox2);
            button10.Visible = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {//знаходження союзної матриці
            if (button9.Enabled)
            {
                Buttons_Colors();
                button9.BackColor = Color.Green;
                panel4.Visible = true;
                label5.Visible = true;
                panel4.Location = new Point(panel2.Location.X + panel2.Width + 40, panel2.Location.Y);
                label5.Location = new Point(panel2.Location.X + panel2.Width + 40, panel2.Location.Y - label5.Height);
                panel4.Height = panel2.Height;
                panel4.Width = panel2.Width;
                label5.Text = "Союзна матриця:";
                int h = Convert.ToInt32(textBox1.Text);
                int w = Convert.ToInt32(textBox2.Text);
                M3 = new double[w, w];
                for (int i = 0; i < w; i++)
                    for (int j = 0; j < w; j++)
                        M3[j, i] = Math.Pow(-1, i + j + 2) * Determinant(i, j, w - 1, M1);
                do_matrix(M3, w, w, panel4, pictureBox2);
                button10.Visible = true;
            }
        }

        private void Button12_Click(object sender, EventArgs e)
        {//знахлдження рангу матриці
            Buttons_Colors();
            button12.BackColor = Color.Green;
            panel4.Visible = false;
            label5.Visible = true;
            panel4.Location = new Point(panel2.Location.X + panel2.Width + 40, panel2.Location.Y);
            label5.Location = new Point(panel2.Location.X + panel2.Width + 40, panel2.Location.Y - label5.Height);
            button10.Visible = false;
            int h = Convert.ToInt32(textBox1.Text);
            int w = Convert.ToInt32(textBox2.Text);
            int rank = -1;
            //перевіряємо матрицю на наявність всіх нульових елементів:
            bool bl = false;
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                    if (M1[i, j] == 0)
                        bl = true;
                    else
                    {
                        bl = false;
                        break;
                    }
                if (!bl)
                    break;
            }
            if (bl)//якщо всі ел. - нулі
                rank = 0;
            else
                rank = Rangue(M1, h, w);
            label5.Text = "Ранг матриці А = "+rank;
        }

        int Rangue(double[,] m, int h, int w)
        {
            int answer = 0;
            if (h > w)
            {//i
                answer = w;
                int[] z = new int[w];//массив, хранящий информацию о линейной зависимости столбцов
                //если і0-тый зависит от і-того, то z[i]=i и z[i0]=i
                //если i0-тый - нулевой, то z[i0]=-1
                for (int i = 0; i < w; i++)
                    z[i] = w + h;
                bool zero = false, trying = false;
                int count = 0;
                double koef = 0;
                for (int i = 0; i < w; i++)
                {
                    zero = true;
                    for (int j = 0; j < h; j++)
                        if (m[i, j] != 0)
                        {
                            zero = false;
                            break;
                        }
                    if (!zero)
                    {
                        if (z[i] == h + w)
                        {//если так, то этот рядок еще не зависит от других
                            //иначе этот рядок уже линейно зависит, поэтому не требует проверки
                            for (int i0 = 0; i0 < w; i0++)
                            {//анализ каждого столбца кроме проверяемого
                                if (i != i0)
                                {
                                    koef = 1;
                                    //устанавливаем коефициент соотношения
                                    for (int j0 = 0; j0 < h; j0++)
                                        if (m[i, j0] != 0 && m[i0, j0] != 0)
                                        {
                                            koef = m[i, j0] / m[i0, j0];
                                            break;
                                        }
                                    count = 0;
                                    for (int j = 0; j < h; j++)
                                        if (m[i, j] == m[i0, j] * koef)
                                            count++;
                                        else
                                            break;
                                    if (count == h)
                                    {//линейно зависимые столбцы
                                        z[i] = i;
                                        z[i0] = i;
                                    }
                                    else
                                    {//линейно независимый столбец
                                        z[i] = h + w;
                                    }
                                }
                            }
                        }
                    }
                    else
                        z[i] = -1;
                }
                //анализируем список линейной зависимости столбцов
                for (int i = 0; i < w; i++)
                    if (z[i] != -1)
                    {//если не нулевой
                        if (z[i] == w + h)
                        {//линейно независимый

                        }
                        else
                        {//линейно зависим
                            trying = true;
                            for (int j = i; j >= 0; j--)
                            {//проверяем, не учли ли мы уже данную линейную зависимость
                                if (i != j)
                                    if (z[i] == z[j])
                                    {
                                        trying = false;
                                        break;
                                    }
                            }
                            //проверяем сколько неучтенных вектор-столбцов:
                            if (trying)
                                for (int j = i; j < w; j++)
                                    if (i != j)
                                        if (z[i] == z[j])
                                            answer--;
                        }
                    }
                    else
                        answer--;
                return answer;
            }
            else if(h<w)
            {//j
                answer = h;
                int[] z = new int[h];//массив, хранящий информацию о линейной зависимости рядков
                //если j0-тый зависит от j-того, то z[j]=j0 и z[j0]=j
                //если j0-тый - нулевой, то z[j0]=-1
                for (int i = 0; i < h; i++)
                    z[i] = w + h;
                bool zero = false, trying = false;
                int count = 0;
                double koef = 0;
                for (int j = 0; j < h; j++)
                {
                    zero = true;
                    for (int i = 0; i < w; i++)
                        if (m[i, j] != 0)
                        {
                            zero = false;
                            break;
                        }
                    if (!zero)
                    {
                        if (z[j] == w + h)
                        {
                            for (int j0 = 0; j0 < h; j0++)//анализ каждой строки кроме проверяемого
                                if (j != j0)
                                {
                                    koef = 1;
                                    //устанавливаем коефициент соотношения
                                    for (int i0 = 0; i0 < w; i0++)
                                        if (m[i0, j] != 0 && m[i0, j0] != 0)
                                        {
                                            koef = m[i0, j] / m[i0, j0];
                                            break;
                                        }
                                    count = 0;
                                    for (int i = 0; i < w; i++)
                                        if (m[i, j] == m[i, j0] * koef)
                                            count++;
                                        else
                                            break;
                                    if (count == w)
                                    {//линейно зависимые столбцы
                                        z[j] = j;
                                        z[j0] = j;
                                    }
                                    else//линейно независимый столбец
                                        z[j] = h + w;
                                }
                        }
                    }
                    else
                        z[j] = -1;
                }
                //анализируем список линейной зависимости строк:
                for (int j = 0; j < h; j++)
                {
                    if (z[j] != -1)
                    {//если не нулевой
                        if (z[j] == w + h)
                        {//линейно независимый

                        }
                        else
                        {//линейно зависим
                            trying = true;
                            for (int i = j; i >= 0; i--)
                            {//проверяем, не учли ли мы уже данную линейную зависимость
                                if (i != j)
                                    if (z[j] == z[i])
                                    {
                                        trying = false;
                                        break;
                                    }
                            }
                            //проверяем сколько неучтенных вектор-столбцов:
                            if (trying)
                                for (int i = j; i < h; i++)
                                    if (i != j)
                                        if (z[i] == z[j])
                                            answer--;
                        }
                    }
                    else
                        answer--;
                }
                return answer;
            }
            else
            {
                //i
                answer = w;
                int[] z = new int[w];//массив, хранящий информацию о линейной зависимости столбцов
                //если і0-тый зависит от і-того, то z[i]=i и z[i0]=i
                //если i0-тый - нулевой, то z[i0]=-1
                for (int i = 0; i < w; i++)
                    z[i] = w + h;
                bool zero = false, trying = false;
                int count = 0;
                double koef = 0;
                for (int i = 0; i < w; i++)
                {
                    zero = true;
                    for (int j = 0; j < h; j++)
                        if (m[i, j] != 0)
                        {
                            zero = false;
                            break;
                        }
                    if (!zero)
                    {
                        if (z[i] == h + w)
                        {//если так, то этот рядок еще не зависит от других
                            //иначе этот рядок уже линейно зависит, поэтому не требует проверки
                            for (int i0 = 0; i0 < w; i0++)
                            {//анализ каждого столбца кроме проверяемого
                                if (i != i0)
                                {
                                    koef = 1;
                                    //устанавливаем коефициент соотношения
                                    for (int j0 = 0; j0 < h; j0++)
                                        if (m[i, j0] != 0 && m[i0, j0] != 0)
                                        {
                                            koef = m[i, j0] / m[i0, j0];
                                            break;
                                        }
                                    count = 0;
                                    for (int j = 0; j < h; j++)
                                        if (m[i, j] == m[i0, j] * koef)
                                            count++;
                                        else
                                            break;
                                    if (count == h)
                                    {//линейно зависимые столбцы
                                        z[i] = i;
                                        z[i0] = i;
                                    }
                                    else
                                    {//линейно независимый столбец
                                        z[i] = h + w;
                                    }
                                }
                            }
                        }
                    }
                    else
                        z[i] = -1;
                }
                //анализируем список линейной зависимости столбцов
                for (int i = 0; i < w; i++)
                    if (z[i] != -1)
                    {//если не нулевой
                        if (z[i] == w + h)
                        {//линейно независимый

                        }
                        else
                        {//линейно зависим
                            trying = true;
                            for (int j = i; j >= 0; j--)
                            {//проверяем, не учли ли мы уже данную линейную зависимость
                                if (i != j)
                                    if (z[i] == z[j])
                                    {
                                        trying = false;
                                        break;
                                    }
                            }
                            //проверяем сколько неучтенных вектор-столбцов:
                            if (trying)
                                for (int j = i; j < w; j++)
                                    if (i != j)
                                        if (z[i] == z[j])
                                            answer--;
                        }
                    }
                    else
                        answer--;


                //j
                int answer1 = h;
                z = new int[h];//массив, хранящий информацию о линейной зависимости рядков
                //если j0-тый зависит от j-того, то z[j]=j0 и z[j0]=j
                //если j0-тый - нулевой, то z[j0]=-1
                for (int i = 0; i < h; i++)
                    z[i] = w + h;
                
                for (int j = 0; j < h; j++)
                {
                    zero = true;
                    for (int i = 0; i < w; i++)
                        if (m[i, j] != 0)
                        {
                            zero = false;
                            break;
                        }
                    if (!zero)
                    {
                        if (z[j] == w + h)
                        {
                            for (int j0 = 0; j0 < h; j0++)//анализ каждой строки кроме проверяемого
                                if (j != j0)
                                {
                                    koef = 1;
                                    //устанавливаем коефициент соотношения
                                    for (int i0 = 0; i0 < w; i0++)
                                        if (m[i0, j] != 0 && m[i0, j0] != 0)
                                        {
                                            koef = m[i0, j] / m[i0, j0];
                                            break;
                                        }
                                    count = 0;
                                    for (int i = 0; i < w; i++)
                                        if (m[i, j] == m[i, j0] * koef)
                                            count++;
                                        else
                                            break;
                                    if (count == w)
                                    {//линейно зависимые столбцы
                                        z[j] = j;
                                        z[j0] = j;
                                    }
                                    else//линейно независимый столбец
                                        z[j] = h + w;
                                }
                        }
                    }
                    else
                        z[j] = -1;
                }
                //анализируем список линейной зависимости строк:
                for (int j = 0; j < h; j++)
                {
                    if (z[j] != -1)
                    {//если не нулевой
                        if (z[j] == w + h)
                        {//линейно независимый

                        }
                        else
                        {//линейно зависим
                            trying = true;
                            for (int i = j; i >= 0; i--)
                            {//проверяем, не учли ли мы уже данную линейную зависимость
                                if (i != j)
                                    if (z[j] == z[i])
                                    {
                                        trying = false;
                                        break;
                                    }
                            }
                            //проверяем сколько неучтенных вектор-столбцов:
                            if (trying)
                                for (int i = j; i < h; i++)
                                    if (i != j)
                                        if (z[i] == z[j])
                                            answer1--;
                        }
                    }
                    else
                        answer1--;
                }
                if (answer < answer1)
                    return answer;
                else
                    return answer1;
            }
            
        }

        private void button10_Click(object sender, EventArgs e)
        {//матрицю відповіді у початкову
            M1 = M3;
            textBox2.Text = (panel4.Width / dist_between_el).ToString();
            textBox1.Text = (panel4.Height / dist_between_el).ToString();
            for (int i = 0; i < Convert.ToInt32(textBox2.Text); i++)
                for (int j = 0; j < Convert.ToInt32(textBox1.Text); j++)
                    M1[i, j] = M3[i, j];
            panel4.Visible = false;
            panel4.Location = new Point(-1000, -1000);
            label5.Visible = false;
            label5.Location = new Point(-1000, -1000);
            do_matrix(M1, panel4.Width / dist_between_el, panel4.Height / dist_between_el, panel2, pictureBox1);
            do_matrix(M1, panel4.Width / dist_between_el, panel4.Height / dist_between_el, panel2, pictureBox1);
        }

        private void TextBox5_MouseLeave(object sender, EventArgs e)
        {
            textBox5.Location = new Point(-100, -100);
            int h = Convert.ToInt32(textBox1.Text);
            int w = Convert.ToInt32(textBox2.Text);
            try
            {
                M1[active_i, active_j] = Convert.ToDouble(textBox5.Text);
            }
            catch { }
            do_matrix(M1, w, h, panel2,pictureBox1);
        }

        private void TextBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)Keys.Return:
                    {
                        //CancelEdit = false;
                        e.Handled = true;
                        textBox5.Location = new Point(-100, -100);
                        break;
                    }
            }
        }

        private void PictureBox1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            double x, y;
            x = Cursor.Position.X - this.Location.X - panel2.Location.X;
            y = Cursor.Position.Y - this.Location.Y - panel2.Location.Y;
            int h = Convert.ToInt32(textBox1.Text);
            int w = Convert.ToInt32(textBox2.Text);
            int i = Convert.ToInt32((x + 7) / dist_between_el) - 1;
            int j = Convert.ToInt32((y + 15) / dist_between_el) - 2;
            textBox5.Width = dist_between_el;
            textBox5.Height = dist_between_el;
            textBox5.Location = new Point(i * dist_between_el, j * dist_between_el);
            try
            {
                textBox5.Text = M1[i, j].ToString();
                active_i = i;
                active_j = j;
            }
            catch { }
            do_matrix(M1, w, h, panel2, pictureBox1);
        }

        private void Button11_Click(object sender, EventArgs e)
        {//довідка
            Form2 f = new Form2();
            f.ShowDialog();
        }

        private void Button13_Click(object sender, EventArgs e)
        {//налаштування

        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                toolTip1.SetToolTip(button4, "Піднести матрицю до\n" + (int)Convert.ToDouble(textBox3.Text) + "-ого ступеня");
                toolTip1.SetToolTip(button6, "Домножити матрицю на " + textBox3.Text);
            }
            catch { }
        }

        private void TextBox5_TextChanged(object sender, EventArgs e)
        {
            pictureBox2.Refresh();
        }

        void Buttons_Colors()
        {
            button2.BackColor = Color.White;
            button3.BackColor = Color.White;
            button4.BackColor = Color.White;
            button5.BackColor = Color.White;
            button6.BackColor = Color.White;
            button7.BackColor = Color.White;
            button8.BackColor = Color.White;
            button9.BackColor = Color.White;
            button12.BackColor = Color.White;
            if (textBox1.Text == textBox2.Text)
            {
                button2.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                button9.Enabled = true;
                button2.BackColor = Color.White;
                button4.BackColor = Color.White;
                button5.BackColor = Color.White;
                button9.BackColor = Color.White;
            }
            else
            {
                button2.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button9.Enabled = false;
                button2.BackColor = Color.Gray;
                button4.BackColor = Color.Gray;
                button5.BackColor = Color.Gray;
                button9.BackColor = Color.Gray;
            }
        } 
    }
}
