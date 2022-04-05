using System;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace toolkit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 9;
            progressBar1.Step = 1;
            if (!Directory.Exists(@"C:\Toolkit"))       //新建主文件夹
            {
                Directory.CreateDirectory(@"C:\Toolkit");
                progressBar1.PerformStep();
            }
            else
            {
                progressBar1.PerformStep();
            }

            if (!Directory.Exists(@"C:\Toolkit\writingbook"))       //新建记事本文件夹
            {
                Directory.CreateDirectory(@"C:\Toolkit\writingbook");
                progressBar1.PerformStep();
            }
            else
            {
                progressBar1.PerformStep();
            }

            if (!Directory.Exists(@"C:\Toolkit\writingbook\message"))       //新建记事本文件内容
            {
                Directory.CreateDirectory(@"C:\Toolkit\writingbook\message");
                progressBar1.PerformStep();
            }
            else
            {
                progressBar1.PerformStep();
            }

            if (!Directory.Exists(@"C:\Toolkit\Calculator"))       //新建计算机文件夹
            {
                Directory.CreateDirectory(@"C:\Toolkit\Calculator");
                progressBar1.PerformStep();
            }
            else
            {
                progressBar1.PerformStep();
            }

            if (!Directory.Exists(@"C:\Toolkit\user"))       //新建主用户文件夹
            {
                Directory.CreateDirectory(@"C:\Toolkit\user");
                progressBar1.PerformStep();
            }
            else
            {
                progressBar1.PerformStep();
            }

            if (!Directory.Exists(@"C:\Toolkit\Data"))       //新建数据文件夹
            {
                Directory.CreateDirectory(@"C:\Toolkit\Data");
                progressBar1.PerformStep();
            }
            else
            {
                progressBar1.PerformStep();
            }

            if (!File.Exists(@"C:\Toolkit\Data\log.txt"))       //新建主程序日志文件
            {
                File.Create(@"C:\Toolkit\Data\log.txt").Close();
                progressBar1.PerformStep();
            }
            else
            {
                progressBar1.PerformStep();
            }

            if (!File.Exists(@"C:\Toolkit\writingbook\wlog.txt"))       //新建记事本日志文件
            {
                File.Create(@"C:\Toolkit\writingbook\wlog.txt").Close();
                progressBar1.PerformStep();
            }
            else
            {
                progressBar1.PerformStep();
            }

            if (!File.Exists(@"C:\Toolkit\Calculator\clog.txt"))       //新建计算机日志文件
            {
                File.Create(@"C:\Toolkit\Calculator\clog.txt").Close();
                progressBar1.PerformStep();
            }
            else
            {
                progressBar1.PerformStep();
            }

            this.Close();
        }
    }
}
