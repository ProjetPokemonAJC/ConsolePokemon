using PokeApiNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePokemon
{
    internal abstract class HTML_Handler
    {
        public static List<string> HeaderHTML(List<string> codeHTML)
        {
            codeHTML.Add("<!DOCTYPE html>\r");
            codeHTML.Add("<html>\r    <head>\r");
            codeHTML.Add("        <meta charset=\"utf-8\" />\r");
            codeHTML.Add("        <title>Titre</title>\r");
            codeHTML.Add("    </head>\r");
            codeHTML.Add("\r    <body>\r");

            return codeHTML;
        }
        public static List<string> FooterHTML(List<string> codeHTML)
        {
            codeHTML.Add("    </body>\r");
            codeHTML.Add("</html>");

            return codeHTML;
        }
        public static List<string> HeaderHTMLgrafic(List<string> codeHTML)
        {
            string pathDirectory = Directory.GetCurrentDirectory();
            int index = pathDirectory.IndexOf("ConsolePokemon") + 14;
            pathDirectory = pathDirectory[..index];
            pathDirectory += "\\html\\template_header.html";

            // Open the stream and read it back.
            using (StreamReader sr = File.OpenText(pathDirectory))
            {
                string? s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    codeHTML.Add(s);
                }
            }

            return codeHTML;
        }
        public static List<string> FooterHTMLgrafic(List<string> codeHTML)
        {
            string pathDirectory = Directory.GetCurrentDirectory();
            int index = pathDirectory.IndexOf("ConsolePokemon") + 14;
            pathDirectory = pathDirectory[..index];
            pathDirectory += "\\html\\template_footer.html";

            // Open the stream and read it back.
            using (StreamReader sr = File.OpenText(pathDirectory))
            {
                string? s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    codeHTML.Add(s);
                }
            }

            return codeHTML;
        }

        public static void CreerHTMLtexte(List<Pokemon> listPokemon)
        {
            List<string> codeHTML = new();
            HeaderHTML(codeHTML);
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

            CreateHTMLFile(codeHTML);

        }

        private static void CreateHTMLFile(List<string> codeHTML)
        {

            string pathDirectory = Directory.GetCurrentDirectory();

            try
            {
                // Write the string array to a new file named "WriteLines.txt".
                using StreamWriter outputFile = new(Path.Combine(pathDirectory, "pokémon.html"));
                foreach (string line in codeHTML) outputFile.WriteLine(line);
                Console.WriteLine($"fichier créer dans : {pathDirectory}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void CreerHTMLgrafic(List<Pokemon> listPokemon)
        {
            List<string> codeHTML = new();
            HeaderHTMLgrafic(codeHTML);


            // création des path
            string pathBody = Directory.GetCurrentDirectory();
            int index = pathBody.IndexOf("ConsolePokemon") + 14;
            pathBody = pathBody[..index];
            pathBody += "\\html\\template_body.html";

            string pathType2 = Directory.GetCurrentDirectory();
            index = pathType2.IndexOf("ConsolePokemon") + 14;
            pathType2 = pathType2[..index];
            pathType2 += "\\html\\template_type2.html";
            
            foreach (Pokemon pokemon in listPokemon)
            {
                // Open the stream and read it back.
                using StreamReader sr = File.OpenText(pathBody);
                string? s = "";
                Console.WriteLine($"nb de poke : {listPokemon.Count}");
                while ((s = sr.ReadLine()) != null)
                {
                    // gestion de base
                    s = s.Replace("$pokemon_ID", Convert.ToString(pokemon.Id));
                    s = s.Replace("$nomPokemon", pokemon.Name);
                    s = s.Replace("$type1", pokemon.Types[0].Type.Name);

                    
                    //gestion du type 2
                    if (pokemon.Types.Count == 2 && s.Contains("$espaceType2"))
                    {
                        // ouverture du template html pour le type 2
                        s = s.Replace("$espaceType2", "");

                        // écriture du code html pour le type 2
                        using StreamReader sr2 = File.OpenText(pathType2);
                        string? s2 = "";
                        while ((s2 = sr2.ReadLine()) != null)
                        {
                            s2 = s2.Replace("$type2", pokemon.Types[1].Type.Name);
                            codeHTML.Add(s2);
                        }
                    }
                    else
                    {
                        s = s.Replace("$espaceType2", "");
                    }
                    codeHTML.Add(s);
                }
            }
            

            FooterHTMLgrafic(codeHTML);

            string pathFilePokemon = Directory.GetCurrentDirectory();
            index = pathType2.IndexOf("ConsolePokemon") + 14;
            pathFilePokemon = pathFilePokemon[..index];

            try
            {
                // Write the string array to a new file named "WriteLines.txt".
                using StreamWriter outputFile = new(Path.Combine(pathFilePokemon, "pokémon.html"));
                foreach (string line in codeHTML) outputFile.WriteLine(line);
                Console.WriteLine($"fichier créer dans : {pathFilePokemon}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
