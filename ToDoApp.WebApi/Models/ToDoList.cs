﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoApp.WebApi.Models;

[Table("ToDo")]
public partial class ToDoList
{
    public int Id { get; set; }

    public string? Task { get; set; }

    public bool? IsCompleted { get; set; }

    public string? CreatedUserId { get; set; }

    public DateTime? CreatedDateTime { get; set; }

    public string? ModifiedUserId { get; set; }

    public DateTime? ModifiedDateTime { get; set; }
}
