namespace ForumApp.Data.Models.Post
{
    using System.ComponentModel.DataAnnotations;
    public class PostFormModel
    {
        [Required]
        [MinLength(DataConstants.TittleMinLenght)]
        [MaxLength(DataConstants.TittleMaxLenght)]
        public string Title { get; set; } = null!;

        [Required]
        [MinLength(DataConstants.ContentMinLenght)]
        [MaxLength(DataConstants.ContentMaxLenght)]
        public string Content { get; set; } = null!;
    }
}
