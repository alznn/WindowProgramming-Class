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
using System.IO;


namespace HW3_1031436
{
    public partial class Form1 : Form
    {
        List<Point> startPt = new List<Point>();
        List<Point> endPt = new List<Point>();
        List<Pen> pen = new List<Pen>();
        List<int> penStyle = new List<int>();
        Color colors;
        int width = 1;
        int LineSolid = 1;
        public Form1()
        {
            InitializeComponent();
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colors = Color.Red;
            redToolStripMenuItem.Checked = true;
            greenToolStripMenuItem.Checked = false;
            blueToolStripMenuItem.Checked = false;
            Pen pen1 = new Pen(colors, width);
        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colors = Color.Green;
            redToolStripMenuItem.Checked = false;
            greenToolStripMenuItem.Checked = true;
            blueToolStripMenuItem.Checked = false;
            
        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colors = Color.Blue;
            redToolStripMenuItem.Checked = false;
            greenToolStripMenuItem.Checked = false;
            blueToolStripMenuItem.Checked = true;
        }
        
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            System.Console.WriteLine("SOLID??  " + penStyle.Count());
            for (int i = 0; i < endPt.Count(); i++)
            {
                
                if (penStyle[i] == 1)
                {
                    pen[i].DashStyle = DashStyle.Solid;
                    e.Graphics.DrawLine(pen[i], startPt[i].X, startPt[i].Y, endPt[i].X, endPt[i].Y);
                }
                else if(penStyle[i] == 0)
                {
                    pen[i].DashStyle = DashStyle.Dash;
                    e.Graphics.DrawLine(pen[i], startPt[i].X, startPt[i].Y, endPt[i].X, endPt[i].Y);
                }
               
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            startPt.Add(e.Location);
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            Pen pen1 = new Pen(colors, width);
            pen.Add(pen1);
            penStyle.Add(LineSolid);
            endPt.Add(e.Location);
            this.Invalidate();

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            width = 1;
            toolStripMenuItem2.Checked = true;
            toolStripMenuItem3.Checked = false;
            toolStripMenuItem4.Checked = false;
            toolStripMenuItem5.Checked = false;
            toolStripMenuItem6.Checked = false;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            width = 2;
            toolStripMenuItem2.Checked = false;
            toolStripMenuItem3.Checked = true;
            toolStripMenuItem4.Checked = false;
            toolStripMenuItem5.Checked = false;
            toolStripMenuItem6.Checked = false;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            width = 3;
            toolStripMenuItem2.Checked = false;
            toolStripMenuItem3.Checked = false;
            toolStripMenuItem4.Checked = true;
            toolStripMenuItem5.Checked = false;
            toolStripMenuItem6.Checked = false;
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            width = 4;
            toolStripMenuItem2.Checked = false;
            toolStripMenuItem3.Checked = false;
            toolStripMenuItem4.Checked = false;
            toolStripMenuItem5.Checked = true;
            toolStripMenuItem6.Checked = false;
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            width = 5;
            toolStripMenuItem2.Checked = false;
            toolStripMenuItem3.Checked = false;
            toolStripMenuItem4.Checked = false;
            toolStripMenuItem5.Checked = false;
            toolStripMenuItem6.Checked = true;
        }

        private void solidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LineSolid = 1;
            solidToolStripMenuItem.Checked = true;
            dashToolStripMenuItem.Checked = false;
        }

