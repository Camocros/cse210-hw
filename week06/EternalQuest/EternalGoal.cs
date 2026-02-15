using System;

public class EternalGoal : Goal
{
    public EternalGoal(string shortName, string description, int points)
        : base(shortName, description, points)
    {
    }

    public override int RecordEvent()
    {
        return _points; // siempre suma
    }

    public override bool IsComplete() => false; // nunca se completa

    public override string GetStringRepresentation()
    {
        // Type|Name|Description|Points
        return $"EternalGoal|{_shortName}|{_description}|{_points}";
    }
}
