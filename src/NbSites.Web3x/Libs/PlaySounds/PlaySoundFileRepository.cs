using System.Collections.Generic;
using System.Linq;

namespace NbSites.Web.Libs.PlaySounds
{
    public class PlaySoundFileRepository : IPlaySoundFileRepository
    {
        public PlaySoundFileRepository()
        {
            PlaySoundFiles.Add(new PlaySoundFile() { Id = "default", FilePath = "~/content/sounds/status/default.mp3", Description = "构建执行完毕" });
            PlaySoundFiles.Add(new PlaySoundFile() { Id = "status_success", FilePath = "~/content/sounds/status/success.mp3", Description = "构建成功" });
            PlaySoundFiles.Add(new PlaySoundFile() { Id = "status_fail", FilePath = "~/content/sounds/status/fail.mp3", Description = "构建失败" });
            PlaySoundFiles.Add(new PlaySoundFile() { Id = "status_alarm", FilePath = "~/content/sounds/status/alarm.mp3", Description = "严重告警" });
            PlaySoundFiles.Add(new PlaySoundFile() { Id = "status_dead", FilePath = "~/content/sounds/status/dead.mp3", Description = "严重错误" });

            //PlaySoundFiles.Add(new PlaySoundFile() { Id = "Default", FilePath = "~/content/sounds/default.wav", Description = "打雷" });
            //PlaySoundFiles.Add(new PlaySoundFile() { Id = "Alarm001", FilePath = "~/content/sounds/alarm001.wav", Description = "警报1" });
            //PlaySoundFiles.Add(new PlaySoundFile() { Id = "Alarm002", FilePath = "~/content/sounds/alarm002.wav", Description = "警报2" });
            //PlaySoundFiles.Add(new PlaySoundFile() { Id = "fail", FilePath = "~/content/sounds/fail.wav", Description = "构建失败" });
            //PlaySoundFiles.Add(new PlaySoundFile() { Id = "buildComplete", FilePath = "~/content/sounds/buildComplete.wav", Description = "构建完成" });
            //PlaySoundFiles.Add(new PlaySoundFile() { Id = "deployComplete", FilePath = "~/content/sounds/deployComplete.wav", Description = "部署完成" });
            //PlaySoundFiles.Add(new PlaySoundFile() { Id = "status_dead", FilePath = "~/content/sounds/status/dead.mp3", Description = "致命" });
        }

        //todo read from real data source
        public IList<PlaySoundFile> PlaySoundFiles { get; set; } = new List<PlaySoundFile>();

        public IQueryable<PlaySoundFile> Query()
        {
            return PlaySoundFiles.AsQueryable();
        }
    }
}