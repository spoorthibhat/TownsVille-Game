using Game.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace Game.Views
{
    /// <summary>
    /// About Page
    /// </summary>
    [DesignTimeVisible(false)]
    public partial class AboutPage : ContentPage
    {
        // Constructor for Unit Testing
        public AboutPage(bool UnitTest) { }

        /// <summary>
        /// Constructor for About Page
        /// </summary>
        public AboutPage()
        {
            InitializeComponent();

            // Hide the Debug Settings
            DatabaseSettingsFrame.IsVisible = false;

            // Turn off the Settings Frame
            DebugSettingsFrame.IsVisible = false;

            // Set to the curent date and time
            CurrentDateTime.Text = DateTime.Now.ToString("MM/dd/yy hh:mm:ss");
        }

        /// <summary>
        /// Show or hide the Database Frame
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DatabaseSettingsSwitch_OnToggled(object sender, ToggledEventArgs e)
        {
            // Show or hide the Database Section
            DatabaseSettingsFrame.IsVisible = (e.Value);
        }

        /// <summary>
        /// Sow or hide the Debug Settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DebugSettingsSwitch_OnToggled(object sender, ToggledEventArgs e)
        {
           // Show or hide the Debug Settings
           DebugSettingsFrame.IsVisible = (e.Value);
        }

        /// <summary>
        /// Data Source Toggle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void DataSource_Toggled(object sender, EventArgs e)
        {
            // Flip the settings
            if (DataSourceValue.IsToggled == true)
            {
                MessagingCenter.Send(this, "SetDataSource", 1);
            }
            else
            {
                MessagingCenter.Send(this, "SetDataSource", 0);
            }
        }

        /// <summary>
        /// Button to delete the data store
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void WipeDataList_Clicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Delete Data", "Are you sure you want to delete all data?", "Yes", "No");

            if (answer)
            {
                MessagingCenter.Send(this, "WipeDataList", true);
            }
        }
        /// <summary>
        /// Character Hit Value changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CharacterHitValue_Changed(object sender, TextChangedEventArgs e)
        {
            // Set character Hit Value
            BattleEngineViewModel EngineViewModel = BattleEngineViewModel.Instance;
            EngineViewModel.Engine.CharacterHitValue = Int32.Parse(CharacterHitValueEntry.Text);
        }
        /// <summary>
        /// Set Character to Force Miss
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CharacterForceMiss_OnToggled(object sender, ToggledEventArgs e)
        {
            // Set character to force Miss
            BattleEngineViewModel EngineViewModel = BattleEngineViewModel.Instance;
            EngineViewModel.Engine.CharacterHitValue = 1;
        }

        /// <summary>
        /// Set Character to Force Hit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CharacterForceHit_OnToggled(object sender, ToggledEventArgs e)
        {
            // Set character to force Hit
            BattleEngineViewModel EngineViewModel = BattleEngineViewModel.Instance;
            EngineViewModel.Engine.CharacterHitValue = 20;
        }
        /// <summary>
        /// Monster Hit Value changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MonsterHitValue_Changed(object sender, TextChangedEventArgs e)
        {
            // Set character Hit Value
            BattleEngineViewModel EngineViewModel = BattleEngineViewModel.Instance;
            EngineViewModel.Engine.MonsterHitValue = Int32.Parse(MonsterHitValueEntry.Text);
        }
        /// <summary>
        /// Set Monster to Force Miss
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MonsterForceMiss_OnToggled(object sender, ToggledEventArgs e)
        {
            // Set Monster to force Miss
            BattleEngineViewModel EngineViewModel = BattleEngineViewModel.Instance;
            EngineViewModel.Engine.MonsterHitValue = 1;
        }

        /// <summary>
        /// Set Monster to Force Hit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MonsterForceHit_OnToggled(object sender, ToggledEventArgs e)
        {
            // Set Monster to force Hit
            BattleEngineViewModel EngineViewModel = BattleEngineViewModel.Instance;
            EngineViewModel.Engine.MonsterHitValue = 20;
        }

        private void IFeelGood_OnToggled(object sender, ToggledEventArgs e)
        {
            MessagingCenter.Send(this, "IFeelGood", true);
        }
    }
}