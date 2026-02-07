using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private Random _random = new Random();

    private string[] _prompts =
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
        : base(
            "Listing",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area."
        )
    {
    }

    public void Run()
    {
        StartActivity();

        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine();

        string prompt = _prompts[_random.Next(_prompts.Length)];
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine();

        Console.Write("You may begin in: ");
        ShowCountdown(5);
        Console.WriteLine();
        Console.WriteLine();

        List<string> items = new List<string>();

        int duration = GetDuration();
        DateTime endTime = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string entry = Console.ReadLine();

            // Guardamos lo que escribió (aunque sea vacío, pero normalmente escribirá algo)
            items.Add(entry);
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {items.Count} items!");

        EndActivity();
    }
}
