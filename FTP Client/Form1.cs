using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace FTP_Client
{
    public partial class Form1 : Form
    {
        FTPClient ftp;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ftp = new FTPClient(hostBox.Text, userBox.Text, passBox.Text);
                ftp.RemotePort = (int)portNUD.Value;
                listDirs();
            }
            catch
            {
                MessageBox.Show("Error!");
            }
        }

        private void listDirs()
        {
            string[] list = ftp.GetFileList();
            String lines = "";
            foreach (string s in list)
            {
                lines += s + "\r\n";
            }
            textBox.Text = lines;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (ftp != null)
            {
                ftp = new FTPClient(hostBox.Text, "Dropbox", "cisco");
                ftp.RemotePath = dirBox.Text;
                listDirs();
            }
        }
    }
}
