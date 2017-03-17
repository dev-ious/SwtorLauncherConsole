using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

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
                try
                {
                    if (IsProcessOpen(psi.FileName))
                    {
                        Console.WriteLine($"{psi.FileName} is already running, skipping launch of it.");
                    }
                    else if(!process.Start())
                        Console.WriteLine($"Failed to start {psi.FileName}");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Something unexpected has happened. Please paste the output of this window (use ctrl + s to save the output to a file first) in the issue area of github for this project. {e}");
                }
            });
        }

        public static bool IsProcessOpen(string name)
        {
            name = name.Split(char.Parse(".")).FirstOrDefault();
            return Process.GetProcesses().Any(clsProcess => name != null && clsProcess.ProcessName.ToLower().Contains(name));
        }
    }
}
