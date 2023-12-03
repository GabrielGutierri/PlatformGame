namespace jogoN2v2._0
{
    partial class frmOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOptions));
            this.lblDifficulty = new System.Windows.Forms.Label();
            this.lblDificuldade = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.lblGameSound = new System.Windows.Forms.Label();
            this.lblGamesMusic = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSounds = new System.Windows.Forms.Button();
            this.panelSoundsOptions = new System.Windows.Forms.Panel();
            this.btnMusic = new System.Windows.Forms.Button();
            this.panelSoundsOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDifficulty
            // 
            this.lblDifficulty.AutoSize = true;
            this.lblDifficulty.BackColor = System.Drawing.Color.Transparent;
            this.lblDifficulty.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDifficulty.ForeColor = System.Drawing.Color.White;
            this.lblDifficulty.Location = new System.Drawing.Point(32, 9);
            this.lblDifficulty.Name = "lblDifficulty";
            this.lblDifficulty.Size = new System.Drawing.Size(93, 24);
            this.lblDifficulty.TabIndex = 15;
            this.lblDifficulty.Text = "Difficulty:";
            // 
            // lblDificuldade
            // 
            this.lblDificuldade.AutoSize = true;
            this.lblDificuldade.BackColor = System.Drawing.Color.Transparent;
            this.lblDificuldade.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDificuldade.ForeColor = System.Drawing.Color.White;
            this.lblDificuldade.Location = new System.Drawing.Point(215, 9);
            this.lblDificuldade.Name = "lblDificuldade";
            this.lblDificuldade.Size = new System.Drawing.Size(77, 24);
            this.lblDificuldade.TabIndex = 16;
            this.lblDificuldade.Text = "Normal";
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.DarkRed;
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(299, 7);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(31, 23);
            this.btnNext.TabIndex = 17;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            this.btnNext.MouseLeave += new System.EventHandler(this.btnNext_MouseLeave);
            this.btnNext.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnNext_MouseMove);
            // 
            // btnPrev
            // 
            this.btnPrev.BackColor = System.Drawing.Color.DarkRed;
            this.btnPrev.FlatAppearance.BorderSize = 0;
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev.ForeColor = System.Drawing.Color.White;
            this.btnPrev.Location = new System.Drawing.Point(178, 8);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(31, 23);
            this.btnPrev.TabIndex = 18;
            this.btnPrev.Text = "<";
            this.btnPrev.UseVisualStyleBackColor = false;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            this.btnPrev.MouseLeave += new System.EventHandler(this.btnPrev_MouseLeave);
            this.btnPrev.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnPrev_MouseMove);
            // 
            // lblGameSound
            // 
            this.lblGameSound.AutoSize = true;
            this.lblGameSound.BackColor = System.Drawing.Color.Transparent;
            this.lblGameSound.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameSound.ForeColor = System.Drawing.Color.White;
            this.lblGameSound.Location = new System.Drawing.Point(21, 75);
            this.lblGameSound.Name = "lblGameSound";
            this.lblGameSound.Size = new System.Drawing.Size(169, 24);
            this.lblGameSound.TabIndex = 19;
            this.lblGameSound.Text = "Game\'s Sounds: ";
            // 
            // lblGamesMusic
            // 
            this.lblGamesMusic.AutoSize = true;
            this.lblGamesMusic.BackColor = System.Drawing.Color.Transparent;
            this.lblGamesMusic.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGamesMusic.ForeColor = System.Drawing.Color.White;
            this.lblGamesMusic.Location = new System.Drawing.Point(21, 125);
            this.lblGamesMusic.Name = "lblGamesMusic";
            this.lblGamesMusic.Size = new System.Drawing.Size(153, 24);
            this.lblGamesMusic.TabIndex = 20;
            this.lblGamesMusic.Text = "Game\'s Music: ";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DarkRed;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(109, 194);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(139, 46);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.MouseLeave += new System.EventHandler(this.button3_MouseLeave);
            this.btnSave.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button3_MouseMove);
            // 
            // btnSounds
            // 
            this.btnSounds.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSounds.BackgroundImage = global::jogoN2v2._0.Properties.Resources.switch_on;
            this.btnSounds.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSounds.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSounds.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSounds.Location = new System.Drawing.Point(41, 3);
            this.btnSounds.Name = "btnSounds";
            this.btnSounds.Size = new System.Drawing.Size(64, 36);
            this.btnSounds.TabIndex = 22;
            this.btnSounds.UseVisualStyleBackColor = false;
            this.btnSounds.Click += new System.EventHandler(this.btnSons_Click);
            // 
            // panelSoundsOptions
            // 
            this.panelSoundsOptions.Controls.Add(this.btnMusic);
            this.panelSoundsOptions.Controls.Add(this.btnSounds);
            this.panelSoundsOptions.Location = new System.Drawing.Point(178, 67);
            this.panelSoundsOptions.Name = "panelSoundsOptions";
            this.panelSoundsOptions.Size = new System.Drawing.Size(151, 121);
            this.panelSoundsOptions.TabIndex = 23;
            // 
            // btnMusic
            // 
            this.btnMusic.BackColor = System.Drawing.Color.SteelBlue;
            this.btnMusic.BackgroundImage = global::jogoN2v2._0.Properties.Resources.switch_on;
            this.btnMusic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMusic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMusic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMusic.Location = new System.Drawing.Point(41, 54);
            this.btnMusic.Name = "btnMusic";
            this.btnMusic.Size = new System.Drawing.Size(64, 36);
            this.btnMusic.TabIndex = 23;
            this.btnMusic.UseVisualStyleBackColor = false;
            this.btnMusic.Click += new System.EventHandler(this.btnMusica_Click);
            // 
            // frmOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(372, 261);
            this.Controls.Add(this.panelSoundsOptions);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblGamesMusic);
            this.Controls.Add(this.lblGameSound);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.lblDificuldade);
            this.Controls.Add(this.lblDifficulty);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Options";
            this.panelSoundsOptions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDifficulty;
        private System.Windows.Forms.Label lblDificuldade;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Label lblGameSound;
        private System.Windows.Forms.Label lblGamesMusic;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSounds;
        private System.Windows.Forms.Panel panelSoundsOptions;
        private System.Windows.Forms.Button btnMusic;
    }
}