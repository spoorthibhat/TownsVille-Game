﻿using Game.Models;
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
        public List<CharacterModel> SelectedCharacterList = BattleEngineViewModel.Instance.SelectedCharacters;
        public Dictionary<CharacterModel,int> SelectedCharacterMap = new Dictionary<CharacterModel, int>();

        public List<PlayerInfoModel> SelectedMonsterList ;
        public Dictionary<PlayerInfoModel, int> SelectedMonsterMap = new Dictionary<PlayerInfoModel, int>();

        public PlayerInfoModel CurrentPlayer;

        public BattleEngine Battle;

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
            foreach (CharacterModel Character in SelectedCharacterList)
            {
                Battle.PopulateCharacterList(Character);
            }
            Battle.StartBattle(false);

            SelectedMonsterList = Battle.MonsterList;

            LoadCharacters();
            LoadMonsters();

            PickPlayers();

        }
        /// <summary>
        /// Pick the Attacker and Defender for the turn
        /// </summary>
        public void PickPlayers()
        {
            Battle.CurrentAttacker = Battle.GetNextPlayerTurn(); //get the attacker
            SetCurrentAttacker();

            CurrentPlayer = Battle.CurrentAttacker;

            Battle.CurrentDefender = Battle.AttackChoice(Battle.CurrentAttacker); // get the defender
            SetCurrentDefender();
        }
        /// <summary>
        /// Setting the currentDefender position and UI elements
        /// </summary>
        private void SetCurrentDefender()
        {
            if (Battle.CurrentDefender.PlayerType == PlayerTypeEnum.Character)
            {
                DefenderPosition[1] = 0;
                DefenderPosition[0] = 0;// SelectedCharacterMap[new CharacterModel(Battle.CurrentAttacker)];
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
                AttackerPosition[0] = 0; // SelectedCharacterMap[new CharacterModel(Battle.CurrentAttacker)];
            }
            if (Battle.CurrentAttacker.PlayerType == PlayerTypeEnum.Monster)
            {
                AttackerPosition[1] = 5;
                AttackerPosition[0] = SelectedMonsterMap[Battle.CurrentAttacker];
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

        private void MoveBack_Clicked(object sender, EventArgs e)
        {
            if (AttackerPosition[1] - 1 < 1)
                return;
            AttackerPosition[1]--;
            Xamarin.Forms.Image img = new Xamarin.Forms.Image();
            img.Source = CurrentPlayer.ImageURI;
            Grid.SetRow(img, AttackerPosition[0]);
            Grid.SetColumn(img, AttackerPosition[1]);
            BattleGrid.Children.Add(img);
            foreach (var child in BattleGrid.Children.Where(child => Grid.GetRow(child) == AttackerPosition[0] && Grid.GetColumn(child) == AttackerPosition[1] + 1))
            {
                child.IsVisible = false;
            }
        }
        private void MoveFront_Clicked(object sender, EventArgs e)
        {
            if (AttackerPosition[1] + 1 > 4)
                return;
            AttackerPosition[1]++;
            Xamarin.Forms.Image img = new Xamarin.Forms.Image();
            img.Source = CurrentPlayer.ImageURI;
            Grid.SetRow(img, AttackerPosition[0]);
            Grid.SetColumn(img, AttackerPosition[1]);
            BattleGrid.Children.Add(img);
            foreach (var child in BattleGrid.Children.Where(child => Grid.GetRow(child) == AttackerPosition[0] && Grid.GetColumn(child) == AttackerPosition[1]-1))
            {
                child.IsVisible = false;
            }
        }
        private void MoveUp_Clicked(object sender, EventArgs e)
        {
            if (AttackerPosition[0] - 1 < 0)
                return;
            AttackerPosition[0]--;
            Xamarin.Forms.Image img = new Xamarin.Forms.Image();
            img.Source = CurrentPlayer.ImageURI;
            Grid.SetRow(img, AttackerPosition[0]);
            Grid.SetColumn(img, AttackerPosition[1]);
            BattleGrid.Children.Add(img);
            foreach (var child in BattleGrid.Children.Where(child => Grid.GetRow(child) == AttackerPosition[0] + 1 && Grid.GetColumn(child) == AttackerPosition[1]))
            {
                child.IsVisible = false;
            }
        }
        private void MoveDown_Clicked(object sender, EventArgs e)
        {
            if (AttackerPosition[0] + 1 > 5)
                return;
            Xamarin.Forms.Image img = new Xamarin.Forms.Image();
            img.Source = CurrentPlayer.ImageURI;
            AttackerPosition[0]++;
            Grid.SetRow(img, AttackerPosition[0]);
            Grid.SetColumn(img, AttackerPosition[1]);
            BattleGrid.Children.Add(img);

            foreach (var child in BattleGrid.Children.Where(child => Grid.GetRow(child) == AttackerPosition[0]-1 && Grid.GetColumn(child) == AttackerPosition[1]))
            {
                child.IsVisible= false;
            }
        }
        /// <summary>
        /// Attack Action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void AttackButton_Clicked(object sender, EventArgs e)
		{
			//DisplayAlert("SU", "Attack !!!", "OK");
            Battle.TurnAsAttack(Battle.CurrentAttacker, Battle.CurrentDefender);
            if (Battle.CharacterList.Count < 1)
            {
                DisplayAlert("Game Over", "Attack !!!", "OK");
            }
            if (Battle.MonsterList.Count < 1)
            {
                //Todo: logic to pick items
                DisplayAlert("Pick Items", "Attack !!!", "OK");
                Battle.NewRound(); // new round begun
                SelectedMonsterList = Battle.MonsterList; // initialize monsters based on alive characters
                LoadMonsters();

                PickPlayers();

            }


        }
        /// <summary>
        /// Special Ability Action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void SpecialAbilityButton_Clicked(object sender, EventArgs e)
        {
            //Just for testing
            await Navigation.PushModalAsync(new NavigationPage(new PickItemsPage()));
        }
    }
}