using System;

/*
EXCEEDING REQUIREMENTS (for 100%):
- Added a simple “Level Up” gamification system.
  The user gains levels based on score (every 1000 points = +1 level).
  The program displays a title (Beginner Seeker, Faith Adventurer, etc.)
  and shows a celebration message when leveling up.
*/

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}
