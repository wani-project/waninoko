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

namespace wani1
{
    public partial class R6 : Form
    {
        private string FilePath = Directory.GetCurrentDirectory();
        public R6()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Cell_Click(object sender, EventArgs e)
        {
            ggwp();
        }

        private void ggwp()
        {
            this.Dispose();
        }

        private void R6_Load(object sender, EventArgs e)
        {
            CreateNum();
        }
        //移動処理の初期変数---------
        bool _isDraging = false;
        Point? _diffPoint = null;
        private void Cell_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_isDraging)
            {
                return;
            }

        }
        private void Cell_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            _isDraging = true;
            _diffPoint = e.Location;

            Point mouse = e.Location;
            GetCellPosition(e.Location);
            
        }

        private void GetCellPosition(Point point)
        {
            int countX = 0;
            int countY = 0;
            int height = tableLayoutPanel1.Height;
            int width = tableLayoutPanel1.Width;
            int h = height / 5;
            int w = width / 5;
            for (int x = w; x <= width; x += w)
            {
                int bufX = w;
                if(bufX < point.X && point.X < x)
                {
                    countX++;
                    bufX = x;
                    
                    countY = 0;
                    for(int y = h; y <= height; y += h)
                    {
                        int bufY = h;
                        if(bufY < point.Y && point.Y < y)
                        {
                            countY++;
                            bufY = y;
                        }
                    }
                }
            }
            MessageBox.Show(countX.ToString() + ", " + countY.ToString());

        }
        private void CreateNum()
        {
            PictureBox zero = new PictureBox();
            PictureBox one = new PictureBox();
            PictureBox two = new PictureBox();

            zero.Size = new Size(100, 100);
            zero.SizeMode = PictureBoxSizeMode.StretchImage;
            zero.Image = Image.FromFile(FilePath + "\\images\\C2\\0.png");

            one.Size = new Size(100, 100);
            one.SizeMode = PictureBoxSizeMode.StretchImage;
            one.Image = Image.FromFile(FilePath + "\\images\\C2\\1.png");

            two.Size = new Size(100, 100);
            two.SizeMode = PictureBoxSizeMode.StretchImage;
            two.Image = Image.FromFile(FilePath + "\\images\\C2\\2.png");

            tableLayoutPanel1.Controls.Add(zero,0,0);
            tableLayoutPanel1.Controls.Add(one,1,1);
            tableLayoutPanel1.Controls.Add(two,2,2);
        }
    }
}
