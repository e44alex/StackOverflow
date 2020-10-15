﻿using System;
using System.Collections.Generic;
using System.Security.AccessControl;

namespace StackOverflow.Models
{
    public class Question
    {
        public Guid Id { get; set; }
        public string Topic { get; set; }
        public string Body { get; set; }
        //if not opened -- not allowed to create answers
        public bool Opened { get; set; }
        public User Creator { get; set; }
        public DateTime DateCreated { get; set; }

        public List<Answer> Answers { get; set; }

        
    }
}