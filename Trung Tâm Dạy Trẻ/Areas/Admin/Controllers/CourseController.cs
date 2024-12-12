using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Trung_Tâm_Dạy_Trẻ.Models;

namespace Trung_Tâm_Dạy_Trẻ.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController : Controller
    {
        private readonly TrungTamDayTreContext _context;

        public CourseController(TrungTamDayTreContext context)
        {
            _context = context;
        }

        // GET: Admin/Course
        public async Task<IActionResult> Index()
        {
            var trungTamDayTreContext = _context.TblCourses.Include(t => t.TeacherNavigation);
            return View(await trungTamDayTreContext.ToListAsync());
        }

        // GET: Admin/Course/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCourse = await _context.TblCourses
                .Include(t => t.TeacherNavigation)
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if (tblCourse == null)
            {
                return NotFound();
            }

            return View(tblCourse);
        }

        // GET: Admin/Course/Create
        public IActionResult Create()
        {
            ViewData["TeacherId"] = new SelectList(_context.TblTeachers, "TeacherId", "TeacherId");
            return View();
        }

        // POST: Admin/Course/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseId,TeacherId,CourseName,Description,CourseType,AgeGroup,Duration,Tuition,MaxStudents,MainContent,Lessons,TotalClassHour,ImageTeacher,Teacher,Image,RegistrationRequirements,StartDate,EndDate,IsActive")] TblCourse tblCourse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblCourse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TeacherId"] = new SelectList(_context.TblTeachers, "TeacherId", "TeacherId", tblCourse.TeacherId);
            return View(tblCourse);
        }

        // GET: Admin/Course/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCourse = await _context.TblCourses.FindAsync(id);
            if (tblCourse == null)
            {
                return NotFound();
            }
            ViewData["TeacherId"] = new SelectList(_context.TblTeachers, "TeacherId", "TeacherId", tblCourse.TeacherId);
            return View(tblCourse);
        }

        // POST: Admin/Course/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourseId,TeacherId,CourseName,Description,CourseType,AgeGroup,Duration,Tuition,MaxStudents,MainContent,Lessons,TotalClassHour,ImageTeacher,Teacher,Image,RegistrationRequirements,StartDate,EndDate,IsActive")] TblCourse tblCourse)
        {
            if (id != tblCourse.CourseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblCourse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblCourseExists(tblCourse.CourseId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["TeacherId"] = new SelectList(_context.TblTeachers, "TeacherId", "TeacherId", tblCourse.TeacherId);
            return View(tblCourse);
        }

        // GET: Admin/Course/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCourse = await _context.TblCourses
                .Include(t => t.TeacherNavigation)
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if (tblCourse == null)
            {
                return NotFound();
            }

            return View(tblCourse);
        }

        // POST: Admin/Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblCourse = await _context.TblCourses.FindAsync(id);
            if (tblCourse != null)
            {
                _context.TblCourses.Remove(tblCourse);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblCourseExists(int id)
        {
            return _context.TblCourses.Any(e => e.CourseId == id);
        }
    }
}
