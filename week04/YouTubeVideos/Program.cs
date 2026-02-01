using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create 3 videos
        Video v1 = new Video("Product Review: New Phone", "TechAna", 540);
        Video v2 = new Video("Unboxing: Sneakers", "StyleMike", 420);
        Video v3 = new Video("How to Make Coffee", "CafeLuna", 300);

        // Add 3-4 comments per video
        v1.AddComment(new Comment("Cam", "Great review!"));
        v1.AddComment(new Comment("Sofia", "This helped me decide."));
        v1.AddComment(new Comment("Luis", "Nice video, thanks!"));

        v2.AddComment(new Comment("Maria", "Those look amazing."));
        v2.AddComment(new Comment("John", "Clean unboxing."));
        v2.AddComment(new Comment("Cam", "Now I want them."));
        v2.AddComment(new Comment("Nina", "Great details!"));

        v3.AddComment(new Comment("Alex", "Super simple, love it."));
        v3.AddComment(new Comment("Cam", "I tried it and it works."));
        v3.AddComment(new Comment("Mia", "Perfect morning routine."));

        // Put videos into a list
        List<Video> videos = new List<Video> { v1, v2, v3 };

        // Display each video and its comments
        foreach (Video video in videos)
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length (seconds): {video.GetLengthSeconds()}");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  - {comment.GetName()}: {comment.GetText()}");
            }

            Console.WriteLine();
        }
    }
}
