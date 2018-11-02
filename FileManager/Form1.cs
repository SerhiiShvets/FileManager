using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            DirectoryInfo directory = new DirectoryInfo(textBox1.Text);

            DirectoryInfo[] directories = directory.GetDirectories();

            foreach (DirectoryInfo dir in directories)
            {
                listBox1.Items.Add(dir);
            }
            FileInfo[] files = directory.GetFiles();

            foreach(FileInfo file in files)
            {
                listBox1.Items.Add(file);
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (Path.GetExtension(Path.Combine(textBox1.Text, listBox1.SelectedItem.ToString())) == "")
            {
                //textBox1.Text = textBox1.Text + "\\" + listBox1.SelectedItem.ToString();
                textBox1.Text = Path.Combine(textBox1.Text, listBox1.SelectedItem.ToString());
                listBox1.Items.Clear();

                DirectoryInfo directory = new DirectoryInfo(textBox1.Text);

                DirectoryInfo[] directories = directory.GetDirectories();

                foreach (DirectoryInfo dir in directories)
                {
                    listBox1.Items.Add(dir);
                }
                FileInfo[] files = directory.GetFiles();

                foreach (FileInfo file in files)
                {
                    listBox1.Items.Add(file);
                }
            }
            else
            {
                Process.Start(Path.Combine(textBox1.Text, listBox1.SelectedItem.ToString()));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text[textBox1.Text.Length - 1] == '\\')
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);

                while (textBox1.Text[textBox1.Text.Length - 1] != '\\')
                {
                    textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
                }
            }
            else
            {
                while (textBox1.Text[textBox1.Text.Length - 1] != '\\')
                {
                    textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
                }
            }

            listBox1.Items.Clear();

            DirectoryInfo directory = new DirectoryInfo(textBox1.Text);

            DirectoryInfo[] directories = directory.GetDirectories();

            foreach (DirectoryInfo dir in directories)
            {
                listBox1.Items.Add(dir);
            }
            FileInfo[] files = directory.GetFiles();

            foreach (FileInfo file in files)
            {
                listBox1.Items.Add(file);
            }
        }
    }
}
