using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trung_Tâm_Dạy_Trẻ.Models;

namespace Trung_Tâm_Dạy_Trẻ.Areas.Admin.Components
{
    [ViewComponent(Name = "AdminMenu")]
    public class AdminMenuComponent : ViewComponent
    {
        private readonly TrungTamDayTreContext _context;

        public AdminMenuComponent(TrungTamDayTreContext db)
        {
            _context = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var mnlist = _context.TblAdminMenus.Where(mn => mn.IsActive ?? true).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", mnlist));
        }
    }
}
