using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Trung_Tâm_Dạy_Trẻ.Models;

public partial class TrungTamDayTreContext : DbContext
{
    public TrungTamDayTreContext()
    {
    }

    public TrungTamDayTreContext(DbContextOptions<TrungTamDayTreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblAccount> TblAccounts { get; set; }

    public virtual DbSet<TblAttendance> TblAttendances { get; set; }

    public virtual DbSet<TblBlog> TblBlogs { get; set; }

    public virtual DbSet<TblBlogComment> TblBlogComments { get; set; }

    public virtual DbSet<TblClass> TblClasses { get; set; }

    public virtual DbSet<TblContact> TblContacts { get; set; }

    public virtual DbSet<TblCourse> TblCourses { get; set; }

    public virtual DbSet<TblCourseDetail> TblCourseDetails { get; set; }

    public virtual DbSet<TblCourseEvaluation> TblCourseEvaluations { get; set; }

    public virtual DbSet<TblEvent> TblEvents { get; set; }

    public virtual DbSet<TblEventRegistration> TblEventRegistrations { get; set; }

    public virtual DbSet<TblFinancialTransaction> TblFinancialTransactions { get; set; }

    public virtual DbSet<TblMenu> TblMenus { get; set; }

    public virtual DbSet<TblRole> TblRoles { get; set; }

    public virtual DbSet<TblStudent> TblStudents { get; set; }

    public virtual DbSet<TblTeacher> TblTeachers { get; set; }

    public virtual DbSet<TblTuition> TblTuitions { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblAccount>(entity =>
        {
            entity.HasKey(e => e.AccountId);

            entity.ToTable("TblAccount");

            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.RoleId).HasColumnName("RoleID");

            entity.HasOne(d => d.Role).WithMany(p => p.TblAccounts)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_TblAccount_TblRole");
        });

        modelBuilder.Entity<TblAttendance>(entity =>
        {
            entity.HasKey(e => e.AttendanceId);

            entity.ToTable("tblAttendance");

            entity.Property(e => e.AttendanceId).HasColumnName("AttendanceID");
            entity.Property(e => e.ClassId).HasColumnName("ClassID");
            entity.Property(e => e.StudenId).HasColumnName("StudenID");

            entity.HasOne(d => d.Class).WithMany(p => p.TblAttendances)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK_tblAttendance_TblClass");

            entity.HasOne(d => d.Studen).WithMany(p => p.TblAttendances)
                .HasForeignKey(d => d.StudenId)
                .HasConstraintName("FK_tblAttendance_TblStudent");
        });

        modelBuilder.Entity<TblBlog>(entity =>
        {
            entity.HasKey(e => e.BlogId);

            entity.ToTable("TblBlog");

            entity.Property(e => e.BlogId).HasColumnName("BlogID");
            entity.Property(e => e.AccountId).HasColumnName("AccountID");
        });

        modelBuilder.Entity<TblBlogComment>(entity =>
        {
            entity.HasKey(e => e.CommentId);

            entity.ToTable("TblBlogComment");

            entity.Property(e => e.CommentId).HasColumnName("CommentID");
            entity.Property(e => e.BlogId).HasColumnName("BlogID");

            entity.HasOne(d => d.Blog).WithMany(p => p.TblBlogComments)
                .HasForeignKey(d => d.BlogId)
                .HasConstraintName("FK_TblBlogComment_TblBlog");
        });

        modelBuilder.Entity<TblClass>(entity =>
        {
            entity.HasKey(e => e.ClassId);

            entity.ToTable("TblClass");

            entity.Property(e => e.ClassId)
                .ValueGeneratedNever()
                .HasColumnName("ClassID");
            entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

            entity.HasOne(d => d.Teacher).WithMany(p => p.TblClasses)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("FK_TblClass_tblTeacher");
        });

        modelBuilder.Entity<TblContact>(entity =>
        {
            entity.HasKey(e => e.ContactId);

            entity.ToTable("TblContact");

            entity.Property(e => e.ContactId).HasColumnName("ContactID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblCourse>(entity =>
        {
            entity.HasKey(e => e.CourseId);

            entity.ToTable("TblCourse");

            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

            entity.HasOne(d => d.TeacherNavigation).WithMany(p => p.TblCourses)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("FK_TblCourse_tblTeacher");
        });

        modelBuilder.Entity<TblCourseDetail>(entity =>
        {
            entity.HasKey(e => e.CourseDetailId);

            entity.ToTable("TblCourseDetail");

            entity.Property(e => e.CourseDetailId).HasColumnName("CourseDetailID");
            entity.Property(e => e.CourseId).HasColumnName("CourseID");

            entity.HasOne(d => d.Course).WithMany(p => p.TblCourseDetails)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK_TblCourseDetail_TblCourse");
        });

        modelBuilder.Entity<TblCourseEvaluation>(entity =>
        {
            entity.HasKey(e => e.EvaluationId);

            entity.ToTable("TblCourseEvaluation");

            entity.Property(e => e.EvaluationId).HasColumnName("EvaluationID");
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.StudentId).HasColumnName("StudentID");

            entity.HasOne(d => d.Course).WithMany(p => p.TblCourseEvaluations)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK_TblCourseEvaluation_TblCourse");

            entity.HasOne(d => d.Student).WithMany(p => p.TblCourseEvaluations)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_TblCourseEvaluation_TblStudent");
        });

        modelBuilder.Entity<TblEvent>(entity =>
        {
            entity.HasKey(e => e.EventId);

            entity.ToTable("TblEvent");

            entity.Property(e => e.EventId).HasColumnName("EventID");
        });

        modelBuilder.Entity<TblEventRegistration>(entity =>
        {
            entity.HasKey(e => e.EventRegistrationId);

            entity.ToTable("TblEventRegistration");

            entity.Property(e => e.EventRegistrationId).HasColumnName("EventRegistrationID");
            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.StudentId).HasColumnName("StudentID");

            entity.HasOne(d => d.Event).WithMany(p => p.TblEventRegistrations)
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("FK_TblEventRegistration_TblEvent");

            entity.HasOne(d => d.Student).WithMany(p => p.TblEventRegistrations)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_TblEventRegistration_TblStudent");
        });

        modelBuilder.Entity<TblFinancialTransaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId);

