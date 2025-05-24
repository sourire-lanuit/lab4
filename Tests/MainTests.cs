using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Threading;

namespace Tests
{
    [TestClass]
    public class MainTests
    {
        [TestMethod]
        public void OnlyOneInstance_ShouldRun_WhenMutexIsUsed()
        {
            string exePath = @"..\..\bin\Debug\net8.0\lab4proj.exe";

            var first = Process.Start(new ProcessStartInfo
            {
                FileName = exePath,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            });

            Thread.Sleep(500);

            var second = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = exePath,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };

            second.Start();
            string output = second.StandardOutput.ReadToEnd();
            second.WaitForExit();

            first.StandardInput.WriteLine();
            first.WaitForExit();

            Assert.IsTrue(output.Contains("Other example is started"), "Estimated message about started example.");
        }
    }
}
