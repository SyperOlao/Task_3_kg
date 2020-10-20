using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Написать процедуру, выводящую строку символов(с коэффициентом увеличения) под любым углом.
namespace Task_3_kg
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void Draw(Graphics graphics)
        {
            string userSTR = textBox1.Text;
            int x = int.Parse(textBoxX.Text);
            int y = int.Parse(textBoxY.Text);
            int alfa = int.Parse(textboxAngle.Text);
            float size = float.Parse(textBox4.Text.Replace(".", ","));
            graphics.RotateTransform(alfa);
            graphics.TranslateTransform(150, 50);
            double Xnew = x * Math.Cos(alfa) + y * Math.Sin(alfa);
            double Ynew = -x * Math.Sin(alfa) + y * Math.Cos(alfa);
            if (alfa >= 0 && alfa <= 90)
            {
                graphics.DrawString(userSTR, new Font("Arial", size * 15.0f), new SolidBrush(Color.Black), y + (float)Ynew, -x - (float)Xnew);
            }
            if (alfa > 90 && alfa <= 180)
            {
                graphics.DrawString(userSTR, new Font("Arial", size * 15.0f), new SolidBrush(Color.Black), -x - (float)Xnew, -y - (float)Ynew);
            }
          
            graphics.ResetTransform();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics graphics = CreateGraphics();
            Draw(graphics);
            pictureBox1.Refresh(); 
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Draw(graphics);
        }


    }
}
