using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwtorLauncherConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var mumbleStartInfo = new ProcessStartInfo
            {
                WorkingDirectory = ConfigurationManager.AppSettings["MumbleWorkingDir"],
                FileName = ConfigurationManager.AppSettings["MumbleFileName"]
            };

            var starParseStartInfo = new ProcessStartInfo
            {
                WorkingDirectory = ConfigurationManager.AppSettings["StarParseWorkingDir"],
                FileName = ConfigurationManager.AppSettings["StarParseFileName"]
            };

            var swtorStartInfo = new ProcessStartInfo
            {
                WorkingDirectory = ConfigurationManager.AppSettings["SwtorWorkingDir"],
                FileName = ConfigurationManager.AppSettings["SwtorFileName"]
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
                if(!process.Start());
                    Console.WriteLine($"Failed to start {psi.FileName}");
            });
        }
    }
}
