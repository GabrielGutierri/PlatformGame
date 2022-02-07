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
    public partial class frmTutorialInvaders : Form
    {
        public frmTutorialInvaders()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel1.Width += 7;
            if(panel1.Width > 390)
            {
                timer1.Stop();
                this.Close();
            }
        }
    }
}
