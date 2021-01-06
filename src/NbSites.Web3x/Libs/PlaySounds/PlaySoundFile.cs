namespace NbSites.Web.Libs.PlaySounds
{
    public class PlaySoundFile
    {
        public string Id { get; set; }
        public string FilePath { get; set; }
        public string Description { get; set; }

        public static PlaySoundFile Default = new PlaySoundFile()
        {
            Id = "default",
            FilePath = "~/content/sounds/default.wav",
            Description = "默认文件"
        };
    }
}