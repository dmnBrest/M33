using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using M33.Models;

namespace M33.Controllers
{

    public class AppController : Controller
    {

        IHostingEnvironment _hostingEnvironment;
        public AppController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        [Authorize]
        //[GenerateAntiforgeryTokenCookieForAjax]
        public IActionResult Index()
        {
            return View();
        }

    }
}
