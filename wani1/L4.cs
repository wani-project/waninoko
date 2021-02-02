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
    public partial class L4 : Form
    {

        public Boolean talkflg = false;
        //ファイルパスの保持
        public string FilePath = Directory.GetCurrentDirectory();
        public string[] AddAnimal = { "動物名" };
        private int ans = 0;
        private Point[] points = { new Point(654, 205), new Point(778, 205), new Point(1028, 205), new Point(904, 205), new Point(654, 345), new Point(778, 345), new Point(904, 345), new Point(1028, 345) };
        private int[] count = { 9, 9, 9, 9, 9, 9, 9, 9};

        public L4()
        {
            InitializeComponent();
        }


        public void CreateControl(string kinds, int count)
        {
            switch (kinds)
            {
               /*ase "waniChara":
                    //パネルインスタンス
                    PictureBox wani = new PictureBox();
                    //名前
                    wani.Name = "wani";
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
                    break;*/
                case "seikai":
                    PictureBox seikai = new PictureBox();
                    seikai.Name = "seikai";
                    seikai.Size = new Size(646, 587);
                    seikai.SizeMode = PictureBoxSizeMode.StretchImage;
                    seikai.Image = Image.FromFile(FilePath + "\\images\\seikai.gif");
                    seikai.Location = new Point(573, 0);
                    seikai.Parent = panel4;
                    panel4.Controls.Add(seikai);
                    seikai.BringToFront();
                    break;
                case "miss":
                    PictureBox miss = new PictureBox();
                    miss.Name = "miss";
                    miss.Size = new Size(646, 587);
                    miss.SizeMode = PictureBoxSizeMode.StretchImage;
                    miss.Image = Image.FromFile(FilePath + "\\images\\matigai.gif");
                    miss.Location = new Point(573, 0);
                    miss.Parent = panel4;
                    panel4.Controls.Add(miss);
                    miss.BringToFront();
                    break;
            }
        }

        private async void Start()
        {
            //分岐処理部分----------------------------------------------------------------------
            
                if (ans == 1)
                {
                    CreateControl("seikai", 2);
                    await Task.Delay(2825);
                    Control[] re = new Control[0];
                    re = panel4.Controls.Find("seikai", true);
                    foreach (Control c in re)
                    {
                        panel4.Controls.Remove(c);
                    }

                    //========================================
                    //waniTalk();
                    //========================================
                }
                else
                {
                    CreateControl("miss", 2);
                    await Task.Delay(2800);
                    Control[] re = new Control[0];
                    re = panel4.Controls.Find("miss", true);
                    foreach (Control c in re)
                    {
                        panel4.Controls.Remove(c);
                    }

                    //========================================
                    //waniTalk();

                    //========================================

                }
            ans = 0;
        }

        /*private async void waniTalk()
        {
            //========================================
            Control[] controls = panel4.Controls.Find("wani", true);
            foreach(PictureBox c in controls)
            {
                c.Image = Image.FromFile(FilePath + "\\images\\talk.gif");
                await Task.Delay(5000);
                c.Image = Image.FromFile(FilePath + "\\images\\Idle.gif");
            }
            

            //========================================
        }*/
      
        private void button8_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ans = 1;
        }

        private void matigai_button_Click(object sender, EventArgs e)
        {
            ans = 0;
        }

        private void L4_Load(object sender, EventArgs e)
        {
            CreateControl("waniChara", 0);
            SetRandomPos();

            label2.Parent = pictureBox9;
            label3.Parent = pictureBox9;
            label4.Parent = pictureBox9;
            label1.Parent = pictureBox9;
            label5.Parent = pictureBox9;

            label2.Location = new Point(50, 100);
            label4.Location = new Point(50, 277);           

            pictureBox8.Parent = pictureBox7;
            label6.Parent = pictureBox8;

            pictureBox8.Location = new Point(5, 42);
            label6.Location = new Point(50, 30);

            //label6.Parent = pictureBox8;

            //pictureBox8.BackColor = Color.Transparent;
            //label6.BackColor = Color.Transparent;
        }

        private void review_back_button_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void SetRandomPos()
        {
            for (int i = 0; i < 8; i++)
            {
                count[i] = 9;
            }
            //時刻からシード値を取得
            int seed = Environment.TickCount;
            for (int i = 0; i < 8; i++)
            {
                Control[] controls = panel4.Controls.Find("button" + i, true);
                foreach (Button con in controls)
                {
                    //ランダム変数のインスタンス化
                    Random random = new Random(seed++);
                    //randNumに0～3のランダムな値を代入
                    int index = ((int)random.Next(8));
                    int buf = 0;
                    for (int x = 0; x < 8; x++)
                    {
                        if (count[x] == index)
                        {
                            if (index < 7)
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
                    count[i] = index;
                    con.Location = new Point(points[index].X, points[index].Y);
                }
            }
        }      
    }
}
