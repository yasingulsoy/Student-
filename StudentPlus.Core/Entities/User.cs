using System;
using System.Collections.Generic;

namespace StudentPlus.Core.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public bool EmailConfirmed { get; set; }
        public string Role { get; set; } // Student, Parent, Coach
        public bool IsActive { get; set; } = true;
        
        // Navigation properties
        public Student Student { get; set; }
        public Parent Parent { get; set; }
        public Coach Coach { get; set; }
    }
}
