﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace TaskControl.Models;

public partial class Priority
{
    public int PriorityId { get; set; }

    public string Priority1 { get; set; }

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}