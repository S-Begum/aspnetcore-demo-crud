using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Demo1CoreCRUD.ViewModels
{
    public class CreateTaskVM
    {
        [Required(ErrorMessage = "Task is required")]
        [DisplayName("Task")]
        [StringLength(300, MinimumLength = 1, ErrorMessage = "{0} must be at {2} - {1} characters long")]
        public string? Name { get; set; }

        [DisplayName("Due")]
        public DateTime? CompleteDate { get; set; }
        
        public string? Rank { get; set; }

        [DisplayName("Comment")]
        [StringLength(1000, MinimumLength = 1, ErrorMessage = "{0} must be at {2} - {1} characters long")]
        public string? Note { get; set; }

        public DateTime? DateCreated { get; set; }

        [DisplayName("Created By")]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "{0} must be at {2} - {1} characters long")]
        public string? User { get; set; }
    }
}
