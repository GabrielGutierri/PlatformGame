namespace jogoN2v2._0
{
    partial class frmCalculusInvaders
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCalculusInvaders));
            this.lblPoints = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.pcbPlayer = new System.Windows.Forms.PictureBox();
            this.lblLifes = new System.Windows.Forms.Label();
            this.lblRecord = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPoints
            // 
            this.lblPoints.AutoSize = true;
            this.lblPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoints.ForeColor = System.Drawing.SystemColors.Control;
            this.lblPoints.Location = new System.Drawing.Point(12, 528);
            this.lblPoints.Name = "lblPoints";
            this.lblPoints.Size = new System.Drawing.Size(90, 24);
            this.lblPoints.TabIndex = 1;
            this.lblPoints.Text = "Points: 0";
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.InvadersTimerEvent);
            // 
            // pcbPlayer
            // 
            this.pcbPlayer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pcbPlayer.Image = global::jogoN2v2._0.Properties.Resources.Wuo_2;
            this.pcbPlayer.Location = new System.Drawing.Point(204, 509);
            this.pcbPlayer.Name = "pcbPlayer";
            this.pcbPlayer.Size = new System.Drawing.Size(57, 43);
            this.pcbPlayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbPlayer.TabIndex = 0;
            this.pcbPlayer.TabStop = false;
            // 
            // lblLifes
            // 
            this.lblLifes.AutoSize = true;
            this.lblLifes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLifes.ForeColor = System.Drawing.SystemColors.Control;
            this.lblLifes.Location = new System.Drawing.Point(625, 9);
            this.lblLifes.Name = "lblLifes";
            this.lblLifes.Size = new System.Drawing.Size(76, 24);
            this.lblLifes.TabIndex = 2;
            this.lblLifes.Text = "Lifes: 3";
            // 
            // lblRecord
            // 
            this.lblRecord.AutoSize = true;
            this.lblRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecord.ForeColor = System.Drawing.SystemColors.Control;
            this.lblRecord.Location = new System.Drawing.Point(12, 9);
            this.lblRecord.Name = "lblRecord";
            this.lblRecord.Size = new System.Drawing.Size(141, 24);
            this.lblRecord.TabIndex = 3;
            this.lblRecord.Text = "Best Round: 0";
            // 
            // frmCalculusInvaders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(734, 561);
            this.Controls.Add(this.lblRecord);
            this.Controls.Add(this.lblLifes);
            this.Controls.Add(this.lblPoints);
            this.Controls.Add(this.pcbPlayer);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCalculusInvaders";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculus Invaders";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.pcbPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pcbPlayer;
        private System.Windows.Forms.Label lblPoints;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label lblLifes;
        private System.Windows.Forms.Label lblRecord;
    }
}
