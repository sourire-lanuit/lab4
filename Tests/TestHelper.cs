using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace Tests
{
    public static class TestHelper
    {
        public static bool TryCreateMutex(string name, out Mutex mutex)
        {
            bool createdNew;
            mutex = new Mutex(true, name, out createdNew);
            return createdNew;
        }
    }
}