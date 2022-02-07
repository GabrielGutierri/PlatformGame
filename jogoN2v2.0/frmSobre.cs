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
    public partial class frmSobre : Form
    {
        public frmSobre()
        {
            InitializeComponent();
        }

        private void btnFechar_MouseMove(object sender, MouseEventArgs e)
        {
            btnFechar.BackColor = Color.White;
            btnFechar.ForeColor = Color.DarkRed;
        }

        private void btnFechar_MouseLeave(object sender, EventArgs e)
        {
            btnFechar.BackColor = Color.DarkRed;
            btnFechar.ForeColor = Color.White;
        }

        private void btnFechar_Click(object sender, EventArgs e)
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
