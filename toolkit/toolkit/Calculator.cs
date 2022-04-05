using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace toolkit
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }

        public static double main(string get)
        {
            List<string> li = new List<string>();
            List<int> wh = new List<int>();
            bool hav;
            double final;
            li = Sp(get);
            wh = backet(li);
            hav = have(li);
            if (wh.Count > 1)
            {
                final = ba(wh, li, hav);
            }
            else
            {
                final = calulater(li, hav);
            }
            return final;
        }

        public static List<string> Sp(string input)
        {
            char[] spilt = input.ToCharArray();
            string num = "";
            int where = 0;
            bool whbr = false;
            List<string> get = new List<string>();
            for (int c = 0; c < spilt.Length; c++)
            {
                if (spilt[c] == ')')
                {
                    for (int i = where; i < c; i++)
                    {
                        num = num + spilt[i];
                    }
                    get.Add(num);
                    get.Add(")");
                    where = c + 1;
                    num = "";
                    whbr = true;
                }
                else if (whbr)
                {
                    get.Add(Convert.ToString(spilt[c]));
                    where = c + 1;
                    num = "";
                    whbr = false;
                }
                else if (spilt[c] == '+' || spilt[c] == '-' || spilt[c] == '*' || spilt[c] == '/')
                {
                    for (int i = where; i < c; i++)
                    {
                        num = num + spilt[i];
                    }
                    get.Add(num);
                    switch (spilt[c])
                    {
                        case '+': get.Add("+"); break;
                        case '-': get.Add("-"); break;
                        case '*': get.Add("*"); break;
                        case '/': get.Add("/"); break;
                    }
                    where = c + 1;
                    num = "";
                }
                if (spilt[c] == '(')
                {
                    switch (spilt[c])
                    {
                        case '(': get.Add("("); break;
                    }
                    where = c + 1;
                }

            }
            num = string.Empty;
            if (spilt[spilt.Length - 1] != ')')
            {
                for (int i = where; i < spilt.Length; i++)
                {
                    num = num + spilt[i];

                }
                get.Add(num);
            }
            return get;
        }

        public static List<int> backet(List<string> get)
        {
            int num = 0;//括号（组）的个数
            List<int> where = new List<int>();
            for (int i = 0; i < get.Count; i++)
            {
                if (get[i] == "(")
                {
                    num = num + 1;
                    where.Add(i);
                }
                if (get[i] == ")")
                {
                    where.Add(i);
                }
            }
            return where;
        }

        public static bool have(List<string> get)
        {
            bool h = false;
            for (int i = 0; i < get.Count; i++)
            {
                if (get[i] == "*" || get[i] == "/")
                {
                    h = true;
                    return h;
                }
            }
            return h;
        }

        public static double calulater(List<string> get, bool hav)
        {
            int i = 0;
            double c = 0;//计算结果
            bool h;
            if (hav)
            {
                while (true)
                {
                    i++;
                    if (get[i] == "*")
                    {
                        c = int.Parse(get[i - 1]) * int.Parse(get[i + 1]);
                        get[i - 1] = Convert.ToString(c);
                        get.RemoveAt(i);
                        get.RemoveAt(i);
                        i = 0;
                    }
                    else if (get[i] == "/")
                    {
                        if (int.Parse(get[i - 1]) % int.Parse(get[i + 1]) == 0)
                        {
                            c = int.Parse(get[i - 1]) / int.Parse(get[i + 1]);
                            get[i - 1] = Convert.ToString(c);
                            get.RemoveAt(i);
                            get.RemoveAt(i);
                            i = 0;
                        }
                        else
                        {
                            c = double.Parse(get[i - 1]) / double.Parse(get[i + 1]);
                            get[i - 1] = Convert.ToString(c);
                            get.RemoveAt(i);
                            get.RemoveAt(i);
                            i = 0;
                        }
                    }
                    h = have(get);
                    if (!h)
                    {
                        break;
                    }
                    c = 0;
                }
                c = 0;
            }
            if (get.Count != 1)
            {
                while (true)
                {
                    if (get[1] == "+")
                    {
                        c = int.Parse(get[0]) + int.Parse(get[2]);
                        get[0] = Convert.ToString(c);
                        get.RemoveAt(1);
                        get.RemoveAt(1);
                    }
                    else if (get[1] == "-")
                    {
                        c = int.Parse(get[0]) - int.Parse(get[2]);
                        get[0] = Convert.ToString(c);
                        get.RemoveAt(1);
                        get.RemoveAt(1);
                    }
                    c = 0;
                    if (get.Count == 1)
                    {
                        break;
                    }
                }
            }
            return int.Parse(get[0]);
        }

        public static double ba(List<int> b, List<string> get, bool hav)
        {
            List<string> li = new List<string>();
            double re = 0;
            int cut = 0;
            int ci = b.Count / 2;
            List<int> whereba = new List<int>();
            whereba = b;
            for (int i = 0; i < ci; i++)
            {
                for (int j = whereba[0] + 1; j < whereba[1]; j++)
                {
                    li.Add(get[j]);
                    cut = cut + 1;
                }
                cut = cut + 2;
                bool ha = have(li);
                re = calulater(li, ha);
                get[whereba[0]] = Convert.ToString(re);
                for (int k = 0; k < cut - 1; k++)
                {
                    get.RemoveAt(whereba[0] + 1);
                }
                li.Clear();
                whereba = backet(get);
                cut = 0;
            }
            re = calulater(get, hav);
            return re;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "1";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            double re;
            re = main(textBox1.Text);
            textBox1.Text = Convert.ToString(re);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "2";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "3";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "4";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "6";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "7";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "9";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "+";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "-";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "*";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "/";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "(";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + ")";
        }
    }
}
