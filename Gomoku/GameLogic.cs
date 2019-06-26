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
                            if (col - 1 >= 0)
                            {
                                if (GAME_BOARD[row, col - 1] == null)
                                {
                                    sRow = row;
                                    sCol = col - 1;
                                    coordsFound = true;
                                    break;
                                }
                            }

                            // Check back
                            if (col + 3 < BOARD_DIMENTION)
                            {
                                if (GAME_BOARD[row, col + 2] == null)
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
                for (int row = BOARD_DIMENTION - 1; row >= 0; row--)                     // Row
                {

                    for (int col = 0; col < BOARD_DIMENTION - 1; col++)
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
                                        if (row - 2 >= 0 && col + 2 <= BOARD_DIMENTION - 1)
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
                                            if (row + 1 <= BOARD_DIMENTION - 1 && col - 1 >= 0)
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

        public int[] hardBOT(string[,] GAME_BOARD)
        {
            return new int[] { };
        }


    }
}
