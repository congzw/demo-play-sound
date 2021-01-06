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
            Process.Start(@"powershell", $@"-c (New-Object Media.SoundPlayer '{file}').PlaySync();");
            return Task.CompletedTask;
        }
    }
}