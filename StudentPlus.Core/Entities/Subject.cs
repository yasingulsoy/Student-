using System;
using System.Collections.Generic;

namespace StudentPlus.Core.Entities
{
    public class Subject : BaseEntity
    {
        public string Name { get; set; } // Trigonometri, Fonksiyonlar, vb.
        public string Description { get; set; }
        public Guid CourseId { get; set; }
        
        // Navigation properties
        public Course Course { get; set; }
        public ICollection<Document> Documents { get; set; }
        public ICollection<CalendarEvent> CalendarEvents { get; set; }
    }
}