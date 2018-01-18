using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace HW1_s1031436
{
    public partial class Form1 : Form
    {
        Rectangle sq1, sq2, sq3, sq4, sq5, sq6, sq7, sq8, sq9;
        Pen pen1;
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            int r, g, b;
            Random rd = new Random();  //使用亂數類別
            Brush Brd;

            r = rd.Next(256); //產生0~255的亂數
            g = rd.Next(256);
            b = rd.Next(256);
            Brd = new SolidBrush(Color.FromArgb(r, g, b)); //產生亂數顏色畫刷

            if (sq1.Contains(e.Location))
            {
                Graphics gr = this.CreateGraphics();
                //gr.DrawRectangle(pen1, sq1); // 繪出矩形
                gr.FillRectangle(Brd, sq1);

            }
            else if (sq2.Contains(e.Location))
            {

                Graphics gr = this.CreateGraphics();
                //gr.DrawRectangle(pen1, sq2); // 繪出矩形
                gr.FillRectangle(Brd, sq2);
            }
            else if (sq3.Contains(e.Location))
            {
                Graphics gr = this.CreateGraphics();
                //gr.DrawRectangle(pen1, sq3); // 繪出矩形
                gr.FillRectangle(Brd, sq3);
            }
            else if (sq4.Contains(e.Location))
            {
                Graphics gr = this.CreateGraphics();
                //gr.DrawRectangle(pen1, sq4); // 繪出矩形
                gr.FillRectangle(Brd, sq4);
            }
            else if (sq5.Contains(e.Location))
            {
                Graphics gr = this.CreateGraphics();
                gr.FillRectangle(Brd, sq5);
            }
            else if (sq6.Contains(e.Location))
            {
                Graphics gr = this.CreateGraphics();
                gr.FillRectangle(Brd, sq6);
            }
            else if (sq7.Contains(e.Location))
            {
                Graphics gr = this.CreateGraphics();
                gr.FillRectangle(Brd, sq7);
            }
            else if (sq8.Contains(e.Location))
            {
                Graphics gr = this.CreateGraphics();
                gr.FillRectangle(Brd, sq8);
            }
            else if (sq9.Contains(e.Location))
            {
                Graphics gr = this.CreateGraphics();
                gr.FillRectangle(Brd, sq9);

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(250, 250);
        }

        public Form1()
        {
            InitializeComponent();
            sq1 = new Rectangle(0, 0, 50, 50);
            sq2 = new Rectangle(50, 0, 50, 50);
            sq3 = new Rectangle(100, 0, 50, 50);
            sq4 = new Rectangle(0, 50, 50, 50);
            sq5 = new Rectangle(50, 50, 50, 50);
            sq6 = new Rectangle(100, 50, 50, 50);
            sq7 = new Rectangle(0, 100, 50, 50);
            sq8 = new Rectangle(50, 100, 50, 50);
            sq9 = new Rectangle(100, 100, 50, 50);
            pen1 = new Pen(Color.Black, 3);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(pen1, sq1); // 繪出矩形
            Brush b1 = new SolidBrush(Color.FromArgb(215, 110, 123));
            e.Graphics.FillRectangle(b1, sq1);//上色

            e.Graphics.DrawRectangle(pen1, sq2); // 繪出矩形
            Brush b2 = new SolidBrush(Color.FromArgb(178, 13, 210));
            e.Graphics.FillRectangle(b2, sq2);//上色

            e.Graphics.DrawRectangle(pen1, sq3); // 繪出矩形
            Brush b3 = new SolidBrush(Color.FromArgb(8, 113, 50));
            e.Graphics.FillRectangle(b3, sq3);//上色

            e.Graphics.DrawRectangle(pen1, sq4); // 繪出矩形
            Brush b4 = new SolidBrush(Color.FromArgb(4, 131, 250));
            e.Graphics.FillRectangle(b4, sq4);//上色

            e.Graphics.DrawRectangle(pen1, sq5); // 繪出矩形
            Brush b5 = new SolidBrush(Color.FromArgb(18, 213, 222));
            e.Graphics.FillRectangle(b5, sq5);//上色

            e.Graphics.DrawRectangle(pen1, sq6); // 繪出矩形
            Brush b6 = new SolidBrush(Color.FromArgb(78, 133, 120));
            e.Graphics.FillRectangle(b6, sq6);//上色

            e.Graphics.DrawRectangle(pen1, sq7); // 繪出矩形
            Brush b7 = new SolidBrush(Color.FromArgb(143, 213, 10));
            e.Graphics.FillRectangle(b7, sq7);//上色

            e.Graphics.DrawRectangle(pen1, sq8); // 繪出矩形
            Brush b8 = new SolidBrush(Color.FromArgb(17, 32, 110));
            e.Graphics.FillRectangle(b8, sq8);//上色

            e.Graphics.DrawRectangle(pen1, sq9); // 繪出矩形
            Brush b9 = new SolidBrush(Color.FromArgb(120, 113, 10));
            e.Graphics.FillRectangle(b9, sq9);//上色

        }
    }
}
