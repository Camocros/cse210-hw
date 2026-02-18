using System;

namespace ExerciseTracking;

public abstract class Activity
{
    private DateTime _date;
    private int _minutes;

    protected Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    protected DateTime Date => _date;
    protected int Minutes => _minutes;

    public abstract double GetDistance(); // miles
    public abstract double GetSpeed();    // mph
    public abstract double GetPace();     // min per mile

    protected abstract string GetName();

    public virtual string GetSummary()
    {
        return $"{Date:dd MMM yyyy} {GetName()} ({Minutes} min)- " +
               $"Distance {GetDistance():F2} miles, " +
               $"Speed {GetSpeed():F2} mph, " +
               $"Pace: {GetPace():F2} min per mile";
    }
}
