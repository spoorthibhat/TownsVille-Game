using Game.Models;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Game.Engine;
using Game.Services;
using System.Linq;
using Game.ViewModels;

namespace Game.Views
{
	/// <summary>
	/// The Main Game Page
	/// </summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BattlePage: ContentPage
	{
        public List<CharacterModel> SelectedCharacterList = BattleEngineViewModel.Instance.SelectedCharacters;

        public List<MonsterModel> SelectedMonsterList = BattleEngineViewModel.Instance.SelectedMonsters;

        public CharacterModel currentCharacter;

        public int[] currentPosition = new int[2];

        /// <summary>
        /// Constructor
        /// </summary>
        public BattlePage (int ThemeIndex)
		{
			InitializeComponent ();
            SetTheme(ThemeIndex);

            LoadCharacters();
            LoadMonsters();
		}
        /// <summary>
        /// Setting Battle Field background
        /// </summary>
        /// <param name="themeIndex"></param>
        private void SetTheme(int themeIndex)
        {
            //TODO
        }

        private void LoadCharacters()
        {
            
            for (int i = 0; i < SelectedCharacterList.Count; i++)
            {
                Xamarin.Forms.ImageButton img = new Xamarin.Forms.ImageButton();
                img.Source = SelectedCharacterList[i].ImageURI;
                img.StyleId = i.ToString();
                img.Clicked += Character_Clicked;
                Grid.SetRow(img, i);
                Grid.SetColumn(img, 0);
                BattleGrid.Children.Add(img);
            }
        }

        private void Character_Clicked(object sender, EventArgs e)
        {
            ImageButton imgButton = (ImageButton)sender;
            int row = Int32.Parse(imgButton.StyleId);
            currentCharacter = SelectedCharacterList[row];
            currentPosition[0] = row;
            currentPosition[1] = 0;
            DisableOtherCharacterSelection();
        }

        private void DisableOtherCharacterSelection()
        {
            foreach (var child in BattleGrid.Children.Where(child => Grid.GetRow(child) != currentPosition[0] && Grid.GetColumn(child) == 0))
            {
                child.IsEnabled = false;
            }
        }

        private void MoveBack_Clicked(object sender, EventArgs e)
        {
            if (currentPosition[1] - 1 < 1)
                return;
            currentPosition[1]--;
            Xamarin.Forms.Image img = new Xamarin.Forms.Image();
            img.Source = currentCharacter.ImageURI;
            Grid.SetRow(img, currentPosition[0]);
            Grid.SetColumn(img, currentPosition[1]);
            BattleGrid.Children.Add(img);
            foreach (var child in BattleGrid.Children.Where(child => Grid.GetRow(child) == currentPosition[0] && Grid.GetColumn(child) == currentPosition[1] + 1))
            {
                child.IsVisible = false;
            }
        }
        private void MoveFront_Clicked(object sender, EventArgs e)
        {
            if (currentPosition[1] + 1 > 4)
                return;
            currentPosition[1]++;
            Xamarin.Forms.Image img = new Xamarin.Forms.Image();
            img.Source = currentCharacter.ImageURI;
            Grid.SetRow(img, currentPosition[0]);
            Grid.SetColumn(img, currentPosition[1]);
            BattleGrid.Children.Add(img);
            foreach (var child in BattleGrid.Children.Where(child => Grid.GetRow(child) == currentPosition[0] && Grid.GetColumn(child) == currentPosition[1]-1))
            {
                child.IsVisible = false;
            }
        }
        private void MoveUp_Clicked(object sender, EventArgs e)
        {
            if (currentPosition[0] - 1 < 0)
                return;
            currentPosition[0]--;
            Xamarin.Forms.Image img = new Xamarin.Forms.Image();
            img.Source = currentCharacter.ImageURI;
            Grid.SetRow(img, currentPosition[0]);
            Grid.SetColumn(img, currentPosition[1]);
            BattleGrid.Children.Add(img);
            foreach (var child in BattleGrid.Children.Where(child => Grid.GetRow(child) == currentPosition[0] + 1 && Grid.GetColumn(child) == currentPosition[1]))
            {
                child.IsVisible = false;
            }
        }
        private void MoveDown_Clicked(object sender, EventArgs e)
        {
            if (currentPosition[0] + 1 > 5)
                return;
            Xamarin.Forms.Image img = new Xamarin.Forms.Image();
            img.Source = currentCharacter.ImageURI;
            currentPosition[0]++;
            Grid.SetRow(img, currentPosition[0]);
            Grid.SetColumn(img, currentPosition[1]);
            BattleGrid.Children.Add(img);

            foreach (var child in BattleGrid.Children.Where(child => Grid.GetRow(child) == currentPosition[0]-1 && Grid.GetColumn(child) == currentPosition[1]))
            {
                child.IsVisible= false;
            }
        }
        private void LoadMonsters()
        {
            for (int i = 0; i < SelectedMonsterList.Count; i++)
            {
                Xamarin.Forms.ImageButton img = new Xamarin.Forms.ImageButton();
                img.Source = SelectedMonsterList[i].ImageURI;
                Grid.SetRow(img, i);
                Grid.SetColumn(img, 5);
                BattleGrid.Children.Add(img);
            }
        }
        /// <summary>
        /// Attack Action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void AttackButton_Clicked(object sender, EventArgs e)
		{
			DisplayAlert("SU", "Attack !!!", "OK");
        }
        /// <summary>
        /// Special Ability Action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void SpecialAbilityButton_Clicked(object sender, EventArgs e)
        {
            //Just for testing
            await Navigation.PushModalAsync(new NavigationPage(new PickItemsPage()));
        }
    }
}