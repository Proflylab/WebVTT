using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebVTT
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var f in args)
            {
		//from python https://github.com/asciidisco/plugin.video.netflix
                var file = File.ReadAllText(f, Encoding.UTF8);
                file = Regex.Replace(file, @"([\d]+)\.([\d]+)", "$1,$2");
                file = Regex.Replace(file, @"WEBVTT\n\n", string.Empty);
                file = Regex.Replace(file, @"NOTE.*\n", string.Empty);
                file = Regex.Replace(file, @"\n\s+\n", string.Empty);
                file = Regex.Replace(file, @" position:.+%", string.Empty);
                file = Regex.Replace(file, @"<.*?>", string.Empty);
                file = Regex.Replace(file, @"{.*?}", string.Empty);
                File.WriteAllText(Path.Combine(Path.GetDirectoryName(f), Path.GetFileNameWithoutExtension(f) + ".srt"), file, Encoding.UTF8);
            }
        }
    }
}
