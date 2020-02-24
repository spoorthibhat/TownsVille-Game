using Game.Services;
using SQLite;

namespace Game.Models
{
    public class CharacterModel : CharacterMonsterBaseModel<CharacterModel>
    {
        
        //Character special ability
        public SpecialAbilityEnum SpecialAbility { get; set; } = SpecialAbilityEnum.Unknown;
        //Character Using Special Ability in the battle
        public bool ISSpecialAbilityNotUsed { get; set; } = true;

        // Items to be added

        /// <summary>
        /// Default CharacterModel
        /// Initialize Values
        /// </summary>

        public CharacterModel()
        {
            this.PlayerType = PlayerTypeEnum.Character;
            ImageURI = ItemService.DefaultImageURI;
            this.Name = "This is a Character";
            this.Description = "Character Description";
            this.ImageURI = "default_character.png";
            this.Level = 1;
        }

        /// <summary>
        /// Constructor to create character based on what is passed in
        /// </summary>
        /// <param name="data"></param>
        public CharacterModel(CharacterModel data)
        {
            Update(data);
        }

        /// <summary>
        /// Update character
        /// </summary>
        /// <param name="newdata"></param>
        public override bool Update(CharacterModel newData)
        {
            if (newData == null)
            {
                return false;
            }
            Name = newData.Name;
            Description = newData.Description;
            ImageURI = newData.ImageURI;
            SpecialAbility = newData.SpecialAbility;
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

        [Ignore]
        // Return the Attack with SpecialAbility Bonus
        public int GetAttackSpecialAbilityBonus { get { return GetSpecialAbilityBonus(this.SpecialAbility); } }

        // Return the specialAbility value
        public int GetSpecialAbilityBonus(SpecialAbilityEnum specialAbilityEnum)
        {
            return (int)specialAbilityEnum;
        }
        /// <summary>
        /// Return the Total Attack Value
        /// </summary>
        /// <returns></returns>
        public override int GetAttack(bool SpecialAbilityToBeUsedInAttack)
        {
            // Base Attack
            var myReturn = Attack;

            // Attack Bonus from Level
            myReturn += GetAttackLevelBonus;

            
            if (SpecialAbilityToBeUsedInAttack && ISSpecialAbilityNotUsed)
            {
                // Get Attack bonus from Special Ability
                myReturn += GetAttackSpecialAbilityBonus;
                ISSpecialAbilityNotUsed = false;

                return myReturn;
            }

            // Get Attack bonus from Items
            myReturn += GetAttackItemBonus;

            return myReturn;

        }
    }
}
