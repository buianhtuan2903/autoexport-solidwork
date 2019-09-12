using System;
using System.Windows;
using System.Windows.Controls;
using System.Threading;
using System.Windows.Threading;
using System.Windows.Forms;
using System.ComponentModel;
using System.Windows.Media.Animation;
using System.Windows.Data;
using System.Threading.Tasks;

namespace Autoexport
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        string value1;
        string value2;
        string value3;
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Setting end day trial
            if (DateTime.Now.ToOADate() >= 43800)
            {
                textBox2.IsEnabled = false;
                button1.IsEnabled = false;
                button2.IsEnabled = false;
                button3.IsEnabled = false;
                textBlock.IsEnabled = false;
                textBox1.IsEnabled = false;
                System.Windows.MessageBox.Show("Your free trial has ended. Please contact buianhtuan2903@gmail.com for purchase license");
            }
        }

        public void button1_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog openfolder = new System.Windows.Forms.FolderBrowserDialog();
            if (openfolder.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string folderitem = openfolder.SelectedPath;
                textBox2.Text = folderitem;
                this.value2 = folderitem;
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            listBox1.Items.Clear();
            ProgressBar1.Value = 0;
            System.Windows.Forms.OpenFileDialog openfile = new System.Windows.Forms.OpenFileDialog();
            openfile.Multiselect = true;
            if (openfile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ProgressBar1.Maximum = openfile.FileNames.Length;
                textBox1.Text = openfile.SafeFileNames.Length.ToString();
                foreach (string fileitem in openfile.FileNames)
                {
                    listBox1.Items.Add(fileitem);
                } 
            }
            else
            {
                System.Windows.MessageBox.Show("Please choose files");
            }
        }

        private async void button3_Click(object sender, RoutedEventArgs e)
        {
            for (int  i = 0; i < listBox1.Items.Count; i++)
            {
                Export Runcode = new Export();
                this.value1 = listBox1.Items[i].ToString();
                this.value3 = System.IO.Path.GetFileNameWithoutExtension(listBox1.Items[i].ToString());
                Runcode.transfer(value1, value2, value3);
                this.ProgressBar1.Value = i + 1;
                System.Threading.Thread.Sleep(100);
                textBlock.Text = "Working...("+ ProgressBar1.Value.ToString() + ")";
                await Task.Delay(10);
            }
            textBlock.Text = "Finished";
        }
    }
}


