using System.Linq;
using DemoEfCoreKhanhPhong.DbContext;
using DemoEfCoreKhanhPhong.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoEfCoreKhanhPhong.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoriesController(ApplicationDbContext db)
        {
            _db = db;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            var categoriesList = _db.Categories.ToList();
            return View(categoriesList);
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Category());
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(category);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        [HttpGet]
        public IActionResult Delete(int categoryId)
        {
            var categoryDb = _db.Categories.Where(c => c.Id == categoryId);
            if (categoryDb.Any())
            {
                _db.Categories.Remove(categoryDb.First());
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }

        [HttpGet]
        public IActionResult Update(int categoryId)
        {
            var categoryDb = _db.Categories.Where(c => c.Id == categoryId);
            if (categoryDb.Any())
            {
                return View(categoryDb.First());
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Update(Category category)
        {
            var categoriDb = _db.Categories.Where(c => c.Id == category.Id);
            if (!categoriDb.Any())
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Update(category);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }
    }
}