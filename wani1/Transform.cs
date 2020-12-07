using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wani1
{
    class Transform
    {
        //追加カウント変数
        private int Addcount = 0;
        public int dog1count = 0;
        public int dog2count = 0;
        public int dog3count = 0;

        private string dog1name = "";
        private string dog2name = "";
        private string dog3name = "";

        public int[] dogAns = { 0, 0, 0 };
        private string[] imageName = { "", "", "" };
        //図形の変形処理----------------------------------------------------------
        public void TransformControl(Control control, string kinds)
        {
            switch (kinds)
            {
                case "test":
                    //多角形の頂点の位置を設定
                    Point[] points = {
                        new Point(0, 0),
                        new Point(150, 0),
                        new Point(150,50),
                        new Point(50, 50),
                        new Point(50, 250),
                        new Point(150,250),
                        new Point(150,300),
                        new Point(0,300)
                    };
                    byte[] types =
                    {
                        (byte) System.Drawing.Drawing2D.PathPointType.Line,
                        (byte) System.Drawing.Drawing2D.PathPointType.Line,
                        (byte) System.Drawing.Drawing2D.PathPointType.Line,
                        (byte) System.Drawing.Drawing2D.PathPointType.Line,
                        (byte) System.Drawing.Drawing2D.PathPointType.Line,
                        (byte) System.Drawing.Drawing2D.PathPointType.Line,
                        (byte) System.Drawing.Drawing2D.PathPointType.Line,
                        (byte) System.Drawing.Drawing2D.PathPointType.Line
                    };
                    //GraphicsPathの作成
                    System.Drawing.Drawing2D.GraphicsPath path =
                        new System.Drawing.Drawing2D.GraphicsPath(points, types);
                    //コントロールの形を変更
                    control.Region = new Region(path);
                    break;
                case "wani":
                    Point[] wani_points = {
                        new Point(0, 0),
                        new Point(261, 0),
                        new Point(261,90),
                        new Point(90, 90),//歯茎部分
                        new Point(90,95),//
                        new Point(90,96),
                        new Point(90,100),
                        new Point(88,102),
                        new Point(86,105),
                        new Point(85,107),//
                        new Point(84,110),
                        new Point(82,112),
                        new Point(80,120),
                        new Point(79,120),
                        new Point(78,120),//
                        new Point(77,120),
                        new Point(76,120),
                        new Point(75,120),
                        new Point(74,120),
                        new Point(73,120),//
                        new Point(72,120),
                        new Point(71,120),
                        new Point(70,120),
                        new Point(55, 221),//下あご
                        new Point(261,221),//
                        new Point(261,261),
                        new Point(0,261)
                    };
                    byte[] wani_types =
                    {
                        (byte) System.Drawing.Drawing2D.PathPointType.Line,
                        (byte) System.Drawing.Drawing2D.PathPointType.Line,
                        (byte) System.Drawing.Drawing2D.PathPointType.Line,
                        (byte) System.Drawing.Drawing2D.PathPointType.Line,
                        (byte) System.Drawing.Drawing2D.PathPointType.Line,//
                        (byte) System.Drawing.Drawing2D.PathPointType.Line,
                        (byte) System.Drawing.Drawing2D.PathPointType.Line,
                        (byte) System.Drawing.Drawing2D.PathPointType.Line,
                        (byte) System.Drawing.Drawing2D.PathPointType.Line,
                        (byte) System.Drawing.Drawing2D.PathPointType.Line,//
                        (byte) System.Drawing.Drawing2D.PathPointType.Line,
                        (byte) System.Drawing.Drawing2D.PathPointType.Line,
                        (byte) System.Drawing.Drawing2D.PathPointType.Line,
                        (byte) System.Drawing.Drawing2D.PathPointType.Line,
                        (byte) System.Drawing.Drawing2D.PathPointType.Line,//
                        (byte) System.Drawing.Drawing2D.PathPointType.Line,
                        (byte) System.Drawing.Drawing2D.PathPointType.Line,
                        (byte) System.Drawing.Drawing2D.PathPointType.Line,
                        (byte) System.Drawing.Drawing2D.PathPointType.Line,
                        (byte) System.Drawing.Drawing2D.PathPointType.Line,//
                        (byte) System.Drawing.Drawing2D.PathPointType.Line,
                        (byte) System.Drawing.Drawing2D.PathPointType.Line,
                        (byte) System.Drawing.Drawing2D.PathPointType.Line,
                        (byte) System.Drawing.Drawing2D.PathPointType.Line,
                        (byte) System.Drawing.Drawing2D.PathPointType.Line,//
                        (byte) System.Drawing.Drawing2D.PathPointType.Line,
                        (byte) System.Drawing.Drawing2D.PathPointType.Line
                    };
                    //GraphicsPathの作成
                    System.Drawing.Drawing2D.GraphicsPath wani_path =
                        new System.Drawing.Drawing2D.GraphicsPath(wani_points, wani_types);
                    //コントロールの形を変更
                    control.Region = new Region(wani_path);
                    break;
                default:
                    break;
            }

        }
        //------------------------------------------------------------------------
        //部品の追加処理----------------------------------------------------------------------------------
        public void CreateControl(Size size, Point location, Learn learn, string kinds, string sender)
        {
            switch (kinds)
            {
                case "test":
                    //追加カウント
                    Addcount++;
                    //パネルインスタンス
                    Panel panel = new Panel();
                    //名前
                    panel.Name = "alligator_" + Addcount;
                    //サイズ
                    panel.Size = size;
                    //色
                    panel.BackColor = Color.FromArgb(192, 255, 192);
                    //座標
                    panel.Location = new Point(location.X - 379, location.Y - 64);
                    //変形処理
                    TransformControl(panel, "test");
                    //イベントハンドラーの追加----------------------------------------------------------
                    panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_MouseDown);
                    panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_MouseMove);
                    panel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_MouseUp);
                    //----------------------------------------------------------------------------------
                    //作業領域に追加
                    learn.panel1.Controls.Add(panel);
                    //最前面に設定
                    panel.BringToFront();
                    //追加した部品の名前を保持-------------------------------------
                    Array.Resize(ref learn.AddAnimal, learn.AddAnimal.Length + 1);
                    learn.AddAnimal.SetValue(panel.Name, Addcount);
                    //-------------------------------------------------------------
                    break;
                case "wani":
                    //追加カウント
                    Addcount++;
                    //パネルインスタンス
                    PictureBox wani = new PictureBox();
                    //名前
                    wani.Name = "wanipic_" + Addcount;
                    //サイズ設定
                    wani.SizeMode = PictureBoxSizeMode.Zoom;
                    //サイズ
                    wani.Size = size;
                    //色
                    wani.BackColor = Color.FromName("Transparent");
                    //画像
                    wani.Image = Image.FromFile(learn.FilePath + "\\images\\wani_block.png");
                    //透過？
                    Bitmap bitmap = new Bitmap(wani.Image);
                    bitmap.MakeTransparent();
                    //座標
                    wani.Location = new Point(location.X - 379, location.Y - 64);
                    //変形処理
                    TransformControl(wani, "test");
                    //イベントハンドラーの追加----------------------------------------------------------
                    wani.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_MouseDown);
                    wani.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_MouseMove);
                    wani.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_MouseUp);
                    //----------------------------------------------------------------------------------
                    //作業領域に追加
                    learn.panel1.Controls.Add(wani);
                    //最前面に設定
                    wani.BringToFront();
                    //追加した部品の名前を保持-------------------------------------
                    Array.Resize(ref learn.AddAnimal, learn.AddAnimal.Length + 1);
                    learn.AddAnimal.SetValue(wani.Name, Addcount);
                    //-------------------------------------------------------------
                    break;
                case "dog":
                    //パネルインスタンス
                    PictureBox dog = new PictureBox();
                    //作成判定フラグ
                    Boolean flg = false;
                    //名前、画像
                    switch (sender)
                    {
                        case "dog_face0":
                            if (dog1count == 0)
                            {
                                dog1count++;
                                dog.Name = "dog_face" + dog1count;
                                dog.BackColor = Color.Transparent;
                                dog.Image = Image.FromFile(learn.FilePath + "\\images\\DOG\\face.png");
                                dog.Parent = learn.panel1;
                                dog1name = dog.Name;
                                learn.questControl.Add(dog.Name);
                                if (dog2count == 1)
                                {
                                    if (dog3count == 1)
                                    {
                                        dogAns[0] = 3;
                                    }
                                    else
                                    {
                                        dogAns[0] = 2;
                                    }
                                }
                                else
                                {
                                    dogAns[0] = 1;
                                }

                                flg = true;
                            }
                            break;
                        case "dog_parts0":
                            if (dog2count == 0)
                            {
                                dog2count++;
                                dog.Name = "dog_parts" + dog2count;
                                dog.BackColor = Color.Transparent;
                                dog.Image = Image.FromFile(learn.FilePath + "\\images\\DOG\\parts.png");
                                dog2name = dog.Name;
                                learn.questControl.Add(dog.Name);
                                if (dog1count == 1)
                                {
                                    if (dog3count == 1)
                                    {
                                        dogAns[1] = 3;
                                    }
                                    else
                                    {
                                        dogAns[1] = 2;
                                    }
                                }
                                else
                                {
                                    dogAns[1] = 1;
                                }
                                flg = true;
                            }
                            break;
                        case "dog_ears0":
                            if (dog3count == 0)
                            {
                                dog3count++;
                                dog.Name = "dog_ears" + dog3count;
                                dog.BackColor = Color.Transparent;
                                dog.Image = Image.FromFile(learn.FilePath + "\\images\\DOG\\ears.png");
                                dog3name = dog.Name;
                                learn.questControl.Add(dog.Name);
                                if (dog1count == 1)
                                {
                                    if (dog2count == 1)
                                    {
                                        dogAns[2] = 3;
                                    }
                                    else
                                    {
                                        dogAns[2] = 2;
                                    }
                                }
                                else
                                {
                                    dogAns[2] = 1;
                                }
                                flg = true;
                            }
                            break;

                    }
                    if (flg == true)
                    {

                        //サイズ設定
                        dog.SizeMode = PictureBoxSizeMode.Zoom;
                        //サイズ
                        dog.Size = new Size(525, 300);
                        //座標
                        //dog.Location = new Point(location.X - 379, location.Y - 64);
                        dog.Location = new Point(0, 0);
                        //変形処理
                        //TransformControl(dog, "dog");
                        //イベントハンドラーの追加----------------------------------------------------------
                        dog.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_MouseDown);
                        dog.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_MouseMove);
                        dog.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_MouseUp);
                        //----------------------------------------------------------------------------------
                        //作業領域に追加
                        learn.panel1.Controls.Add(dog);
                        dog.BringToFront();
                    }
                    break;
                default:
                    break;
            }
        }
        //------------------------------------------------------------------------------------------------



        //追加部品の移動処理------------------------------------------------------
        //移動処理の初期変数---------
        bool _isDraging = false;
        Point? _diffPoint = null;
        Control cont0;
        //---------------------------
        private void panel_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            Cursor.Current = Cursors.Hand;
            _isDraging = true;
            _diffPoint = e.Location;

            Learn learn = new Learn();
            switch (sender.GetType().ToString())
            {
                case "System.Windows.Forms.Panel":
                    cont0 = (Panel)sender;
                    break;
                case "System.Windows.Forms.PictureBox":
                    cont0 = (PictureBox)sender;
                    break;
            }
            learn.panel3.Size = cont0.Size;
            learn.panel3.Location = cont0.Location;
            cont0.BringToFront();
        }
        private void panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_isDraging)
            {
                return;
            }
            Learn learn = new Learn();
            switch (sender.GetType().ToString())
            {
                case "System.Windows.Forms.Panel":
                    cont0 = (Panel)sender;
                    break;
                case "System.Windows.Forms.PictureBox":
                    cont0 = (PictureBox)sender;
                    break;
            }

            int x = cont0.Location.X + e.X - _diffPoint.Value.X;
            int y = cont0.Location.Y + e.Y - _diffPoint.Value.Y;
            if (x <= 0)
            {
                x = 0;
            }
            if (y <= 0)
            {
                y = 0;
            }
            cont0.Location = new Point(x, y);
            learn.panel3.Location = new Point(x, y);

        }
        private void panel_MouseUp(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Default;
            _isDraging = false;

            Learn learn = new Learn();

            if (e.Button != MouseButtons.Left)
            {
                return;
            }
        }
        //------------------------------------------------------------------------

            //1問目の画像透過に必要な親の設定
        public void SetParent(Learn learn, string name, ArrayList array)
        {
            switch (name)
            {
                case "dog":
                    //コントロール変数
                    Control[] controls1 = new Control[0];
                    Control[] controls2 = new Control[0];
                    Control[] controls3 = new Control[0];
                    //繰り返し変数
                    int i = 0;
                    while (array.Count > i)
                    {
                        if (i == 1)
                        {//二件目の処理
                            controls1 = learn.panel1.Controls.Find(array[0].ToString(), true);
                            foreach (Control control1 in controls1)
                            {
                                controls2 = learn.panel1.Controls.Find(array[1].ToString(), true);
                                foreach (Control control2 in controls2)
                                {
                                    control2.Parent = control1;
                                }
                            }
                        }
                        if (i == 2)
                        {//三件目の処理
                            controls2 = learn.panel1.Controls.Find(array[1].ToString(), true);
                            foreach (Control control2 in controls2)
                            {
                                controls3 = learn.panel1.Controls.Find(array[2].ToString(), true);
                                foreach (Control control3 in controls3)
                                {
                                    control3.Parent = control2;
                                }
                            }
                        }
                        i++;
                    }
                    break;
                default:
                    break;

            }

        }
    }
}
