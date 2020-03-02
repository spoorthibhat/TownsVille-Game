using Game.Models;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Game.Engine;
using Game.Services;
using System.Linq;
using Game.ViewModels;

namespace Game.Views
{
	/// <summary>
	/// The Main Game Page
	/// </summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BattlePage: ContentPage
	{
        public List<PlayerInfoModel> SelectedCharacterList;
        public Dictionary<PlayerInfoModel, int> SelectedCharacterMap = new Dictionary<PlayerInfoModel, int>();

        public List<PlayerInfoModel> SelectedMonsterList ;
        public Dictionary<PlayerInfoModel, int> SelectedMonsterMap = new Dictionary<PlayerInfoModel, int>();

        public PlayerInfoModel CurrentPlayer;

        public BattleEngine Battle;
        public bool UseSpecialAbility = false;

        public int[] AttackerPosition = new int[2];
        public int[] DefenderPosition = new int[2];

        /// <summary>
        /// Constructor
        /// </summary>
        public BattlePage (int ThemeIndex)
		{
			InitializeComponent ();
            SetTheme(ThemeIndex);
            
            Battle = new BattleEngine();
            foreach (CharacterModel Character in BattleEngineViewModel.Instance.SelectedCharacters)
            {
                Battle.PopulateCharacterList(Character);
            }
            Battle.StartBattle(false);

            SelectedCharacterList = Battle.CharacterList;
            SelectedMonsterList = Battle.MonsterList;

            LoadCharacters();
            LoadMonsters();

            PickPlayers();

        }
        /// <summary>
        /// Game logic method, called when attacker attacks defender
        /// </summary>
        public async void playBattle()
        {
            Battle.TurnAsAttack(Battle.CurrentAttacker, Battle.CurrentDefender, Battle.CurrentAttacker.ISSpecialAbilityNotUsed);
            //check if battle is over
            if (Battle.CharacterList.Count < 1)
            {
                GameOver();

                return;
            }
            //check if round is over
            if (Battle.MonsterList.Count < 1)
            {
                RoundOver();

                Battle.NewRound(); // new round begun
                SelectedMonsterList = Battle.MonsterList; // initialize monsters based on alive characters
                LoadMonsters();

            }
            PickPlayers(); // pick attacker and defender for next turn
        }

        /// <summary>
        /// Show the Round Over
        /// 
        /// Clear the Board
        /// 
        /// </summary>
        public void RoundOver()
        {
            // Hide the Game Board
            GameUIDisplay.IsVisible = false;

            // Show the Round Over Display
            RoundOverDisplay.IsVisible = true;
        }
        /// <summary>
        /// Show the Score
        /// 
        /// Clear the Board
        /// 
        /// </summary>
        public void GameOver()
        {
            // Hide the Game Board
            GameUIDisplay.IsVisible = false;

            // Show the Game Over Display
            GameOverDisplay.IsVisible = true;
        }
        /// <summary>
        /// Pick the Attacker and Defender for the turn
        /// </summary>
        public void PickPlayers()
        {
            ResetCurrentPlayers();

            Battle.CurrentAttacker = Battle.GetNextPlayerTurn(); //get the attacker
            SetCurrentAttacker();
            if (Battle.CurrentAttacker.ISSpecialAbilityNotUsed == true)
            {
                SpecialAbility.IsEnabled = true;
            }
            CurrentPlayer = Battle.CurrentAttacker;
            CheckPlayerAbilities();

            Battle.CurrentDefender = Battle.AttackChoice(Battle.CurrentAttacker); // get the defender
            SetCurrentDefender();
        }
        /// <summary>
        /// Checking for player abilities and setting the UI elements
        /// </summary>
        private void CheckPlayerAbilities()
        {
            if(CurrentPlayer.PlayerType == PlayerTypeEnum.Monster)
            {
                BackwardButton.IsVisible = false;
                ForwardButton.IsVisible = false;
                UpButton.IsVisible = false;
                DownButton.IsVisible = false;
            }
        }

        /// <summary>
        /// Resetting UI elements for current attacker and defender
        /// </summary>
        private void ResetCurrentPlayers()
        {
            if (Battle.CurrentAttacker != null)
            {
                string AttackerFramePosition = "Frame" + AttackerPosition[0] + AttackerPosition[1];
                Frame AttackerFrame = (Frame)BattleGrid.FindByName(AttackerFramePosition);
                if(AttackerFrame == null)
                {
                    AddImage(Battle.CurrentAttacker.ListOrder, 0); //Column is always 0 because move ability is only for characters
                    RemoveImage(AttackerPosition[0], AttackerPosition[1]);
                }
                else
                {
                    AttackerFrame.IsVisible = false;
                }

            }
            if (Battle.CurrentDefender != null)
            {
                string DefenderFramePosition = "Frame" + DefenderPosition[0] + DefenderPosition[1];
                Frame DefenderFrame = (Frame)BattleGrid.FindByName(DefenderFramePosition);
                DefenderFrame.IsVisible = false;
            }
        }

        /// <summary>
        /// Setting the currentDefender position and UI elements
        /// </summary>
        private void SetCurrentDefender()
        {
            if (Battle.CurrentDefender.PlayerType == PlayerTypeEnum.Character)
            {
                DefenderPosition[1] = 0;
                DefenderPosition[0] = SelectedCharacterMap[Battle.CurrentDefender];
            }
            if (Battle.CurrentDefender.PlayerType == PlayerTypeEnum.Monster)
            {
                DefenderPosition[1] = 5;
                DefenderPosition[0] = SelectedMonsterMap[Battle.CurrentDefender];
            }
            string DefenderFramePosition = "Frame" + DefenderPosition[0] + DefenderPosition[1];
            Frame DefenderFrame = (Frame)BattleGrid.FindByName(DefenderFramePosition);
            DefenderFrame.IsVisible = true;
        }

        /// <summary>
        /// Setting the currentAttacker position and UI elements
        /// </summary>
        private void SetCurrentAttacker()
        {
            if (Battle.CurrentAttacker.PlayerType == PlayerTypeEnum.Character)
            {
                AttackerPosition[1] = 0;
                AttackerPosition[0] = Battle.CurrentAttacker.ListOrder;
            }
            if (Battle.CurrentAttacker.PlayerType == PlayerTypeEnum.Monster)
            {
                AttackerPosition[1] = 5;
                AttackerPosition[0] = Battle.CurrentAttacker.ListOrder; 
            }
            string AttackerFramePosition = "Frame" + AttackerPosition[0] + AttackerPosition[1];
            Frame AttackerFrame = (Frame)BattleGrid.FindByName(AttackerFramePosition);
            AttackerFrame.IsVisible = true;
        }

        /// <summary>
        /// Setting Battle Field background
        /// </summary>
        /// <param name="themeIndex"></param>
        private void SetTheme(int themeIndex)
        {
            //TODO
        }
        /// <summary>
        /// Loading selected characters into the battle grid
        /// </summary>
        private void LoadCharacters()
        {
            for (int i = 0; i < SelectedCharacterList.Count; i++)
            {
                Xamarin.Forms.Image img = new Xamarin.Forms.Image();
                img.Source = SelectedCharacterList[i].ImageURI;
                Grid.SetRow(img, i);
                Grid.SetColumn(img, 0);
                BattleGrid.Children.Add(img);

                SelectedCharacterMap.Add(SelectedCharacterList[i], i);
            }
        }
        /// <summary>
        /// Loading Monsters into the battle grid
        /// </summary>
        private void LoadMonsters()
        {
            for (int i = 0; i < SelectedMonsterList.Count; i++)
            {
                Xamarin.Forms.Image img = new Xamarin.Forms.Image();
                img.Source = SelectedMonsterList[i].ImageURI;
                Grid.SetRow(img, i);
                Grid.SetColumn(img, 5);
                BattleGrid.Children.Add(img);

                SelectedMonsterMap.Add(SelectedMonsterList[i], i);
            }
        }
        /// <summary>
        /// Move character back
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoveBack_Clicked(object sender, EventArgs e)
        {
            if (AttackerPosition[1] - 1 < 1)
                return;
            AttackerPosition[1]--;
            AddImage(AttackerPosition[0], AttackerPosition[1]);
            RemoveImage(AttackerPosition[0], AttackerPosition[1]+1);
        }
        /// <summary>
        /// Move character front
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoveFront_Clicked(object sender, EventArgs e)
        {
            if (AttackerPosition[1] + 1 > 4)
                return;
            AttackerPosition[1]++;
            AddImage(AttackerPosition[0], AttackerPosition[1]);
            RemoveImage(AttackerPosition[0], AttackerPosition[1] - 1);
        }
        /// <summary>
        /// Move character Up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoveUp_Clicked(object sender, EventArgs e)
        {
            if (AttackerPosition[0] - 1 < 0)
                return;
            AttackerPosition[0]--;
            AddImage(AttackerPosition[0], AttackerPosition[1]);
            RemoveImage(AttackerPosition[0]+1, AttackerPosition[1]);
        }
        /// <summary>
        /// Move character down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoveDown_Clicked(object sender, EventArgs e)
        {
            if (AttackerPosition[0] + 1 > 5)
                return;
            AttackerPosition[0]++;
            AddImage(AttackerPosition[0], AttackerPosition[1]);
            RemoveImage(AttackerPosition[0]-1, AttackerPosition[1]);
        }
        /// <summary>
        /// Removing Image from a given position
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        private void RemoveImage(int row, int column)
        {
            foreach (var child in BattleGrid.Children.Where(child => Grid.GetRow(child) == row && Grid.GetColumn(child) == column))
            {
                child.IsVisible = false;
            }
        }
        /// <summary>
        /// Adding Image at a position
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        private void AddImage(int row, int column)
        {
            Xamarin.Forms.Image img = new Xamarin.Forms.Image();
            img.Source = CurrentPlayer.ImageURI;
            Grid.SetRow(img, row);
            Grid.SetColumn(img, column);
            BattleGrid.Children.Add(img);
        }
        /// <summary>
        /// Attack Action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void AttackButton_Clicked(object sender, EventArgs e)
		{
            playBattle();

        }
        /// <summary>
        /// Special Ability Action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void SpecialAbilityButton_Clicked(object sender, EventArgs e)
        {
            //Just for testing
            playBattle();
            Battle.CurrentAttacker.ISSpecialAbilityNotUsed = false;
            if (Battle.CurrentAttacker.ISSpecialAbilityNotUsed == false)
            {
                SpecialAbility.IsEnabled = false;
            }
        }
        /// <summary>
        /// Navigate to pick items page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void PickItemsButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new PickItemsPage()));
           
            RoundOverDisplay.IsVisible = false;

            GameUIDisplay.IsVisible = true;
            
        }
        /// <summary>
        /// Close Round Over Display and Show Battle grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void NextRoundButton_Clicked(object sender, EventArgs e)
        {
            RoundOverDisplay.IsVisible = false;

            GameUIDisplay.IsVisible = true;
        }
        /// <summary>
        /// Show the Game Over Screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public async void ShowScoreButton_Clicked(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ScorePage()));

            GameOverDisplay.IsVisible = false;

            GameUIDisplay.IsVisible = true;

        }

        /// <summary>
        /// Battle Over, so Exit Button
        /// Need to show this for the user to click on.
        /// The Quit does a prompt, exit just exits
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void ExitButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}