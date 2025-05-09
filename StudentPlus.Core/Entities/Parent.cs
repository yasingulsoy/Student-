using System;
using System.Collections.Generic;

namespace StudentPlus.Core.Entities
{
    public class Parent : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid StudentId { get; set; }
        public string Relation { get; set; } // Anne, Baba, vb.
        
        // Navigation properties
        public User User { get; set; }
        public Student Student { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}