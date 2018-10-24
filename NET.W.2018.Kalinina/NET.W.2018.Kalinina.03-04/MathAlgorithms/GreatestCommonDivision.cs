using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathAlgorithmsLib
{
    /// <summary>
    /// Class that contains math algorithms for computing the greatest common division of some numbers
    /// </summary>
    public class GreatestCommonDivision
    {
        #region Public API

        /// <summary>
        /// Method for finding the greatest common division of some numbers by using Euclidean algorithm
        /// </summary>
        /// <param name="time">Elapsed time</param>
        /// <param name="numbers">The numbers those need to find the greatest common division </param>
        /// <returns>The greatest common division for numbers</returns>
        /// <exception cref="ArgumentNullException">Thrown when numbers are not initialized</exception>
        /// <exception cref="ArgumentException">Thrown when there are no numbers to find 
        /// the GCD</exception>
        /// <exception cref="ArgumentException">Thrown when there is the only one 
        /// number to find GCD</exception>
        public static int EuclideanAlgorithm(out long time, params int[] numbers)
        {
            if (numbers == null)
                throw new ArgumentNullException("Numbers are not initialized.");
            if (numbers.Length == 0)
                throw new ArgumentException("There are no numbers for finding the GCD of.");
            if (numbers.Length == 1)
                throw new ArgumentException("It's impossible to find GCD of one number.");

            Stopwatch stopwatch = Stopwatch.StartNew();
            int gcdResult = EuclidGCD(numbers);
            time = stopwatch.ElapsedMilliseconds;

            return gcdResult;
        }

        /// <summary>
        /// Method for finding the greatest common division of some numbers by using Binary 
        /// Euclidean algorithm (Stein's Algorithm)
        /// </summary>
        /// <param name="time">Elapsed time</param>
        /// <param name="numbers">The numbers those need to find the greatest common division </param>
        /// <returns>The greatest common division for numbers</returns>
        /// <exception cref="ArgumentNullException">Thrown when numbers are not initialized</exception>
        /// <exception cref="ArgumentException">Thrown when there are no numbers to find 
        /// the GCD</exception>
        /// <exception cref="ArgumentException">Thrown when there is the only one 
        /// number to find GCD</exception>
        public static int BinaryEuclideanAlgorithm(out long time, params int[] numbers)
        {
            if (numbers == null)
                throw new ArgumentNullException("Numbers are not initialized.");
            if (numbers.Length == 0)
                throw new ArgumentException("There are no numbers for finding the GCD of.");
            if (numbers.Length == 1)
                throw new ArgumentException("It's impossible to find GCD of one number.");

            Stopwatch stopwatch = Stopwatch.StartNew();
            int gcdResult = BinaryEuclidGCD(numbers);
            time = stopwatch.ElapsedMilliseconds;

            return gcdResult;
        }

        #endregion

        #region Private API

        /// <summary>
        /// Method for finding the greatest common division of some numbers by using Euclidean algorithm
        /// </summary>
        /// <param name="numbers">The numbers those need to find the greatest common division </param>
        /// <returns>The greatest common division of numbers</returns>
        private static int EuclidGCD(params int[] numbers)
        {
            int nod = FindGCD(numbers[0], numbers[1]);

            if (numbers.Length == 2)
                return nod;

            for (int i = 2; i < numbers.Length; i++)
            {
                nod = FindGCD(nod, numbers[i]);
            }

            return nod;
        }

        /// <summary>
        /// Method for finding the greatest common division for two numbers by using Euclid's algorithm
        /// </summary>
        /// <param name="a">The first number to find GCD</param>
        /// <param name="b">The second number to find GCD</param>
        /// <returns>The greatest common division for two numbers</returns>
        private static int FindGCD(int a, int b)
        {
            if (b == 0)
                return Math.Abs(a);
            if (a == 0)
                return Math.Abs(b);

            if (a > b)
                return FindGCD(a % b, Math.Abs(b));
            else
                return FindGCD(Math.Abs(a), b % a);
        }

        /// <summary>
        /// Method for finding the greatest common division for some numbers by using Stein's Algorithm
        /// </summary>
        /// <param name="numbers">The numbers those need to find the greatest common division </param>
        /// <returns>The greatest common division of numbers</returns>
        private static int BinaryEuclidGCD(params int[] numbers)
        {
            int nod = FindBinaryGCD(numbers[0], numbers[1]);

            if (numbers.Length == 2)
                return nod;

            for (int i = 2; i < numbers.Length; i++)
            {
                nod = FindBinaryGCD(nod, numbers[i]);
            }

            return nod;
        }

        /// <summary>
        /// Method for finding the greatest common division for two numbers by using Stein's Algorithm
        /// </summary>
        /// <param name="a">The first number to find GCD</param>
        /// <param name="b">The second number to find GCD</param>
        /// <returns>The greatest common division for two numbers</returns>
        private static int FindBinaryGCD(int a, int b)
        {
            if (a == b)
                return a;
            if (a == 0)
                return Math.Abs(b);
            if (b == 0)
                return Math.Abs(a);

            if ((~a & 1) != 0)
            {
                if ((b & 1) != 0)
                    return FindBinaryGCD(a >> 1, Math.Abs(b));
                else
                    return FindBinaryGCD(a >> 1, b >> 1) << 1;
            }

            if ((~b & 1) != 0)
                return FindBinaryGCD(Math.Abs(a), b >> 1);
            if (a > b)
                return FindBinaryGCD((a - b) >> 1, Math.Abs(b));

            return FindBinaryGCD((b - a) >> 1, Math.Abs(a));
        }

        #endregion
    }
}
