﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookServiceLib
{
    /// <summary>
    /// Represents a class provides formatting an object to it's string representation with specified format
    /// </summary>
    public class PriceFormatProvider : IFormatProvider, ICustomFormatter
    {
        #region Fields
        /// <summary>
        /// A field to hold culture info
        /// </summary>
        private CultureInfo cultureInfo;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PriceFormatProvider"/> class with culture by default
        /// </summary>
        public PriceFormatProvider() : this(CultureInfo.CurrentCulture)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PriceFormatProvider"/> class with specified culture
        /// </summary>
        public PriceFormatProvider(CultureInfo cultureInfo)
        {
            this.cultureInfo = cultureInfo;

            BookServiceLogger.Log.Trace("Initialized a new instance of the PriceFormatProvider class.");
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns an object that provides formatting service for specified type
        /// </summary>
        /// <param name="formatType">Specified type of formatting</param>
        /// <returns>An object that provides formatting service for specified type</returns>
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }

            return null;
        }

        /// <summary>
        /// Formats an object to it's string representation with specified format
        /// </summary>
        /// <param name="format">Specified string format</param>
        /// <param name="arg">Object to format</param>
        /// <param name="prov">Specified object format</param>
        /// <returns>String representation of the object with specified format</returns>
        /// <exception cref="ArgumentNullException">Thrown when object to format is null</exception>
        /// <exception cref="ArgumentException">Thrown when object doesn't conform type.</exception>
        public string Format(string format, object arg, IFormatProvider prov)
        {
            if (arg == null)
            {
                BookServiceLogger.Log.Error($"{nameof(arg)} is null.");
                throw new ArgumentNullException($"{nameof(arg)} is null.");
            }

            if (!(arg is decimal value))
            {
                BookServiceLogger.Log.Error($"{nameof(arg)} doesn't conform decimal type.");
                throw new ArgumentException($"{nameof(arg)} doesn't conform decimal type.");
            }

            string resultantString = string.Empty;
            
            resultantString = value.ToString("C", cultureInfo);
            BookServiceLogger.Log.Error($"The string was received: {resultantString}.");
            return resultantString;
        }

        #endregion
    }
}
