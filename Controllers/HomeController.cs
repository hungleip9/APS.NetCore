using ASPNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASPNetCore.Controllers
{
    public class HomeController : Controller
    {
        private IPostRepository postRepo;

        public HomeController(IPostRepository _postRepo)
        {
            this.postRepo = _postRepo;
        }
        public async Task<IActionResult> Index()
        {
           List<Post> posts = await postRepo.GetAll();
            return View(posts);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
