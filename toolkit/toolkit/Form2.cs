using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace toolkit
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            writing fr = new writing();
            fr.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (!File.Exists(@"C:\Toolkit\user\user.txt"))
            {
                Form3 f3 = new Form3();
                
                if(f3.ShowDialog() == DialogResult.OK)
                {
                    string gname = f3.getname;
                    label4.Text = "你好，";
                    label3.Visible = true;
                    label3.Text = gname;
                }
            }

        }

        private void Form2_Load(object sender, EventArgs e)
        {

            //Thread.Sleep(1500);
            timer1.Enabled = true;
            Form1 frm = new Form1();
            frm.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            label5.Text = dt.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            printing pr = new printing();
            pr.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Calculator ca = new Calculator();
            ca.Show();
        }
    }
}
