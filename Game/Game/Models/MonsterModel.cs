﻿using Game.Services;
using Game.Helpers;
using SQLite;

namespace Game.Models
{
    public class MonsterModel : CharacterMonsterBaseModel<MonsterModel>
    {
    
        
        
        // Items to be added

        /// <summary>
        /// Default MonsterModel
        /// Initialize Values
        /// </summary>

        public MonsterModel()
        {
            this.PlayerType = PlayerTypeEnum.Monster;
            ImageURI = ItemService.DefaultImageURI;
            this.Name = "This is a Monster";
            this.Description = "Monster Description";
            this.ImageURI = "default_character.png";
            this.Attack = 100;
        }

        /// <summary>
        /// Constructor to create monster based on what is passed in
        /// </summary>
        /// <param name="data"></param>
        public MonsterModel(MonsterModel data)
        {
            Update(data);
        }

        /// <summary>
        /// Update monster
        /// </summary>
        /// <param name="newdata"></param>
        public override bool Update(MonsterModel newData)
        {
            if (newData == null)
            {
                return false;
            }
            Name = newData.Name;
            Description = newData.Description;
            ImageURI = newData.ImageURI;
            Alive = newData.Alive;
            Level = newData.Level;
            ExperienceTotal = newData.ExperienceTotal;
            Speed = newData.Speed;
            Attack = newData.Attack;
            Defense = newData.Defense;
            CurrentHealth = newData.CurrentHealth;
            MaxHealth = newData.MaxHealth;
            Head = newData.Head;
            Necklace = newData.Necklace;
            PrimaryHand = newData.PrimaryHand;
            OffHand = newData.OffHand;
            RightFinger = newData.RightFinger;
            LeftFinger = newData.LeftFinger;
            Feet = newData.Feet;
            return true;
        }

        /// <summary>
        /// Scales the level of the monster
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public bool ScaleLevel(int Level)
        {
            this.Level = Level;
            this.ExperiencePoints = LevelTableHelper.Instance.LevelDetailsList[Level].Experience;
            this.Attack = LevelTableHelper.Instance.LevelDetailsList[Level].Attack;
            this.Speed = LevelTableHelper.Instance.LevelDetailsList[Level].Speed;
            this.Defense = LevelTableHelper.Instance.LevelDetailsList[Level].Defense;
            return true;
        }


    }
}
