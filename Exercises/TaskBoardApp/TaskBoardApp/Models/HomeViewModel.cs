namespace TaskBoardApp.Models
{
    public class HomeViewModel
    {
        public int AllTaskCount { get; init; }
        public List<HomeBoardModel> BoardsWithTaskCounts { get; init; } = null!;
        public int UserTaskCount { get; init; }
    }
}
