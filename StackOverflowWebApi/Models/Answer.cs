using System;

namespace StackOverflowWebApi.Models;

public class Answer
{
    public Guid AnswerId { get; set; }
    public string Body { get; set; }
    public DateTime DateCreated { get; set; }
    public string Creator { get; set; }
}