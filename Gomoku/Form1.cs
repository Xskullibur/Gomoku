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

        // Die Image Location
        string PLAYER_DIE, COMPUTER_DIE;

        // Symbol Representing Users
        const string PLAYER_SYMBOL = "o";
        const string COMPUTER_SYMBOL = "x";

        string[,] GAME_BOARD = new string[BOARD_DIMENTION, BOARD_DIMENTION];

        public Form1(DIFFICULTY difficulty)
        {
            InitializeComponent();

            PLAYER_DIE = $"{IMAGE_PATH}\\black_die.png";
            COMPUTER_DIE = $"{IMAGE_PATH}\\white_die.png";

            GameLogic = new GameLogic(difficulty);
            generateBoard();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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

        // Generate Game Board
        public void generateBoard()
        {
            int startX = 10;
            int startY = 10;
            int btnHeight = 35;
            int btnWidth = 35;
            int dist = 10;

            for (int x = 0; x < BOARD_DIMENTION; x++)
            {
                for (int y = 0; y < BOARD_DIMENTION; y++)
                {
                    Button btn = new Button();
                    btn.BackColor = Color.SandyBrown;
                    btn.Name = $"{x}-{y}_btn";
                    btn.TabStop = false;
                    btn.Click += button_click;

                    btn.Top = startX + (x * btnHeight + dist);
                    btn.Left = startY + (y * btnWidth + dist);
                    btn.Width = btnWidth;
                    btn.Height = btnHeight;

                    gamePanel.Controls.Add(btn);
                }
            }
        }

        // Reset GAME_BOARD and regen UI
        private void reset_board()
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

            this.Close();
            GameSettings gameSettings = new GameSettings();
            gameSettings.ShowDialog();
        }

        /**
         *      Main Actions
         **/

        // Player Click
        private void button_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

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
                MessageBox.Show("Player Wins!");
            }
            else
            {
                computer_turn();
            }
        }

        // Computer' Move
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
                MessageBox.Show("Computer Wins");
            }
        }

        /**
         *      Menu Actions
         **/
        private void newGame_Click(object sender, EventArgs e)
        {
            reset_board();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
