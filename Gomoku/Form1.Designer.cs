namespace Gomoku
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.gamePanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.miminiseBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.turnLbl = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.newGameToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.easyDifficultyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalDifficultyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hardDifficultyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newGameContextStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.easyDifficultyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.normalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuContextStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.exitContextStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.gamePanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gamePanel);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1139, 637);
            this.panel1.TabIndex = 2;
            // 
            // gamePanel
            // 
            this.gamePanel.AutoScroll = true;
            this.gamePanel.BackColor = System.Drawing.Color.BurlyWood;
            this.gamePanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gamePanel.BackgroundImage")));
            this.gamePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.gamePanel.Controls.Add(this.panel2);
            this.gamePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gamePanel.Location = new System.Drawing.Point(0, 41);
            this.gamePanel.Name = "gamePanel";
            this.gamePanel.Size = new System.Drawing.Size(1139, 596);
            this.gamePanel.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.miminiseBtn);
            this.panel2.Controls.Add(this.exitBtn);
            this.panel2.Controls.Add(this.turnLbl);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1139, 79);
            this.panel2.TabIndex = 1;
            // 
            // miminiseBtn
            // 
            this.miminiseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.miminiseBtn.BackColor = System.Drawing.Color.Teal;
            this.miminiseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.miminiseBtn.Font = new System.Drawing.Font("Kristen ITC", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.miminiseBtn.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.miminiseBtn.Location = new System.Drawing.Point(1041, 12);
            this.miminiseBtn.Name = "miminiseBtn";
            this.miminiseBtn.Size = new System.Drawing.Size(40, 40);
            this.miminiseBtn.TabIndex = 14;
            this.miminiseBtn.TabStop = false;
            this.miminiseBtn.Text = "_";
            this.miminiseBtn.UseVisualStyleBackColor = false;
            this.miminiseBtn.Click += new System.EventHandler(this.miminiseBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exitBtn.BackColor = System.Drawing.Color.Red;
            this.exitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.exitBtn.Font = new System.Drawing.Font("Kristen ITC", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitBtn.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.exitBtn.Location = new System.Drawing.Point(1087, 12);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(40, 40);
            this.exitBtn.TabIndex = 11;
            this.exitBtn.TabStop = false;
            this.exitBtn.Text = "X";
            this.exitBtn.UseVisualStyleBackColor = false;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // turnLbl
            // 
            this.turnLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.turnLbl.BackColor = System.Drawing.Color.Transparent;
            this.turnLbl.Font = new System.Drawing.Font("Kristen ITC", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.turnLbl.Location = new System.Drawing.Point(12, 12);
            this.turnLbl.Name = "turnLbl";
            this.turnLbl.Size = new System.Drawing.Size(1115, 56);
            this.turnLbl.TabIndex = 1;
            this.turnLbl.Text = "Turn: 0";
            this.turnLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.MediumPurple;
            this.menuStrip1.Font = new System.Drawing.Font("Kristen ITC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem1,
            this.menuToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1139, 41);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // newGameToolStripMenuItem1
            // 
            this.newGameToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.easyDifficultyToolStripMenuItem,
            this.normalDifficultyToolStripMenuItem,
            this.hardDifficultyToolStripMenuItem});
            this.newGameToolStripMenuItem1.Name = "newGameToolStripMenuItem1";
            this.newGameToolStripMenuItem1.Size = new System.Drawing.Size(153, 37);
            this.newGameToolStripMenuItem1.Text = "New Game";
            // 
            // easyDifficultyToolStripMenuItem
            // 
            this.easyDifficultyToolStripMenuItem.Font = new System.Drawing.Font("Kristen ITC", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.easyDifficultyToolStripMenuItem.Name = "easyDifficultyToolStripMenuItem";
            this.easyDifficultyToolStripMenuItem.Size = new System.Drawing.Size(274, 32);
            this.easyDifficultyToolStripMenuItem.Text = "Easy Difficulty";
            this.easyDifficultyToolStripMenuItem.Click += new System.EventHandler(this.newEasyGameMenu_Click);
            // 
            // normalDifficultyToolStripMenuItem
            // 
            this.normalDifficultyToolStripMenuItem.Font = new System.Drawing.Font("Kristen ITC", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.normalDifficultyToolStripMenuItem.Name = "normalDifficultyToolStripMenuItem";
            this.normalDifficultyToolStripMenuItem.Size = new System.Drawing.Size(274, 32);
            this.normalDifficultyToolStripMenuItem.Text = "Normal Difficulty";
            this.normalDifficultyToolStripMenuItem.Click += new System.EventHandler(this.newNormalGameMenu_Click);
            // 
            // hardDifficultyToolStripMenuItem
            // 
            this.hardDifficultyToolStripMenuItem.Font = new System.Drawing.Font("Kristen ITC", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hardDifficultyToolStripMenuItem.Name = "hardDifficultyToolStripMenuItem";
            this.hardDifficultyToolStripMenuItem.Size = new System.Drawing.Size(274, 32);
            this.hardDifficultyToolStripMenuItem.Text = "Hard Difficulty";
            this.hardDifficultyToolStripMenuItem.Click += new System.EventHandler(this.newHardGameMenu_Click);
            // 
            // menuToolStripMenuItem1
            // 
            this.menuToolStripMenuItem1.Name = "menuToolStripMenuItem1";
            this.menuToolStripMenuItem1.Size = new System.Drawing.Size(95, 37);
            this.menuToolStripMenuItem1.Text = "Menu";
            this.menuToolStripMenuItem1.Click += new System.EventHandler(this.showMenu_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameContextStrip,
            this.menuContextStrip,
            this.exitContextStrip});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(241, 127);
            // 
            // newGameContextStrip
            // 
            this.newGameContextStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.easyDifficultyToolStripMenuItem1,
            this.normalToolStripMenuItem,
            this.hardToolStripMenuItem});
            this.newGameContextStrip.Name = "newGameContextStrip";
            this.newGameContextStrip.Size = new System.Drawing.Size(170, 30);
            this.newGameContextStrip.Text = "New Game";
            // 
            // easyDifficultyToolStripMenuItem1
            // 
            this.easyDifficultyToolStripMenuItem1.Name = "easyDifficultyToolStripMenuItem1";
            this.easyDifficultyToolStripMenuItem1.Size = new System.Drawing.Size(155, 30);
            this.easyDifficultyToolStripMenuItem1.Text = "Easy";
            this.easyDifficultyToolStripMenuItem1.Click += new System.EventHandler(this.newEasyGameMenu_Click);
            // 
            // normalToolStripMenuItem
            // 
            this.normalToolStripMenuItem.Name = "normalToolStripMenuItem";
            this.normalToolStripMenuItem.Size = new System.Drawing.Size(155, 30);
            this.normalToolStripMenuItem.Text = "Normal";
            this.normalToolStripMenuItem.Click += new System.EventHandler(this.newNormalGameMenu_Click);
            // 
            // hardToolStripMenuItem
            // 
            this.hardToolStripMenuItem.Name = "hardToolStripMenuItem";
            this.hardToolStripMenuItem.Size = new System.Drawing.Size(155, 30);
            this.hardToolStripMenuItem.Text = "Hard";
            this.hardToolStripMenuItem.Click += new System.EventHandler(this.newHardGameMenu_Click);
            // 
            // menuContextStrip
            // 
            this.menuContextStrip.Name = "menuContextStrip";
            this.menuContextStrip.Size = new System.Drawing.Size(240, 30);
            this.menuContextStrip.Text = "Menu";
            this.menuContextStrip.Click += new System.EventHandler(this.showMenu_Click);
            // 
            // exitContextStrip
            // 
            this.exitContextStrip.Name = "exitContextStrip";
            this.exitContextStrip.Size = new System.Drawing.Size(170, 30);
            this.exitContextStrip.Text = "Exit";
            this.exitContextStrip.Click += new System.EventHandler(this.exitContextStrip_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 637);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gomoku";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gamePanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Panel gamePanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button miminiseBtn;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.Label turnLbl;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newGameContextStrip;
        private System.Windows.Forms.ToolStripMenuItem menuContextStrip;
        private System.Windows.Forms.ToolStripMenuItem exitContextStrip;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem easyDifficultyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normalDifficultyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hardDifficultyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem easyDifficultyToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem normalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hardToolStripMenuItem;
    }
}

