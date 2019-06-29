namespace Gomoku
{
    partial class victoryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(victoryForm));
            this.victoryLbl = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.exitBtn = new System.Windows.Forms.Button();
            this.turnLbl = new System.Windows.Forms.Label();
            this.menuBtn = new System.Windows.Forms.Button();
            this.newGameBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // victoryLbl
            // 
            this.victoryLbl.BackColor = System.Drawing.Color.Transparent;
            this.victoryLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.victoryLbl.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.victoryLbl.Font = new System.Drawing.Font("Kristen ITC", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.victoryLbl.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.victoryLbl.Location = new System.Drawing.Point(0, 0);
            this.victoryLbl.Name = "victoryLbl";
            this.victoryLbl.Size = new System.Drawing.Size(800, 450);
            this.victoryLbl.TabIndex = 0;
            this.victoryLbl.Text = "Victory!";
            this.victoryLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.turnLbl);
            this.panel1.Controls.Add(this.menuBtn);
            this.panel1.Controls.Add(this.newGameBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 265);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 185);
            this.panel1.TabIndex = 1;
            // 
            // exitBtn
            // 
            this.exitBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exitBtn.BackColor = System.Drawing.Color.Red;
            this.exitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.exitBtn.Font = new System.Drawing.Font("Kristen ITC", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitBtn.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.exitBtn.Location = new System.Drawing.Point(748, 12);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(40, 40);
            this.exitBtn.TabIndex = 10;
            this.exitBtn.TabStop = false;
            this.exitBtn.Text = "X";
            this.exitBtn.UseVisualStyleBackColor = false;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // turnLbl
            // 
            this.turnLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.turnLbl.Font = new System.Drawing.Font("Kristen ITC", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.turnLbl.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.turnLbl.Location = new System.Drawing.Point(17, 0);
            this.turnLbl.Name = "turnLbl";
            this.turnLbl.Size = new System.Drawing.Size(771, 44);
            this.turnLbl.TabIndex = 10;
            this.turnLbl.Text = "Score: ~";
            this.turnLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuBtn
            // 
            this.menuBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.menuBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.menuBtn.Font = new System.Drawing.Font("Kristen ITC", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuBtn.Location = new System.Drawing.Point(321, 119);
            this.menuBtn.Name = "menuBtn";
            this.menuBtn.Size = new System.Drawing.Size(158, 46);
            this.menuBtn.TabIndex = 9;
            this.menuBtn.Text = "Menu";
            this.menuBtn.UseVisualStyleBackColor = false;
            this.menuBtn.Click += new System.EventHandler(this.menuBtn_Click);
            // 
            // newGameBtn
            // 
            this.newGameBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.newGameBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.newGameBtn.Font = new System.Drawing.Font("Kristen ITC", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newGameBtn.Location = new System.Drawing.Point(321, 67);
            this.newGameBtn.Name = "newGameBtn";
            this.newGameBtn.Size = new System.Drawing.Size(158, 46);
            this.newGameBtn.TabIndex = 8;
            this.newGameBtn.Text = "New Game";
            this.newGameBtn.UseVisualStyleBackColor = false;
            this.newGameBtn.Click += new System.EventHandler(this.newGameBtn_Click);
            // 
            // victoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.victoryLbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "victoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "victoryForm";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label victoryLbl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.Label turnLbl;
        private System.Windows.Forms.Button menuBtn;
        private System.Windows.Forms.Button newGameBtn;
    }
}