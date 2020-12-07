using System;
using System.Collections;
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
    public partial class Learn : Form
    {
        private Transform tf = new Transform();
        public string[] AddAnimal = { "動物名" };
        public int questNum;
        public string questTitle;
        public ArrayList questControl = new ArrayList();
        public Boolean talkflg = false;
        //ファイルパスの保持
        public string FilePath = Directory.GetCurrentDirectory();
        public Learn()
        {
            InitializeComponent();
        }

        private void learn_back_button_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.ScreenSwitch();
            this.Dispose();
        }

        private void Learn_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            CreateControl("waniChara", 0);
            //選択された問題のデータを取得---------------

            //-------------------------------------------

            //取得したデータから必要な部品を作成-------------------
            switch (questNum)
            {
                case 1:
                    CreateControl("dog", 1);
                    wani_block.Visible = false;
                    textTitle.Text = questTitle;
                    textBox1.Text = "じゅんばんにきをつけてね！";
                    comboKinds.Visible = false;
                    break;
                case 2:
                    wani_block.Visible = false;
                    CreateControl("docat", 2);
                    textTitle.Text = questTitle;
                    comboKinds.Visible = false;
                    break;
                default:
                    wani_block.Visible = true;
                    //tf.TransformControl(test, "test");
                    //tf.TransformControl(wani, "wani");
                    break;
            }
            //-----------------------------------------------------
        }


        //ドラッグアンドドロップ処理-----------------------------------------
        //初期変数---------------------------
        bool _isDraging = false;
        Point? _diffPoint = null;
        Point test_def = new Point(35, 115);
        //-----------------------------------
        private void dog_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox pb = ((PictureBox)sender);
            test_def = pb.Location;
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            Cursor.Current = Cursors.Hand;
            _isDraging = true;
            _diffPoint = e.Location;

            panel3.Size = pb.Size;
            panel3.Location = pb.Location;

        }
        private void dog_MouseMove(object sender, MouseEventArgs e)
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
            panel3.Location = new Point(x, y);
            pb.BringToFront();
        }
        private void dog_MouseUp(object sender, MouseEventArgs e)
        {


            PictureBox pb = ((PictureBox)sender);
            Cursor.Current = Cursors.Default;
            _isDraging = false;

            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            Point loc = new Point(pb.Location.X, panel3.Location.Y);
            if (loc.X >= 379 && loc.Y >= 64)
            {
                tf.CreateControl(pb.Size, loc, this, "dog", pb.Name);
                tf.SetParent(this, "dog", questControl);
            }
            pb.Location = test_def;
        }
        //-------------------------------------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            switch (questNum)
            {

                case 1:
                    talkflg = true;
                    CreateControl("waniChara", 0);
                    string ans = "";
                    for (int i = 0; i < 3; i++)
                    {
                        ans += tf.dogAns[i];
                    }
                    Timer timer = new Timer();
                    timer.Start();

                    if (ans == "123")
                    {
                        textBox1.Text = "せいかい！！";

                    }
                    else
                    {
                        textBox1.Text = "じゅんばんがまちがってるよ！！";
                    }
                    while (timer.Interval >= 500)
                    {
                        if (timer.Interval >= 300)
                        {
                            timer.Stop();
                            talkflg = false;
                            CreateControl("waniChara", 0);
                            break;
                        }
                    }
                    break;
                default:
                    break;
            }
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
                    wani.Size = new Size(200, 200);
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
                    //透過？
                    Bitmap bitmap = new Bitmap(wani.Image);
                    //bitmap.MakeTransparent(Color.FromArgb(0, 255, 255));
                    //wani.Image = bitmap;
                    //座標
                    wani.Location = new Point(641, 388);
                    //作業領域に追加
                    panel1.Controls.Add(wani);
                    //最前面に設定
                    wani.BringToFront();
                    //追加した部品の名前を保持-------------------------------------
                    Array.Resize(ref AddAnimal, AddAnimal.Length + 1);
                    AddAnimal.SetValue(wani.Name, count);
                    //-------------------------------------------------------------
                    break;

                case "dog"://1問目
                    //パネルインスタンス
                    PictureBox dog1 = new PictureBox();
                    PictureBox dog2 = new PictureBox();
                    PictureBox dog3 = new PictureBox();
                    //名前
                    dog1.Name = "dog_face0";
                    dog2.Name = "dog_parts0";
                    dog3.Name = "dog_ears0";
                    //サイズ設定
                    dog1.SizeMode = PictureBoxSizeMode.StretchImage;
                    dog2.SizeMode = PictureBoxSizeMode.StretchImage;
                    dog3.SizeMode = PictureBoxSizeMode.StretchImage;
                    //サイズ
                    dog1.Size = new Size(260, 180);
                    dog2.Size = new Size(260, 180);
                    dog3.Size = new Size(260, 180);
                    //色
                    dog1.BackColor = Color.Transparent;
                    dog2.BackColor = Color.Transparent;
                    dog3.BackColor = Color.Transparent;
                    //画像
                    dog1.Image = Image.FromFile(FilePath + "\\images\\DOG\\face.png");
                    dog2.Image = Image.FromFile(FilePath + "\\images\\DOG\\parts.png");
                    dog3.Image = Image.FromFile(FilePath + "\\images\\DOG\\ears.png");
                    //透過
                    bitmap = new Bitmap(dog1.Image);
                    bitmap.MakeTransparent(Color.White);
                    dog1.Image = bitmap;
                    bitmap = new Bitmap(dog2.Image);
                    bitmap.MakeTransparent(Color.White);
                    dog2.Image = bitmap;
                    bitmap = new Bitmap(dog3.Image);
                    bitmap.MakeTransparent(Color.White);
                    dog3.Image = bitmap;
                    //座標
                    dog1.Location = new Point(35, 115);
                    dog2.Location = new Point(35, 285);
                    dog3.Location = new Point(35, 425);
                    //イベントハンドラーの追加----------------------------------------------------------
                    dog1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dog_MouseDown);
                    dog1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dog_MouseMove);
                    dog1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dog_MouseUp);
                    dog2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dog_MouseDown);
                    dog2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dog_MouseMove);
                    dog2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dog_MouseUp);
                    dog3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dog_MouseDown);
                    dog3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dog_MouseMove);
                    dog3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dog_MouseUp);
                    //----------------------------------------------------------------------------------
                    //作業領域に追加
                    Controls.Add(dog1);
                    Controls.Add(dog2);
                    Controls.Add(dog3);
                    //最前面に設定
                    dog1.BringToFront();
                    dog2.BringToFront();
                    dog3.BringToFront();

                    //追加した部品の名前を保持-------------------------------------
                    Array.Resize(ref AddAnimal, AddAnimal.Length + 3);
                    AddAnimal.SetValue(dog1.Name, 1);
                    AddAnimal.SetValue(dog2.Name, 2);
                    AddAnimal.SetValue(dog3.Name, 3);
                    //-------------------------------------------------------------
                    break;
                default:
                    break;
            }
        }
        //最初からボタンの処理----------------------------------
        private void button2_Click(object sender, EventArgs e)
        {
            switch (questNum)
            {
                case 1:
                    questControl.Clear();
                    Control[] d1 = new Control[0];
                    Control[] d2 = new Control[0];
                    Control[] d3 = new Control[0];

                    d1 = panel1.Controls.Find("dog_face1", true);
                    d2 = panel1.Controls.Find("dog_parts1", true);
                    d3 = panel1.Controls.Find("dog_ears1", true);

                    foreach (Control c in d1)
                    {
                        panel1.Controls.Remove(c);
                    }
                    foreach (Control c in d2)
                    {
                        panel1.Controls.Remove(c);
                    }
                    foreach (Control c in d3)
                    {
                        panel1.Controls.Remove(c);
                    }
                    if(talkflg == true)
                    {
                        talkflg = false;
                        CreateControl("waniChara", 0);
                    }
                    tf.dog1count = 0;
                    tf.dog2count = 0;
                    tf.dog3count = 0;
                    textBox1.Text = "じゅんばんにきをつけてね！";
                    break;
                default:
                    break;
            }
            

        }
        //-------------------------------------------------------
    }
}
