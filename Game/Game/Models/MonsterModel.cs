using Game.Services;
using Game.Helpers;
using SQLite;

namespace Game.Models
{
    public class MonsterModel : CharacterMonsterBaseModel<MonsterModel>
    {
    
        
        // Item possessed by the monster
        [Ignore]
        public ItemModel ItemPossesed { get; set; } = null;

        // Items to be added

        /// <summary>
        /// Default MonsterModel
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
