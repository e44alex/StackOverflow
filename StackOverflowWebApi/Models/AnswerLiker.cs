using System;

namespace StackOverflowWebApi.Models;

public class AnswerLiker
{
    public Guid Id { get; set; }

    public string User { get; set; }

    public Guid AnswerId { get; set; }
}