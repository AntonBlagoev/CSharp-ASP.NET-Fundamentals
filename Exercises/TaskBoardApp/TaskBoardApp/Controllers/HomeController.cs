namespace TaskBoardApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;
    using TaskBoardApp.Data;
    using TaskBoardApp.Models;

    public class HomeController : Controller
    {
        private readonly TaskBoardAppDbContext _data;
        public HomeController(TaskBoardAppDbContext context)
        {
            _data = context;
        }

        public async Task<IActionResult> Index()
        {
            //var taskBoards = _data
            //    .Boards
            //    .Select(b => b.Name)
            //    .Distinct();

            //var tasksCounts = new List<HomeBoardModel>();

            //foreach (var boardName in taskBoards)
            //{

            //    tasksCounts.Add(new HomeBoardModel()
            //    {
            //        BoardName = boardName,
            //        TasksCount = _data.Tasks.Where(t => t.Board.Name == boardName).Count()
            //    });
            //}

            //var userTasksCount = -1;

            //if (User.Identity.IsAuthenticated)
            //{
            //    var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //    userTasksCount = _data.Tasks.Where(t => t.OwnerId == currentUserId).Count();
            //}

            //var homeModel = new HomeViewModel()
            //{
            //    AllTaskCount = _data.Tasks.Count(),
            //    BoardsWithTaskCounts = tasksCounts,
            //    UserTaskCount = userTasksCount
            //};

           
                List<string> taskBoards = _data.Boards.Select(b => b.Name).Distinct().ToList();
                var tasksCount = new List<HomeBoardModel>();
                foreach (var boardName in taskBoards)
                {
                    int tasksInBoard = _data.Tasks.Where(t => t.Board.Name == boardName).Count();
                    tasksCount.Add(new HomeBoardModel
                    {
                        BoardName = boardName,
                        TasksCount = tasksInBoard
                    });
                }

                var userTasksCount = -1;

                if (this.User.Identity.IsAuthenticated)
                {
                    var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    userTasksCount = _data.Tasks.Where(t => t.OwnerId == currentUserId).Count();
                }

                var homeModel = new HomeViewModel
                {
                    AllTaskCount = _data.Tasks.Count(),
                    BoardsWithTaskCounts = tasksCount,
                    UserTaskCount = userTasksCount
                };
                return View(homeModel);
        }

    }
}