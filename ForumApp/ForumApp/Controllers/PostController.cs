namespace ForumApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using ForumApp.Data;
    using ForumApp.Data.Models.Post;
    using Microsoft.EntityFrameworkCore;

    public class PostController : Controller
    {
        private readonly ForumAppDbContext _data;
        public PostController(ForumAppDbContext data)
        {
            _data = data;
        }

        public async Task<IActionResult> All()
        {
            var posts = await _data
                .Posts
                .Select(p => new PostViewModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content
                }).ToListAsync();

            return View(posts);
        }

        public async Task<IActionResult> Add() => View();

        [HttpPost]
        public async Task<IActionResult> Add(PostFormModel model)
        {
            var post = new Post()
            {
                Title = model.Title,
                Content = model.Content
            };
            await _data.AddAsync(post);
            await _data.SaveChangesAsync();

            return RedirectToAction("All");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var post = await _data.Posts.FindAsync(id);

            return View(new PostFormModel()
            {
                Title = post.Title,
                Content = post.Content
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, PostFormModel model)
        {
            var post = await _data.Posts.FindAsync(id);

            post.Title = model.Title;
            post.Content = model.Content;

            await _data.SaveChangesAsync();

            return RedirectToAction("All");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var post = await _data.Posts.FindAsync(id);
            _data.Posts.Remove(post);

            await _data.SaveChangesAsync();

            return RedirectToAction("All");
        }

    }
}
