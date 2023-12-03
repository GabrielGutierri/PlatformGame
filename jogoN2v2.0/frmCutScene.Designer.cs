namespace jogoN2v2._0
{
    partial class frmCutScene
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCutScene));
            this.wmpMedia = new AxWMPLib.AxWindowsMediaPlayer();
            this.btnSkip = new System.Windows.Forms.Button();
            this.timerCutScene = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.wmpMedia)).BeginInit();
            this.SuspendLayout();
            // 
            // wmpMedia
            // 
            this.wmpMedia.Enabled = true;
            this.wmpMedia.Location = new System.Drawing.Point(-1, 1);
            this.wmpMedia.Name = "wmpMedia";
            this.wmpMedia.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("wmpMedia.OcxState")));
            this.wmpMedia.Size = new System.Drawing.Size(775, 392);
            this.wmpMedia.TabIndex = 0;
            // 
            // btnSkip
            // 
            this.btnSkip.BackColor = System.Drawing.Color.Black;
            this.btnSkip.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSkip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSkip.ForeColor = System.Drawing.Color.White;
            this.btnSkip.Location = new System.Drawing.Point(675, 346);
            this.btnSkip.Name = "btnSkip";
            this.btnSkip.Size = new System.Drawing.Size(99, 47);
            this.btnSkip.TabIndex = 1;
            this.btnSkip.Text = "Skip";
            this.btnSkip.UseVisualStyleBackColor = false;
            this.btnSkip.Click += new System.EventHandler(this.btnSkip_Click);
            this.btnSkip.MouseLeave += new System.EventHandler(this.btnSkip_MouseLeave);
            this.btnSkip.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSkip_MouseMove);
            // 
            // timerCutScene
            // 
            this.timerCutScene.Interval = 1000;
            this.timerCutScene.Tick += new System.EventHandler(this.timerCutScene_Tick);
            // 
            // frmCutScene
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 393);
            this.Controls.Add(this.btnSkip);
            this.Controls.Add(this.wmpMedia);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCutScene";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCutScene";
            this.Load += new System.EventHandler(this.frmCutScene_Load);
            ((System.ComponentModel.ISupportInitialize)(this.wmpMedia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer wmpMedia;
        private System.Windows.Forms.Button btnSkip;
        private System.Windows.Forms.Timer timerCutScene;
    }
}