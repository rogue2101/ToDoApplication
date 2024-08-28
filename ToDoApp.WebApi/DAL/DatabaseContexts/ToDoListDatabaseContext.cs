using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ToDoApp.WebApi.DAL.Entities;

namespace ToDo.WebApi.DAL.DatabaseContexts;

public partial class ToDoListDatabaseContext : DbContext
{
    public ToDoListDatabaseContext()
    {
    }

    public ToDoListDatabaseContext(DbContextOptions<ToDoListDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ToDoEntity> ToDos { get; set; }
}
