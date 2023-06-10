using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskBoardApp.Models;
using Task = TaskBoardApp.Models.Task;

namespace TaskBoardApp.Data
{
    public class TaskBoardAppDbContext : IdentityDbContext
    {
        private IdentityUser TestUser { get; set; } = null!;
        private Board OpenBoard { get; set; } = null!;
        private Board InProgressBoard { get; set; } = null!;
        private Board DoneBoard { get; set; } = null!;

        public TaskBoardAppDbContext(DbContextOptions<TaskBoardAppDbContext> options)
            : base(options)
        {
            this.Database.Migrate();
        }

        public DbSet<Board> Boards { get; set; } = null!;
        public DbSet<Task> Tasks { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Task>()
                .HasOne(t => t.Board)
                .WithMany(b => b.Tasks)
                .HasForeignKey(t => t.BoardId)
                .OnDelete(DeleteBehavior.Restrict);

            SeedUsers();
            modelBuilder
                .Entity<IdentityUser>()
                .HasData(TestUser);

            SeedBoards();
            modelBuilder
                .Entity<Board>()
                .HasData(OpenBoard, InProgressBoard, DoneBoard);

            modelBuilder
                .Entity<Task>()
                .HasData(
                new Task
                {
                    Id = 1,
                    Title = "Improve CSS styles",
                    Description = "Implement better styling for all public pages",
                    CreatedOn = DateTime.Now.AddDays(-200),
                    OwnerId = TestUser.Id,
                    BoardId = OpenBoard.Id
                },
                new Task
                {
                    Id = 2,
                    Title = "Android Client App",
                    Description = "Create Android client app for the TaskBoard RESTful API",
                    CreatedOn = DateTime.Now.AddMonths(-5),
                    OwnerId = TestUser.Id,
                    BoardId = DoneBoard.Id,
                },
                new Task
                {
                    Id = 3,
                    Title = "Desktop Client App",
                    Description = "Ceate Windows Forms desktop app client for the TaskBoard RESTful API",
                    CreatedOn = DateTime.Now.AddDays(-1),
                    OwnerId = TestUser.Id,
                    BoardId = InProgressBoard.Id,
                },
                new Task
                {
                    Id = 4,
                    Title = "Create Tasks",
                    Description = "Implemet [Create Task] page for adding new tasks",
                    CreatedOn = DateTime.Now.AddYears(-1),
                    OwnerId = TestUser.Id,
                    BoardId = DoneBoard.Id,
                });


            base.OnModelCreating(modelBuilder);
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            TestUser = new IdentityUser()
            {
                UserName = "test@softuni.bg",
                NormalizedUserName = "TEST@SOFTUNI.BG"
            };

            TestUser.PasswordHash = hasher.HashPassword(TestUser, "softuni");
        }

        private void SeedBoards()
        {
            OpenBoard = new Board()
            {
                Id = 1,
                Name = "Open"
            };
            InProgressBoard = new Board()
            {
                Id = 2,
                Name = "In Progress"
            };
            DoneBoard = new Board()
            {
                Id = 3,
                Name = "Done"
            };
        }


    }
}