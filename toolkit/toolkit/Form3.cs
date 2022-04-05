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
using System.Threading;

namespace toolkit
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        public string getname { get; set; }
        

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != string.Empty)
            {
                if(comboBox1.Text != string.Empty && comboBox2.Text != string.Empty && comboBox3.Text != string.Empty)
                {
                    if(radioButton1.Checked || radioButton2.Checked)
                    {
                        if(textBox2.Text != string.Empty && textBox2.Text.Length >= 8)
                        {
                            string xingget;
                            if (radioButton1.Checked)
                            {
                                xingget = "男";
                            }
                            else
                            {
                                xingget = "女";
                            }
                            string usermessage = textBox1.Text + "," + comboBox1.Text + "/" + comboBox3.Text + "/" + comboBox2.Text + "," + xingget + "," + textBox2.Text;
                            File.Create(@"C:\Toolkit\user\user.txt").Close();
                            using (StreamWriter sWriter = new StreamWriter(@"C:\Toolkit\user\user.txt"))
                            {
                                sWriter.WriteLine(usermessage);
                            }
                            getname = textBox1.Text;
                            this.DialogResult = DialogResult.OK;
                            Form3 f = new Form3();
                            f.Close();
                        }
                        else
                        {
                            MessageBox.Show("您的密码不符合规范（必须为8字以上！）！");
                        }
                    }
                    else
                    {
                        MessageBox.Show("请输入性别！");
                    }
                }
                else
                {
                    MessageBox.Show("请输入出生日期!");
                }
            }
            else
            {
                MessageBox.Show("请输入昵称！");
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            int[] year = new int[22] { 2021, 2020, 2019, 2018, 2017, 2016, 2015, 2014, 2013, 2012, 2011, 2010, 2009, 2008, 2007, 2006, 2005, 2004, 2003, 2002, 2001, 2000 };
            for(int i = 0; i < 22; i++)
            {
                comboBox1.Items.Add(i);
            }
            int[] month = new int[12] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            for (int i = 0; i < 12; i++)
            {
                comboBox3.Items.Add(i);
            }
            int[] days = new int[31] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31 };
            for (int i = 0; i < 31; i++)
            {
                comboBox2.Items.Add(i);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
            if(radioButton2.Checked == true)
            {
                radioButton2.Checked = false;
                radioButton1.Checked = true;
            }
            else
            {
                radioButton1.Checked = true;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                radioButton2.Checked = true;
                radioButton1.Checked = false;
            }
            else
            {
                radioButton2.Checked = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void jiami(string get , int add)
        {
            
            char[] chars = get.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if ((chars[i] >= 'a' && chars[i] <= 'z') || (chars[i] >= 'A' && chars[i] <= 'Z'))
                {
                    chars[i] = (char)(chars[i] + add);
                }
            }
            if (File.Exists(@"C:\Toolkit\key\key3.txt"))
            {
                using (StreamWriter sw = new StreamWriter(@"C:\Toolkit\key\key3.txt"))
                {
                    foreach (char c in chars)
                    {
                        sw.Write(c);
                    }
                    sw.Close();
                }
            }
            else
            {
                File.Create(@"C:\Toolkit\key\key3.txt").Close();
                using (StreamWriter sw = new StreamWriter(@"C:\Toolkit\key\key3.txt"))
                {
                    foreach (char c in chars)
                    {
                        sw.Write(c);
                    }
                    sw.Close();
                }
            }

        }

        public void tomakejiami(string get)
        {
            int x = 0;
            int m = 0;
            if (Directory.Exists(@"C:\Toolkit\key"))
            {
                if (!File.Exists(@"C:\Toolkit\key\key1.txt"))
                {
                    File.Create(@"C:\Toolkit\key\key1.txt").Close();
                    Random random = new Random();
                    Thread.Sleep(1);
                    m = random.Next(1, 5);
                    string s = GetRnd(5, false, false, true, true, "hhhfenficcdsjncshucbcs");
                    string a = GetRnd(5, true, true, false, false, "sdofifuvhnvtjithg");
                    using (StreamWriter sw = new StreamWriter(@"C:\Toolkit\key\key1.txt"))
                    {
                        sw.WriteLine(a + m + s);
                        sw.Close();
                    }
                }

            }
            else
            {
                Directory.CreateDirectory(@"C:\Toolkit\key");
                File.Create(@"C:\Toolkit\key\key1.txt").Close();
                Random random = new Random();
                Thread.Sleep(1);
                m = random.Next(1, 5);
                string s = GetRnd(5, false, false, true, true, "hhhfenficcdsjncshucbcs");
                string a = GetRnd(5, true, true, false, false, "sdofifuvhnvtjithg");
                using (StreamWriter sw = new StreamWriter(@"C:\Toolkit\key\key1.txt"))
                {
                    sw.WriteLine(a + m + s);
                    sw.Close();
                }
            }
            if (Directory.Exists(@"C:\Toolkit\key"))
            {
                if (!File.Exists(@"C:\Toolkit\key\key2.txt"))
                {
                    File.Create(@"C:\Toolkit\key\key2.txt").Close();
                    Random random = new Random();
                    Thread.Sleep(1);
                    x = random.Next(1, 4);
                    using (StreamWriter sw = new StreamWriter(@"C:\Toolkit\key\key2.txt"))
                    {
                        sw.WriteLine(x+17);
                        sw.Close();
                    }
                }
            }
            jiami(get, x + m);
        }

        public string jiemi()
        {
            string a = "";
            string p = "";
            string q = "";
            int b = 0;
            string get = "";
            string final = "";
            using(StreamReader sr = new StreamReader(@"C:\Toolkit\key\key1.txt"))
            {
                a = sr.ReadToEnd();
                p = a.Remove(0, 5);
                q = p.Remove(1, 5);
                sr.Close();
            }
            using (StreamReader sr = new StreamReader(@"C:\Toolkit\key\key2.txt"))
            {
                b = int.Parse(sr.ReadToEnd())-17;
                sr.Close();
            }
            using (StreamReader sr = new StreamReader(@"C:\Toolkit\key\key3.txt"))
            {
                get = sr.ReadToEnd();
                sr.Close();
            }
            char[] chars = get.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if ((chars[i] >= 'a' && chars[i] <= 'z') || (chars[i] >= 'A' && chars[i] <= 'Z'))
                {
                    chars[i] = (char)(chars[i] - int.Parse(q)+b);
                }
            }
            foreach(char d in chars)
            {
                final = final + d;
            }
            return final;
        }

        public string GetRnd(int length, bool useNum, bool useLow, bool useUpp, bool useSpe, string custom)
        {
            byte[] b = new byte[4];
            new System.Security.Cryptography.RNGCryptoServiceProvider().GetBytes(b);
            Random r = new Random(BitConverter.ToInt32(b, 0));
            string s = null, str = custom;

            if (useNum == true) { str += "0123456789"; }
            if (useLow == true) { str += "abcdefghijklmnopqrstuvwxyz"; }
            if (useUpp == true) { str += "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; }
            if (useSpe == true) { str += "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~"; }

            for (int i = 0; i < length; i++)
            {
                s += str.Substring(r.Next(0, str.Length - 1), 1);
            }

            return s;
        }
    }
}
