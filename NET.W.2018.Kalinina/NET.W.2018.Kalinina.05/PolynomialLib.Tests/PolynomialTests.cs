using System;
using NUnit.Framework;

namespace PolynomialLib.Tests
{
    [TestFixture]
    public class PolynomialTests
    {
        [TestCase(new double[] { 1, 8, 6, 8, 0, 3 })]
        [TestCase(new double[] { 1, 8, 0, 0, 0, 3 })]
        [TestCase(new double[] { -9, 3, 6, 8, 4, -6 })]
        [TestCase(new double[] { -8, -30, -5, -16, 8, 4 })]
        public void Polynomial_InitializeTest(double[] coeffs)
        {
            Polynomial newPolynomial = new Polynomial(coeffs);

            Assert.IsNotNull(newPolynomial);
        }

        [Test]
        public void Polynomial_InitializeTest_ArgumentExceptionExpected()
        {
            double[] coeffs = { };
            Assert.Throws<ArgumentException>(() => new Polynomial(coeffs));
        }

        [Test]
        public void Polynomial_InitializeTest_ArgumentNullExceptionExpected()
        {
            double[] coeffs = null;
            Assert.Throws<NullReferenceException>(() => new Polynomial(coeffs));
        }

        [TestCase(new double[] { 1, 8, 6, 8 }, ExpectedResult = 3)]
        [TestCase(new double[] { 1, 8 }, ExpectedResult = 1)]
        [TestCase(new double[] { -9 }, ExpectedResult = 0)]
        [TestCase(new double[] { -8, -30, -5, -16, 8, 4 }, ExpectedResult = 5)]
        public int Polynomial_GetMaximalDegreeTest(double[] coeffs)
        {
            Polynomial newPolynomial = new Polynomial(coeffs);

            int actual = newPolynomial.MaximalDegree;

            return actual;
        }

        [TestCase(3, new double[] { 1, 8, 6, 8 }, ExpectedResult = 8)]
        [TestCase(0, new double[] { 1, 8 }, ExpectedResult = 1)]
        [TestCase(0, new double[] { -9 }, ExpectedResult = -9)]
        [TestCase(4, new double[] { -8, -30, -5, -16, 8, 4 }, ExpectedResult = 8)]
        public double Polynomial_GetElementByIndexTest_ElementExpected(int index, double[] coeffs)
        {
            Polynomial newPolynomial = new Polynomial(coeffs);

            double actual = newPolynomial[index];

            return actual;
        }

        [Test]
        public void Polynomial_GetElementByIndexTest_IndexOutOfRangeExceptionExpected()
        {
            Polynomial newPolynomial = new Polynomial(1.6, 8, 4.2, 0, 6);

            double actual; 
            Assert.Throws<IndexOutOfRangeException>(() =>  actual = newPolynomial[6]);
        }

        [TestCase(new double[] { 4, 3, 0, 5 }, new double[] { 1, 3, 2 }, ExpectedResult = new double[] { 5, 6, 2, 5 })]
        [TestCase(new double[] { 0, 1.5, 1}, new double[] { 0.06, 1, 7 }, ExpectedResult = new double[] { 0.06, 2.5, 8 })]
        [TestCase(new double[] { 0, 0, 0, 1 }, new double[] { 1}, ExpectedResult = new double[] { 1, 0, 0, 1 })]
        [TestCase(new double[] { 0.15, 0.23 }, new double[] { 0, 0, 0.26 }, ExpectedResult = new double[] { 0.15, 0.23, 0.26 })]
        public double[] Polynomial_GetSumTest(double[] firstCoeffs, double[] secondCoeffs)
        {
            Polynomial firstPolynomial = new Polynomial(firstCoeffs);
            Polynomial secondPolynomial = new Polynomial(secondCoeffs);

            Polynomial result = firstPolynomial + secondPolynomial;

            return result.GetCoefficients;
        }

