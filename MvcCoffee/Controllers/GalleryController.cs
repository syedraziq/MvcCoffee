﻿using Microsoft.AspNetCore.Mvc;

public class GalleryController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
