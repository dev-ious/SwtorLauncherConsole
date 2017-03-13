using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace SwtorLauncherConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var mumbleStartInfo = new ProcessStartInfo
            {
                WorkingDirectory = Directory.Exists("C:\\Program Files (x86)\\Mumble") ? "C:\\Program Files (x86)\\Mumble" : "D:\\Program Files (x86)\\Mumble",
                FileName = "mumble.exe"
            };

            var starParseStartInfo = new ProcessStartInfo
            {
                WorkingDirectory = Directory.Exists($"C:\\Users\\{System.Environment.UserName}\\AppData\\Local\\StarParse") ? $"C:\\Users\\{System.Environment.UserName}\\AppData\\Local\\StarParse" : $"D:\\Users\\{System.Environment.UserName}\\AppData\\Local\\StarParse",
                FileName = "starparse.exe"
            };

            var swtorStartInfo = new ProcessStartInfo
            {
                WorkingDirectory = Directory.Exists("C:\\Program Files (x86)\\Star Wars-The Old Republic") ? "C:\\Program Files (x86)\\Star Wars-The Old Republic" : "D:\\Program Files (x86)\\Star Wars-The Old Republic",
                FileName = "launcher.exe"
            };

            var processList = new List<ProcessStartInfo>
            {
                mumbleStartInfo,
                starParseStartInfo,
                swtorStartInfo
            };

            processList.ForEach(psi =>
            {
                var process = new Process {StartInfo = psi};
                if(!process.Start())
                    Console.WriteLine($"Failed to start {psi.FileName}");
            });
        }
    }
}
