using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base(
            "Breathing",
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing."
        )
    {
    }

    public void Run()
    {
        StartActivity();

        int duration = GetDuration();
        int elapsedTime = 0;

        while (elapsedTime < duration)
        {
            Console.Write("Breathe in... ");
            ShowCountdown(4);
            Console.WriteLine();

            elapsedTime += 4;
            if (elapsedTime >= duration)
                break;

            Console.Write("Breathe out... ");
            ShowCountdown(4);
            Console.WriteLine();

            elapsedTime += 4;
        }

        EndActivity();
    }
}
