using System.Collections.Generic;
using System.Linq;

namespace NbSites.Web.Libs.PlaySounds
{
    public class PlaySoundFileRepository : IPlaySoundFileRepository
    {
        public PlaySoundFileRepository()
        {
            //content", "sounds", "Alarm002.wav"
            PlaySoundFiles.Add(new PlaySoundFile() { Id = "Default", FilePath = "~/content/sounds/default.wav", Description = "默认" });
            PlaySoundFiles.Add(new PlaySoundFile() { Id = "Alarm001", FilePath = "~/content/sounds/alarm001.wav", Description = "犬吠" });
            PlaySoundFiles.Add(new PlaySoundFile() { Id = "Alarm002", FilePath = "~/content/sounds/alarm002.wav", Description = "打雷" });
        }

        //todo read from real data source
        public IList<PlaySoundFile> PlaySoundFiles { get; set; } = new List<PlaySoundFile>();

        public IQueryable<PlaySoundFile> Query()
        {
            return PlaySoundFiles.AsQueryable();
        }
    }
}