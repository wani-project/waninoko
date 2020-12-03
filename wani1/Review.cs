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
        public Boolean talkflg = false;
        public int MeatCount = 0;
        public int ComboCount = 0;
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
                    

                    Scat.Size = new Size(400, 500);
                    Scat.SizeMode = PictureBoxSizeMode.StretchImage;
                    Scat.Location = new Point(40,10);
                    Scat.Image = Image.FromFile(FilePath + "\\images\\docat\\Scat.png");

                    Lcat.Size = new Size(260,240);
                    Lcat.SizeMode = PictureBoxSizeMode.StretchImage;
                    Lcat.Location = new Point(35, 115);
                    Lcat.Image = Image.FromFile(FilePath + "\\images\\docat\\Lcat.png");
                    Lcat.BackColor = Color.White;

                    cat.Size = new Size(260, 120);
                    cat.SizeMode = PictureBoxSizeMode.StretchImage;
                    cat.Location = new Point(35, 360);
                    cat.Image = Image.FromFile(FilePath + "\\images\\docat\\cat.png");
                    cat.BackColor = Color.Transparent;

                    dog.Size = new Size(260, 120);
                    dog.SizeMode = PictureBoxSizeMode.StretchImage;
                    dog.Location = new Point(35, 485);
                    dog.Image = Image.FromFile(FilePath + "\\images\\docat\\dog.png");
                    dog.BackColor = Color.Transparent;


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
            switch (questNum)
            {
                case 1:
                    Start(1);
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                default:
                    break;
            }
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
                rcc.CreateControls(this, 1, "meat", loc,pb.Name);
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
                    break;
                default:
                    break;
            }
        }
        //-------------------------------------------------------------------------
    }
}
