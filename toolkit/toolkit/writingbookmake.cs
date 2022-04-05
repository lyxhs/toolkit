using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace toolkit
{
    public partial class writingbookmake : Form
    {
        public writingbookmake(string openthing)
        {
            InitializeComponent();
            open = openthing;
        }

        public string font { get; set; }

        public string color { get; set; }

        public string open { get; set; }

        private void writingbookmake_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = string.Empty;
            label1.Text = "打开的文件：" + open;
            int lines = readFileLines(open);
            label2.Text = "行数:" + lines;
            using (StreamReader sr = new StreamReader(open))
            {
                for(int i = 0; i <= lines - 1; i++)
                {
                    if(i == 0)
                    {
                        richTextBox1.Text = sr.ReadLine();
                    }
                    else
                    {
                        richTextBox1.Text = richTextBox1.Text + "\r\n" + sr.ReadLine();
                    }
                }
                sr.Close();
            }
            numericUpDown1.Maximum = 400;
            numericUpDown1.Minimum = 0;
            numericUpDown1.DecimalPlaces = 2;
        }

        public static int readFileLines(string path)  //这里的参数是txt所在路径
        {
            int lines = 0;  //用来统计txt行数
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(fs);
            while (sr.ReadLine() != null)
            {
                lines++;
            }

            fs.Close();
            sr.Close();

            return lines;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            font = richTextBox1.Font.Name + "#" + richTextBox1.Font.Size + "#" + richTextBox1.Font.Style;
            System.IO.File.WriteAllText(open,string.Empty);
            using (StreamWriter sw = new StreamWriter(open))
            {
                sw.Write(richTextBox1.Text);
                sw.Close();
            }
            if (File.Exists(@"C:\Toolkit\writingbook\message\fontmessage.txt"))
            {
                int line = readFileLines(@"C:\Toolkit\writingbook\message\fontmessage.txt");
                if (line != 0)
                {
                    string get;
                    bool yes = false;
                    int where = 0;
                    List<string> getline = new List<string>();
                    List<string> getlines = new List<string>();
                    using (StreamReader sr = new StreamReader(@"C:\Toolkit\writingbook\message\fontmessage.txt"))
                    {
                        string[] g = new string[4];
                        g = sr.ReadLine().Split(',');
                        for (int i = 0; i <= line - 1; i++)
                        {
                            get = g[0];
                            if (get == open)
                            {
                                yes = true;
                                where = i;
                            }
                            getline.Add(sr.ReadLine());
                        }
                        sr.Close();
                    }
                    if (yes)
                    {
                        getline.RemoveAt(where);
                        for (int i = 0; i < getline.Count; i++)
                        {
                            if (i == where)
                            {
                                getlines.Add(open + "#" + font);
                            }
                            else
                            {
                                getlines.Add(getline[i]);
                            }
                        }
                        using (StreamWriter sw = new StreamWriter(@"C:\Toolkit\writingbook\message\fontmessage.txt"))
                        {
                            
                            for (int i = 0; i < getline.Count; i++)
                            {
                                sw.WriteLine(getlines[i]);
                            }
                            sw.Close();
                        }

                    }
                    else
                    {
                        StreamWriter sw = File.AppendText(@"C:\Toolkit\writingbook\message\fontmessage.txt");
                        sw.WriteLine(open + "#" + font);
                        sw.Close();
                    }

                }
                else
                {
                    StreamWriter sw = File.AppendText(@"C:\Toolkit\writingbook\message\fontmessage.txt");
                    sw.WriteLine(open + "#" + font);
                    sw.Close();
                }
            }
            else
            {
                File.Create(@"C:\Toolkit\writingbook\message\fontmessage.txt").Close();
                StreamWriter sw = File.AppendText(@"C:\Toolkit\writingbook\message\fontmessage.txt");
                sw.WriteLine(open + "#" + font);
                sw.Close();
            }
            MessageBox.Show("保存成功！");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.DialogResult = DialogResult.OK;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (File.Exists(@"C:\Toolkit\writingbook\message\fontmessage.txt"))
            {
                int line = readFileLines(@"C:\Toolkit\writingbook\message\fontmessage.txt");
                using (StreamReader sr = new StreamReader(@"C:\Toolkit\writingbook\message\fontmessage.txt"))
                {
                    string[] get = new string[4];
                    for (int i = 0; i < line; i++)
                    {
                        get = sr.ReadLine().Split('#');
                        if (get[0] == open)
                        {
                            MessageBox.Show(("您上一次的字体设置的是：" + get[1] + ",大小为：" + get[2] + ",样式信息为：" + get[3]), "提示");
                        }
                    }
                    
                }
            }
            FontDialog fd = new FontDialog();//创建一个字体对话框
            fd.ShowDialog();//显示对话框
            this.richTextBox1.Font = fd.Font;//将文本框字体设置成为选中的字体

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();//创建一个颜色对话框
            cd.ShowDialog();
            this.richTextBox1.ForeColor = cd.Color;//将文本框颜色设置成为选中的颜色
            
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionIndent = ((int)numericUpDown1.Value);
            richTextBox1.SelectionRightIndent = ((int)numericUpDown1.Value);
        }
    }
}
