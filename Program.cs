using ConsolePokemon;
using PokeApiNet;
using System.Collections.Generic;
using System.Text;

internal class Programm
{
    // Main de l'application pokédex

    static void Main(String[] args)
    {


        bool exit = false;
        while (!exit)
        {
            Console.Write("\nApplication pokédex - Menu principal");
            Console.Write("\nCréer une page pour un seul pokémon : 1");
            Console.Write("\nCréer une page html d'une liste texte de pokémon : 2");
            Console.Write("\nCréer une page html d'une liste graphique de pokémon : 3");
            Console.Write("\nFaire une recherche sur le site pokemontruc : 4");
            Console.Write("\nQuitter : 0");
            Console.WriteLine();

            Console.Write("\nEntrez une commande : ");
            string param = Console.ReadLine() ?? "";

            List<Pokemon>? listPokemon;
            API_Pokemon API = new();
            switch (param)
            {
                case "1":
                    // ConsolePokemon.HTML_Handler.CreerHTML();
                    break;

                case "2":
                    listPokemon = FetchPokemon(API);
                    if (listPokemon == null) break;
                    ConsolePokemon.HTML_Handler.CreerHTMLtexte(listPokemon);
                    break;

                case "3":
                    listPokemon = FetchPokemon(API);
                    if (listPokemon == null) break;
                    ConsolePokemon.HTML_Handler.CreerHTMLgrafic(listPokemon);
                    break;

                case "4":
                    break;

                case "0":
                    exit = true;
                    break;

                default:
                    Console.WriteLine("\nCommande non reconnnue");
                    break;
            }
        }
    }

    static List<Pokemon>? FetchPokemon(API_Pokemon API)
    {
        List<Pokemon> listPokemon = new();

        uint nbrPokemon;
        Console.Write("\nCombien de pokémons voulez vous ? ");
        try
        {
            nbrPokemon = uint.Parse(Console.ReadLine() ?? "");
        }
        catch
        {
            Console.WriteLine("ce n'est pas un nombre valide");
            return null;
        }

        // thread
        API.API_FetchAll(Convert.ToInt32(nbrPokemon), listPokemon);

        // /!\ danger, on peut appuyer sur la touche avant la fin du thread
        Console.ReadKey();

        return listPokemon;
    }
}
