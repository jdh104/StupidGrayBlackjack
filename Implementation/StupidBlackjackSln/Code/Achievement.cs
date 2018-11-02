//ClassMaster: Dakota

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StupidBlackjackSln.Code
{
    class Achievement
    {
        private String name;
        private String description;
        private Bitmap icon;
        //Time that the achievement was received
        private DateTime timeEarned;

        public Achievement(String name, String description, String iconName)
        {
            this.name = name;
            this.description = description;
            //setIcon
            //Saves the current time as timeEarned
            timeEarned = DateTime.Now;
        }

        public Bitmap getIcon()
        {
            return icon;
        }

        public String getName()
        {
            return name;
        }

        public String getDescription()
        {
            return description;
        }

        public DateTime getTimeEarned()
        {
            return timeEarned;
        }

        //Returns the time earned in a readable format
        public String getReadableTime()
        {
            return timeEarned.ToString();
        }
    }
}