            entity.ToTable("TblFinancialTransaction");

            entity.Property(e => e.TransactionId).HasColumnName("TransactionID");
        });

        modelBuilder.Entity<TblMenu>(entity =>
        {
            entity.HasKey(e => e.MenuId);

            entity.ToTable("TblMenu");

            entity.Property(e => e.MenuId).HasColumnName("MenuID");
            entity.Property(e => e.ParentId).HasColumnName("ParentID");
        });

        modelBuilder.Entity<TblRole>(entity =>
        {
            entity.HasKey(e => e.RoleId);

            entity.ToTable("TblRole");

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
        });

        modelBuilder.Entity<TblStudent>(entity =>
        {
            entity.HasKey(e => e.StudentId);

            entity.ToTable("TblStudent");

            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.Gender).HasMaxLength(10);
        });

        modelBuilder.Entity<TblTeacher>(entity =>
        {
            entity.HasKey(e => e.TeacherId);

            entity.ToTable("tblTeacher");

            entity.Property(e => e.TeacherId).HasColumnName("TeacherID");
        });

        modelBuilder.Entity<TblTuition>(entity =>
        {
            entity.HasKey(e => e.TuitionId);

            entity.ToTable("tblTuition");

            entity.Property(e => e.TuitionId).HasColumnName("TuitionID");
            entity.Property(e => e.ClassId).HasColumnName("ClassID");
            entity.Property(e => e.StudenId).HasColumnName("StudenID");

            entity.HasOne(d => d.Class).WithMany(p => p.TblTuitions)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK_tblTuition_TblClass");

            entity.HasOne(d => d.Studen).WithMany(p => p.TblTuitions)
                .HasForeignKey(d => d.StudenId)
                .HasConstraintName("FK_tblTuition_TblStudent");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
