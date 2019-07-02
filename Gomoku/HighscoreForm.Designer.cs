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
            this.userRankingLbl = new System.Windows.Forms.Label();
            this.rankingList = new System.Windows.Forms.ListView();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPanel.BackColor = System.Drawing.Color.Transparent;
            this.mainPanel.Controls.Add(this.rankingList);
            this.mainPanel.Controls.Add(this.userRankingLbl);
            this.mainPanel.Location = new System.Drawing.Point(12, 12);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(378, 603);
            this.mainPanel.TabIndex = 16;
            // 
            // userRankingLbl
            // 
            this.userRankingLbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.userRankingLbl.Font = new System.Drawing.Font("Kristen ITC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userRankingLbl.Location = new System.Drawing.Point(0, 0);
            this.userRankingLbl.Name = "userRankingLbl";
            this.userRankingLbl.Size = new System.Drawing.Size(378, 50);
            this.userRankingLbl.TabIndex = 0;
            this.userRankingLbl.Text = "label1";
            this.userRankingLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rankingList
            // 
            this.rankingList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rankingList.Font = new System.Drawing.Font("Kristen ITC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rankingList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.rankingList.Location = new System.Drawing.Point(0, 50);
            this.rankingList.Name = "rankingList";
            this.rankingList.Size = new System.Drawing.Size(378, 553);
            this.rankingList.TabIndex = 1;
            this.rankingList.UseCompatibleStateImageBehavior = false;
            this.rankingList.View = System.Windows.Forms.View.List;
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
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label userRankingLbl;
        private System.Windows.Forms.ListView rankingList;
    }
}