using System;
using System.IO;

namespace file_io_part1_exercises_pair
{
    class Program
    {
        static void Main(string[] args)
        {
            bool successfulInput = false;
            string filepath = "";

            // Define counters
            int wordCount = 0;
            int sentenceCount = 0;
 
            while (!successfulInput)
            {
                // Get filepath from user
                Console.Write("Enter a filepath: ");
                filepath = Console.ReadLine();

                // If file exists, analyze
                if (File.Exists(filepath))
                {
                    successfulInput = true;

                    using (StreamReader sr = new StreamReader(filepath))
                    {
                        string line = "";

                        while (!sr.EndOfStream)
                        {
                            line = sr.ReadLine();

                            for (int i = 0; i < line.Length; i++)
                            {
                                // Find space - new word
                                if (line[i] == ' ' || i == line.Length - 1)
                                {
                                    // Check if found space is alone
                                    if (i > 0)
                                    {
                                        if (line[i - 1] != ' ')
                                        {
                                            wordCount++;
                                        }
                                        else
                                        {
                                            if (i < line.Length - 1)
                                            {
                                                if (line[i + 1] != ' ')
                                                {
                                                    wordCount++;
                                                }
                                            }
                                        }
                                    }
                                }

                                // Find punctuation - new sentence
                                if (line[i] == '.' || line[i] == '!' || line[i] == '?')
                                {
                                    sentenceCount++;
                                }
                            }
                        }
                    }
                }
            }


            // Output analyzed information to user
            Console.Clear();
            Console.WriteLine($"File: {filepath}");
            Console.WriteLine($"Words: {wordCount}");
            Console.WriteLine($"Sentences: {sentenceCount}");
            Console.ReadKey();
        }
    }
}
