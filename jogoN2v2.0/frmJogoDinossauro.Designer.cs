namespace jogoN2v2._0
{
    partial class frmJogoDinossauro
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
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.txtScore = new System.Windows.Forms.Label();
            this.chao = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.wuo = new System.Windows.Forms.PictureBox();
            this.txtRecorde = new System.Windows.Forms.Label();
            this.txtVidas = new System.Windows.Forms.Label();
            this.txtMensagem = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wuo)).BeginInit();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Interval = 20;
            this.timer.Tick += new System.EventHandler(this.MainGameTimerEvent);
            // 
            // txtScore
            // 
            this.txtScore.AutoSize = true;
            this.txtScore.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScore.Location = new System.Drawing.Point(12, 9);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(118, 24);
            this.txtScore.TabIndex = 1;
            this.txtScore.Text = "Pontos: 0";
            // 
            // chao
            // 
            this.chao.BackColor = System.Drawing.Color.Black;
            this.chao.Location = new System.Drawing.Point(-6, 368);
            this.chao.Name = "chao";
            this.chao.Size = new System.Drawing.Size(810, 88);
            this.chao.TabIndex = 0;
            this.chao.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::jogoN2v2._0.Properties.Resources._1;
            this.pictureBox1.Location = new System.Drawing.Point(501, 305);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(59, 64);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Tag = "obstaculo";
            // 
            // wuo
            // 
            this.wuo.BackColor = System.Drawing.Color.White;
            this.wuo.Image = global::jogoN2v2._0.Properties.Resources.jogowuogif;
            this.wuo.Location = new System.Drawing.Point(60, 243);
            this.wuo.Name = "wuo";
            this.wuo.Size = new System.Drawing.Size(57, 126);
            this.wuo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.wuo.TabIndex = 0;
            this.wuo.TabStop = false;
            // 
            // txtRecorde
            // 
            this.txtRecorde.AutoSize = true;
            this.txtRecorde.BackColor = System.Drawing.Color.Black;
            this.txtRecorde.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecorde.ForeColor = System.Drawing.Color.White;
            this.txtRecorde.Location = new System.Drawing.Point(12, 417);
            this.txtRecorde.Name = "txtRecorde";
            this.txtRecorde.Size = new System.Drawing.Size(202, 24);
            this.txtRecorde.TabIndex = 2;
            this.txtRecorde.Text = "Melhor Rodada: 0";
            // 
            // txtVidas
            // 
            this.txtVidas.AutoSize = true;
            this.txtVidas.BackColor = System.Drawing.Color.Black;
            this.txtVidas.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVidas.ForeColor = System.Drawing.Color.White;
            this.txtVidas.Location = new System.Drawing.Point(682, 417);
            this.txtVidas.Name = "txtVidas";
            this.txtVidas.Size = new System.Drawing.Size(106, 24);
            this.txtVidas.TabIndex = 3;
            this.txtVidas.Text = "Vidas: 3";
            // 
            // txtMensagem
            // 
            this.txtMensagem.AutoSize = true;
            this.txtMensagem.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMensagem.Location = new System.Drawing.Point(265, 96);
            this.txtMensagem.Name = "txtMensagem";
            this.txtMensagem.Size = new System.Drawing.Size(0, 24);
            this.txtMensagem.TabIndex = 4;
            // 
            // frmJogoDinossauro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtMensagem);
            this.Controls.Add(this.txtVidas);
            this.Controls.Add(this.txtRecorde);
            this.Controls.Add(this.chao);
            this.Controls.Add(this.txtScore);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.wuo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmJogoDinossauro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "T-Wuo";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyisdown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyisup);
            ((System.ComponentModel.ISupportInitialize)(this.chao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wuo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox wuo;
        private System.Windows.Forms.PictureBox chao;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label txtScore;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label txtRecorde;
        private System.Windows.Forms.Label txtVidas;
        private System.Windows.Forms.Label txtMensagem;
    }
}