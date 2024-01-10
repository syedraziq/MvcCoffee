using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcCoffee.Data;
using System.Linq;
using MvcCoffee.Models;

namespace MvcCoffee.Controllers
{
    public class DessertController : Controller
    {
        private readonly MvcCoffeeContext _context;

        public DessertController(MvcCoffeeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var dessertData = _context.Dessert.ToList();
            return View(dessertData);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Descriptions,Price,Stock")] Dessert dessert)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dessert);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(dessert);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dessertItem = _context.Dessert.FirstOrDefault(d => d.Id == id);

            if (dessertItem == null)
            {
                return NotFound();
            }

            return View(dessertItem);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dessertItem = _context.Dessert.Find(id);

            if (dessertItem == null)
            {
                return NotFound();
            }

            return View(dessertItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Descriptions,Price,Stock")] Dessert dessert)
        {
            if (id != dessert.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dessert);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DessertExists(dessert.Id))
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

            return View(dessert);
        }


        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dessertItem = _context.Dessert.Find(id);

            if (dessertItem == null)
            {
                return NotFound();
            }

            return View(dessertItem);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dessertItem = await _context.Dessert.FindAsync(id);
            _context.Dessert.Remove(dessertItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        // Add other actions (Create, Details, Delete) as needed

        private bool DessertExists(int id)
        {
            return _context.Dessert.Any(e => e.Id == id);
        }
        // Add other actions (Create, Details, Edit, Delete) as needed
    }
}
