using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Numerics;
using M33.Models;
using M33.Models.DB;
using M33.Data;
using M33.Services;

namespace M33.Controllers
{

    public class ImageLibraryController : Controller
    {

        private IHostingEnvironment _hostingEnvironment;
        private UserManager<ApplicationUser> _userManager;
        private ApplicationDbContext _dbContext;

        public ImageLibraryController(IHostingEnvironment hostingEnvironment, UserManager<ApplicationUser> userManager, ApplicationDbContext dbContext)
        {
            _hostingEnvironment = hostingEnvironment;
            _userManager = userManager;
            _dbContext = dbContext;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Upload(IFormFile file, String data)
        {

            Console.WriteLine("XXXXX 1");
            Console.WriteLine(data);

            Dictionary<string, string> input = JsonConvert.DeserializeObject<Dictionary<string, string>>(data);

            Console.WriteLine(input);
            Console.WriteLine(input["title"]);

            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");

            // TODO Add size and type validation
            // Console.WriteLine(file.Length);

            if (file.Length > 0)
            {
                var dt = Utils.getNowInUnixTimestamp();
                var userId = _userManager.GetUserId(User);
                var filename = userId + '_' + dt.ToString() + ".jpg";
                var userUploadsDir = Path.Combine(uploads, userId);
                Directory.CreateDirectory(userUploadsDir);
                var filePath = Path.Combine(userUploadsDir, filename);
                using (var fileStream = new FileStream(filePath, FileMode.Create)) {
                    await file.CopyToAsync(fileStream);
                }

                var img = new Image {
                    Name = input["title"],
                    Filename = filename,
                    ApplicationUserID = userId
                };
                _dbContext.Add(img);
                _dbContext.SaveChanges();

            }

            var output = new Dictionary<string, object>();
            output.Add("key1", "doom1");
            output.Add("key2", 1000);
            output.Add("key3", true);
            return new ObjectResult(output);
        }
    }
}
