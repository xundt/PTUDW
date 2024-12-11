using Trung_Tâm_Dạy_Trẻ.Models;
using Microsoft.AspNetCore.Mvc;


namespace Trung_Tâm_Dạy_Trẻ.ViewComponents
{
    public class TeacherViewComponent : ViewComponent
    {
        private readonly TrungTamDayTreContext _context;

        public TeacherViewComponent(TrungTamDayTreContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = _context.TblTeachers
                .Where(m => m.IsActive == true).ToList();

            return await Task.FromResult(View(items));
        }
    }
}
