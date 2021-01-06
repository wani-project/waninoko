﻿using System;
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
    public partial class R4 : Form
    {
        private string FilePath = Directory.GetCurrentDirectory();
        private int[] ans = { 0, 0, 0 };
        private int[] answer = { 0, 0, 0 };
        private Point[] points = { new Point(27, 54), new Point(245, 54), new Point(473, 54) };

        public R4()
        {
            InitializeComponent();
        }
        private void R4_Load(object sender, EventArgs e)
        {
            CreateChara();
            CreateEnergy();
            GetNum();
        }
        private void review_back_button_Click(object sender, EventArgs e)
        {

            {
                this.Dispose();
            }

        }
        //回答ボタン
        private void button_answer_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
        //エネルギーの値をランダムで取得
        private int Random(int i)
        {
            //時刻からシード値を取得
            int seed = Environment.TickCount + i;
            //ランダム変数のインスタンス化
            Random random = new Random(seed++);
            //randNumに0～50のランダムな値を代入
            return ((int)random.Next(10, 50) / 10) * 10;
        }
        private async void Start()
        {
            try
            {
                for (int i = 1; i <= 3; i++)
                {
                    Control[] label = panel1.Controls.Find("kaitou" + i, true);
                    foreach (Control c in label)
                    {
                        ans[i - 1] = int.Parse(c.Text);
                    }
                }
                if (ans[0] == answer[0])
                {
                    MoveChara(0);
                    MessageBox.Show("1問目正解");
                }
                else
                {
                    MessageBox.Show("1問目不正解");
                }
                await Task.Delay(2000);
                if (ans[1] == answer[1])
                {
                    MoveChara(1);
                    MessageBox.Show("2問目正解");
                }
                else
                {
                    MessageBox.Show("2問目不正解");
                }
                await Task.Delay(2000);
                if (ans[2] == answer[2])
                {
                    MoveChara(2);
                    MessageBox.Show("3問目正解");
                }
                else
                {
                    MessageBox.Show("3問目不正解");
                }
                await Task.Delay(2000);
            }
            catch (Exception e)
            {
                MessageBox.Show("こたえをかいてね！\r\n");

            }
        }

        private void CreateEnergy()
        {
            for (int i = 1; i <= 5; i++)
            {
                Control[] label = panel4.Controls.Find("labelsu" + i, true);
                foreach (Control c in label)
                {
                    c.Text = Random(i).ToString();
                }
            }
        }
        private void GetNum()
        {
            Control[] l = panel4.Controls.Find("labelsu3", true);
            foreach (Control c in l)
            {
                answer[0] = int.Parse(c.Text);
            }
            l = panel4.Controls.Find("labelsu1", true);
            foreach (Control c in l)
            {
                answer[1] = answer[0] + int.Parse(c.Text);
            }
            l = panel4.Controls.Find("labelsu2", true);
            foreach (Control c in l)
            {
                answer[2] = answer[1] + int.Parse(c.Text);
            }
        }
        //最初からボタン
        private void button2_Click(object sender, EventArgs e)
        {
            Reset();
            CreateEnergy();
            GetNum();
        }
        //初期化処理
        private void Reset()
        {
            ans.Initialize();
            answer.Initialize();
            for (int i = 1; i <= 3; i++)
            {
                Control[] label = panel1.Controls.Find("kaitou" + i, true);
                foreach (Control c in label)
                {
                    c.Text = null;
                }
            }
        }
        //数値のみの入力に制限
        private void kaitou_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b')
            {
                //押されたキーが 0～9でない場合は、イベントをキャンセルする
                e.Handled = true;
            }
        }

        //ワニ作成処理
        private void CreateChara()
        {
            //設定
            PictureBox wani = new PictureBox();
            wani.Name = "wani";
            wani.Location = new Point(245, 445);
            wani.Size = new Size(111, 102);
            wani.SizeMode = PictureBoxSizeMode.StretchImage;
            wani.BackColor = Color.Transparent;
            wani.Image = Image.FromFile(FilePath + "\\images\\idle.gif");
            //追加
            panel4.Controls.Add(wani);
            wani.BringToFront();
        }
        //ワニ移動処理
        private async void MoveChara(int point)
        {
            Control[] controls = panel4.Controls.Find("wani", true);
            foreach(PictureBox c in controls)
            {
                //走るGIFに画像を変更
                c.Image = Image.FromFile(FilePath + "\\images\\Run.gif");
                if(c.Location.Y != 54)
                {
                    for (int y = 54; y < c.Location.Y; y -= 3)
                    {
                        c.Location = new Point(c.Location.X, c.Location.Y - 3);
                        if (c.Location.X > points[point].X)
                        {
                            c.Location = new Point(c.Location.X - 2, c.Location.Y);//途中
                        }
                        await Task.Delay(25);
                    }
                }
                
            }
            await Task.Delay(1000);
        }
    }
}
