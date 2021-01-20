﻿using System;
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
            //CreateNum();
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
                SetCellItems(GetPoint(c),((PictureBox)sender).Name);

                
                //tableLayoutPanel1.GetControlFromPosition();
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

            //X座標
            if (0 < point.X && point.X <= w)
            {
                countX = 0;
            }
            else if (point.X <= w * 2)
            {
                countX = 1;
            }
            else if (point.X <= w * 3)
            {
                countX = 2;
            }
            else if (point.X <= w * 4)
            {
                countX = 3;
            }
            else if (point.X <= w * 5)
            {
                countX = 4;
            }

            //Y座標
            if (0 < point.Y && point.Y <= h)
            {
                countY = 0;
            }
            else if (point.Y <= h * 2)
            {
                countY = 1;
            }
            else if (point.Y <= h * 3)
            {
                countY = 2;
            }
            else if (point.Y <= h * 4)
            {
                countY = 3;
            }
            else if (point.Y <= h * 5)
            {
                countY = 4;
            }


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

    }
}