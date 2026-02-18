using System;

namespace ExerciseTracking;

public class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, int minutes, int laps)
        : base(date, minutes)
    {
        _laps = laps;
    }

    protected override string GetName() => "Swimming";

    public override double GetDistance()
    {
        // miles = laps * 50 meters → km → miles
        return _laps * 50.0 / 1000.0 * 0.62;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / Minutes) * 60.0;
    }

    public override double GetPace()
    {
        return Minutes / GetDistance();
    }
}
