using System.Speech.Synthesis;
using System.Threading.Tasks;

namespace NbSites.Web.Libs.TextSpeech
{
    public interface ITextSpeaker
    {
        Task Speak(string text);
    }

    public class TextSpeaker : ITextSpeaker
    {
        private readonly SpeechSynthesizer _speaker = new SpeechSynthesizer();

        public TextSpeaker()
        {
            _speaker.Rate = 1;
            _speaker.Volume = 100;
        }

        public Task Speak(string text)
        {
            _speaker.Speak(text);
            return Task.CompletedTask;
        }
    }
}
