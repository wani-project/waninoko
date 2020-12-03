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
    public partial class Challenge : Form
    {
        public Challenge()
        {
            InitializeComponent();
        }

        private void challenge_back_button_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.ScreenSwitch();
            this.Dispose();
        }

        private void Challenge_Load(object sender, EventArgs e)
        {
            Challenge_Group.Visible = true;
        }
        private void Challenge_Close(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
