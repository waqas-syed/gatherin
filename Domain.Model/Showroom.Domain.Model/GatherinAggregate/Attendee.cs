﻿using System.Collections;
using System.Collections.Generic;

namespace Gatherin.Domain.Model.GatherinAggregate
{
    /// <summary>
    /// Person who is attending the meeting
    /// </summary>
    public class Attendee
    {
        //private IList<string> _gifts = new List<string>();
        public Attendee(string fullName, string email)
        {
            FullName = fullName;
            Email = email;
        }

        public string FullName { get; set; }
        public string Email { get; set; }
        //public IList<Gift> Gifts = new List<Gift>();
    }
}
