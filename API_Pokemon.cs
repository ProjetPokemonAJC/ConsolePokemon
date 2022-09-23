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
        readonly PokeApiClient pokeClient = new();

        public async void API_FetchAll(int nbrPokemon, List<Pokemon> listPokemon)
        {
            Console.WriteLine("Récupération depuis l'API en cours...");
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
            Console.WriteLine("Fin du chargement, appuyez sur une touche.");
        }

        public async void API_Fetch_Single(int i, Pokemon current)
        {
            Console.WriteLine("Récupération depuis l'API en cours...");
            current = await pokeClient.GetResourceAsync<Pokemon>(i);
            Console.WriteLine("Fin du chargement, appuyez sur une touche.");
        }
    }
}
