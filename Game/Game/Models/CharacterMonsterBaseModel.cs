﻿using Game.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Models
{
    public class CharacterMonsterBaseModel<T> : BaseModel<T>
    {
        //Flag to check if the character/monster is alive
        public bool Alive { get; set; } = true;

        //Level of the character/monster
        public int Level { get; set; } = 1;

        //Total Experience of the character/monster
        public int ExperienceTotal { get; set; } = 300;

        //Speed of the character/monster
        public int Speed { get; set; } = 0;

        //Attack caused by character/monster
        public int Attack { get; set; } = 0;

        //monsters character/monster
        public int Defense { get; set; } = 0;

        //Current health of character/monster
        public int CurrentHealth { get; set; } = 1;

        //Max health of monster
        public int MaxHealth { get; set; } = 1;

        // Item in head
        public ItemModel Head { get; set; } = null;

        // Item in feet
        public ItemModel Feet { get; set; } = null;

        // Item in Necklace
        public ItemModel Necklace { get; set; } = null;

        // Item in right finger
        public ItemModel RightFinger { get; set; } = null;

        //  Item in LeftFinger
        public ItemModel LeftFinger { get; set; } = null;

        // Item in PrimaryHand
        public ItemModel PrimaryHand { get; set; } = null;

        // Item on Body
        public ItemModel Body { get; set; } = null;

        /// <summary>
        /// Scales the level of the monster
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public bool ScaleLevel(int Level)
        {
            this.Level = Level;
            return true;
        }

        /// <summary>
        /// Levels up the monster if it is time to level up
        /// </summary>
        /// <returns></returns>
        public bool LevelUp()
        {
            int newLevel = ExperienceMappingHelper.GetLevelPerExperience(this.ExperienceTotal);
            if (newLevel > this.Level)
            {
                this.Level = newLevel;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Force level up to particular value on the monster
        /// </summary>
        /// <param name="Level"></param>
        public void LevelUpToValue(int Level)
        {
            this.Level = Level;
        }

        /// <summary>
        /// Adds the input value to the expereince of the monster.
        /// This is needed during the game play
        /// </summary>
        /// <param name="ExtraExperienceToAdd"></param>
        public void AddExperience(int ExtraExperienceToAdd)
        {
            this.ExperienceTotal += ExtraExperienceToAdd;
        }

        /// <summary>
        /// Based on the weapon damage input, makes changes in the monster's health
        /// </summary>
        /// <param name="DamageFromItem"></param>
        public void TakeDamage(int DamageFromItem)
        {
            int LevelDamage = this.Level * 1 / 4;
            int TotalDamage = LevelDamage + DamageFromItem;
            this.CurrentHealth = this.CurrentHealth - TotalDamage;
        }
    }
}