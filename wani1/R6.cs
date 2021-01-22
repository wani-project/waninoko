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

        //照合に必要な変数
        private Dictionary<string, Point> NumPoint = new Dictionary<string, Point>();
        private Dictionary<string, Point> ApplePoint = new Dictionary<string, Point>();
        private Dictionary<string, Point> OrangePoint = new Dictionary<string, Point>();
        private int countZero = 0;
        private int countOne = 0;
        private int countTwo = 0;
        private int countApple = 0;
        private int countOrange = 0;

        public R6()
        {
            InitializeComponent();
        }

        private void R6_Close(object sender, FormClosedEventArgs e)
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
                    InsertNum(CreateNum(1));
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
            try
            {
                PictureBox Number = new PictureBox();
                Number.Size = new Size(100, 100);
                Number.SizeMode = PictureBoxSizeMode.StretchImage;
                switch (num)
                {
                    case 0:
                        countZero++;
                        Number.Name = "zero_" + countZero;
                        Number.Image = Image.FromFile(FilePath + "\\images\\C2\\0.png");
                        break;
                    case 1:
                        Number.Name = "one_";
                        Number.Image = Image.FromFile(FilePath + "\\images\\C2\\1.png");
                        break;
                    case 2:
                        Number.Name = "two_";
                        Number.Image = Image.FromFile(FilePath + "\\images\\C2\\2.png");
                        break;
                }
                return Number;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }

        private int Random()
        {
            int seed = Environment.TickCount;
            Random random = new Random(seed++);
            return (int)random.Next(2,4);
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
                int count = 0;
                int bufX = 999;
                int bufY = 999;
                do
                {
                    
                    TableLayoutPanelCellPosition p = new TableLayoutPanelCellPosition(rand[0], rand[1]);
                    if (tableLayoutPanel2.GetControlFromPosition(p.Column, p.Row) == null)
                    {
                        tableLayoutPanel2.Controls.Add(control, p.Column, p.Row);
                        if (control.Name.Equals("one_"))
                        {
                            countOne++;
                            NumPoint.Add(control.Name + countOne, new Point(p.Column, p.Row));
                        }
                        if (control.Name.Equals("two_"))
                        {
                            countTwo++;
                            NumPoint.Add(control.Name + countTwo, new Point(p.Column, p.Row));
                        }
                        count = 0;
                        bufX = 999;
                        bufY = 999;
                        break;
                    }
                    else
                    {
                        random = new Random(seed++);
                        p.Row = (int)random.Next(5);
                        if(count > 0)
                        {
                            if(bufY == p.Row)
                            {
                                if (p.Row < 4)
                                {
                                    p.Row++;
                                }
                                else
                                {
                                    p.Row = 0;
                                }
                            }
                        }
                        rand[1] = p.Row;
                        bufY = p.Row;
                        random = new Random(seed++);
                        p.Column = (int)random.Next(5);
                        if (count > 0)
                        {
                            if (bufX == p.Column)
                            {
                                if (p.Column < 4)
                                {
                                    p.Column++;
                                }
                                else
                                {
                                    p.Column = 0;
                                }
                            }
                        }
                        bufX = p.Column;
                        rand[0] = p.Column;
                        count++;
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

            countX = ((point.X - 1) - ((point.X - 1) % w)) / w;
            countY = ((point.Y - 1) - ((point.Y - 1) % h)) / h;

            return new Point(countX, countY);
        }
        //セルに画像を追加する処理
        private void SetCellItems(Point point,string name)
        {
            string cname;
            if (tableLayoutPanel1.GetControlFromPosition(point.X,point.Y) == null)
            {
                tableLayoutPanel1.Controls.Add(CreateFruits(name), point.X, point.Y);
                cname = tableLayoutPanel1.GetControlFromPosition(point.X, point.Y).Name;
                switch (cname)
                {
                    case "Apple":
                        cname += "_" + countApple;
                        tableLayoutPanel1.GetControlFromPosition(point.X, point.Y).Name = cname;
                        ApplePoint.Add(cname, point);
                        break;
                    case "Orange":
                        cname += "_" + countOrange;
                        tableLayoutPanel1.GetControlFromPosition(point.X, point.Y).Name = cname;
                        OrangePoint.Add(cname, point);
                        break;
                }
            }
        }
        //フルーツのPictureBoxの生成
        private Control CreateFruits(string name)
        {
            PictureBox fruits = new PictureBox();
            switch (name)
            {
                case "Apple":
                    countApple++;
                    fruits.Name = "Apple";
                    fruits.Size = new Size(100, 100);
                    fruits.SizeMode = PictureBoxSizeMode.StretchImage;
                    fruits.Image = Image.FromFile(FilePath + "\\images\\C2\\apple.png");
                    break;
                case "Orange":
                    countOrange++;
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
        //スタート
        private void Start()
        {
            try
            {
                Boolean flg = false;
                Boolean Aans = false;
                Boolean Oans = false;
                for (int i = 1; i <= ApplePoint.Count; i++)
                {
                    Control[] controls = panel4.Controls.Find("Apple_" + i, true);
                    foreach (Control c in controls)
                    {
                        TableLayoutPanelCellPosition p = tableLayoutPanel1.GetCellPosition(c);
                        for(int n = 1;n <= ApplePoint.Count; n++)
                        {
                            if (NumPoint["one_" + n] == new Point(p.Column, p.Row))
                            {
                                flg = true;
                            }
                        }
                    }
                    if(flg == true)
                    {
                        flg = false;
                    }
                    else
                    {
                        MessageBox.Show("ちがうよ！");
                        return;
                    }
                    if (i == ApplePoint.Count)
                    {
                        Aans = true;
                    }
                }
                if (Aans == true)
                {
                    //Apple座標一致
                    for (int i = 1; i <= OrangePoint.Count; i++)
                    {
                        Control[] controls = panel4.Controls.Find("Orange_" + i, true);
                        foreach (Control c in controls)
                        {
                            TableLayoutPanelCellPosition p = tableLayoutPanel1.GetCellPosition(c);
                            for(int n = 1; n <= OrangePoint.Count; n++)
                            {
                                if (NumPoint["two_" + n] == new Point(p.Column, p.Row))
                                {
                                    flg = true;
                                }
                            }
                        }
                        if (flg == true)
                        {
                            flg = false;
                        }
                        else
                        {
                            MessageBox.Show("ちがうよ！");
                            return;
                        }
                        if (i == OrangePoint.Count)
                        {
                            Oans = true;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("ちがうよ！");
                    return;
                }
                if (Oans == true && Aans == true)
                {
                    //両方の座標一致
                    MessageBox.Show("せいかい！！！");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("ちがうよ！！");
            }
        }

        private void review_back_button_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Clear();
            countApple = 0;
            countOrange = 0;
            ApplePoint.Clear();
            OrangePoint.Clear();
        }
    }
}
