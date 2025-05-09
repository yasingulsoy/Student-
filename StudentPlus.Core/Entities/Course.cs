using System;
using System.Collections.Generic;

namespace StudentPlus.Core.Entities
{
    public class Course : BaseEntity
    {
        public string Name { get; set; } // Matematik, Fizik, vb.
        public string Description { get; set; }
        public Guid CoachId { get; set; }
        
        // Navigation properties
        public Coach Coach { get; set; }
        public ICollection<Subject> Subjects { get; set; }
    }
}