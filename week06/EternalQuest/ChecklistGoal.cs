using System;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string shortName, string description, int points, int target, int bonus, int amountCompleted = 0)
        : base(shortName, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = amountCompleted;
    }

    public override int RecordEvent()
    {
        if (IsComplete())
        {
            return 0; // ya estaba completo
        }

        _amountCompleted++;
        int earned = _points;

        if (_amountCompleted >= _target)
        {
            earned += _bonus; // bonus al completar
        }

        return earned;
    }

    public override bool IsComplete() => _amountCompleted >= _target;

    public override string GetDetailsString()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkbox} {_shortName} ({_description}) -- Completed {_amountCompleted}/{_target} times";
    }

    public override string GetStringRepresentation()
    {
        // Type|Name|Description|Points|Bonus|Target|AmountCompleted
        return $"ChecklistGoal|{_shortName}|{_description}|{_points}|{_bonus}|{_target}|{_amountCompleted}";
    }
}

