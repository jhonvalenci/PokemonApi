using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using PokemonApi.Models;

namespace PokemonApi.Services
{
    public class PokemonService
    {
        private readonly HttpClient _httpClient;

        public PokemonService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PokemonAbilities> GetPokemonAbilities(string pokemonName)
        {
            var response = await _httpClient.GetAsync($"https://pokeapi.co/api/v2/pokemon/{pokemonName}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var pokemonData = JsonSerializer.Deserialize<PokemonData>(content);

            var hiddenAbilities = new List<string>();
            foreach (var abilityInfo in pokemonData.Abilities)
            {
                if (abilityInfo.IsHidden)
                {
                    hiddenAbilities.Add(abilityInfo.Ability.Name);
                }
            }

            return new PokemonAbilities { Ocultas = hiddenAbilities };
        }
    }

    public class PokemonData
    {
        public List<AbilityInfo> Abilities { get; set; }
    }

    public class AbilityInfo
    {
        public AbilityDetail Ability { get; set; }
        public bool IsHidden { get; set; }
    }

    public class AbilityDetail
    {
        public string Name { get; set; }
    }

    public class PokemonAbilities
    {
        public List<string> Ocultas { get; set; }
    }
}
