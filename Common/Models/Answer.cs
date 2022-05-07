namespace StackOverflow.Common.Models;

public class Answer
{
    public Guid AnswerId { get; set; }
    public string Body { get; set; }
    public Question Question { get; set; }
    public DateTime DateCreated { get; set; }
    public List<AnswerLiker> Users { get; set; }
    public User Creator { get; set; }
}