using System.Linq;

namespace NbSites.Web.Libs.PlaySounds
{
    public interface IPlaySoundFileRepository
    {
        IQueryable<PlaySoundFile> Query();
    }
}