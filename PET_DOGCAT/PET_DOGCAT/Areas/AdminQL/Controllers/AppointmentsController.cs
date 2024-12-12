using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PET_DOGCAT.Models;

namespace PET_DOGCAT.Areas.AdminQL.Controllers
{
    [Area("AdminQL")]
    public class AppointmentsController : Controller
    {
        private readonly PetsDogcatContext _context;

        public AppointmentsController(PetsDogcatContext context)
        {
            _context = context;
        }

        // GET: AdminQL/Appointments
        public async Task<IActionResult> Index()
        {
            var petsDogcatContext = _context.Appointments.Include(a => a.Customer).Include(a => a.Pet).Include(a => a.Service);
            return View(await petsDogcatContext.ToListAsync());
        }

        // GET: AdminQL/Appointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments
                .Include(a => a.Customer)
                .Include(a => a.Pet)
                .Include(a => a.Service)
                .FirstOrDefaultAsync(m => m.AppointmentId == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // GET: AdminQL/Appointments/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId");
            ViewData["PetId"] = new SelectList(_context.Pets, "PetId", "PetId");
            ViewData["ServiceId"] = new SelectList(_context.Services, "ServiceId", "ServiceId");
            return View();
        }

        // POST: AdminQL/Appointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AppointmentId,CustomerId,PetId,ServiceId,AppointmentDate,Status,Notes")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appointment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", appointment.CustomerId);
            ViewData["PetId"] = new SelectList(_context.Pets, "PetId", "PetId", appointment.PetId);
            ViewData["ServiceId"] = new SelectList(_context.Services, "ServiceId", "ServiceId", appointment.ServiceId);
            return View(appointment);
        }

        // GET: AdminQL/Appointments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", appointment.CustomerId);
            ViewData["PetId"] = new SelectList(_context.Pets, "PetId", "PetId", appointment.PetId);
            ViewData["ServiceId"] = new SelectList(_context.Services, "ServiceId", "ServiceId", appointment.ServiceId);
            return View(appointment);
        }

        // POST: AdminQL/Appointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AppointmentId,CustomerId,PetId,ServiceId,AppointmentDate,Status,Notes")] Appointment appointment)
        {
            if (id != appointment.AppointmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentExists(appointment.AppointmentId))
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
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", appointment.CustomerId);
            ViewData["PetId"] = new SelectList(_context.Pets, "PetId", "PetId", appointment.PetId);
            ViewData["ServiceId"] = new SelectList(_context.Services, "ServiceId", "ServiceId", appointment.ServiceId);
            return View(appointment);
        }

        // GET: AdminQL/Appointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments
                .Include(a => a.Customer)
                .Include(a => a.Pet)
                .Include(a => a.Service)
                .FirstOrDefaultAsync(m => m.AppointmentId == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // POST: AdminQL/Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentExists(int id)
        {
            return _context.Appointments.Any(e => e.AppointmentId == id);
        }
    }
}
