using Microsoft.EntityFrameworkCore;
using StudentPlus.Core.Entities;

namespace StudentPlus.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<StudentCoach> StudentCoaches { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamResult> ExamResults { get; set; }
        public DbSet<CalendarEvent> CalendarEvents { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User Entity Configuration
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
                entity.Property(e => e.PasswordHash).IsRequired();
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Role).IsRequired().HasMaxLength(20);
                
                // User - Student ilişkisi (1:1)
                entity.HasOne(u => u.Student)
                      .WithOne(s => s.User)
                      .HasForeignKey<Student>(s => s.UserId);
                
                // User - Parent ilişkisi (1:1)
                entity.HasOne(u => u.Parent)
                      .WithOne(p => p.User)
                      .HasForeignKey<Parent>(p => p.UserId);
                
                // User - Coach ilişkisi (1:1)
                entity.HasOne(u => u.Coach)
                      .WithOne(c => c.User)
                      .HasForeignKey<Coach>(c => c.UserId);
            });

            // Student Entity Configuration
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Grade).IsRequired();
                entity.Property(e => e.School).HasMaxLength(100);
                
                // Student - Parents ilişkisi (1:N)
                entity.HasMany(s => s.Parents)
                      .WithOne(p => p.Student)
                      .HasForeignKey(p => p.StudentId);
                
                // Student - CalendarEvents ilişkisi (1:N)
                entity.HasMany(s => s.CalendarEvents)
                      .WithOne(c => c.Student)
                      .HasForeignKey(c => c.StudentId);
                
                // Student - ExamResults ilişkisi (1:N)
                entity.HasMany(s => s.ExamResults)
                      .WithOne(e => e.Student)
                      .HasForeignKey(e => e.StudentId);
            });

            // Coach Entity Configuration
            modelBuilder.Entity<Coach>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Specialty).HasMaxLength(100);
                
                // Coach - Courses ilişkisi (1:N)
                entity.HasMany(c => c.Courses)
                      .WithOne(c => c.Coach)
                      .HasForeignKey(c => c.CoachId);
            });

            // StudentCoach Entity Configuration (Many-to-Many)
            modelBuilder.Entity<StudentCoach>(entity =>
            {
                entity.HasKey(e => e.Id);
                
                // StudentCoach - Student ilişkisi
                entity.HasOne(sc => sc.Student)
                      .WithMany(s => s.StudentCoaches)
                      .HasForeignKey(sc => sc.StudentId);
                
                // StudentCoach - Coach ilişkisi
                entity.HasOne(sc => sc.Coach)
                      .WithMany(c => c.StudentCoaches)
                      .HasForeignKey(sc => sc.CoachId);
            });

            // Course Entity Configuration
            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                
                // Course - Subjects ilişkisi (1:N)
                entity.HasMany(c => c.Subjects)
                      .WithOne(s => s.Course)
                      .HasForeignKey(s => s.CourseId);
            });

            // Subject Entity Configuration
            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                
                // Subject - Documents ilişkisi (1:N)
                entity.HasMany(s => s.Documents)
                      .WithOne(d => d.Subject)
                      .HasForeignKey(d => d.SubjectId);
                
                // Subject - CalendarEvents ilişkisi (1:N)
                entity.HasMany(s => s.CalendarEvents)
                      .WithOne(c => c.Subject)
                      .HasForeignKey(c => c.SubjectId);
            });

            // Document Entity Configuration
            modelBuilder.Entity<Document>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
                entity.Property(e => e.FilePath).IsRequired();
                entity.Property(e => e.FileType).IsRequired().HasMaxLength(20);
                
                // Document - Exam ilişkisi (1:1)
                entity.HasOne(d => d.Exam)
                      .WithOne(e => e.Document)
                      .HasForeignKey<Exam>(e => e.DocumentId);
            });

            // Exam Entity Configuration
            modelBuilder.Entity<Exam>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.AnswerKey).IsRequired();
                
                // Exam - ExamResults ilişkisi (1:N)
                entity.HasMany(e => e.Results)
                      .WithOne(r => r.Exam)
                      .HasForeignKey(r => r.ExamId);
            });

            // ExamResult Entity Configuration
            modelBuilder.Entity<ExamResult>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Answers);
            });

            // CalendarEvent Entity Configuration
            modelBuilder.Entity<CalendarEvent>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
                entity.Property(e => e.EventDate).IsRequired();
            });

            // Message Entity Configuration
            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Content).IsRequired();
                
                // İlişkiler - User tablosuna foreign key
                entity.HasOne(m => m.Sender)
                      .WithMany()
                      .HasForeignKey(m => m.SenderId)
                      .OnDelete(DeleteBehavior.Restrict);
                
                entity.HasOne(m => m.Receiver)
                      .WithMany()
                      .HasForeignKey(m => m.ReceiverId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}