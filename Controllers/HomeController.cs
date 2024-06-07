using ASPNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASPNetCore.Controllers
{
    public class HomeController : Controller
    {
        private UnitOfWork unitOfWork;

        public HomeController(NewDbContext context)
        {
            this.unitOfWork = new UnitOfWork(context);
        }
        public async Task<IActionResult> Index()
        {
           List<Post> posts = await unitOfWork.PostReponsitory.GetAll();
            return View(posts);
        }
        [Route("post/{slug}-{id:int}")]

        public async Task<ViewResult> ViewPost(int id)
        {
            var data = await unitOfWork.PostReponsitory.FindById(id);
            return View(data);
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
