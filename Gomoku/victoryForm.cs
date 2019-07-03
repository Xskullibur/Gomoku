using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gomoku
{
    public partial class victoryForm : Form
    {
        public enum users
        {
            player,
            computer
        }

        const string playerName = "Player";
        const string computerName = "Computer";
        DIFFICULTY cDifficulty;
        Scoreboard scoreboard = new Scoreboard();
        Form1 form;

        SoundPlayer victoryPlayer = new SoundPlayer(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory().ToString()).ToString()) + "\\sound\\Victory.wav");
        SoundPlayer failurePlayer = new SoundPlayer(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory().ToString()).ToString()) + "\\sound\\Failure.wav");

        public victoryForm(users users, int turns, DIFFICULTY difficulty, Form1 currentForm)
        {
            InitializeComponent();
            form = currentForm;
            cDifficulty = difficulty;

            switch (users)
            {
                case users.player:
                    victoryLbl.Text = $"{playerName} {victoryLbl.Text}";
                    scoreboard.updateRecords(turns, difficulty, "Test Player");
                    victoryPlayer.Play();
                    break;
                case users.computer:
                    victoryLbl.Text = $"{computerName} {victoryLbl.Text}";
                    nxtLvlBtn.BackColor = Color.FromArgb(150, Color.Violet);
                    nxtLvlBtn.Enabled = false;
                    failurePlayer.Play();
                    break;
                default:
                    victoryLbl.Text = "Victory!";
                    break;
            }

            turnLbl.Text = $"Score: {scoreboard.getScore(turns, difficulty)}";

            if (difficulty == DIFFICULTY.HARD)
            {
                nxtLvlBtn.BackColor = Color.FromArgb(150, Color.Violet);
                nxtLvlBtn.Enabled = false;
            }
        }

        private void newGameBtn_Click(object sender, EventArgs e)
        {
            form.reset_board(cDifficulty, this);
        }

        private void menuBtn_Click(object sender, EventArgs e)
        {
            form.Close();
            this.Hide();
            GameSettings gameSettings = new GameSettings();
            gameSettings.ShowDialog();
            this.Close();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void nxtLvlBtn_Click(object sender, EventArgs e)
        {
            switch (cDifficulty)
            {
                case DIFFICULTY.EASY:
                    form.reset_board(DIFFICULTY.NORMAL, this);
                    this.Close();
                    break;
                case DIFFICULTY.NORMAL:
                    form.reset_board(DIFFICULTY.HARD, this);
                    break;
                default:
                    break;
            }
        }
    }
}
