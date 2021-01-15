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
    public partial class R6 : Form
    {
        public R6()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Cell_Click(object sender, EventArgs e)
        {
            ggwp();
        }

        private void ggwp()
        {
            this.Dispose();
        }

        private void R6_Load(object sender, EventArgs e)
        {
            
        }
        //移動処理の初期変数---------
        bool _isDraging = false;
        Point? _diffPoint = null;
        private void MouseMove(object sender, MouseEventArgs e)
        {
            if (!_isDraging)
            {
                return;
            }

        }
        private void MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            Cursor.Current = Cursors.Hand;
            _isDraging = true;
            _diffPoint = e.Location;

        }
    }
}
