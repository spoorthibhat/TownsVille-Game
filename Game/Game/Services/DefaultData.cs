using Game.Models;
using System.Collections.Generic;

namespace Game.Services
{
    public static class DefaultData
    {
        /// <summary>
        /// Load the Default data
        /// </summary>
        /// <returns></returns>
        public static List<ItemModel> LoadData(ItemModel temp)
        {
            var datalist = new List<ItemModel>()
            {
                new ItemModel {
                    Name = "Gold Sword",
                    Description = "Sword made of Gold, really expensive looking",
                    ImageURI = "http://www.clker.com/cliparts/e/L/A/m/I/c/sword-md.png",
                    Range = 0,
                    Damage = 9,
                    Value = 9,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Defense},

                new ItemModel {
                    Name = "Strong Shield",
                    Description = "Enough to hide behind",
                    ImageURI = "http://www.clipartbest.com/cliparts/4T9/LaR/4T9LaReTE.png",
                    Range = 0,
                    Damage = 0,
                    Value = 9,
                    Location = ItemLocationEnum.OffHand,
                    Attribute = AttributeEnum.Defense},

                new ItemModel {
                    Name = "Bunny Hat",
                    Description = "Pink hat with fluffy ears",
                    ImageURI = "http://www.clipartbest.com/cliparts/yik/e9k/yike9kMyT.png",
                    Range = 0,
                    Damage = 0,
                    Value = 9,
                    Location = ItemLocationEnum.Head,
                    Attribute = AttributeEnum.Speed},
            };

            return datalist;
        }

        public static List<ScoreModel> LoadData(ScoreModel temp)
        {
            var datalist = new List<ScoreModel>()
            {
                new ScoreModel {
                    Name = "First Score",
                    Description = "Test Data",
                },

                new ScoreModel {
                    Name = "Second Score",
                    Description = "Test Data",
                }
            };

            return datalist;
        }

        public static List<CharacterModel> LoadData(CharacterModel temp)
        {
            var datalist = new List<CharacterModel>()
            { new CharacterModel{
                Name = "Blossom",
                Description = "Self-proclaimed leader of the Powerpuff Girls",
                ImageURI = "Blossum.png",
                Level = 1,
                SpecialAbility = SpecialAbilityEnum.LaserEyes,

            },
            new CharacterModel{
                Name = "Bubbles",
                Description = "She is the emotional glue of the superhero trio",
                ImageURI = "Bubbles.png",
                Level = 1,
                SpecialAbility = SpecialAbilityEnum.Armour,
            },
            new CharacterModel{
                Name = "Buttercup",
                Description = "She is the bravest of the Powerpuff Girls",
                ImageURI = "Buttercup.png",
                Level = 1,
                SpecialAbility = SpecialAbilityEnum.LaserEyes,
            },
             new CharacterModel{
                Name = "Mayor",
                Description = "He is the mayor of townsville",
                ImageURI = "mayor.png",
                Level = 1,
                SpecialAbility = SpecialAbilityEnum.LaserEyes,
            },
                new CharacterModel{
                Name = "Professor",
                Description = "He is creator of powerpuff girls",
                ImageURI = "professor_utonium.png",
                Level = 1,
                SpecialAbility = SpecialAbilityEnum.LaserEyes,
            },

            };
            return datalist;
        }
        public static List<MonsterModel> LoadData(MonsterModel temp)
        {
            var datalist = new List<MonsterModel>()
            { 
            new MonsterModel{
                Name = "Mojo jojo",
                Description = "He is the master mind",
                ImageURI = "mojo_jojo.png",
                Level = 1,

            },
            new MonsterModel{
                Name = "Him",
                Description = "He is most evil",
                ImageURI = "him.png",
                Level = 1,
             
            },
             new MonsterModel{
                Name = "Amoeba boys",
                Description = "They spread ill ness",
                ImageURI = "amoeba_boys.png",
                Level = 1,
               
            },
                new MonsterModel{
                Name = "Rowdy boys",
                Description = "They are rough",
                ImageURI = "rowdy_boys.png",
                Level = 1,
                
            },

            };
            return datalist;
        }
        /// <summary>
        /// Loads the default available character images
        /// </summary>
        /// <returns></returns>
        public static List<Image> LoadCharacterImages()
        {
            var imageList = new List<Image>()
            {
                new Image { Url = "Blossum.png" },
                new Image { Url = "Bubbles.png" },
                new Image { Url = "Buttercup.png" },
                new Image { Url = "utonium.png" },
                new Image { Url = "ms_keane.png" },
                new Image { Url = "mayor.png" },
            };
            return imageList;
        }

        /// <summary>
        /// Loads the default available item images
        /// </summary>
        /// <returns></returns>
        public static List<Image> LoadItemImages()
        {
            var imageList = new List<Image>()
            {
                new Image { Url = "item_flaming_sword.png" },
                new Image { Url = "slashing_knives.png" },
                new Image { Url = "heat_shield.png" },
                new Image { Url = "thunderbolt.png" },
                new Image { Url = "helmet.png" },
                new Image { Url = "mayor.png" },
            };
            return imageList;
        }
    }
}