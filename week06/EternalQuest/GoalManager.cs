using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void Start()
    {
        int choice = -1;

        while (choice != 6)
        {
            Console.WriteLine();
            DisplayPlayerInfo();
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            choice = ReadInt();

            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    CreateGoal();
                    break;
                case 2:
                    ListGoalDetails();
                    break;
                case 3:
                    SaveGoals();
                    break;
                case 4:
                    LoadGoals();
                    break;
                case 5:
                    RecordEvent();
                    break;
                case 6:
                    Console.WriteLine("Goodbye! Keep going on your Eternal Quest!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        string title = GetPlayerTitle(_score);
        int level = GetPlayerLevel(_score);
        Console.WriteLine($"You have {_score} points. Level {level} - {title}");
    }

    // EXTRA (creatividad): niveles/títulos por puntaje (simple)
    private int GetPlayerLevel(int score)
    {
        // cada 1000 puntos sube 1 nivel (mínimo nivel 1)
        return (score / 1000) + 1;
    }

    private string GetPlayerTitle(int score)
    {
        int level = GetPlayerLevel(score);

        if (level >= 10) return "Celestial Champion";
        if (level >= 7) return "Temple Titan";
        if (level >= 5) return "Scripture Warrior";
        if (level >= 3) return "Faith Adventurer";
        return "Beginner Seeker";
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }

        if (_goals.Count == 0)
        {
            Console.WriteLine("(No goals yet)");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");

        int type = ReadInt();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = ReadInt();

        if (type == 1)
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (type == 2)
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (type == 3)
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = ReadInt();

            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = ReadInt();

            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
        else
        {
            Console.WriteLine("Invalid type. Goal not created.");
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals to record yet.");
            return;
        }

        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }

        Console.Write("Which goal did you accomplish? ");
        int index = ReadInt() - 1;

        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        int oldLevel = GetPlayerLevel(_score);

        int earned = _goals[index].RecordEvent();
        _score += earned;

        Console.WriteLine($"Congratulations! You have earned {earned} points!");
        Console.WriteLine($"You now have {_score} points.");

        int newLevel = GetPlayerLevel(_score);
        if (newLevel > oldLevel)
        {
            Console.WriteLine($"🎉 LEVEL UP! You are now Level {newLevel} - {GetPlayerTitle(_score)}!");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved!");
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);

        _goals.Clear();

        if (lines.Length > 0)
        {
            _score = int.Parse(lines[0]);
        }

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] parts = line.Split('|');

            string type = parts[0];

            if (type == "SimpleGoal")
            {
                // SimpleGoal|Name|Desc|Points|IsComplete
                string name = parts[1];
                string desc = parts[2];
                int points = int.Parse(parts[3]);
                bool isComplete = bool.Parse(parts[4]);

                _goals.Add(new SimpleGoal(name, desc, points, isComplete));
            }
            else if (type == "EternalGoal")
            {
                // EternalGoal|Name|Desc|Points
                string name = parts[1];
                string desc = parts[2];
                int points = int.Parse(parts[3]);

                _goals.Add(new EternalGoal(name, desc, points));
            }
            else if (type == "ChecklistGoal")
            {
                // ChecklistGoal|Name|Desc|Points|Bonus|Target|AmountCompleted
                string name = parts[1];
                string desc = parts[2];
                int points = int.Parse(parts[3]);
                int bonus = int.Parse(parts[4]);
                int target = int.Parse(parts[5]);
                int amountCompleted = int.Parse(parts[6]);

                _goals.Add(new ChecklistGoal(name, desc, points, target, bonus, amountCompleted));
            }
        }

        Console.WriteLine("Goals loaded!");
    }

    // Helper simple para leer ints sin romper el programa
    private int ReadInt()
    {
        while (true)
        {
            string input = Console.ReadLine();
            if (int.TryParse(input, out int value))
            {
                return value;
            }
            Console.Write("Please enter a valid number: ");
        }
    }
}
