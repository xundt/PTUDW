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
    public class BlogController : Controller
    {
        private readonly TrungTamDayTreContext _context;

        public BlogController(TrungTamDayTreContext context)
        {
            _context = context;
        }

        // GET: Admin/Blog
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblBlogs.ToListAsync());
        }

        // GET: Admin/Blog/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblBlog = await _context.TblBlogs
                .FirstOrDefaultAsync(m => m.BlogId == id);
            if (tblBlog == null)
            {
                return NotFound();
            }

            return View(tblBlog);
        }

        // GET: Admin/Blog/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Blog/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BlogId,Title,Alias,Description,Detail,Image,ImageTeacher,SeoTitle,SeoDescription,SeoKeywords,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,AccountId,IsActive")] TblBlog tblBlog)
        {
            if (ModelState.IsValid)
            {
                tblBlog.Alias = Trung_Tâm_Dạy_Trẻ.Utilities.Function.TittleGenerationAlias(tblBlog.Title);
                _context.Add(tblBlog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblBlog);
        }

        // GET: Admin/Blog/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblBlog = await _context.TblBlogs.FindAsync(id);
            if (tblBlog == null)
            {
                return NotFound();
            }
            return View(tblBlog);
        }

        // POST: Admin/Blog/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BlogId,Title,Alias,Description,Detail,Image,ImageTeacher,SeoTitle,SeoDescription,SeoKeywords,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,AccountId,IsActive")] TblBlog tblBlog)
        {
            if (id != tblBlog.BlogId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var originalBlog = await _context.TblBlogs.AsNoTracking().FirstOrDefaultAsync(m => m.BlogId == id);

                    if (originalBlog == null)
                    {
                        return NotFound();
                    }

                    if (originalBlog.Title != tblBlog.Title)
                    {
                        tblBlog.Alias = Trung_Tâm_Dạy_Trẻ.Utilities.Function.TittleGenerationAlias(tblBlog.Title);
                    }
                    _context.Update(tblBlog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblBlogExists(tblBlog.BlogId))
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
            return View(tblBlog);
        }

        // GET: Admin/Blog/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblBlog = await _context.TblBlogs
                .FirstOrDefaultAsync(m => m.BlogId == id);
            if (tblBlog == null)
            {
                return NotFound();
            }

            return View(tblBlog);
        }

        // POST: Admin/Blog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblBlog = await _context.TblBlogs.FindAsync(id);
            if (tblBlog != null)
            {
                _context.TblBlogs.Remove(tblBlog);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblBlogExists(int id)
        {
            return _context.TblBlogs.Any(e => e.BlogId == id);
        }
    }
}
