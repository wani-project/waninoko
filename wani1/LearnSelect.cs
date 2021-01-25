using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace wani1
{
    public partial class LearnSelect : Form
    {
        public int screenflg = 0;
        private string FilePath = Directory.GetCurrentDirectory();
        public LearnSelect()
        {
            InitializeComponent();
        }

        private void quest_back_button_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        

        private void LearnSelect_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            //ここでDBから問題を取得---------------------------------------

            //-------------------------------------------------------------

            //問題タイトルをボタンに表示
            Form1 f1 = new Form1();
            switch (screenflg)
            {
                case 1:
                    quest1.Text = "イヌのかおをつくろう！";
                    quest2.Text = "イヌとネコをならべよう！";
                    quest3.Text = "どうぶつシールでじゃんけん！";
                    quest4.Text = "ふくをわけよう！";
                    quest5.Text = "つみきゲーム！";
                    break;
                case 2:
                    quest1.Text = "キャラクターをうごかそう！";
                    quest2.Text = "イヌとネコをならべよう！";
                    quest3.Text = "ワニをおよがせよう！";
                    break;
                case 3:
                    break;
                default:
                    break;
            }
        }
        private void quest1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            switch (screenflg)
            {
                case 1:
                    Learn learn = new Learn();
                    learn.questNum = 1;
                    learn.questTitle = "シールをかさねてイヌのかおをつくってね！";
                    learn.Show();
                    break;
                case 2:
                    Review review = new Review();
                    review.questNum = 1;
                    review.questTitle = "ぶひんをくみあわせてゴールまですすもう！";
                    review.Show();
                    break;
                case 3:
                    C1 c1 = new C1();
                    c1.Show();
                    break;
                default:
                    break;
            }
            //テスト------------------------------------
        }

        private void quest2_Click(object sender, EventArgs e)
        {
            switch (screenflg)
            {
                case 1:
                    L2 l2 = new L2();
                    l2.Show();
                    break;
                case 2:
                    Review review = new Review();
                    review.questNum = 2;
                    review.questTitle = "イヌ→ネコのじゅんばんで３かいならべよう！";
                    review.BackgroundImage = Image.FromFile(FilePath + "\\images\\Background\\Background_RO.png");
                    review.Show();
                    break;
                case 3:
                    C2 c2 = new C2();
                    c2.Show();
                    break;
            }
            
        }

        private void quest3_Click(object sender, EventArgs e)
        {
            switch (screenflg)
            {
                case 1:
                    L6 l6 = new L6();
                    l6.Show();
                    break;
                case 2:
                    R3 l3 = new R3();
                    l3.Show();
                    break;
            }            
        }

        private void quest4_Click(object sender, EventArgs e)
        {
            switch (screenflg)
            {
                case 1:
                    L4 l4 = new L4();
                    l4.Show();
                    break;
                case 2:
                    
                    break;
            }
        }
        private void quest5_Click(object sender, EventArgs e)
        {
            switch (screenflg)
            {
                case 1:
                    L3 l3 = new L3();
                    l3.Show();
                    break;
                case 2:
                    R6 r6 = new R6();
                    r6.Show();
                    break;
            }
        }
    }
}
