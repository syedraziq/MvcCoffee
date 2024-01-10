using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcCoffee.Data;
using System.Linq;
using MvcCoffee.Models; // Assuming your Tea class is in the MvcCoffee.Models namespace


namespace MvcCoffee.Controllers
{
    public class TeaController : Controller
    {
        private readonly MvcCoffeeContext _context;

        public TeaController(MvcCoffeeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var teaData = _context.Tea.ToList();
            return View(teaData);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teaItem = _context.Tea.FirstOrDefault(t => t.Id == id);

            if (teaItem == null)
            {
                return NotFound();
            }

            return View(teaItem);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Descriptions,Price,Stock")] Tea tea)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tea);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(tea);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teaItem = await _context.Tea.FindAsync(id);

            if (teaItem == null)
            {
                return NotFound();
            }

            return View(teaItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Descriptions,Price,Stock")] Tea tea)
        {
            if (id != tea.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tea);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeaExists(tea.Id))
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

            return View(tea);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teaItem = await _context.Tea.FirstOrDefaultAsync(t => t.Id == id);

            if (teaItem == null)
            {
                return NotFound();
            }

            return View(teaItem);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teaItem = await _context.Tea.FindAsync(id);
            _context.Tea.Remove(teaItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        // Add other actions (Delete) as needed

        private bool TeaExists(int id)
        {
            return _context.Tea.Any(e => e.Id == id);
        }

        // Add other actions (Create, Edit, Delete) as needed
    }
}
