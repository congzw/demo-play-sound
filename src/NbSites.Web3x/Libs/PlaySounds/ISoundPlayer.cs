using System.Diagnostics;
using System.Threading.Tasks;

namespace NbSites.Web.Libs.PlaySounds
{
    public interface ISoundPlayer
    {
        Task Play(string file);
    }

    public class SoundPlayer : ISoundPlayer
    {
        public Task Play(string file)
        {
            //System.Media.SystemSounds.Asterisk.Play();
            //System.Media.SystemSounds.Beep.Play();
            //System.Media.SystemSounds.Exclamation.Play();
            //System.Media.SystemSounds.Hand.Play();
            //System.Media.SystemSounds.Question.Play();
            
            //var player = new System.Media.SoundPlayer();
            //player.SoundLocation = @"D:\WS_Github\congzw\demo-play-sound\src\NbSites.Web3x\Libs\PlaySounds\deployComplete.mp3";
            //player.Load(); //同步加载声音
            //player.Play(); //启用新线程播放

            //Process.Start(@"powershell", $@"-c (New-Object Media.SoundPlayer '{file}').PlaySync();");
            return Task.CompletedTask;
        }
    }
}