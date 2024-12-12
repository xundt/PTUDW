using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Trung_Tâm_Dạy_Trẻ.Models;

namespace Trung_Tâm_Dạy_Trẻ.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuController : Controller
    {
        private readonly TrungTamDayTreContext _context;

        public MenuController(TrungTamDayTreContext context)
        {
            _context = context;
        }

        // GET: Admin/Menu
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblMenus.ToListAsync());
        }

        // GET: Admin/Menu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblMenu = await _context.TblMenus
                .FirstOrDefaultAsync(m => m.MenuId == id);
            if (tblMenu == null)
            {
                return NotFound();
            }

            return View(tblMenu);
        }

        // GET: Admin/Menu/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Menu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MenuId,Title,Alias,Description,Levels,ParentId,Position,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,IsActive")] TblMenu tbMenu)
        {
            if (ModelState.IsValid)
            {
                tbMenu.Alias = Trung_Tâm_Dạy_Trẻ.Utilities.Function.TittleGenerationAlias(tbMenu.Title);

                _context.Add(tbMenu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbMenu);
        }

        // GET: Admin/Menu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblMenu = await _context.TblMenus.FindAsync(id);
            if (tblMenu == null)
            {
                return NotFound();
            }
            return View(tblMenu);
        }

        // POST: Admin/Menu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MenuId,Title,Alias,Description,ParentId,Position,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,IsActive")] TblMenu tblMenu)
        {
            if (id != tblMenu.MenuId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var originalMenu = await _context.TblMenus.AsNoTracking().FirstOrDefaultAsync(m => m.MenuId == id);

                    if (originalMenu == null)
                    {
                        return NotFound();
                    }

                    if (originalMenu.Title != tblMenu.Title)
                    {
                        tblMenu.Alias = Trung_Tâm_Dạy_Trẻ.Utilities.Function.TittleGenerationAlias(tblMenu.Title);
                    }

                    _context.Update(tblMenu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblMenuExists(tblMenu.MenuId))
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
            return View(tblMenu);
        }

        // GET: Admin/Menu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblMenu = await _context.TblMenus
                .FirstOrDefaultAsync(m => m.MenuId == id);
            if (tblMenu == null)
            {
                return NotFound();
            }

            return View(tblMenu);
        }

        // POST: Admin/Menu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblMenu = await _context.TblMenus.FindAsync(id);
            if (tblMenu != null)
            {
                _context.TblMenus.Remove(tblMenu);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblMenuExists(int id)
        {
            return _context.TblMenus.Any(e => e.MenuId == id);
        }
    }
}
