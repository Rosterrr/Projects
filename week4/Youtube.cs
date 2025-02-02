using System;
using System.Collections.Generic;

class Comment
{
    public string Name { get; set; }
    public string Text { get; set; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }
}

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; } // in seconds
    private List<Comment> Comments;

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return Comments.Count;
    }

    public void DisplayVideoDetails()
    {
        Console.WriteLine($"Title: {Title}\nAuthor: {Author}\nLength: {Length} seconds\nComments ({GetCommentCount()}):");
        foreach (var comment in Comments)
        {
            Console.WriteLine($"- {comment.Name}: {comment.Text}");
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("C# Tutorial", "John Doe", 600);
        video1.AddComment(new Comment("Alice", "Great tutorial!"));
        video1.AddComment(new Comment("Bob", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Charlie", "I learned a lot!"));

        Video video2 = new Video("Learn OOP in C#", "Jane Smith", 900);
        video2.AddComment(new Comment("Dave", "Clear explanation!"));
        video2.AddComment(new Comment("Eve", "This made OOP easy to understand."));
        video2.AddComment(new Comment("Frank", "Loved the examples!"));

        Video video3 = new Video("Advanced C# Concepts", "Michael Brown", 1200);
        video3.AddComment(new Comment("Grace", "This was challenging but fun!"));
        video3.AddComment(new Comment("Hank", "Super useful information."));
        video3.AddComment(new Comment("Ivy", "Great video, thanks!"));

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        foreach (var video in videos)
        {
            video.DisplayVideoDetails();
        }
    }
}
