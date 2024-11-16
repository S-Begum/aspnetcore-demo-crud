using System.ComponentModel.DataAnnotations;

namespace Demo1CoreCRUD.Data.Enums
{
    public enum StatusLabel
    {
        Pending =0,
        [Display(Name = "In-Progess")]
        InProgress = 1,
        [Display(Name = "On-Hold")]
        OnHold = 2,
        Complete = 3,
        [Display(Name = "Delayed")]
        Late = 4
    }
}
