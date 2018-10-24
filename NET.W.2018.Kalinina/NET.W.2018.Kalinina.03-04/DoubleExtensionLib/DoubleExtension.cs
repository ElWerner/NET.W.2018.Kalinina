using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DoubleExtensionLib
{
    /// <summary>
    /// Class that extend functionality of the Double class.
    /// Allows to convert double number to binary string in IEEE 754 format
    /// </summary>
    public static class DoubleExtension
    {
        private const int DOUBLESIZE = 64;

        /// <summary>
        /// Structure that helps to convert double value to int64 value
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        public struct DoubleToInt64
        {
            [FieldOffset(0)]
            public double DoubleVariable;

            [FieldOffset(0)]
            public long Int64Variable;
        }

        /// <summary>
        /// Method for converting double-precision floating-point format value to IEEE 754 format string
        /// </summary>
        /// <param name="number">The number to convert into binary IEEE 754 format string</param>
        /// <returns>Binary IEEE 754 foramt string</returns>
        public static string ConvertToIEEE754(this double number)
        {
            DoubleToInt64 doubleToInt64 = new DoubleToInt64();
            doubleToInt64.DoubleVariable = number;

            long int64Variable = doubleToInt64.Int64Variable;

            string binaryString = string.Empty;

            long mask = 1;
            for(int i = 0; i < DOUBLESIZE; i++)
            {
                binaryString = (int64Variable & mask) + binaryString;
                int64Variable = int64Variable >> 1;
            }

            return binaryString;
        }
    }
}
