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
    public class ProductMaterialsController : Controller
    {
        private readonly XuongMocContext _context;

        public ProductMaterialsController(XuongMocContext context)
        {
            _context = context;
        }

        // GET: AdminQL/ProductMaterials
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductMaterials.ToListAsync());
        }

        // GET: AdminQL/ProductMaterials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productMaterial = await _context.ProductMaterials
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productMaterial == null)
            {
                return NotFound();
            }

            return View(productMaterial);
        }

        // GET: AdminQL/ProductMaterials/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminQL/ProductMaterials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Pid,Mid")] ProductMaterial productMaterial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productMaterial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productMaterial);
        }

        // GET: AdminQL/ProductMaterials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productMaterial = await _context.ProductMaterials.FindAsync(id);
            if (productMaterial == null)
            {
                return NotFound();
            }
            return View(productMaterial);
        }

        // POST: AdminQL/ProductMaterials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Pid,Mid")] ProductMaterial productMaterial)
        {
            if (id != productMaterial.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productMaterial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductMaterialExists(productMaterial.Id))
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
            return View(productMaterial);
        }

        // GET: AdminQL/ProductMaterials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productMaterial = await _context.ProductMaterials
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productMaterial == null)
            {
                return NotFound();
            }

            return View(productMaterial);
        }

        // POST: AdminQL/ProductMaterials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productMaterial = await _context.ProductMaterials.FindAsync(id);
            if (productMaterial != null)
            {
                _context.ProductMaterials.Remove(productMaterial);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductMaterialExists(int id)
        {
            return _context.ProductMaterials.Any(e => e.Id == id);
        }
    }
}
