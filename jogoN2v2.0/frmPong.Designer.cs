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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblPontosJogador = new System.Windows.Forms.Label();
            this.lblPontosPC = new System.Windows.Forms.Label();
            this.pcbBola = new System.Windows.Forms.PictureBox();
            this.pcbPc = new System.Windows.Forms.PictureBox();
            this.pcbPlayer = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pcbBola)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblPontosJogador
            // 
            this.lblPontosJogador.AutoSize = true;
            this.lblPontosJogador.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPontosJogador.ForeColor = System.Drawing.Color.White;
            this.lblPontosJogador.Location = new System.Drawing.Point(12, 9);
            this.lblPontosJogador.Name = "lblPontosJogador";
            this.lblPontosJogador.Size = new System.Drawing.Size(65, 20);
            this.lblPontosJogador.TabIndex = 3;
            this.lblPontosJogador.Text = "Wuo: 0";
            // 
            // lblPontosPC
            // 
            this.lblPontosPC.AutoSize = true;
            this.lblPontosPC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPontosPC.ForeColor = System.Drawing.Color.White;
            this.lblPontosPC.Location = new System.Drawing.Point(686, 9);
            this.lblPontosPC.Name = "lblPontosPC";
            this.lblPontosPC.Size = new System.Drawing.Size(86, 20);
            this.lblPontosPC.TabIndex = 4;
            this.lblPontosPC.Text = "Limites: 0";
            // 
            // pcbBola
            // 
            this.pcbBola.BackColor = System.Drawing.Color.White;
            this.pcbBola.Location = new System.Drawing.Point(400, 310);
            this.pcbBola.Name = "pcbBola";
            this.pcbBola.Size = new System.Drawing.Size(23, 23);
            this.pcbBola.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbBola.TabIndex = 2;
            this.pcbBola.TabStop = false;
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
            this.Controls.Add(this.lblPontosPC);
            this.Controls.Add(this.lblPontosJogador);
            this.Controls.Add(this.pcbBola);
            this.Controls.Add(this.pcbPc);
            this.Controls.Add(this.pcbPlayer);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmPong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PONG";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyisdown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyisup);
            ((System.ComponentModel.ISupportInitialize)(this.pcbBola)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pcbPlayer;
        private System.Windows.Forms.PictureBox pcbPc;
        private System.Windows.Forms.PictureBox pcbBola;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblPontosJogador;
        private System.Windows.Forms.Label lblPontosPC;
    }
}