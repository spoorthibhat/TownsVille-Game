using Game.Services;

namespace Game.Models
{
    public class CharacterModel : BaseModel<CharacterModel>
    {
        public SpecialAbilityEnum SpecialAbility { get; set; } = SpecialAbilityEnum.None;
        public bool Alive { get; set; } = true;
        public int Level { get; set; } = 1;
        public int ExperienceTotal { get; set; } = 300;
        public int Speed { get; set; } = 1;
        public int Attack { get; set; } = 0;
        public int Defense { get; set; } = 0;
        public int CurrentHealth { get; set; } = 1;
        public int MaxHealth { get; set; } = 1;

        // Items to be added

        public CharacterModel()
        {
            ImageURI = ItemService.DefaultImageURI;
            this.Name = "This is a Character";
            this.Description = "Character Description";
        }

        public CharacterModel(CharacterModel data)
        {
            Update(data);
        }

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
     
        }
    }
}
