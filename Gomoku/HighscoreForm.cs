using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gomoku
{
    public partial class HighscoreForm : Form
    {
        public HighscoreForm(Users user)
        {
            InitializeComponent();

            int panelHeight = mainPanel.Height / 3;

            Scoreboard scoreboard = new Scoreboard(user);
            userRankingLbl.Text = scoreboard.getUserScore();

            string[] highscore = scoreboard.getAllHighscore().ToArray();

            for (int i = 0; i < highscore.Length; i++)
            {
                rankingList.Items.Add(highscore[i]);

                if (i == 0 || i == 1 || i == 2)
                {

                    if (i == 0)
                    {
                        rankingList.Items[i].ForeColor = Color.Gold;
                    }
                    else if (i == 1)
                    {
                        rankingList.Items[i].ForeColor = Color.Gray;
                    }
                    else if (i == 2)
                    {
                        rankingList.Items[i].ForeColor = Color.Brown;
                    }

                }

            }

        }
    }
}
