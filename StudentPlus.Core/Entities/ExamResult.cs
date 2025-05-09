using System;

namespace StudentPlus.Core.Entities
{
    public class ExamResult : BaseEntity
    {
        public Guid ExamId { get; set; }
        public Guid StudentId { get; set; }
        public string Answers { get; set; } // JSON formatında öğrenci cevapları
        public double Score { get; set; }
        public int CorrectAnswers { get; set; }
        public int WrongAnswers { get; set; }
        public int EmptyAnswers { get; set; }
        public bool IsPublished { get; set; } // Sonuç öğrenci ve veliye açıklandı mı?
        public DateTime SubmittedAt { get; set; }
        
        // Navigation properties
        public Exam Exam { get; set; }
        public Student Student { get; set; }
    }
}