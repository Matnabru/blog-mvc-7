using Horroras.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Horroras.Web.Repositories;
using Horroras.Web.Models.ViewModels;


namespace Horroras.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBlogPostRepository blogPostRepository;
        private readonly ITagInterface tagInterface;

        public HomeController(ILogger<HomeController> logger, IBlogPostRepository blogPostRepository, ITagInterface tagInterface)
        {
            _logger = logger;
            this.blogPostRepository = blogPostRepository;
            this.tagInterface = tagInterface;
        }

        public async Task<IActionResult> Index(string searchQuery, int page = 1)
        {
            const int PageSize = 2;
            var (blogPosts, totalItems) = await blogPostRepository.GetBlogPostsAsync(searchQuery, page, PageSize);
            var tags = await tagInterface.GetAllAsync();
            var model = new HomeViewModel
            {
                BlogPosts = blogPosts,
                Tags = tags,
                SearchQuery = searchQuery,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(totalItems / (double)PageSize)
            };
            return View(model);
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