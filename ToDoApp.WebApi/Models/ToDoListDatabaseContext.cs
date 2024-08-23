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

    public virtual DbSet<ToDoList> ToDos { get; set; }
}
