using ForumApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Data
{
    public class ForumAppDbContext : DbContext
    {
        private Post FirstPost { get; set; }
        private Post SecondPost { get; set; }
        private Post ThirdPost { get; set; }

        public ForumAppDbContext(DbContextOptions<ForumAppDbContext> options)
            : base(options)
        {

        }

        public DbSet<Post> Posts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedPost();
            modelBuilder.Entity<Post>().HasData(FirstPost, SecondPost, ThirdPost);

            base.OnModelCreating(modelBuilder);
        }

        private void SeedPost()
        {
            FirstPost = new Post()
            {
                Id = 1,
                Title = "My first post",
                Content = "My first post will be about performing CRUD operation in MVC. It's so much fun!"
            };
            SecondPost = new Post()
            {
                Id = 2,
                Title = "My second post",
                Content = "This is my second post CRUD operation in MVC are getting more and more intersting!"
            };
            ThirdPost = new Post()
            {
                Id = 3,
                Title = "My third post",
                Content = "Hello there! I;m getting better and better with the CRUD operation in MVC. Stay tuned!"
            };
        }



    }
}
