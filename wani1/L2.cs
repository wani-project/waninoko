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
    public partial class L2 : Form
    {
        private Boolean talkflg = false;
        private string FilePath = Directory.GetCurrentDirectory();
        public L2()
        {
            InitializeComponent();
        }

        private void L2_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            CreateControl("waniChara", 0);
            CreateControl("docat", 2);
        }
        //docatクリック
        private async void docat_Click(object sender, EventArgs e)
        {
            //不正解
            Answer(0);
            textBox1.Text = "ざんねん！！";
            talkflg = true;
            await Task.Delay(2800);
            CreateControl("waniChara", 0);
            await Task.Delay(1500);
            talkflg = false;
            CreateControl("waniChara", 0);
        }
        private async void docat_Click_Correct(object sender, EventArgs e)
        {
            //正解
            Answer(1);
            textBox1.Text = "せいかい！すごいね！";
            talkflg = true;
            await Task.Delay(2800);
            CreateControl("waniChara", 0);
            await Task.Delay(1500);
            talkflg = false;
            CreateControl("waniChara", 0);
                
            
        }
        private void CreateControl(string kinds,int num)
        {
            switch (kinds)
            {
                case "waniChara":
                    Learn learn = new Learn();
                    //パネルインスタンス
                    PictureBox wani = new PictureBox();
                    //名前
                    wani.Name = "waniGif";
                    //サイズ設定
                    wani.SizeMode = PictureBoxSizeMode.Zoom;
                    //サイズ
                    wani.Size = new Size(200, 200);
                    //画像
                    if (talkflg == false)
                    {
                        wani.Image = Image.FromFile(learn.FilePath + "\\images\\Idle.gif");
                    }
                    else if (talkflg == true)
                    {
                        wani.Image = Image.FromFile(learn.FilePath + "\\images\\talk.gif");
                    }

                    //色
                    wani.BackColor = Color.FromName("Transparent");
                    //透過？
                    Bitmap bitmap = new Bitmap(wani.Image);
                    //bitmap.MakeTransparent(Color.FromArgb(0, 255, 255));
                    //wani.Image = bitmap;
                    //座標
                    wani.Location = new Point(980, 388);
                    //作業領域に追加
                    panel1.Controls.Add(wani);
                    //最前面に設定
                    wani.BringToFront();
                    break;
                case "docat":
                    learn = new Learn();

                    PictureBox docat0 = new PictureBox();
                    PictureBox docat1 = new PictureBox();
                    PictureBox docat2 = new PictureBox();
                    PictureBox docat3 = new PictureBox();
                    Label n1 = new Label();
                    Label n2 = new Label();
                    Label n3 = new Label();

                    string[] cards = { learn.FilePath + "\\images\\docat\\card1.png", learn.FilePath + "\\images\\docat\\card2.png", learn.FilePath + "\\images\\docat\\card3.png" };
                    //番号
                    n1.Text = "①";
                    n2.Text = "②";
                    n3.Text = "③";
                    //番号サイズ
                    n1.Font = new Font(n1.Font.FontFamily, 20);
                    n2.Font = new Font(n2.Font.FontFamily, 20);
                    n3.Font = new Font(n3.Font.FontFamily, 20);

                    n1.Size = new Size(40, 40);
                    n2.Size = new Size(40, 40);
                    n3.Size = new Size(40, 40);


                    //名前
                    docat0.Name = "docat0";
                    docat1.Name = "docat1";
                    docat2.Name = "docat2";
                    docat3.Name = "docat3";
                    //サイズ設定
                    docat0.SizeMode = PictureBoxSizeMode.StretchImage;
                    docat1.SizeMode = PictureBoxSizeMode.StretchImage;
                    docat2.SizeMode = PictureBoxSizeMode.StretchImage;
                    docat3.SizeMode = PictureBoxSizeMode.StretchImage;
                    //サイズ
                    docat0.Size = new Size(160, 102);
                    docat1.Size = new Size(500, 102);
                    docat2.Size = new Size(500, 102);
                    docat3.Size = new Size(500, 102);
                    //色
                    docat0.BackColor = Color.Transparent;
                    docat1.BackColor = Color.Transparent;
                    docat2.BackColor = Color.Transparent;
                    docat3.BackColor = Color.Transparent;

                    //座標
                    docat0.Location = new Point(20, 10);
                    docat1.Location = new Point(20, 120);
                    docat2.Location = new Point(20, 230);
                    docat3.Location = new Point(20, 340);


                    //画像
                    docat0.Image = Image.FromFile(learn.FilePath + "\\images\\docat\\card0.png");

                    //カードをランダムで表示させる-------------------------------------------------------------------------------------------
                    int seed = Environment.TickCount;
                    int[] index = { 0, 0, 0 };
                    for (int i = 0; i < 3; i++)
                    {
                        //ランダムのインスタンス
                        Random rd = new Random(seed++);
                        //ランダムで0～2の乱数を保持
                        index[i] = (int)rd.Next(0, 3);
                        //ランダム処理------------------------------------------------------------------------------------
                        switch (i)
                        {
                            case 0://一枚目
                                docat1.Image = Image.FromFile(cards[index[0]]); //1
                                if (index[0] == 0)
                                {
                                    docat1.Click += new EventHandler(this.docat_Click_Correct);
                                }
                                else
                                {
                                    docat1.Click += new EventHandler(this.docat_Click);
                                }
                                break;
                            case 1://二枚目
                                if (index[i - 1] == index[i])    //0
                                {
                                    switch (index[i - 1])
                                    {
                                        case 0:
                                            docat2.Image = Image.FromFile(cards[index[i]]);
                                            docat2.Click += new EventHandler(this.docat_Click);
                                            break;
                                        case 1:
                                            Random rrr = new Random(seed++);
                                            int rda = rrr.Next(0, 2);
                                            if (rda == 1)
                                            {
                                                rda = 0;
                                            }
                                            docat2.Image = Image.FromFile(cards[rda]);
                                            if (rda == 0)
                                            {
                                                docat2.Click += new EventHandler(this.docat_Click_Correct);
                                            }
                                            else
                                            {
                                                docat2.Click += new EventHandler(this.docat_Click);
                                            }
                                            break;
                                        case 2:
                                            rrr = new Random(seed++);
                                            rda = rrr.Next(0, 1);
                                            if (rda == 2)
                                            {
                                                rda = 1;
                                            }
                                            docat2.Image = Image.FromFile(cards[rda]);
                                            if (rda == 0)
                                            {
                                                docat2.Click += new EventHandler(this.docat_Click_Correct);
                                            }
                                            else
                                            {
                                                docat2.Click += new EventHandler(this.docat_Click);
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                else
                                {
                                    docat2.Image = Image.FromFile(cards[index[1]]);
                                    if (index[1] == 0)
                                    {
                                        docat2.Click += new EventHandler(this.docat_Click_Correct);
                                    }
                                    else
                                    {
                                        docat2.Click += new EventHandler(this.docat_Click);
                                    }

                                }
                                break;
                            case 2://三枚目
                                if (index[i - 1] == index[i]) //1
                                {
                                    switch (index[i - 1])
                                    {
                                        case 0:
                                            if (index[i - 2] == 1)
                                            {
                                                docat3.Image = Image.FromFile(cards[2]);
                                                docat3.Click += new EventHandler(this.docat_Click);
                                            }
                                            else
                                            {
                                                docat3.Image = Image.FromFile(cards[1]);
                                                docat3.Click += new EventHandler(this.docat_Click);
                                            }
                                            break;
                                        case 1:
                                            if (index[i - 2] == 2)
                                            {
                                                docat3.Image = Image.FromFile(cards[0]);
                                                docat3.Click += new EventHandler(this.docat_Click_Correct);
                                            }
                                            else
                                            {
                                                docat3.Image = Image.FromFile(cards[2]);
                                                docat3.Click += new EventHandler(this.docat_Click);
                                            }
                                            break;
                                        case 2:
                                            if (index[i - 2] == 0)
                                            {
                                                docat3.Image = Image.FromFile(cards[1]);
                                                docat3.Click += new EventHandler(this.docat_Click);
                                            }
                                            else
                                            {
                                                docat3.Image = Image.FromFile(cards[0]);
                                                docat3.Click += new EventHandler(this.docat_Click_Correct);
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                else if (index[i - 2] == index[i])    //[0]と[2]がかぶり　[1]と[2]は別
                                {
                                    switch (index[i - 2])
                                    {
                                        case 0:
                                            if (index[1] == 1)
                                            {
                                                docat3.Image = Image.FromFile(cards[2]);
                                                docat3.Click += new EventHandler(this.docat_Click);
                                            }
                                            else if (index[1] == 2)
                                            {
                                                docat3.Image = Image.FromFile(cards[1]);
                                                docat3.Click += new EventHandler(this.docat_Click);
                                            }
                                            break;
                                        case 1:
                                            if (index[1] == 0)
                                            {
                                                docat3.Image = Image.FromFile(cards[2]);
                                                docat3.Click += new EventHandler(this.docat_Click);
                                            }
                                            else if (index[1] == 2)
                                            {
                                                docat3.Image = Image.FromFile(cards[0]);
                                                docat3.Click += new EventHandler(this.docat_Click_Correct);
                                            }
                                            break;
                                        case 2:
                                            if (index[1] == 0)
                                            {
                                                docat3.Image = Image.FromFile(cards[1]);
                                                docat3.Click += new EventHandler(this.docat_Click);
                                            }
                                            else if (index[1] == 1)
                                            {
                                                docat3.Image = Image.FromFile(cards[0]);
                                                docat3.Click += new EventHandler(this.docat_Click_Correct);
                                            }
                                            break;
                                        default:
                                            break;

                                    }
                                }
                                else
                                {
                                    docat3.Image = Image.FromFile(cards[index[2]]);
                                    if (index[2] == 0)
                                    {
                                        docat3.Click += new EventHandler(this.docat_Click_Correct);
                                    }
                                    else
                                    {
                                        docat3.Click += new EventHandler(this.docat_Click);
                                    }
                                }
                                break;
                        }
                    }
                    panel1.Controls.Add(docat0);
                    panel1.Controls.Add(docat1);
                    panel1.Controls.Add(docat2);
                    panel1.Controls.Add(docat3);
                    docat0.BringToFront();
                    docat1.BringToFront();
                    docat2.BringToFront();
                    docat3.BringToFront();
                    break;
            }
            
        }

        

        private void learn_back_button_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Control[] con0 = new Control[0];
            Control[] con1 = new Control[0];
            Control[] con2 = new Control[0];
            Control[] con3 = new Control[0];

            con0 = panel1.Controls.Find("docat0", true);
            con1 = panel1.Controls.Find("docat1", true);
            con2 = panel1.Controls.Find("docat2", true);
            con3 = panel1.Controls.Find("docat3", true);
            foreach (Control c0 in con0)
            {
                panel1.Controls.Remove(c0);
            }
            foreach (Control c1 in con1)
            {
                panel1.Controls.Remove(c1);
            }
            foreach (Control c2 in con2)
            {
                panel1.Controls.Remove(c2);
            }
            foreach (Control c3 in con3)
            {
                panel1.Controls.Remove(c3);
            }
            textBox1.Text = "";
            CreateControl("docat", 2);
            if (talkflg == true)
            {
                talkflg = false;
            }
            CreateControl("waniChara", 0);
        }

        private async void Answer(int i)
        {
            switch (i)
            {
                case 0:
                    PictureBox no = new PictureBox();
                    no.Name = "no";
                    no.Size = new Size(1228, 593);
                    no.SizeMode = PictureBoxSizeMode.StretchImage;
                    no.Image = Image.FromFile(FilePath + "\\images\\matigai.gif");
                    no.Parent = panel1;
                    panel1.Controls.Add(no);
                    no.BringToFront();
                    await Task.Delay(2800);
                    Control[] c1 = panel1.Controls.Find("no", true);
                    foreach (Control con in c1)
                    {
                        panel1.Controls.Remove(con);
                    }
                    break;
                case 1:
                    PictureBox yes = new PictureBox();
                    yes.Name = "yes";
                    yes.Size = new Size(1228, 593);
                    yes.SizeMode = PictureBoxSizeMode.StretchImage;
                    yes.Image = Image.FromFile(FilePath + "\\images\\seikai.gif");
                    yes.Parent = panel1;
                    panel1.Controls.Add(yes);
                    yes.BringToFront();
                    await Task.Delay(2800);
                    Control[] c2 = panel1.Controls.Find("yes", true);
                    foreach (Control con in c2)
                    {
                        panel1.Controls.Remove(con);
                    }
                    break;
            }
        }
    }
}
    
