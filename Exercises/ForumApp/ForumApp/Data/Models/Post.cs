namespace ForumApp.Data
{
    using System.ComponentModel.DataAnnotations;


    public class Post
    {
        public int Id { get; set; }

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
