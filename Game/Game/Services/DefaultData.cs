using Game.Helpers;
using Game.Models;
using System.Collections.Generic;

namespace Game.Services
{
    public static class DefaultData
    {

        public static List<ItemModel> HeadList = new List<ItemModel>()
        {
            new ItemModel {
                    Name = "Helmet",
                    Description = "Protect head from attack",
                    ImageURI = "helmet.png",
                    Range = 0,
                    Damage = 0,
                    Value = 9,
                    Location = ItemLocationEnum.Head,
                    Attribute = AttributeEnum.Speed},
            new ItemModel {
                    Name = "Firing Crown",
                    Description = "Attacks from the crown gem",
                    ImageURI = "firing_crown.png",
                    Range = 0,
                    Damage = 0,
                    Value = 5,
                    Location = ItemLocationEnum.Head,
                    Attribute = AttributeEnum.Attack},
        };

        public static List<ItemModel> FeetList = new List<ItemModel>()
        {
            new ItemModel {
                    Name = "Absorbing Shoes",
                    Description = "Protect against powerful radiation",
                    ImageURI = "absorbing_shoes.png",
                    Range = 0,
                    Damage = 5,
                    Value = 5,
                    Location = ItemLocationEnum.Feet,
                    Attribute = AttributeEnum.Defense},
            new ItemModel {
                    Name = "Warm sock",
                    Description = "Protects against ice and fire attacks",
                    ImageURI = "warm_sock.png",
                    Range = 0,
                    Damage = 0,
                    Value = 5,
                    Location = ItemLocationEnum.Feet,
                    Attribute = AttributeEnum.Defense},
        };

        public static List<ItemModel> PrimaryHandList = new List<ItemModel>()
        {
            new ItemModel {
                    Name = "Slashing Knives",
                    Description = "Attack with Sharp knives",
                    ImageURI = "slashing_knives.png",
                    Range = 0,
                    Damage = 10,
                    Value = 10,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Attack},
            new ItemModel {
                    Name = "Thunder bolt",
                    Description = "Electric shock attack",
                    ImageURI = "thunderbolt.png",
                    Range = 0,
                    Damage = 5,
                    Value = 5,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Attack},
        };

        public static List<ItemModel> OffHandList = new List<ItemModel>()
        {
            new ItemModel {
                    Name = "Heat shield",
                    Description = "Protect against heat",
                    ImageURI = "heat_shield.png",
                    Range = 0,
                    Damage = 0,
                    Value = 10,
                    Location = ItemLocationEnum.OffHand,
                    Attribute = AttributeEnum.Defense},
        };

        public static List<ItemModel> NecklassList = new List<ItemModel>()
        {
        new ItemModel {
                    Name = "Poisonous pearls",
                    Description = "Pearls thrown from this release poisonous gas",
                    ImageURI = "poisonous_pearls.png",
                    Range = 0,
                    Damage = 0,
                    Value = 5,
                    Location = ItemLocationEnum.Necklass,
                    Attribute = AttributeEnum.Attack
    },
                new ItemModel {
                    Name = "Muffler",
                    Description = "Protects against heat and cold",
                    ImageURI = "muffler.png",
                    Range = 0,
                    Damage = 0,
                    Value = 5,
                    Location = ItemLocationEnum.Necklass,
                    Attribute = AttributeEnum.Defense
},
        };

        public static List<ItemModel> LeftFingerList = new List<ItemModel>()
            {
            new ItemModel {
                    Name = "Ring of Blocking",
                    Description = "Creates a wall of blocking",
                    ImageURI = "ring_of_blocking.png",
                    Range = 0,
                    Damage = 0,
                    Value = 5,
                    Location = ItemLocationEnum.LeftFinger,
                    Attribute = AttributeEnum.Defense
    },
            };

