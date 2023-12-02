namespace jogoN2v2._0
{
    partial class frmDinoGame
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
            this.pcbWuo = new System.Windows.Forms.PictureBox();
            this.txtRecord = new System.Windows.Forms.Label();
            this.txtLifes = new System.Windows.Forms.Label();
            this.txtMensagem = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbWuo)).BeginInit();
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
            this.txtScore.Text = "Points: 0";
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
            // pcbWuo
            // 
            this.pcbWuo.BackColor = System.Drawing.Color.White;
            this.pcbWuo.Image = global::jogoN2v2._0.Properties.Resources.jogowuogif;
            this.pcbWuo.Location = new System.Drawing.Point(60, 243);
            this.pcbWuo.Name = "pcbWuo";
            this.pcbWuo.Size = new System.Drawing.Size(57, 126);
            this.pcbWuo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pcbWuo.TabIndex = 0;
            this.pcbWuo.TabStop = false;
            // 
            // txtRecord
            // 
            this.txtRecord.AutoSize = true;
            this.txtRecord.BackColor = System.Drawing.Color.Black;
            this.txtRecord.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecord.ForeColor = System.Drawing.Color.White;
            this.txtRecord.Location = new System.Drawing.Point(12, 417);
            this.txtRecord.Name = "txtRecord";
            this.txtRecord.Size = new System.Drawing.Size(166, 24);
            this.txtRecord.TabIndex = 2;
            this.txtRecord.Text = "Best Round: 0";
            // 
            // txtLifes
            // 
            this.txtLifes.AutoSize = true;
            this.txtLifes.BackColor = System.Drawing.Color.Black;
            this.txtLifes.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLifes.ForeColor = System.Drawing.Color.White;
            this.txtLifes.Location = new System.Drawing.Point(682, 417);
            this.txtLifes.Name = "txtLifes";
            this.txtLifes.Size = new System.Drawing.Size(106, 24);
            this.txtLifes.TabIndex = 3;
            this.txtLifes.Text = "Lifes: 3";
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
            // frmDinoGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtMensagem);
            this.Controls.Add(this.txtLifes);
            this.Controls.Add(this.txtRecord);
            this.Controls.Add(this.chao);
            this.Controls.Add(this.txtScore);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pcbWuo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmDinoGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "T-Wuo";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyisdown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyisup);
            ((System.ComponentModel.ISupportInitialize)(this.chao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbWuo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pcbWuo;
        private System.Windows.Forms.PictureBox chao;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label txtScore;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label txtRecord;
        private System.Windows.Forms.Label txtLifes;
        private System.Windows.Forms.Label txtMensagem;
    }
}