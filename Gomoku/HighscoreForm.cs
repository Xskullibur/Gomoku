using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gomoku
{
    public partial class HighscoreForm : Form
    {
        public HighscoreForm()
        {
            InitializeComponent();

            int panelHeight = mainPanel.Height / 3;
            easyPanel.Height = panelHeight;
            normalPanel.Height = panelHeight;
            hardPanel.Height = panelHeight;

            Scoreboard scoreboard = new Scoreboard();
        }
    }
}
