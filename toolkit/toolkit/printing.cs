using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace toolkit
{
    public partial class printing : Form
    {
        public printing()
        {
            InitializeComponent();
        }

        Bitmap myImage;
        int PBwidth; //这个是  画板的宽度
        int PBheight;//这个是  画板的高度
        bool beginPaint = false;//定义是否画板开启 初始化否
        bool beginMove = false;//定义是否开始移动画画 初始化否
        int currentXpos;//定义的一个变量 用来存储 移动中坐标的x值
        int currentYpos;//定义的一个变量 用来存储 移动中坐标的y值

        public string color { get; set; }
        public int size { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "开始画画")

            {
                beginPaint = true;

                button1.Text = "结束画画";

                //新建一个以白色为背景色的画布，并显示在pictureBox

                myImage = new Bitmap(PBwidth, PBheight);

                Graphics g = Graphics.FromImage(myImage);

                g.Clear(Color.White);

                pictureBox1.Image = myImage;

            }

            else if (button1.Text == "结束画画")

            {
                beginPaint = false;

                button1.Text = "开始画画";

            }
        }

        private void printing_Load(object sender, EventArgs e)
        {
            numericUpDown1.Maximum = 10;
            numericUpDown1.Minimum = 1;
            numericUpDown1.DecimalPlaces = 1;
            color = "Black";
            PBheight = pictureBox1.Height;
            PBwidth = pictureBox1.Width;
            this.pictureBox1.MouseDown += new MouseEventHandler(pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new MouseEventHandler(pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new MouseEventHandler(pictureBox1_MouseUp);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (beginPaint == true)

            {
                if (e.Button == MouseButtons.Left)

                {
                    beginMove = true;

                    currentXpos = e.X;

                    currentYpos = e.Y;

                }

            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (beginMove)
            {
                Graphics g = Graphics.FromImage(myImage);
                if(color == "Red")
                {
                    Pen myPen = new Pen(Color.Red, size);//画笔的初始
                    g.DrawLine(myPen, currentXpos, currentYpos, e.X, e.Y);//画笔在画板上的操作
                    pictureBox1.Image = myImage;//跟新图像
                    g.Dispose();//释放画板资源
                    currentYpos = e.Y;//跟新坐标
                    currentXpos = e.X;
                }
                else if(color == "DeepSkyBlue")
                {
                    Pen myPen = new Pen(Color.DeepSkyBlue, size);//画笔的初始
                    g.DrawLine(myPen, currentXpos, currentYpos, e.X, e.Y);//画笔在画板上的操作
                    pictureBox1.Image = myImage;//跟新图像
                    g.Dispose();//释放画板资源
                    currentYpos = e.Y;//跟新坐标
                    currentXpos = e.X;
                }
                else if (color == "Green")
                {
                    Pen myPen = new Pen(Color.Green, size);//画笔的初始
                    g.DrawLine(myPen, currentXpos, currentYpos, e.X, e.Y);//画笔在画板上的操作
                    pictureBox1.Image = myImage;//跟新图像
                    g.Dispose();//释放画板资源
                    currentYpos = e.Y;//跟新坐标
                    currentXpos = e.X;
                }
                else if (color == "Yellow")
                {
                    Pen myPen = new Pen(Color.Yellow, size);//画笔的初始
                    g.DrawLine(myPen, currentXpos, currentYpos, e.X, e.Y);//画笔在画板上的操作
                    pictureBox1.Image = myImage;//跟新图像
                    g.Dispose();//释放画板资源
                    currentYpos = e.Y;//跟新坐标
                    currentXpos = e.X;
                }
                else
                {
                    Pen myPen = new Pen(Color.Black, size);//画笔的初始
                    g.DrawLine(myPen, currentXpos, currentYpos, e.X, e.Y);//画笔在画板上的操作
                    pictureBox1.Image = myImage;//跟新图像
                    g.Dispose();//释放画板资源
                    currentYpos = e.Y;//跟新坐标
                    currentXpos = e.X;
                }
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)

            {
                beginMove = false;

                currentXpos = 0;

                currentYpos = 0;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (beginPaint == true)

            {
                SaveFileDialog sfd = new SaveFileDialog();
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    
                    //储存为Jpeg格式，加个后缀保存，让Photoshop之类的软件识别

                    myImage.Save(sfd.FileName + @".jpeg", ImageFormat.Jpeg);

                }

            }

            else

            {
                MessageBox.Show("请先绘制图像");

                return;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            colorchoose cl = new colorchoose(color);
            if (cl.ShowDialog() == DialogResult.OK)
            {
                color = cl.color;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            size = ((int)numericUpDown1.Value);
        }
    }
}