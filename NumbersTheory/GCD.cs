using System;
using System.Collections.Generic;
using System.Linq;

namespace NumbersTheory
{
    class GCD
    {
        /// <summary>
        /// Get greatest common divisor in a list of positive numbers 
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns>The GCD of numbers</returns>
        public int GeneralGcd(int[] numbers)
        {
            Dictionary<int, int> minfrequenciesOfPrimes = new Dictionary<int, int>();
            foreach (var p in PrimeNumberList(numbers.Max()))
            {
                int minFreqOfP = MinFrequency(p, numbers);
                if (minFreqOfP != 0) minfrequenciesOfPrimes.Add(p, minFreqOfP);
            }

            double gdc = 1;
            foreach (var val in minfrequenciesOfPrimes)
            {
                gdc *= Math.Pow(val.Key, val.Value);
            }
            return (int)gdc;
        }

        private int MinFrequency(int p, int[] numbers)
        {
            double min = Double.PositiveInfinity;
            foreach (int number in numbers)
            {
                int freqOfP = Divider(p, number);
                if (freqOfP < min) min = freqOfP;
                if (min == 0) break;
            }
            return (int)min;
        }

        private int Divider(int d, int number)
        {
            int sum = 0;
            return Divider(d, number, ref sum);
        }

        private int Divider(int d, int number, ref int sum)
        {
            if (number % d != 0) return sum;
            sum++;
            Divider(d, number / d, ref sum);
            return sum;
        }

        //private static bool IsPrime(int num)
        //{
        //    if (num <= 1) return false;
        //    else if (num <= 3) return true;
        //    else if (num % 2 == 0 || num % 3 == 0) return false;
        //    var i = 5;
        //    while (i * i <= num)
        //    {
        //        if (num % i == 0 || num % (i + 2) == 0) return false;
        //        i += 6;
        //    }
        //    return true;
        //}

        public static List<int> PrimeNumberList(int n)
        {
            bool[] notPrimes = new bool[n + 1];

            for (int p = 2; p * p <= n; p++)
            {
                if (!notPrimes[p])
                {
                    for (int i = p * 2; i <= n; i += p)
                        notPrimes[i] = true;
                }
            }

            List<int> primeNumbers = new List<int>();
            for (int i = 2; i <= n; i++)
            {
                if (!notPrimes[i])
                    primeNumbers.Add(i);
            }
            return primeNumbers;
        }
    }
}
