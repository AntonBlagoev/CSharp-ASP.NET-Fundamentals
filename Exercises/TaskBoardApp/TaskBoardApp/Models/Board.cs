namespace TaskBoardApp.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;

    using static TaskBoardApp.Data.DataConstants.Board;

    public class Board
    {
        public Board()
        {
            Tasks = new List<Task>();
        }
        public int Id { get; set; }

        [Required]
        [MaxLength(BoardMaxName)]
        public string Name { get; set; } = null!;
        public virtual IEnumerable<Task> Tasks { get; set; } = null!;
    }
}
