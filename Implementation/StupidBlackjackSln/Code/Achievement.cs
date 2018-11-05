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

        public Bitmap GetIcon()
        {
            return icon;
        }

        public String GetName()
        {
            return name;
        }

        public String GetDescription()
        {
            return description;
        }

        public DateTime GetTimeEarned()
        {
            return timeEarned;
        }

        //Returns the time earned in a readable format
        public String GetReadableTime()
        {
            return timeEarned.ToString();
        }
    }
}
