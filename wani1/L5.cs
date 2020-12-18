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
    public partial class L5 : Form
    {
        public Boolean talkflg = false;
        //ファイルパスの保持
        public string FilePath = Directory.GetCurrentDirectory();
        public string[] AddAnimal = { "動物名" };
        public int ans = 0;
        

        public L5()
        {
            InitializeComponent();
        }


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


        //まちがい　--------------------------------------------------------------------
        private void button7_Click(object sender, EventArgs e)
        {
            Start(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Start(0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Start(0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Start(0);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Start(0);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Start(0);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Start(0);
        }

        //=============================================



        //せいかい　-----------------------------------------------------------

        private void button9_Click(object sender, EventArgs e)
        {
            Start(1);
        }

        private async void waniTalk()
        {
            //========================================
            talkflg = true;
            CreateControl("waniChara", 0);
            await Task.Delay(5000);
            talkflg = false;
            CreateControl("waniChara", 0);

            //========================================
        }


        private async void Start(int num)
        {      
            //分岐処理部分----------------------------------------------------------------------
                if (num == 1)
                {
                    textBox1.Text = "せいかい！！すごい！！！";
                    CreateControl("seikai", 2);
                    await Task.Delay(2825);
                    Control[] re = new Control[0];
                    re = panel4.Controls.Find("seikai", true);
                    foreach (Control c in re)
                    {
                        panel4.Controls.Remove(c);
                    }

                    //========================================
                    waniTalk();
                    //========================================
                }
                else
                {
                    textBox1.Text = "まちがい...つぎはできるよ！\r\nがんばって！！！";
                    CreateControl("miss", 2);
                    await Task.Delay(2800);
                    Control[] re = new Control[0];
                    re = panel4.Controls.Find("miss", true);
                    foreach (Control c in re)
                    {
                        panel4.Controls.Remove(c);
                    }

                    //========================================
                    waniTalk();

                    //========================================

                }         
        }

        private void review_back_button_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void L5_Load(object sender, EventArgs e)
        {
            CreateControl("waniChara", 0);
        }
    }
}
