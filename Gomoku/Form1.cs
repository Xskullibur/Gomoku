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
    public partial class Form1 : Form
    {
        // Game Logic Class
        GameLogic GameLogic;

        // Img Folder Path
        string IMAGE_PATH = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory().ToString()).ToString()) + "\\img";

        // Dimention of board
        const int BOARD_DIMENTION = 15;

        // Names Image
        string PLAYER_DIE, COMPUTER_DIE;

        // Symbol Representing Users
        const string PLAYER_SYMBOL = "o";
        const string COMPUTER_SYMBOL = "x";

        // Turn Number
        string turnStr = "Turn: ";
        int turnNumber = 0;

        string[,] GAME_BOARD = new string[BOARD_DIMENTION, BOARD_DIMENTION];

        public Form1(DIFFICULTY difficulty)
        {
            InitializeComponent();

            PLAYER_DIE = $"{IMAGE_PATH}\\black_die.png";
            COMPUTER_DIE = $"{IMAGE_PATH}\\white_die.png";

            GameLogic = new GameLogic(difficulty);
            generateBoard();
        }

        /**
         *      Board Functions
         **/

        // Get Coords From Btn Name
        private int[] getCoords(string btnName)
        {
            string[] splitedName = btnName.Split('_')[0].Split('-');
            return new int[] { Convert.ToInt32(splitedName[0]), Convert.ToInt32(splitedName[1]) };
        }


        // Button Events
        bool btnClicked = false;

        private void button_click(object sender, EventArgs e)
        {
            // Update Turn
            turnNumber++;
            turnLbl.Text = turnStr + turnNumber;

            Button btn = (Button)sender;
            btnClicked = true;

            // Get Selected Coords
            int[] coords = getCoords(btn.Name);
            int row = coords[0], column = coords[1];

            // Update GAME_BOARD based on coords
            GAME_BOARD[row, column] = PLAYER_SYMBOL;

            // Update Selected Btn
            btn.BackgroundImage = Image.FromFile(PLAYER_DIE);
            btn.BackgroundImageLayout = ImageLayout.Stretch;
            btn.Enabled = false;

            // Check Victory
            if (GameLogic.winCondition(GAME_BOARD, PLAYER_SYMBOL))
            {
                victoryForm victoryForm = new victoryForm(victoryForm.users.player, this);
                victoryForm.ShowDialog();
            }
            else
            {
                computer_turn();
            }
        }

        private void button_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            btn.BackgroundImage = Image.FromFile(PLAYER_DIE);
            btn.BackgroundImageLayout = ImageLayout.Stretch;

            btn.Cursor = Cursors.Hand;
        }

        private void button_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            btn.Cursor = Cursors.Default;

            if (btnClicked)
            {
                btnClicked = false;
            }
            else
            {
                btn.BackgroundImage = null;
            }
        }


        // Game Actions
        public void generateBoard()         
        {
            int startX = 60;
            int startY = gamePanel.Width / 2;
            int btnHeight = 35;
            int btnWidth = 35;
            int dist = 10;

            for (int x = 0; x < BOARD_DIMENTION; x++)
            {
                for (int y = 0; y < BOARD_DIMENTION; y++)
                {
                    // Properties
                    Button btn = new Button();
                    btn.BackColor = Color.Beige
;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.Name = $"{x}-{y}_btn";
                    btn.TabStop = false;

                    // Events
                    btn.Click += button_click;
                    btn.MouseEnter += button_MouseEnter;
                    btn.MouseLeave += button_MouseLeave;

                    btn.Top = startX + (x * btnHeight + dist);
                    btn.Left = startY + (y * btnWidth + dist);

                    btn.Width = btnWidth;
                    btn.Height = btnHeight;

                    gamePanel.Controls.Add(btn);
                }
            }
        }


        public void reset_board()
        {
            foreach (Control control in gamePanel.Controls)
            {
                control.BackgroundImage = null;
                control.Enabled = true;
            }

            for (int col = 0; col < BOARD_DIMENTION-1; col++)
            {
                for (int row = 0; row < BOARD_DIMENTION-1; row++)
                {
                    GAME_BOARD[row, col] = "";
                }
            }

            turnNumber = 0;
            turnLbl.Text = turnStr + turnNumber;
        }

        private void computer_turn()
        {
            List<int> coords = new List<int>();

            // Identify next move based on difficulty
            switch (GameLogic.cDifficulty)
            {
                // Place DIE Randomly
                case DIFFICULTY.EASY:
                    coords = GameLogic.easyBOT(GAME_BOARD).ToList();
                    break;

                // Block Player - Random
                case DIFFICULTY.NORMAL:
                    coords = GameLogic.normalBOT(GAME_BOARD).ToList();

                    // Use EASY BOT if there is nothing to block
                    if (coords[0] == -1 && coords[1] == -1)
                        coords = GameLogic.easyBOT(GAME_BOARD).ToList();

                    break;

                case DIFFICULTY.HARD:
                    coords = GameLogic.hardBOT(GAME_BOARD).ToList();

                    // Use EASY BOT if there is nothing to block
                    if (coords[0] == -1 && coords[1] == -1)
                        coords = GameLogic.easyBOT(GAME_BOARD).ToList();
                    break;

                default:
                    break;
            }

            // Update GAME_BOARD
            GAME_BOARD[coords.ElementAt(0), coords.ElementAt(1)] = COMPUTER_SYMBOL;

            // Update Btn UI
            Button btn = (Button)gamePanel.Controls.Find($"{coords.ElementAt(0)}-{coords.ElementAt(1)}_btn", true).First();
            btn.BackgroundImage = Image.FromFile(COMPUTER_DIE);
            btn.BackgroundImageLayout = ImageLayout.Stretch;
            btn.Enabled = false;

            // Check Win Condition
            if (GameLogic.winCondition(GAME_BOARD, COMPUTER_SYMBOL))
            {
                victoryForm victoryForm = new victoryForm(victoryForm.users.computer, this);
                victoryForm.ShowDialog();
            }
        }


        /**
         *      Menu Actions
         **/
        
        private void showMenu()
        {
            this.Hide();
            GameSettings gameSettings = new GameSettings();
            gameSettings.ShowDialog();
            this.Close();
        }


        // Toolbar (Toolbar Menu) Actions
        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reset_board();
        }

        private void menuToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            showMenu();
        }


        // Context Strip (Right Click Menu) Actions
        private void newGameContextStrip_Click(object sender, EventArgs e)
        {
            reset_board();
        }

        private void menuContextStrip_Click(object sender, EventArgs e)
        {
            showMenu();
        }

        private void exitContextStrip_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        //Button Actions
        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void miminiseBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
