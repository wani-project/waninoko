using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace wani1
{
    public partial class C2 : Form
    {
        public C2()
        {
            InitializeComponent();
        }

        private void review_back_button_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


        private async void Start()
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
   
        }

        bool _isDraging = false;
        Point? _diffPoint = null;

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
                int bufX = 0;
                if (bufX < point.X && point.X < x)
                {
                    countX++;
                    bufX = x;

                    countY = 0;
                    for (int y = h; y <= height; y += h)
                    {
                        int bufY = 0;
                        if (bufY < point.Y && point.Y < y)
                        {
                            countY++;
                            bufY = y;
                        }
                    }
                }
            }
            MessageBox.Show(countX.ToString() + ", " + countY.ToString());
        }

    }
}
