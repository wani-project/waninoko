using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wani1
{
    public partial class Review : Form
    {
        public string[] AddAnimal = { "動物名" };
        public int questNum;
        public string questTitle;
        public ArrayList questControl = new ArrayList();
        public int[] ControlCount = { 0, 0, 0 };//Lcat,cat,dog
        public int[] rank = { 0, 0, 0 };
        private int[] cardCount = { 0, 0 };
        public Boolean talkflg = false;
        private Boolean hukiflg = false;
        private Boolean cardflg = false;
        public int MeatCount = 0;
        public int ConCount = 0;
        public int loopCount = 0;
        private Point docatP = new Point(430,200);
        //ファイルパスの保持
        public string FilePath = Directory.GetCurrentDirectory();
        public Review()
        {
            InitializeComponent();
        }
        public void CreateControls(Review review, int num)
        {
            switch (num)
            {
                case 0:
                    //パネルインスタンス
                    PictureBox wani = new PictureBox();
                    //名前
                    wani.Name = "waniChara";
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
                    panel4.Controls.Add(wani);
                    //最前面に設定
                    wani.BringToFront();
                    break;
                //------------------------------------------------
                case 1:
                    //フローチャートの肉部品の追加
                    PictureBox meat = new PictureBox();
                    //フローチャートのなまず部品の追加
                    PictureBox catfish = new PictureBox();
                    //フローチャートのかに部品の追加
                    PictureBox crab = new PictureBox();
                    //フローチャートの貝部分の追加
                    PictureBox shell = new PictureBox();
                    //フローチャートの上部分の追加（上顎）
                    PictureBox upF = new PictureBox();
                    //ラベル
                    Label upL = new Label();
                    Label bottomL = new Label();
                    Label meatL = new Label();
                    Label catfishL = new Label();
                    Label crabL = new Label();
                    Label shellL = new Label();
                    //フローチャートの下部部の追加（下顎）
                    PictureBox bottomF = new PictureBox();
                    //迷路部分の追加
                    TableLayoutPanel field = new TableLayoutPanel();
                    //キャラクターの追加
                    PictureBox chara = new PictureBox();
                    //ドクロの追加
                    PictureBox skull = new PictureBox();
                    //爆弾の追加
                    PictureBox bomb = new PictureBox();
                    PictureBox bomb2 = new PictureBox();

                    //肉部品設定
                    meat.Name = "meat_0";
                    meat.Size = new Size(270, 79);
                    meat.SizeMode = PictureBoxSizeMode.StretchImage;
                    meat.Location = new Point(45, 90);
                    meat.BackColor = Color.FromName("White");
                    meat.Image = Image.FromFile(review.FilePath + "\\images\\flowchart\\meat.png");
                    meat.Parent = panel4;
                    meat.MouseDown += new MouseEventHandler(this.Control_MouseDown);
                    meat.MouseMove += new MouseEventHandler(this.Control_MouseMove);
                    meat.MouseUp += new MouseEventHandler(this.Control_MouseUp);
                    //肉部品ラベル設定
                    meatL.Text = "うえ";
                    meatL.Font = new Font(upL.Font.FontFamily, 20);
                    meatL.ForeColor = Color.White;
                    //meatL.BackColor = Color.FromArgb(168, 104, 70);
                    meatL.BackColor = Color.Transparent;
                    meatL.Size = new Size(50, 30);
                    //meatL.Location = new Point(155, 110);
                    meatL.Location = new Point(110,30);

                    //貝部品設定
                    shell.Name = "shell_0";
                    shell.Size = new Size(270, 79);
                    shell.SizeMode = PictureBoxSizeMode.StretchImage;
                    shell.Location = new Point(45, 175);
                    shell.BackColor = Color.FromName("White");
                    shell.Image = Image.FromFile(review.FilePath + "\\images\\flowchart\\shell.png");
                    shell.Parent = panel4;
                    shell.MouseDown += new MouseEventHandler(this.Control_MouseDown);
                    shell.MouseMove += new MouseEventHandler(this.Control_MouseMove);
                    shell.MouseUp += new MouseEventHandler(this.Control_MouseUp);
                    //貝ラベル設定
                    shellL.Text = "うえ";
                    shellL.Font = new Font(upL.Font.FontFamily, 20);
                    shellL.ForeColor = Color.Black;
                    //shellL.BackColor = Color.FromArgb(255, 155, 105);
                    shellL.BackColor = Color.Transparent;
                    shellL.Size = new Size(50, 30);
                    shellL.Location = new Point(110, 20);

                    //なまず部品設定
                    catfish.Name = "catfish_0";
                    catfish.Size = new Size(270, 79);
                    catfish.SizeMode = PictureBoxSizeMode.StretchImage;
                    catfish.Location = new Point(45, 260);
                    catfish.BackColor = Color.FromName("White");
                    catfish.Image = Image.FromFile(review.FilePath + "\\images\\flowchart\\catfish.png");
                    catfish.Parent = panel4;
                    catfish.MouseDown += new MouseEventHandler(this.Control_MouseDown);
                    catfish.MouseMove += new MouseEventHandler(this.Control_MouseMove);
                    catfish.MouseUp += new MouseEventHandler(this.Control_MouseUp);
                    //なまずラベル設定
                    catfishL.Text = "みぎ";
                    catfishL.Font = new Font(upL.Font.FontFamily, 20);
                    catfishL.ForeColor = Color.White;
                    //catfishL.BackColor = Color.FromArgb(70, 70, 70);
                    catfishL.BackColor = Color.Transparent;
                    catfishL.Size = new Size(60, 30);
                    catfishL.Location = new Point(110, 20);

                    //かに部品設定
                    crab.Name = "crab_0";
                    crab.Size = new Size(270, 79);
                    crab.SizeMode = PictureBoxSizeMode.StretchImage;
                    crab.Location = new Point(45, 345);
                    crab.BackColor = Color.FromName("White");
                    crab.Image = Image.FromFile(review.FilePath + "\\images\\flowchart\\crab.png");
                    crab.Parent = panel4;
                    crab.MouseDown += new MouseEventHandler(this.Control_MouseDown);
                    crab.MouseMove += new MouseEventHandler(this.Control_MouseMove);
                    crab.MouseUp += new MouseEventHandler(this.Control_MouseUp);
                    //かにラベル設定
                    crabL.Text = "みぎ";
                    crabL.Font = new Font(upL.Font.FontFamily, 20);
                    crabL.ForeColor = Color.White;
                    //crabL.BackColor = Color.FromArgb(209, 0, 0);
                    crabL.BackColor = Color.Transparent;
                    crabL.Size = new Size(60, 30);
                    crabL.Location = new Point(110, 40);


                    //フローチャートの上部分設定
                    upF.Name = "upFlow";
                    upF.Size = new Size(230, 105);
                    upF.SizeMode = PictureBoxSizeMode.StretchImage;
                    upF.Location = new Point(36, 40);
                    upF.BackColor = Color.FromName("White");
                    upF.Image = Image.FromFile(review.FilePath + "\\images\\flowchart\\up.png");
                    //上部分のラベル設定
                    upL.Text = "はじめ";
                    upL.Font = new Font(upL.Font.FontFamily, 20);
                    upL.Size = new Size(80, 30);
                    upL.Location = new Point(110, 72);
                    upL.BackColor = Color.FromArgb(170, 218, 24);
                    upL.Parent = upF;

                    //フローチャートの下部分設定
                    bottomF.Name = "bottomFlow";
                    bottomF.Size = new Size(230, 105);
                    bottomF.SizeMode = PictureBoxSizeMode.StretchImage;
                    bottomF.Location = new Point(36, 485);
                    bottomF.BackColor = Color.FromName("White");
                    bottomF.Image = Image.FromFile(review.FilePath + "\\images\\flowchart\\bottom.png");
                    //下部分のラベル設定
                    bottomL.Text = "おわり";
                    bottomL.Font = new Font(upL.Font.FontFamily, 20);
                    bottomL.Size = new Size(80, 30);
                    bottomL.Location = new Point(115, 540);
                    bottomL.BackColor = Color.FromArgb(170, 218, 24);
                    bottomL.Parent = bottomF;

                    //キャラクター設定
                    chara.Name = "chara";
                    chara.Size = new Size(110, 98);
                    chara.SizeMode = PictureBoxSizeMode.Zoom;
                    chara.Image = Image.FromFile(review.FilePath + "\\images\\Run.gif");
                    chara.BackColor = Color.Transparent;

                    //どくろ設定
                    skull.Name = "skull1";
                    skull.Size = new Size(110, 98);
                    skull.SizeMode = PictureBoxSizeMode.Zoom;
                    skull.Image = Image.FromFile(review.FilePath + "\\images\\flowchart\\skull.png");
                    skull.BackColor = Color.Transparent;

                    //爆弾設定
                    bomb.Name = "bomb1";
                    bomb.Size = new Size(110, 98);
                    bomb.SizeMode = PictureBoxSizeMode.Zoom;
                    bomb.Image = Image.FromFile(review.FilePath + "\\images\\flowchart\\bomb.png");
                    bomb.BackColor = Color.Transparent;

                    bomb2.Name = "bomb2";
                    bomb2.Size = new Size(110, 98);
                    bomb2.SizeMode = PictureBoxSizeMode.Zoom;
                    bomb2.Image = Image.FromFile(review.FilePath + "\\images\\flowchart\\bomb.png");
                    bomb2.BackColor = Color.Transparent;

                    //迷路部分(TableLayoutPanel)設定
                    field.Name = "rabyrinth";
                    field.Size = new Size(470, 470);
                    field.Location = new Point(360, 40);
                    field.BackgroundImage = Image.FromFile(review.FilePath + "\\images\\flowchart\\ground.png");
                    field.BackgroundImageLayout = ImageLayout.Zoom;
                    for (int i = 0; i < 4; i++)
                    {
                        field.RowCount++;
                        field.RowStyles.Insert(i, new RowStyle(SizeType.Percent, 50));
                        field.ColumnCount++;
                        field.ColumnStyles.Insert(i, new ColumnStyle(SizeType.Percent, 50));
                    }
                    //スタート地点にキャラクターを配置
                    field.Controls.Add(chara, 0, 3);
                    //障害物を配置
                    field.Controls.Add(skull, 0, 0);
                    field.Controls.Add(bomb, 2, 1);
                    field.Controls.Add(bomb2, 2, 3);
                    //迷路部品を追加
                    review.panel4.Controls.Add(field);
                    field.BringToFront();
                    //各部品を追加
                    review.panel4.Controls.Add(upF);
                    review.panel4.Controls.Add(upL);
                    review.panel4.Controls.Add(bottomF);
                    review.panel4.Controls.Add(bottomL);
                    review.Controls.Add(meat);
                    review.Controls.Add(meatL);
                    review.Controls.Add(catfish);
                    review.Controls.Add(catfishL);
                    review.Controls.Add(crab);
                    review.Controls.Add(crabL);
                    review.Controls.Add(shell);
                    review.Controls.Add(shellL);

                    meatL.Parent = meat;
                    catfishL.Parent = catfish;
                    crabL.Parent = crab;
                    shellL.Parent = shell;
                    upF.BringToFront();
                    upL.BringToFront();
                    bottomF.BringToFront();
                    bottomL.BringToFront();
                    meat.BringToFront();
                    meatL.BringToFront();
                    catfish.BringToFront();
                    catfishL.BringToFront();
                    crab.BringToFront();
                    crabL.BringToFront();
                    shell.BringToFront();
                    shellL.BringToFront();

                    
                    break;
                //--------------------------------------------------------
                //--------------------------------------------------------
                case 2:
                    //各コントロールの宣言
                    //犬ブロック
                    PictureBox dog = new PictureBox();
                    //ネコブロック
                    PictureBox cat = new PictureBox();
                    //はじめネコブロック
                    PictureBox Scat = new PictureBox();
                    //ループネコブロック
                    PictureBox Lcat = new PictureBox();
                    

                    Scat.Size = new Size(400, 580);
                    Scat.SizeMode = PictureBoxSizeMode.StretchImage;
                    Scat.Name = "Scat";
                    Scat.Location = new Point(10,10);
                    Scat.Image = Image.FromFile(FilePath + "\\images\\docat\\Scat.png");

                    Lcat.Size = new Size(260,240);
                    Lcat.SizeMode = PictureBoxSizeMode.StretchImage;
                    Lcat.Name = "Lcat";
                    Lcat.Location = new Point(35, 115);
                    Lcat.Image = Image.FromFile(FilePath + "\\images\\docat\\Lcat.png");
                    Lcat.BackColor = Color.White;
                    Lcat.MouseDown += new MouseEventHandler(this.Control_MouseDown);
                    Lcat.MouseMove += new MouseEventHandler(this.Control_MouseMove);
                    Lcat.MouseUp += new MouseEventHandler(this.Control_MouseUp);

                    cat.Size = new Size(260, 120);
                    cat.SizeMode = PictureBoxSizeMode.StretchImage;
                    cat.Name = "cat";
                    cat.Location = new Point(35, 360);
                    cat.Image = Image.FromFile(FilePath + "\\images\\docat\\cat.png");
                    cat.BackColor = Color.Transparent;
                    cat.MouseDown += new MouseEventHandler(this.Control_MouseDown);
                    cat.MouseMove += new MouseEventHandler(this.Control_MouseMove);
                    cat.MouseUp += new MouseEventHandler(this.Control_MouseUp);

                    dog.Size = new Size(260, 120);
                    dog.SizeMode = PictureBoxSizeMode.StretchImage;
                    dog.Name = "dog";
                    dog.Location = new Point(35, 485);
                    dog.Image = Image.FromFile(FilePath + "\\images\\docat\\dog.png");
                    dog.BackColor = Color.Transparent;
                    dog.MouseDown += new MouseEventHandler(this.Control_MouseDown);
                    dog.MouseMove += new MouseEventHandler(this.Control_MouseMove);
                    dog.MouseUp += new MouseEventHandler(this.Control_MouseUp);

                    //コントロールの追加
                    panel4.Controls.Add(Scat);
                    Controls.Add(Lcat);
                    Controls.Add(cat);
                    Controls.Add(dog);
                    //コントロールの最前面配置
                    Scat.BringToFront();
                    Lcat.BringToFront();
                    cat.BringToFront();
                    dog.BringToFront();
                    break;
                //--------------------------------------------------------
                case 21:
                    //2問目のイヌネコカードの生成
                    //ネコ
                    PictureBox catC = new PictureBox();
                    //ネコ
                    cardCount[1]++;
                    catC.Name = "catC_" + cardCount[1];
                    catC.Size = new Size(65, 80);
                    catC.SizeMode = PictureBoxSizeMode.StretchImage;
                    catC.BackColor = Color.Transparent;
                    catC.Location = docatP;
                    catC.Image = Image.FromFile(FilePath + "\\images\\docat\\catC.png");

                    docatP = new Point(docatP.X + 70, docatP.Y);

                    //追加
                    panel4.Controls.Add(catC);
                    //最前面配置
                    catC.BringToFront();
                    break;
                case 22:
                    //2問目のイヌネコカードの生成
                    //イヌ
                    PictureBox dogC = new PictureBox();
                    //イヌ
                    cardCount[0]++;
                    dogC.Name = "dogC_" + cardCount[0];
                    dogC.Size = new Size(65, 80);
                    dogC.SizeMode = PictureBoxSizeMode.StretchImage;
                    dogC.BackColor = Color.Transparent;
                    dogC.Location = docatP;
                    dogC.Image = Image.FromFile(FilePath + "\\images\\docat\\dogC.png");

                    docatP = new Point(docatP.X + 70, docatP.Y);

                    //追加
                    panel4.Controls.Add(dogC);
                    //最前面配置
                    dogC.BringToFront();
                    break;

                default:
                    break;
            }

        }

        private void review_back_button_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.ScreenSwitch();
            this.Dispose();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Start(questNum);
        }


        private void Review_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            CreateControls(this, questNum);
            textBox2.Text = questTitle;
        }

        private async void MoveChara(string direction)
        {
            Control[] controls = new Control[0];
            controls = panel4.Controls.Find("rabyrinth", true);
            TableLayoutPanel table;
            PictureBox charaP = new PictureBox();
            PictureBox booom = new PictureBox();
            booom.Size = new Size(470, 470);
            booom.Image = Image.FromFile(FilePath + "\\images\\flowchart\\booom.gif");
            booom.BackColor = Color.Transparent;

            PictureBox goal = new PictureBox();
            goal.Image = Image.FromFile(FilePath + "\\images\\flowchart\\goal.gif");
            goal.Size = new Size(650, 470);
            goal.Location = new Point(180, 40);
            goal.BackColor = Color.Transparent;

            foreach (Control c in controls)
            {
                table = (TableLayoutPanel)c;
                booom.Location = table.Location;
                Control[] controls2 = new Control[0];
                controls2 = panel4.Controls.Find("chara", true);
                foreach (Control c2 in controls2)
                {
                    charaP = (PictureBox)c2;
                    switch (direction)
                    {
                        case "up":
                            TableLayoutPanelCellPosition p = table.GetCellPosition(charaP);
                            if (p.Row != 0)
                            {
                                if(table.GetControlFromPosition(p.Column,p.Row - 1) == null)
                                {
                                    p.Row -= 1;
                                    table.SetCellPosition(charaP, p);
                                }else
                                {
                                    p.Row -= 1;
                                    if (p == new TableLayoutPanelCellPosition(0, 0))
                                    {
                                        //どくろ
                                        booom.Image = Image.FromFile(FilePath + "\\images\\flowchart\\death.gif");
                                        panel4.Controls.Add(booom);
                                        booom.BringToFront();
                                        await Task.Delay(3500);
                                        panel4.Controls.Remove(booom);
                                    }
                                    else
                                    {
                                        panel4.Controls.Add(booom);
                                        booom.BringToFront();
                                        await Task.Delay(3500);
                                        panel4.Controls.Remove(booom);
                                    }
                                    return;
                                }
                            }

                            break;
                        case "down":
                            p = table.GetCellPosition(charaP);
                            if (p.Row != 3)
                            {
                                if (table.GetControlFromPosition(p.Column, p.Row + 1) == null)
                                {
                                    p.Row += 1;
                                    table.SetCellPosition(charaP, p);
                                }
                            }
                            break;
                        case "left":
                            p = table.GetCellPosition(charaP);
                            if (p.Column != 0)
                            {
                                if (table.GetControlFromPosition(p.Column - 1, p.Row) == null)
                                {
                                    p.Column -= 1;
                                    table.SetCellPosition(charaP, p);
                                }

                            }
                            break;
                        case "right":
                            p = table.GetCellPosition(charaP);
                            if (p.Column != 3)
                            {
                                if (table.GetControlFromPosition(p.Column + 1, p.Row) == null)
                                {
                                    p.Column += 1;
                                    table.SetCellPosition(charaP, p);
                                }
                                else
                                {
                                    p.Column += 1;
                                    if (table.GetCellPosition(charaP) == new TableLayoutPanelCellPosition(0, 0))
                                    {
                                        //どくろ
                                        booom.Image = Image.FromFile(FilePath + "\\images\\flowchart\\death.gif");
                                        panel4.Controls.Add(booom);
                                        booom.BringToFront();
                                        await Task.Delay(3500);
                                        panel4.Controls.Remove(booom);
                                    }
                                    else
                                    {
                                        panel4.Controls.Add(booom);
                                        booom.BringToFront();
                                        await Task.Delay(3500);
                                        panel4.Controls.Remove(booom);
                                    }
                                    return;
                                }

                            }
                            break;
                        default:
                            break;
                    }
                    if(table.GetCellPosition(charaP) == new TableLayoutPanelCellPosition(3, 0))
                    {
                        //ゴール演出
                        await Task.Delay(500);
                        panel4.Controls.Add(goal);
                        goal.BringToFront();
                        await Task.Delay(3500);
                        panel4.Controls.Remove(goal);
                    }
                }
            }
            
        }
        private async void Start(int num)
        {
            switch (num)
            {
                case 1:
                    for(int i = 1;i <= MeatCount; i++)
                    {
                        Control[] c1 = new Control[0];
                        Control[] c2 = new Control[0];
                        TextBox text = new TextBox();
                        int count = 0;
                        string Cname = "";
                        string[] kinds = { "meat_" + i, "catfish_" + i, "crab_" + i, "shell_" + i};
                        string find = "count_" + i;
                        c1 = panel4.Controls.Find(find, true);
                        foreach (Control con1 in c1)
                        {
                            text = (TextBox)con1;
                            count = int.Parse(con1.Text);
                            for (int y = 0; y < 4; y++)
                            {
                                c2 = panel4.Controls.Find(kinds[y], true);
                                if (c2.Length != 0)
                                {
                                    break;
                                }
                            }
                            foreach (Control con2 in c2)
                            {
                                Cname = con2.Name;
                                if (Cname == kinds[0])
                                {
                                    for (int c = 0; c < count; c++)
                                    {
                                        MoveChara("up");
                                        await Task.Delay(1000);
                                    }
                                }
                                if (Cname == kinds[1])
                                {
                                    for (int c = 0; c < count; c++)
                                    {
                                        MoveChara("right");
                                        await Task.Delay(1000);
                                    }
                                }
                                if (Cname == kinds[2])
                                {
                                    for (int c = 0; c < count; c++)
                                    {
                                        MoveChara("right");
                                        await Task.Delay(1000);
                                    }
                                }
                                if (Cname == kinds[3])
                                {
                                    for (int c = 0; c < count; c++)
                                    {
                                        MoveChara("up");
                                        await Task.Delay(1000);
                                    }
                                }
                            }
                        }

                    }
                    break;
                case 2:
                    loopCount = 0;
                    if(hukiflg == false)
                    {
                        //吹き出し表示
                        PictureBox huki = new PictureBox();
                        huki.Size = new Size(500, 200);
                        huki.SizeMode = PictureBoxSizeMode.StretchImage;
                        huki.Location = new Point(385, 125);
                        huki.BackColor = Color.Transparent;
                        huki.Image = Image.FromFile(FilePath + "\\images\\docat\\hukidashi.png");
                        panel4.Controls.Add(huki);
                        huki.BringToFront();
                        hukiflg = true;
                        await Task.Delay(1000);
                    }
                    if(cardflg == true)
                    {
                        //表示済みカードの削除
                        if (cardCount[0] < cardCount[1])
                        {
                            cardCount[0] = cardCount[1];
                        }
                        for(int i = 1; i <= cardCount[0]; i++)
                        {
                            Control[] cards = new Control[0];
                            cards = panel4.Controls.Find("catC_" + i, true);
                            foreach (Control c in cards)
                            {
                                panel4.Controls.Remove(c);
                            }
                            cards = panel4.Controls.Find("dogC_" + i, true);
                            foreach (Control c in cards)
                            {
                                panel4.Controls.Remove(c);
                            }
                        }
                        docatP = new Point(430, 200);
                        cardflg = false;
                        await Task.Delay(1000);
                    }
                    //ループ判定
                    if (rank[0] == 1)
                    {
                        Control[] loop = new Control[0];
                        loop = panel4.Controls.Find("loopCount", true);
                        foreach (Control con in loop)
                        {
                            loopCount = int.Parse(con.Text);
                        }
                        //ループ開始
                        for (int i = 0; i < loopCount; i++)
                        {
                            if (rank[1] > rank[2]) //cat > dog
                            {
                                if (rank[1] >= 1)
                                {
                                    CreateControls(this, 22);
                                    await Task.Delay(1000);
                                }
                                if (rank[2] >= 1)
                                {
                                    CreateControls(this, 21);
                                }
                            }
                            else if (rank[2] > rank[1])
                            {
                                if (rank[2] >= 1)
                                {
                                    CreateControls(this, 21);
                                    await Task.Delay(1000);
                                }
                                if (rank[1] >= 1)
                                {
                                    CreateControls(this, 22);
                                }
                            }
                            await Task.Delay(1000);
                        }
                    }
                    else if(rank[0] == 2)
                    {
                        Control[] loop = new Control[0];
                        loop = panel4.Controls.Find("loopCount", true);
                        foreach (Control con in loop)
                        {
                            loopCount = int.Parse(con.Text);
                        }
                        if (rank[1] == 1)
                        {
                            CreateControls(this, 21);
                            await Task.Delay(1000);
                        }
                        if (rank[2] == 1)
                        {
                            CreateControls(this, 22);
                            await Task.Delay(1000);
                        }
                        //ループ開始
                        for (int i = 0; i < loopCount; i++)
                        {

                            if (rank[1] == 3)
                            {
                                CreateControls(this, 21);
                            }
                            if (rank[2] == 3)
                            {
                                CreateControls(this, 22);
                            }
                            
                            await Task.Delay(1000);
                        }
                    }
                    else
                    {
                        if (rank[1] > rank[2]) //cat > dog
                        {
                            if (rank[1] >= 1)
                            {
                                CreateControls(this, 22);
                                await Task.Delay(1000);
                            }
                            if (rank[2] >= 1)
                            {
                                CreateControls(this, 21);
                            }
                        }
                        else if (rank[2] > rank[1])
                        {
                            if (rank[2] >= 1)
                            {
                                CreateControls(this, 21);
                                await Task.Delay(1000);
                            }
                            if (rank[1] >= 1)
                            {
                                CreateControls(this, 22);
                            }
                        }
                        await Task.Delay(1000);
                    }
                    //正誤判定
                    if (loopCount == 3)
                    {
                        if (rank[1] == 3 || rank[2] == 2)
                        {
                            MessageBox.Show("せいかい！！");
                        }
                        else
                        {
                            MessageBox.Show("ちがうよ！！");
                        }
                    }
                    else
                    {
                        MessageBox.Show("ちがうよ！！");
                    }
                    cardflg = true;
                    break;
                default:
                    break;
            }
        }
        //追加部品の移動処理------------------------------------------------------
        //移動処理の初期変数---------
        bool _isDraging = false;
        Point? _diffPoint = null;
        Control cont0;
        Point test_def = new Point(45, 90);
        //---------------------------
        private void Control_MouseDown(object sender, MouseEventArgs e)
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

            panel1.Size = pb.Size;
            panel1.Location = pb.Location;
        }
        private void Control_MouseMove(object sender, MouseEventArgs e)
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
            panel1.Location = new Point(x, y);
            pb.BringToFront();

        }
        private void Control_MouseUp(object sender, MouseEventArgs e)
        {
            ReviewCreateControls rcc = new ReviewCreateControls();
            PictureBox pb = ((PictureBox)sender);
            Cursor.Current = Cursors.Default;
            _isDraging = false;

            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            Point loc = new Point(pb.Location.X, panel1.Location.Y);
            if (loc.X >= 379 && loc.Y >= 64)
            {
                rcc.CreateControls(this, questNum, "meat", loc,pb.Name);
            }
            pb.Location = test_def;
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            switch (questNum)
            {
                case 1:
                    for (int i = 1; i <= 4; i++)
                    {
                        string[] kinds = { "meat_" + i, "catfish_" + i, "crab_" + i, "shell_" + i };
                        Control[] c1 = new Control[0];
                        Control[] c2 = new Control[0];
                        for (int x = 0; x < 4; x++)
                        {
                            c1 = panel4.Controls.Find(kinds[x], true);
                            
                            foreach(Control c in c1)
                            {
                                panel4.Controls.Remove(c);
                            }
                            if (c1.Length != 0)
                            {
                                break;
                            }
                        }
                        c2 = panel4.Controls.Find("count_" + i, true);
                        foreach(Control c in c2)
                        {
                            panel4.Controls.Remove(c);
                        }
                    }
                    Control[] con = new Control[0];
                    con = panel4.Controls.Find("rabyrinth", true);
                    TableLayoutPanel table;
                    PictureBox charaP = new PictureBox();
                    foreach (Control c in con)
                    {
                        table = (TableLayoutPanel)c;
                        Control[] controls2 = new Control[0];
                        controls2 = panel4.Controls.Find("chara", true);
                        foreach (Control c2 in controls2)
                        {
                            charaP = (PictureBox)c2;
                            TableLayoutPanelCellPosition p = new TableLayoutPanelCellPosition(0,3);
                            table.SetCellPosition(charaP, p);
                        }
                    }
                        MeatCount = 0;
                    break;
                case 2:
                    for(int i = 0;i < ControlCount.Length; i++)
                    {
                        ControlCount[i] = 0;
                    }
                    for(int i = 0;i < rank.Length; i++)
                    {
                        rank[i] = 0;
                    }
                    ConCount = 0;
                    hukiflg = false;
                    cardflg = false;
                    panel4.Controls.Clear();
                    docatP = new Point(430, 200);
                    Button b = new Button();
                    b.Name = "button_2";
                    b.Anchor = AnchorStyles.Top;
                    b.Anchor = AnchorStyles.Right;
                    b.Font = new Font(b.Font.FontFamily, 18);
                    b.Text = "さいしょから";
                    b.BackColor = Color.FromArgb(128, 255, 128);
                    b.FlatStyle = FlatStyle.Flat;
                    b.FlatAppearance.BorderSize = 0;
                    b.Size = new Size(126, 32);
                    b.Location = new Point(768, 3);
                    b.Click += new EventHandler(this.button2_Click);
                    panel4.Controls.Add(b);
                    b.BringToFront();
                    CreateControls(this, 2);
                    break;
                default:
                    break;
            }
        }
        //-------------------------------------------------------------------------
    }
}
