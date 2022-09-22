using PokeApiNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePokemon
{
    internal abstract class HTML_Handler
    {
        public static List<string> HeaderHTML()
        {
            List<string> codeHTML = new()
            {
                "<!DOCTYPE html>\r",
                "<html>\r    <head>\r",
                "        <meta charset=\"utf-8\" />\r",
                "        <title>Titre</title>\r",
                "    </head>\r",
                "\r    <body>\r",
            };
            return codeHTML;
        }
        public static List<string> FooterHTML(List<string> codeHTML)
        {
            codeHTML.Add("    </body>\r");
            codeHTML.Add("</html>");

            return codeHTML;
        }
            public static void CreerHTMLtexte(List<Pokemon> listPokemon)
        {
            List<string> codeHTML = HeaderHTML();
            codeHTML.Add("<ul>");
            for (int i = 0; i <= listPokemon.Count - 1; i++)
            {
                if (listPokemon[i].Types.Count == 1)
                {
                    codeHTML.Add($"<li>#{listPokemon[i].Id} : {listPokemon[i].Species.Name} ( {listPokemon[i].Types[0].Type.Name} )</li>");
                }
                else
                {
                    codeHTML.Add($"<li>#{listPokemon[i].Id} : {listPokemon[i].Species.Name} ( {listPokemon[i].Types[0].Type.Name} / {listPokemon[i].Types[1].Type.Name} )</li>");
                }
            }
            codeHTML.Add("</ul>");

            FooterHTML(codeHTML);

            createHTMLFile(codeHTML);


        }

        private static void createHTMLFile(List<string> codeHTML)
        {

            string pathDirectory = Directory.GetCurrentDirectory();

            try
            {
                // Write the string array to a new file named "WriteLines.txt".
                using StreamWriter outputFile = new(Path.Combine(pathDirectory, "pokémon.html"));
                foreach (string line in codeHTML)
                    outputFile.WriteLine(line);

                //// Open the stream and read it back.
                //using (StreamReader sr = File.OpenText(pathDirectory))
                //{
                //    string? s = "";
                //    while ((s = sr.ReadLine()) != null)
                //    {
                //        Console.WriteLine(s);
                //    }
                //}
                //Console.WriteLine($"emplacement du fichier html : {pathDirectory}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            // Create a string array with the lines of text
            string[] lines = { "First line", "Second line", "Third line" };

            // Set a variable to the Documents path.
            string docPath =
              Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        public static void CreerHTMLgrafic(List<Pokemon> listPokemon)
        {

            List<string> codeHTML = new()
            {
                "<!DOCTYPE html>\r",
                "<html>\r    <head>\r",
                "        <meta charset=\"utf-8\" />\r",
                "        <title>Titre</title>\r",
                "    </head>\r",
                "\r    <body>\r",
            };


            Console.WriteLine($"list longueur : {listPokemon.Count}");
            for (int i = 0; i <= listPokemon.Count - 1; i++)
            {
                if (listPokemon[i].Types.Count == 1)
                {
                    codeHTML.Add($"\n#{listPokemon[i].Id} : {listPokemon[i].Species.Name} ( {listPokemon[i].Types[0].Type.Name} )");
                }
                else
                {
                    codeHTML.Add($"\n#{listPokemon[i].Id} : {listPokemon[i].Species.Name} ( {listPokemon[i].Types[0].Type.Name} / {listPokemon[i].Types[1].Type.Name} )");
                }
            }


            codeHTML.Add("    </body>\r");
            codeHTML.Add("</html>");


            string pathDirectory = Directory.GetCurrentDirectory();

            try
            {
                // Write the string array to a new file named "WriteLines.txt".
                using StreamWriter outputFile = new(Path.Combine(pathDirectory, "pokémon.html"));
                foreach (string line in codeHTML)
                    outputFile.WriteLine(line);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            // Create a string array with the lines of text
            string[] lines = { "First line", "Second line", "Third line" };

            // Set a variable to the Documents path.
            string docPath =
              Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }
    }
}
