using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Common;

namespace NbSites.Web.Libs.PlaySounds
{
    public class PlaySoundAppService
    {
        private readonly IPlaySoundFileRepository _repository;
        private readonly ServerPathHelper _serverPathHelper;
        private readonly ISoundPlayer _soundPlayer;

        public PlaySoundAppService(IPlaySoundFileRepository repository, ServerPathHelper serverPathHelper, ISoundPlayer soundPlayer)
        {
            _repository = repository;
            _serverPathHelper = serverPathHelper;
            _soundPlayer = soundPlayer;
        }
        
        public Task<MessageResult> Play(string soundId, bool playDefaultIfNotExist)
        {
            var playSoundFile = GetPlaySoundFile(soundId, playDefaultIfNotExist);
            var filePath = MapContentRootPath(playSoundFile.FilePath);
            return PlayFile(filePath);
        }
        
        internal PlaySoundFile GetPlaySoundFile(string soundId, bool getDefaultIfNotExist)
        {
            if (string.IsNullOrWhiteSpace(soundId))
            {
                return PlaySoundFile.Default;
            }

            var theOne = _repository.Query().FirstOrDefault(x => soundId.Equals(x.Id, StringComparison.OrdinalIgnoreCase));
            if (theOne == null && getDefaultIfNotExist)
            {
                return PlaySoundFile.Default;
            }
            return theOne;
        }

        internal string MapContentRootPath(string relativePath)
        {
            return _serverPathHelper.MapWebRootPath(relativePath);
        }

        internal async Task<MessageResult> PlayFile(string file)
        {
            var messageResult = new MessageResult();
            if (!File.Exists(file))
            {
                messageResult.Message = "文件不存在:" + file;
                return messageResult;
            }

            try
            {
                await _soundPlayer.Play(file);
                messageResult.Success = true;
                messageResult.Message = "OK";
                messageResult.Data = file;
                return messageResult;
            }
            catch (Exception e)
            {
                messageResult.Message = e.Message;
                return messageResult;
            }
        }
    }
}
