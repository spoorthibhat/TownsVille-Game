using Game.Models;
using Game.Services;
using Game.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Image = Game.Models.Image;

namespace Game.Views.Monsters
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MonsterCreatePage : ContentPage
    {
        GenericViewModel<MonsterModel> ViewModel { get; set; }

        // The image list holding all the Image objects
        ObservableCollection<Image> imageList = new ObservableCollection<Image>();
        

        public MonsterCreatePage(GenericViewModel<MonsterModel> data)
        {
            InitializeComponent();
            data.Data = new MonsterModel();

            foreach (Image image in DefaultData.LoadMonsterImages())
            {
                imageList.Add(image);
            }
            ImageView.ItemsSource = imageList;
            BindingContext = this.ViewModel = data;

            this.ViewModel.Title = "Create";
        }

        void OnMonsterImageSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var image = args.SelectedItem as Image;

            ViewModel.Data.ImageURI = image.Url;
            MonsterImage.Source = image.Url;

        }

        /// <summary>
        /// Method inviked when stepper value is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Level_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            LevelValue.Text = String.Format("{0}", e.NewValue);
        }
    }
}