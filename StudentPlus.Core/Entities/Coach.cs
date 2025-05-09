using System;
using System.Collections.Generic;

namespace StudentPlus.Core.Entities
{
    public class Coach : BaseEntity
    {
        public Guid UserId { get; set; }
        public string Specialty { get; set; } // Matematik, Fizik, vb.
        public string Bio { get; set; }
        
        // Navigation properties
        public User User { get; set; }
        public ICollection<StudentCoach> StudentCoaches { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}