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
    public partial class colorchoose : Form
    {
        public colorchoose(string Colour)
        {
            InitializeComponent();
            c = Colour;
        }
        public string c { get; set; }
        public string color { get; set; }
        private void button2_Click(object sender, EventArgs e)
        {
            color = "DeepSkyBlue";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            color = "Red";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            color = "Green";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            color = "Yellow";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void colorchoose_Load(object sender, EventArgs e)
        {
            color = c;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            color = "Black";
        }
    }
}
