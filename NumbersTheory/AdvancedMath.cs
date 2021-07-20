using System;
using System.Collections.Generic;
using System.Text;

namespace NumbersTheory
{
    public static class AdvancedMath
    {
        public static string MultiplyLongNumbers(string numLong, string numShort)
        {
            int multCarr = 0;
            int sumCarr = 0;
            int[] result = new int[numLong.Length + numShort.Length];

            for (int i = numShort.Length - 1; i >= 0; i--)
            {
                for (int j = numLong.Length - 1; j >= 0; j--)
                {
                    int multVal = int.Parse(numShort[i].ToString()) * int.Parse(numLong[j].ToString()) + multCarr;
                    multCarr = multVal / 10;
                    int multRmd = multVal - multCarr * 10;
                    int sumVal = multRmd + result[i + j + 1] + sumCarr;
                    sumCarr = sumVal / 10;
                    int summRmd = sumVal - sumCarr * 10;
                    result[i + j + 1] = summRmd;
                }
                result[i] = multCarr + sumCarr;
                multCarr = 0;
                sumCarr = 0;
            }
            result[0] += sumCarr;
            StringBuilder sb = new StringBuilder();
            bool leadingZero = true;
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] != 0) leadingZero = false;
                if (!leadingZero) sb.Append(result[i]);
            }
            if (sb.Length == 0) sb.Append(0);
            return sb.ToString();
        }
    }
}
