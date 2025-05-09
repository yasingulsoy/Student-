using System;

namespace StudentPlus.Core.Entities
{
    public class Message : BaseEntity
    {
        public Guid SenderId { get; set; } // User ID
        public Guid ReceiverId { get; set; } // User ID
        public string Content { get; set; }
        public bool IsRead { get; set; }
        public DateTime? ReadAt { get; set; }
        
        // Navigation properties - User ID'lere göre Coach veya Parent
        public User Sender { get; set; }
        public User Receiver { get; set; }
    }
}