using System.Threading.Tasks;
using Common;
using Microsoft.AspNetCore.Mvc;
using NbSites.Web.Libs.PlaySounds;
using NbSites.Web.Libs.TextSpeech;

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
        public async Task<IActionResult> GetPlay([FromServices] PlaySoundAppService playSoundAppService, string id)
        {
            var messageResult = await playSoundAppService.Play(id, true);
            ViewBag.MessageResult = messageResult;
            return View("Index");
        }
        
        /// <summary>
        /// 播放声音
        /// </summary>
        /// <param name="playSoundAppService"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Play([FromServices] PlaySoundAppService playSoundAppService, string id)
        {
            var messageResult = await playSoundAppService.Play(id, true);
            ViewBag.MessageResult = messageResult;
            return View("Index");
        }


        public async Task<IActionResult> GetSpeak([FromServices] ITextSpeaker textSpeaker, string id)
        {
            //todo: id to text
            await textSpeaker.Speak(id);
            ViewBag.MessageResult = id;
            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Speak([FromServices] ITextSpeaker textSpeaker, string id)
        {
            //todo: id to text
            await textSpeaker.Speak(id);
            return Json(MessageResult.SuccessResult("OK", id));
        }
    }
}
