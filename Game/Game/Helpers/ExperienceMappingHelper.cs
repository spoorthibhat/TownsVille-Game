using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Helpers
{
    

    public static class ExperienceMappingHelper
    {
        
        public static Dictionary<int, int> GetExperienceLevelMapping()
        {
            var Experience_Level = new Dictionary<int, int>()
            {
                {0, 1},
                {300,2},
                {900, 3},
                {2700, 4},
                {6500, 5},
                {14000, 6},
                {23000, 7},
                {34000, 8},
                {48000,9 },
                {64000, 10 },
                {85000, 11},
                {100000,12},
                {120000,13},
                {140000, 14},
                {165000,15},
                {195000,16},
                {225000, 17},
                {265000,18 },
                {305000,19},
                {355000,20}
            };

            return Experience_Level;
        }

    }
}
