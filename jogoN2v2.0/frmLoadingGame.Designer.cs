namespace jogoN2v2._0
{
    partial class frmLoadingGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoadingGame));
            this.pnlLoadingScreenContainer = new System.Windows.Forms.Panel();
            this.pnlLoadingScreen = new System.Windows.Forms.Panel();
            this.timerLoadingScreen = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlLoadingScreenContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLoadingScreenContainer
            // 
            this.pnlLoadingScreenContainer.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pnlLoadingScreenContainer.Controls.Add(this.pnlLoadingScreen);
            this.pnlLoadingScreenContainer.Location = new System.Drawing.Point(-2, 312);
            this.pnlLoadingScreenContainer.Name = "pnlLoadingScreenContainer";
            this.pnlLoadingScreenContainer.Size = new System.Drawing.Size(536, 11);
            this.pnlLoadingScreenContainer.TabIndex = 1;
            // 
            // pnlLoadingScreen
            // 
            this.pnlLoadingScreen.BackColor = System.Drawing.Color.White;
            this.pnlLoadingScreen.Location = new System.Drawing.Point(3, 3);
            this.pnlLoadingScreen.Name = "pnlLoadingScreen";
            this.pnlLoadingScreen.Size = new System.Drawing.Size(21, 10);
            this.pnlLoadingScreen.TabIndex = 2;
            // 
            // timerLoadingScreen
            // 
            this.timerLoadingScreen.Tick += new System.EventHandler(this.timerScreen_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::jogoN2v2._0.Properties.Resources.intro1;
            this.pictureBox1.Location = new System.Drawing.Point(-2, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(536, 346);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // frmLoadingGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 326);
            this.Controls.Add(this.pnlLoadingScreenContainer);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLoadingGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLoadingGame";
            this.pnlLoadingScreenContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlLoadingScreenContainer;
        private System.Windows.Forms.Panel pnlLoadingScreen;
        private System.Windows.Forms.Timer timerLoadingScreen;
    }
}