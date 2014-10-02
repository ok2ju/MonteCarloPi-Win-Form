using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int radius = Convert.ToInt32(textBox3.Text);
            int countPoints = Convert.ToInt32(textBox4.Text);
            int countPointsInCircle = 0;
            int a = radius * 2;

            int x, y;
            double pi;

            Bitmap bmp = new Bitmap(a, a);

            for (int Xcount = 0; Xcount < bmp.Width; Xcount++)
            {
                for (int Ycount = 0; Ycount < bmp.Height; Ycount++)
                {
                    bmp.SetPixel(Xcount, Ycount, Color.Red);
                }
            }
            Graphics g = Graphics.FromImage(bmp);
            Brush b = new SolidBrush(Color.Black);
            Pen pen = new Pen(b);
            g.DrawEllipse(pen, 0, 0, a, a);
            pictureBox1.Image = bmp;

            Random random = new Random();

            for (int i = 0; i <= countPoints; i++)
            {
                x = random.Next(0,a);
                y = random.Next(0,a);

                bmp.SetPixel(x, y, Color.Blue);

                if (IsPointInCircle(radius, x, y))
                {
                    countPointsInCircle++;
                }
            }

            pi = 4.0 * ((double)countPointsInCircle / (double)countPoints);
            textBox1.Text = countPointsInCircle.ToString();
            textBox2.Text = pi.ToString();

        }

        public static bool IsPointInCircle(double R, double x, double y)
        {
            return ((x - R) * (x - R) + (y - R) * (y - R)) <= R * R;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
