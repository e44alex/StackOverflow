﻿using System.ComponentModel.DataAnnotations.Schema;

namespace StackOverflow.Common.Models;

public class User
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserId { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string? Login { get; set; }
    public int? Rating { get; set; }
    public DateTime DateRegistered { get; set; }
    public string? Position { get; set; }
    public float? Exerience { get; set; }
    public string? Bio { get; set; }
    public string? PasswordHash { get; set; }

    public List<Answer> Answers { get; set; }
    public List<AnswerLiker> LikedAnswers { get; set; }
    public List<Question> Questions { get; set; }

}