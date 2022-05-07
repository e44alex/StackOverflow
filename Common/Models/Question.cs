namespace StackOverflow.Common.Models;

public class Question
{
    public Guid Id { get; set; }
    public string Topic { get; set; }
    public string Body { get; set; }
    public bool Opened { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime LastActivity { get; set; }
    public User Creator { get; set; }
    public List<Answer> Answers { get; set; }
}