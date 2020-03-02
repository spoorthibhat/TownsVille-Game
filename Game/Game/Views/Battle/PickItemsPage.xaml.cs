﻿using Game.Models;
using Game.Services;
using Game.ViewModels;
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
        public List<ItemModel> DroppedItemsList;

        /// <summary>
        /// Constructor
        /// </summary>
        public PickItemsPage()
        {
            InitializeComponent();
            LoadItems();
        }
        /// <summary>
        /// Loading Characters in the battle
        /// </summary>
        private void LoadItems()
        {
            foreach (var data in BattleEngineViewModel.Instance.Engine.BattleScore.ItemModelDropList)
            {
                DroppedItemsList.Add(data);
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