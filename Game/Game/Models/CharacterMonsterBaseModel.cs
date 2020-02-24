using Game.Helpers;
using Game.ViewModels;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Models
{
    public class CharacterMonsterBaseModel<T> : BaseModel<T>
    {
        #region GameEngineAttributes
        // alive status, !alive will be removed from the list
        [Ignore]
        public bool Alive { get; set; } = true;

        // The type of player, character comes before monster
        [Ignore]
        public PlayerTypeEnum PlayerType { get; set; } = PlayerTypeEnum.Unknown;

        // TurnOrder
        [Ignore]
        public int Order { get; set; } = 0;

        // Remember who was first into the list...
        [Ignore]
        public int ListOrder { get; set; } = 0;

        #endregion GameEngineAttributes

        

        //Level of the character/monster
        public int Level { get; set; } = 1;

        //Total Experience of the character/monster
        public int ExperienceTotal { get; set; } = 300;

        public int ExperiencePoints { get; set; } = 0;

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


        #region Attack        
        [Ignore]
        // Return the attack value
        public int GetAttackLevelBonus { get { return LevelTableHelper.Instance.LevelDetailsList[Level].Attack; } }

        [Ignore]
        // Return the Attack with Item Bonus
        public int GetAttackItemBonus { get { return GetItemBonus(AttributeEnum.Attack); } }
        
        [Ignore]
        // Return the Total of All Attack
        public int GetAttackTotal { get { return GetAttack(); } }
        #endregion Attack

        #region Defense
        [Ignore]
        // Return the Defense value
        public int GetDefenseLevelBonus { get { return LevelTableHelper.Instance.LevelDetailsList[Level].Defense; } }

        [Ignore]
        // Return the Defense with Item Bonus
        public int GetDefenseItemBonus { get { return GetItemBonus(AttributeEnum.Defense); } }

        [Ignore]
        // Return the Total of All Defense
        public int GetDefenseTotal { get { return GetDefense(); } }
        #endregion Defense

        #region Speed
        [Ignore]
        // Return the Speed value
        public int GetSpeedLevelBonus { get { return LevelTableHelper.Instance.LevelDetailsList[Level].Speed; } }

        [Ignore]
        // Return the Speed with Item Bonus
        public int GetSpeedItemBonus { get { return GetItemBonus(AttributeEnum.Speed); } }

        [Ignore]
        // Return the Total of All Speed
        public int GetSpeedTotal { get { return GetSpeed(); } }
        #endregion Speed

        #region CurrentHealth
        [Ignore]
        // Return the CurrentHealth value
        public int GetCurrentHealthLevelBonus { get { return 0; } }

        [Ignore]
        // Return the CurrentHealth with Item Bonus
        public int GetCurrentHealthItemBonus { get { return GetItemBonus(AttributeEnum.CurrentHealth); } }

        [Ignore]
        // Return the Total of All CurrentHealth
        public int GetCurrentHealthTotal { get { return GetCurrentHealth(); } }
        #endregion CurrentHealth

        #region MaxHealth
        [Ignore]
        // Return the MaxHealth value
        public int GetMaxHealthLevelBonus { get { return 0; } }

        [Ignore]
        // Return the MaxHealth with Item Bonus
        public int GetMaxHealthItemBonus { get { return GetItemBonus(AttributeEnum.MaxHealth); } }

        [Ignore]
        // Return the Total of All MaxHealth
        public int GetMaxHealthTotal { get { return GetMaxHealth(); } }
        #endregion MaxHealth

        #region Damage
        [Ignore]
        // Return the Damage value, it is 25% of the Level rounded up
        public int GetDamageLevelBonus { get { return Convert.ToInt32(Math.Ceiling(Level * .25)); } }

        [Ignore]
        // Return the Damage with Item Bonus
        public int GetDamageItemBonus
        {
            get
            {
                var myItem = ItemModelHelper.GetItemModelFromGuid(PrimaryHand);
                if (myItem == null)
                {
                    return 0;
                }
                return myItem.Damage;
            }
        }

        [Ignore]
        // Return the Damage Dice if there is one
        public string GetDamageItemBonusString
        {
            get
            {
                var data = GetDamageItemBonus;
                if (data == 0)
                {
                    return "-";
                }

                return string.Format("1D {0}", data);
            }
        }

        [Ignore]
        // Return the Total of All Damage
        public string GetDamageTotalString
        {
            get
            {

                if (GetDamageItemBonusString.Equals("-"))
                {
                    return GetDamageLevelBonus.ToString();
                }

                return GetDamageLevelBonus.ToString() + " + " + GetDamageItemBonusString;

            }
        }
        #endregion Damage

        //Constructor
        public CharacterMonsterBaseModel()
        {
            Guid = Id;
        }

        #region GetAttributeValues
        /// <summary>
        /// Return the Total Attack Value
        /// </summary>
        /// <returns></returns>
        public virtual int GetAttack(bool SpecialAbilityToBeUsedInAttack = false)
        {
            // Base Attack
            var myReturn = Attack;
            
            // Attack Bonus from Level
            myReturn += GetAttackLevelBonus;
            
            // Get Attack bonus from Items
            myReturn += GetAttackItemBonus;

            return myReturn;
        }

        /// <summary>
        /// Return the Total Defense Value
        /// </summary>
        /// <returns></returns>
        public int GetDefense()
        {
            // Base Defense
            var myReturn = Defense;

            // Defense Bonus from Level
            myReturn += GetDefenseLevelBonus;

            // Get Defense bonus from Items
            myReturn += GetDefenseItemBonus;

            return myReturn;
        }

        /// <summary>
        /// Return the Total Speed Value
        /// </summary>
        /// <returns></returns>
        public int GetSpeed()
        {
            // Base Speed
            var myReturn = Speed;

            // Speed Bonus from Level
            myReturn += GetSpeedLevelBonus;

            // Get Speed bonus from Items
            myReturn += GetSpeedItemBonus;

            return myReturn;
        }

        /// <summary>
        /// Return the Total CurrentHealth Value
        /// </summary>
        /// <returns></returns>
        public int GetCurrentHealth()
        {
            // Base CurrentHealth
            var myReturn = CurrentHealth;

            // CurrentHealth Bonus from Level
            myReturn += GetCurrentHealthLevelBonus;

            // Get CurrentHealth bonus from Items
            myReturn += GetCurrentHealthItemBonus;

            return myReturn;
        }

        /// <summary>
        /// Return the Total MaxHealth Value
        /// </summary>
        /// <returns></returns>
        public int GetMaxHealth()
        {
            // Base MaxHealth
            var myReturn = MaxHealth;

            // MaxHealth Bonus from Level
            myReturn += GetMaxHealthLevelBonus;

            // Get MaxHealth bonus from Items
            myReturn += GetMaxHealthItemBonus;

            return myReturn;
        }
        #endregion GetAttributeValues

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
        public bool AddExperience(int ExtraExperienceToAdd)
        {
            this.ExperienceTotal += ExtraExperienceToAdd;
            return true;
        }

        //TODO
        public int CalculateExperienceEarned(int damage) { return 0; }

        /// <summary>
        /// Based on the weapon damage input, makes changes in the monster's health
        /// </summary>
        /// <param name="DamageFromItem"></param>
        public bool TakeDamage(int damage)
        {
            if (damage <= 0)
            {
                return false;
            }

            CurrentHealth = CurrentHealth - damage;
            if (CurrentHealth <= 0)
            {
                CurrentHealth = 0;

                // Death...
                CauseDeath();
            }

            return true;
        }

        /// <summary>
        /// Roll the Damage Dice, and add to the Damage
        /// </summary>
        /// <returns></returns>
        public int GetDamageRollValue()
        {
            var myReturn = 0;

            var myItem = ItemModelHelper.GetItemModelFromGuid(PrimaryHand);
            if (myItem != null)
            {
                // Dice of the weapon.  So sword of Damage 10 is d10
                myReturn += DiceHelper.RollDice(1, myItem.Damage);
            }

            // Add in the Level as extra damage per game rules
            myReturn += GetDamageLevelBonus;

            return myReturn;
        }

        // Death
        // Alive turns to False
        public bool CauseDeath()
        {
            Alive = false;
            return Alive;
        }

        public string FormatOutput() { return ""; }

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


        // Add ItemModel
        // Looks up the ItemModel
        // Puts the ItemModel ID as a string in the location slot
        // If ItemModel is null, then puts null in the slot
        // Returns the ItemModel that was in the location
        public ItemModel AddItem(ItemLocationEnum itemlocation, string itemID)
        {
            ItemModel myReturn;

            switch (itemlocation)
            {
                case ItemLocationEnum.Feet:
                    myReturn = ItemModelHelper.GetItemModelFromGuid(Feet);
                    Feet = itemID;
                    break;

                case ItemLocationEnum.Head:
                    myReturn = ItemModelHelper.GetItemModelFromGuid(Head);
                    Head = itemID;
                    break;

                case ItemLocationEnum.Necklass:
                    myReturn = ItemModelHelper.GetItemModelFromGuid(Necklace);
                    Necklace = itemID;
                    break;

                case ItemLocationEnum.PrimaryHand:
                    myReturn = ItemModelHelper.GetItemModelFromGuid(PrimaryHand);
                    PrimaryHand = itemID;
                    break;

                case ItemLocationEnum.OffHand:
                    myReturn = ItemModelHelper.GetItemModelFromGuid(OffHand);
                    OffHand = itemID;
                    break;

                case ItemLocationEnum.RightFinger:
                    myReturn = ItemModelHelper.GetItemModelFromGuid(RightFinger);
                    RightFinger = itemID;
                    break;

                case ItemLocationEnum.LeftFinger:
                    myReturn = ItemModelHelper.GetItemModelFromGuid(LeftFinger);
                    LeftFinger = itemID;
                    break;

                default:
                    myReturn = null;
                    break;
            }

            return myReturn;
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

        // Walk all the Items on the Character.
        // Add together all Items that modify the Attribute Enum Passed in
        // Return the sum
        public int GetItemBonus(AttributeEnum attributeEnum)
        {
            var myReturn = 0;
            ItemModel myItem;

            myItem = ItemModelHelper.GetItemModelFromGuid(Head);
            if (myItem != null)
            {
                if (myItem.Attribute == attributeEnum)
                {
                    myReturn += myItem.Value;
                }
            }

            myItem = ItemModelHelper.GetItemModelFromGuid(Necklace);
            if (myItem != null)
            {
                if (myItem.Attribute == attributeEnum)
                {
                    myReturn += myItem.Value;
                }
            }

            myItem = ItemModelHelper.GetItemModelFromGuid(PrimaryHand);
            if (myItem != null)
            {
                if (myItem.Attribute == attributeEnum)
                {
                    myReturn += myItem.Value;
                }
            }

            myItem = ItemModelHelper.GetItemModelFromGuid(OffHand);
            if (myItem != null)
            {
                if (myItem.Attribute == attributeEnum)
                {
                    myReturn += myItem.Value;
                }
            }

            myItem = ItemModelHelper.GetItemModelFromGuid(RightFinger);
            if (myItem != null)
            {
                if (myItem.Attribute == attributeEnum)
                {
                    myReturn += myItem.Value;
                }
            }

            myItem = ItemModelHelper.GetItemModelFromGuid(LeftFinger);
            if (myItem != null)
            {
                if (myItem.Attribute == attributeEnum)
                {
                    myReturn += myItem.Value;
                }
            }

            myItem = ItemModelHelper.GetItemModelFromGuid(Feet);
            if (myItem != null)
            {
                if (myItem.Attribute == attributeEnum)
                {
                    myReturn += myItem.Value;
                }
            }

            return myReturn;
        }

    }
}
