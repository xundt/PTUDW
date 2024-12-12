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
    public class EventController : Controller
    {
        private readonly TrungTamDayTreContext _context;

        public EventController(TrungTamDayTreContext context)
        {
            _context = context;
        }

        // GET: Admin/Event
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblEvents.ToListAsync());
        }

        // GET: Admin/Event/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblEvent = await _context.TblEvents
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (tblEvent == null)
            {
                return NotFound();
            }

            return View(tblEvent);
        }

        // GET: Admin/Event/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Event/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventId,EventName,EventType,Description,StartDateTime,EndDateTime,Location,CurrentParticipants,MaxParticipants,Image,Fee,IsActive")] TblEvent tblEvent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblEvent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblEvent);
        }

        // GET: Admin/Event/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblEvent = await _context.TblEvents.FindAsync(id);
            if (tblEvent == null)
            {
                return NotFound();
            }
            return View(tblEvent);
        }

        // POST: Admin/Event/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventId,EventName,EventType,Description,StartDateTime,EndDateTime,Location,CurrentParticipants,MaxParticipants,Image,Fee,IsActive")] TblEvent tblEvent)
        {
            if (id != tblEvent.EventId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblEvent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblEventExists(tblEvent.EventId))
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
            return View(tblEvent);
        }

        // GET: Admin/Event/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblEvent = await _context.TblEvents
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (tblEvent == null)
            {
                return NotFound();
            }

            return View(tblEvent);
        }

        // POST: Admin/Event/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblEvent = await _context.TblEvents.FindAsync(id);
            if (tblEvent != null)
            {
                _context.TblEvents.Remove(tblEvent);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblEventExists(int id)
        {
            return _context.TblEvents.Any(e => e.EventId == id);
        }
    }
}
