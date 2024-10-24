function updatePokedex(pokemon) {
    document.getElementById('pokemon-sprite').src = pokemon.sprite;
    document.getElementById('pokemon-name').textContent = pokemon.name;
    document.getElementById('pokemon-id').textContent = `ID: ${pokemon.id}`;
}

async function fetchPokemon(id) {
    try {
        const response = await fetch(`/Pokemon/GetPokemon?id=${id}`);
        const pokemon = await response.json();
        updatePokedex(pokemon);
    } catch (error) {
        console.error('Error al obtener el Pokémon:', error);
    }
}

document.getElementById('next-btn').addEventListener('click', () => {
    currentPokemonId++;
    fetchPokemon(currentPokemonId);
});

document.getElementById('prev-btn').addEventListener('click', () => {
    if (currentPokemonId > 1) {
        currentPokemonId--;
        fetchPokemon(currentPokemonId);
    }
});