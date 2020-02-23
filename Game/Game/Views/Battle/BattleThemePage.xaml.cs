﻿using Game.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Image = Game.Models.Image;

namespace Game.Views.Battle
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BattleThemePage : ContentPage
    {

        // The image list holding all the Image objects
        ObservableCollection<Image> ImageList = new ObservableCollection<Image>();

        public BattleThemePage()
        {
            InitializeComponent();
            foreach (Image image in DefaultData.LoadCharacterImages())
            {
                ImageList.Add(image);
            }

            ImageView.ItemsSource = ImageList;
        }

        async void Pick_Characters_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PickCharactersPage());
        }

        /// <summary>
        /// When the image is selected, assigns this theme 
        /// </summary>to be used duing battle
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void OnThemeImageSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var image = args.SelectedItem as Image;

            

        }
    }
}