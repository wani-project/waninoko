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

namespace wani1
{
    public partial class LearnSelect : Form
    {
        public int screenflg = 0;
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
                    quest3.Text = "シールでじゃんけん！";
                    break;
                case 2:
                    quest1.Text = "キャラクターをうごかそう！";
                    quest2.Text = "イヌとネコをならべよう！";
                    quest3.Text = "どうぶつのいえにいこう！";
                    break;
                default:
                    break;
            }
        }
        private void quest1_Click(object sender, EventArgs e)
        {

            //ここからテスト----------------------------
            //DBからデータを取得する--------------
            // コネクションを開いてテーブル作成して閉じる  
            /*string db_file = "Test.db";
            using (var conn = new SQLiteConnection("Data Source=" + db_file))
            {
                conn.Open();
                using (SQLiteCommand command = conn.CreateCommand())
                {
                    command.CommandText = "create table Sample(Id INTEGER  PRIMARY KEY AUTOINCREMENT, Name TEXT, Age INTEGER)";
                    command.ExecuteNonQuery();
                }
                conn.Close();
            }
            */
            //------------------------------------
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
                    Learn learn = new Learn();
                    learn.questNum = 2;
                    learn.questTitle = "イヌ→ネコのじゅんばんで３かいならべるとどれになる？";
                    learn.Show();
                    break;
                case 2:
                    Review review = new Review();
                    review.questNum = 2;
                    review.questTitle = "イヌ→ネコのじゅんばんで３かいならべるとどれになる？";
                    review.Show();
                    break;
                default:
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
                    
                    break;
                default:
                    break;
            }
        }

        private void quest4_Click(object sender, EventArgs e)
        {

        }

        private void quest5_Click(object sender, EventArgs e)
        {
        
        }
    }
}
