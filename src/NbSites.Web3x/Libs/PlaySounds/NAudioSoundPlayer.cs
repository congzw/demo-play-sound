using System;
using System.Threading.Tasks;
using NAudio.Wave;

namespace NbSites.Web.Libs.PlaySounds
{
    public class NAudioSoundPlayer : ISoundPlayer
    {
        public async Task Play(string file)
        {
            await using var mf = new MediaFoundationReader(file);
            using var wo = new WaveOutEvent();
            wo.Init(mf);
            wo.Play();
            while (wo.PlaybackState == PlaybackState.Playing)
            {
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
        }
    }
}
