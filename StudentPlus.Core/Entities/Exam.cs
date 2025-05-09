using System;
using System.Collections.Generic;

namespace StudentPlus.Core.Entities
{
    public class Exam : BaseEntity
    {
        public Guid DocumentId { get; set; }
        public string AnswerKey { get; set; } // JSON formatında cevap anahtarı
        public int QuestionCount { get; set; }
        public int Duration { get; set; } // Dakika cinsinden süre
        
        // Navigation properties
        public Document Document { get; set; }
        public ICollection<ExamResult> Results { get; set; }
    }
}