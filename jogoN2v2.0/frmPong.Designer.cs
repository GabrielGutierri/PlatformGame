namespace jogoN2v2._0
{
    partial class frmPong
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timerPong = new System.Windows.Forms.Timer(this.components);
            this.lblPointsPlayer = new System.Windows.Forms.Label();
            this.lblPointsPC = new System.Windows.Forms.Label();
            this.pcbBall = new System.Windows.Forms.PictureBox();
            this.pcbPc = new System.Windows.Forms.PictureBox();
            this.pcbPlayer = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pcbBall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // timerPong
            // 
            this.timerPong.Interval = 20;
            this.timerPong.Tick += new System.EventHandler(this.timerPong_Click);
            // 
            // lblPointsPlayer
            // 
            this.lblPointsPlayer.AutoSize = true;
            this.lblPointsPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPointsPlayer.ForeColor = System.Drawing.Color.White;
            this.lblPointsPlayer.Location = new System.Drawing.Point(12, 9);
            this.lblPointsPlayer.Name = "lblPointsPlayer";
            this.lblPointsPlayer.Size = new System.Drawing.Size(65, 20);
            this.lblPointsPlayer.TabIndex = 3;
            this.lblPointsPlayer.Text = "Wuo: 0";
            // 
            // lblPointsPC
            // 
            this.lblPointsPC.AutoSize = true;
            this.lblPointsPC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPointsPC.ForeColor = System.Drawing.Color.White;
            this.lblPointsPC.Location = new System.Drawing.Point(686, 9);
            this.lblPointsPC.Name = "lblPointsPC";
            this.lblPointsPC.Size = new System.Drawing.Size(76, 20);
            this.lblPointsPC.TabIndex = 4;
            this.lblPointsPC.Text = "Limits: 0";
            // 
            // pcbBall
            // 
            this.pcbBall.BackColor = System.Drawing.Color.White;
            this.pcbBall.Location = new System.Drawing.Point(400, 310);
            this.pcbBall.Name = "pcbBall";
            this.pcbBall.Size = new System.Drawing.Size(23, 23);
            this.pcbBall.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbBall.TabIndex = 2;
            this.pcbBall.TabStop = false;
            // 
            // pcbPc
            // 
            this.pcbPc.BackColor = System.Drawing.Color.Transparent;
            this.pcbPc.Image = global::jogoN2v2._0.Properties.Resources.wuoputador;
            this.pcbPc.Location = new System.Drawing.Point(724, 200);
            this.pcbPc.Name = "pcbPc";
            this.pcbPc.Size = new System.Drawing.Size(48, 79);
            this.pcbPc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbPc.TabIndex = 1;
            this.pcbPc.TabStop = false;
            // 
            // pcbPlayer
            // 
            this.pcbPlayer.BackColor = System.Drawing.Color.Transparent;
            this.pcbPlayer.Image = global::jogoN2v2._0.Properties.Resources.awdaw;
            this.pcbPlayer.Location = new System.Drawing.Point(12, 200);
            this.pcbPlayer.Name = "pcbPlayer";
            this.pcbPlayer.Size = new System.Drawing.Size(48, 79);
            this.pcbPlayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbPlayer.TabIndex = 0;
            this.pcbPlayer.TabStop = false;
            // 
            // frmPong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(784, 581);
            this.Controls.Add(this.lblPointsPC);
            this.Controls.Add(this.lblPointsPlayer);
            this.Controls.Add(this.pcbBall);
            this.Controls.Add(this.pcbPc);
            this.Controls.Add(this.pcbPlayer);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmPong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pong";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyisdown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyisup);
            ((System.ComponentModel.ISupportInitialize)(this.pcbBall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pcbPlayer;
        private System.Windows.Forms.PictureBox pcbPc;
        private System.Windows.Forms.PictureBox pcbBall;
        private System.Windows.Forms.Timer timerPong;
        private System.Windows.Forms.Label lblPointsPlayer;
        private System.Windows.Forms.Label lblPointsPC;
    }
}