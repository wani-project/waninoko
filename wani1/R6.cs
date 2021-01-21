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

        private void R6_Close(object sender, FormClosedEventArgs e)
        {
            Dispose();
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
            Dispose();
        }

        private void R6_Load(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < Random(); i++)
                {
                    InsertNum(CreateNum(0));
                }
                for (int i = 0; i < Random(); i++)
                {
                    InsertNum(CreateNum(1));
                }
                for (int i = 0; i < Random(); i++)
                {
                    InsertNum(CreateNum(2));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
        }
        
        
        private Control CreateNum(int num)
        {
            PictureBox Number = new PictureBox();
            Number.Size = new Size(100, 100);
            Number.SizeMode = PictureBoxSizeMode.StretchImage;
            switch (num)
            {
                case 0:
                    Number.Name = "zero";
                    Number.Image = Image.FromFile(FilePath + "\\images\\C2\\0.png");
                    break;
                case 1:
                    Number.Name = "one";
                    Number.Image = Image.FromFile(FilePath + "\\images\\C2\\1.png");
                    break;
                case 2:
                    Number.Name = "two";
                    Number.Image = Image.FromFile(FilePath + "\\images\\C2\\2.png");
                    break;
            }
            return Number;
        }

        private int Random()
        {
            int seed = Environment.TickCount;
            Random random = new Random(seed++);
            return (int)random.Next(2,6);
        }
        private void InsertNum(Control control)
        {
            try
            {
                int seed = Environment.TickCount;
                Random random = new Random();
                int[] rand = new int[2];
                for (int i = 0; i < 2; i++)
                {
                    random = new Random(seed++);
                    rand[i] = (int)random.Next(5);
                }
                Boolean flg = false;
                do
                {
                    TableLayoutPanelCellPosition p = new TableLayoutPanelCellPosition(rand[0], rand[1]);
                    if (tableLayoutPanel2.GetControlFromPosition(p.Column, p.Row) == null)
                    {
                        tableLayoutPanel2.Controls.Add(control, p.Column, p.Row);
                        break;
                    }
                    else
                    {
                        random = new Random(seed++);
                        p.Row = (int)random.Next(5);
                        rand[1] = p.Row;
                        random = new Random(seed++);
                        p.Column = (int)random.Next(5);
                        rand[0] = p.Column;
                    }
                } while (!flg);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
                SetCellItems(GetPoint(c),((PictureBox)sender).Name);
            }
            pb.Location = def;
        }
        //セル取得処理
        private Point GetPoint(Point point)
        {
            int countX = 0;
            int countY = 0;
            int height = tableLayoutPanel1.Height;
            int width = tableLayoutPanel1.Width;
            int h = height / 5;
            int w = width / 5;

            countX = (point.X - ((point.X - 1) % 10)) / w;
            countY = (point.Y - ((point.Y - 1) % 10)) / h;

            return new Point(countX, countY);
        }
        //セルに画像を追加する処理
        private void SetCellItems(Point point,string name)
        {
            if(tableLayoutPanel1.GetControlFromPosition(point.X,point.Y) == null)
            {
                tableLayoutPanel1.Controls.Add(CreateFruits(name), point.X, point.Y);
            }
        }
        private Control CreateFruits(string name)
        {
            PictureBox fruits = new PictureBox();
            switch (name)
            {
                case "Apple":
                    fruits.Name = "Apple";
                    fruits.Size = new Size(100, 100);
                    fruits.SizeMode = PictureBoxSizeMode.StretchImage;
                    fruits.Image = Image.FromFile(FilePath + "\\images\\C2\\apple.png");
                    break;
                case "Orange":
                    fruits.Name = "Orange";
                    fruits.Size = new Size(100, 100);
                    fruits.SizeMode = PictureBoxSizeMode.StretchImage;
                    fruits.Image = Image.FromFile(FilePath + "\\images\\C2\\orange.png");
                    break;
            }
            return (Control)fruits;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void Start()
        {
            int[] oneX = { 0, 0};
            int[] oneY = { 0, 0};
            int[] twoX = { 0, 0};
            int[] twoY = { 0, 0};
            int countX = 0;
            int countY = 0;

            Control[] controls1 = panel4.Controls.Find("Apple", true);
            Control[] controls2 = panel4.Controls.Find("one", true);
            foreach(Control c in controls2)
            {
                TableLayoutPanelCellPosition p = tableLayoutPanel2.GetCellPosition(c);
                oneX[countX] = p.Column;
                oneY[countY] = p.Row;
                countX++;
                countY++;
            }
            countX = 0;
            countY = 0;
            controls2 = panel4.Controls.Find("two", true);
            foreach(Control c in controls2)
            {
                TableLayoutPanelCellPosition p = tableLayoutPanel2.GetCellPosition(c);
                twoX[countX] = p.Column;
                twoY[countY] = p.Row;
                countX++;
                countY++;
            }
            for(int i = 0;i < 2; i++)
            {
                
                MessageBox.Show("one" + oneX[i] + "," + oneY[i]);
                MessageBox.Show("two" + twoX[i] + "," + twoY[i]);
            }

        }

        private void review_back_button_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
