using PokeApiNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePokemon
{
    public class API_Pokemon
    {
        PokeApiClient pokeClient = new PokeApiClient();
        List<Pokemon> ListePokemon = new List<Pokemon>();


        public async void API_FetchAll(int nbrPokemon, List<Pokemon> listPokemon)
        {

            for (int i = 1; i <= nbrPokemon; i++)
            {
                // pour éviter de se faire bannir
                if (i%50 == 0)
                {
                    System.Threading.Thread.Sleep(2000);
                }
                Pokemon current = await pokeClient.GetResourceAsync<Pokemon>(i);
                listPokemon.Add(current);
            }
        }
    }
}
