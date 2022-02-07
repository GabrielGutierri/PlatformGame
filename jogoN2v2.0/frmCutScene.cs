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
    public partial class frmCutScene : Form
    {
        int c = 0;
        public frmCutScene()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            wmpMedia.Ctlcontrols.stop();
            this.Close();
        }

        private void frmCutScene_Load(object sender, EventArgs e)
        {
            wmpMedia.URL = "scene.mp4";
            wmpMedia.Ctlcontrols.play();
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.BackColor = Color.White;
            button1.ForeColor = Color.Black;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Black;
            button1.ForeColor = Color.White;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            c += 1;
            if (c >= 136)
            {
                wmpMedia.Ctlcontrols.stop();
                this.Close();
            }
        }
    }
}
