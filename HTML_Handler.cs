using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePokemon
{
    internal abstract class HTML_Handler
    {
        public static void CreerHTML()
        {

            List<string> codeHTML = new()
            {
                "<!DOCTYPE html>\r",
                "<html>\r    <head>\r",
                "        <meta charset=\"utf-8\" />\r",
                "        <title>Titre</title>\r",
                "    </head>\r",
                "\r    <body>\r",
                "\r du texte ici",
                "    </body>\r",
                "</html>"
            };


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
    }
}
