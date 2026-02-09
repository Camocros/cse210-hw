using System;
using System.Collections.Generic;

namespace ScriptureMemorizer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // EXCEEDING REQUIREMENTS (100%):
            // 1) Library of scriptures (list) and choose one at random.
            // 2) Hide only words that are still visible (stretch).
            // 3) Difficulty: choose how many words to hide per round.

            List<Scripture> library = BuildScriptureLibrary();

            Random random = new Random();
            Scripture scripture = library[random.Next(library.Count)];

            int wordsToHidePerRound = ChooseDifficulty();

            while (true)
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine();
                Console.Write("Press ENTER to hide words, or type 'quit' to exit: ");

                string input = Console.ReadLine();

                if (input != null && input.Trim().ToLower() == "quit")
                {
                    break;
                }

                scripture.HideRandomWords(wordsToHidePerRound);

                if (scripture.IsCompletelyHidden())
                {
                    Console.Clear();
                    Console.WriteLine(scripture.GetDisplayText());
                    Console.WriteLine();
                    Console.WriteLine("All words are hidden. Program finished.");
                    break;
                }
            }
        }

        private static int ChooseDifficulty()
        {
            Console.Clear();
            Console.WriteLine("Choose difficulty (how many words to hide each round):");
            Console.WriteLine("1) Easy (2 words)");
            Console.WriteLine("2) Normal (3 words)");
            Console.WriteLine("3) Hard (5 words)");
            Console.Write("Option (1-3): ");

            string choice = Console.ReadLine();

            if (choice == "1") return 2;
            if (choice == "3") return 5;
            return 3;
        }

        private static List<Scripture> BuildScriptureLibrary()
        {
            List<Scripture> library = new List<Scripture>();

            Reference r1 = new Reference("John", 3, 16);
            Scripture s1 = new Scripture(
                r1,
                "For God so loved the world, that he gave his only begotten Son, " +
                "that whosoever believeth in him should not perish, but have everlasting life."
            );
            library.Add(s1);

            Reference r2 = new Reference("Proverbs", 3, 5, 6);
            Scripture s2 = new Scripture(
                r2,
                "Trust in the Lord with all thine heart; and lean not unto thine own understanding. " +
                "In all thy ways acknowledge him, and he shall direct thy paths."
            );
            library.Add(s2);

            Reference r3 = new Reference("Psalm", 23, 1, 2);
            Scripture s3 = new Scripture(
                r3,
                "The Lord is my shepherd; I shall not want. He maketh me to lie down in green pastures: " +
                "he leadeth me beside the still waters."
            );
            library.Add(s3);

            return library;
        }
    }
}
