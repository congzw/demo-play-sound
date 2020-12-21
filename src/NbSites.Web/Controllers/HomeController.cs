using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NbSites.Web.Libs.PlaySounds;

namespace NbSites.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// only for test
        /// </summary>
        /// <param name="playSoundAppService"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> GetPlay([FromServices] PlaySoundAppService playSoundAppService, [FromQuery] string id)
        {
            var messageResult = await playSoundAppService.Play(id, true);
            ViewBag.Message = messageResult.Message;
            return View("Index");
        }

        /// <summary>
        /// 播放声音
        /// </summary>
        /// <param name="playSoundAppService"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Play([FromServices] PlaySoundAppService playSoundAppService, [FromQuery]string id)
        {
            var messageResult = await playSoundAppService.Play(id, true);
            ViewBag.Message = messageResult.Message;
            return View("Index");
        }
    }
}
