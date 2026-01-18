using System;

public class Entry
{
    public string _date = "";
    public string _promptText = "";
    public string _entryText = "";

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine(_entryText);
        Console.WriteLine();
    }

    // Convierte el Entry a una línea para guardar en archivo
    public string ToFileString(string separator)
    {
        return $"{_date}{separator}{_promptText}{separator}{_entryText}";
    }

    // Crea un Entry desde una línea del archivo
    public static Entry FromFileString(string line, string separator)
    {
        string[] parts = line.Split(separator);

        // Manejo simple por si hay una línea dañada
        if (parts.Length < 3)
        {
            return new Entry
            {
                _date = "",
                _promptText = "Invalid line",
                _entryText = line
            };
        }

        return new Entry
        {
            _date = parts[0],
            _promptText = parts[1],
            _entryText = parts[2]
        };
    }
}
