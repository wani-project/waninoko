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
    public partial class R3 : Form
    {
        private string FilePath = Directory.GetCurrentDirectory();
        PictureBox Chara;
        public R3()
        {
            InitializeComponent();
        }
        
        private void tableLayoutPanel1_Click(object sender, EventArgs e)
        {
            Start(1);
        }

        private void tableLayoutPanel2_Click(object sender,EventArgs e)
        {
            Start(2);
        }
        private void tableLayoutPanel3_Click(object sender, EventArgs e)
        {
            Start(3);
        }
        private async void Start(int num)
        {
            Reset();
            await Task.Delay(500);
            TableLayoutPanelCellPosition p = new TableLayoutPanelCellPosition(0, 3);
            Control[] controls = panel4.Controls.Find("chara", true);
            foreach(PictureBox con in controls)
            {
                Chara = con;
            }
            
            //前に進む
            if (p.Row != 0)
            {
                p.Row -= 1;
                field.SetCellPosition(Chara, p);
                field.Controls.Add(CreateLine(1), p.Column, p.Row + 1);
                await Task.Delay(1000);
            }

            //右に進む
            //Chara.Image = Rotate(Chara, 1);
            Chara.Image = Image.FromFile(FilePath + "\\images\\L3\\charaR.gif");
            await Task.Delay(1000);
            for (int r = 0; r < 3; r++)
            {
                if (p.Column != 3)
                {
                    p.Column += 1;
                    field.SetCellPosition(Chara, p);
                    if(r == 0)
                    {
                        field.Controls.Add(CreateLine(3), p.Column - 1, p.Row);
                    }
                    else
                    {
                        field.Controls.Add(CreateLine(2), p.Column - 1, p.Row);
                    }
                    await Task.Delay(1000);
                }
            }
            //左に進む
            Chara.Image = Image.FromFile(FilePath + "\\images\\L3\\chara.gif");
            await Task.Delay(1000);
            for (int l = 0;l < 2; l++)
            {
                if (p.Row != 0)
                {
                    p.Row -= 1;
                    field.SetCellPosition(Chara, p);
                    if (l == 0)
                    {
                        field.Controls.Add(CreateLine(4), p.Column, p.Row + 1);
                    }
                    else
                    {
                        field.Controls.Add(CreateLine(1), p.Column, p.Row + 1);
                    }
                    await Task.Delay(1000);
                }
            }
            if (num == 1)
            {
                PictureBox yes = new PictureBox();
                yes.Name = "yes";
                yes.Size = new Size(897, 587);
                yes.SizeMode = PictureBoxSizeMode.StretchImage;
                yes.Image = Image.FromFile(FilePath + "\\images\\seikai.gif");
                yes.Parent = panel4;
                panel4.Controls.Add(yes);
                yes.BringToFront();
                await Task.Delay(2800);
                Control[] c = panel4.Controls.Find("yes", true);
                foreach (Control con in c)
                {
                    panel4.Controls.Remove(con);
                }
            }
            else
            {
                PictureBox no = new PictureBox();
                no.Name = "no";
                no.Size = new Size(897, 587);
                no.SizeMode = PictureBoxSizeMode.StretchImage;
                no.Image = Image.FromFile(FilePath + "\\images\\matigai.gif");
                no.Parent = panel4;
                panel4.Controls.Add(no);
                no.BringToFront();
                await Task.Delay(2800);
                Control[] c = panel4.Controls.Find("no", true);
                foreach (Control con in c)
                {
                    panel4.Controls.Remove(con);
                }
            }
        }

        private void L3_Load(object sender, EventArgs e)
        {
            CreateChara(0,3);
        }
        private void CreateChara(int column,int row)
        {
            PictureBox chara = new PictureBox();
            chara.Name = "chara";
            chara.Image = Image.FromFile(FilePath + "\\images\\L4\\chara.gif");
            chara.Size = new Size(110, 108);
            chara.SizeMode = PictureBoxSizeMode.StretchImage;
            chara.BackColor = Color.Transparent;

            field.Controls.Add(chara, column, row);
        }
        private PictureBox CreateLine(int i)
        {
            PictureBox rt = new PictureBox();
            //移動線の作成
            switch (i)
            {
                case 1://straight
                    //縦線設定
                    rt.Name = "straight";
                    rt.Image = Image.FromFile(FilePath + "\\images\\L4\\straight.png");
                    rt.Size = new Size(110, 108);
                    rt.BackColor = Color.Transparent;
                    rt.SizeMode = PictureBoxSizeMode.StretchImage;
                    break;
                case 2://right
                    //横線設定
                    rt.Name = "right";
                    rt.Image = Image.FromFile(FilePath + "\\images\\L4\\right.png");
                    rt.Size = new Size(110, 108);
                    rt.BackColor = Color.Transparent;
                    rt.SizeMode = PictureBoxSizeMode.StretchImage;
                    break;
                case 3://turnR
                    //右折線設定
                    rt.Name = "turnR";
                    rt.Image = Image.FromFile(FilePath + "\\images\\L4\\turnR.png");
                    rt.Size = new Size(110, 108);
                    rt.BackColor = Color.Transparent;
                    rt.SizeMode = PictureBoxSizeMode.StretchImage;
                    break;
                case 4://turnL
                    //左折線設定
                    PictureBox turnL = new PictureBox();
                    rt.Name = "turnL";
                    rt.Image = Image.FromFile(FilePath + "\\images\\L3L4turnL.png");
                    rt.Size = new Size(110, 108);
                    rt.BackColor = Color.Transparent;
                    rt.SizeMode = PictureBoxSizeMode.StretchImage;
                    break;
            }
            return rt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reset();
        }
        private void Reset()
        {
            field.Controls.Clear();
            CreateChara(0,3);
        }

        private void review_back_button_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
