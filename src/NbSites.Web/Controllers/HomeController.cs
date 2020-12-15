using System.Diagnostics;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace NbSites.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Play([FromServices] IHostingEnvironment env)
        {
            var filePath = Path.Combine(env.WebRootPath, "content", "sounds", "Alarm002.wav");
            if (!System.IO.File.Exists(filePath))
            {
                ViewBag.Message = "FileNotExist:" + filePath;
            }
            else
            {
                ViewBag.Message = "PlaySound:" + filePath;
                PlaySound(filePath);
            }
            return View("Index");
        }

        private static void PlaySound(string file)
        {
            Process.Start(@"powershell", $@"-c (New-Object Media.SoundPlayer '{file}').PlaySync();");
        }
    }
}
