﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TaskControl.Models;

public partial class TaskListContext : DbContext
{
    public TaskListContext()
    {
    }

    public TaskListContext(DbContextOptions<TaskListContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Priority> Priorities { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<TaskCategory> TaskCategories { get; set; }

    public virtual DbSet<TaskPerson> TaskPeople { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=K106\\SQLEXPRESS;Initial Catalog=TaskList;Integrated Security=True;TrustServerCertificate=True;Encrypt=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Category__D54EE9B45F89A7FC");

            entity.ToTable("Category");

            entity.HasIndex(e => e.CategoryName, "UQ__Category__5189E2559003E7B0").IsUnique();

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CategoryName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("category_name");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.PersonId).HasName("PK__People__543848DFD3AEE911");

            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("phone_number");
        });

        modelBuilder.Entity<Priority>(entity =>
        {
            entity.HasKey(e => e.PriorityId).HasName("PK__Priority__EE325785090BEB4C");

            entity.ToTable("Priority");

            entity.Property(e => e.PriorityId).HasColumnName("priority_id");
            entity.Property(e => e.Priority1)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("priority");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__Status__3683B531A9380D82");

            entity.ToTable("Status");

            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.Status1)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("status");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.TaskId).HasName("PK__Tasks__0492148D1184389C");

            entity.HasIndex(e => e.Task1, "UQ__Tasks__E5F92A2D6E2422B2").IsUnique();

            entity.Property(e => e.TaskId).HasColumnName("task_id");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.DueDate).HasColumnName("due_date");
            entity.Property(e => e.PriorityId).HasColumnName("priority_id");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.Task1)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("task");

            entity.HasOne(d => d.Priority).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.PriorityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tasks__priority___3C69FB99");

            entity.HasOne(d => d.Status).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tasks__status_id__3B75D760");
        });

        modelBuilder.Entity<TaskCategory>(entity =>
        {
            entity.HasKey(e => new { e.TaskId, e.CategoryId }).HasName("PK__Task_Cat__59C6FA1644B5EBC0");

            entity.ToTable("Task_Category");

            entity.Property(e => e.TaskId).HasColumnName("task_id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");

            entity.HasOne(d => d.Category).WithMany(p => p.TaskCategories)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Task_Cate__categ__48CFD27E");

            entity.HasOne(d => d.Task).WithMany(p => p.TaskCategories)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Task_Cate__task___47DBAE45");
        });

        modelBuilder.Entity<TaskPerson>(entity =>
        {
            entity.HasKey(e => new { e.TaskId, e.PersonId }).HasName("PK__Task_Peo__E1D1900050340699");

            entity.ToTable("Task_People");

            entity.Property(e => e.TaskId).HasColumnName("task_id");
            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.TimeAssigned).HasColumnName("time_assigned");

            entity.HasOne(d => d.Person).WithMany(p => p.TaskPeople)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Task_Peop__perso__4222D4EF");

            entity.HasOne(d => d.Task).WithMany(p => p.TaskPeople)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Task_Peop__task___412EB0B6");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}