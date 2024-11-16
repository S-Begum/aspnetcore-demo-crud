using System;
using System.Collections.Generic;

namespace Demo1CoreCRUD.Models;

public partial class ToDoList
{
    public int Id { get; set; }

    public string? Task { get; set; }

    public DateTime? DueDate { get; set; }

    public string? Status { get; set; }

    public string? Comment { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? CreatedBy { get; set; }
}
