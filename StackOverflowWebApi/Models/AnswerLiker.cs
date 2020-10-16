using System;

namespace StackOverflowWebApi.Models
{
    public class AnswerLiker
    {
        public Guid Id { get; set; }

        public User User { get; set; }

        public Answer Answer { get; set; }
    }
}