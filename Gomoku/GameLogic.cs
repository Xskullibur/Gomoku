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

        string IMAGE_PATH = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory().ToString()).ToString()) + "\\img";

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


    }
}
