using PokeApiNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
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
        private static void CreateHTMLFile(List<string> codeHTML, string name)
        {

            string pathFile = Directory.GetCurrentDirectory();
            int index = pathFile.IndexOf("ConsolePokemon") + 14;
            pathFile = pathFile[..index];

            try
            {
                // écriture du fichier HTML
                using StreamWriter outputFile = new(Path.Combine(pathFile, name));
                foreach (string line in codeHTML) outputFile.WriteLine(line);
                Console.WriteLine($"fichier créer dans : {pathFile}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
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

            CreateHTMLFile(codeHTML, "pokémon.html");

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


            // boucle d'écriture de l'HTML
            for (int i = 0; i < listPokemon.Count; i++)
            {
                if (i % 4 == 0)
                {
                    codeHTML.Add("        <div class=\"row mx-5\">");
                }

                // Boucle d'écriture du body d'un pokemon
                using StreamReader sr = File.OpenText(pathBody);
                string? s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    // gestion de base
                    s = s.Replace("$pokemon_ID", Convert.ToString(listPokemon[i].Id));
                    s = s.Replace("$nomPokemon", listPokemon[i].Name);
                    s = s.Replace("$type1", listPokemon[i].Types[0].Type.Name);


                    //gestion du type 2
                    if (listPokemon[i].Types.Count == 2 && s.Contains("$espaceType2"))
                    {
                        // ouverture du template html pour le type 2
                        s = s.Replace("$espaceType2", "");

                        // écriture du code html pour le type 2
                        using StreamReader sr2 = File.OpenText(pathType2);
                        string? s2 = "";
                        while ((s2 = sr2.ReadLine()) != null)
                        {
                            s2 = s2.Replace("$type2", listPokemon[i].Types[1].Type.Name);
                            codeHTML.Add(s2);
                        }
                    }
                    else
                    {
                        s = s.Replace("$espaceType2", "");
                    }
                    codeHTML.Add(s);
                }

                if (i == listPokemon.Count - 1)
                {
                    int cloture = (4 - (i + 1) % 4) % 4;
                    for (int j = 0; j < cloture; j++)
                    {
                        codeHTML.Add("            <div class=\"col\"></div>");
                    }
                }

                if (i % 4 == 3 || i == listPokemon.Count - 1)
                {
                    codeHTML.Add("        </div>");
                }


            }


            FooterHTMLgrafic(codeHTML);

            CreateHTMLFile(codeHTML, "pokémon.html");
        }
        public static void CreerHTMLSinglePokemon(Pokemon pokemon)
        {
            /*
            List<string> codeHTML = new();


            // écriture du header
            string pathHeader = Directory.GetCurrentDirectory();
            int index = pathHeader.IndexOf("ConsolePokemon") + 14;
            pathHeader = pathHeader[..index];
            pathHeader += "\\html\\template_headerSinglePokemon.html";

            // Open the stream and read it back.
            using (StreamReader sr = File.OpenText(pathHeader))
            {
                string? s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    codeHTML.Add(s);
                }
            }

            // écriture du body

            // création des path
            string pathBody = Directory.GetCurrentDirectory();
            index = pathBody.IndexOf("ConsolePokemon") + 14;
            pathBody = pathBody[..index];
            pathBody += "\\html\\template_bodySinglePokemon.html";

            string pathType2 = Directory.GetCurrentDirectory();
            index = pathType2.IndexOf("ConsolePokemon") + 14;
            pathType2 = pathType2[..index];
            pathType2 += "\\html\\template_SinglePokemonType2.html";


                using StreamReader sr = File.OpenText(pathBody);
                string? s = "";
                while ((s = sr.ReadLine()) != null)

                // A finir à partir d'ici
                
                {
                    // gestion de base
                    s = s.Replace("$pokemon_ID", Convert.ToString(pokemon[i].Id));


                    //gestion du type 2
                    if (listPokemon[i].Types.Count == 2 && s.Contains("$espaceType2"))
                    {
                        // ouverture du template html pour le type 2
                        s = s.Replace("$espaceType2", "");

                        // écriture du code html pour le type 2
                        using StreamReader sr2 = File.OpenText(pathType2);
                        string? s2 = "";
                        while ((s2 = sr2.ReadLine()) != null)
                        {
                            s2 = s2.Replace("$type2", listPokemon[i].Types[1].Type.Name);
                            codeHTML.Add(s2);
                        }
                    }
                    else
                    {
                        s = s.Replace("$espaceType2", "");
                    }
                    codeHTML.Add(s);
                }

                if (i % 4 == 3)
                {
                    codeHTML.Add("        </div>");
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


            /////



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
            */
        }
    }
}
