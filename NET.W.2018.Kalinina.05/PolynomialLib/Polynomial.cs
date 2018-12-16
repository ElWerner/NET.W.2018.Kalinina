using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolynomialLib
{
    /// <summary>
    /// Represent a class providing basic polynomial arithmetic
    /// </summary>
    public sealed class Polynomial
    {
        #region Constants
        /// <summary>
        /// A constant for comparing two double-coefficients polynomials
        /// </summary>
        private const double DELTA = 0.0000001;

        #endregion

        #region Fields
        /// <summary>
        /// An array that holds polynomial coefficients
        /// </summary>
        private double[] coefficients;

        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Polynomial"/> class with specified coefficients
        /// </summary>
        /// <param name="coefficients">An array of polynomial coefficients</param>
        /// <exception cref="ArgumentException">Thrown when coefficients array is empty</exception>
        /// <exception cref="ArgumentNullException">Thrown when coefficient 
        /// array is not initialized</exception>
        public Polynomial(params double[] coefficients)
        {
            if (coefficients.Length == 0)
            {
                throw new ArgumentException("Coefficient array is empty.");
            }

            this.coefficients = coefficients ?? throw new NullReferenceException(nameof(coefficients));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Polynomial"/> class with specified degree
        /// </summary>
        /// <param name="maximalDegree">Maximal degree of the polynomial</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when number of coefficients is less than 0</exception>
        public Polynomial(int coeffsCount)
        {
            if (coeffsCount < 0)
            {
                throw new ArgumentOutOfRangeException("Number of coefficients must be greater than 0.");
            }

            coefficients = new double[coeffsCount];
        }

        #endregion

        #region Properties
        /// <summary>
        /// Gets the number of elements in coefficients array
        /// </summary>
        public int CoeffsCount
        {
            get { return coefficients.Length; }
        }

        /// <summary>
        /// Gets the maximal degree of the polynomial
        /// </summary>
        public int MaximalDegree
        {
            get { return coefficients.Length - 1; }
        }

        /// <summary>
        /// Gets the coefficients of the polynomial
        /// </summary>
        public double[] GetCoefficients
        {
            get
            {
                double[] coefs = new double[coefficients.Length];
                Array.Copy(coefficients, coefs, coefficients.Length);
                return coefs;
            }
        }

        /// <summary>
        /// Gets or sets the coefficient of the polynomial with specified index
        /// </summary>
        /// <param name="index">The index of the coefficient</param>
        /// <returns>The coefficient with specified index</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when index is out of range</exception>
        public double this[int index]
        {
            get
            {
                if (index < 0 || index >= this.coefficients.Length)
                {
                    throw new ArgumentOutOfRangeException("Index is out of range.");
                }

                return coefficients[index];
            }

            set
            {
                if (index < 0 || index >= this.coefficients.Length)
                {
                    throw new ArgumentOutOfRangeException("Index is out of range.");
                }

                coefficients[index] = value;
            }
        }

        #endregion

        #region Public API

        /// <summary>
        /// Compares two polynomials
        /// </summary>
        /// <param name="firstPolynomial">First polynomial</param>
        /// <param name="secondPolynomial">Second polynomial</param>
        /// <returns>The biggest polynomial</returns>
        /// <exception cref="ArgumentNullException">Thrown when first or second polynomial is not initialized</exception>
        public static Polynomial FindBiggestPolynomial(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            if (firstPolynomial == null)
            {
                throw new ArgumentNullException($"{nameof(firstPolynomial)} is not initialized.");
            }

            if (secondPolynomial == null)
            {
                throw new ArgumentNullException($"{nameof(secondPolynomial)} is not initialized.");
            }

            return FindBiggestPolynom(firstPolynomial, secondPolynomial);
        }

        /// <summary>
        /// Summarizes two polynomials
        /// </summary>
        /// <param name="firstPolynomial">First polynomial</param>
        /// <param name="secondPolynomial">Second polynomial</param>
        /// <returns>The sum of two polynomials</returns>
        /// <exception cref="ArgumentNullException">Thrown when first or second polynomial is not initialized</exception>
        public static Polynomial operator +(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            if (firstPolynomial == null)
            {
                throw new ArgumentNullException($"{nameof(firstPolynomial)} is not initialized.");
            }

            if (secondPolynomial == null)
            {
                throw new ArgumentNullException($"{nameof(secondPolynomial)} is not initialized.");
            }

            return FindSumm(firstPolynomial, secondPolynomial);
        }

        /// <summary>
        /// Subtracts second polynomial from first polynomial
        /// </summary>
        /// <param name="firstPolynomial">First polynomial</param>
        /// <param name="secondPolynomial">Second polynomial</param>
        /// <returns>The result of subtracting</returns>
        /// <exception cref="ArgumentNullException">Thrown when first or second polynomial is not initialized</exception>
        public static Polynomial operator -(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            if (firstPolynomial == null)
            {
                throw new ArgumentNullException($"{nameof(firstPolynomial)} is not initialized.");
            }

            if (secondPolynomial == null)
            {
                throw new ArgumentNullException($"{nameof(secondPolynomial)} is not initialized.");
            }

            return FindDifference(firstPolynomial, secondPolynomial);
        }

        /// <summary>
        /// Multiplies two polynomials
        /// </summary>
        /// <param name="firstPolynomial">First polynomial</param>
        /// <param name="secondPolynomial">Second polynomial</param>
        /// <returns>The result of multiplying</returns>
        /// <exception cref="ArgumentNullException">Thrown when first or second polynomial is not initialized</exception>
        public static Polynomial operator *(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            if (firstPolynomial == null)
            {
                throw new ArgumentNullException($"{nameof(firstPolynomial)} is not initialized.");
            }

            if (secondPolynomial == null)
            {
                throw new ArgumentNullException($"{nameof(secondPolynomial)} is not initialized.");
            }

            return FindMultiplicationWithPolynomial(firstPolynomial, secondPolynomial);
        }

        /// <summary>
        /// Multiplies a polynomial and a number
        /// </summary>
        /// <param name="polynomial">Polynomial to multiply</param>
        /// <param name="number">Number to multiply</param>
        /// <returns>The result of multiplying</returns>
        /// <exception cref="ArgumentNullException">Thrown when polynomial is not initialized</exception>
        public static Polynomial operator *(Polynomial polynomial, double number)
        {
            if (polynomial == null)
            {
                throw new ArgumentNullException($"{nameof(polynomial)} is not initialized.");
            }

            return FindMultiplicationWithNumber(polynomial, number);
        }

        /// <summary>
        /// Compares two polynomials
        /// </summary>
        /// <param name="firstPolynomial">First polynomial</param>
        /// <param name="secondPolynomial">Second polynomial</param>
        /// <returns>True if polynomials have the same coefficients. False otherwise.</returns>
        /// <exception cref="ArgumentNullException">Thrown when first or second polynomial is not initialized</exception>
        public static bool operator ==(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            if (firstPolynomial == null)
            {
                throw new ArgumentNullException($"{nameof(firstPolynomial)} is not initialized.");
            }

            if (secondPolynomial == null)
            {
                throw new ArgumentNullException($"{nameof(secondPolynomial)} is not initialized.");
            }

            return ComparePolynomils(firstPolynomial, secondPolynomial);
        }

        /// <summary>
        /// Compares two polynomials
        /// </summary>
        /// <param name="firstPolynomial">First polynomial</param>
        /// <param name="secondPolynomial">Second polynomial</param>
        /// <returns>False if polynomials have the same coefficients. True otherwise.</returns>
        public static bool operator !=(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            return !(firstPolynomial == secondPolynomial);
        }

        /// <summary>
        /// Evaluates this polynomial at the specified point
        /// </summary>
        /// <param name="point">The point at which to evaluate the polynomial</param>
        /// <returns>The result of evaluating</returns>
        public double Evaluate(double point)
        {
            return EvaluateInPoint(point);
        }

        /// <summary>
        /// Returns a string representation of the polynomial
        /// </summary>
        /// <returns>A string that represent the polynomial</returns>
        public override string ToString()
        {
            string polimonial = string.Empty;

            string sign = string.Empty;

            int degree = this.MaximalDegree;

            for (int i = CoeffsCount - 1; i > 0; i--)
            {
                if (coefficients[i] == 0)
                {
                    degree--;
                    continue;
                }

                if (coefficients[i - 1] < 0)
                {
                    sign = "-";
                }
                else
                {
                    sign = "+";
                }

                polimonial += Math.Abs(coefficients[i]) + "x^" + degree + sign;
                degree--;
            }

            polimonial += Math.Abs(coefficients[0]);

            return polimonial;
        }

        /// <summary>
        /// Calculates a hash code for this instance
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            int hash = 17;
            for (int i = 0; i < CoeffsCount; i++)
            {
                hash = (hash * 31) + coefficients[i].GetHashCode();
            }

            return hash;
        }

        /// <summary>
        /// Compares this polynomial to the specified polynomial
        /// </summary>
        /// <param name="obj">Specified polynomial</param>
        /// <returns>True if the polynomials are equal. False otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var polynomial = obj as Polynomial;

            return this == polynomial;
        }

        #endregion

        #region Private API

        /// <summary>
        /// Compares two polynomials
        /// </summary>
        /// <param name="firstPolynomial">First polynomial</param>
        /// <param name="secondPolynomial">Second polynomial</param>
        /// <returns>The biggest polynomial</returns>
        private static Polynomial FindBiggestPolynom(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            double[] resultantPolynomCoefs;

            int firstPolynLength = firstPolynomial.CoeffsCount;
            int secondPolynLength = secondPolynomial.CoeffsCount;

            if (firstPolynLength > secondPolynLength)
            {
                resultantPolynomCoefs = new double[firstPolynLength];
                Array.Copy(firstPolynomial.GetCoefficients, resultantPolynomCoefs, firstPolynLength);
            }
            else if (firstPolynLength < secondPolynLength)
            {
                resultantPolynomCoefs = new double[secondPolynLength];
                Array.Copy(secondPolynomial.GetCoefficients, resultantPolynomCoefs, secondPolynLength);
            }
            else
            {
                resultantPolynomCoefs = new double[firstPolynLength];
                for (int i = 0; i < firstPolynLength; i++)
                {
                    if (firstPolynomial[i] > secondPolynomial[i])
                    {
                        Array.Copy(firstPolynomial.GetCoefficients, resultantPolynomCoefs, secondPolynLength);
                        break;
                    }
                    else if (firstPolynomial[i] < secondPolynomial[i])
                    {
                        Array.Copy(secondPolynomial.GetCoefficients, resultantPolynomCoefs, secondPolynLength);
                        break;
                    }
                }
            }

            return new Polynomial(resultantPolynomCoefs);
        }

        /// <summary>
        /// Summarizes two polynomials
        /// </summary>
        /// <param name="firstPolynomial">First polynomial</param>
        /// <param name="secondPolynomial">Second polynomial</param>
        /// <returns>The sum of two polynomials</returns>
        private static Polynomial FindSumm(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            Polynomial resultantPolinomial = FindBiggestPolynomial(firstPolynomial, secondPolynomial);

            for (int i = resultantPolinomial.CoeffsCount - 1; i >= 0; i--)
            {
                double a = 0, b = 0;

                if (i < firstPolynomial.CoeffsCount)
                {
                    a = firstPolynomial[i];
                }

                if (i < secondPolynomial.CoeffsCount)
                {
                    b = secondPolynomial[i];
                }

                resultantPolinomial[i] = a + b;
            }

            return resultantPolinomial;
        }

        /// <summary>
        /// Subtracts second polynomial from first polynomial
        /// </summary>
        /// <param name="firstPolynomial">First polynomial</param>
        /// <param name="secondPolynomial">Second polynomial</param>
        /// <returns>The result of subtracting</returns>
        private static Polynomial FindDifference(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            Polynomial resultantPolinomial = FindBiggestPolynomial(firstPolynomial, secondPolynomial);

            for (int i = 0; i < resultantPolinomial.CoeffsCount; i++)
            {
                double a = 0, b = 0;

                if (i < firstPolynomial.CoeffsCount)
                {
                    a = firstPolynomial[i];
                }

                if (i < secondPolynomial.CoeffsCount)
                {
                    b = secondPolynomial[i];
                }

                resultantPolinomial[i] = a - b;
            }

            return resultantPolinomial;
        }

        /// <summary>
        /// Multiplies two polynomials
        /// </summary>
        /// <param name="firstPolynomial">First polynomial</param>
        /// <param name="secondPolynomial">Second polynomial</param>
        /// <returns>The result of multiplying</returns>
        private static Polynomial FindMultiplicationWithPolynomial(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            Polynomial resultantPolinomial = new Polynomial(firstPolynomial.CoeffsCount +
                secondPolynomial.CoeffsCount - 1);

            for (int i = 0; i < firstPolynomial.CoeffsCount; i++)
            {
                for (int j = 0; j < secondPolynomial.CoeffsCount; j++)
                {
                    resultantPolinomial[i + j] += firstPolynomial[i] * secondPolynomial[j];
                }
            }

            return resultantPolinomial;
        }

        /// <summary>
        /// Multiplies a polynomial and a number
        /// </summary>
        /// <param name="polynomial">Polynomial to multiply</param>
        /// <param name="number">Number to multiply</param>
        /// <returns>The result of multiplying</returns>
        private static Polynomial FindMultiplicationWithNumber(Polynomial polynomial, double number)
        {
            Polynomial resultantPolinomial = new Polynomial(polynomial.CoeffsCount);

            for (int i = 0; i < polynomial.CoeffsCount; i++)
            {
                resultantPolinomial[i] = polynomial[i] * number;
            }

            return resultantPolinomial;
        }

        /// <summary>
        /// Compares two polynomials
        /// </summary>
        /// <param name="firstPolynomial">First polynomial</param>
        /// <param name="secondPolynomial">Second polynomial</param>
        /// <returns>True if polynomials have the same coefficients. False otherwise.</returns>
        private static bool ComparePolynomils(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            if (firstPolynomial.CoeffsCount != secondPolynomial.CoeffsCount)
            {
                return false;
            }

            for (int i = 0; i < firstPolynomial.CoeffsCount; i++)
            {
                if (Math.Abs(firstPolynomial[i] - secondPolynomial[i]) > DELTA)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Evaluates this polynomial at the specified point
        /// </summary>
        /// <param name="point">The point at which to evaluate the polynomial</param>
        /// <returns>The result of evaluating</returns>
        private double EvaluateInPoint(double point)
        {
            double result = 0;
            for (int i = 0; i < CoeffsCount; i++)
            {
                result += coefficients[i] * point;
            }

            return result;
        }

        #endregion
    }
}