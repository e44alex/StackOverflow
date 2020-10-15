using System;
using System.Collections.Generic;

namespace StackOverflow.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username{ get; set; }
        public string Email{ get; set; }
        public float Rating { get; set; }
        public DateTime DateRegistered { get; set; }

        public List<Answer> Answers{ get; set; }
        public List<Question> Questions{ get; set; }
    }
}