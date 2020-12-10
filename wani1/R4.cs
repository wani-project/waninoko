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
            // Random クラスの新しいインスタンスを生成する
            Random cRandom = new System.Random();

            int iResult1 = cRandom.Next();

            int iResult2 = cRandom.Next(51);

            // 10 以上 51 未満の乱数を取得する
            int iResult3 = cRandom.Next(10, 51);

            // 取得した乱数を表示する
            MessageBox.Show(
                iResult1.ToString() + System.Environment.NewLine +
                iResult2.ToString() + System.Environment.NewLine +
                iResult3.ToString()
            );
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            // Random クラスの新しいインスタンスを生成する
            Random cRandom = new System.Random();

            int iResult1 = cRandom.Next();

            int iResult2 = cRandom.Next(51);

            // 10 以上 51 未満の乱数を取得する
            int iResult3 = cRandom.Next(10, 51);

            // 取得した乱数を表示する
            MessageBox.Show(
                iResult1.ToString() + System.Environment.NewLine +
                iResult2.ToString() + System.Environment.NewLine +
                iResult3.ToString()
            );
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            // Random クラスの新しいインスタンスを生成する
            Random cRandom = new System.Random();

            int iResult1 = cRandom.Next();

            int iResult2 = cRandom.Next(51);

            // 10 以上 51 未満の乱数を取得する
            int iResult3 = cRandom.Next(10, 51);

            // 取得した乱数を表示する
            MessageBox.Show(
                iResult1.ToString() + System.Environment.NewLine +
                iResult2.ToString() + System.Environment.NewLine +
                iResult3.ToString()
            );
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            // Random クラスの新しいインスタンスを生成する
            Random cRandom = new System.Random();

            int iResult1 = cRandom.Next();

            int iResult2 = cRandom.Next(51);

            // 10 以上 51 未満の乱数を取得する
            int iResult3 = cRandom.Next(10, 51);

            // 取得した乱数を表示する
            MessageBox.Show(
                iResult1.ToString() + System.Environment.NewLine +
                iResult2.ToString() + System.Environment.NewLine +
                iResult3.ToString()
            );
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            // Random クラスの新しいインスタンスを生成する
            Random cRandom = new System.Random();

            int iResult1 = cRandom.Next();

            int iResult2 = cRandom.Next(51);

            // 10 以上 51 未満の乱数を取得する
            int iResult3 = cRandom.Next(10, 51);

            // 取得した乱数を表示する
            MessageBox.Show(
                iResult1.ToString() + System.Environment.NewLine +
                iResult2.ToString() + System.Environment.NewLine +
                iResult3.ToString()
            );
        }
    }
}
