using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views.Characters
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharacterCreatePage : ContentPage
    {
        public CharacterCreatePage()
        {
            InitializeComponent();
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

        void Level_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            // LevelValue.Text = String.Format("{0}", e.NewValue);
        }

        void Attack_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            // AttackValue.Text = String.Format("{0}", e.NewValue);
        }

        void Defense_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            // DefenseValue.Text = String.Format("{0}", e.NewValue);
        }

        void Health_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            // HealthValue.Text = String.Format("{0}", e.NewValue);
        }

    }
}