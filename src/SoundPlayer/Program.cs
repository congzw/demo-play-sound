using System;
using System.Diagnostics;
using System.IO;
using CommandLine;

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

                PlaySound(o.File);
            });
        }
        
        private static void PlaySound(string file)
        {
            Process.Start(@"powershell", $@"-c (New-Object Media.SoundPlayer '{file}').PlaySync();");
        }
    }
}
