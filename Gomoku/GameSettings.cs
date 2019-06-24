﻿using System;
using System.Windows.Forms;

namespace Gomoku
{
    public enum DIFFICULTY
    {
        EASY, NORMAL, HARD
    }

    public partial class GameSettings : Form
    {

        DIFFICULTY cDifficulty = new DIFFICULTY();

        public GameSettings()
        {
            InitializeComponent();
        }

        private void GameSettings_Load(object sender, EventArgs e)
        {
            difficultyCombo.DataSource = Enum.GetValues(typeof(DIFFICULTY));
        }

        private void difficultyCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cDifficulty = (DIFFICULTY)difficultyCombo.SelectedValue;
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(cDifficulty);
            form1.ShowDialog();
            this.Close();
        }
    }
}
