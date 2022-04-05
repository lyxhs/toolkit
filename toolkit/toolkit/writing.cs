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
    public partial class writing : Form
    {
        public writing()
        {
            InitializeComponent();
        }

        public string getpath { get; set; }
        public string savepath { get; set; }
        

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "打开文件";
            openFileDialog.InitialDirectory = "C:\\";
            openFileDialog.Filter = "Text files(.txt)|*.txt";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                getpath = openFileDialog.FileName;
                writingbookmake fm = new writingbookmake(getpath);
                this.Hide();
                DateTime dt = DateTime.Now;
                StreamWriter sw = File.AppendText(@"C:\Toolkit\writingbook\wlog.txt");
                sw.WriteLine(dt.ToString() + "," + getpath);
                sw.Close();
                if (fm.ShowDialog() == DialogResult.OK)
                {
                    this.Show();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Title = "新建文件";
            save.Filter = "txt files(*.txt)|*.txt";
            save.FileName = "file01";
            save.RestoreDirectory = true;
            if(save.ShowDialog() == DialogResult.OK)
            {
                savepath = save.FileName.ToString();
                File.Create(savepath).Close();
                writingbookmake fm = new writingbookmake(savepath);
                this.Hide();
                DateTime dt = DateTime.Now;
                StreamWriter sw = File.AppendText(@"C:\Toolkit\writingbook\wlog.txt");
                sw.WriteLine(dt.ToString() + "," + savepath);
                sw.Close();
                if (fm.ShowDialog() == DialogResult.OK)
                {
                    this.Show();
                }
            }
        }

        private void writing_Load(object sender, EventArgs e)
        {
            int lines = readFileLines(@"C:\Toolkit\writingbook\wlog.txt");
            using (StreamReader sr = new StreamReader(@"C:\Toolkit\writingbook\wlog.txt"))
            {
                for(int i = 0; i < lines; i++)
                {
                    if(lines > 20)
                    {
                        if(i >= lines - 20)
                        {
                            listBox1.Items.Add(sr.ReadLine());
                            
                        }
                    }
                    else
                    {
                        listBox1.Items.Add(sr.ReadLine());
                    }
                    
                }
            }
            this.listBox1.MouseDoubleClick += new MouseEventHandler(listBox1_MouseDoubleClick);

        }

        void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // get index Clicked & DoubleClick BlankSpace return NoMatches
            int index = this.listBox1.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                string pa = listBox1.Items[index].ToString();
                string[] li = new string[2];
                li = pa.Split(',');
                string final = li[1];
                if (File.Exists(final))
                {
                    writingbookmake fm = new writingbookmake(final);
                    this.Hide();
                    DateTime dt = DateTime.Now;
                    StreamWriter sw = File.AppendText(@"C:\Toolkit\writingbook\wlog.txt");
                    sw.WriteLine(dt.ToString() + "," + final);
                    sw.Close();
                    if (fm.ShowDialog() == DialogResult.OK)
                    {
                        this.Show();
                    }
                }
                else
                {
                    List<string> wg = new List<string>();
                    MessageBox.Show("这个文件不存在了！");
                    listBox1.Items.Remove(pa);
                    foreach (string x in listBox1.Items)
                    {
                        if(x == pa)
                        {
                            listBox1.Items.Remove(x);
                        }
                    }
                    foreach (string str in System.IO.File.ReadAllLines(@"C:\Toolkit\writingbook\wlog.txt", Encoding.UTF8))
                    {
                        if (str == pa)
                        {
                            continue;
                        }
                        else
                        {
                            wg.Add(str);
                        }
                    }
                    using(StreamWriter sw = new StreamWriter(@"C:\Toolkit\writingbook\wlog.txt"))
                    {
                        for(int i = 0; i < wg.Count; i++)
                        {
                            sw.WriteLine(wg[i],Encoding.UTF8);
                        }
                        sw.Close();
                    }
                }
            }
            //do what you wanna do
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}
