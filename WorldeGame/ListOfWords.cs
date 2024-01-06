using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace WorldeGame
{
    internal class ListOfWords
    {
        private static List<string> words;

        static ListOfWords()
        {
            LoadWordsAsync(); // Wait for the asynchronous operation to complete
        }

        private static async Task LoadWordsAsync()
        {
            List<string> loadedWords = new List<string>();


            try
            {
                using (Stream fileStream = await FileSystem.Current.OpenAppPackageFileAsync("words.txt"))
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    string line = reader.ReadLine();

                    while (line != null)
                    {
                        Console.WriteLine(line);
                        loadedWords.Add(line.Trim());
                        line = reader.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log, show message, etc.)
                Console.WriteLine($"Error loading words: {ex.Message}");
            }

            words = loadedWords;
        }

        public static string GetRandomWord()
        {
            if (words != null && words.Count > 0)
            {
                Random random = new Random();
                int randomIndex = random.Next(words.Count);
                return words[randomIndex];
            }

            return "HAPPY";
        }
    }
}
