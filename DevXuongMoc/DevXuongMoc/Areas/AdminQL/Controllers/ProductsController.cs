using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DevXuongMoc.Models;
using X.PagedList;

namespace DevXuongMoc.Areas.AdminQL.Controllers
{
    [Area("AdminQL")]
    public class ProductsController : Controller
    {
        private readonly XuongMocContext _context;

        public ProductsController(XuongMocContext context)
        {
            _context = context;
        }


        // GET: AdminQL/AdminUsers
        public async Task<IActionResult> Index(string name, int page = 1)
        {
            //số bản ghi trên 1 trang
            int limit = 6;

            // var category = await _context.Categories.ToListAsync();
            var Products = await _context.Products.OrderBy(c => c.Id).ToPagedListAsync(page, limit);
            // nếu có tham số name trên url
            if (!String.IsNullOrEmpty(name))
            {
                Products = await _context.Products.Where(c => c.Title.Contains(name)).OrderBy(c => c.Id).ToPagedListAsync(page, limit);
            }
            ViewBag.keyword = name;
            return View(Products);
        }

        // GET: AdminQL/Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: AdminQL/Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminQL/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cid,Code,Title,Description,Content,Image,MetaTitle,MetaKeyword,MetaDescription,Slug,PriceOld,PriceNew,Size,Views,Likes,Star,Home,Hot,CreatedDate,UpdatedDate,AdminCreated,AdminUpdated,Status,Isdelete")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: AdminQL/Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: AdminQL/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Cid,Code,Title,Description,Content,Image,MetaTitle,MetaKeyword,MetaDescription,Slug,PriceOld,PriceNew,Size,Views,Likes,Star,Home,Hot,CreatedDate,UpdatedDate,AdminCreated,AdminUpdated,Status,Isdelete")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            return View(product);
        }

        // GET: AdminQL/AdminUsers/Delete/5

        // POST: AdminQL/AdminUsers/Delete/5
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var user = _context.Products.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                // Nếu không tìm thấy người dùng, redirect đến danh sách hoặc hiển thị lỗi
                return NotFound();
            }

            // Tiến hành xóa người dùng
            _context.Products.Remove(user);
            _context.SaveChanges();

            // Redirect về trang danh sách người dùng hoặc trang khác sau khi xóa thành công
            return RedirectToAction(nameof(Index));  // Giả sử bạn sẽ chuyển hướng về trang danh sách người dùng
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
