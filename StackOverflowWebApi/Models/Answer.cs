﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StackOverflowWebApi.Models
{
    public class Answer
    {
        public Guid Id { get; set; }
        [Required]
        public string Body { get; set; }
        public User? Creator { get; set; }
        public Question Question { get; set; }
        public DateTime DateCreated { get; set; }
        public List<AnswerLiker> Users { get; set; }
    }
}