        public static List<ItemModel> RightFingerList = new List<ItemModel>()
        {
            new ItemModel {
                    Name = "Ring of Attack",
                    Description = "Sends a beam of fire from the ring",
                    ImageURI = "bracelet_of_attack.png",
                    Range = 0,
                    Damage = 0,
                    Value = 5,
                    Location = ItemLocationEnum.RightFinger,
                    Attribute = AttributeEnum.Attack},
        };
        /// <summary>
        /// Load the Default data
        /// </summary>
        /// <returns></returns>
        public static List<ItemModel> LoadData(ItemModel temp)
        {
            var datalist = new List<ItemModel>()
            {
                HeadList[0],
                HeadList[1],
                FeetList[0],
                FeetList[1],
                NecklassList[0],
                NecklassList[1],
                RightFingerList[0],
                LeftFingerList[0],
                PrimaryHandList[0],
                PrimaryHandList[1],
                OffHandList[0],

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
                SpecialAbility = SpecialAbilityEnum.Laser_Eyes,
                Head = HeadList[0].Id,

        },
            new CharacterModel{
                Name = "Bubbles",
                Description = "She is the emotional glue of the superhero trio",
                ImageURI = "Bubbles.png",
                Level = 1,
                SpecialAbility = SpecialAbilityEnum.Freeze,
                Feet = FeetList[0].Id,
            },
            new CharacterModel{
                Name = "Buttercup",
                Description = "She is the bravest of the Powerpuff Girls",
                ImageURI = "Buttercup.png",
                Level = 1,
                SpecialAbility = SpecialAbilityEnum.Laser_Eyes,
                PrimaryHand = PrimaryHandList[0].Id,
            },
             new CharacterModel{
                Name = "Mayor",
                Description = "He is the mayor of townsville",
                ImageURI = "mayor.png",
                Level = 1,
                SpecialAbility = SpecialAbilityEnum.Laser_Eyes,
                Necklace = NecklassList[0].Id,
            },
                new CharacterModel{
                Name = "Professor",
                Description = "He is creator of powerpuff girls",
                ImageURI = "professor_utonium.png",
                Level = 1,
                SpecialAbility = SpecialAbilityEnum.Laser_Eyes,
                RightFinger = RightFingerList[0].Id,
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
                Head = HeadList[0].Id,

            },
            new MonsterModel{
                Name = "Him",
                Description = "He is most evil",
                ImageURI = "him.png",
                Level = 1,
                Feet = FeetList[0].Id,

            },
             new MonsterModel{
                Name = "Amoeba boys",
                Description = "They spread ill ness",
                ImageURI = "amoeba_boys.png",
                Level = 1,
                PrimaryHand = PrimaryHandList[1].Id,

            },
                new MonsterModel{
                Name = "Rowdy boys",
                Description = "They are rough",
                ImageURI = "rowdy_boys.png",
                Level = 1,
                Necklace = NecklassList[1].Id,
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
                new Image { Url = "safe_bubble.png" },
                new Image { Url = "slashing_knives.png" },
                new Image { Url = "heat_shield.png" },
                new Image { Url = "thunderbolt.png" },
                new Image { Url = "helmet.png" },
                new Image { Url = "absorbing_shoes.png" },
                new Image {Url = "bracelet_of_attack.png"},
                new Image {Url = "muffler.png"},
                new Image {Url = "poisonous_pearls.png"},
                new Image {Url = "warm_sock.png"},
                new Image {Url = "firing_crown.png"}
            };
            return imageList;
        }

        /// <summary>
        /// Loads the default available Monster images
        /// </summary>
        /// <returns></returns>
        public static List<Image> LoadMonsterImages()
        {
            var imageList = new List<Image>()
            {
                new Image { Url = "mojo_jojo.png" },
                new Image { Url = "him.png" },
                new Image { Url = "amoeba_boys.png" },
                new Image { Url = "rowdy_boys.png" },
                new Image { Url = "princess_morbucks.png" },
                new Image { Url = "gang_green.png" },
            };
            return imageList;
        }

    }
}