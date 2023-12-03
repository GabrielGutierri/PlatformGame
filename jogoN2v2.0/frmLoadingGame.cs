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
    public partial class frmLoadingGame : Form
    {
        public frmLoadingGame()
        {
            InitializeComponent();
            timerLoadingScreen.Start();
        }
        private void timerScreen_Tick(object sender, EventArgs e)
        {
            pnlLoadingScreen.Width += 15;
            if (pnlLoadingScreen.Width >= pnlLoadingScreenContainer.Width)
            {
                timerLoadingScreen.Stop();
                this.Close();
            }
        }
    }
}
