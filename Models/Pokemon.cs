namespace pokeapi_net_mvc.Models
{
    /// Represents a Pokemon entity with basic properties.
    public class Pokemon
    {
        /// Gets or sets the ID of the Pokemon. Can be null if not yet assigned.
        public int? Id { get; set; }

        /// Gets or sets the name of the Pokemon. Can be null if not retrieved.
        public string? Name { get; set; }

        /// Gets or sets the sprite URL of the Pokemon. Can be null if no sprite is available.
        public string? Sprite { get; set; }

        /// Gets or sets the description of the Pokemon. Can be null if no description is available.
        public string? Description { get; set; }
    }

    /// Represents the response structure from the PokeAPI for Pokemon data.
    public class PokeApiResponse
    {
        /// Gets or sets the ID of the Pokemon. Can be null if not provided.
        public int? Id { get; set; }

        /// Gets or sets the name of the Pokemon. Can be null if not provided.
        public string? Name { get; set; }

        /// Gets or sets the sprite information of the Pokemon. Can be null if no sprite data is available.
        public Sprite? Sprites { get; set; }

        /// Gets or sets the description of the Pokemon. Can be null if no description is available.
        public string? Description { get; set; }
    }

    /// Represents sprite details for a Pokemon, including the front view.
    public class Sprite
    {
        /// Gets or sets the URL for the front default sprite of the Pokemon. Can be null if not available.
        public string? Front_Default { get; set; }
    }
    
    /// Represents a flavor text entry that provides additional information about a Pokemon in various languages.
    public class PokeApiFlavorTextEntry
    {
        /// Gets or sets the flavor text providing the description or fun facts about the Pokemon.
        public string Flavor_Text { get; set; }

        /// Gets or sets the language in which the flavor text is written.
        public Language Language { get; set; }
    }

    /// Represents a language entity that includes the name of the language used in the API response.
    public class Language
    {
        /// Gets or sets the name of the language.
        public string Name { get; set; }
    }

    /// Represents the species-specific data structure returned from the PokeAPI.
    public class PokeApiSpeciesResponse
    {
        /// Gets or sets the list of flavor text entries associated with a Pokemon's species.
        public List<PokeApiFlavorTextEntry> Flavor_Text_Entries { get; set; }
    }
}