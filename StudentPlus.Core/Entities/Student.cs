using System;
using System.Collections.Generic;

namespace StudentPlus.Core.Entities
{
    public class Student : BaseEntity
    {
        public Guid UserId { get; set; }
        public string ProfileImagePath { get; set; }
        public int Grade { get; set; } // Sınıf
        public string School { get; set; }
        
        // Navigation properties
        public User User { get; set; }
        public ICollection<StudentCoach> StudentCoaches { get; set; }
        public ICollection<Parent> Parents { get; set; }
        public ICollection<ExamResult> ExamResults { get; set; }
        public ICollection<CalendarEvent> CalendarEvents { get; set; }
    }
}