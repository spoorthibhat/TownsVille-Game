using NUnit.Framework;

using Game.Engine;
using Game.Models;
using System.Threading.Tasks;
using Game.Helpers;
using System.Linq;
using Game.ViewModels;

namespace Scenario
{
    [TestFixture]
    public class HackathonScenarioTests
    {
        BattleEngineViewModel EngineViewModel = BattleEngineViewModel.Instance;

        AutoBattleEngine AutoBattleEngine;
        BattleEngine BattleEngine;

        [SetUp]
        public void Setup()
        {
            AutoBattleEngine = EngineViewModel.AutoBattleEngine;
            BattleEngine = EngineViewModel.Engine;
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void HakathonScenario_Constructor_0_Default_Should_Pass()
        {
            /* 
            * Scenario Number:  
            *      #
            *      
            * Description: 
            *      <Describe the scenario>
            * 
            * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
            *      <List Files Changed>
            *      <List Classes Changed>
            *      <List Methods Changed>
            * 
            * Test Algrorithm:
            *      <Step by step how to validate this change>
            * 
            * Test Conditions:
            *      <List the different test conditions to make>
            * 
            * Validation:
            *      <List how to validate this change>
            *  
            */

            // Arrange

            // Act

            // Assert
           

            // Act
            var result = EngineViewModel;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task HackathonScenario_Scenario_1_Default_Should_Pass()
        {
            /* 
            * Scenario Number:  
            *      1
            *      
            * Description: 
            *      Make a Character called Mike, who dies in the first round
            * 
            * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
            *      No Code changes requied 
            * 
            * Test Algrorithm:
            *      Create Character named Mike
            *      Set speed to -1 so he is really slow
            *      Set Max health to 1 so he is weak
            *      Set Current Health to 1 so he is weak
            *  
            *      Startup Battle
            *      Run Auto Battle
            * 
            * Test Conditions:
            *      Default condition is sufficient
            * 
            * Validation:
            *      Verify Battle Returned True
            *      Verify Mike is not in the Player List
            *      Verify Round Count is 1
            *  
            */

            //Arrange

            // Set Character Conditions

            EngineViewModel.Engine.MaxNumberPartyCharacters = 1;

            var CharacterPlayerMike = new PlayerInfoModel(
                            new CharacterModel
                            {
                                Speed = -1, // Will go last...
                                Level = 1,
                                CurrentHealth = 1,
                                ExperienceTotal = 1,
                                //ExperienceRemaining = 1,
                                Name = "Mike",
                            });

            EngineViewModel.Engine.CharacterList.Add(CharacterPlayerMike);

            // Set Monster Conditions

            // Auto Battle will add the monsters


            //Act
            var result = await AutoBattleEngine.RunAutoBattle();

            //Reset

            //Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(null, AutoBattleEngine.PlayerList.Find(m => m.Name.Equals("Mike")));
            Assert.AreEqual(1, AutoBattleEngine.BattleScore.RoundCount);
        }

        [Test]
        public async Task HackathonScenario_Scenario_2_Character_Bob_Should_Miss()
        {
            /* 
             * Scenario Number:  
             *  2
             *  
             * Description: 
             *      Make a Character called Bob
             *      Bob Always Misses
             *      Other Characters Always Hit
             * 
             * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
             *      Change to Turn Engine
             *      Changed TurnAsAttack method
             *      Check for Name of Bob and return miss
             *                 
             * Test Algrorithm:
             *  Create Character named Bob
             *  Create Monster
             *  Call TurnAsAttack
             * 
             * Test Conditions:
             *  Test with Character of Named Bob
             *  Test with Character of any other name
             * 
             * Validation:
             *      Verify Enum is Miss
             *  
             */

            //Arrange

            // Set Character Conditions

            BattleEngine.MaxNumberPartyCharacters = 1;

            var CharacterPlayer = new PlayerInfoModel(
                            new CharacterModel
                            {
                                Speed = 200,
                                Level = 10,
                                CurrentHealth = 100,
                                ExperienceTotal = 100,
                                //ExperienceRemaining = 1,
                                Name = "Bob",
                            });

            BattleEngine.CharacterList.Add(CharacterPlayer);

            // Set Monster Conditions

            // Add a monster to attack
            BattleEngine.MaxNumberPartyCharacters = 1;

            var MonsterPlayer = new PlayerInfoModel(
                new MonsterModel
                {
                    Speed = 1,
                    Level = 1,
                    CurrentHealth = 1,
                    ExperienceTotal = 1,
                    //ExperienceRemaining = 1,
                    Name = "Monster",
                });

            BattleEngine.CharacterList.Add(MonsterPlayer);

            // Have dice rull 19
            DiceHelper.EnableRandomValues();
            DiceHelper.SetForcedRandomValue(19);

            //Act
            var result = BattleEngine.TurnAsAttack(CharacterPlayer, MonsterPlayer,false);

            //Reset
            DiceHelper.DisableRandomValues();

            //Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(HitStatusEnum.Miss, BattleEngine.BattleMessagesModel.HitStatus);
        }
        [Test]
        public async Task HackathonScenario_Scenario_2_Character_Not_Bob_Should_Hit()
        {
            /* 
             * Scenario Number:  
             *      2
             *      
             * Description: 
             *      See Default Test
             * 
             * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
             *      See Defualt Test
             *                 
             * Test Algrorithm:
             *      Create Character named Mike
             *      Create Monster
             *      Call TurnAsAttack so Mike can attack Monster
             * 
             * Test Conditions:
             *      Control Dice roll so natural hit
             *      Test with Character of not named Bob
             *  
             *  Validation
             *      Verify Enum is Hit
             *      
             */

            //Arrange

            // Set Character Conditions

            BattleEngine.MaxNumberPartyCharacters = 1;

            var CharacterPlayer = new PlayerInfoModel(
                            new CharacterModel
                            {
                                Speed = 200,
                                Level = 10,
                                CurrentHealth = 100,
                                ExperienceTotal = 100,
                                //ExperienceRemaining = 1,
                                Name = "Mike",
                            });

            BattleEngine.CharacterList.Add(CharacterPlayer);

            // Set Monster Conditions

            // Add a monster to attack
            BattleEngine.MaxNumberPartyCharacters = 1;

            var MonsterPlayer = new PlayerInfoModel(
                new MonsterModel
                {
                    Speed = 1,
                    Level = 1,
                    CurrentHealth = 1,
                    ExperienceTotal = 1,
                    //ExperienceRemaining = 1,
                    Name = "Monster",
                });

            BattleEngine.CharacterList.Add(MonsterPlayer);

            // Have dice roll 20
            DiceHelper.EnableRandomValues();
            DiceHelper.SetForcedRandomValue(20);

            //Act
            var result = BattleEngine.TurnAsAttack(CharacterPlayer, MonsterPlayer,false);

            //Reset
            DiceHelper.DisableRandomValues();

            //Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(HitStatusEnum.Hit, BattleEngine.BattleMessagesModel.HitStatus);
        }
        [Test]
        public async Task HackathonScenario_Scenario_3_Monster_Hit_Status_Should_SetToGivenValue()
        {
            /* 
             * Scenario Number:  
             *  3
             *  
             * Description: 
             *      Set Monsters to hit as per given hitStatus value
             * 
             * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
             *      Change to Turn Engine
             *      Changed TurnAsAttack method
             *      Check for MonsterHitStatus
             *                 
             * Test Algrorithm:
             *  Set Monster Hit Status
             *  Create Monster
             *  Call TurnAsAttack
             * 
             * Test Conditions:
             *  Test with MonsterHitStatus set to 15
             * 
             * Validation:
             *      Verify Enum is Hit
             *  
             */

            //Arrange

            // Set Character Conditions

            BattleEngine.MaxNumberPartyCharacters = 1;

            var CharacterPlayer = new PlayerInfoModel(
                            new CharacterModel
                            {
                                Speed = 1,
                                Level = 1,
                                CurrentHealth = 1,
                                ExperienceTotal = 1,
                                //ExperienceRemaining = 1,
                                Name = "Character",
                            });

            BattleEngine.CharacterList.Add(CharacterPlayer);

            // Set Monster Conditions

            // Add a monster to attack
            BattleEngine.MaxNumberPartyMonsters = 1;

            var MonsterPlayer = new PlayerInfoModel(
                new MonsterModel
                {
                    Speed = 200,
                    Level = 10,
                    CurrentHealth = 100,
                    ExperienceTotal = 100,
                    //ExperienceRemaining = 1,
                    Name = "SetHitMonster",
                });

            BattleEngine.MonsterList.Add(MonsterPlayer);

            BattleEngine.MonsterHitValue = 15;
            //Act
            var result = BattleEngine.TurnAsAttack(MonsterPlayer, CharacterPlayer, false);

            //Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(HitStatusEnum.Hit, BattleEngine.BattleMessagesModel.HitStatus);
        }
        [Test]
        public async Task HackathonScenario_Scenario_3_Character_Hit_Status_Should_SetToGivenValue()
        {
            /* 
             * Scenario Number:  
             *  3
             *  
             * Description: 
             *      Set characters to hit as per given hitStatus value
             * 
             * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
             *      Change to Turn Engine
             *      Changed TurnAsAttack method
             *      Check for CharacterHitStatus
             *                 
             * Test Algrorithm:
             *  Set Character Hit Status
             *  Create Monster
             *  Call TurnAsAttack
             * 
             * Test Conditions:
             *  Test with CharacterHitStatus set to 15
             * 
             * Validation:
             *      Verify Enum is Hit
             *  
             */

            //Arrange

            // Set Character Conditions

            BattleEngine.MaxNumberPartyCharacters = 1;

            var CharacterPlayer = new PlayerInfoModel(
                            new CharacterModel
                            {
                                Speed = 200,
                                Level = 10,
                                CurrentHealth = 100,
                                ExperienceTotal = 100,
                                //ExperienceRemaining = 1,
                                Name = "SetHitCharacter",
                            });

            BattleEngine.CharacterList.Add(CharacterPlayer);

            // Set Monster Conditions

            // Add a monster to attack
            BattleEngine.MaxNumberPartyMonsters = 1;

            var MonsterPlayer = new PlayerInfoModel(
                new MonsterModel
                {
                    Speed = 1,
                    Level = 1,
                    CurrentHealth = 1,
                    ExperienceTotal = 1,
                    //ExperienceRemaining = 1,
                    Name = "Monster",
                });

            BattleEngine.MonsterList.Add(MonsterPlayer);

            BattleEngine.CharacterHitValue = 15;
            //Act
            var result = BattleEngine.TurnAsAttack(CharacterPlayer, MonsterPlayer, false);

            //Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(HitStatusEnum.Hit, BattleEngine.BattleMessagesModel.HitStatus);
        }
        [Test]
        public async Task HackathonScenario_Scenario_33_Character_Die_On_Round13()
        {
            /* 
            * Scenario Number:  
            *      33
            *      
            * Description: 
            *      Make a Character, who dies in the round 13 and health is set to 0
            * 
            * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
            *      Change to Turn Engine
            *      Changed TurnAsAttack method
            *      Check for Round Number 
            * 
            * Test Algrorithm:
            *      Create Character and monster
            *      Set Current Health of character to 400 so he is strong and battle continues for more than 13 rounds
            *  
            *      Startup Battle
            *      Run Auto Battle
            * 
            * Test Conditions:
            *      Default condition is sufficient
            * 
            * Validation:
            *      Verify Battle Returned True
            *      Verify character is not in the Player List
            *      Verify Round Count is 13
            *  
            */

            //Arrange

            // Set Character Conditions

            AutoBattleEngine.MaxNumberPartyCharacters = 1;

            var CharacterPlayerMike = new PlayerInfoModel(
                            new CharacterModel
                            {
                                Speed = 1,
                                Level = 1,
                                CurrentHealth = 400,
                                ExperienceTotal = 1,
                                //ExperienceRemaining = 1,
                                Name = "Character",
                            });

            AutoBattleEngine.CharacterList.Add(CharacterPlayerMike);

            // Set Monster Conditions
            AutoBattleEngine.MaxNumberPartyMonsters = 1;

            var MonsterPlayer = new PlayerInfoModel(
                new MonsterModel
                {
                    Speed = 1,
                    Level = 1,
                    CurrentHealth = 1,
                    ExperienceTotal = 1,
                    //ExperienceRemaining = 1,
                    Name = "Monster",
                });

            AutoBattleEngine.MonsterList.Add(MonsterPlayer);
            
            //Act
            var result = await AutoBattleEngine.RunAutoBattle();

            //Reset

            //Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(null, AutoBattleEngine.PlayerList.Find(m => m.Name.Equals("Character")));
            Assert.AreEqual(13, AutoBattleEngine.BattleScore.RoundCount);
        }

    }
}