using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace plagiarism_checker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label2.Hide();
        }

        //[1]inserting first file
        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Text Documents.txt|*", ValidateNames = true, Multiselect = false })
                if ( ofd.ShowDialog()==DialogResult.OK)
                {
                    using (StreamReader sr = new StreamReader(ofd.FileName))
                        
                    richTextBox1.Text = sr.ReadToEnd();

                }
        }
       
        //[2]insering  second file
        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd2 = new OpenFileDialog() { Filter = "Text Documents.txt|*", ValidateNames = true, Multiselect = false })
                if (ofd2.ShowDialog() == DialogResult.OK)
                {
                    using (StreamReader sr = new StreamReader(ofd2.FileName))

                        richTextBox2.Text = sr.ReadToEnd();

                }
        }
        //comaparing beween both text files
        private void button3_Click(object sender, EventArgs e)
        {
            
            
            //label2.Text = "Similaty checker takes seconds";
            label2.Show();

            string[] words_one = Regex.Split(richTextBox1.Text, @"\W+");
            string[] words_two = Regex.Split(richTextBox2.Text, @"\W+");

            words_one = words_one.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            words_two = words_two.Where(x => !string.IsNullOrEmpty(x)).ToArray();

            Dictionary<string, double> counter1 = new Dictionary<string, double>();
            Dictionary<string, double> counter2 = new Dictionary<string, double>();

            foreach (string word in words_one)
            {
                string x = word.ToLower();
                if (counter1.TryGetValue(x, out double count))
                {
                    if (count < 100000) counter1[x] = count + 1;
                }
                else
                {
                    counter1[x] = 1;
                }
            }

            foreach (string word in words_two)
            {
                string x = word.ToLower();
                if (counter2.TryGetValue(x, out double count))
                {
                    if (count < 100000) counter2[x] = count + 1;
                }
                else
                {
                    counter2[x] = 1;
                }
            }

            double dotx = 0;
            double squaredabsolute1 = 0;
            double squaredabsolute2 = 0;

            foreach (KeyValuePair<string, double> R in counter1)
            {
                if (counter2.TryGetValue(R.Key, out double count))
                {
                    dotx += R.Value * count;
                }
                squaredabsolute1 += R.Value * R.Value;
            }

            foreach (KeyValuePair<string, double> R in counter2)
            {
                squaredabsolute2 += R.Value * R.Value;
            }

            double cosangle = dotx / Math.Sqrt(squaredabsolute1 * squaredabsolute2);
            double angle = Math.Acos(cosangle);
            angle = angle * 180 / Math.PI;
            angle = 90 - angle;
            angle = (angle / 90) * 100;
            angle = (int)angle;
            if (angle < 0) label2.Text = "Please Insert Both Text Files";
            else {
                string theta = angle.ToString();
                if (theta == "Nan") label2.Text = "Please Insert Both Text Files";
                else
                label2.Text = theta+'%';
            }
            

            

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = " ";
            label2.Text = " ";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = " ";
            label2.Text = " ";
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.ReadOnly = true;
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            richTextBox2.ReadOnly = true;
        }
    }
}
