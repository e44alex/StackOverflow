using System;
using System.Security.AccessControl;

namespace StackOverflow.Models
{
    public class Answer
    {
        public Guid Id { get; set; }
        public string Body { get; set; }
        public int LikesCount { get; set; }
        public User Creator { get; set; }

        public DateTime DateCreated { get; set; }
    }
}