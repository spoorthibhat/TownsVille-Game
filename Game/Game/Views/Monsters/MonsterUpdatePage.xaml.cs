﻿using System;
using System.ComponentModel;
using Xamarin.Forms;
using Game.ViewModels;
using Game.Models;
using System.Collections.ObjectModel;
using Image = Game.Models.Image;
using Game.Services;

namespace Game.Views
{
    /// <summary>
    /// Character Update Page
    /// </summary>
    [DesignTimeVisible(false)]
    public partial class MonsterUpdatePage : ContentPage
    {
        

        // View Model for Character
        readonly GenericViewModel<MonsterModel> ViewModel;

        ObservableCollection<Image> imageList = new ObservableCollection<Image>();

        /// <summary>
        /// Constructor that takes and existing data item
        /// </summary>
        public MonsterUpdatePage(GenericViewModel<MonsterModel> data)
        {
            InitializeComponent();

            BindingContext = this.ViewModel = data;

            // Adding image data 
            foreach (Image image in DefaultData.LoadCharacterImages())
            {
                imageList.Add(image);
            }
 

            ImageView.ItemsSource = imageList;

            this.ViewModel.Title = "Update " + data.Title;

            //Need to make the SelectedItem a string, so it can select the correct item.
            AttackPicker.SelectedItem = data.Data.Attack.ToString();
            DefensePicker.SelectedItem = data.Data.Defense.ToString();
            SpeedPicker.SelectedItem = data.Data.Speed.ToString();
        }
        
        /// <summary>
        /// Save calls to Update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void Save_Clicked(object sender, EventArgs e)
        {
            // If the image in the data box is empty, use the default one..
            if (string.IsNullOrEmpty(ViewModel.Data.ImageURI))
            {
                ViewModel.Data.ImageURI = Services.ItemService.DefaultImageURI;
            }

            MessagingCenter.Send(this, "Update", ViewModel.Data);
            await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Cancel and close this page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
        
        /// <summary>
        /// Catch the change to the Stepper for Level
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Level_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            LevelValue.Text = String.Format("{0}", e.NewValue);
        }

        /// <summary>
        /// Catch the change for image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnCharacterImageSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var image = args.SelectedItem as Image;

            ViewModel.Data.ImageURI = image.Url;
            CharacterImage.Source = image.Url;
        }
    }
}