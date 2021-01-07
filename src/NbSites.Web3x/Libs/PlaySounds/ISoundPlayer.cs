using System.Threading.Tasks;

namespace NbSites.Web.Libs.PlaySounds
{
    public interface ISoundPlayer
    {
        Task Play(string file);
    }

    public class MediaSoundPlayer : ISoundPlayer
    {
        public Task Play(string file)
        {
            //System.Media.SystemSounds.Beep.Play();
            var player = new System.Media.SoundPlayer
            {
                SoundLocation = file
            };
            player.Load(); //同步加载声音
            player.Play(); //启用新线程播放

            //Process.Start(@"powershell", $@"-c (New-Object Media.SoundPlayer '{file}').PlaySync();");
            return Task.CompletedTask;
        }
    }
}