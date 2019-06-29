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
    public partial class victoryForm : Form
    {
        public enum users
        {
            player,
            computer
        }

        const string playerName = "Player";
        const string computerName = "Computer";
        Form1 form;

        public victoryForm(users users, int turns, Form1 currentForm)
        {
            InitializeComponent();
            form = currentForm;

            switch (users)
            {
                case users.player:
                    victoryLbl.Text = $"{playerName} {victoryLbl.Text}";
                    break;
                case users.computer:
                    victoryLbl.Text = $"{computerName} {victoryLbl.Text}";
                    break;
                default:
                    victoryLbl.Text = "Victory!";
                    break;
            }

            turnLbl.Text = $"Turns: {turns}";
        }

        private void newGameBtn_Click(object sender, EventArgs e)
        {
            form.reset_board();
            this.Close();
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
    }
}
