using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Helpers
{
    

    public static class ExperienceMappingHelper
    {
        static int[] Experiences = {0,300,900,2700,6500,14000,23000,34000,48000,64000,85000,100000,120000,140000,165000,195000,225000,265000,305000,355000};

        public static Dictionary<int, int> GetExperienceLevelMapping()
        {
            var Experience_Level = new Dictionary<int, int>();
            
           for(int i = 1; i <=20; i++)
            {
                Experience_Level.Add(Experiences[i], i);
            }

            return Experience_Level;
        }

    }
}
