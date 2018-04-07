using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using M33.Models;

namespace M33.Controllers
{
    public class ImageLibraryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
