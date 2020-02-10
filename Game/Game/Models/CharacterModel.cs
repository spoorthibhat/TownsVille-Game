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
        public int CurrentHealth { get; set; } = 1;
        public int MaxHealth { get; set; } = 1;

        // Items to be added

        public CharacterModel()
        {
            ImageURI = ItemService.DefaultImageURI;
        }

    }
}
