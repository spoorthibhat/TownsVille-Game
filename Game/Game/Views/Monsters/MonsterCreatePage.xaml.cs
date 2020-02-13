using Game.Models;
using Game.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views.Monsters
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MonsterCreatePage : ContentPage
    {
        GenericViewModel<MonsterModel> ViewModel { get; set; }

        public MonsterCreatePage(GenericViewModel<MonsterModel> data)
        {
            InitializeComponent();
            data.Data = new MonsterModel();

            BindingContext = this.ViewModel = data;

            this.ViewModel.Title = "Create";
        }
    }
}