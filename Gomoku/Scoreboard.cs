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
        int maxScore = 113;
        int easyScoreMultiplier = 20;
        int normalScoreMultiplier = 40;
        int hardScoreMultiplier = 60;

        public Scoreboard()
        {
            highscoreFile = $"{scoreFolder}//highscore.txt";

            if (!File.Exists(highscoreFile))
            {
                File.WriteAllText(highscoreFile, "");
            }
        }

        public int getScore(int turns, DIFFICULTY cDifficulty)
        {
            int score = maxScore - turns;

            switch (cDifficulty)
            {
                case DIFFICULTY.EASY:
                    return score * easyScoreMultiplier;

                case DIFFICULTY.NORMAL:
                    return score * normalScoreMultiplier;

                case DIFFICULTY.HARD:
                    return score * hardScoreMultiplier;

                default:
                    return 0;
            }
        }

        public void updateRecords(int turns, DIFFICULTY cDifficulty, string name)
        {
            int score = getScore(turns, cDifficulty);
            string[] scoreboard = File.ReadAllLines(highscoreFile);
            bool playerFound = false;

            for (int i = 0; i < scoreboard.Length; i++)
            {
                if (scoreboard[i].Contains(name))
                {
                    playerFound = true;
                    string[] splittedLine = scoreboard[i].Split(':');
                    score += Convert.ToInt32(splittedLine[1]);
                    scoreboard[i] = $"{splittedLine[0]}: {score}";
                    File.WriteAllLines(highscoreFile, scoreboard);
                }
            }

            if (playerFound == false)
            {
                using (StreamWriter file = new StreamWriter(highscoreFile))
                {
                    file.WriteLine($"{name}: {score}");
                }
            }
        }
    }
}
