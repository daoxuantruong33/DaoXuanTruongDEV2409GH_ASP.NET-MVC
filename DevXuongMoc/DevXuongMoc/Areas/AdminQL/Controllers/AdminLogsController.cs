using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DevXuongMoc.Models;

namespace DevXuongMoc.Areas.AdminQL.Controllers
{
    [Area("AdminQL")]
    public class AdminLogsController : Controller
    {
        private readonly XuongMocContext _context;

        public AdminLogsController(XuongMocContext context)
        {
            _context = context;
        }

        // GET: AdminQL/AdminLogs
        public async Task<IActionResult> Index()
        {
            return View(await _context.AdminLogs.ToListAsync());
        }

        // GET: AdminQL/AdminLogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminLog = await _context.AdminLogs
                .FirstOrDefaultAsync(m => m.LogId == id);
            if (adminLog == null)
            {
                return NotFound();
            }

            return View(adminLog);
        }

        // GET: AdminQL/AdminLogs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminQL/AdminLogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LogId,Status,SessionId,AppCode,ThreadId,StartTime,EndTime,AdminUserId,UserLogin,UserName,IpAddress,ActionCode,ActionName,MenuCode,MenuName,WebpagesActionId,ActionType,ObjectId,Content,Description,LogLevel,ErrorCode")] AdminLog adminLog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adminLog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adminLog);
        }

        // GET: AdminQL/AdminLogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminLog = await _context.AdminLogs.FindAsync(id);
            if (adminLog == null)
            {
                return NotFound();
            }
            return View(adminLog);
        }

        // POST: AdminQL/AdminLogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LogId,Status,SessionId,AppCode,ThreadId,StartTime,EndTime,AdminUserId,UserLogin,UserName,IpAddress,ActionCode,ActionName,MenuCode,MenuName,WebpagesActionId,ActionType,ObjectId,Content,Description,LogLevel,ErrorCode")] AdminLog adminLog)
        {
            if (id != adminLog.LogId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adminLog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminLogExists(adminLog.LogId))
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
            return View(adminLog);
        }

        // GET: AdminQL/AdminLogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminLog = await _context.AdminLogs
                .FirstOrDefaultAsync(m => m.LogId == id);
            if (adminLog == null)
            {
                return NotFound();
            }

            return View(adminLog);
        }

        // POST: AdminQL/AdminLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adminLog = await _context.AdminLogs.FindAsync(id);
            if (adminLog != null)
            {
                _context.AdminLogs.Remove(adminLog);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdminLogExists(int id)
        {
            return _context.AdminLogs.Any(e => e.LogId == id);
        }
    }
}
