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
        public string[] AddAnimal = { "動物名" };
        private int hanako = 0;
        private int satoshi = 0;
        private int ans = 0;

        public L6()
        {
            InitializeComponent();
        }


        //開始時の部品作成処理（左側の部品一覧やカードの初期配置等）a
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
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void Start()
        {
            //分岐処理部分----------------------------------------------------------------------
            if (satoshi == 2)
            {
                if (hanako == 1 && ans == 2)
                {
                    textBox1.Text = "せいかい！！";
                }
                else
                {
                    textBox1.Text = "まちがい";
                }
            }
            else if(hanako == 1)
            {
                textBox1.Text = "まちがい";
            }
            else
            {
                textBox1.Text = "まちがい";
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

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}






       

