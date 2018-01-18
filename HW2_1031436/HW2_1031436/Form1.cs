using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
namespace HW2_1031436
{
    public partial class Form1 : Form
    {
        int cpr;
        Random rd = new Random();
        int[] score = new int[9];
        Rectangle[] recArray = new Rectangle[9];//畫格子
        List<Rectangle> recList = new List<Rectangle>();
        Pen pen1, pen2;
        static private int[,] Win = new int[,]//二維陣列
        {
            {0,1,2},
            {3,4,5},
            {6,7,8},
            {0,3,6},
            {1,4,7},
            {2,5,8},
            {0,4,8},
            {2,4,6}
   };
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            
            Graphics gr = this.CreateGraphics();
            if (recList[0].Contains(e.Location))
            {
                if (score[0] == 100 || score[0] == -100)
                {
                    label1.Text = "is chosen";
                }

                else
                {
                    gr.DrawEllipse(pen2, recList[0].X + 10, recList[0].Y + 10, 40, 40);
                    score[0] = 100;
                    cpr = CheckSum(0);
                    if (score[cpr] == -100 || score[cpr] == 100)
                    {
                        cpr = rd.Next(9);
                    }
                    else
                    {
                        gr.DrawLine(new Pen(Color.Blue, 3), recList[cpr].X + 10, recList[cpr].Y + 10, recList[cpr].X + 50, recList[cpr].Y + 50);
                        gr.DrawLine(new Pen(Color.Blue, 3), recList[cpr].X + 50, recList[cpr].Y + 10, recList[cpr].X + 10, recList[cpr].Y + 50);
                        score[cpr] = -100;
                        cpr = CheckSum(cpr);
                    }

                }
            }
            else if (recList[1].Contains(e.Location))
            {
                if (score[1] == 100 || score[1] == -100)
                {
                    label1.Text = "is chosen";
                }

                else
                {
                    gr.DrawEllipse(pen2, recList[1].X + 10, recList[1].Y + 10, 40, 40);
                    score[1] = 100;
                    cpr = CheckSum(1);
                    Console.WriteLine("MAX: " + cpr);
                    if (score[cpr] == -100 || score[cpr] == 100)
                    {
                        cpr = rd.Next(cpr);
                    }
                    else
                    {
                        gr.DrawLine(new Pen(Color.Blue, 3), recList[cpr].X + 10, recList[cpr].Y + 10, recList[cpr].X + 50, recList[cpr].Y + 50);
                        gr.DrawLine(new Pen(Color.Blue, 3), recList[cpr].X + 50, recList[cpr].Y + 10, recList[cpr].X + 10, recList[cpr].Y + 50);
                        score[cpr] = -100;
                        cpr = CheckSum(cpr);
                    }

                }
            }
            else if (recList[2].Contains(e.Location))
            {
                if (score[2] == 100 || score[2] == -100)
                {
                    label1.Text = "is chosen";
                }

                else
                {
                    gr.DrawEllipse(pen2, recList[2].X + 10, recList[2].Y + 10, 40, 40);
                    score[2] = 100;
                    cpr = CheckSum(2);
                    Console.WriteLine("MAX: ", cpr);
                    if (score[cpr] == -100 || score[cpr] == 100)
                    {
                        cpr = rd.Next(cpr);
                    }
                    else
                    {
                        gr.DrawLine(new Pen(Color.Blue, 3), recList[cpr].X + 10, recList[cpr].Y + 10, recList[cpr].X + 50, recList[cpr].Y + 50);
                        gr.DrawLine(new Pen(Color.Blue, 3), recList[cpr].X + 50, recList[cpr].Y + 10, recList[cpr].X + 10, recList[cpr].Y + 50);
                        score[cpr] = -100;

                        Debug.WriteLine("Now CPR is"+cpr);
                        cpr = CheckSum(cpr);
                    }

                }
            }
            else if (recList[3].Contains(e.Location))
            {
                if (score[3] == 100 || score[3] == -100)
                {
                    label1.Text = "is chosen";
                }

                else
                {
                    gr.DrawEllipse(pen2, recList[3].X + 10, recList[3].Y + 10, 40, 40);
                    score[3] = 100;
                    cpr = CheckSum(3);
                    Console.WriteLine("MAX: ", cpr);
                    if (score[cpr] == -100 || score[cpr] == 100)
                    {
                        cpr = rd.Next(cpr);
                    }
                    else
                    {
                        gr.DrawLine(new Pen(Color.Blue, 3), recList[cpr].X + 10, recList[cpr].Y + 10, recList[cpr].X + 50, recList[cpr].Y + 50);
                        gr.DrawLine(new Pen(Color.Blue, 3), recList[cpr].X + 50, recList[cpr].Y + 10, recList[cpr].X + 10, recList[cpr].Y + 50);
                        score[cpr] = -100;
                        cpr = CheckSum(cpr);
                    }
                }
            }
            else if (recList[4].Contains(e.Location))
            {
                if (score[4] == 100 || score[4] == -100)
                {
                    label1.Text = "is chosen";
                }

                else
                {
                    gr.DrawEllipse(pen2, recList[4].X + 10, recList[4].Y + 10, 40, 40);
                    score[4] = 100;
                    cpr = CheckSum(4);
                    Console.WriteLine("MAX: ", cpr);
                    if (score[cpr] == -100 || score[cpr] == 100)
                    {
                        cpr = rd.Next(cpr);
                    }
                    else
                    {
                        gr.DrawLine(new Pen(Color.Blue, 3), recList[cpr].X + 10, recList[cpr].Y + 10, recList[cpr].X + 50, recList[cpr].Y + 50);
                        gr.DrawLine(new Pen(Color.Blue, 3), recList[cpr].X + 50, recList[cpr].Y + 10, recList[cpr].X + 10, recList[cpr].Y + 50);
                        score[cpr] = -100;
                        cpr = CheckSum(cpr);
                    }
                }
            }
            else if (recList[5].Contains(e.Location))
            {
                if (score[5] == 100 || score[5] == -100)
                {
                    label1.Text = "is chosen";
                }

                else
                {
                    gr.DrawEllipse(pen2, recList[5].X + 10, recList[5].Y + 10, 40, 40);
                    score[5] = 100;
                    cpr = CheckSum(5);
                    Console.WriteLine("MAX: ", cpr);
                    if (score[cpr] == -100 || score[cpr] == 100)
                    {
                        cpr = rd.Next(cpr);
                    }
                    else
                    {
                        gr.DrawLine(new Pen(Color.Blue, 3), recList[cpr].X + 10, recList[cpr].Y + 10, recList[cpr].X + 50, recList[cpr].Y + 50);
                        gr.DrawLine(new Pen(Color.Blue, 3), recList[cpr].X + 50, recList[cpr].Y + 10, recList[cpr].X + 10, recList[cpr].Y + 50);
                        score[cpr] = -100;
                        cpr = CheckSum(cpr);
                    }
                }
            }
            else if (recList[6].Contains(e.Location))
            {
                if (score[6] == 100 || score[6] == -100)
                {
                    label1.Text = "is chosen";
                }

                else
                {
                    gr.DrawEllipse(pen2, recList[6].X + 10, recList[6].Y + 10, 40, 40);
                    score[6] = 100;
                    cpr = CheckSum(6);
                    Console.WriteLine("MAX: ", cpr);
                    if (score[cpr] == -100 || score[cpr] == 100)
                    {
                        cpr = rd.Next(cpr);
                    }
                    else
                    {
                        gr.DrawLine(new Pen(Color.Blue, 3), recList[cpr].X + 10, recList[cpr].Y + 10, recList[cpr].X + 50, recList[cpr].Y + 50);
                        gr.DrawLine(new Pen(Color.Blue, 3), recList[cpr].X + 50, recList[cpr].Y + 10, recList[cpr].X + 10, recList[cpr].Y + 50);
                        score[cpr] = -100;
                        cpr = CheckSum(cpr);
                    }
                }
            }
            else if (recList[7].Contains(e.Location))
            {
                if (score[7] == 100 || score[7] == -100)
                {
                    label1.Text = "is chosen";
                }

                else
                {
                    gr.DrawEllipse(pen2, recList[7].X + 10, recList[7].Y + 10, 40, 40);
                    score[7] = 100;
                    cpr = CheckSum(7);
                    Console.WriteLine("MAX: ", cpr);
                    if (score[cpr] == -100 || score[cpr] == 100)
                    {
                        cpr = rd.Next(cpr);
                    }
                    else
                    {
                        gr.DrawLine(new Pen(Color.Blue, 3), recList[cpr].X + 10, recList[cpr].Y + 10, recList[cpr].X + 50, recList[cpr].Y + 50);
                        gr.DrawLine(new Pen(Color.Blue, 3), recList[cpr].X + 50, recList[cpr].Y + 10, recList[cpr].X + 10, recList[cpr].Y + 50);
                        score[cpr] = -100;
                        cpr = CheckSum(cpr);
                    }
                }
            }
            else if (recList[8].Contains(e.Location))
            {
                if (score[8] == 100 || score[8] == -100)
                {
                    label1.Text = "is chosen";
                }

                else
                {
                    gr.DrawEllipse(pen2, recList[8].X + 10, recList[8].Y + 10, 40, 40);
                    score[8] = 100;
                    cpr = CheckSum(8);
                    Console.WriteLine("MAX: ", cpr);
                    if (score[cpr] == -100 || score[cpr] == 100)
                    {
                        cpr = rd.Next(cpr);
                    }
                    else
                    {
                        gr.DrawLine(new Pen(Color.Blue, 3), recList[cpr].X + 10, recList[cpr].Y + 10, recList[cpr].X + 50, recList[cpr].Y + 50);
                        gr.DrawLine(new Pen(Color.Blue, 3), recList[cpr].X + 50, recList[cpr].Y + 10, recList[cpr].X + 10, recList[cpr].Y + 50);
                        score[cpr] = -100;
                        cpr = CheckSum(cpr);
                    }

                }
            }
        }

