using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    class Scoreboard
    {
        string scoreFolder = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory().ToString()).ToString()) + "\\score";

        string highscoreFile;
        string defaultScoreTxt = "Highscore: 0";
        int maxScore = 113;

        public Scoreboard()
        {
            highscoreFile = $"{scoreFolder}//highscore.txt";

            if (!File.Exists(highscoreFile))
            {
                File.WriteAllText(highscoreFile, defaultScoreTxt);
            }
        }

        public void updateRecords(int turns, DIFFICULTY cDifficulty)
        {
            switch (cDifficulty)
            {
                case DIFFICULTY.EASY:

                    break;

                case DIFFICULTY.NORMAL:

                    break;

                case DIFFICULTY.HARD:

                    break;
            }
        }
    }
}
