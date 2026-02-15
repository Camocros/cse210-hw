using System;

public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;

    public Goal(string shortName, string description, int points)
    {
        _shortName = shortName;
        _description = description;
        _points = points;
    }

    public string GetShortName() => _shortName;
    public string GetDescription() => _description;
    public int GetPoints() => _points;

    public abstract int RecordEvent(); // retorna puntos ganados al registrar
    public abstract bool IsComplete();

    public virtual string GetDetailsString()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkbox} {_shortName} ({_description})";
    }

    public abstract string GetStringRepresentation(); // para guardar en archivo
}
