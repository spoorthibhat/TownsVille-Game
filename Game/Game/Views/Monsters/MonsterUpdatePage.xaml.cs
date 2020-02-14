using System;
using System.ComponentModel;
using Xamarin.Forms;
using Game.ViewModels;
using Game.Models;
using System.Collections.ObjectModel;
using Image = Game.Models.Image;
using Game.Services;
using Game.Helpers;

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
            HeadItemPicker.BindingContext = ItemModelHelper.GetItemModelNameFromGuid(data.Data.Head);

            // Adding image data 
            foreach (Image image in DefaultData.LoadMonsterImages())
            {
                imageList.Add(image);
            }
 

            ImageView.ItemsSource = imageList;


            HeadItemPicker.ItemsSource = DefaultData.LoadItems(ItemLocationEnum.Head);
            //HeadItemPicker.SelectedItem = ItemModelHelper.GetItemModelFromGuid(data.Data.Head);



            NecklaceItemPicker.ItemsSource = DefaultData.LoadItems(ItemLocationEnum.Necklass);
            PrimaryHandItemPicker.ItemsSource = DefaultData.LoadItems(ItemLocationEnum.PrimaryHand);
            OffHandItemPicker.ItemsSource = DefaultData.LoadItems(ItemLocationEnum.OffHand);
            RightFingerItemPicker.ItemsSource = DefaultData.LoadItems(ItemLocationEnum.RightFinger);
            LeftFingerItemPicker.ItemsSource = DefaultData.LoadItems(ItemLocationEnum.LeftFinger);
            FeetItemPicker.ItemsSource = DefaultData.LoadItems(ItemLocationEnum.Feet);

            this.ViewModel.Title = "Update " + data.Title;

            //Need to make the SelectedItem a string, so it can select the correct item.
            AttackPicker.SelectedItem = data.Data.Attack.ToString();
            DefensePicker.SelectedItem = data.Data.Defense.ToString();
            SpeedPicker.SelectedItem = data.Data.Speed.ToString();

            HeadItemPicker.SelectedItem = ItemModelHelper.GetItemModelFromGuid(data.Data.Head);
            NecklaceItemPicker.SelectedItem = data.Data.Necklace;
            PrimaryHandItemPicker.SelectedItem = data.Data.PrimaryHand;
            OffHandItemPicker.SelectedItem = data.Data.OffHand;
            RightFingerItemPicker.SelectedItem = data.Data.RightFinger;
            LeftFingerItemPicker.SelectedItem = data.Data.LeftFinger;
            FeetItemPicker.SelectedItem = data.Data.Feet;

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
           // HeadItemPicker.SelectedItem = ItemModelHelper.GetItemModelFromGuid(ViewModel.Data.Head);

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
        void picker_Changed(object sender, SelectedItemChangedEventArgs args)
        {

        }
    }
}