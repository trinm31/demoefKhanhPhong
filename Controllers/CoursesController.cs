using System.Linq;
using DemoEfCoreKhanhPhong.DbContext;
using DemoEfCoreKhanhPhong.Models;
using DemoEfCoreKhanhPhong.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DemoEfCoreKhanhPhong.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CoursesController(ApplicationDbContext db)
        {
            _db = db;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            var courseList = _db.Courses.Include(c=>c.Category).ToList();
            return View(courseList);
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            var categoryDb = _db.Categories.ToList();
            CourseVM courseVm = new CourseVM()
            {
                Course = new Course(),
                CategoryList = categoryDb.Select(c => new SelectListItem()
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                })
            };
            return View(courseVm);
        }

        [HttpPost]
        public IActionResult Create(CourseVM courseVm)
        {
            if (ModelState.IsValid)
            {
                _db.Courses.Add(courseVm.Course);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            var categoryDb = _db.Categories.ToList();
            
            courseVm.CategoryList = categoryDb.Select(c => new SelectListItem()
            {
                Text = c.Name,
                Value = c.Id.ToString()
            });
            return View(courseVm);
        }

        [HttpGet]
        public IActionResult Delete(int courseId)
        {
            var courseDb = _db.Courses.Where(c => c.CourseId == courseId);
            if (courseDb.Any())
            {
                _db.Courses.Remove(courseDb.First());
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }

        [HttpGet]
        public IActionResult Update(int courseId)
        {
            var courseDb = _db.Courses.Where(c => c.CourseId == courseId);
            if (courseDb.Any())
            {
                return View(courseDb.First());
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Update(Course course)
        {
            var courseDb = _db.Courses.Where(c => c.CourseId == course.CourseId);
            if (!courseDb.Any())
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.Courses.Update(course);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(course);
        }
    }
}