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
        public DIFFICULTY cDifficulty = new DIFFICULTY();

        string IMAGE_PATH = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory().ToString()).ToString()) + "\\img";

        const int BOARD_WIDTH = 15;
        const int BOARD_HEIGHT = 15;

        const string PLAYER_DIE = "black_die.png";
        const string PLAYER_SYMBOL = "o";

        const string COMPUTER_DIE = "white_die.png";
        const string COMPUTER_SYMBOL = "x";

        string[,] GAME_BOARD = new string[BOARD_WIDTH, BOARD_HEIGHT];

        public Form1(DIFFICULTY difficulty)
        {
            InitializeComponent();
            cDifficulty = difficulty;
            generateBoard();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show($"Difficulty from Form1: {cDifficulty.ToString()}");
        }

        /**
         * Global Functions
         **/

        // Generate New Game Board
        public void generateBoard()
        {
            int startX = 10;
            int startY = 10;
            int btnHeight = 35;
            int btnWidth = 35;
            int dist = 10;

            for (int x = 0; x < BOARD_WIDTH; x++)
            {
                for (int y = 0; y < BOARD_HEIGHT; y++)
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
        
        // Check Win Condition
        public bool winCondition(string symbol)
        {

            /*****      Check Horizontal Victory        *****/
            for (int row = 0; row < BOARD_HEIGHT; row++)        // All Rows
            {
                for (int col = 0; col < BOARD_WIDTH-4; col++)   // First 6 col (Prevent Crash From col 7 onwards)
                {

                    if (GAME_BOARD[row, col] == symbol)         // Check for symbol
                    {

                        int diesInRow = 0;

                        for (int i = 1; i < 5; i++)             // Check Next 4 Col
                        {           
                            if (GAME_BOARD[row, col] == GAME_BOARD[row, col + i])
                            {
                                diesInRow++;                    // Count the number of times in a row
                            }
                            else                               
                            {
                                break;                          // Stop the loop if not in a row
                            }
                        }

                        if (diesInRow == 4)
                        {
                            return true;
                        }

                    }

                }
            }

            /*****      Check Vertical Victory          *****/
            for (int col = 0; col < BOARD_WIDTH; col++)         // All Cols
            {
                for (int row = 0; row < BOARD_HEIGHT-4; row++)  // First 6 Rows (Prevent Crash at row 7 onwards)
                {

                    if (GAME_BOARD[row, col] == symbol)         // Check Symbol
                    {

                        int diesInRow = 0;

                        for (int i = 1; i < 5; i++)             // Check next 4 rows
                        {
                            if (GAME_BOARD[row, col] == GAME_BOARD[row + i, col])
                            {
                                diesInRow++;
                            }
                            else
                            {
                                break;
                            }
                        }

                        if (diesInRow == 4)
                        {
                            return true;
                        }

                    }

                }
            }

            /*****      Check Top-Left Diagonal Victory          *****/
            for (int col = 0; col < BOARD_WIDTH-4; col++)
            {
                for (int row = 0; row < BOARD_HEIGHT-4; row++)
                {

                    if (GAME_BOARD[row, col] == symbol)
                    {

                        int diesInRow = 0;

                        for (int i = 1; i < 5; i++)
                        {
                            if (GAME_BOARD[row, col] == GAME_BOARD[row + i, col + i])
                            {
                                diesInRow++;
                            }
                            else
                            {
                                break;
                            }
                        }

                        if (diesInRow == 4)
                        {
                            return true;
                        }

                    }

                }
            }

            /*****      Check Bottom-Right Diagonal Victory          *****/
            for (int row = BOARD_HEIGHT-1; row > 4; row--)
            {
                for (int col = 0; col < BOARD_WIDTH-4; col++)
                {
                    if (GAME_BOARD[row, col] == symbol)
                    {

                        int diesInRow = 0;

                        for (int i = 1; i < 5; i++)
                        {
                            if (GAME_BOARD[row, col] == GAME_BOARD[row - i, col + i])
                            {
                                diesInRow++;
                            }
                            else
                            {
                                break;
                            }
                        }

                        if (diesInRow == 4)
                        {
                            return true;
                        }

                    }
                }
            }

            return false; 
        }

        // Reset and Generate New Game Board
        private void reset_board()
        {
            foreach (Control control in gamePanel.Controls)
            {
                control.BackgroundImage = null;
                control.Enabled = true;
            }

            for (int col = 0; col < BOARD_WIDTH-1; col++)
            {
                for (int row = 0; row < BOARD_HEIGHT-1; row++)
                {
                    GAME_BOARD[row, col] = "";
                }
            }
        }
        
        // Computer's Turn
        private void computer_turn()
        {
            Random random = new Random();
            int xCoords = 0, yCoords = 0;

            switch (cDifficulty)
            {
                case DIFFICULTY.EASY:

                    do
                    {
                        xCoords = random.Next(BOARD_WIDTH);
                        yCoords = random.Next(BOARD_HEIGHT);
                    } while (GAME_BOARD[xCoords, yCoords] != null);

                    break;

                case DIFFICULTY.NORMAL:
                    break;

                case DIFFICULTY.HARD:
                    break;

                default:
                    break;
            }

            GAME_BOARD[xCoords, yCoords] = COMPUTER_SYMBOL;

            Button btn = (Button)gamePanel.Controls.Find($"{xCoords}-{yCoords}_btn", true).First();
            btn.BackgroundImage = Image.FromFile($"{IMAGE_PATH}\\{COMPUTER_DIE}");
            btn.BackgroundImageLayout = ImageLayout.Stretch;
            btn.Enabled = false;

            if (winCondition(COMPUTER_SYMBOL))
            {
                MessageBox.Show("Computer Wins");
            }
        }

        /**
         * Main Actions
         **/

        // Player Click
        private void button_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            //Set Gameboard
            string btnPosition = btn.Name.Split('_')[0];
            int row = Convert.ToInt32(btnPosition.Split('-')[0]);
            int column = Convert.ToInt32(btnPosition.Split('-')[1]);

            //Update Gameboard
            GAME_BOARD[row, column] = PLAYER_SYMBOL;

            //Set PLAYER DIE
            btn.BackgroundImage = Image.FromFile($"{IMAGE_PATH}\\{PLAYER_DIE}");
            btn.BackgroundImageLayout = ImageLayout.Stretch;

            //Disable Btn
            btn.Enabled = false;

            if (winCondition(PLAYER_SYMBOL))
            {
                MessageBox.Show("Player Wins!");
            }
            else
            {
                computer_turn();
            }
        }

        /**
         * Menu Actions
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
