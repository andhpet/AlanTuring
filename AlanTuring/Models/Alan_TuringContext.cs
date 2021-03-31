using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AlanTuring.Models
{
    public partial class Alan_TuringContext : DbContext
    {
        public Alan_TuringContext()
        {
        }

        public Alan_TuringContext(DbContextOptions<Alan_TuringContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Assignment> Assignments { get; set; }
        public virtual DbSet<Chat> Chats { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<DeclarativeLesson> DeclarativeLessons { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<FilesAssignment> FilesAssignments { get; set; }
        public virtual DbSet<FilesLearningMaterial> FilesLearningMaterials { get; set; }
        public virtual DbSet<Finance> Finances { get; set; }
        public virtual DbSet<Folder> Folders { get; set; }
        public virtual DbSet<Graduation> Graduations { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<GroupConsistsOfStudent> GroupConsistsOfStudents { get; set; }
        public virtual DbSet<LearningMaterial> LearningMaterials { get; set; }
        public virtual DbSet<Lecturer> Lecturers { get; set; }
        public virtual DbSet<Lesson> Lessons { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<NotificationGroup> NotificationGroups { get; set; }
        public virtual DbSet<NotificationUser> NotificationUsers { get; set; }
        public virtual DbSet<Path> Paths { get; set; }
        public virtual DbSet<Stream> Streams { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentParticipateLesson> StudentParticipateLessons { get; set; }
        public virtual DbSet<Submission> Submissions { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=LAPTOP-PBSQPR1I\\SQLEXPRESS;Database=Alan_Turing;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Assignment>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.PathsId, e.CoursesId, e.DeclarativeLessonsId, e.LessonsId })
                    .HasName("Assignments_pk");

                entity.HasIndex(e => e.Id, "UQ__Assignme__3214EC2672E9EF64")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PathsId).HasColumnName("paths_ID");

                entity.Property(e => e.CoursesId).HasColumnName("courses_ID");

                entity.Property(e => e.DeclarativeLessonsId).HasColumnName("declarative_Lessons_ID");

                entity.Property(e => e.LessonsId).HasColumnName("lessons_ID");

                entity.Property(e => e.AssignmentsIdentity)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("assignments_identity");

                entity.Property(e => e.Datetime)
                    .HasColumnType("datetime")
                    .HasColumnName("datetime");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.DueDate)
                    .HasColumnType("datetime")
                    .HasColumnName("dueDate");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.HasOne(d => d.Courses)
                    .WithMany(p => p.Assignments)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.CoursesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Assignmen__cours__7E37BEF6");

                entity.HasOne(d => d.DeclarativeLessons)
                    .WithMany(p => p.Assignments)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.DeclarativeLessonsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Assignmen__decla__5AEE82B9");

                entity.HasOne(d => d.Lessons)
                    .WithMany(p => p.Assignments)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.LessonsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Assignmen__lesso__00200768");

                entity.HasOne(d => d.Paths)
                    .WithMany(p => p.Assignments)
                    .HasForeignKey(d => d.PathsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Assignmen__paths__5CD6CB2B");
            });

            modelBuilder.Entity<Chat>(entity =>
            {
                entity.HasKey(e => e.MessageId)
                    .HasName("PK__Chats__0BBF6EE6DEFE4AFE");

                entity.Property(e => e.MessageId)
                    .ValueGeneratedNever()
                    .HasColumnName("message_id");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.GroupReceiverId).HasColumnName("group_receiver_id");

                entity.Property(e => e.MessageContent)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("message_content");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UserReceiverId).HasColumnName("user_receiver_id");

                entity.Property(e => e.UserSenderId).HasColumnName("user_sender_id");

                entity.HasOne(d => d.GroupReceiver)
                    .WithMany(p => p.Chats)
                    .HasForeignKey(d => d.GroupReceiverId)
                    .HasConstraintName("FK__Chats__group_rec__5DCAEF64");

                entity.HasOne(d => d.UserReceiver)
                    .WithMany(p => p.ChatUserReceivers)
                    .HasForeignKey(d => d.UserReceiverId)
                    .HasConstraintName("FK__Chats__user_rece__32AB8735");

                entity.HasOne(d => d.UserSender)
                    .WithMany(p => p.ChatUserSenders)
                    .HasForeignKey(d => d.UserSenderId)
                    .HasConstraintName("FK__Chats__user_send__339FAB6E");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.AssignmentsId).HasColumnName("assignments_ID");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("content");

                entity.Property(e => e.CoursesId).HasColumnName("courses_ID");

                entity.Property(e => e.Datetime)
                    .HasColumnType("datetime")
                    .HasColumnName("datetime");

                entity.Property(e => e.DeclarativeLessonsId).HasColumnName("declarative_Lessons_ID");

                entity.Property(e => e.LessonsId).HasColumnName("lessons_ID");

                entity.Property(e => e.PathsId).HasColumnName("paths_ID");

                entity.Property(e => e.SubmissionsId).HasColumnName("submissions_ID");

                entity.Property(e => e.UsersId).HasColumnName("users_ID");

                entity.HasOne(d => d.Assignments)
                    .WithMany(p => p.Comments)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.AssignmentsId)
                    .HasConstraintName("FK__Comments__assign__60A75C0F");

                entity.HasOne(d => d.Courses)
                    .WithMany(p => p.Comments)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.CoursesId)
                    .HasConstraintName("FK__Comments__course__0F624AF8");

                entity.HasOne(d => d.DeclarativeLessons)
                    .WithMany(p => p.Comments)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.DeclarativeLessonsId)
                    .HasConstraintName("FK__Comments__declar__628FA481");

                entity.HasOne(d => d.Lessons)
                    .WithMany(p => p.Comments)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.LessonsId)
                    .HasConstraintName("FK__Comments__lesson__114A936A");

                entity.HasOne(d => d.Paths)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.PathsId)
                    .HasConstraintName("FK__Comments__paths___6477ECF3");

                entity.HasOne(d => d.Submissions)
                    .WithMany(p => p.Comments)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.SubmissionsId)
                    .HasConstraintName("FK__Comments__submis__656C112C");

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UsersId)
                    .HasConstraintName("FK__Comments__users___0C85DE4D");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.PathsId })
                    .HasName("Courses_pk");

                entity.HasIndex(e => e.Id, "UQ__Courses__3214EC26ABD85FA4")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PathsId).HasColumnName("paths_ID");

                entity.Property(e => e.CoursesIdentity)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("courses_identity");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Paths)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.PathsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Courses__paths_I__52593CB8");
            });

            modelBuilder.Entity<DeclarativeLesson>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.PathsId, e.CoursesId })
                    .HasName("Declarative_Lessons_pk");

                entity.ToTable("Declarative_Lessons");

                entity.HasIndex(e => e.Id, "UQ__Declarat__3214EC2646CDBBEA")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PathsId).HasColumnName("paths_ID");

                entity.Property(e => e.CoursesId).HasColumnName("courses_ID");

                entity.Property(e => e.DeclarativeLessonsIdentity)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Declarative_Lessons_identity");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.HasOne(d => d.Courses)
                    .WithMany(p => p.DeclarativeLessons)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.CoursesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Declarati__cours__5AEE82B9");

                entity.HasOne(d => d.Paths)
                    .WithMany(p => p.DeclarativeLessons)
                    .HasForeignKey(d => d.PathsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Declarati__paths__693CA210");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Position)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("position");

                entity.Property(e => e.Salary)
                    .HasColumnType("money")
                    .HasColumnName("salary");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Employee)
                    .HasForeignKey<Employee>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Employees__id__778AC167");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Category)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("category");

                entity.Property(e => e.Datetime)
                    .HasColumnType("datetime")
                    .HasColumnName("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<File>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Accessibility).HasColumnName("accessibility");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnName("content");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.Desciption)
                    .HasColumnType("text")
                    .HasColumnName("desciption");

                entity.Property(e => e.FolderChildId).HasColumnName("folder_childID");

                entity.Property(e => e.FolderParentId).HasColumnName("folder_parentID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("type");

                entity.HasOne(d => d.FolderParent)
                    .WithMany(p => p.Files)
                    .HasForeignKey(d => d.FolderParentId)
                    .HasConstraintName("FK__Files__folder_pa__160F4887");
            });

            modelBuilder.Entity<FilesAssignment>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("files_assignments");

                entity.Property(e => e.AssignmentsId).HasColumnName("assignments_ID");

                entity.Property(e => e.FilesId).HasColumnName("files_ID");

                entity.HasOne(d => d.Assignments)
                    .WithMany()
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.AssignmentsId)
                    .HasConstraintName("FK__files_ass__assig__6C190EBB");

                entity.HasOne(d => d.Files)
                    .WithMany()
                    .HasForeignKey(d => d.FilesId)
                    .HasConstraintName("FK__files_ass__files__17F790F9");
            });

            modelBuilder.Entity<FilesLearningMaterial>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("files_learningMaterials");

                entity.Property(e => e.FilesId).HasColumnName("files_ID");

                entity.Property(e => e.LearningMaterialsId).HasColumnName("learningMaterials_ID");

                entity.HasOne(d => d.Files)
                    .WithMany()
                    .HasForeignKey(d => d.FilesId)
                    .HasConstraintName("FK__files_lea__files__208CD6FA");

                entity.HasOne(d => d.LearningMaterials)
                    .WithMany()
                    .HasForeignKey(d => d.LearningMaterialsId)
                    .HasConstraintName("FK__files_lea__learn__6EF57B66");
            });

            modelBuilder.Entity<Finance>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnType("money")
                    .HasColumnName("amount");

                entity.Property(e => e.Datetime)
                    .HasColumnType("datetime")
                    .HasColumnName("datetime");

                entity.Property(e => e.Purpose)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("purpose");

                entity.Property(e => e.ReceiverId).HasColumnName("receiver_id");

                entity.Property(e => e.SenderId).HasColumnName("sender_id");

                entity.HasOne(d => d.Receiver)
                    .WithMany(p => p.FinanceReceivers)
                    .HasForeignKey(d => d.ReceiverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Finances__receiv__2EDAF651");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.FinanceSenders)
                    .HasForeignKey(d => d.SenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Finances__sender__2FCF1A8A");
            });

            modelBuilder.Entity<Folder>(entity =>
            {
                entity.HasKey(e => e.ParentId)
                    .HasName("PK__Folders__90658CB819BFF475");

                entity.Property(e => e.ParentId)
                    .ValueGeneratedNever()
                    .HasColumnName("parentID");

                entity.Property(e => e.Accessibility).HasColumnName("accessibility");

                entity.Property(e => e.ChildId).HasColumnName("childID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Graduation>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.PathsId })
                    .HasName("pk");

                entity.HasIndex(e => e.Id, "UQ__Graduati__3214EC26F16DDBC7")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PathsId).HasColumnName("paths_ID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.GraduationsIdentity)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("graduations_identity");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Paths)
                    .WithMany(p => p.Graduations)
                    .HasForeignKey(d => d.PathsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Graduatio__paths__4D94879B");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.CoursesId).HasColumnName("courses_ID");

                entity.Property(e => e.LecturersId).HasColumnName("Lecturers_ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.PathsId).HasColumnName("Paths_ID");

                entity.Property(e => e.StreamId).HasColumnName("stream_ID");

                entity.HasOne(d => d.Courses)
                    .WithMany(p => p.Groups)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.CoursesId)
                    .HasConstraintName("FK__Groups__courses___6754599E");

                entity.HasOne(d => d.Lecturers)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.LecturersId)
                    .HasConstraintName("FK__Groups__Lecturer__73BA3083");

                entity.HasOne(d => d.Paths)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.PathsId)
                    .HasConstraintName("FK__Groups__Paths_ID__74AE54BC");

                entity.HasOne(d => d.Stream)
                    .WithMany(p => p.Groups)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.StreamId)
                    .HasConstraintName("FK__Groups__stream_I__656C112C");
            });

            modelBuilder.Entity<GroupConsistsOfStudent>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Group_ConsistsOf_Students");

                entity.Property(e => e.GroupsId).HasColumnName("Groups_ID");

                entity.Property(e => e.StudentsId).HasColumnName("students_ID");
            });

            modelBuilder.Entity<LearningMaterial>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.CoursesId).HasColumnName("courses_ID");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.DeclarativeLessonsId).HasColumnName("declarative_Lessons_ID");

                entity.Property(e => e.LessonsId).HasColumnName("lessons_ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.PathsId).HasColumnName("paths_ID");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("type");

                entity.HasOne(d => d.Courses)
                    .WithMany(p => p.LearningMaterials)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.CoursesId)
                    .HasConstraintName("FK__LearningM__cours__1CBC4616");

                entity.HasOne(d => d.DeclarativeLessons)
                    .WithMany(p => p.LearningMaterials)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.DeclarativeLessonsId)
                    .HasConstraintName("FK__LearningM__decla__778AC167");

                entity.HasOne(d => d.Lessons)
                    .WithMany(p => p.LearningMaterials)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.LessonsId)
                    .HasConstraintName("FK__LearningM__lesso__1EA48E88");

                entity.HasOne(d => d.Paths)
                    .WithMany(p => p.LearningMaterials)
                    .HasForeignKey(d => d.PathsId)
                    .HasConstraintName("FK__LearningM__paths__797309D9");
            });

            modelBuilder.Entity<Lecturer>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.HourlyRate)
                    .HasColumnType("money")
                    .HasColumnName("hourlyRate");

                entity.Property(e => e.Speciality)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("speciality");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Lecturer)
                    .HasForeignKey<Lecturer>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Lecturers__id__628FA481");
            });

            modelBuilder.Entity<Lesson>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.PathsId, e.CoursesId, e.DeclarativeLessonsId })
                    .HasName("Lessons_pk");

                entity.HasIndex(e => e.Id, "UQ__Lessons__3214EC26438CC650")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PathsId).HasColumnName("paths_ID");

                entity.Property(e => e.CoursesId).HasColumnName("courses_ID");

                entity.Property(e => e.DeclarativeLessonsId).HasColumnName("declarative_Lessons_ID");

                entity.Property(e => e.DateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("dateTime");

                entity.Property(e => e.Description)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Duration)
                    .HasColumnType("time(0)")
                    .HasColumnName("duration");

                entity.Property(e => e.GroupsId).HasColumnName("Groups_ID");

                entity.Property(e => e.LecturersId).HasColumnName("Lecturers_ID");

                entity.Property(e => e.MeetingId)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("MeetingID");

                entity.Property(e => e.StreamsId).HasColumnName("Streams_ID");

                entity.HasOne(d => d.Courses)
                    .WithMany(p => p.Lessons)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.CoursesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Lessons__courses__6E01572D");

                entity.HasOne(d => d.DeclarativeLessons)
                    .WithMany(p => p.Lessons)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.DeclarativeLessonsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Lessons__declara__6D0D32F4");

                entity.HasOne(d => d.Groups)
                    .WithMany(p => p.Lessons)
                    .HasForeignKey(d => d.GroupsId)
                    .HasConstraintName("FK__Lessons__Groups___70DDC3D8");

                entity.HasOne(d => d.Lecturers)
                    .WithMany(p => p.Lessons)
                    .HasForeignKey(d => d.LecturersId)
                    .HasConstraintName("FK__Lessons__Lecture__6FE99F9F");

                entity.HasOne(d => d.Paths)
                    .WithMany(p => p.Lessons)
                    .HasForeignKey(d => d.PathsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Lessons__paths_I__6EF57B66");

                entity.HasOne(d => d.Streams)
                    .WithMany(p => p.Lessons)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.StreamsId)
                    .HasConstraintName("FK__Lessons__Streams__71D1E811");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.AssignmentsId).HasColumnName("assignments_id");

                entity.Property(e => e.Category)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("category");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("content");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.EventsId).HasColumnName("events_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.SubmissionsId).HasColumnName("submissions_id");

                entity.HasOne(d => d.Assignments)
                    .WithMany(p => p.Notifications)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.AssignmentsId)
                    .HasConstraintName("FK__Notificat__assig__04E4BC85");

                entity.HasOne(d => d.Events)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.EventsId)
                    .HasConstraintName("FK__Notificat__event__2BFE89A6");

                entity.HasOne(d => d.Submissions)
                    .WithMany(p => p.Notifications)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.SubmissionsId)
                    .HasConstraintName("FK__Notificat__submi__06CD04F7");
            });

            modelBuilder.Entity<NotificationGroup>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("notification_groups");

                entity.Property(e => e.GroupsId).HasColumnName("groups_ID");

                entity.Property(e => e.NotificationsId).HasColumnName("notifications_ID");

                entity.HasOne(d => d.Groups)
                    .WithMany()
                    .HasForeignKey(d => d.GroupsId)
                    .HasConstraintName("FK__notificat__group__01142BA1");

                entity.HasOne(d => d.Notifications)
                    .WithMany()
                    .HasForeignKey(d => d.NotificationsId)
                    .HasConstraintName("FK__notificat__notif__02084FDA");
            });

            modelBuilder.Entity<NotificationUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("notification_user");

                entity.Property(e => e.NotificationsId).HasColumnName("notifications_ID");

                entity.Property(e => e.UsersId).HasColumnName("users_ID");

                entity.HasOne(d => d.Notifications)
                    .WithMany()
                    .HasForeignKey(d => d.NotificationsId)
                    .HasConstraintName("FK__notificat__notif__02FC7413");

                entity.HasOne(d => d.Users)
                    .WithMany()
                    .HasForeignKey(d => d.UsersId)
                    .HasConstraintName("FK__notificat__users__367C1819");
            });

            modelBuilder.Entity<Path>(entity =>
            {
                entity.HasIndex(e => e.Name, "UQ__Paths__72E12F1BB1F7F5E8")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Stream>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.PathsId, e.CoursesId })
                    .HasName("Streams_pk");

                entity.HasIndex(e => e.Id, "UQ__Streams__3214EC26827AA00E")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PathsId).HasColumnName("paths_ID");

                entity.Property(e => e.CoursesId).HasColumnName("courses_ID");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("end_date");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("start_date");

                entity.Property(e => e.StrearmsIdentity)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("strearms_identity");

                entity.HasOne(d => d.Courses)
                    .WithMany(p => p.Streams)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.CoursesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Streams__courses__571DF1D5");

                entity.HasOne(d => d.Paths)
                    .WithMany(p => p.Streams)
                    .HasForeignKey(d => d.PathsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Streams__paths_I__5629CD9C");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Discount).HasColumnName("discount");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Student)
                    .HasForeignKey<Student>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Students__id__74AE54BC");
            });

            modelBuilder.Entity<StudentParticipateLesson>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.PathsId, e.CoursesId, e.DeclarativeLessonsId, e.LessonsId, e.StudentsId })
                    .HasName("Students_Participate_Lessons_pk");

                entity.ToTable("Student_Participate_Lessons");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PathsId).HasColumnName("paths_ID");

                entity.Property(e => e.CoursesId).HasColumnName("courses_ID");

                entity.Property(e => e.DeclarativeLessonsId).HasColumnName("declarative_Lessons_ID");

                entity.Property(e => e.LessonsId).HasColumnName("lessons_ID");

                entity.Property(e => e.StudentsId).HasColumnName("students_ID");

                entity.Property(e => e.Attendance).HasColumnName("attendance");

                entity.Property(e => e.Mark).HasColumnName("mark");

                entity.Property(e => e.StudentsParticipateLessonsIdentity)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Students_Participate_Lessons_identity");
            });

            modelBuilder.Entity<Submission>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.PathsId, e.CoursesId, e.DeclarativeLessonsId, e.LessonsId, e.AssignmentsId })
                    .HasName("Submissions_pk");

                entity.HasIndex(e => e.Id, "UQ__Submissi__3214EC26FC7F699B")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PathsId).HasColumnName("paths_ID");

                entity.Property(e => e.CoursesId).HasColumnName("courses_ID");

                entity.Property(e => e.DeclarativeLessonsId).HasColumnName("declarative_Lessons_ID");

                entity.Property(e => e.LessonsId).HasColumnName("lessons_ID");

                entity.Property(e => e.AssignmentsId).HasColumnName("assignments_ID");

                entity.Property(e => e.Datetime)
                    .HasColumnType("datetime")
                    .HasColumnName("datetime");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.Mark).HasColumnName("mark");

                entity.Property(e => e.StudentsId).HasColumnName("students_ID");

                entity.Property(e => e.SubmissionsIdentity)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("submissions_identity");

                entity.HasOne(d => d.Assignments)
                    .WithMany(p => p.Submissions)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.AssignmentsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Submissio__assig__0A9D95DB");

                entity.HasOne(d => d.Courses)
                    .WithMany(p => p.Submissions)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.CoursesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Submissio__cours__04E4BC85");

                entity.HasOne(d => d.DeclarativeLessons)
                    .WithMany(p => p.Submissions)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.DeclarativeLessonsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Submissio__decla__0C85DE4D");

                entity.HasOne(d => d.Lessons)
                    .WithMany(p => p.Submissions)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.LessonsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Submissio__lesso__06CD04F7");

                entity.HasOne(d => d.Paths)
                    .WithMany(p => p.Submissions)
                    .HasForeignKey(d => d.PathsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Submissio__paths__0E6E26BF");

                entity.HasOne(d => d.Students)
                    .WithMany(p => p.Submissions)
                    .HasForeignKey(d => d.StudentsId)
                    .HasConstraintName("FK__Submissio__stude__0F624AF8");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Mail, "UQ__Users__7A2129048A1A65BF")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                //entity.Property(e => e.AdditionalInfo)
                //    .HasMaxLength(200)
                //    .IsUnicode(false)
                //    .HasColumnName("additional_info");

                entity.Property(e => e.Cv).HasColumnName("cv");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("firstName");

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("gender");

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("lastName");

                entity.Property(e => e.Mail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("mail");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("phone")
                    .IsFixedLength(true);

                entity.Property(e => e.Picture)
                    .HasColumnType("image")
                    .HasColumnName("picture");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
