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
    public partial class L3 : Form
    {
        private string FilePath = Directory.GetCurrentDirectory();
        private Point[] points = { new Point(621, 219), new Point(771, 219), new Point(922,219), new Point(1053, 219) };
        private int[] count = { 0, 0, 0, 0 };
        private Boolean flg = false;
        public L3()
        {
            InitializeComponent();
        }
        //不正解
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            ViewAns(2);
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            pictureBox10.Image = Image.FromFile(@"C:\anime.gif");
        }
        //正解
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            ViewAns(1);
        }
        //不正解
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            ViewAns(2);
        }

        //不正解
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            ViewAns(2);
        }

        private async void ViewAns(int i)
        {
            PictureBox ans = new PictureBox();
            ans.Size = new Size(800,600);
            ans.SizeMode = PictureBoxSizeMode.StretchImage;
            ans.Location = new Point(0, 0);
            switch (i)
            {
                case 1:
                    ans.Image = Image.FromFile(FilePath + "\\images\\seikai.gif");
                    break;
                case 2:
                    ans.Image = Image.FromFile(FilePath + "\\images\\matigai.gif");
                    break;
            }
            panel1.Controls.Add(ans);
            ans.BringToFront();

            await Task.Delay(2500);
            panel1.Controls.Remove(ans);
        }
        private void SetRandomPos()
        {
            //時刻からシード値を取得
            int seed = Environment.TickCount;
            for (int i = 6; i <= 9; i++)
            {
                Control[] controls = panel1.Controls.Find("pictureBox" + i, true);
                foreach(PictureBox con in controls)
                {
                    //ランダム変数のインスタンス化
                    Random random = new Random(seed++);
                    //randNumに0～3のランダムな値を代入
                    int index = ((int)random.Next(3));
                    count[i - 6] = index;
                    if(flg == false)
                    {
                        flg = true;
                    }
                    else
                    {
                        if(count[i - 7] == count[i - 6])
                        {
                            switch (index)
                            {
                                case 0:break;
                                case 1:break;
                                case 2:break;
                                case 3:break;
                            }
                        }
                    }
                    con.Location = new Point(points[index].X, con.Location.Y);
                }
            }
        }
        private int CreateRandom()
        {
            //時刻からシード値を取得
            int seed = Environment.TickCount;
            //ランダム変数のインスタンス化
            Random random = new Random(seed++);
            //randNumに0～50のランダムな値を代入
            return ((int)random.Next(0, 4));
        }

        private void L3_Load(object sender, EventArgs e)
        {
            SetRandomPos();
        }
    }
}
