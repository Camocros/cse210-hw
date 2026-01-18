using System;

public class Program
{
    public static void Main(string[] args)
    {
        // EXCEED REQUIREMENTS:
        // - Added extra prompts in PromptGenerator (more than 5).
        // - Used a unique separator (~|~) and encapsulated save/load logic in Journal + Entry.

        const string SEPARATOR = "~|~";

        Journal theJournal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        bool running = true;

        while (running)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    // Write
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine(prompt);
                    Console.Write("> ");
                    string response = Console.ReadLine();

                    Entry newEntry = new Entry();
                    newEntry._date = DateTime.Now.ToShortDateString();
                    newEntry._promptText = prompt;
                    newEntry._entryText = response;

                    theJournal.AddEntry(newEntry);
                    Console.WriteLine("Entry added.\n");
                    break;

                case "2":
                    // Display
                    theJournal.DisplayAll();
                    break;

                case "3":
                    // Load
                    Console.Write("What is the filename? ");
                    string loadFile = Console.ReadLine();
                    theJournal.LoadFromFile(loadFile, SEPARATOR);
                    Console.WriteLine("Journal loaded.\n");
                    break;

                case "4":
                    // Save
                    Console.Write("What is the filename? ");
                    string saveFile = Console.ReadLine();
                    theJournal.SaveToFile(saveFile, SEPARATOR);
                    Console.WriteLine("Journal saved.\n");
                    break;

                case "5":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid option. Try again.\n");
                    break;
            }
        }
    }
}
