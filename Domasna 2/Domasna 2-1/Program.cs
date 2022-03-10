using System;

namespace Domasna_2_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int credits = 102;
            int smsCost = 5;
            Console.WriteLine("You can send " + credits / smsCost + " SMS messages");
        }
    }
}
