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
            var output1 = new StringWriter();
            Console.SetOut(output1);

            Task t1 = Task.Run(() =>
            {
                var input = new StringReader(Environment.NewLine);
                Console.SetIn(input);

                Program.Main(null);
            });

            Thread.Sleep(500); 
            var output2 = new StringWriter();
            Console.SetOut(output2);

            Task t2 = Task.Run(() =>
            {
                Program.Main(null);
            });

            Task.WaitAll(t1, t2);

            string result2 = output2.ToString();
            Assert.IsTrue(result2.Contains("Other example is started"), "Second instance should detect that the mutex is taken.");
        }
    }
}
