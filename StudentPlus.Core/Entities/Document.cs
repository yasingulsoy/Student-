using System;
using System.Collections.Generic;

namespace StudentPlus.Core.Entities
{
    public class Document : BaseEntity
    {
        public string Title { get; set; }
        public string FilePath { get; set; }
        public string FileType { get; set; } // PDF, Word, vb.
        public Guid SubjectId { get; set; }
        public bool IsExam { get; set; } // Sınav mı yoksa çalışma materyali mi?
        
        // Navigation properties
        public Subject Subject { get; set; }
        public Exam Exam { get; set; }
    }
}