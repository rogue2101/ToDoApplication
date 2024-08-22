using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ToDoApp.WebApi.Models;

public partial class ToDoListDatabaseContext : DbContext
{
    public ToDoListDatabaseContext()
    {
    }

    public ToDoListDatabaseContext(DbContextOptions<ToDoListDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ToDoList> ToDoLists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=DESKTOP-5AD1P0N\\SQLEXPRESS;Database=ToDoListDatabase;Trusted_Connection = True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ToDoList>(entity =>
        {
            entity.ToTable("ToDoList");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("createdDateTime");
            entity.Property(e => e.CreatedUserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("createdUserId");
            entity.Property(e => e.IsCompleted).HasColumnName("isCompleted");
            entity.Property(e => e.ModifiedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("modifiedDateTime");
            entity.Property(e => e.ModifiedUserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("modifiedUserId");
            entity.Property(e => e.Task)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("task");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
