using System;

namespace StudentPlus.Core.Entities
{
    // Many-to-many ilişki tablosu
    public class StudentCoach : BaseEntity
    {
        public Guid StudentId { get; set; }
        public Guid CoachId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        
        // Navigation properties
        public Student Student { get; set; }
        public Coach Coach { get; set; }
    }
}