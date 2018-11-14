using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciNumbersLib
{
    /// <summary>
    /// Represent a class providing Fibonacci numbers generation
    /// </summary>
    public static class Fibonacci
    {
        /// <summary>
        /// Provides Fibonacci numbers generation
        /// </summary>
        /// <param name="amount">Amount of fibonacci numbers in sequence</param>
        /// <returns>Fibonacci sequence</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when amount is less or equal than 0</exception>
        public static int[] FibonacciGeneration(int amount)
        {
            if(amount <= 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(amount)} parameter must be greater than 0");
            }

            return FibonacciNumbers(amount);
        }

        /// <summary>
        /// Generates fibonacci numbers sequence
        /// </summary>
        /// <param name="amount">Amount of fibonacci numbers in sequence</param>
        /// <returns>Fibonacci sequence</returns>
        public static int[] FibonacciNumbers(int amount)
        {
            if (amount == 1)
            {
                return new int[]{ 0 };
            }

            if (amount == 2)
            {
                return new int[]{ 0, 1 };
            }

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
