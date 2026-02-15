using System;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string shortName, string description, int points, bool isComplete = false)
        : base(shortName, description, points)
    {
        _isComplete = isComplete;
    }

    public override int RecordEvent()
    {
        if (_isComplete)
        {
            return 0; // ya estaba completo, no suma
        }

        _isComplete = true;
        return _points;
    }

    public override bool IsComplete() => _isComplete;

    public override string GetStringRepresentation()
    {
        // Type|Name|Description|Points|IsComplete
        return $"SimpleGoal|{_shortName}|{_description}|{_points}|{_isComplete}";
    }
}
