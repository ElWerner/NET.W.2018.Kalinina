using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathAlgorithmsLib
{
    /// <summary>
    /// Class that contains math algorithms for day 2 tasks
    /// </summary>
    public static class MathAlgorithms
    {
        /// <summary>
        /// Inserts bits range from inserted number into source number
        /// </summary>
        /// <param name="sourceNumber">Source number</param>
        /// <param name="insertedNumber">A number, a range of bits from which inserts
        /// into source number </param>
        /// <param name="fromBit">The starting bit position to insert</param>
        /// <param name="toBit">The ending bit posotion to insert</param>
        /// <returns>A number with inserted bits range</returns> 
        /// <exception cref="ArgumentException">Thrown when starting bit position is 
        /// greater than ending bit position.</exception>
        /// <exception cref="ArgumentNullException">Thrown when starting bit position
        /// or ending bit position is outside the range [0..31].</exception>
        public static int InsertNumber(int sourceNumber, int insertedNumber, int fromBit, int toBit)
        {
            if (fromBit > toBit)
                throw new ArgumentException("Starting bit position must be less then " +
                    "ending bit position.");

            if ((toBit < 0) | (toBit > 31) | (fromBit < 0) | (fromBit > 31))
                throw new ArgumentOutOfRangeException("Bit position must be in range of [0..31]");

            int nulledBitMask = (int.MaxValue << (toBit + 1)) | (int.MaxValue >> (32 - fromBit));

            int setBitMask = int.MaxValue << (toBit - fromBit + 1);

            int nulledBitSource = sourceNumber & nulledBitMask;

            int settedInsertedBitNumber = (insertedNumber & (~setBitMask)) << fromBit;

            int resultNumber = nulledBitSource | settedInsertedBitNumber;

            return resultNumber;
        }

        /// <summary>
        /// Extracts the Nth root from a number with a given precision
        /// </summary>
        /// <param name="number">The number from which the root is extracted</param>
        /// <param name="degree">The degree of the extracted root</param>
        /// <param name="precision">The precision of the root extraction</param>
        /// <returns>Nth root of a number</returns>
        /// <exception cref="ArgumentException">Thrown when a number from which the root is
        /// extracted is negative and the degree of the extracted root is even.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when precision is 
        /// out of range of (0..1).</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when degree is less then 1.</exception>
        public static double FindNthRoot(double number, int degree, double precision)
        {
            if (number < 0 && degree % 2 == 0)
                throw new ArgumentException("None of the Nth roots is real");

            if (precision >= 1 || precision <= 0)
                throw new ArgumentOutOfRangeException("Precision must be in range of (0..1)");

            if (degree < 1)
                throw new ArgumentOutOfRangeException("Degree must be greater then or equal to 1");

            double currNthRoot = number / 2;
            double prevNthRoot = 0;

            do
            {
                prevNthRoot = currNthRoot;
                currNthRoot = (1.0 / degree) * ((degree - 1) * currNthRoot + number /
                    Math.Pow(currNthRoot, degree - 1));
            } while (Math.Abs(prevNthRoot - currNthRoot) >= precision);

            return currNthRoot;
        }

        /// <summary>
        /// Filters list of integer numbers so that resultant list has only numbers 
        /// that contains given digit
        /// </summary>
        /// <param name="listOfNumbers">Filtered list of integers</param>
        /// <param name="digit">Number based on which the filtering is based</param>
        /// <returns>Filtered list of integers</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when digit parameter is 
        /// out of range of [0..9].</exception>
        /// <exception cref="ArgumentNullException">Thrown when list of numbers is 
        /// not initialized.</exception>
        public static int[] FilterDigit(int digit, params int[] listOfNumbers)
        {
            if (digit < 0 | digit > 9)
                throw new ArgumentOutOfRangeException("Digit must be in range of [0..9]");

            if (listOfNumbers == null)
                throw new ArgumentNullException("List of numbers is not initialized");

            int i = 0;

            List<int> resultList = new List<int>();

            while (i < listOfNumbers.Length)
            {
                if (IsContainsDigit(listOfNumbers[i], digit))
                    resultList.Add(listOfNumbers[i]);
                i++;
            }

            return resultList.ToArray();
        }

        /// <summary>
        /// Checks if a number contains given digit
        /// </summary>
        /// <param name="number">Checked number</param>
        /// <param name="digit">Checked digit</param>
        /// <returns>Returns True if the number contains given digit. 
        /// Returns False in other case.</returns>
        private static bool IsContainsDigit(int number, int digit)
        {
            do
            {
                if (number % 10 == digit)
                    return true;

                number = number / 10;

            } while (number != 0);

            return false;
        }

        /// <summary>
        /// Finds the next positive bigger number that consist of digits from the given number
        /// </summary>
        /// <param name="number">Source number</param>
        /// <returns>The next biggest number of the same digits</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when given number is 
        /// less then 10.</exception>
        public static int FindNextBiggerNumber(int number)
        {
            if (number < 10)
                throw new ArgumentOutOfRangeException("Given number must be greater " +
                    "then or equal to 10.");

            int[] digitArray = ConvertIntToIntArray(number);

            if (IsAscSorted(digitArray))
            {
                Swap(ref digitArray[digitArray.Length - 1], ref digitArray[digitArray.Length - 2]);

                return ConvertIntArrayToInt(digitArray);
            }

            if (IsDescSorted(digitArray))
            {
                return -1;
            }

            int pivot = 0;
            int pivotIndex = 0;

            for (int i = digitArray.Length - 2; i >= 0; i--)
            {
                if (digitArray[i] < digitArray[i + 1])
                {
                    pivot = digitArray[i];
                    pivotIndex = i;

                    int minGreaterDigit = digitArray[pivotIndex + 1];
                    int minGreaterDigitIndex = pivotIndex + 1;

                    for (int j = pivotIndex + 1; j < digitArray.Length; j++)
                    {
                        if (digitArray[j] > pivot && digitArray[j] < minGreaterDigit)
                        {
                            minGreaterDigit = digitArray[j];
                            minGreaterDigitIndex = j;
                        }
                    }

                    Swap(ref digitArray[pivotIndex], ref digitArray[minGreaterDigitIndex]);
                    Array.Sort(digitArray, pivotIndex + 1, digitArray.Length - pivotIndex - 1);

                    return ConvertIntArrayToInt(digitArray);
                }
            }

            return -1;
        }

        /// <summary>
        /// Overloaded method that finds the next positive bigger number that consist of 
        /// digits from the given number
        /// </summary>
        /// <param name="number">Source number</param>
        /// <param name="stopwatch">The reference to the stopwatch object, that helps to
        /// find elapsed time since the algorithm was started</param>
        /// <returns>The next biggest number of the same digits</returns>
        public static int FindNextBiggerNumber(int number, out long miliseconds)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int nextBiggerNumber = FindNextBiggerNumber(number);

            stopwatch.Stop();
            miliseconds = stopwatch.ElapsedMilliseconds;

            return nextBiggerNumber;
        }

        /// <summary>
        /// Converts positive integer number to digit array
        /// </summary>
        /// <param name="number">Convertible number</param>
        /// <returns>Digit array containing digits from given number</returns>
        private static int[] ConvertIntToIntArray(int number)
        {
            List<int> digitlist = new List<int>();

            do
            {
                digitlist.Add(number % 10);
                number /= 10;

            } while (number != 0);

            digitlist.Reverse();

            return digitlist.ToArray();
        }

        /// <summary>
        /// Converts array of digits to integer number
        /// </summary>
        /// <param name="digitArray">Convertible array</param>
        /// <returns>Positive integer number containing digits from given array</returns>
        private static int ConvertIntArrayToInt(int[] digitArray)
        {
            int result = digitArray[digitArray.Length - 1];

            int tmp = 10;

            for (int i = digitArray.Length - 2; i >= 0; i--)
            {
                result += digitArray[i] * tmp;
                tmp *= 10;
            }

            return result;
        }

        /// <summary>
        /// Checks if the array is sorted in ascending order
        /// </summary>
        /// <param name="number">Checked array</param>
        /// <returns>Returns True if array is sorted in ascending order. 
        /// Returns False in other case.</returns>
        private static bool IsAscSorted(int[] number)
        {
            for (int i = 0; i < number.Length - 1; i++)
            {
                if (number[i] >= number[i + 1])
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Checks if the array is sorted in descending order
        /// </summary>
        /// <param name="number">Checked array</param>
        /// <returns>Returns True if array is sorted in descending order. 
        /// Returns False in other case.</returns>
        private static bool IsDescSorted(int[] number)
        {
            for (int i = 0; i < number.Length - 1; i++)
            {
                if (number[i] < number[i + 1])
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Swaps two elements by references
        /// </summary>
        /// <param name="i">Reference to the first element</param>
        /// <param name="j">Reference to the second element</param>
        private static void Swap(ref int i, ref int j)
        {
            int temp = i;
            i = j;
            j = temp;
        }
    }
}
