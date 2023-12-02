namespace jogoN2v2._0
{
    partial class frmGameOver
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGameOver));
            this.lblPointsMainGame = new System.Windows.Forms.Label();
            this.lblPointsInvaders = new System.Windows.Forms.Label();
            this.btnMenu = new System.Windows.Forms.Button();
            this.pcbGameOver = new System.Windows.Forms.PictureBox();
            this.lblTotalPoints = new System.Windows.Forms.Label();
            this.lblPointsPong = new System.Windows.Forms.Label();
            this.lblPointsDino = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pcbGameOver)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPointsMainGame
            // 
            this.lblPointsMainGame.AutoSize = true;
            this.lblPointsMainGame.BackColor = System.Drawing.Color.Transparent;
            this.lblPointsMainGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPointsMainGame.ForeColor = System.Drawing.Color.White;
            this.lblPointsMainGame.Location = new System.Drawing.Point(13, 108);
            this.lblPointsMainGame.Name = "lblPointsMainGame";
            this.lblPointsMainGame.Size = new System.Drawing.Size(60, 24);
            this.lblPointsMainGame.TabIndex = 1;
            this.lblPointsMainGame.Text = "label1";
            // 
            // lblPointsInvaders
            // 
            this.lblPointsInvaders.AutoSize = true;
            this.lblPointsInvaders.BackColor = System.Drawing.Color.Transparent;
            this.lblPointsInvaders.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPointsInvaders.ForeColor = System.Drawing.Color.White;
            this.lblPointsInvaders.Location = new System.Drawing.Point(13, 149);
            this.lblPointsInvaders.Name = "lblPointsInvaders";
            this.lblPointsInvaders.Size = new System.Drawing.Size(60, 24);
            this.lblPointsInvaders.TabIndex = 2;
            this.lblPointsInvaders.Text = "label2";
            // 
            // btnMenu
            // 
            this.btnMenu.BackColor = System.Drawing.Color.Black;
            this.btnMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenu.ForeColor = System.Drawing.Color.White;
            this.btnMenu.Location = new System.Drawing.Point(311, 338);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(147, 38);
            this.btnMenu.TabIndex = 4;
            this.btnMenu.Text = "Back to Menu";
            this.btnMenu.UseVisualStyleBackColor = false;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            this.btnMenu.MouseLeave += new System.EventHandler(this.btnMenu_MouseLeave);
            this.btnMenu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnMenu_MouseMove);
            // 
            // pcbGameOver
            // 
            this.pcbGameOver.Image = ((System.Drawing.Image)(resources.GetObject("pcbGameOver.Image")));
            this.pcbGameOver.Location = new System.Drawing.Point(56, -67);
            this.pcbGameOver.Name = "pcbGameOver";
            this.pcbGameOver.Size = new System.Drawing.Size(372, 250);
            this.pcbGameOver.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbGameOver.TabIndex = 5;
            this.pcbGameOver.TabStop = false;
            // 
            // lblTotalPoints
            // 
            this.lblTotalPoints.AutoSize = true;
            this.lblTotalPoints.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPoints.ForeColor = System.Drawing.Color.White;
            this.lblTotalPoints.Location = new System.Drawing.Point(13, 274);
            this.lblTotalPoints.Name = "lblTotalPoints";
            this.lblTotalPoints.Size = new System.Drawing.Size(66, 24);
            this.lblTotalPoints.TabIndex = 6;
            this.lblTotalPoints.Text = "label2";
            // 
            // lblPointsPong
            // 
            this.lblPointsPong.AutoSize = true;
            this.lblPointsPong.BackColor = System.Drawing.Color.Transparent;
            this.lblPointsPong.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPointsPong.ForeColor = System.Drawing.Color.White;
            this.lblPointsPong.Location = new System.Drawing.Point(13, 227);
            this.lblPointsPong.Name = "lblPointsPong";
            this.lblPointsPong.Size = new System.Drawing.Size(60, 24);
            this.lblPointsPong.TabIndex = 8;
            this.lblPointsPong.Text = "label2";
            // 
            // lblPointsDino
            // 
            this.lblPointsDino.AutoSize = true;
            this.lblPointsDino.BackColor = System.Drawing.Color.Transparent;
            this.lblPointsDino.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPointsDino.ForeColor = System.Drawing.Color.White;
            this.lblPointsDino.Location = new System.Drawing.Point(13, 186);
            this.lblPointsDino.Name = "lblPointsDino";
            this.lblPointsDino.Size = new System.Drawing.Size(60, 24);
            this.lblPointsDino.TabIndex = 7;
            this.lblPointsDino.Text = "label1";
            // 
            // frmGameOver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(470, 388);
            this.Controls.Add(this.lblPointsPong);
            this.Controls.Add(this.lblPointsDino);
            this.Controls.Add(this.lblTotalPoints);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.lblPointsInvaders);
            this.Controls.Add(this.lblPointsMainGame);
            this.Controls.Add(this.pcbGameOver);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmGameOver";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Over";
            ((System.ComponentModel.ISupportInitialize)(this.pcbGameOver)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblPointsMainGame;
        private System.Windows.Forms.Label lblPointsInvaders;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.PictureBox pcbGameOver;
        private System.Windows.Forms.Label lblTotalPoints;
        private System.Windows.Forms.Label lblPointsPong;
        private System.Windows.Forms.Label lblPointsDino;
    }
}