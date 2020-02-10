using Game.Models;
using Game.Views;
using System;
using Xamarin.Forms;
using System.Linq;
using System.Collections.Generic;
using Game.Services;


namespace Game.ViewModels
{
    class CharacterIndexViewModel: BaseViewModel<CharacterModel>
    {
        public CharacterIndexViewModel()
        {
            Title = "Character";
        }

        /// <summary>
        /// Returns the Character passed in
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public CharacterModel CheckIfCharacterExists(CharacterModel data)
        {
            // This will walk the items and find if there is one that is the same.
            // If so, it returns the item...

            var myList = Dataset.Where(a =>
                                        a.Name == data.Name)
                                        .FirstOrDefault();

            if (myList == null)
            {
                // it's not a match, return false;
                return null;
            }

            return myList;
        }

        /// <summary>
        /// Load the Default Data
        /// </summary>
        /// <returns></returns>
        public override List<CharacterModel> GetDefaultData()
        {
            return DefaultData.LoadData(new CharacterModel());
        }
    }
}
