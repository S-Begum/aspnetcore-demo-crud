using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Demo1CoreCRUD.ViewModels
{
    public class EditTaskVM
    {
        public int TaskId { get; set; }

        [Required(ErrorMessage = "Task is required")]
        [DisplayName("Task")]
        [StringLength(300, MinimumLength = 1, ErrorMessage = "The {0} must be at {2} - {1} characters long")]
        public string? Name { get; set; }

        [DisplayName("Due")]
        public DateTime? CompleteDate { get; set; }

        [DisplayName("Status")]
        [Required(ErrorMessage = "Status is required")]
        public string? StatusLabel { get; set; }

        [DisplayName("Comment")]
        [StringLength(1000, MinimumLength = 1, ErrorMessage = "{0} must be at {2} - {1} characters long")]
        public string? Note { get; set; }

        [DisplayName("Created On")]
        public DateTime? DateCreated { get; set; }

        [DisplayName("Created By")]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "{0} must be at {2} - {1} characters long")]
        public string? User { get; set; }
    }
}