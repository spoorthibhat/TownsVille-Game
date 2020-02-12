﻿using Game.Services;

namespace Game.Models
{
    public class MonsterModel : BaseModel<MonsterModel>
    {
        
        //Flag to check if the character is alive
        public bool Alive { get; set; } = true;
        //Level of the character
        public int Level { get; set; } = 1;
        //Total Experience of the character
        public int ExperienceTotal { get; set; } = 300;
        //Speed of the character
        public int Speed { get; set; } = 1;
        //Attack caused by character
        public int Attack { get; set; } = 0;
        //Characters defense
        public int Defense { get; set; } = 0;
        //Current health of character
        public int CurrentHealth { get; set; } = 1;
        //Max health of character
        public int MaxHealth { get; set; } = 1;

        // Item possessed by the character
        public ItemModel ItemPossesed { get; set; } = null;

        // Items to be added

        /// <summary>
        /// Default CharacterModel
        /// Initialize Values
        /// </summary>

        public MonsterModel()
        {
            ImageURI = ItemService.DefaultImageURI;
            this.Name = "This is a Monster";
            this.Description = "Monster Description";
            this.ImageURI = "default_character.png";
        }

        /// <summary>
        /// Constructor to create character based on what is passed in
        /// </summary>
        /// <param name="data"></param>
        public MonsterModel(MonsterModel data)
        {
            Update(data);
        }

        /// <summary>
        /// Update character
        /// </summary>
        /// <param name="newdata"></param>
        public override void Update(MonsterModel newData)
        {
            if (newData == null)
            {
                return;
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
            ItemPossesed = newData.ItemPossesed;
     
        }
    }
}