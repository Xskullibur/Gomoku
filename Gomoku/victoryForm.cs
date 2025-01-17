﻿using System;
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
        public enum PLAYER
        {
            player,
            computer
        }

        const string computerName = "Computer";
        DIFFICULTY cDifficulty;

        bool viewBoard = false;

        Scoreboard scoreboard;
        Users currentUser;
        SoundPlayer victorySound = new SoundPlayer(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory().ToString()).ToString()) + "\\sounds\\Victory.wav");
        SoundPlayer failureSound = new SoundPlayer(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory().ToString()).ToString()) + "\\sounds\\Failure.wav");
        Form1 form;

        public victoryForm(PLAYER player, int turns, DIFFICULTY difficulty, Form1 currentForm, Users user)
        {
            InitializeComponent();
            form = currentForm;
            cDifficulty = difficulty;
            currentUser = user;
            scoreboard = new Scoreboard(currentUser);

            switch (player)
            {
                case PLAYER.player:
                    victoryLbl.Text = $"{currentUser.playerName}'s {victoryLbl.Text}";
                    scoreboard.updateRecords(turns, difficulty, currentUser.playerName);
                    victorySound.Play();
                    break;
                case PLAYER.computer:
                    victoryLbl.Text = $"{computerName}'s {victoryLbl.Text}";
                    nxtLvlBtn.BackColor = Color.FromArgb(150, Color.Violet);
                    nxtLvlBtn.Enabled = false;
                    failureSound.Play();
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
            GameSettings gameSettings = new GameSettings(currentUser);
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

        private void viewBoardBtn_MouseDown(object sender, MouseEventArgs e)
        {
            if (viewBoard == false)
            {
                this.Opacity = .05;
                viewBoard = true;
            }
        }

        private void viewBoardBtn_MouseUp(object sender, MouseEventArgs e)
        {
            if (viewBoard == true)
            {
                this.Opacity = 1;
                viewBoard = false;
            }
        }
    }
}
