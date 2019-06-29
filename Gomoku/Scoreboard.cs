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

        string easyFile, normalFile, hardFile;

        string[] defaultScore = 
        {
            "Number of Wins: 0",
            "Least Number of Turns To Win: 0",
            "Highest Win Streak: 0",
            "Win Streak: false"
        };

        public Scoreboard()
        {

            easyFile = $"{scoreFolder}//easy.txt";
            normalFile = $"{scoreFolder}//normal.txt";
            hardFile = $"{scoreFolder}//hard.txt";

            if (!File.Exists(easyFile))
            {
                File.WriteAllLines(easyFile, defaultScore);
            }

            if (!File.Exists(normalFile))
            {
                File.WriteAllLines(normalFile, defaultScore);
            }

            if (!File.Exists(hardFile))
            {
                File.WriteAllLines(hardFile, defaultScore);
            }
        }

        public void updateRecords(int turns, DIFFICULTY cDifficulty)
        {
            string checkFile = "";
            string[] fileDetails = { };

            switch (cDifficulty)
            {
                case DIFFICULTY.EASY:
                    checkFile = easyFile;
                    fileDetails = File.ReadAllLines(easyFile);
                    break;

                case DIFFICULTY.NORMAL:
                    checkFile = normalFile;
                    fileDetails = File.ReadAllLines(normalFile);
                    break;

                case DIFFICULTY.HARD:
                    checkFile = hardFile;
                    fileDetails = File.ReadAllLines(hardFile);
                    break;
            }

            // Update Number of Wins
            string[] line1 = fileDetails[0].Split(':');
            int numberOfWins = Convert.ToInt32(line1[1]);

            numberOfWins++;
            fileDetails[0] = $"{line1[0]}:{numberOfWins}";

            // Least Number of Turns
            string[] line2 = fileDetails[1].Split(':');
            int noOfTurns = Convert.ToInt32(line2[1]);

            if (noOfTurns == 0 || turns < noOfTurns)
            {
                fileDetails[1] = $"{line2[0]}:{turns}";
            }

            // Winning Streaks
            string[] line3 = fileDetails[2].Split(':');
            string[] line4 = fileDetails[3].Split(':');

            int winStreakCount = Convert.ToInt32(line3[1]);
            bool isWinStreak = Convert.ToBoolean(line4[1]);

            if (isWinStreak == false)
            {
                if (winStreakCount == 0)
                {
                    winStreakCount++;
                }
                isWinStreak = true;
            }
            else
            {
                winStreakCount++;
            }

            fileDetails[2] = $"{line3[0]}:{winStreakCount}";
            fileDetails[3] = $"{line4[0]}:{isWinStreak}";

            File.WriteAllLines(checkFile, fileDetails);
        }

        public void updateLoseWinStreak(DIFFICULTY cDifficulty)
        {
            string checkFile = "";
            string[] fileDetails = { };

            switch (cDifficulty)
            {
                case DIFFICULTY.EASY:
                    checkFile = easyFile;
                    fileDetails = File.ReadAllLines(easyFile);
                    break;

                case DIFFICULTY.NORMAL:
                    checkFile = normalFile;
                    fileDetails = File.ReadAllLines(normalFile);
                    break;

                case DIFFICULTY.HARD:
                    checkFile = hardFile;
                    fileDetails = File.ReadAllLines(hardFile);
                    break;
            }

            string[] line4 = fileDetails[3].Split(':');

            bool isWinStreak = Convert.ToBoolean(line4[1]);

            if (isWinStreak == true)
            {
                isWinStreak = false;
                fileDetails[3] = $"{line4[0]}:{isWinStreak}";
                File.WriteAllLines(checkFile, fileDetails);
            }
        }

        public string readEasy()
        {
            string returnStr = "";

            string[] lines =  File.ReadAllLines(easyFile);
            for (int i = 0; i < lines.Length-1; i++)
            {
                returnStr += lines[i];
                if (i < lines.Length-1)
                {
                    returnStr += "\n";
                }
            }

            return returnStr;
        }

        public string readNormal()
        {
            string returnStr = "";

            string[] lines = File.ReadAllLines(normalFile);
            for (int i = 0; i < lines.Length - 1; i++)
            {
                returnStr += lines[i];
                if (i < lines.Length - 1)
                {
                    returnStr += "\n";
                }
            }

            return returnStr;
        }

        public string readHard()
        {
            string returnStr = "";

            string[] lines = File.ReadAllLines(hardFile);
            for (int i = 0; i < lines.Length - 1; i++)
            {
                returnStr += lines[i];
                if (i < lines.Length - 1)
                {
                    returnStr += "\n";
                }
            }

            return returnStr;
        }
    }
}
