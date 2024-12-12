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
    public class NewsController : Controller
    {
        private readonly XuongMocContext _context;

        public NewsController(XuongMocContext context)
        {
            _context = context;
        }

        // GET: AdminQL/News
        public async Task<IActionResult> Index(string name, int page = 1)
        {
            //số bản ghi trên 1 trang
            int limit = 6;

            // var category = await _context.Categories.ToListAsync();
            var News = await _context.News.OrderBy(c => c.Id).ToPagedListAsync(page, limit);
            // nếu có tham số name trên url
            if (!String.IsNullOrEmpty(name))
            {
                News = await _context.News.Where(c => c.Code.Contains(name)).OrderBy(c => c.Id).ToPagedListAsync(page, limit);
            }
            ViewBag.keyword = name;
            return View(News);
        }

        // GET: AdminQL/News/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News
                .FirstOrDefaultAsync(m => m.Id == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        // GET: AdminQL/News/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminQL/News/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Code,Title,Description,Content,Image,MetaTitle,MainKeyword,MetaKeyword,MetaDescription,Slug,Views,Likes,Star,CreatedDate,UpdatedDate,AdminCreated,AdminUpdated,Status,Isdelete")] News news)
        {
            if (ModelState.IsValid)
            {
                _context.Add(news);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(news);
        }

        // GET: AdminQL/News/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News.FindAsync(id);
            if (news == null)
            {
                return NotFound();
            }
            return View(news);
        }

        // POST: AdminQL/News/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Code,Title,Description,Content,Image,MetaTitle,MainKeyword,MetaKeyword,MetaDescription,Slug,Views,Likes,Star,CreatedDate,UpdatedDate,AdminCreated,AdminUpdated,Status,Isdelete")] News news)
        {
            if (id != news.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(news);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsExists(news.Id))
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
            return View(news);
        }

        // GET: AdminQL/News/Delete/5
        // GET: AdminQL/AdminUsers/Delete/5

        // POST: AdminQL/AdminUsers/Delete/5
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var user = _context.News.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                // Nếu không tìm thấy người dùng, redirect đến danh sách hoặc hiển thị lỗi
                return NotFound();
            }

            // Tiến hành xóa người dùng
            _context.News.Remove(user);
            _context.SaveChanges();

            // Redirect về trang danh sách người dùng hoặc trang khác sau khi xóa thành công
            return RedirectToAction(nameof(Index));  // Giả sử bạn sẽ chuyển hướng về trang danh sách người dùng
        }

        private bool NewsExists(int id)
        {
            return _context.News.Any(e => e.Id == id);
        }
    }
}