        private void dashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LineSolid = 0;
            solidToolStripMenuItem.Checked = false;
            dashToolStripMenuItem.Checked = true;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                String s = saveFileDialog1.FileName;
                BinaryWriter outFile = new BinaryWriter(File.Open(s, FileMode.Create));
                outFile.Write(endPt.Count());
                for (int i = 0; i < endPt.Count(); i++) {
                    Int32 width = Convert.ToInt32(pen[i].Width);
                    
                    if (pen[i].Color.Name == "Red")
                    {
                        outFile.Write(1);
                        outFile.Write(width);
                        System.Console.WriteLine("R: " + 1);
                        System.Console.WriteLine("\n\nTOWidth: " + width);

                        Int32 SolidOrNot = Convert.ToInt32(penStyle[i]);
                        outFile.Write(SolidOrNot);

                        System.Console.WriteLine("\n\nToStyle" + SolidOrNot);

                        outFile.Write(startPt[i].X);
                        System.Console.WriteLine(startPt[i].X);
                        outFile.Write(startPt[i].Y);
                        System.Console.WriteLine(startPt[i].Y);
                        outFile.Write(endPt[i].X);
                        System.Console.WriteLine("\n" + endPt[i].X);
                        outFile.Write(endPt[i].Y);
                        System.Console.WriteLine("\n" + endPt[i].Y);
                    }
                    else if (pen[i].Color.Name == "Green")
                    {
                        outFile.Write(2);
                        outFile.Write(width);
                        System.Console.WriteLine("G: " + 2);
                        System.Console.WriteLine("\n\nTOWidth: " + width);

                        Int32 SolidOrNot = Convert.ToInt32(penStyle[i]);
                        outFile.Write(SolidOrNot);

                        System.Console.WriteLine("\n\nToStyle" + SolidOrNot);

                        outFile.Write(startPt[i].X);
                        System.Console.WriteLine(startPt[i].X);
                        outFile.Write(startPt[i].Y);
                        System.Console.WriteLine(startPt[i].Y);
                        outFile.Write(endPt[i].X);
                        System.Console.WriteLine("\n" + endPt[i].X);
                        outFile.Write(endPt[i].Y);
                        System.Console.WriteLine("\n" + endPt[i].Y);
                    }
                    else if (pen[i].Color.Name == "Blue")
                    {
                        outFile.Write(3);
                        outFile.Write(width);
                        System.Console.WriteLine("B: " + 3);
                        System.Console.WriteLine("\n\nTOWidth: " + width);

                        Int32 SolidOrNot = Convert.ToInt32(penStyle[i]);
                        outFile.Write(SolidOrNot);

                        System.Console.WriteLine("\n\nToStyle" + SolidOrNot);

                        outFile.Write(startPt[i].X);
                        System.Console.WriteLine(startPt[i].X);
                        outFile.Write(startPt[i].Y);
                        System.Console.WriteLine(startPt[i].Y);
                        outFile.Write(endPt[i].X);
                        System.Console.WriteLine("\n" + endPt[i].X);
                        outFile.Write(endPt[i].Y);
                        System.Console.WriteLine("\n" + endPt[i].Y);
                    }
                }
                outFile.Close();
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK){
                String s = openFileDialog1.FileName;
                if (!File.Exists(s)) return;
                BinaryReader inFile = new BinaryReader(File.Open(s, FileMode.Open));
                startPt.Clear();
                endPt.Clear();
                pen.Clear();
                penStyle.Clear();
                int num = inFile.ReadInt32();
                System.Console.WriteLine("\nnum: " + num);
                for (int i = 0; i < num; i++) {

                    System.Console.WriteLine("\n now I is: " + i);
                    int c = inFile.ReadInt32();
                    System.Console.WriteLine("\n now C is: " + c);

                    if (c == 1)
                    {
                        int w = inFile.ReadInt32();
                        int sd = inFile.ReadInt32();
                        pen.Add(new Pen(Color.Red, w));
                        penStyle.Add(sd);
                        startPt.Add(new Point(inFile.ReadInt32(), inFile.ReadInt32()));
                        //System.Console.WriteLine("X " + inFile.ReadInt32());
                        endPt.Add(new Point(inFile.ReadInt32(), inFile.ReadInt32()));
                        continue;
                    }
                    if (c == 2)
                    {
                        int w = inFile.ReadInt32();
                        int sd = inFile.ReadInt32();
                        pen.Add(new Pen(Color.Green, w));
                        penStyle.Add(sd);
                        startPt.Add(new Point(inFile.ReadInt32(), inFile.ReadInt32()));
                        //System.Console.WriteLine("X " + inFile.ReadInt32());
                        endPt.Add(new Point(inFile.ReadInt32(), inFile.ReadInt32()));
                        continue;
                    }
                    if (c == 3)
                    {
                        int w = inFile.ReadInt32();
                        int sd = inFile.ReadInt32();
                        pen.Add(new Pen(Color.Blue, w));
                        penStyle.Add(sd);
                        startPt.Add(new Point(inFile.ReadInt32(), inFile.ReadInt32()));
                        endPt.Add(new Point(inFile.ReadInt32(), inFile.ReadInt32()));
                        continue;
                    }
                }
                this.Invalidate();
                inFile.Close();
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startPt.Clear();
            endPt.Clear();
            penStyle.Clear();
            pen.Clear();
            this.Invalidate();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "線段檔(*pnt)|*.pnt";
            saveFileDialog1.Filter = "線段檔(*pnt)|*.pnt";
        }
    }
}
