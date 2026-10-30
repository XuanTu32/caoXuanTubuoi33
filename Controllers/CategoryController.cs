using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using caoXuanTubuoi3.Data;
using caoXuanTubuoi3.Models;

namespace caoXuanTubuoi3.Controllers
{
    public class CategoryController : Controller
    {
        // GET: CategoryController
        public ActionResult Index()
        {
            return View(SeedData.categories);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            var category = SeedData.categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] Category category)
        {
            if (ModelState.IsValid)
            {
                int maxId = SeedData.categories.Any() ? SeedData.categories.Max(c => c.Id) : 0;
                category.Id = maxId + 1;
                SeedData.categories.Add(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            var category = SeedData.categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([FromForm] Category category)
        {
            var existingCategory = SeedData.categories.FirstOrDefault(c => c.Id == category.Id);
            if (existingCategory == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                existingCategory.Name = category.Name;
                existingCategory.Description = category.Description;
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            var category = SeedData.categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: CategoryController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var existingCategory = SeedData.categories.FirstOrDefault(c => c.Id == id);
            if (existingCategory == null)
            {
                return NotFound();
            }
            SeedData.categories.Remove(existingCategory);
            return RedirectToAction(nameof(Index));
        }
    }
}