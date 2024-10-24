using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using pokeapi_net_mvc.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace pokeapi_net_mvc.Controllers
{
    /// Controller responsible for handling Pokemon-related actions.
    public class PokemonController : Controller
    {
        private readonly HttpClient _httpClient;

        /// Constructor initializing the HttpClient for API requests.
        public PokemonController()
        {
            _httpClient = new HttpClient();
        }

        /// Displays the main page with Pokemon details.
        /// The default Pokemon ID is 1 (Bulbasaur) if no ID is provided.
        public async Task<IActionResult> Index(int id = 1)
        {
            // Fetch Pokemon data from the PokeAPI
            var response = await _httpClient.GetStringAsync($"https://pokeapi.co/api/v2/pokemon/{id}");
            var pokemon = JsonConvert.DeserializeObject<PokeApiResponse>(response);

            // Map API response to the view model
            var model = new Pokemon
            {
                Id = pokemon?.Id ?? 0,  // Assign 0 if ID is null
                Name = pokemon?.Name ?? "Unknown",  // Default to "Unknown" if name is null
                Sprite = pokemon?.Sprites?.Front_Default  // Fetch the front sprite, if available
            };

            return View(model);  // Pass the model to the view
        }

        /// API endpoint to retrieve Pokemon details by ID.
        [HttpGet]
        public async Task<JsonResult> GetPokemon(int id)
        {
            // Fetch Pokemon data from the PokeAPI
            var response = await _httpClient.GetStringAsync($"https://pokeapi.co/api/v2/pokemon/{id}");
            var pokemon = JsonConvert.DeserializeObject<PokeApiResponse>(response);

            // Fetch species data (including flavor text/descriptions) from the PokeAPI
            var speciesResponse = await _httpClient.GetStringAsync($"https://pokeapi.co/api/v2/pokemon-species/{id}");
            var species = JsonConvert.DeserializeObject<PokeApiSpeciesResponse>(speciesResponse);

            // Map API response and species data to the view model
            var model = new Pokemon
            {
                Id = pokemon?.Id ?? 0,  // Default to 0 if ID is null
                Name = pokemon?.Name ?? "Unknown",  // Default to "Unknown" if name is null
                Sprite = pokemon?.Sprites?.Front_Default,  // Fetch the front sprite, if available
                // Retrieve the first description in Spanish, if available
                Description = species?.Flavor_Text_Entries?.FirstOrDefault(x => x.Language.Name == "es")?.Flavor_Text ?? "No description available"
            };

            return Json(model);  // Return the model as JSON
        }
    }
}
