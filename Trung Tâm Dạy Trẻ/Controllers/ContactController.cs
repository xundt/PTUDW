using Microsoft.AspNetCore.Mvc;
using Trung_Tâm_Dạy_Trẻ.Models;

namespace Trung_Tâm_Dạy_Trẻ.Controllers
{
    public class ContactController : Controller
    {
        private readonly TrungTamDayTreContext _context;

        public ContactController(TrungTamDayTreContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string name, string phone, string email, string message)
        {
            try
            {
                TblContact contact = new TblContact();
                contact.Name = name;
                contact.Phone = phone;
                contact.Email = email;
                contact.Message = message;
                await _context.AddAsync(contact);
                await _context.SaveChangesAsync();
                return Json(new { status = true });
            }
            catch
            {
                return Json(new { status = false });
            }
        }
    }
}
