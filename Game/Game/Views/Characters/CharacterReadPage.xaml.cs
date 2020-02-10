﻿using System.ComponentModel;
using Xamarin.Forms;
using Game.ViewModels;
using System;
using Game.Models;

namespace Game.Views
{
    /// <summary>
    /// The Read Page
    /// </summary>
    [DesignTimeVisible(false)]
    public partial class CharacterReadPage : ContentPage
    {
        // View Model for Item
        readonly GenericViewModel<CharacterModel> ViewModel;

        /// <summary>
        /// Constructor called with a view model
        /// This is the primary way to open the page
        /// The viewModel is the data that should be displayed
        /// </summary>
        /// <param name="viewModel"></param>
        public CharacterReadPage(GenericViewModel<CharacterModel> data)
        {
            InitializeComponent();

            BindingContext = this.ViewModel = data;
        }

        /// <summary>
        /// Save calls to Update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //async void Update_Clicked(object sender, EventArgs e)
        //{
            //await Navigation.PushModalAsync(new NavigationPage(new ItemUpdatePage(new GenericViewModel<CharacterModel>(ViewModel.Data))));
            //await Navigation.PopAsync();
        //}

        /// <summary>
        /// Calls for Delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //async void Delete_Clicked(object sender, EventArgs e)
        //{
            //await Navigation.PushModalAsync(new NavigationPage(new ItemDeletePage(new GenericViewModel<ItemModel>(ViewModel.Data))));
            //await Navigation.PopAsync();
        //}
    }
}