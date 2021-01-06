using System;
using System.Threading;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace SoundPlayer.NAudios
{
    public class NAudioDemo
    {
        public static void Test(string fileName)
        {
            using (var audioFile = new AudioFileReader(fileName))
            using (var outputDevice = new WaveOutEvent())
            {
                outputDevice.Init(audioFile);
                outputDevice.Play();
                while (outputDevice.PlaybackState == PlaybackState.Playing)
                {
                    Thread.Sleep(1000);
                }
            }
        }

        public static void Test2()
        {
            var url = "buildComplete.mp3";
            using (var mf = new MediaFoundationReader(url))
            using (var wo = new WaveOutEvent())
            {
                wo.Init(mf);
                wo.Play();
                while (wo.PlaybackState == PlaybackState.Playing)
                {
                    Thread.Sleep(1000);
                }
            }
        }
        public static void Test3()
        {
            using (var reader1 = new AudioFileReader("Alarm001.wav"))
            using (var reader2 = new AudioFileReader("Alarm002.wav"))
            {
                Console.WriteLine(reader1.WaveFormat);
                Console.WriteLine(reader2.WaveFormat);


                //var mixer = new MixingSampleProvider(new[] { reader1, reader2 });
                var mixer = new MixingSampleProvider(reader1.WaveFormat);
                mixer.AddMixerInput(new WaveFileReader("Alarm001.wav"));
                mixer.AddMixerInput(new WaveFileReader("Alarm002.wav"));

                WaveFileWriter.CreateWaveFile16("mixed.wav", mixer);
            }
        }
    }
}
