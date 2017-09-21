using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gatherin.Presentation.ViewModels
{
    /// <summary>
    /// View Model for the attendee
    /// </summary>
    public class AttendeeViewModel
    {
        public AttendeeViewModel(string fullName, string email)
        {
            FullName = fullName;
            Email = email;
        }

        /// <summary>
        /// Full Name of the attendee
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Email of the attendee
        /// </summary>
        public string Email { get; set; }
    }
}