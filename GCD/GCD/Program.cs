using System;
namespace GCD
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] testValue = new int[] {
                22,
                44,
                2816
            };
            GCD gcd = new GCD();
            int test = gcd.GeneralGcd(testValue);
            Console.WriteLine(test);
            Console.ReadLine();
        }
    }
}
