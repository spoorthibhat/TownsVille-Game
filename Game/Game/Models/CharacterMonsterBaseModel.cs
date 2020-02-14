using Game.Helpers;
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
        public string Head { get; set; } = null;

        // Item in feet
        public string Feet { get; set; } = null;

        // Item in Necklace
        public string Necklace { get; set; } = null;

        // Item in right finger
        public string RightFinger { get; set; } = null;

        //  Item in LeftFinger
        public string LeftFinger { get; set; } = null;

        // Item in PrimaryHand
        public string PrimaryHand { get; set; } = null;

        // Item on Body
        public string OffHand { get; set; } = null;

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

        
        /// <summary>
        /// Returns list of all items possessed.
        /// </summary>
        /// <returns></returns>
        public List<ItemModel> DropAllItems()
        {
            var DroppedItems = new List<ItemModel>();
            if(this.Head != null)
            {
                DroppedItems.Add(ItemModelHelper.GetItemModelFromGuid(this.Head));
                this.Head = null;
            }

            if (this.Feet != null)
            {
                DroppedItems.Add(ItemModelHelper.GetItemModelFromGuid(this.Feet));
                this.Feet = null;
            }

            if (this.Necklace != null)
            {
                DroppedItems.Add(ItemModelHelper.GetItemModelFromGuid(this.Necklace));
                this.Necklace = null;
            }

            if (this.LeftFinger != null)
            {
                DroppedItems.Add(ItemModelHelper.GetItemModelFromGuid(this.LeftFinger));
                this.LeftFinger = null;
            }

            if (this.RightFinger != null)
            {
                DroppedItems.Add(ItemModelHelper.GetItemModelFromGuid(this.RightFinger));
                this.RightFinger = null;
            }

            if (this.PrimaryHand != null)
            {
                DroppedItems.Add(ItemModelHelper.GetItemModelFromGuid(this.PrimaryHand));
                this.PrimaryHand = null;
            }

            if (this.OffHand != null)
            {
                DroppedItems.Add(ItemModelHelper.GetItemModelFromGuid(this.OffHand));
                this.OffHand = null;
            }

            return DroppedItems;
        }
        

        /// <summary>
        /// Gets item per the location input
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public ItemModel GetItemByLocation(ItemLocationEnum Location)
        {
            switch (Location)
            {
                case ItemLocationEnum.Head:
                    return ItemModelHelper.GetItemModelFromGuid(this.Head);
                case ItemLocationEnum.Feet:
                    return ItemModelHelper.GetItemModelFromGuid(this.Feet);
                case ItemLocationEnum.LeftFinger:
                    return ItemModelHelper.GetItemModelFromGuid(this.LeftFinger);
                case ItemLocationEnum.RightFinger:
                    return ItemModelHelper.GetItemModelFromGuid(this.RightFinger);
                case ItemLocationEnum.PrimaryHand:
                    return ItemModelHelper.GetItemModelFromGuid(this.PrimaryHand);
                case ItemLocationEnum.Necklass:
                    return ItemModelHelper.GetItemModelFromGuid(this.Necklace);
                case ItemLocationEnum.OffHand:
                    return ItemModelHelper.GetItemModelFromGuid(this.OffHand);
                default:
                    return null;
            }
        }

        /*
        /// <summary>
        /// Adds the Item to the location
        /// </summary>
        /// <param name="Location"></param>
        /// <param name="ToBeAdded"></param>
        public void AddItem(ItemLocationEnum Location, ItemModel ToBeAdded)
        {
            switch (Location)
            {
                case ItemLocationEnum.Head:
                    this.Head = ToBeAdded;
                    break;
                case ItemLocationEnum.Feet:
                    this.Feet = ToBeAdded;
                    break;
                case ItemLocationEnum.LeftFinger:
                    this.LeftFinger = ToBeAdded;
                    break;
                case ItemLocationEnum.RightFinger:
                    this.RightFinger = ToBeAdded;
                    break;
                case ItemLocationEnum.PrimaryHand:
                    this.PrimaryHand = ToBeAdded;
                    break;
                case ItemLocationEnum.Necklass:
                    this.Necklace = ToBeAdded;
                    break;
                case ItemLocationEnum.OffHand:
                    this.OffHand = ToBeAdded;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Removes the Item from the given location
        /// </summary>
        /// <param name="Location"></param>
        public void RemoveItemFromLocation(ItemLocationEnum Location)
        {
            switch (Location)
            {
                case ItemLocationEnum.Head:
                    this.Head = null;
                    break;
                case ItemLocationEnum.Feet:
                    this.Feet = null;
                    break;
                case ItemLocationEnum.LeftFinger:
                    this.LeftFinger = null;
                    break;
                case ItemLocationEnum.RightFinger:
                    this.RightFinger = null;
                    break;
                case ItemLocationEnum.PrimaryHand:
                    this.PrimaryHand = null;
                    break;
                case ItemLocationEnum.Necklass:
                    this.Necklace = null;
                    break;
                case ItemLocationEnum.OffHand:
                    this.OffHand = null;
                    break;
                default:
                    break;
            }
            
        }
        */
    }
}
