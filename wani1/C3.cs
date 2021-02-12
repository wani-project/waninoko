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
                case "White":
                    colors.Name = "White";
                    colors.Image = Image.FromFile(FilePath + "\\images\\C3\\white.png");
                    break;
            }
            return (Control)colors;
        }

        private void review_back_button_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
