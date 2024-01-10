using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcCoffee.Data;

public class CoffeesFController : Controller
{
    private readonly MvcCoffeeContext _context;

    public CoffeesFController(MvcCoffeeContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            var coffees = await _context.Coffee.ToListAsync();
            return View(coffees);
        }
        catch (Exception ex)
        {
            // Log the exception or handle it appropriately
            return Problem("An error occurred while fetching data.", null, 500, "Internal Server Error", ex.ToString());
        }
    }
}
