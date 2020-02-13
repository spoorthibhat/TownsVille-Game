using Game.Services;
using Game.Helpers;
using SQLite;

namespace Game.Models
{
    public class MonsterModel : BaseModel<MonsterModel>
    {
        
        //Flag to check if the monster is alive
        public bool Alive { get; set; } = true;
        //Level of the monster
        public int Level { get; set; } = 1;
        //Total Experience of the monster
        public int ExperienceTotal { get; set; } = 300;
        //Speed of the monster
        public int Speed { get; set; } = 0;
        //Attack caused by monster
        public int Attack { get; set; } = 0;
        //monsters defense
        public int Defense { get; set; } = 0;
        //Current health of monster
        public int CurrentHealth { get; set; } = 1;
        //Max health of monster
        public int MaxHealth { get; set; } = 1;

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
     
        }

        /// <summary>
        /// Scales the level of the monster
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public bool ScaleLevel(int level)
        {
            return true;
        }

        /// <summary>
        /// Levels up the monster if it is time to level up
        /// </summary>
        /// <returns></returns>
        public bool LevelUp()
        {
            int newLevel = ExperienceMappingHelper.GetLevelPerExperience(this.ExperienceTotal);
            if(newLevel > this.Level)
            {
                this.Level = newLevel;
                return true;
            }
            return false;
        }
    }
}
