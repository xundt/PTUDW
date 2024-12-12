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
    public class TeacherController : Controller
    {
        private readonly TrungTamDayTreContext _context;

        public TeacherController(TrungTamDayTreContext context)
        {
            _context = context;
        }

        // GET: Admin/Teacher
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblTeachers.ToListAsync());
        }

        // GET: Admin/Teacher/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblTeacher = await _context.TblTeachers
                .FirstOrDefaultAsync(m => m.TeacherId == id);
            if (tblTeacher == null)
            {
                return NotFound();
            }

            return View(tblTeacher);
        }

        // GET: Admin/Teacher/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Teacher/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeacherId,TeacherName,Expertise,Experience,Certificate,Image,TeachingAssignment,IsActive")] TblTeacher tblTeacher)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblTeacher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblTeacher);
        }

        // GET: Admin/Teacher/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblTeacher = await _context.TblTeachers.FindAsync(id);
            if (tblTeacher == null)
            {
                return NotFound();
            }
            return View(tblTeacher);
        }

        // POST: Admin/Teacher/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TeacherId,TeacherName,Expertise,Experience,Certificate,Image,TeachingAssignment,IsActive")] TblTeacher tblTeacher)
        {
            if (id != tblTeacher.TeacherId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblTeacher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblTeacherExists(tblTeacher.TeacherId))
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
            return View(tblTeacher);
        }

        // GET: Admin/Teacher/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblTeacher = await _context.TblTeachers
                .FirstOrDefaultAsync(m => m.TeacherId == id);
            if (tblTeacher == null)
            {
                return NotFound();
            }

            return View(tblTeacher);
        }

        // POST: Admin/Teacher/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblTeacher = await _context.TblTeachers.FindAsync(id);
            if (tblTeacher != null)
            {
                _context.TblTeachers.Remove(tblTeacher);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblTeacherExists(int id)
        {
            return _context.TblTeachers.Any(e => e.TeacherId == id);
        }
    }
}
