using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciNumbersLib
{
    public static class Fibonacci
    {
        public static int[] FibonacciNumbers(int amount)
        {
            int[] fibonacciArray = new int[amount];

            fibonacciArray[0] = 0;
            fibonacciArray[1] = 1;
            for (int i = 2; i < amount; i++)
            {
                fibonacciArray[i] = fibonacciArray[i - 2] + fibonacciArray[i - 1];
            }

            return fibonacciArray;
        }
    }
}
