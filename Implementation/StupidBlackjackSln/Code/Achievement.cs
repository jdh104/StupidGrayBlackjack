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

        public Achievement(String name, String description, String iconName)
        {
            setName(name);
            setDescription(description);
            //setIcon();
        }

        public Bitmap getIcon()
        {
            return icon;
        }

        public void setIcon(Bitmap newIcon)
        {
            icon = newIcon;
        }

        public String getName()
        {
            return name;
        }

        public void setName(String newName)
        {
            name = newName;
        }

        public String getDescription()
        {
            return description;
        }

        public void setDescription(String newDescription)
        {
            name = newDescription;
        }

        
    }
}
