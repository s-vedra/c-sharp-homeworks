using System;

namespace Domasna_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double firstDouble = 2.5;
            double secondDouble = 6.8;
            double resOne = secondDouble / firstDouble;
            Console.WriteLine(resOne);
            int firstInt = 10;
            int secondInt = 20;
            int resTwo = secondInt / firstInt;
            Console.WriteLine(resTwo);
            Console.WriteLine(resTwo > resOne);
            Console.WriteLine(resOne > resTwo);
        }
    }
}
