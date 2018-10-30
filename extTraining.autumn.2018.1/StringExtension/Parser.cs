using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace StringExtension
{
    /// <summary>
    /// Represens a class that extends string class
    /// </summary>
    public static class Parser
    {
        /// <summary>
        /// A field to hold symbols used in hexadecimal numbers
        /// </summary>
        private static string chars = "ABCDEF";

        /// <summary>
        /// Converts a string from specified numeric base to decimal integer number
        /// </summary>
        /// <param name="source">String to convert</param>
        /// <param name="base">Numeric base of the string</param>
        /// <returns>Decimal integer number</returns>
        /// <exception cref="ArgumentNullException">Thrown when source string is null or empty</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when numeric base is less than 2
        /// or greater than 16</exception>
        /// <exception cref="ArgumentException">Thrown when source string is not in the base</exception>
        public static int ToDecimal(this string source, int @base)
        {
            if(string.IsNullOrEmpty(source))
            {
                throw new ArgumentNullException("String is not initialized");
            }

            if(@base < 2 || @base > 16)
            {
                throw new ArgumentOutOfRangeException("Base is out of range.");
            }

            if(!IsValidString(source, @base))
            {
                throw new ArgumentException("String is not in the base.");
            }

            return ParseString(source, @base);
        }

        /// <summary>
        /// Converts a string from specified numeric base to decimal integer number
        /// </summary>
        /// <param name="source">String to convert</param>
        /// <param name="base">Numeric base of the string</param>
        /// <returns>Decimal integer number</returns>
        private static int ParseString(string source, int @base)
        {
            int result = 0;
            checked
            {
                string tempString = "";
                int tempValue;
                for (int i = 0; i < source.Length; i++)
                {
                    tempString = "";

                    tempString += GetChar(source.Substring(i, 1));
                    tempValue = (int)Math.Pow(@base, source.Length - (i + 1));

                    result += Convert.ToInt32(tempString) * tempValue;
                }
            }

            return result;
        }

        /// <summary>
        /// Gets next char in the specified string in decimal base
        /// </summary>
        /// <param name="source">String to get char</param>
        /// <returns>Next char</returns>
        private static string GetChar(string source)
        {
            string tmp = "";
            if (chars.IndexOf(source.ToUpper()) == -1)
            {
                tmp += source;
            }
            else
            {
                tmp += (chars.IndexOf(source.ToUpper()) + 10).ToString();
            }

            return tmp;
        }

        /// <summary>
        /// Checks if source string is in the base
        /// </summary>
        /// <param name="source">String to check</param>
        /// <param name="base">Numeric base</param>
        /// <returns>True if string is in the base. False otherwise</returns>
        private static bool IsValidString(string source, int @base)
        {
            string validStringReg = "";

            if (@base > 11)
            {
                validStringReg = "^[0-9a-" + chars[@base - 11].ToString().ToLower() + 
                    "A-" + chars[@base - 11]+ "]+$";
            }
            else
            if(@base == 11)
            {
                validStringReg = "^[0-9aA]+$";
            }
            else
            {
                validStringReg = "^[0-" + (@base - 1) + "]+$";
            }

            Regex reg = new Regex(validStringReg);

            return reg.IsMatch(source);
        }
    }
}
