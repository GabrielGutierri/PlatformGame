using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jogoN2v2._0
{
    public partial class frmHelp : Form
    {
        public frmHelp()
        {
            InitializeComponent();
        }

        private void btnClose_MouseMove(object sender, MouseEventArgs e)
        {
            btnClose.BackColor = Color.White;
            btnClose.ForeColor = Color.DarkRed;
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.DarkRed;
            btnClose.ForeColor = Color.White;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblCreators_MouseMove(object sender, MouseEventArgs e)
        {
            lblCreators.ForeColor = Color.DarkRed;
        }

        private void lblCreators_MouseLeave(object sender, EventArgs e)
        {
            lblCreators.ForeColor = Color.White;
        }
    }
}
