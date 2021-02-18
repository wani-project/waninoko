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
    public partial class R5 : Form
    {
        public Boolean talkflg = false;
        private string FilePath = Directory.GetCurrentDirectory();
        private Point[] points = { new Point(625, 108), new Point(625, 190), new Point(625, 276), new Point(625, 358) };
        private int[] count = { 9, 9, 9, 9 };


        //開始時の部品作成処理（左側の部品一覧やカードの初期配置等）
        public void CreateControl(string kinds, int count)
        {
            switch (kinds)
            {
                case "waniChara":              
                    //追加カウント
                    count++;
                    //パネルインスタンス
                    PictureBox wani = new PictureBox();
                    //名前
                    wani.Name = "waniGif_" + count;
                    //サイズ設定
                    wani.SizeMode = PictureBoxSizeMode.Zoom;
                    //サイズ
                    wani.Size = new Size(150, 150);
                    //画像
                    if (talkflg == false)
                    {
                        wani.Image = Image.FromFile(FilePath + "\\images\\Idle.gif");
                    }
                    else if (talkflg == true)
                    {
                        wani.Image = Image.FromFile(FilePath + "\\images\\talk.gif");
                    }
                    //色
                    wani.BackColor = Color.FromName("Transparent");
                    //座標
                    wani.Location = new Point(1080, 440);
                    //作業領域に追加
                    panel4.Controls.Add(wani);
                    //最前面に設定
                    wani.BringToFront();
                    break;
            }
        }

        public R5()
        {
            InitializeComponent();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            ViewAns(2);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ViewAns(2);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            ViewAns(1);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            ViewAns(2);
        }

        private async void ViewAns(int i)
        {
            PictureBox ans = new PictureBox();
            ans.Size = new Size(646, 587);
            ans.SizeMode = PictureBoxSizeMode.StretchImage;
            ans.Location = new Point(573, 0);
            switch (i)
            {
                case 1:
                    ans.Image = Image.FromFile(FilePath + "\\images\\seikai.gif");
                    textBox1.Text = "せいかい！！";
                    talkflg = true;
                    break;
                case 2:
                    ans.Image = Image.FromFile(FilePath + "\\images\\matigai.gif");
                    textBox1.Text = "まちがい！！";
                    talkflg = true;
                    break;
            }
            talkflg = false;
            panel4.Controls.Add(ans);
            ans.BringToFront();

            await Task.Delay(2500);
            panel4.Controls.Remove(ans);
        }
        private void SetRandomPos()
        {
            for (int i = 0; i < 4; i++)
            {
                count[i] = 9;
            }
            //時刻からシード値を取得
            int seed = Environment.TickCount;
            for (int i = 6; i <= 9; i++)
            {
                Control[] controls = panel4.Controls.Find("pictureBox" + i, true);
                foreach (PictureBox con in controls)
                {
                    //ランダム変数のインスタンス化
                    Random random = new Random(seed += 3);
                    //randNumに0～3のランダムな値を代入
                    int index = ((int)random.Next(3));
                    int buf = 0;
                    for (int x = 0; x < 4; x++)
                    {
                        if (count[x] == index)
                        {
                            if (index < 3)
                            {
                                index++;
                            }
                            else
                            {
                                index = 0;
                            }
                            buf = x;
                            x = -1;
                        }
                    }
                    count[i - 6] = index;
                    con.Location = new Point(points[index].X, con.Location.Y);
                }
            }
        }

        private void review_back_button_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void R5_Load(object sender, EventArgs e)
        {
            textBox1.Text = "スタートはふくまないよ！";
            SetRandomPos();
            CreateControl("waniChara", 0);

            //いぬ　ねこ　ねずみ
            pictureBox0.Parent = pictureBox3;
            pictureBox1.Parent = pictureBox3;
            pictureBox2.Parent = pictureBox3;

            //ラベル
            label2.Parent = pictureBox3;
            label3.Parent = pictureBox3;
            label4.Parent = pictureBox3;
        }
    }
}
