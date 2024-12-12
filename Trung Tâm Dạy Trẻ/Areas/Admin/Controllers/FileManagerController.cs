using Microsoft.AspNetCore.Mvc;

namespace Trung_Tâm_Dạy_Trẻ.Areas.Admin.Controllers
{
    public class FileManagerController : Controller
    {
        [Area("Admin")]
        [Route("/Admin/file-manager")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
