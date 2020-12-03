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
    class ReviewCreateControls
    {
        

        public void CreateControls(Review review, int num, string kinds, Point location, string name)
        {
            switch (num)
            {
                case 1:
                    //肉部品設定
                    PictureBox meat = new PictureBox();
                    //選択肢設定
                    ComboBox direction = new ComboBox();
                    //ラベル設定
                    Label labelL = new Label();
                    //labelL設定
                    labelL.Font = new Font(labelL.Font.FontFamily, 16, FontStyle.Bold);
                    labelL.Size = new Size(200, 40);
                    labelL.ForeColor = Color.White;
                    labelL.BackColor = Color.Transparent;
                    labelL.Parent = meat;
                    
                    //回数設定
                    TextBox countBox = new TextBox();
                    countBox.Multiline = true;
                    countBox.Size = new Size(35,25);
                    countBox.TextAlign = HorizontalAlignment.Center;
                    countBox.Font = new Font(countBox.Font.FontFamily, 16);
                    countBox.KeyPress += new KeyPressEventHandler(countBox_KeyPress);
                    countBox.BringToFront();

                    review.MeatCount++;
                    switch (name)
                    {
                        case "meat_0":
                            meat.Name = "meat_" + review.MeatCount;
                            meat.Image = Image.FromFile(review.FilePath + "\\images\\flowchart\\meat.png");
                            labelL.Text = "うえに     マスすすむ";
                            labelL.Location = new Point(65, 25);
                            break;
                        case "catfish_0":
                            meat.Name = "catfish_" + review.MeatCount;
                            meat.Image = Image.FromFile(review.FilePath + "\\images\\flowchart\\catfish.png");
                            labelL.Text = "みぎに     マスすすむ";
                            labelL.Location = new Point(62, 20);                          
                            break;
                        case "crab_0":
                            meat.Name = "crab_" + review.MeatCount;
                            meat.Image = Image.FromFile(review.FilePath + "\\images\\flowchart\\crab.png");
                            labelL.Text = "みぎに     マスすすむ";
                            labelL.Location = new Point(62, 40);                          
                            break;
                        case "shell_0":
                            meat.Name = "shell_" + review.MeatCount;
                            meat.Image = Image.FromFile(review.FilePath + "\\images\\flowchart\\shell.png");
                            labelL.Text = "うえに     マスすすむ";
                            labelL.ForeColor = Color.Black;
                            labelL.Location = new Point(65, 25);
                            break;
                    }
                    //肉
                    meat.Size = new Size(320, 79);
                    meat.SizeMode = PictureBoxSizeMode.StretchImage;
                    switch (review.MeatCount)
                    {
                        case 1:
                            meat.Location = new Point(0, 145);
                            if(name == "catfish_0")
                            {
                                countBox.Location = new Point(120, 165);//20
                            }
                            else if(name == "crab_0")
                            {
                                countBox.Location = new Point(120, 185);//40
                            }
                            else
                            {
                                countBox.Location = new Point(120, 170);//25
                            }
                            
                            countBox.Name = "count_1";
                            break;
                        case 2:
                            meat.Location = new Point(0, 235);
                            if (name == "catfish_0")
                            {
                                countBox.Location = new Point(120, 255);
                            }
                            else if (name == "crab_0")
                            {
                                countBox.Location = new Point(120, 275);
                            }
                            else
                            {
                                countBox.Location = new Point(120, 260);
                            }
                            countBox.Name = "count_2";

                            break;
                        case 3:
                            meat.Location = new Point(0, 330);
                            if (name == "catfish_0")
                            {
                                countBox.Location = new Point(120, 350);
                            }
                            else if (name == "crab_0")
                            {
                                countBox.Location = new Point(120, 370);
                            }
                            else
                            {
                                countBox.Location = new Point(120, 355);
                            }
                            countBox.Name = "count_3";
                            break;
                        case 4:
                            meat.Location = new Point(0, 420);
                            if (name == "catfish_0")
                            {
                                countBox.Location = new Point(120, 440);
                            }
                            else if (name == "crab_0")
                            {
                                countBox.Location = new Point(120, 460);
                            }
                            else
                            {
                                countBox.Location = new Point(120, 445);
                            }
                            countBox.Name = "count_4";
                            break;
                        default:
                            break;
                    }
                    meat.BackColor = Color.FromName("White");
                    
                    //meat.MouseDown += new MouseEventHandler(this.panel_MouseDown);
                    //meat.MouseMove += new MouseEventHandler(this.panel_MouseMove);
                    //meat.MouseUp += new MouseEventHandler(this.panel_MouseUp);
                    //追加
                    review.panel4.Controls.Add(meat);
                    review.panel4.Controls.Add(countBox);
                    meat.BringToFront();
                    countBox.BringToFront();
                    
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
        private void panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            Cursor.Current = Cursors.Hand;
            _isDraging = true;
            _diffPoint = e.Location;

            Review review = new Review();
            switch (sender.GetType().ToString())
            {
                case "System.Windows.Forms.Panel":
                    cont0 = (Panel)sender;
                    break;
                case "System.Windows.Forms.PictureBox":
                    cont0 = (PictureBox)sender;
                    break;
            }
            review.panel1.Size = cont0.Size;
            review.panel1.Location = cont0.Location;
            cont0.BringToFront();
        }
        private void panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_isDraging)
            {
                return;
            }
            Review review = new Review();
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
            review.panel1.Location = new Point(x, y);
        }
        private void panel_MouseUp(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Default;
            _isDraging = false;
            Review review = new Review();
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
        }


        //------------------------------------------------------------------------

        private void countBox_KeyPress(object sender,System.Windows.Forms.KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b')
            {
                //押されたキーが 0～9でない場合は、イベントをキャンセルする
                e.Handled = true;
            }
        }

        public void SetParent(Review review, string name, ArrayList array)
        {
            switch (name)
            {
                case "docat":
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
                            controls1 = review.panel1.Controls.Find(array[0].ToString(), true);
                            foreach (Control control1 in controls1)
                            {
                                controls2 = review.panel1.Controls.Find(array[1].ToString(), true);
                                foreach (Control control2 in controls2)
                                {
                                    control2.Parent = control1;
                                }
                            }
                        }
                        if (i == 2)
                        {//三件目の処理
                            controls2 = review.panel1.Controls.Find(array[1].ToString(), true);
                            foreach (Control control2 in controls2)
                            {
                                controls3 = review.panel1.Controls.Find(array[2].ToString(), true);
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
