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
    public partial class Form1 : Form
    {
        //画面フラグ変数 0がメインメニュー画面
        LearnSelect ls = new LearnSelect();
        

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            ls.screenflg = 0;
        }
        //がくしゅうもーどボタン
        private void learn_button_Click_1(object sender, EventArgs e)
        {
            LearnSelect ls = new LearnSelect();
            if(ls.screenflg != 1)
            {
                ls.screenflg = 1;
                ls.Show();
            }else if(ls.screenflg == 1)
            {
                ls.WindowState = FormWindowState.Normal;                
            }
        }
        //ふくしゅうもーどボタン
        private void review_button_Click_1(object sender, EventArgs e)
        {
            LearnSelect ls = new LearnSelect();
            if(ls.screenflg != 2)
            {
                ls.screenflg = 2;
                ls.Show();
            }else if(ls.screenflg == 2)
            {
                ls.WindowState = FormWindowState.Normal;
            }
        }
        //ちゃれんじもーどボタン
        private void challenge_button_Click_1(object sender, EventArgs e)
        {
            Challenge challenge = new Challenge();
            if (ls.screenflg != 3)
            {
                ls.screenflg = 3;
                challenge.Show();
            }else if(ls.screenflg == 3)
            {
                challenge.WindowState = FormWindowState.Normal;
            }
        }
        //図鑑ボタン
        private void PictureBook_Click(object sender, EventArgs e)
        {
            PictureBook zukan = new PictureBook();
            if(ls.screenflg != 4)
            {
                ls.screenflg = 4;
                zukan.Show();
            }else if(ls.screenflg == 4)
            {
                zukan.WindowState = FormWindowState.Normal;
            }
        }
        //画面遷移
        public void ScreenSwitch()
        {
            ls.screenflg = 0;
        }
    }
}
