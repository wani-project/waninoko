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
        private string RO = Directory.GetCurrentDirectory() + "\\images\\Background\\Background_RO.png";
        private string BG = Directory.GetCurrentDirectory() + "\\images\\Background\\Background_BG.png";
        private string BP = Directory.GetCurrentDirectory() + "\\images\\Background\\Background_BP.png";
        private string PP = Directory.GetCurrentDirectory() + "\\images\\Background\\Background_PP.png";
        private string YG = Directory.GetCurrentDirectory() + "\\images\\Background\\Background_YG.png";

        //もんだいえらんでね背景画像
        private string LB = Directory.GetCurrentDirectory() + "\\images\\Background\\Cat_O.png";
        private string RB = Directory.GetCurrentDirectory() + "\\images\\Background\\DOG_G.png";
        private string CB = Directory.GetCurrentDirectory() + "\\images\\Background\\WANI_W.png";

        //ボタン背景画像
        private string YR1 = Directory.GetCurrentDirectory() + "\\images\\Button\\YR\\Button1.png";
        private string YR2 = Directory.GetCurrentDirectory() + "\\images\\Button\\YR\\Button2.png";
        private string YR3 = Directory.GetCurrentDirectory() + "\\images\\Button\\YR\\Button3.png";
        private string YR4 = Directory.GetCurrentDirectory() + "\\images\\Button\\YR\\Button4.png";
        private string YR5 = Directory.GetCurrentDirectory() + "\\images\\Button\\YR\\Button5.png";

        private string G1 = Directory.GetCurrentDirectory() + "\\images\\Button\\G\\Button6.png";
        private string G2 = Directory.GetCurrentDirectory() + "\\images\\Button\\G\\Button7.png";
        private string G3 = Directory.GetCurrentDirectory() + "\\images\\Button\\G\\Button8.png";
        private string G4 = Directory.GetCurrentDirectory() + "\\images\\Button\\G\\Button9.png";
        private string G5 = Directory.GetCurrentDirectory() + "\\images\\Button\\G\\Button10.png";

        private string B1 = Directory.GetCurrentDirectory() + "\\images\\Button\\B\\Button11.png";
        private string B2 = Directory.GetCurrentDirectory() + "\\images\\Button\\B\\Button12.png";
        private string B3 = Directory.GetCurrentDirectory() + "\\images\\Button\\B\\Button13.png";
        private string B4 = Directory.GetCurrentDirectory() + "\\images\\Button\\B\\Button14.png";
        private string B5 = Directory.GetCurrentDirectory() + "\\images\\Button\\B\\Button15.png";

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

                    quest1.BackgroundImage = Image.FromFile(YR1);
                    quest2.BackgroundImage = Image.FromFile(YR2);
                    quest3.BackgroundImage = Image.FromFile(YR3);
                    quest4.BackgroundImage = Image.FromFile(YR4);
                    quest5.BackgroundImage = Image.FromFile(YR5);

                    this.BackgroundImage = Image.FromFile(LB);

                    break;
                case 2:
                    quest1.Text = "キャラクターをうごかそう！";
                    quest2.Text = "イヌとネコをならべよう！";
                    quest3.Text = "ワニをおよがせよう！";
                    quest4.Text = "じゅんびちゅうだよ！";
                    quest4.Enabled = false;
                    quest5.Text = "じゅんびちゅうだよ！";
                    quest5.Enabled = false;

                    quest1.BackgroundImage = Image.FromFile(G1);
                    quest2.BackgroundImage = Image.FromFile(G2);
                    quest3.BackgroundImage = Image.FromFile(G3);
                    quest4.BackgroundImage = Image.FromFile(G4);
                    quest5.BackgroundImage = Image.FromFile(G5);

                    this.BackgroundImage = Image.FromFile(RB);
                    break;
                case 3:
                    quest1.Text = "じゅんびちゅうだよ！";
                    quest1.Enabled = false;
                    quest2.Text = "くだものをマスにいれよう！";
                    quest3.Text = "新しい紙をつくろう！";
                    quest4.Text = "じゅんびちゅうだよ！";
                    quest4.Enabled = false;
                    quest5.Text = "じゅんびちゅうだよ！";
                    quest5.Enabled = false;

                    quest1.BackgroundImage = Image.FromFile(B1);
                    quest2.BackgroundImage = Image.FromFile(B2);
                    quest3.BackgroundImage = Image.FromFile(B3);
                    quest4.BackgroundImage = Image.FromFile(B4);
                    quest5.BackgroundImage = Image.FromFile(B5);

                    this.BackgroundImage = Image.FromFile(CB);
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
                    learn.BackgroundImage = Image.FromFile(BG);
                    learn.Learn_Group.BackgroundImage = Image.FromFile(BG);
                    learn.Show();
                    break;
                case 2:
                    Review review = new Review();
                    review.questNum = 1;
                    review.questTitle = "ぶひんをくみあわせてゴールまですすもう！";
                    review.Show();
                    break;
                case 3:
                    //C1 c1 = new C1();
                    //c1.Show();
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
                    review.BackgroundImage = Image.FromFile(RO);
                    review.Review_Group.BackgroundImage = Image.FromFile(RO);
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
                case 3:
                    C3 c3 = new C3();
                    c3.Show();
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
                    break;
            }
        }
    }
}
