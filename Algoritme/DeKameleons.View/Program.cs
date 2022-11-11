using System;
using System.Threading;

namespace Demo
{
    public static class Program
    {
        public static void Main()
        {
            while (true)
            {
                Console.WriteLine("Kameleon :)");
                Thread.Sleep(100);
                Console.Clear();
            }
        }

        private static void callback(object state)
        {
            Console.WriteLine("Called back with state = " + state);
        }
    }
}