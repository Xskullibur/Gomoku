using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    class GameLogic
    {
        public DIFFICULTY cDifficulty = new DIFFICULTY();
        const int BOARD_DIMENTION = 15;
        const string PLAYER_SYMBOL = "o";
        const string COMPUTER_SYMBOL = "x";

        public GameLogic(DIFFICULTY difficulty)
        {
            cDifficulty = difficulty;
        }

        public bool winCondition(string[,] GAME_BOARD, string symbol)
        {
            /*****      Check Horizontal Victory        *****/
            for (int row = 0; row < BOARD_DIMENTION; row++)        // All Rows
            {
                for (int col = 0; col < BOARD_DIMENTION - 4; col++)   // First 6 col (Prevent Crash From col 7 onwards)
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
                for (int row = 0; row < BOARD_DIMENTION - 4; row++)  // First 6 Rows (Prevent Crash at row 7 onwards)
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
            for (int col = 0; col < BOARD_DIMENTION - 4; col++)
            {
                for (int row = 0; row < BOARD_DIMENTION - 4; row++)
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
            for (int row = BOARD_DIMENTION - 1; row > 4; row--)
            {
                for (int col = 0; col < BOARD_DIMENTION - 4; col++)
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

        // Difficulty Computer Turns
        public int[] easyBOT(string[,] GAME_BOARD)
        {
            Random random = new Random();
            int xCoords = 0, yCoords = 0;

            do
            {
                xCoords = random.Next(BOARD_DIMENTION);
                yCoords = random.Next(BOARD_DIMENTION);
            } while (GAME_BOARD[xCoords, yCoords] != null);

            return new int[] { xCoords, yCoords };
        }

        public int[] normalBOT(string[,] GAME_BOARD)
        {

            int[] coords = new int[] { -1, -1 };

            // Check 4 in a row
            coords = checkForConsecutive(GAME_BOARD, 4, PLAYER_SYMBOL);

            // Check 3 if not found
            if (coords[0] == -1 && coords[1] == -1)
                coords = checkForConsecutive(GAME_BOARD, 3, PLAYER_SYMBOL);

            // Check 2 if not found
            if (coords[0] == -1 && coords[1] == -1)
                coords = checkForConsecutive(GAME_BOARD, 2, PLAYER_SYMBOL);

            return coords.ToArray();
        }

        public int[] hardBOT(string[,] GAME_BOARD)
        {
            int[] coords = new int[] { -1, -1 };

            // Win Check(4)
            coords = checkForConsecutive(GAME_BOARD, 4, COMPUTER_SYMBOL);

            // Win Check(3)
            if (coords[0] == -1 && coords[1] == -1)
                coords = checkForConsecutive(GAME_BOARD, 3, COMPUTER_SYMBOL);

            // Block Check(4)
            if (coords[0] == -1 && coords[1] == -1)
                coords = checkForConsecutive(GAME_BOARD, 4, PLAYER_SYMBOL);

            // Block Check(3)
            if (coords[0] == -1 && coords[1] == -1)
                coords = checkForConsecutive(GAME_BOARD, 3, PLAYER_SYMBOL);

            // Win Check(2)
            if (coords[0] == -1 && coords[1] == -1)
                coords = checkForConsecutive(GAME_BOARD, 2, COMPUTER_SYMBOL);

            // Block Check(2)
            if (coords[0] == -1 && coords[1] == -1)
                coords = checkForConsecutive(GAME_BOARD, 2, PLAYER_SYMBOL);

            // Win Check(1)
            if (coords[0] == -1 && coords[1] == -1)
                coords = checkForConsecutive(GAME_BOARD, 1, PLAYER_SYMBOL);

            return coords;
        }

        // Functions
        private bool checkCurrentTurn(string symbol)
        {
            switch (symbol)
            {
                case PLAYER_SYMBOL:
                    return false;

                case COMPUTER_SYMBOL:
                    return true;

                default:
                    return false;
            }
        }

        private int[] checkForConsecutive(string[,] GAME_BOARD, int noOfConsecutive, string symbol)
        {

            bool coordsFound = false;
            List<int> coords = new List<int>();

            // Horizontal
            for (int row = 0; row < BOARD_DIMENTION; row++)
            {
                for (int col = 0; col < BOARD_DIMENTION - noOfConsecutive+1; col++)
                {

                    if (GAME_BOARD[row, col] == symbol)
                    {

                        int diesInRow = 1;

                        for (int i = 1; i < noOfConsecutive; i++)
                        {
                            if (GAME_BOARD[row, col] == GAME_BOARD[row, col + i])
                            {
                                diesInRow++;
                            }
                            else
                            {
                                break;
                            }
                        }

                        if (diesInRow == noOfConsecutive)
                        {
                            // Check front
                            if (col - 1 >= 0)
                            {
                                if (GAME_BOARD[row, col - 1] == null)
                                {
                                    coords.AddRange(new int[] { row, col - 1 });
                                    coordsFound = true;
                                    break;
                                }
                            }

                            // Check back
                            if (!coordsFound)
                            {
                                if (col + noOfConsecutive + 1 < BOARD_DIMENTION)
                                {
                                    if (GAME_BOARD[row, col + noOfConsecutive] == null) // GAME_BOARD starts from 0 thus no need for + 1
                                    {
                                        coords.AddRange(new int[] { row, col + noOfConsecutive });
                                        coordsFound = true;
                                        break;
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

            // Vertical
            if (!coordsFound)
            {
                for (int col = 0; col < BOARD_DIMENTION; col++)         // All Cols
                {
                    for (int row = 0; row < BOARD_DIMENTION - noOfConsecutive+1; row++)  // First 6 Rows (Prevent Crash at row 7 onwards)
                    {

                        if (GAME_BOARD[row, col] == symbol)         // Check Symbol
                        {

                            int diesInRow = 1;

                            for (int i = 1; i < noOfConsecutive; i++)             // Check next 4 rows
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

                            if (diesInRow == noOfConsecutive)
                            {
                                // Check front
                                if (row - 1 >= 0)
                                {
                                    if (GAME_BOARD[row - 1, col] == null)
                                    {
                                        coords.AddRange(new int[] { row - 1, col });
                                        coordsFound = true;
                                        break;
                                    }
                                }

                                // Check back
                                if (!coordsFound)
                                {
                                    if (row + noOfConsecutive + 1 < BOARD_DIMENTION)
                                    {
                                        if (GAME_BOARD[row + noOfConsecutive, col] == null)
                                        {
                                            coords.AddRange(new int[] { row + noOfConsecutive, col });
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

            // Top-Left to Bottom-Right
            if (!coordsFound)
            {
                for (int col = 0; col < BOARD_DIMENTION; col++)
                {
                    for (int row = 0; row < BOARD_DIMENTION; row++)
                    {

                        // Check if Over Board Limit
                        if (col + noOfConsecutive < BOARD_DIMENTION)
                        {
                            if (row + noOfConsecutive < BOARD_DIMENTION)
                            {
                                if (GAME_BOARD[row, col] == symbol)
                                {

                                    int diesInRow = 1;

                                    for (int i = 1; i < noOfConsecutive; i++)
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

                                    if (diesInRow == noOfConsecutive)
                                    {
                                        // Top-Left
                                        if (row - 1 >= 0 && col - 1 >= 0)
                                        {
                                            if (GAME_BOARD[row - 1, col - 1] == null)
                                            {
                                                coords.AddRange(new int[] { row - 1, col - 1 });
                                                coordsFound = true;
                                                break;
                                            }
                                        }

                                        // Bottom-Right
                                        if (!coordsFound)
                                        {
                                            if (row + noOfConsecutive < BOARD_DIMENTION && col + noOfConsecutive < BOARD_DIMENTION)
                                            {
                                                if (GAME_BOARD[row + noOfConsecutive, col + noOfConsecutive] == null)
                                                {
                                                    coords.AddRange(new int[] { row + noOfConsecutive, col + noOfConsecutive });
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

            // Bottom-Left to Top-Right
            if (!coordsFound)
            {
                for (int row = BOARD_DIMENTION - 1; row >= 0; row--)                     // Row
                {

                    for (int col = 0; col < BOARD_DIMENTION; col++)
                    {
                        if (row - noOfConsecutive >= 0)
                        {
                            if (col + noOfConsecutive <= BOARD_DIMENTION)
                            {

                                if (GAME_BOARD[row, col] == symbol)
                                {

                                    int diesInRow = 1;

                                    for (int i = 1; i < noOfConsecutive; i++)
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

                                    if (diesInRow == noOfConsecutive)
                                    {

                                        // Top-Right
                                        if (row - noOfConsecutive >= 0 && col + noOfConsecutive < BOARD_DIMENTION - 1)
                                        {
                                            if (GAME_BOARD[row - noOfConsecutive, col + noOfConsecutive] == null)
                                            {
                                                coords.AddRange(new int[] { row - noOfConsecutive, col + noOfConsecutive });
                                                coordsFound = true;
                                                break;
                                            }
                                        }

                                        // Bottom-Left
                                        if (!coordsFound)
                                        {
                                            if (row + 1 < BOARD_DIMENTION - 1 && col - 1 >= 0)
                                            {
                                                if (GAME_BOARD[row + 1, col - 1] == null)
                                                {
                                                    coords.AddRange(new int[] { row + 1, col - 1 });
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
                return coords.ToArray();
            }
            else
            {
                return new int[] { -1, -1 };
            }

        }

    }
}
