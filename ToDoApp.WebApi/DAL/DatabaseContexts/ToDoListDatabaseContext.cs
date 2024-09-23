using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDoApp.WebApi.DAL.Entities;
using ToDoApp.WebApi.DAL.Identity;

namespace ToDo.WebApi.DAL.DatabaseContexts;

public partial class ToDoListDatabaseContext : IdentityDbContext<ApplicationUser>
{
    public ToDoListDatabaseContext(DbContextOptions<ToDoListDatabaseContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }

    public virtual DbSet<ToDoEntity> ToDos { get; set; }
}
