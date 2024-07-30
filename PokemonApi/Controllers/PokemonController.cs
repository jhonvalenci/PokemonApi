using Microsoft.AspNetCore.Mvc;
using PokemonApi.Services;
using System.Threading.Tasks;

namespace PokemonApi.Controllers
{
    [ApiController]
    [Route("pokemon/habilidadesOcultas")]
    public class PokemonController : ControllerBase
    {
        private readonly PokemonService _pokemonService;

        public PokemonController(PokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetPokemon(string name)
        {
            var pokemonAbilities = await _pokemonService.GetPokemonAbilities(name);
            return Ok(new { habilidades = new { ocultas = pokemonAbilities.Ocultas } });
        }
    }
}
