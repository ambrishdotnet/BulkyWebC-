using BulkyWebC_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BulkyWebC_.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDBContext? _db = null;
        public CategoryController(ApplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var obj = _db.Categories.ToList();
            return View(obj);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            //_db.Categories.Add(obj);
            //_db.SaveChanges();
            //return RedirectToAction("Index", "Category");
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index", "Category");
            }
            else
                return View("Create");
        }

        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var item = _db.Categories.FirstOrDefault(i => i.Id == Id);
            if (item == null)
            {
                return NotFound();
            }
            //var item = _db.Categories.Find(Id);
            return View(item);
        }
        
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["Update"] = "Category udpated successfully";
                return RedirectToAction("Index", "Category");
            }
            else
                return View("Edit");

        }

        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var item = _db.Categories.FirstOrDefault(i => i.Id == Id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeletePost(int? Id)
        {
            if (Id != null || Id != 0)
            {
                var item = _db.Categories.Find(Id);
                if(item !=null)
                _db.Categories.Remove(item);
                TempData["Delete"] = "Category Deleted successfully";
                _db.SaveChanges();
                return RedirectToAction("Index", "Category");    
            }
            return View();

        }

    }
}
