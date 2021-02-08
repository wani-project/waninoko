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
    public partial class L6 : Form
    {

        public Boolean talkflg = false;
        //ファイルパスの保持
        public string FilePath = Directory.GetCurrentDirectory();
        //じゃんけんの手を保持
        private int hanako = 0;
        private int satoshi = 0;
        private int ans = 0;
        private int hanakoAns = 0;
        private int satoshiAns = 0;
        //ランダム
        private Point[] points = { new Point(103, 107), new Point(103, 191), new Point(103, 283) };
        private int[] count = { 9, 9, 9 };
        public L6()
        {
            InitializeComponent();
        }


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

    
        //さとし--------------------------------------------------------------
        private void button5_Click(object sender, EventArgs e)
        {
            //グー
            satoshi = 1;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //チョキ
            satoshi = 2;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //パー
            satoshi = 3;
        }
        //はなこ------------------------------------------------------
        private void button10_Click(object sender, EventArgs e)
        {
            //グー
            hanako = 1;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //チョキ
            hanako = 2;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //パー
            hanako = 3;
        }

        //------------------------------------------------------------------------
        private void L6_Load(object sender, EventArgs e)
        {
            CreateControl("waniChara", 0);
            SetRandomPos();
            GetAns();

            //いぬ　ねこ　ねずみ
            pictureBox0.Parent = pictureBox3;
            pictureBox1.Parent = pictureBox3;
            pictureBox2.Parent = pictureBox3;

            //パー　チョキ　グー
            pa.Parent = pictureBox3;
            choki.Parent = pictureBox3;
            gu.Parent = pictureBox3;

            //ラベル
            label2.Parent = pictureBox3;
            label3.Parent = pictureBox3;
            label4.Parent = pictureBox3;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void Start()
        {
            //分岐処理部分----------------------------------------------------------------------
            if (satoshi == satoshiAns && hanako == hanakoAns)
            {
                
                if (ans == 2)
                {
                    switch (hanako)
                    {//はなこが
                        case 1://グー
                            if(satoshi == 2)
                            {
                                textBox1.Text = "せいかい！！";
                            }
                            else
                            {
                                textBox1.Text = "まちがい";
                            }
                            break;
                        case 2://チョキ
                            if(satoshi == 3)
                            {
                                textBox1.Text = "せいかい！！";
                            }
                            else
                            {
                                textBox1.Text = "まちがい";
                            }
                            break;
                        case 3://パー
                            if(satoshi == 1)
                            {
                                textBox1.Text = "せいかい！！";
                            }
                            else
                            {
                                textBox1.Text = "まちがい";
                            }
                            break;
                    }
                    
                }
                else if (ans == 1)
                {
                    switch (satoshi)
                    {//さとしが
                        case 1://グー
                            if (hanako == 2)
                            {
                                textBox1.Text = "せいかい！！";
                            }
                            else
                            {
                                textBox1.Text = "まちがい";
                            }
                            break;
                        case 2://チョキ
                            if (hanako == 3)
                            {
                                textBox1.Text = "せいかい！！";
                            }
                            else
                            {
                                textBox1.Text = "まちがい";
                            }
                            break;
                        case 3://パー
                            if (hanako == 1)
                            {
                                textBox1.Text = "せいかい！！";
                            }
                            else
                            {
                                textBox1.Text = "まちがい";
                            }
                            break;
                    }

                }
            }
            else
            {
                textBox1.Text = "てがちがうよ！";
            }
        }
        
        //---------------------------------------------------------------------


        private void button1_Click(object sender, EventArgs e)
        {
            //さとしくん
            ans = 1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //はなこさん
            ans = 2;
        }

        private void review_back_button_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        //ランダム処理
        private void SetRandomPos()
        {
            for (int i = 0; i < 3; i++)
            {
                count[i] = 9;
            }
            //時刻からシード値を取得
            int seed = Environment.TickCount;
            for (int i = 0; i < 3; i++)
            {
                Control[] controls = panel4.Controls.Find("pictureBox" + i, true);
                foreach (PictureBox con in controls)
                {
                    //ランダム変数のインスタンス化
                    Random random = new Random(seed += 3);
                    //randNumに0～3のランダムな値を代入
                    int index = ((int)random.Next(3));
                    int buf = 0;
                    for (int x = 0; x < 3; x++)
                    {
                        if (count[x] == index)
                        {
                            if (index < 2)
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
                    con.Location = new Point(con.Location.X, points[index].Y);
                }
            }
        }

        private void GetAns()
        {
            Boolean flg = false;
            for(int i = 1;i <= 2; i++)
            {
                Control[] controls = panel4.Controls.Find("pictureBox" + i, true);
                foreach(Control c in controls)
                {
                    if(c.Location == points[0])
                    {
                        if (!flg)
                        {
                            satoshiAns = 3;
                        }
                        else
                        {
                            hanakoAns = 3;
                        }
                    }
                    else if(c.Location == points[1])
                    {
                        if (!flg)
                        {
                            satoshiAns = 2;
                        }
                        else
                        {
                            hanakoAns = 2;
                        }
                    }
                    else if (c.Location == points[2])
                    {
                        if (!flg)
                        {
                            satoshiAns = 1;
                        }
                        else
                        {
                            hanakoAns = 1;
                        }
                    }

                }
                flg = true;
            }
        }
    }
}






       

