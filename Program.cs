using ConsolePokemon;
using PokeApiNet;
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
            Console.Write("\nIndiquer une liste de pokémon à afficher : 2");
            Console.Write("\nFaire une recherche sur le site pokemontruc : 3");
            Console.Write("\nQuitter : 0");
            Console.WriteLine();

            Console.Write("\nEntrez une commande : ");
            string param = Console.ReadLine() ?? "";

            switch (param)
            {
                case "1":
                    // ConsolePokemon.HTML_Handler.CreerHTML();
                    break;

                case "2":
                    Console.Write("\nCombien de pokémons voulez vous ? ");
                    uint nbrPokemon;
                    try
                    {
                        nbrPokemon = uint.Parse(Console.ReadLine() ?? "");
                    }
                    catch
                    {
                        Console.WriteLine("ce n'est pas un nombre valide");
                        break;
                    }

                    List<Pokemon> listPokemon = new();

                    API_Pokemon API = new();
                    API.API_FetchAll(Convert.ToInt32(nbrPokemon), listPokemon);

                    // /!\ danger, on peut appuyer sur la touche avant la fin du thread
                    Console.ReadKey();

                    ConsolePokemon.HTML_Handler.CreerHTMLtexte(listPokemon);

                    break;

                case "3":
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
}
