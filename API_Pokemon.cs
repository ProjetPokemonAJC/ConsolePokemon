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


        public async void API_FetchAll()
        {
            for (int i = 1; i <= 151; i++)
            {
                if (i == 50 || i == 100)
                {
                    System.Threading.Thread.Sleep(2000);
                }
                Pokemon current = await pokeClient.GetResourceAsync<Pokemon>(i);
                ListePokemon.Add(current);
                if (ListePokemon[i-1].Types.Count() == 1)
                {
                    Console.WriteLine($"#{ListePokemon[i-1].Id} : {ListePokemon[i - 1].Species.Name} ( {ListePokemon[i-1].Types[0].Type.Name} )");
                }
                else
                {
                    Console.WriteLine($"#{ListePokemon[i - 1].Id} : {ListePokemon[i - 1].Species.Name} ( {ListePokemon[i - 1].Types[0].Type.Name} / {ListePokemon[i - 1].Types[1].Type.Name} )");
                }
            }


        }
    }
}
