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
        private class Image
        {
            public string Url { get; set; }
        }
        // the character to create
        GenericViewModel<CharacterModel> ViewModel { get; set; }

        ObservableCollection<Image> imageList = new ObservableCollection<Image>();

        // public ObservableCollection<Image> Images { get { return imageList; } }

        public CharacterCreatePage(GenericViewModel<CharacterModel> data)
        {
            InitializeComponent();
            data.Data = new CharacterModel();
            imageList.Add(new Image { Url = "Blossum.png" });
            imageList.Add(new Image { Url = "Bubbles.png" });
            imageList.Add(new Image { Url = "Buttercup.png" });

            ImageView.ItemsSource = imageList;
            

            BindingContext = this.ViewModel = data;

            this.ViewModel.Title = "Create";

            SpecialAbilityPicker.SelectedItem = data.Data.SpecialAbility.ToString();
            AttackPicker.SelectedItem = data.Data.Attack.ToString();
            DefensePicker.SelectedItem = data.Data.Defense.ToString();
            HealthPicker.SelectedItem = data.Data.MaxHealth.ToString();
        }

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

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        

        void Level_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            LevelValue.Text = String.Format("{0}", e.NewValue);
        }

        

    }
}