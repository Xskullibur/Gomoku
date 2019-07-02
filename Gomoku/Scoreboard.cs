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

        Users currentUser;

        string highscoreFile;
        int maxScore = 113;
        int easyScoreMultiplier = 20;
        int normalScoreMultiplier = 40;
        int hardScoreMultiplier = 60;

        public Scoreboard(Users user)
        {
            highscoreFile = $"{scoreFolder}//highscore.txt";
            currentUser = user;

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
            List<string> scoreboard = File.ReadAllLines(highscoreFile).ToList();
            bool playerFound = false;

            for (int i = 0; i < scoreboard.Count; i++)
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
                scoreboard.Add($"{currentUser.playerName}: {score}");
                File.WriteAllLines(highscoreFile, scoreboard);
            }
        }
    }
}
