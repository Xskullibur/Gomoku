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

        const int BOARD_DIMENTION = 15;

        const string PLAYER_DIE = "black_die.png";
        const string PLAYER_SYMBOL = "o";

        const string COMPUTER_DIE = "white_die.png";
        const string COMPUTER_SYMBOL = "x";

        string[,] GAME_BOARD = new string[BOARD_DIMENTION, BOARD_DIMENTION];

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
        
        // Check Win Condition
        public bool winCondition(string symbol)
        {

            /*****      Check Horizontal Victory        *****/
            for (int row = 0; row < BOARD_DIMENTION; row++)        // All Rows
            {
                for (int col = 0; col < BOARD_DIMENTION-4; col++)   // First 6 col (Prevent Crash From col 7 onwards)
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
            for (int col = 0; col < BOARD_DIMENTION; col++)         // All Cols
            {
                for (int row = 0; row < BOARD_DIMENTION-4; row++)  // First 6 Rows (Prevent Crash at row 7 onwards)
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
            for (int col = 0; col < BOARD_DIMENTION-4; col++)
            {
                for (int row = 0; row < BOARD_DIMENTION-4; row++)
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
            for (int row = BOARD_DIMENTION-1; row > 4; row--)
            {
                for (int col = 0; col < BOARD_DIMENTION-4; col++)
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

        // Difficulty Computer Turns
        private int[] easyBOT()
        {
            Random random = new Random();
            int xCoords = 0, yCoords = 0;

            do
            {
                xCoords = random.Next(BOARD_DIMENTION);
                yCoords = random.Next(BOARD_DIMENTION);
            } while (GAME_BOARD[xCoords, yCoords] != null);

            return new int[]{xCoords, yCoords};
        }

        private int[] normalBOT()
        {

            bool coordsFound = false;
            int sRow = 0;
            int sCol = 0;

            /*****      Check Horizontal Victory        *****/
            for (int row = 0; row < BOARD_DIMENTION; row++)        // All Rows
            {
                for (int col = 0; col < BOARD_DIMENTION - 2; col++)   // First 6 col (Prevent Crash From col 7 onwards)
                {

                    if (GAME_BOARD[row, col] == PLAYER_SYMBOL)         // Check for symbol
                    {

                        int diesInRow = 0;

                        for (int i = 1; i < 2; i++)             // Check Next 4 Col
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

                        if (diesInRow == 1)
                        {
                            // Check front
                            if (col-1 >= 0)
                            {
                                if (GAME_BOARD[row, col-1] == null)
                                {
                                    sRow = row;
                                    sCol = col - 1;
                                    coordsFound = true;
                                    break;
                                }
                            }

                            // Check back
                            if (col+3 < BOARD_DIMENTION)
                            {
                                if (GAME_BOARD[row, col+2] == null)
                                {
                                    sRow = row;
                                    sCol = col + 2;
                                    coordsFound = true;
                                    break;
                                }
                            }
                        }

                    }

                }

                if (coordsFound)
                {
                    break;
                }

            }

            /*****      Check Vertical Victory          *****/
            if (!coordsFound)
            {
                for (int col = 0; col < BOARD_DIMENTION; col++)         // All Cols
                {
                    for (int row = 0; row < BOARD_DIMENTION - 2; row++)  // First 6 Rows (Prevent Crash at row 7 onwards)
                    {

                        if (GAME_BOARD[row, col] == PLAYER_SYMBOL)         // Check Symbol
                        {

                            int diesInRow = 0;

                            for (int i = 1; i < 2; i++)             // Check next 4 rows
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

                            if (diesInRow == 1)
                            {
                                // Check front
                                if (row - 1 >= 0)
                                {
                                    if (GAME_BOARD[row - 1, col] == null)
                                    {
                                        sRow = row - 1;
                                        sCol = col;
                                        coordsFound = true;
                                        break;
                                    }
                                }

                                // Check back
                                if (row + 3 < BOARD_DIMENTION)
                                {
                                    if (GAME_BOARD[row + 2, col] == null)
                                    {
                                        sRow = row + 2;
                                        sCol = col;
                                        coordsFound = true;
                                        break;
                                    }
                                }
                            }
                        }

                    }
                }
            }

            /*****      Check Top-Left Diagonal Victory          *****/
            if (!coordsFound)
            {
                for (int col = 0; col < BOARD_DIMENTION; col++)
                {
                    for (int row = 0; row < BOARD_DIMENTION; row++)
                    {

                        // Check if Over Board Limit
                        if (col + 2 <= BOARD_DIMENTION - 1)
                        {
                            if (row + 2 <= BOARD_DIMENTION - 1)
                            {
                                if (GAME_BOARD[row, col] == PLAYER_SYMBOL)
                                {

                                    int diesInRow = 0;

                                    for (int i = 1; i < 2; i++)
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

                                    if (diesInRow == 1)
                                    {
                                        // Top-Left
                                        if (row - 1 >= 0 && col - 1 >= 0)
                                        {
                                            if (GAME_BOARD[row - 1, col - 1] == null)
                                            {
                                                sRow = row - 1;
                                                sCol = col - 1;
                                                coordsFound = true;
                                                break;
                                            }
                                        }

                                        // Bottom-Right
                                        if (!coordsFound)
                                        {
                                            if (row + 2 < BOARD_DIMENTION && col + 2 < BOARD_DIMENTION)
                                            {
                                                if (GAME_BOARD[row + 2, col + 2] == null)
                                                {
                                                    sRow = row + 2;
                                                    sCol = col + 2;
                                                    coordsFound = true;
                                                    break;
                                                }
                                            } 
                                        }
                                    }

                                }
                            }
                        }

                    }

                    if (coordsFound)
                    {
                        break;
                    }

                }
            }

            ///*****      Check Bottom-Left Diagonal Victory          *****/
            if (!coordsFound)
            {
                for (int row = BOARD_DIMENTION-1; row >= 0; row--)                     // Row
                {

                    for (int col = 0; col < BOARD_DIMENTION-1; col++)
                    {
                        if (row - 2 >= 0)
                        {
                            if (col + 2 <= BOARD_DIMENTION)
                            {

                                if (GAME_BOARD[row, col] == PLAYER_SYMBOL)
                                {

                                    int diesInRow = 0;

                                    for (int i = 1; i < 2; i++)
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

                                    if (diesInRow == 1)
                                    {

                                        // Top-Right
                                        if (row - 2 >= 0 && col + 2 <= BOARD_DIMENTION-1)
                                        {
                                            if (GAME_BOARD[row - 2, col + 2] == null)
                                            {
                                                sRow = row - 2;
                                                sCol = col + 2;
                                                coordsFound = true;
                                                break;
                                            }
                                        }

                                        // Bottom-Left
                                        if (!coordsFound)
                                        {
                                            if (row + 1 <= BOARD_DIMENTION-1 && col - 1 >= 0)
                                            {
                                                if (GAME_BOARD[row + 1, col - 1] == null)
                                                {
                                                    sRow = row + 1;
                                                    sCol = col - 1;

                                                    coordsFound = true;
                                                    break;
                                                }
                                            }
                                        }

                                    }

                                }

                            }
                        }
                    }

                    if (coordsFound)
                    {
                        break;
                    }

                }
            }


            if (coordsFound)
            {
                return new int[] { sRow, sCol };
            }
            else
            {
                return new int[] { -1, -1 };
            }

        }

        private int[] hardBOT()
        {
            return new int[] { };
        }

        // Computer's Turn
        private void computer_turn()
        {
            List<int> coords = new List<int>();

            switch (cDifficulty)
            {
                case DIFFICULTY.EASY:
                    coords = easyBOT().ToList();
                    break;

                case DIFFICULTY.NORMAL:
                    coords = normalBOT().ToList();

                    if (coords[0] == -1 && coords[1] == -1)
                    {
                        coords = easyBOT().ToList();
                    }

                    break;

                case DIFFICULTY.HARD:
                    break;

                default:
                    break;
            }

            Console.WriteLine($"{coords.ElementAt(0)}, {coords.ElementAt(1)}");

            GAME_BOARD[coords.ElementAt(0), coords.ElementAt(1)] = COMPUTER_SYMBOL;

            Button btn = (Button)gamePanel.Controls.Find($"{coords.ElementAt(0)}-{coords.ElementAt(1)}_btn", true).First();
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
