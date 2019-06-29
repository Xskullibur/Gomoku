namespace Gomoku
{
    partial class HighscoreForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HighscoreForm));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.normalPanel = new System.Windows.Forms.Panel();
            this.normalLbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.hardPanel = new System.Windows.Forms.Panel();
            this.hardLbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.easyPanel = new System.Windows.Forms.Panel();
            this.easyLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.normalPanel.SuspendLayout();
            this.hardPanel.SuspendLayout();
            this.easyPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPanel.BackColor = System.Drawing.Color.Transparent;
            this.mainPanel.Controls.Add(this.normalPanel);
            this.mainPanel.Controls.Add(this.hardPanel);
            this.mainPanel.Controls.Add(this.easyPanel);
            this.mainPanel.Location = new System.Drawing.Point(12, 12);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(378, 603);
            this.mainPanel.TabIndex = 16;
            // 
            // normalPanel
            // 
            this.normalPanel.Controls.Add(this.normalLbl);
            this.normalPanel.Controls.Add(this.label2);
            this.normalPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.normalPanel.Location = new System.Drawing.Point(0, 206);
            this.normalPanel.Name = "normalPanel";
            this.normalPanel.Size = new System.Drawing.Size(378, 192);
            this.normalPanel.TabIndex = 1;
            // 
            // normalLbl
            // 
            this.normalLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.normalLbl.Font = new System.Drawing.Font("Kristen ITC", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.normalLbl.Location = new System.Drawing.Point(0, 43);
            this.normalLbl.Name = "normalLbl";
            this.normalLbl.Size = new System.Drawing.Size(378, 149);
            this.normalLbl.TabIndex = 2;
            this.normalLbl.Text = "label5";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Kristen ITC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.label2.Size = new System.Drawing.Size(250, 43);
            this.label2.TabIndex = 1;
            this.label2.Text = "Normal Difficulty:";
            // 
            // hardPanel
            // 
            this.hardPanel.Controls.Add(this.hardLbl);
            this.hardPanel.Controls.Add(this.label3);
            this.hardPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hardPanel.Location = new System.Drawing.Point(0, 398);
            this.hardPanel.Name = "hardPanel";
            this.hardPanel.Size = new System.Drawing.Size(378, 205);
            this.hardPanel.TabIndex = 2;
            // 
            // hardLbl
            // 
            this.hardLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hardLbl.Font = new System.Drawing.Font("Kristen ITC", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hardLbl.Location = new System.Drawing.Point(0, 43);
            this.hardLbl.Name = "hardLbl";
            this.hardLbl.Size = new System.Drawing.Size(378, 162);
            this.hardLbl.TabIndex = 2;
            this.hardLbl.Text = "label6";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Kristen ITC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.label3.Size = new System.Drawing.Size(222, 43);
            this.label3.TabIndex = 1;
            this.label3.Text = "Hard Difficulty:";
            // 
            // easyPanel
            // 
            this.easyPanel.Controls.Add(this.easyLbl);
            this.easyPanel.Controls.Add(this.label1);
            this.easyPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.easyPanel.Location = new System.Drawing.Point(0, 0);
            this.easyPanel.Name = "easyPanel";
            this.easyPanel.Size = new System.Drawing.Size(378, 206);
            this.easyPanel.TabIndex = 0;
            // 
            // easyLbl
            // 
            this.easyLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.easyLbl.Font = new System.Drawing.Font("Kristen ITC", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.easyLbl.Location = new System.Drawing.Point(0, 63);
            this.easyLbl.Name = "easyLbl";
            this.easyLbl.Size = new System.Drawing.Size(378, 143);
            this.easyLbl.TabIndex = 1;
            this.easyLbl.Text = "label4";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Kristen ITC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 20, 0, 10);
            this.label1.Size = new System.Drawing.Size(214, 63);
            this.label1.TabIndex = 0;
            this.label1.Text = "Easy Difficulty:";
            // 
            // HighscoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(403, 627);
            this.Controls.Add(this.mainPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "HighscoreForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Highscore";
            this.mainPanel.ResumeLayout(false);
            this.normalPanel.ResumeLayout(false);
            this.normalPanel.PerformLayout();
            this.hardPanel.ResumeLayout(false);
            this.hardPanel.PerformLayout();
            this.easyPanel.ResumeLayout(false);
            this.easyPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel easyPanel;
        private System.Windows.Forms.Panel hardPanel;
        private System.Windows.Forms.Panel normalPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label normalLbl;
        private System.Windows.Forms.Label hardLbl;
        private System.Windows.Forms.Label easyLbl;
    }
}