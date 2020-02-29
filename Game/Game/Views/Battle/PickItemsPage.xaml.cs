using Game.Models;
using Game.Services;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views
{
    /// <summary>
    /// The Main Game Page
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PickItemsPage : ContentPage
    {
        public List<CharacterModel> SelectedCharacterList = DefaultData.LoadData(new CharacterModel());

        /// <summary>
        /// Constructor
        /// </summary>
        public PickItemsPage()
        {
            InitializeComponent();
            LoadCharacters();
        }
        /// <summary>
        /// Loading Characters in the battle
        /// </summary>
        private void LoadCharacters()
        {
            for (int i = 0; i < 6; i++)
            {
                Xamarin.Forms.ImageButton img = new Xamarin.Forms.ImageButton();
                img.Source = SelectedCharacterList[i].ImageURI;
                img.StyleId = i.ToString();
                Grid.SetRow(img, 0);
                Grid.SetColumn(img, i);
                CharactersGrid.Children.Add(img);
            }
        }

        /// <summary>
        /// Quit the Battle
        /// 
        /// Quitting out
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void CloseButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
        /// <summary>
        /// Auto assign items to characters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void AutoPickUpButton_Clicked(object sender, EventArgs e)
        {

            await Navigation.PopModalAsync();
        }
    }
}