using System;
namespace GCD
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] testValue = new int[] {
                25896648,
                44786624,
                28472656
            };
            GCD gcd = new GCD();
            int test = gcd.GeneralGcd(testValue);
            Console.WriteLine(test);
            Console.ReadLine();
        }
    }
}
