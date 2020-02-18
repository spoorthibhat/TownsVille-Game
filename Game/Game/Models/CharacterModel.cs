using Game.Services;
using SQLite;

namespace Game.Models
{
    public class CharacterModel : CharacterMonsterBaseModel<CharacterModel>
    {
        
        //Character special ability
       
        public SpecialAbilityEnum SpecialAbility { get; set; } = SpecialAbilityEnum.None;
        

        
        // Items to be added

        /// <summary>
        /// Default CharacterModel
        /// Initialize Values
        /// </summary>

        public CharacterModel()
        {
            ImageURI = ItemService.DefaultImageURI;
            this.Name = "This is a Character";
            this.Description = "Character Description";
            this.ImageURI = "default_character.png";
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
        public override void Update(CharacterModel newData)
        {
            if (newData == null)
            {
                return;
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
        }
    }
}
