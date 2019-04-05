using System;
using System.Collections.Generic;
using System.IO;

namespace FindAndReplace
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize local variables
            string searchPhrase = "";
            string replacePhrase = "";
            string sourcePath = "";
            string destinationPath = "";

            // Get search phrase
            Console.Write("Enter a search phrase: ");
            searchPhrase = Console.ReadLine();

            // Get replace phrase
            Console.Write("Enter a replace phrase: ");
            replacePhrase = Console.ReadLine();

            // Get source file
            do
            {
                Console.Write("Enter a source path: ");
                sourcePath = Console.ReadLine();
            }
            while (!File.Exists(sourcePath));

            // Get destination file
            do
            {
                Console.Write("Enter a destination path: ");
                destinationPath = Console.ReadLine();

                if (File.Exists(destinationPath))
                {
                    Console.WriteLine($"File at {destinationPath} already exists.");
                }
            }
            while (File.Exists(destinationPath));

            // Create array to hold all modified lines
            Queue<string> modifiedFile = new Queue<string>();

            // Open destination file
            using (StreamReader reader = new StreamReader(sourcePath))
            {
                // Find all instances of searchPhrase in destination file
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    // Replace instance of word
                    if (line.Contains(searchPhrase))
                    {
                        modifiedFile.Enqueue(line.Replace(searchPhrase, replacePhrase));
                    }
                }
            }

            // Write all modified data to new file
            using (StreamWriter writer = new StreamWriter(destinationPath, true))
            {
                while (modifiedFile.Count > 0)
                {
                    writer.WriteLine(modifiedFile.Dequeue());
                }
            }
        }
    }
}
