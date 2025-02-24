using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyVienPhi.Models;

namespace QuanLyVienPhi.Areas.Admins.Controllers
{
    public class YtumsController : BaseController
    {
        private readonly QuanLyVienPhiContext _context;

        public YtumsController(QuanLyVienPhiContext context)
        {
            _context = context;
        }

        // GET: Admins/Ytums
        public async Task<IActionResult> Index()
        {
            return View(await _context.Yta.ToListAsync());
        }

        // GET: Admins/Ytums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ytum = await _context.Yta
                .FirstOrDefaultAsync(m => m.YtaId == id);
            if (ytum == null)
            {
                return NotFound();
            }

            return View(ytum);
        }

        // GET: Admins/Ytums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admins/Ytums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("YtaId,HoTen,DienThoai,Email")] Ytum ytum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ytum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ytum);
        }

        // GET: Admins/Ytums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ytum = await _context.Yta.FindAsync(id);
            if (ytum == null)
            {
                return NotFound();
            }
            return View(ytum);
        }

        // POST: Admins/Ytums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("YtaId,HoTen,DienThoai,Email")] Ytum ytum)
        {
            if (id != ytum.YtaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ytum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YtumExists(ytum.YtaId))
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
            return View(ytum);
        }

        // GET: Admins/Ytums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ytum = await _context.Yta
                .FirstOrDefaultAsync(m => m.YtaId == id);
            if (ytum == null)
            {
                return NotFound();
            }

            return View(ytum);
        }

        // POST: Admins/Ytums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ytum = await _context.Yta.FindAsync(id);
            if (ytum != null)
            {
                _context.Yta.Remove(ytum);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YtumExists(int id)
        {
            return _context.Yta.Any(e => e.YtaId == id);
        }
    }
}
