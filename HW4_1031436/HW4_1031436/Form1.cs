using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW4_1031436
{
    public partial class Form1 : Form
    {
        Rectangle rect; // 矩形區域
        int tab_pos = 10;
        int ballposX = 20;
        int ballposY = 50;
        int accX = 5;
        int accY = 3;
        int time = 0;
        Color Cball = Color.Red;
        public Form1()
        {
            InitializeComponent();
            rect = new Rectangle(10, 50, 218 , 300); // 畫矩形區域       
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 100;
            timer1.Start();
            timer2.Interval = 1000;
            timer2.Start();

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Brush myBrush = new SolidBrush(Color.Red); // 紅色的單色塗刷
            Brush BrushBall = new SolidBrush(Cball); // Ball的單色塗刷
            e.Graphics.DrawRectangle(Pens.Black, rect); // 繪出矩形
            e.Graphics.FillRectangle(myBrush, tab_pos, 351, 30, 15); // 填一個tab
            e.Graphics.FillEllipse(BrushBall, ballposX, ballposY, 15, 15); // 填一個ball
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //Red
            Cball = Color.Red;
            this.Invalidate();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //Blue
            Cball = Color.Blue;
            this.Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            StatusLabel2.Text = "playing";
            if ((ballposX + accX) < 10 || (ballposX + accX) > 200)
            {
                accX = -accX;
            }
            else ballposX += accX;
            if ((ballposY + accY) > 335 || (ballposY + accY) < 50)
            {                
                if ((ballposY + accY) < 50) accY = -accY;
                else if ((ballposY + accY) > 335 && ballposX > tab_pos-15 && ballposX < (tab_pos + 25))
                {
                    accY = -accY;
                }
                else
                {
                    ballposY = 335;
                    accX = accY = 0;
                    timer1.Stop();
                    timer2.Stop();
                    StatusLabel2.Text = "lose";
                }
            }
            else
            {
                ballposY += accY;
            }

            TimeLabel1.Text = time.ToString();
            
            this.Invalidate();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            //Green
            Cball = Color.Green;
            this.Invalidate();
        }


        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            tab_pos = e.X;
            if (tab_pos > 200) tab_pos = 200;
            else if (tab_pos < 10) tab_pos = 10;
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ballposX = 20;
            ballposY = 50;
            accX = 5;
            accY = 3;
            time = 0;
            timer1.Start();
            timer2.Start();
            Cball = Color.Red;
            this.Invalidate();
        }
        
        private void timer2_Tick(object sender, EventArgs e)
        {
           time+=1;
            if (time % 5 == 0) {
                if (accX > 0) accX += 1;
                else accX -= 1;
                if (accY > 0) accY += 1;
                else accY -= 1;
            }
        }
    }
}
