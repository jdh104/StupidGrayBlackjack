//ClassMaster: Dakota

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StupidBlackjackSln.Code
{
    class AchievementMonitor
    {
        private static AchievementMonitor instance = null;
        private List<Achievement> achievements = null;
        private int winCount = 0;

        private AchievementMonitor()
        {
            achievements = new List<Achievement>();
        }

        public static AchievementMonitor getInstance()
        {
            if (instance == null)
            {
                instance = new AchievementMonitor();
            }
            return instance;
        }

        public List<Achievement> getAchievements()
        {
            return achievements;
        }

        //Adds a new Achievement object, then puts it in the user's list of achievements
        public void addAchievement(String name, String description, String iconName)
        {
            Achievement newAchievement = new Achievement(name, description, iconName);
            achievements.Add(newAchievement);
        }

        //Increases the win count, called upon winning a game of any type
        public void addWin()
        {
            winCount++;
            //Check if an achievement was earned based on the winCount
            switch (winCount)
            {
                case 1:
                    addAchievement("1 Win", "You won one game of StupidBlackjack!", "1_win_icon.png");
                    break;
                case 10:
                    addAchievement("10 Wins", "You won ten games of StupidBlackjack!", "10_win_icon.png");
                    break;
                case 25:
                    addAchievement("25 Wins", "You won 25 games of StupidBlackjack!", "25_win_icon.png");
                    break;
                case 100:
                    addAchievement("100 Wins", "You won 100 games of StupidBlackjack! Do yourself a favor and don't go to a casino...", "100_win_icon.png");
                    break;
                default:
                    break;
            }
        }
    }
}
