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
            Console.Write("\nEntrez une commande :");
            Console.WriteLine();


            string param = Console.ReadLine() ?? "";

            switch (param)
            {
                case "1":
                    // ConsolePokemon.HTML_Handler.CreerHTML();
                    break;

                case "2":
                    List<Pokemon> listPokemon = new();

                    Console.WriteLine("Hello, World!");
                    API_Pokemon API = new API_Pokemon();
                    API.API_FetchAll(20, listPokemon);

                    Console.WriteLine("Récupération depuis l'API en cours...");
                    System.Threading.Thread.Sleep(5000);
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
