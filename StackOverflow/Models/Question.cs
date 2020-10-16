﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;

namespace StackOverflow.Models
{
    public class Question : IEnumerable
    {
        public Guid Id { get; set; }
        public string Topic { get; set; }
        public string Body { get; set; }
        //if not opened -- not allowed to create answers
        public bool Opened { get; set; }
        public User Creator { get; set; }
        public DateTime DateCreated { get; set; }
        //if no q's date created
        //else max(a.dateCreated)
        public DateTime LastActivity { get; set; }
        public List<Answer> Answers { get; set; }


        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}