using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wani1
{
    public partial class R4 : Form
    {
        public R4()
        {
            InitializeComponent();
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void review_back_button_Click(object sender, EventArgs e)
        {

            {
                this.Dispose();
            }

        }


        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            
        {
          
            {

                for (int i = 0; i < 50; i++)
                {
                    //コンストラクタに引数を指定しないでインスタンスを作成
                    Random rnd = new Random();

                    for (int j = 0; j < 10; j++)
                    {
                        Console.Write("{0} ", rnd.Next(10, 100));
                    }
                }//for(i)文の終わり
            }
        }
    }

        private void label6_Click(object sender, EventArgs e)
        {
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
        
        }

        private void labelsu3_Click(object sender, EventArgs e)
        {

         
        }

        private void labelsu4_Click(object sender, EventArgs e)
        {
            
        }

        private void kaitou1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private int Random()
        {
            //時刻からシード値を取得
            int seed = Environment.TickCount;
            //ランダム変数のインスタンス化
            Random random = new Random(seed++);
            //randNumに0～50のランダムな値を代入
            return ((int)random.Next(0, 50)/10)*10;
        }

        private void R4_Load(object sender, EventArgs e)
        {
            labelsu1.Text = Random().ToString();
            labelsu2.Text = Random().ToString();
            labelsu3.Text = Random().ToString();
            labelsu4.Text = Random().ToString();
            labelsu5.Text = Random().ToString();
        }
    }
}
