using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW8_1031436
{
    public partial class Form1 : Form
    {
        double final = 0.0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'studentRecordsDataSet.StudentRecords' 資料表。您可以視需要進行移動或移除。
            this.studentRecordsTableAdapter.Fill(this.studentRecordsDataSet.StudentRecords);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((this.studentRecordsBindingSource.Find("StudentId", textBox1.Text)) != -1)
            {
                MessageBox.Show("This ID exists!");
            }
            else
            {
                this.studentRecordsTableAdapter.Insert(textBox1.Text, textBox2.Text,comboBox1.Text, Int32.Parse(textBox3.Text), Int32.Parse(textBox4.Text));
                this.studentRecordsTableAdapter.Fill(this.studentRecordsDataSet.StudentRecords);
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            final = (Convert.ToDouble(textBox3.Text) + Convert.ToDouble(textBox4.Text)) / 2;
            label8.Text = final.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.studentRecordsBindingSource.EndEdit();
            this.studentRecordsTableAdapter.Update(this.studentRecordsDataSet);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.studentRecordsTableAdapter.Delete(textBox1.Text, textBox2.Text, comboBox1.Text, Int32.Parse(textBox3.Text), Int32.Parse(textBox4.Text));
            this.studentRecordsTableAdapter.Fill(this.studentRecordsDataSet.StudentRecords);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int i = -1;
            switch (comboBox2.Text)
            {
                case "ID":
                    i = this.studentRecordsBindingSource.Find("StudentId", textBox5.Text);
                    break;
                case "Name":
                    i = this.studentRecordsBindingSource.Find("StudentName", textBox5.Text);
                    break;
                case "Gender":
                    i = this.studentRecordsBindingSource.Find("Gender", textBox5.Text);
                    break;
                case "Midterm":
                    i = this.studentRecordsBindingSource.Find("MidExam", textBox5.Text);
                    if (i < 0 || i >100)
                        MessageBox.Show("Incorrect Score!");
                    break;
                case "FinalExam":
                    i = this.studentRecordsBindingSource.Find("FinalExam", textBox5.Text);
                    if (i < 0 || i > 100)
                        MessageBox.Show("Incorrect Score!");
                    break;
            }
            if (i != -1)
                this.studentRecordsBindingSource.Position = i;
            else
                MessageBox.Show("Not found!");
        }
    }
}
