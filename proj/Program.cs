using System;
using System.Threading;

public class Program
{
    static Mutex mutex = null!;

    public static void Main(string[] args)
    {
        const string mutexName = "Global\\MyUniqueAppMutex";
        bool createdNew;

        try
        {
            mutex = new Mutex(true, mutexName, out createdNew);

            if (!createdNew)
            {
                Console.WriteLine("Other example is started. Finishing the program.");
                return;
            }

            Console.WriteLine("Executing the program, click Enter to finish.");
            Console.ReadLine();
        }
        finally
        {
            if (mutex != null)
            {
                mutex.ReleaseMutex();
                mutex.Dispose();
            }
        }
    }
}
