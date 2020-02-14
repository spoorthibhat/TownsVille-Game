using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Helpers
{
    
    /// <summary>
    /// Experience to other attributes mapping helper as per the game design
    /// </summary>
    public static class ExperienceMappingHelper
    {
        // An array of experiences
        static int[] Experiences = {0,300,900,2700,6500,14000,23000,34000,48000,64000,85000,100000,120000,140000,165000,195000,225000,265000,305000,355000};


        /// <summary>
        /// Gets the level associated with the experience passed
        /// </summary>
        /// <param name="Experience"></param>
        /// <returns></returns>
        public static int GetLevelPerExperience(int Experience)
        {  

            int index = Array.BinarySearch(Experiences, Experience);
            if(index < 0)
            {
                index = ~index - 1;
            }

            return index + 1; // This would be the level since level starts with 1
        }

    }
}
