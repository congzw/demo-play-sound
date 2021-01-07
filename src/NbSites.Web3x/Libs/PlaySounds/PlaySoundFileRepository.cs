using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;

namespace NbSites.Web.Libs.PlaySounds
{
    public class PlaySoundFileRepository : IPlaySoundFileRepository
    {
        public PlaySoundFileRepository(IWebHostEnvironment hostEnvironment)
        {
            var jsonFile = Path.Combine(hostEnvironment.ContentRootPath, "playSoundFile.json");
            EnsureInit(jsonFile);
        }
        
        public List<PlaySoundFile> PlaySoundFiles { get; set; } = new List<PlaySoundFile>();

        public IQueryable<PlaySoundFile> Query()
        {
            return PlaySoundFiles.AsQueryable();
        }

        private void EnsureInit(string jsonFile)
        {
            if (!File.Exists(jsonFile))
            {
                var soundFiles = new List<PlaySoundFile>();
                soundFiles.Add(new PlaySoundFile() { Id = "default", FilePath = "~/content/sounds/status/default.mp3", Description = "构建执行完毕" });
                soundFiles.Add(new PlaySoundFile() { Id = "success", FilePath = "~/content/sounds/status/success.mp3", Description = "构建成功" });
                soundFiles.Add(new PlaySoundFile() { Id = "fail", FilePath = "~/content/sounds/status/fail.mp3", Description = "构建失败" });
                soundFiles.Add(new PlaySoundFile() { Id = "alarm", FilePath = "~/content/sounds/status/alarm.mp3", Description = "严重告警" });
                soundFiles.Add(new PlaySoundFile() { Id = "dead", FilePath = "~/content/sounds/status/dead.mp3", Description = "严重错误" });

                var json = JsonConvert.SerializeObject(soundFiles, Formatting.Indented);
                File.WriteAllText(jsonFile, json, Encoding.UTF8);
            }

            var jsonRead = File.ReadAllText(jsonFile);
            PlaySoundFiles = JsonConvert.DeserializeObject<List<PlaySoundFile>>(jsonRead);
        }
    }
}