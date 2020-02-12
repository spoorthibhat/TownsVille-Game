﻿using Game.Models;
using Game.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace Game.Views
{
    /// <summary>
    /// Create Item
    /// </summary>
    [DesignTimeVisible(false)]
    public partial class ItemCreatePage : ContentPage
    {
        /// <summary>
        /// Image class needed for the list view
        /// </summary>
        private class Image
        {

            /// <summary>
            /// The source url of the image
            /// </summary>
            public string Url { get; set; }
        }

        // The image list holding all the Image objects
        ObservableCollection<Image> imageList = new ObservableCollection<Image>();

        // The item to create
        GenericViewModel<ItemModel> ViewModel { get; set; }

        /// <summary>
        /// Constructor for Create makes a new model
        /// </summary>
        public ItemCreatePage(GenericViewModel<ItemModel> data)
        {
            InitializeComponent();

            data.Data = new ItemModel();

            BindingContext = this.ViewModel = data;

            this.ViewModel.Title = "Create";

            // TODO: To be changed
            imageList.Add(new Image { Url = "Blossum.png" });
            imageList.Add(new Image { Url = "Bubbles.png" });
            imageList.Add(new Image { Url = "Buttercup.png" });
            imageList.Add(new Image { Url = "utonium.png" });
            imageList.Add(new Image { Url = "ms_keane.png" });
            imageList.Add(new Image { Url = "mayor.png" });

            ImageView.ItemsSource = imageList;

            //Need to make the SelectedItem a string, so it can select the correct item.
            LocationPicker.SelectedItem = data.Data.Location.ToString();
            AttributePicker.SelectedItem = data.Data.Attribute.ToString();
        }

        /// <summary>
        /// Save by calling for Create
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

            MessagingCenter.Send(this, "Create", ViewModel.Data);
            await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Cancel the Create
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Catch the change to the Stepper for Range
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Range_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            RangeValue.Text = String.Format("{0}", e.NewValue);
        }

        /// <summary>
        /// Catch the change to the stepper for Value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Value_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            ValueValue.Text = String.Format("{0}", e.NewValue);
        }

        /// <summary>
        /// Catch the change to the stepper for Damage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Damage_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            DamageValue.Text = String.Format("{0}", e.NewValue);
        }

        void OnItemImageSelected(object sender, SelectedItemChangedEventArgs args)
        {
            return;


        }
    }
}