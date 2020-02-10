using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Models;
using Game.ViewModels;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views.Characters
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0019:Use pattern matching", Justification = "<Pending>")]
    [DesignTimeVisible(false)]
    public partial class CharacterIndexPage : ContentPage
    {
        // View Model used for data binding
        readonly CharacterIndexViewModel ViewModel;


        /// <summary>
        /// Constructor for Character Page
        /// 
        /// Get the CharacterIndexView Model
        /// </summary>
        public CharacterIndexPage()
        {
            InitializeComponent();
            BindingContext = ViewModel = CharacterIndexViewModel.Instance;
        }


    }
}