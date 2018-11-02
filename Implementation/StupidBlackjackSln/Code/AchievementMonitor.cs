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
        public List<Achievement> achievements = null;

        public AchievementMonitor()
        {
            achievements = new List<Achievement>();
        }

        public void addAchievement(String name, String description, String iconName)
        {
            Achievement newAchievement = new Achievement(name, description, iconName);
            achievements.Add(newAchievement);
        }
    }
}