        private void Form1_Paint_1(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < recList.Count(); i++)
                e.Graphics.DrawRectangle(pen1, recList[i]); // 繪出矩形
        }


        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 9; i++)
                score[i] = 0;
            score[4] = 500;
            recList.Add(new Rectangle(0, 40, 60, 60));
            recList.Add(new Rectangle(60, 40, 60, 60));
            recList.Add(new Rectangle(120, 40, 60, 60));

            recList.Add(new Rectangle(0, 100, 60, 60));
            recList.Add(new Rectangle(60, 100, 60, 60));
            recList.Add(new Rectangle(120, 100, 60, 60));

            recList.Add(new Rectangle(0, 160, 60, 60));
            recList.Add(new Rectangle(60, 160, 60, 60));
            recList.Add(new Rectangle(120, 160, 60, 60));

            pen1 = new Pen(Color.Black, 3);
            pen2 = new Pen(Color.Blue, 5);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(360, 360);
        }

        public int CheckSum(int position)
        {
     
            Console.Write("!!!!!!!!!!!!!!!!!!!!!!" + position+ "!!!!!!!!!!!!!!!!!!!!!!" );
            int max;
            if (isDrawn())
            {
                label1.Text = "Drawn";
            }
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Win[i, j] == position) {
                        if (score[Win[i, 0]] == 100 && score[Win[i, 1]] == 100 && score[Win[i, 2]] == 100)
                        {
                            Graphics g = this.CreateGraphics();
                            g.DrawLine(Pens.Red, recList[Win[i, 0]].X+30, recList[Win[i, 0]].Y + 30, recList[Win[i, 2]].X + 30, recList[Win[i, 2]].Y + 30);
                            label1.Text = "You Win";
                        }
                        else if (score[Win[i, 0]] == -100 && score[Win[i, 1]] == -100 && score[Win[i, 2]] == -100)
                        {
                            Graphics g = this.CreateGraphics();
                            g.DrawLine(Pens.Red, recList[Win[i, 0]].X + 30, recList[Win[i, 0]].Y + 30, recList[Win[i, 2]].X + 30, recList[Win[i, 2]].Y + 30);
                            label1.Text = "You lose";
                        }
                        else
                        {
                            //label1.Text += i + " %% " + j + "\\\\\\";
                            //textBox2.Text += position + "!!!!" + Win[i, 0] + " \\ " + Win[i, 1] + " \\ " + Win[i, 2] + " \\\\\\\\\\\\\\\\ ";
                            if (score[Win[i, 0]] == 100 || score[Win[i, 0]] == -100) { }
                            else {
                                if (i < 3) score[Win[i, 0]] += 200;
                                score[Win[i, 0]] += 200;
                            }
                            if (score[Win[i, 1]] == 100 || score[Win[i, 1]] == -100) { }
                            else
                            {
                                if (i < 3) score[Win[i, 1]] += 200;
                                score[Win[i, 1]] += 200;
                            }
                            if (score[Win[i, 2]] == 100 || score[Win[i, 2]] == -100) { }
                            else
                            {
                                if (i < 3) score[Win[i, 2]] += 200;
                                score[Win[i, 2]] += 200;
                            }
                        }
                    }
                }
            }
            max = 0;
            for (int i = 0; i < 9; i++)
            {
                Console.WriteLine( "\n position:"+i + " " + score[i] + " current max is" + score[max] + "\\\n");
            }
            for (int i = 0; i < 9; i++)
            {
                if (score[i] > score[max]) max = i;
            }
            Console.WriteLine(score[max] + " return value is "+max);
            return max;
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 9; i++)
                score[i] = 0;
            score[4] = 500;
            this.Invalidate();
        }

        public bool isDrawn() {
            for (int i = 0; i < 9; i++)
            {
                if (score[i] == 100 || score[i] == -100) ;
                else return false;
            }
            return true;
        }

    }

}
