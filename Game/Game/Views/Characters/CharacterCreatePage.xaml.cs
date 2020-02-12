using Game.Models;
using Game.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

namespace Game.Views.Characters
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(false)]
    public partial class CharacterCreatePage : ContentPage
    {
        // Image class needed for the list view
        private class Image
        {
            // The source url of the image
            public string Url { get; set; }
        }
        // the character to create
        GenericViewModel<CharacterModel> ViewModel { get; set; }

        // The image list holding all the Image objects
        ObservableCollection<Image> imageList = new ObservableCollection<Image>();

        // Constructor that initializes the character create page with default values.
        public CharacterCreatePage(GenericViewModel<CharacterModel> data)
        {
            InitializeComponent();
            data.Data = new CharacterModel();
            imageList.Add(new Image { Url = "Blossum.png" });
            imageList.Add(new Image { Url = "Bubbles.png" });
            imageList.Add(new Image { Url = "Buttercup.png" });
            imageList.Add(new Image { Url = "utonium.png" });
            imageList.Add(new Image { Url = "ms_keane.png" });
            imageList.Add(new Image { Url = "mayor.png" });

            ImageView.ItemsSource = imageList;
            

            BindingContext = this.ViewModel = data;

            this.ViewModel.Title = "Create";

            SpecialAbilityPicker.SelectedItem = data.Data.SpecialAbility.ToString();
            AttackPicker.SelectedItem = data.Data.Attack.ToString();
            DefensePicker.SelectedItem = data.Data.Defense.ToString();
            // HealthPicker.SelectedItem = data.Data.MaxHealth.ToString();
        }

        // Function that is invoked when save button was clicked in the UI. 
        // The method sends the Character object with the Create message through messaging center publishing.
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

        // Function that is invoked when cancel button was clicked in the UI. 
        // It pops the current page from the stack
        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        
        // Method inviked when stepper value is changed
        void Level_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            LevelValue.Text = String.Format("{0}", e.NewValue);
        }

        // When the image is selected, assigns the image on UI source to the clicked image's URL
        // and updates the ImageURI field on the Data
        void OnCharacterImageSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var image = args.SelectedItem as Image;

            ViewModel.Data.ImageURI = image.Url;
            CharacterImage.Source = image.Url;


        }

    }
}