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
        private bool onlineWin = false;
        private bool instantWin = false;
        private bool blackjack = false;

        private AchievementMonitor()
        {
            achievements = new List<Achievement>();
        }

        public static AchievementMonitor GetInstance()
        {
            return instance ?? (instance = new AchievementMonitor());
        }

        public List<Achievement> GetAchievements()
        {
            return achievements;
        }

        //Adds a new Achievement object, then puts it in the user's list of achievements
        public void AddAchievement(String name, String description, String iconName)
        {
            Achievement newAchievement = new Achievement(name, description, iconName);
            achievements.Add(newAchievement);
        }

        //Increases the win count, called upon winning a game of any type
        public void AddWin()
        {
            winCount++;
            //Check if an achievement was earned based on the winCount
            switch (winCount)
            {
                case 1:
                    AddAchievement("1 Win", "You won one game!", "_1_win_icon");
                    break;
                case 10:
                    AddAchievement("10 Wins", "You won ten games!", "_10_win_icon");
                    break;
                case 25:
                    AddAchievement("25 Wins", "You won 25 games!", "_25_win_icon");
                    break;
                case 100:
                    AddAchievement("100 Wins", "You won 100 games of StupidBlackjack! Do yourself a favor, and don't go to a casino...", "_100_win_icon");
                    break;
                default:
                    break;
            }
        }

        //Add the online win achievement if not already awarded
        public void AddOnlineWinAchievement()
        {
            if (!onlineWin)
            {
                AddAchievement("Online Win", "You won an online game!", "online_win_icon");
                onlineWin = true;
            }

        }

        //Add the instant win achievement if not already awarded
        public void AddInstantWinAchievement()
        {
            if (!instantWin)
            {
                AddAchievement("Instant Win", "You won a game without hitting!", "instant_win_icon");
                instantWin = true;
            }

        }

        //Add the blackjack achievement if not already awarded
        public void AddBlackjackAchievement()
        {
            if (!blackjack)
            {
                AddAchievement("Blackjack", "You got a Blackjack!", "blackjack_icon");
                blackjack = true;
            }

        }
    }
}
