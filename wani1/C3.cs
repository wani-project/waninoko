using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wani1
{
    public partial class C3 : Form
    {
        private string FilePath = Directory.GetCurrentDirectory();
        private List <Point> q1_t1_p = new List<Point>(0);
        private List <Point> q1_t2_p = new List<Point>(0);
        private List <Point> q1_ans_p = new List<Point>(0);
        private List<Point> q1_Uans_p = new List<Point>(0);
        public C3()
        {
            InitializeComponent();
        }
        private void CellClick(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;
            //セルに入れる処理を記述
            Point c = new Point(x, y);
            SetCellItems(GetPoint(c), "Black");
            
        }
        //セル取得処理
        private Point GetPoint(Point point)
        {
            int countX = 0;
            int countY = 0;
            int height = q1_ans.Height;
            int width = q1_ans.Width;
            int h = height / 3;
            int w = width / 3;

            countX = (point.X - ((point.X - 1) % 10)) / w;
            countY = (point.Y - ((point.Y - 1) % 10)) / h;

            return new Point(countX, countY);
        }
        //セルに画像を追加する処理
        private void SetCellItems(Point point, string name)
        {
            string cname;
            if (q1_ans.GetControlFromPosition(point.X, point.Y) == null)
            {
                q1_ans.Controls.Add(CreateColors(name), point.X, point.Y);
                cname = q1_ans.GetControlFromPosition(point.X, point.Y).Name;
                switch (cname)
                {
                    case "Black":
                        //q1_ans.GetControlFromPosition(point.X, point.Y).Name = cname;
                        //ApplePoint.Add(cname, point);
                        break;
                    case "White":
                        //q1_ans.GetControlFromPosition(point.X, point.Y).Name = cname;
                        //OrangePoint.Add(cname, point);
                        break;
                }
            }
        }
        //白黒のPictureBoxの生成
        private Control CreateColors(string name)
        {
            PictureBox colors = new PictureBox();
            colors.Size = new Size(100, 100);
            colors.SizeMode = PictureBoxSizeMode.StretchImage;
            colors.BackColor = Color.Transparent;
            switch (name)
            {
                case "Black":
                    colors.Name = "Black";
                    colors.Image = Image.FromFile(FilePath + "\\images\\C3\\black.png");
                    break;
            }
            return (Control)colors;
        }

        private void GetAns()
        {
            Control[] controls1 = q1_t1.Controls.Find("Black", true);
            foreach(Control c in controls1)
            {
                q1_t1_p.Add(GetPoint(c.Location));
            }
            controls1 = q1_t2.Controls.Find("Black", true);
            foreach (Control c in controls1)
            {
                q1_t2_p.Add(GetPoint(c.Location));
            }

            for(int i = 0; i < q1_t1_p.Count; i++)
            {
                for(int y = 0; y < q1_t2_p.Count; y++)
                {
                    if(q1_t1_p[i] == q1_t2_p[y])
                    {
                        q1_ans_p.Add(q1_t1_p[i]);
                        break;
                    }
                }
            }
        }
        private void InsertNum(Control control,TableLayoutPanel table)
        {
            try
            {
                int seed = Environment.TickCount;
                Random random = new Random();
                int[] rand = new int[2];
                for (int i = 0; i < 2; i++)
                {
                    random = new Random(seed++);
                    rand[i] = (int)random.Next(3);
                }
                Boolean flg = false;
                int count = 0;
                int bufX = 999;
                int bufY = 999;
                do
                {

                    TableLayoutPanelCellPosition p = new TableLayoutPanelCellPosition(rand[0], rand[1]);
                    if (table.GetControlFromPosition(p.Column, p.Row) == null)
                    {
                        table.Controls.Add(control, p.Column, p.Row);
                        
                        count = 0;
                        bufX = 999;
                        bufY = 999;
                        break;
                    }
                    else
                    {
                        random = new Random(seed++);
                        p.Row = (int)random.Next(3);
                        if (count > 0)
                        {
                            if (bufY == p.Row)
                            {
                                if (p.Row < 2)
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
                        p.Column = (int)random.Next(3);
                        if (count > 0)
                        {
                            if (bufX == p.Column)
                            {
                                if (p.Column < 2)
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private int Random()
        {
            int seed = Environment.TickCount;
            Random random = new Random(seed++);
            return (int)random.Next(4, 7);
        }
        private void review_back_button_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void C3_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < Random(); i++)
            {
                InsertNum(CreateColors("Black"),q1_t1);
            }
            for(int i = 0;i < Random(); i++)
            {
                InsertNum(CreateColors("Black"), q1_t2);
            }
            GetAns();
        }
        //start
        private void button3_Click(object sender, EventArgs e)
        {
            Start();
        }
        //reset
        private void button1_Click(object sender, EventArgs e)
        {
            Reset();
        }
        private void Start()
        {
            Boolean flg = false;
            Boolean Aflg = false;
            q1_Uans_p.Clear();
            Control[] controls = q1_ans.Controls.Find("Black", true);
            foreach (Control con in controls)
            {
                q1_Uans_p.Add(GetPoint(con.Location));
            }
            if(q1_Uans_p.Count != q1_ans_p.Count)
            {
                //間違い
                Answer(0);
                return;
            }
            for(int i = 0; i < q1_ans_p.Count; i++)
            {
                for(int y = 0; y < q1_Uans_p.Count; y++)
                {
                    if(q1_ans_p[i] == q1_Uans_p[y])
                    {
                        flg = true;
                        break;
                    }
                }
                if(flg != true)
                {
                    //間違い
                    Answer(0);
                    return;
                }
                else
                {
                    flg = false;
                }
                if(i == q1_ans_p.Count - 1)
                {
                    Aflg = true;
                }
            }
            if(Aflg != true)
            {
                //間違い
                Answer(0);
                return;
            }
            else
            {
                //正解
                Answer(1);

            }
        }
        private void Reset()
        {
            //テーブル初期化
            q1_ans.Controls.Clear();
            //リスト初期化
            q1_Uans_p.Clear();
        }
        private async void Answer(int ans)
        {
            switch (ans)
            {
                case 0://不正解
                    PictureBox no = new PictureBox();
                    no.Name = "no";
                    no.Size = new Size(742, 587);
                    no.Location = new Point(477, 0);
                    no.SizeMode = PictureBoxSizeMode.StretchImage;
                    no.Image = Image.FromFile(FilePath + "\\images\\matigai.gif");
                    no.Parent = panel4;
                    panel4.Controls.Add(no);
                    no.BringToFront();
                    await Task.Delay(2800);
                    Control[] c = panel4.Controls.Find("no", true);
                    foreach (Control con1 in c)
                    {
                        panel4.Controls.Remove(con1);
                    }
                    break;
                case 1://正解
                    PictureBox yes = new PictureBox();
                    yes.Name = "yes";
                    yes.Size = new Size(742, 587);
                    yes.Location = new Point(477, 0);
                    yes.SizeMode = PictureBoxSizeMode.StretchImage;
                    yes.Image = Image.FromFile(FilePath + "\\images\\seikai.gif");
                    yes.Parent = panel4;
                    panel4.Controls.Add(yes);
                    yes.BringToFront();
                    await Task.Delay(2800);
                    Control[] con = panel4.Controls.Find("yes", true);
                    foreach (Control con2 in con)
                    {
                        panel4.Controls.Remove(con2);
                    }
                    break;
            }

        }
    }
}
