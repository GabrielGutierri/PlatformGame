namespace jogoN2v2._0
{
    partial class frmOpcoes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOpcoes));
            this.lblD = new System.Windows.Forms.Label();
            this.lblDificuldade = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRedefinir = new System.Windows.Forms.Button();
            this.btnSons = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMusica = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblD
            // 
            this.lblD.AutoSize = true;
            this.lblD.BackColor = System.Drawing.Color.Transparent;
            this.lblD.Font = new System.Drawing.Font("Monospac821 BT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblD.ForeColor = System.Drawing.Color.White;
            this.lblD.Location = new System.Drawing.Point(32, 9);
            this.lblD.Name = "lblD";
            this.lblD.Size = new System.Drawing.Size(153, 22);
            this.lblD.TabIndex = 15;
            this.lblD.Text = "Dificuldade: ";
            // 
            // lblDificuldade
            // 
            this.lblDificuldade.AutoSize = true;
            this.lblDificuldade.BackColor = System.Drawing.Color.Transparent;
            this.lblDificuldade.Font = new System.Drawing.Font("Monospac821 BT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDificuldade.ForeColor = System.Drawing.Color.White;
            this.lblDificuldade.Location = new System.Drawing.Point(215, 9);
            this.lblDificuldade.Name = "lblDificuldade";
            this.lblDificuldade.Size = new System.Drawing.Size(76, 22);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Monospac821 BT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(21, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 22);
            this.label1.TabIndex = 19;
            this.label1.Text = "Sons do jogo: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Monospac821 BT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(-3, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 22);
            this.label2.TabIndex = 20;
            this.label2.Text = "Músicas do jogo: ";
            // 
            // btnRedefinir
            // 
            this.btnRedefinir.BackColor = System.Drawing.Color.DarkRed;
            this.btnRedefinir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRedefinir.ForeColor = System.Drawing.Color.White;
            this.btnRedefinir.Location = new System.Drawing.Point(109, 194);
            this.btnRedefinir.Name = "btnRedefinir";
            this.btnRedefinir.Size = new System.Drawing.Size(139, 46);
            this.btnRedefinir.TabIndex = 21;
            this.btnRedefinir.Text = "Redefinir";
            this.btnRedefinir.UseVisualStyleBackColor = false;
            this.btnRedefinir.Click += new System.EventHandler(this.button3_Click);
            this.btnRedefinir.MouseLeave += new System.EventHandler(this.button3_MouseLeave);
            this.btnRedefinir.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button3_MouseMove);
            // 
            // btnSons
            // 
            this.btnSons.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSons.BackgroundImage = global::jogoN2v2._0.Properties.Resources.switch_on;
            this.btnSons.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSons.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSons.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSons.Location = new System.Drawing.Point(41, 3);
            this.btnSons.Name = "btnSons";
            this.btnSons.Size = new System.Drawing.Size(64, 36);
            this.btnSons.TabIndex = 22;
            this.btnSons.UseVisualStyleBackColor = false;
            this.btnSons.Click += new System.EventHandler(this.btnSons_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnMusica);
            this.panel1.Controls.Add(this.btnSons);
            this.panel1.Location = new System.Drawing.Point(178, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(151, 121);
            this.panel1.TabIndex = 23;
            // 
            // btnMusica
            // 
            this.btnMusica.BackColor = System.Drawing.Color.SteelBlue;
            this.btnMusica.BackgroundImage = global::jogoN2v2._0.Properties.Resources.switch_on;
            this.btnMusica.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMusica.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMusica.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMusica.Location = new System.Drawing.Point(41, 54);
            this.btnMusica.Name = "btnMusica";
            this.btnMusica.Size = new System.Drawing.Size(64, 36);
            this.btnMusica.TabIndex = 23;
            this.btnMusica.UseVisualStyleBackColor = false;
            this.btnMusica.Click += new System.EventHandler(this.btnMusica_Click);
            // 
            // frmOpcoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(372, 261);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnRedefinir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.lblDificuldade);
            this.Controls.Add(this.lblD);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmOpcoes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Opções";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblD;
        private System.Windows.Forms.Label lblDificuldade;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRedefinir;
        private System.Windows.Forms.Button btnSons;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnMusica;
    }
}