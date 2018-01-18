using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW6_1031436
{
    public partial class Form1 : Form
    {
        Bitmap bm = new Bitmap(Properties.Resources.Bowl);
        Point pos = new Point(); // 碗的位置

        Bitmap img, imgClone; //  背景影像
        int time1 = 0; //記錄換背景時間

        Bitmap fr1 = new Bitmap(Properties.Resources.Tomato);
        Bitmap fr2 = new Bitmap(Properties.Resources.Banana);
        Bitmap fr3 = new Bitmap(Properties.Resources.StawBerry);
        Point pos1 = new Point(); // 水果的位置
        Point pos2 = new Point(); // 水果的位置
        Point pos3 = new Point(); // 水果的位置
        Bitmap[] bmmap = new Bitmap[3];//圖片陣列
        int count = 0; //水果
        int time2 = 120; //紀錄總時間
        public Form1()
        {
            InitializeComponent();
            
            DoubleBuffered = true;
            img = new Bitmap(Properties.Resources.FB_IMG_1435904287732);
            bmmap = new Bitmap[3] { fr1, fr2, fr3};
            bgImageClone();
            fruit1Down();
            fruit2Down();
            fruit3Down();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time1++;
            if (time1 % 30 < 10) {
                img = Properties.Resources.FB_IMG_1435904287732;
            }
            if (time1 % 30 > 10 && time1 % 30 < 20)
            {
                img = Properties.Resources.FB_IMG_1435904291521;
            }
            if (time1 % 30 > 20 && time1 % 30 < 30)
            {
                img = Properties.Resources.FB_IMG_1435904296642;
            }
            bgImageClone();
            this.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(imgClone.Width*2, imgClone.Height+100);
            //計換背景
            timer1.Interval = 1000;
            timer1.Start();

            //倒數計時
            timer2.Interval = 1000;
            timer2.Start();

            //掉水果
            timer3.Interval = 1;
            timer3.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            time2--;
            if (time2 == 0)
            {
                label1.Text = "Time's UP";
                label2.Text = "The fruit you catch is " + count;
                pos1 = new Point(0, 0);
                pos2 = new Point(0, 0);
                pos3 = new Point(0, 0);
                timer1.Stop();
                timer2.Stop();
                timer3.Stop();
            }
            else
            {
                label1.Text = "Time : " + time2 + "seconds";
                label2.Text = "Recieved: " + count;

            }
            this.Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            TextureBrush bg = new TextureBrush(imgClone);
            e.Graphics.FillRectangle(bg, 0, 0, imgClone.Width*2, imgClone.Height); // 繪出圖形
            
            e.Graphics.TranslateTransform(pos1.X, pos1.Y);
            TextureBrush frb1 = new TextureBrush(fr1);
            e.Graphics.FillRectangle(frb1, 0, 0, fr1.Width, fr1.Height); // 繪出圖形
            
            e.Graphics.ResetTransform();
            e.Graphics.TranslateTransform(pos2.X, pos2.Y);
            TextureBrush frb2 = new TextureBrush(fr2);
            e.Graphics.FillRectangle(frb2, 0, 0, fr2.Width, fr2.Height); // 繪出圖形

            e.Graphics.ResetTransform();
            e.Graphics.TranslateTransform(pos3.X, pos3.Y);
            TextureBrush frb3 = new TextureBrush(fr3);
            e.Graphics.FillRectangle(frb3, 0, 0, fr3.Width, fr3.Height); // 繪出圖形
            
            e.Graphics.ResetTransform();
            e.Graphics.TranslateTransform(x, 400);
            TextureBrush tb = new TextureBrush(bm);
            e.Graphics.FillRectangle(tb, 0,0, bm.Width, bm.Height); // 繪出圖形
        }
        int time3 = 0;
        private void timer3_Tick(object sender, EventArgs e)
        {
            time3++;
            pos1 = new Point(pos1.X, pos1.Y + time3 % 5);
            pos2 = new Point(pos2.X, pos2.Y + time3 % 5);
            pos3 = new Point(pos3.X, pos3.Y + time3 % 5);
            check();
            this.Invalidate();
        }
        int x = 0;
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Location.X > imgClone.Width * 2 - 70) {
                x = imgClone.Width * 2 - 70;
//                pos = new Point(imgClone.Width * 2-70, 800);
            }
            else if (pos.X < 0) x = 0;// pos = new Point(0, 800);
            else x = e.Location.X; //pos = new Point(e.Location.X, 800);

            this.Invalidate();
        }

        void check() {
            if (pos1.Y >= 400) {
                if (pos1.X - x > 35 || x - pos1.X > 35)
                {
                    fruit1Down();
                }
                else
                {
                    count += 1;
                    fruit1Down();
                }
            }
            if (pos2.Y >= 400)
            {
                if (pos2.X - x > 35 || x - pos2.X > 35)
                {
                    fruit2Down();
                }
                else
                {
                    count += 1;
                    fruit2Down();
                }
            }
            if (pos3.Y >= 400)
            {
                if (pos3.X - x > 35 || x - pos3.X > 35)
                {
                    fruit3Down();
                }
                else
                {
                    count += 1;
                    fruit3Down();
                }
            }
        }
        

        //-------------------------------------------------------------
        //重新生成位置
        void fruit1Down() {
            int acc;
            Random rd = new Random(Guid.NewGuid().GetHashCode());
            int r = rd.Next(100); //產生0~8的亂數
            int px = rd.Next(1000000);
            acc = rd.Next(100);
            pos1 = new Point(px%img.Width, 0);
        }
        void fruit2Down()
        {
            int acc;
            Random rd = new Random(Guid.NewGuid().GetHashCode());
            int r = rd.Next(100); //產生0~8的亂數
            int px = rd.Next(400000000);
            acc = rd.Next(100);
            pos2 = new Point(px % img.Width, 10);
        }
        void fruit3Down()
        {
            int acc;
            Random rd = new Random(Guid.NewGuid().GetHashCode());
            int r = rd.Next(100); //產生0~8的亂數
            int px = rd.Next(5000000);
            acc = rd.Next(100);
            pos3 = new Point(px % img.Width, 10);
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            count = 0;
            time1 = 0;
            time2 = 120;
            time3 = 0;
            label1.Text = "Time : " + time2 + "seconds";
            label2.Text = "Recieved: " + count;
            fruit1Down();
            fruit2Down();
            fruit3Down();

            DoubleBuffered = true;
            img = new Bitmap(Properties.Resources.FB_IMG_1435904287732);
            bgImageClone();

            timer1.Start();
            timer2.Start();
            timer3.Start();
        }

        //-----------------------------------------------------------
        void bgImageClone()
        {
            imgClone = (Bitmap)img.Clone();
            int x, y;
            // 重設 img 的 圖素
            for (x = 0; x < imgClone.Width; x++)
            {
                for (y = 0; y < imgClone.Height; y++)
                {
                    Color pixelColor = imgClone.GetPixel(x, y); // 得到圖素
                    Color newColor = pixelColor;
                    newColor = Color.FromArgb(pixelColor.A / 2, pixelColor.R / 2, pixelColor.G / 2, pixelColor.B / 2);
                    imgClone.SetPixel(x, y, newColor); // 設定圖素
                }
            }
        }

    }

}
