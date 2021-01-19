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
        private void Cell_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
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
            /*for (int x = w; x <= width; x += w)
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
            */
            Point p  = GetPoint(point);
            MessageBox.Show(p.ToString());
            //MessageBox.Show(countX.ToString() + ", " + countY.ToString());

        }
        private Point GetPoint(Point point)
        {
            int countX = 0;
            int countY = 0;
            int height = tableLayoutPanel1.Height;
            int width = tableLayoutPanel1.Width;
            int h = height / 5;
            int w = width / 5;

            if(0 < point.X && point.X <= w)
            {
                countX = 0;
            }
            if(0 < point.Y && point.Y <= h) {
                countY = 0;
            }
            return new Point(countX, countY);
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

        //D&D処理
        Point def;
        private void Fruits_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox pb = ((PictureBox)sender);
            def = pb.Location;
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            Cursor.Current = Cursors.Hand;
            _isDraging = true;
            _diffPoint = e.Location;
            
        }
        private void Fruits_MouseMove(object sender, MouseEventArgs e)
        {
            PictureBox pb = ((PictureBox)sender);
            if (!_isDraging)
            {
                return;
            }

            int x = pb.Location.X + e.X - _diffPoint.Value.X;
            int y = pb.Location.Y + e.Y - _diffPoint.Value.Y;

            if (x <= 0) x = 0;
            if (y <= 0) y = 0;
            pb.Location = new Point(x, y);
            pb.BringToFront();
        }
        private void Fruits_MouseUp(object sender, MouseEventArgs e)
        {
            PictureBox pb = ((PictureBox)sender);
            Cursor.Current = Cursors.Default;
            _isDraging = false;

            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            Point loc = new Point(pb.Location.X, pb.Location.Y);
            int x = e.X + loc.X;
            int y = e.Y + loc.Y;
            if (tableLayoutPanel1.Location.X <= x && x < (tableLayoutPanel1.Location.X + tableLayoutPanel1.Size.Width) && tableLayoutPanel1.Location.Y  <= y && y <= (tableLayoutPanel1.Location.Y + tableLayoutPanel1.Size.Height))
            {
                //セルに入れる処理を記述
                int cX = x - tableLayoutPanel1.Location.X;
                int cY = y - tableLayoutPanel1.Location.Y;
                Point c = new Point(cX, cY);
                GetCellPosition(c);

                
                //tableLayoutPanel1.GetControlFromPosition();
            }
            pb.Location = def;
        }
        
        

    }
}
