using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace StackOverflow.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Login{ get; set; }
        public float? Rating { get; set; }
        public DateTime DateRegistered { get; set; }
        public string? Position { get; set; }
        public float? Exerience { get; set; }

        public List<AnswerLiker> Answers{ get; set; }
        public List<Question> Questions{ get; set; }
    }
}