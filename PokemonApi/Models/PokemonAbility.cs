namespace PokemonApi.Models
{
    public class Ability
    {
        public AbilityDetail AbilityDetail { get; set; }
        public bool IsHidden { get; set; }
    }

    public class AbilityDetail
    {
        public string Name { get; set; }
    }

    public class PokemonResponse
    {
        public List<Ability> Abilities { get; set; }
    }
}
