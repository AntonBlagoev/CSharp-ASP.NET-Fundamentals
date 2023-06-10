namespace TaskBoardApp.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;

    using static TaskBoardApp.Data.DataConstants.Task;

    public class Task
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(TaskMaxTitle)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(TaskMaxDescription)]
        public string Description { get; set; } = null!;
        public DateTime CreatedOn { get; set; }

       
        public int BoardId { get; set; }
        public Board Board { get; set; } = null!;

        
        public string OwnerId { get; set; } = null!;
        public IdentityUser Owner { get; set; } = null!;
    }
}
