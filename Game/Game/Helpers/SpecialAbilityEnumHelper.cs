using System;
using System.Collections.Generic;
using Game.Models;
using System.Linq;

namespace Game.Helpers
{
    /// <summary>
    /// Helper class that will be used to get special abilities from enum 
    /// </summary>
    static class SpecialAbilityEnumHelper
    {
        public static List<string> GetSpecialAbilityList
        {
            get
            {
                var myList = Enum.GetNames(typeof(SpecialAbilityEnum)).ToList();
                return myList;
            }
        }
    }
}
