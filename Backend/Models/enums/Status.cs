using System.ComponentModel.DataAnnotations;

namespace Backend.Models.enums;

public enum Status
{
    [Display(Name="To do")]
    Todo,
    [Display(Name="In Progress")]
    InProgress,
    Review,
    Done
}