        [TestCase(new double[] { 4, 3, 0, 5 }, new double[] { 1, 3, 2 }, ExpectedResult = new double[] { 3, 0, -2, 5 })]
        [TestCase(new double[] { 0, 1.5, 1 }, new double[] { 0.06, 1, 7 }, ExpectedResult = new double[] { -0.06, 0.5, -6 })]
        [TestCase(new double[] { 0, 0, 0, 1 }, new double[] { 1 }, ExpectedResult = new double[] { -1, 0, 0, 1 })]
        [TestCase(new double[] { 0.15, 0.23 }, new double[] { 0, 0, 0.26 }, ExpectedResult = new double[] { 0.15, 0.23, -0.26 })]
        public double[] Polynomial_GetSubtractTest(double[] firstCoeffs, double[] secondCoeffs)
        {
            Polynomial firstPolynomial = new Polynomial(firstCoeffs);
            Polynomial secondPolynomial = new Polynomial(secondCoeffs);

            Polynomial result = firstPolynomial - secondPolynomial;

            return result.GetCoefficients;
        }

        [TestCase(new double[] { 4, 3, 0, 5 }, new double[] { 1, 3, 2 }, ExpectedResult = new double[] { 4, 15, 17, 11, 15, 10 })]
        [TestCase(new double[] { 0, 1.5, 1 }, new double[] { 4, 1, 7 }, ExpectedResult = new double[] { 0, 6, 5.5, 11.5, 7})]
        public double[] Polynomial_GetMultiplTest(double[] firstCoeffs, double[] secondCoeffs)
        {
            Polynomial firstPolynomial = new Polynomial(firstCoeffs);
            Polynomial secondPolynomial = new Polynomial(secondCoeffs);

            Polynomial result = firstPolynomial * secondPolynomial;

            return result.GetCoefficients;
        }

        [TestCase(new double[] { 4, 3, 0, 5 }, 4, ExpectedResult = new double[] { 16, 12, 0, 20 })]
        [TestCase(new double[] { 0, 1.5, 1 }, 0, ExpectedResult = new double[] { 0, 0, 0 })]
        public double[] Polynomial_GetMultiplWithNumberTest(double[] firstCoeffs, double number)
        {
            Polynomial firstPolynomial = new Polynomial(firstCoeffs);

            Polynomial result = firstPolynomial * number;

            return result.GetCoefficients;
        }

        [TestCase(new double[] { 4, 3, 0, 5 }, new double[] { 1, 3, 2 }, ExpectedResult = false)]
        [TestCase(new double[] { 0, 1.5, 1 }, new double[] { 0, 1.5, 1 }, ExpectedResult = true)]
        public bool Polynomial_AreQualTest(double[] firstCoeffs, double[] secondCoeffs)
        {
            Polynomial firstPolynomial = new Polynomial(firstCoeffs);
            Polynomial secondPolynomial = new Polynomial(secondCoeffs);

            return firstPolynomial.Equals(secondPolynomial);
        }

        [TestCase(new double[] { 4, 3, 0, 5 }, new double[] { 1, 3, 2 }, ExpectedResult = false)]
        [TestCase(new double[] { 0, 1.5, 1 }, new double[] { 0, 1.5, 1 }, ExpectedResult = true)]
        public bool Polynomial_QualOperationTest(double[] firstCoeffs, double[] secondCoeffs)
        {
            Polynomial firstPolynomial = new Polynomial(firstCoeffs);
            Polynomial secondPolynomial = new Polynomial(secondCoeffs);

            return firstPolynomial == secondPolynomial;
        }

        [TestCase(new double[] { 4, 3, 0, 5 }, new double[] { 1, 3, 2 }, ExpectedResult = true)]
        [TestCase(new double[] { 0, 1.5, 1 }, new double[] { 0, 1.5, 1 }, ExpectedResult = false)]
        public bool Polynomial_NotQualOperationTest(double[] firstCoeffs, double[] secondCoeffs)
        {
            Polynomial firstPolynomial = new Polynomial(firstCoeffs);
            Polynomial secondPolynomial = new Polynomial(secondCoeffs);

            return firstPolynomial != secondPolynomial;
        }

        [TestCase(new double[] { 4, 3, 0, 5 }, ExpectedResult = "5x^3+3x^1+4")]
        [TestCase(new double[] { -84, 6, -6 }, ExpectedResult = "-6x^2+6x^1-84")]
        public string Polynomial_ToStringTest(double[] firstCoeffs)
        {
            Polynomial firstPolynomial = new Polynomial(firstCoeffs);

            return firstPolynomial.ToString();
        }
    }
}
