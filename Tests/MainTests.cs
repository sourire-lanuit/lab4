using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class MainTests
    {
        [TestMethod]
        public void OnlyOneInstance_ShouldRun_WhenMutexIsUsed()
        {
            using var sw = new StringWriter();
            Console.SetOut(sw);

            var firstTask = Task.Run(() =>
            {
                Program.Main(null);
            });

            Thread.Sleep(500);
            using var secondOutput = new StringWriter();
            Console.SetOut(secondOutput);

            Program.Main(null); 
            string output = secondOutput.ToString();
            Assert.IsTrue(output.Contains("Other example is started"), "Second instance should detect that the mutex is taken.");

            Console.SetOut(sw); 
            Console.SetIn(new StringReader(Environment.NewLine));
            firstTask.Wait();
        }
    }
}
