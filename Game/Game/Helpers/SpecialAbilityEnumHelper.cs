using System;
using System.Collections.Generic;
using Game.Models;
using System.Linq;

namespace Game.Helpers
{
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
