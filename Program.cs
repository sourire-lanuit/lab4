using System;
using System.Threading;

class Program
{
    static Mutex mutex;

    static void Main(string[] args)
    {
        const string mutexName = "Global\\MyUniqueAppMutex";

        if (!TestHelper.TryCreateMutex(mutexName, out mutex))
        {
            Console.WriteLine("Other example is started. Finishing the program.");
            return;
        }

        Console.WriteLine("Executing the program, click Enter to finish.");
        Console.ReadLine();

        mutex.ReleaseMutex();
    }
}
