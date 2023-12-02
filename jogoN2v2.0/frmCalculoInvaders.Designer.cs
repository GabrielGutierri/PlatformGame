namespace jogoN2v2._0
{
    partial class frmCalculoInvaders
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCalculoInvaders));
            this.lblPontos = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.pcbJogador = new System.Windows.Forms.PictureBox();
            this.lblVidas = new System.Windows.Forms.Label();
            this.lblRecorde = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pcbJogador)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPontos
            // 
            this.lblPontos.AutoSize = true;
            this.lblPontos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPontos.ForeColor = System.Drawing.SystemColors.Control;
            this.lblPontos.Location = new System.Drawing.Point(12, 528);
            this.lblPontos.Name = "lblPontos";
            this.lblPontos.Size = new System.Drawing.Size(97, 24);
            this.lblPontos.TabIndex = 1;
            this.lblPontos.Text = "Pontos: 0";
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.InvadersTimerEvent);
            // 
            // pcbJogador
            // 
            this.pcbJogador.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pcbJogador.Image = global::jogoN2v2._0.Properties.Resources.Wuo_2;
            this.pcbJogador.Location = new System.Drawing.Point(204, 509);
            this.pcbJogador.Name = "pcbJogador";
            this.pcbJogador.Size = new System.Drawing.Size(57, 43);
            this.pcbJogador.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbJogador.TabIndex = 0;
            this.pcbJogador.TabStop = false;
            // 
            // lblVidas
            // 
            this.lblVidas.AutoSize = true;
            this.lblVidas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVidas.ForeColor = System.Drawing.SystemColors.Control;
            this.lblVidas.Location = new System.Drawing.Point(625, 9);
            this.lblVidas.Name = "lblVidas";
            this.lblVidas.Size = new System.Drawing.Size(85, 24);
            this.lblVidas.TabIndex = 2;
            this.lblVidas.Text = "Vidas: 3";
            // 
            // lblRecorde
            // 
            this.lblRecorde.AutoSize = true;
            this.lblRecorde.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecorde.ForeColor = System.Drawing.SystemColors.Control;
            this.lblRecorde.Location = new System.Drawing.Point(12, 9);
            this.lblRecorde.Name = "lblRecorde";
            this.lblRecorde.Size = new System.Drawing.Size(176, 24);
            this.lblRecorde.TabIndex = 3;
            this.lblRecorde.Text = "Melhor Rodada: 0";
            // 
            // frmCalculoInvaders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(734, 561);
            this.Controls.Add(this.lblRecorde);
            this.Controls.Add(this.lblVidas);
            this.Controls.Add(this.lblPontos);
            this.Controls.Add(this.pcbJogador);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCalculoInvaders";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Space Invaders";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.pcbJogador)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pcbJogador;
        private System.Windows.Forms.Label lblPontos;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label lblVidas;
        private System.Windows.Forms.Label lblRecorde;
    }
}
