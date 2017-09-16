using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gatherin.Presentation.ViewModels
{
    public class AttendeeViewModel
    {
        public AttendeeViewModel(string fullName, string email)
        {
            FullName = fullName;
            Email = email;
        }

        public string FullName { get; set; }

        public string Email { get; set; }
    }
}