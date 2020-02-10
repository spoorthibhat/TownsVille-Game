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

namespace Game.Views.Characters
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(false)]
    public partial class CharacterCreatePage : ContentPage
    {
        // the character to create
        GenericViewModel<CharacterModel> ViewModel { get; set; }

        public CharacterCreatePage(GenericViewModel<CharacterModel> data)
        {
            InitializeComponent();
            data.Data = new CharacterModel();

            BindingContext = this.ViewModel = data;

            this.ViewModel.Title = "Create";

            SpecialAbilityPicker.SelectedItem = data.Data.SpecialAbility.ToString();
            AttackPicker.SelectedItem = data.Data.Attack.ToString();
            DefensePicker.SelectedItem = data.Data.Defense.ToString();
            HealthPicker.SelectedItem = data.Data.MaxHealth.ToString();
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            // TODO : Complete this
            return;
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            // TODO : Complete this
            return;
        }

        async void Browse_Clicked(object sender, EventArgs e)
        {
            return;
        }

        void Level_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            LevelValue.Text = String.Format("{0}", e.NewValue);
        }

        

    }
}