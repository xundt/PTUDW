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
    }
}
