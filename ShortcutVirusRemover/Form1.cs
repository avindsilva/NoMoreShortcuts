using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ShortcutVirusRemover
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void loadDrives()
        {
            comboBox1.Items.Clear();
            int i = 0;
            string drive;
            try
            {
                DriveInfo[] di = DriveInfo.GetDrives();

                foreach (string drives in Environment.GetLogicalDrives())
                {
                    comboBox1.Items.Insert(i++,drives);
                }
            }
            catch (DriveNotFoundException d)
            {
                Console.WriteLine("Message : {0}", d.Message);
            }
            catch (IOException ex)
            {
                Console.WriteLine("Message : {0}", ex.Message);
            }
                
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadDrives();          
        }

       private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
       {
            
       }

       private void button2_Click(object sender, EventArgs e)
       {
           FolderBrowserDialog x = new FolderBrowserDialog();
           x.ShowDialog();
           string selected_path = x.SelectedPath;
           textBox1.Text = selected_path;
       }

       private void button1_Click(object sender, EventArgs e)
       {
           string command = null;
           
           if (radioButton1.Checked == true)
               command = "attrib -S -H " + textBox1.Text + "*.*" + " /s /d";
           if(radioButton2.Checked == true)
              command = "attrib -S -H " + textBox1.Text + " /s /d";

           System.Diagnostics.ProcessStartInfo procStart = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + command);
           //procStart.CreateNoWindow = true;
           MessageBox.Show("Shortcut Virus removed!");

       }

       private void button3_Click(object sender, EventArgs e)
        {
            loadDrives();
        }

       private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
       {
           comboBox1.Visible = true;
           button3.Visible = true;

           textBox1.Visible = false;
           button2.Visible = false;

       }

       private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
       {
           comboBox1.Visible = false;
           button3.Visible = false;

           textBox1.Visible = true;
           button2.Visible = true;
       }

       private void button1_Click_1(object sender, EventArgs e)
       {
           string command = null;

           if (radioButton1.Checked == true)
               command = "-S -H " + comboBox1.Text + "*.*" + " /s /d";
           if (radioButton2.Checked == true)
               command = "-S -H " + textBox1.Text + " /s /d";
           
           Console.WriteLine(command);

           //System.Diagnostics.Process process = new System.Diagnostics.Process();
           //System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
           //startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
           //startInfo.FileName = "attrib.exe";
           //startInfo.Arguments = command;
           //process.StartInfo = startInfo;
           //process.Start();

           System.Diagnostics.Process.Start("attrib.exe", command);
           MessageBox.Show("Congratulations! The Shortcut Virus has been removed.\n Your will find your files in folder without a name on your device. ");

       }

       private void button2_Click_1(object sender, EventArgs e)
       {
           FolderBrowserDialog x = new FolderBrowserDialog();
           x.ShowDialog();
           string selected_path = x.SelectedPath;
           textBox1.Text = selected_path;
       }

       private void label3_Click(object sender, EventArgs e)
       {

       }
      
    }
}
