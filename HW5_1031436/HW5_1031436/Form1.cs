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
namespace HW5_1031436
{
    public partial class Form1 : Form
    {
        int index = 0;
        Bitmap bm = new Bitmap(Properties.Resources._8_0);
        Bitmap bm1 = new Bitmap(Properties.Resources._8_1);
        Bitmap bm2 = new Bitmap(Properties.Resources._8_2);
        Bitmap bm3 = new Bitmap(Properties.Resources._8_3);
        Bitmap bm4 = new Bitmap(Properties.Resources._8_4);
        Bitmap bm5 = new Bitmap(Properties.Resources._8_5);
        Bitmap bm6 = new Bitmap(Properties.Resources._8_6);
        Bitmap bm7 = new Bitmap(Properties.Resources._8_7);
        Bitmap bm8 = new Bitmap(Properties.Resources._8_8);
        int[] isflopped = new int[16];//已被點選
        int[] twice = new int[8];//確認每張圖都出現兩次
        Rectangle[] back = new Rectangle[16];//畫範圍
        Bitmap[] bmmap = new Bitmap[8];//圖片陣列
        TextureBrush[] rTB = new TextureBrush[16];//16格的筆刷
        int[] rTBV = new int[16];//記應對的圖片
        TextureBrush myBrush;
        int counter = 0;//記點擊次數
        int[] match = new int[2];//記圖片一不一樣
        int[] pos = new int[2];//記九宮格位置一不一樣

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            initial();
        }

        int time1 =0,time3 = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            time1 += 1;
            label1.Text = "Time: " + time1;
        }
        
        private void timer3_Tick(object sender, EventArgs e)
        {
            time3 ++;
            if (time3 > 1)
            {
                time3 = 0;
                this.Invalidate();
                Console.WriteLine("time3tick 呼叫paint " + index);
                timer3.Stop();


            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            counter = 0;
            match[0] = -1;
            match[1] = -1;
            pos[0] = -1;
            pos[1] = -1;

            Graphics gr = this.CreateGraphics();
            Console.WriteLine("呼叫paint "+index);
            for (int i = 0; i < index; i++) {
                 if (isflopped[i] == 1)
                    {
                        gr.DrawRectangle(pen1, back[0]); // 繪出矩形
                        gr.FillRectangle(rTB[i], back[i]);
                    }
                else {
                    gr.DrawRectangle(pen1, back[i]);
                    e.Graphics.FillRectangle(myBrush, back[i]);
                }
            }
        }

        Pen pen1;
        
        public Form1()
        {
            InitializeComponent();
            Graphics gr = this.CreateGraphics();
            myBrush = new TextureBrush(bm);
            pen1 = new Pen(Color.Black, 3);
            bmmap = new Bitmap[8] { bm1, bm2, bm3, bm4, bm5, bm6, bm7, bm8 };
        }

        private int checkisTwice(int time)
        {
            //亂數生成順序加檢查是否出現兩次
            int r;
            Random rd = new Random(Guid.NewGuid().GetHashCode());
            r = rd.Next(100); //產生0~8的亂數
            r = r % 8;
            twice[r]++;
            while (twice[r] > 2) {
                Console.WriteLine("void檢查r" + r);
                twice[r]--;
                r = rd.Next(1500); //產生0~8的亂數
                r = r % 8;
                twice[r]++;
            }
            return r;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Graphics gr = this.CreateGraphics();
            
            for (int i = 0; i < 16; i++){

                if (counter == 2)
                {
                    if (match[0] == match[1])
                    {
                        Console.WriteLine("counter 3 :" + counter);
                        isflopped[pos[0]] = 1;
                        isflopped[pos[1]] = 1;
                        label1.Text = "Compare Success !";
                        isOver();
                        Console.WriteLine("配對成功呼叫 " + index);
                        this.Invalidate();
                    }
                    else
                    {
                        timer3.Start();
                    }

                }
                if (back[i].Contains(e.Location))
                {
                    if (counter < 2)
                    {
                        gr.DrawRectangle(pen1, back[i]); // 繪出矩形
                        gr.FillRectangle(rTB[i], back[i]);
                        match[counter] = rTBV[i];
                        pos[counter] = i;
                        ++counter;
                    }
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(500, 500);
            //計總時間
            timer1.Interval = 1000;
            timer1.Start();

            //計時翻卡
            timer3.Interval = 1000;
            initial();
        }
        private void isOver() {
            label1.Text = "isOver?";
            for (int i = 0; i < index; i++)
            {
                if (isflopped[i] == 0) return;
            }
            timer1.Stop();
            label1.Text = "Time: " + time1.ToString();
            counter = 2;
        }
        private void initial() {
            TextureBrush tmpBrush;
            time1 = 0;
            time3 = 0;
            index = 0;
            for (int i = 0; i < 4; i++)
            {
                // Console.WriteLine("建圖的for" + index);
                for (int j = 0; j < 4; j++)
                    back[index++] = new Rectangle(bm.Height * i, bm.Width * j, bm.Width, bm.Height);
            }
            for (int i = 0; i < 16; i++)
                isflopped[i] = 0;
            for (int i = 0; i < 8; i++)
                twice[i] = 0;
            for (int i = 0; i < 16; i++)
            {
                int value = checkisTwice(i);
                Console.WriteLine("檢查圖" + value);
                tmpBrush = new TextureBrush(bmmap[value]);
                rTB[i] = tmpBrush;
                rTBV[i] = value;
            }
            for (int i = 0; i < 16; i++)
            {
                Console.WriteLine("檢查圖 twice " + rTBV[i] + " ");

            }
            this.Invalidate();
            timer1.Start();
        }
    }
}
