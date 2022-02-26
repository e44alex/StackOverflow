using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using StackOverflow.Common.Models;

namespace StackOverflowWebApi.Models;

public class User
{
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
    public string PasswordHash { get; set; }
}