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
        public List<Achievement> achievements = null;

        private AchievementMonitor()
        {
            achievements = new List<Achievement>();
        }

        public static AchievementMonitor getInstance()
        {
            if(instance == null)
            {
                instance = new AchievementMonitor();
            }
            return instance;
        }

        public void addAchievement(String name, String description, String iconName)
        {
            Achievement newAchievement = new Achievement(name, description, iconName);
            achievements.Add(newAchievement);
        }
    }
}
