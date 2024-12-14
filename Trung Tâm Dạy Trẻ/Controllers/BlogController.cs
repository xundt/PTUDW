using Microsoft.AspNetCore.Mvc;
using Trung_Tâm_Dạy_Trẻ.Models;
using Microsoft.EntityFrameworkCore;

namespace Trung_Tâm_Dạy_Trẻ.Controllers
{
    public class BlogController : Controller
    {
        private readonly TrungTamDayTreContext _context;
        public BlogController(TrungTamDayTreContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }


        [Route("/blog/{alias}-{id}.html")]
        public async Task <IActionResult> Details(int? id)
        {
            if (id == null || _context.TblBlogs == null)
            {
                return NotFound();
            }

            var blogs = await _context.TblBlogs.FirstOrDefaultAsync(m => m.BlogId == id);

            if (blogs == null)
            {
                return NotFound();
            }

            return View(blogs);
        }
    }
}
