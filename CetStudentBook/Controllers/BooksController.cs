using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CetStudentBook.Data;
using CetStudentBook.Models;

namespace CetStudentBook.Controllers
{
    public class BooksController : Controller

    {
        private readonly ApplicationDbContext _db;

        public BooksController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var kitaplar= await _db.Books.ToListAsync();
            return View(kitaplar);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book)
        {
            if (!ModelState.IsValid)
                return View(book);
            _db.Books.Add(book);  //create books
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var kitap = await _db.Books.FindAsync(id);
            if (kitap == null)
                return NotFound();
            return View(kitap);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Book book)
        {
            if (id != book.Id)
                return BadRequest();
            if(!ModelState.IsValid)
                return View(book);
            var dbKitap = await _db.Books.FindAsync(id);
            if (dbKitap == null)
                return NotFound();
            dbKitap.Name = book.Name;
            dbKitap.Author = book.Author;
            dbKitap.PublishDate = book.PublishDate;
            dbKitap.PageCount = book.PageCount;
            dbKitap.IsSecondHand = book.IsSecondHand;
            
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var kitap = await _db.Books.FindAsync(id);
            if (kitap == null)
                return NotFound();
            return View(kitap);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kitap = await _db.Books.FindAsync(id);
            if (kitap == null)
                return NotFound();
            _db.Books.Remove(kitap);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
    }
}