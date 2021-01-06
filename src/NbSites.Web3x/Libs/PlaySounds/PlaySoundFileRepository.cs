using System.Collections.Generic;
using System.Linq;

namespace NbSites.Web.Libs.PlaySounds
{
    public class PlaySoundFileRepository : IPlaySoundFileRepository
    {
        public PlaySoundFileRepository()
        {
            //content", "sounds", "Alarm002.wav"
            PlaySoundFiles.Add(new PlaySoundFile() { Id = "Default", FilePath = "~/content/sounds/default.wav", Description = "打雷" });
            PlaySoundFiles.Add(new PlaySoundFile() { Id = "Alarm001", FilePath = "~/content/sounds/alarm001.wav", Description = "警报1" });
            PlaySoundFiles.Add(new PlaySoundFile() { Id = "Alarm002", FilePath = "~/content/sounds/alarm002.wav", Description = "警报2" });
            PlaySoundFiles.Add(new PlaySoundFile() { Id = "fail", FilePath = "~/content/sounds/fail.wav", Description = "构建失败" });
            PlaySoundFiles.Add(new PlaySoundFile() { Id = "buildComplete", FilePath = "~/content/sounds/buildComplete.wav", Description = "构建完成" });
            PlaySoundFiles.Add(new PlaySoundFile() { Id = "deployComplete", FilePath = "~/content/sounds/deployComplete.wav", Description = "部署完成" });
        }

        //todo read from real data source
        public IList<PlaySoundFile> PlaySoundFiles { get; set; } = new List<PlaySoundFile>();

        public IQueryable<PlaySoundFile> Query()
        {
            return PlaySoundFiles.AsQueryable();
        }
    }
}