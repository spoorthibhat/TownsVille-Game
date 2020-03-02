using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Game.ViewModels;
using Game.Models;
using Game.Engine;

namespace Game.Views.Battle
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowMonstersPage : ContentPage
    {
        // List of Monsters in the battle
        public List<PlayerInfoModel> SelectedMonsterList;

        // Constructor
        public ShowMonstersPage()
        {
            InitializeComponent();
            var CharacterList = BattleEngineViewModel.Instance.SelectedCharacters;
            var Battle = new BattleEngine();
            foreach (CharacterModel Character in CharacterList)
            {
                Battle.PopulateCharacterList(Character);
            }
            Battle.StartBattle(false);

            SelectedMonsterList = Battle.MonsterList;
            //MonstersListView.ItemsSource = SelectedMonsterList;
        }
    }
}