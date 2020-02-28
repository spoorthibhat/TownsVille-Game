using Game.Models;
using Game.Views;
using System;
using Xamarin.Forms;
using System.Linq;
using System.Collections.Generic;
using Game.Services;
using System.Threading.Tasks;

namespace Game.ViewModels
{
    /// <summary>
    /// Index View Model
    /// Manages the list of data records
    /// </summary>
    public class BattleEngineViewModel
    {
        #region Singleton

        // Make this a singleton so it only exist one time because holds all the data records in memory
        private static volatile BattleEngineViewModel instance;
        private static readonly object syncRoot = new Object();
        public List<CharacterModel> SelectedCharacters = new List<CharacterModel>();

        public static BattleEngineViewModel Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new BattleEngineViewModel();
                        }
                    }
                }

                return instance;
            }
        }

        #endregion Singleton


        /// <summary>
        /// The Battle Engine
        /// </summary>
        public Engine.BattleEngine Engine = new Engine.BattleEngine();

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public BattleEngineViewModel()
        {
            // Register the Character pick up message
            MessagingCenter.Subscribe<PickCharactersPage, List<CharacterModel>>(this, "PickCharacters", async (obj, data) =>
            {
                await PickCharactersAsync(data as List<CharacterModel>);
            });

        }

        private async Task<bool> PickCharactersAsync(List<CharacterModel> SelectedCharacterList)
        {
            foreach (CharacterModel character in SelectedCharacterList)
                SelectedCharacters.Add(character);
            return await Task.FromResult(true);
        }

        #endregion Constructor
    }
}