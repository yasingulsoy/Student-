using System;

namespace StudentPlus.Core.Entities
{
    public class CalendarEvent : BaseEntity
    {
        public Guid StudentId { get; set; }
        public Guid SubjectId { get; set; }
        public DateTime EventDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public Guid CreatedByCoachId { get; set; } // Hangi koç eklediyse
        
        // Navigation properties
        public Student Student { get; set; }
        public Subject Subject { get; set; }
    }
}
