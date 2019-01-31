using System;
using System.Collections.Generic;
using System.Linq;

namespace GCD
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

        private static bool CheckPrime(int p)
        {
            for (int i = 2; i < p; i++)
            {
                if (p % i == 0) return false;
            }
            return true;
        }

        private List<int> PrimeNumberList(int n)
        {
            List<int> list = new List<int>();
            for (int i = 2; i <= n / 2; i++)
            {
                if (CheckPrime(i)) list.Add(i);
            }
            return list;
        }
    }
}
