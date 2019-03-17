using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScanFolder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "ScanFolder";
            label1.Text = "Выберите папку!";
            button1.Text = "Выбрать папку";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string Path;
            OpenFileDialog FD = new OpenFileDialog();
            FolderBrowserDialog FB = new FolderBrowserDialog();
            FB.ShowDialog();
            Path = FB.SelectedPath;
            //FD.ShowDialog();
            //Path = FD.FileName;
            if(Path!=null&&Path!="")
            {
                ScanFolder.StartScan(Path);
                label1.Text = "Список содержимого создан!";
            }            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            ScanFolder.Close();
        }
    }
}
