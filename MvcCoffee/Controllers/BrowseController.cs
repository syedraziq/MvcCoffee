using Microsoft.AspNetCore.Mvc;

public class BrowseController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
