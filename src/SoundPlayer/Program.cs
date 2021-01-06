using System;
using System.Diagnostics;
using System.IO;
using CommandLine;
using NAudio.Wave;
using SoundPlayer.NAudios;

namespace SoundPlayer
{
    class Program
    {
        public class Options
        {
            [Option('f', "file", Required = false, Default = "Alarm001.wav", HelpText = "播放的文件路径")]
            public string File { get; set; }
        }

        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args).WithParsed<Options>(o =>
            {
                if (!File.Exists(o.File))
                {
                    Console.WriteLine("文件不存在:" + o.File);
                    return;
                }

                NAudioDemo.Test3();

                //PlaySound(o.File);
            });
        }
        
        private static void PlaySound(string file)
        {
            Process.Start(@"powershell", $@"-c (New-Object Media.SoundPlayer '{file}').PlaySync();");
        }
    }
}
