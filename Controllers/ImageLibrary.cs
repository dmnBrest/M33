using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using M33.Models;

namespace M33.Controllers
{

    public class ImageLibraryController : Controller
    {

        IHostingEnvironment _hostingEnvironment;
        public ImageLibraryController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        //[HttpGet]
        //[GenerateAntiforgeryTokenCookieForAjax]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(List<IFormFile> files)
        {

            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");

            Console.WriteLine(uploads);
            Console.WriteLine(files);


            foreach (var file in files)
            {

                Console.WriteLine(file.FileName);
                Console.WriteLine(file.Length);


                if (file.Length > 0)
                {
                    var filePath = Path.Combine(uploads, file.FileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create)) {
                        await file.CopyToAsync(fileStream);
                    }
                    // you should not use file.FileName from the user input and directly combine it with path.combine, as this file name could contain routing to subdirectories ("../../") you always need to recheck with e.g. Path.GetFullPath(generatedPath) if the return value is the same as your wanted upload directory. Also the filename from the request is not unique.
                }
            }



            var output = new Dictionary<string, object>();
            output.Add("key1", "doom1");
            output.Add("key2", 1000);
            output.Add("key3", true);
            return new ObjectResult(output);
        }
    }
}
