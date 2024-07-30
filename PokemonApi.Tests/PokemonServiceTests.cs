using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using PokemonApi.Services;
using PokemonApi.Models;
using System.Collections.Generic;

public class PokemonServiceTests
{
    [Fact]
    public async Task GetPokemonAbilities_ReturnsHiddenAbilities()
    {
        // Arrange
        var responseMessage = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent("{ \"abilities\": [ { \"ability\": { \"name\": \"hidden-ability\" }, \"is_hidden\": true } ] }")
        };
        var httpClient = new HttpClient(new FakeHttpMessageHandler(responseMessage));
        var pokemonService = new PokemonService(httpClient);

        // Act
        var result = await pokemonService.GetPokemonAbilities("pikachu");

        // Assert
        Assert.Contains(result.Ocultas, ability => ability == "hidden-ability");
    }
}
