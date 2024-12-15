using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trung_Tâm_Dạy_Trẻ.Models;

namespace Trung_Tâm_Dạy_Trẻ.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly TrungTamDayTreContext _context;

        public HomeController(TrungTamDayTreContext db)
        {
            _context = db;
        }

        public IActionResult Index()
        {
            // Tổng tiền khóa học
            var totalOrderCourse = _context.TblCourses.Sum(c => c.Tuition);

            // Tổng số giảng viên
            var totalTeacher = _context.TblTeachers.Count();

            // Tổng số học viên
            var totalStudent = _context.TblCourses.Sum(c => c.MaxStudents);

            // Tổng số bài viết
            var totalBlog = _context.TblBlogs.Count();

            ViewData["TotalOrderCourse"] = totalOrderCourse;
            ViewData["TotalTeacher"] = totalTeacher;
            ViewData["TotalStudent"] = totalStudent;
            ViewData["TotalBlog"] = totalBlog;

            return View();
        }
    }
}
