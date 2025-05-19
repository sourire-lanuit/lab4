using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;


namespace Tests
{
    [TestClass]
    public class MutexTests
    {
        [TestMethod]
        public void Mutex_IsCreatedSuccessfully()
        {
            string name = "Global\\TestMutex_Unique";
            bool result = TestHelper.TryCreateMutex(name, out Mutex mutex);
            Assert.IsTrue(result);
            mutex.ReleaseMutex();
        }

        [TestMethod]
        public void Mutex_ReturnsFalse_WhenAlreadyExists()
        {
            string name = "Global\\TestMutex_Conflict";

            Mutex first = new Mutex(true, name, out _); 

            bool result = TestHelper.TryCreateMutex(name, out Mutex second);
            Assert.IsFalse(result); 
        }
    }
}
