/*
========================================================================
    Copyright (C) 2025 Omer Birler.
    
    This file is part of polynomial project.
    Polynomial is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.
    Polynomial is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.
    You should have received a copy of the GNU General Public License
    along with Polynomial.  If not, see <http://www.gnu.org/licenses/>.
========================================================================
*/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Polynomial;
using System;

namespace Polynomial.Tests
{
    [TestClass]
    public class PolyTests
    {
        [TestMethod]
        public void Constructor_WithStringExpression_CreatesValidPolynomial()
        {
            // Arrange & Act
            Console.WriteLine("TEST: Constructor_WithStringExpression_CreatesValidPolynomial");
            Console.WriteLine("Testing: Creating polynomial from string expression");
            string expression = "3x^2 + 2x - 1";
            Console.WriteLine($"Input expression: '{expression}'");
            
            var poly = new Poly(expression);
            Console.WriteLine($"Polynomial created: {poly}");

            // Assert
            Console.WriteLine($"Expected: Non-null polynomial with 3 terms");
            Console.WriteLine($"Actual: Terms count = {poly.Terms.Count}");
            Assert.IsNotNull(poly);
            Assert.IsNotNull(poly.Terms);
            Assert.AreEqual(3, poly.Terms.Count);
            Console.WriteLine("✓ Test passed");
        }

        [TestMethod]
        public void Constructor_WithStartAndEndPoints_SetsRangeCorrectly()
        {
            // Arrange & Act
            Console.WriteLine("TEST: Constructor_WithStartAndEndPoints_SetsRangeCorrectly");
            Console.WriteLine("Testing: Creating polynomial with defined range");
            string expression = "x^2";
            double startPoint = 0;
            double endPoint = 10;
            Console.WriteLine($"Input: expression='{expression}', startPoint={startPoint}, endPoint={endPoint}");
            
            var poly = new Poly(expression, startPoint, endPoint);

            // Assert
            Console.WriteLine($"Expected: StartPoint={startPoint}, EndPoint={endPoint}");
            Console.WriteLine($"Actual: StartPoint={poly.StartPoint}, EndPoint={poly.EndPoint}");
            Assert.AreEqual(0, poly.StartPoint);
            Assert.AreEqual(10, poly.EndPoint);
            Console.WriteLine("✓ Test passed");
        }

        [TestMethod]
        public void Calculate_WithSimplePolynomial_ReturnsCorrectValue()
        {
            // Arrange
            Console.WriteLine("TEST: Calculate_WithSimplePolynomial_ReturnsCorrectValue");
            Console.WriteLine("Testing: Calculating polynomial value at x=3");
            string expression = "x^2 + 2x + 1";
            Console.WriteLine($"Polynomial: {expression}");
            var poly = new Poly(expression);

            // Act
            double x = 3;
            double result = poly.Calculate(x);

            // Assert
            // 3^2 + 2*3 + 1 = 9 + 6 + 1 = 16
            double expected = 16;
            Console.WriteLine($"Calculation at x={x}: 3^2 + 2*3 + 1 = 9 + 6 + 1");
            Console.WriteLine($"Expected: {expected}");
            Console.WriteLine($"Actual: {result}");
            Assert.AreEqual(expected, result, 0.0001);
            Console.WriteLine("✓ Test passed");
        }

        [TestMethod]
        public void Calculate_WithNegativeCoefficients_ReturnsCorrectValue()
        {
            // Arrange
            Console.WriteLine("TEST: Calculate_WithNegativeCoefficients_ReturnsCorrectValue");
            Console.WriteLine("Testing: Calculating polynomial with negative coefficients");
            string expression = "2x^2 - 3x + 1";
            Console.WriteLine($"Polynomial: {expression}");
            var poly = new Poly(expression);

            // Act
            double x = 2;
            double result = poly.Calculate(x);

            // Assert
            // 2*4 - 3*2 + 1 = 8 - 6 + 1 = 3
            double expected = 3;
            Console.WriteLine($"Calculation at x={x}: 2*4 - 3*2 + 1 = 8 - 6 + 1");
            Console.WriteLine($"Expected: {expected}");
            Console.WriteLine($"Actual: {result}");
            Assert.AreEqual(expected, result, 0.0001);
            Console.WriteLine("✓ Test passed");
        }

        [TestMethod]
        public void Integrate_SimplePolynomial_ReturnsCorrectIntegral()
        {
            // Arrange
            Console.WriteLine("TEST: Integrate_SimplePolynomial_ReturnsCorrectIntegral");
            Console.WriteLine("Testing: Integration of x^2");
            string expression = "x^2";
            Console.WriteLine($"Original polynomial: {expression}");
            var poly = new Poly(expression);

            // Act
            var integrated = poly.Integrate();
            Console.WriteLine($"Integrated polynomial: {integrated}");

            // Assert
            // Integral of x^2 is (1/3)x^3
            Assert.IsNotNull(integrated);
            double x = 3;
            var result = integrated.Calculate(x);
            // (1/3) * 27 = 9
            double expected = 9;
            Console.WriteLine($"Expected integral of x^2: (1/3)x^3");
            Console.WriteLine($"At x={x}: (1/3)*27 = {expected}");
            Console.WriteLine($"Calculated: {result}");
            Assert.AreEqual(expected, result, 0.0001);
            Console.WriteLine("✓ Test passed");
        }

        [TestMethod]
        public void Derivate_SimplePolynomial_ReturnsCorrectDerivative()
        {
            // Arrange
            Console.WriteLine("TEST: Derivate_SimplePolynomial_ReturnsCorrectDerivative");
            Console.WriteLine("Testing: Differentiation of x^3 + 2x^2 + 3x");
            string expression = "x^3 + 2x^2 + 3x";
            Console.WriteLine($"Original polynomial: {expression}");
            var poly = new Poly(expression);

            // Act
            var derivative = poly.Derivate();
            Console.WriteLine($"Derivative polynomial: {derivative}");

            // Assert
            // Derivative of x^3 + 2x^2 + 3x is 3x^2 + 4x + 3
            double x = 2;
            var result = derivative.Calculate(x);
            // 3*4 + 4*2 + 3 = 12 + 8 + 3 = 23
            double expected = 23;
            Console.WriteLine($"Expected derivative: 3x^2 + 4x + 3");
            Console.WriteLine($"At x={x}: 3*4 + 4*2 + 3 = 12 + 8 + 3 = {expected}");
            Console.WriteLine($"Calculated: {result}");
            Assert.AreEqual(expected, result, 0.0001);
            Console.WriteLine("✓ Test passed");
        }

        [TestMethod]
        public void DefiniteIntegral_WithRange_ReturnsCorrectValue()
        {
            // Arrange
            Console.WriteLine("TEST: DefiniteIntegral_WithRange_ReturnsCorrectValue");
            Console.WriteLine("Testing: Definite integral of x from 0 to 2");
            string expression = "x";
            Console.WriteLine($"Polynomial: {expression}");
            var poly = new Poly(expression);

            // Act
            double start = 0, end = 2;
            double result = poly.DefiniteIntegral(start, end);

            // Assert
            // Integral of x from 0 to 2 is (1/2)*x^2 = (1/2)*4 - 0 = 2
            double expected = 2;
            Console.WriteLine($"Definite integral from {start} to {end}");
            Console.WriteLine($"Formula: ∫x dx = (1/2)x^2");
            Console.WriteLine($"Calculation: [(1/2)*{end}^2] - [(1/2)*{start}^2] = {expected}");
            Console.WriteLine($"Expected: {expected}");
            Console.WriteLine($"Actual: {result}");
            Assert.AreEqual(expected, result, 0.0001);
            Console.WriteLine("✓ Test passed");
        }

        [TestMethod]
        public void Addition_TwoPolynomials_ReturnsCorrectSum()
        {
            // Arrange
            Console.WriteLine("TEST: Addition_TwoPolynomials_ReturnsCorrectSum");
            Console.WriteLine("Testing: Adding two polynomials");
            string expr1 = "x^2 + 2x";
            string expr2 = "3x^2 - x + 1";
            Console.WriteLine($"Polynomial 1: {expr1}");
            Console.WriteLine($"Polynomial 2: {expr2}");
            var poly1 = new Poly(expr1);
            var poly2 = new Poly(expr2);

            // Act
            var sum = poly1 + poly2;
            Console.WriteLine($"Sum: {sum}");

            // Assert
            double x = 2;
            var result = sum.Calculate(x);
            // (4 + 4) + (12 - 2 + 1) = 8 + 11 = 19
            double expected = 19;
            Console.WriteLine($"At x={x}:");
            Console.WriteLine($"  Poly1: {x}^2 + 2*{x} = 4 + 4 = 8");
            Console.WriteLine($"  Poly2: 3*{x}^2 - {x} + 1 = 12 - 2 + 1 = 11");
            Console.WriteLine($"  Sum: 8 + 11 = {expected}");
            Console.WriteLine($"Calculated: {result}");
            Assert.AreEqual(expected, result, 0.0001);
            Console.WriteLine("✓ Test passed");
        }

        [TestMethod]
        public void Subtraction_TwoPolynomials_ReturnsCorrectDifference()
        {
            // Arrange
            var poly1 = new Poly("5x^2 + 3x");
            var poly2 = new Poly("2x^2 + x");

            // Act
            var diff = poly1 - poly2;

            // Assert
            var result = diff.Calculate(2);
            // (20 + 6) - (8 + 2) = 26 - 10 = 16
            Assert.AreEqual(16, result, 0.0001);
        }

        [TestMethod]
        public void Multiplication_TwoPolynomials_ReturnsCorrectProduct()
        {
            // Arrange
            Console.WriteLine("TEST: Multiplication_TwoPolynomials_ReturnsCorrectProduct");
            Console.WriteLine("Testing: Multiplying (x+1) * (x-1)");
            string expr1 = "x + 1";
            string expr2 = "x - 1";
            Console.WriteLine($"Polynomial 1: {expr1}");
            Console.WriteLine($"Polynomial 2: {expr2}");
            var poly1 = new Poly(expr1);
            var poly2 = new Poly(expr2);

            // Act
            var product = poly1 * poly2;
            Console.WriteLine($"Product: {product}");

            // Assert
            double x = 3;
            var result = product.Calculate(x);
            // (x+1)(x-1) = x^2 - 1, at x=3: 9 - 1 = 8
            double expected = 8;
            Console.WriteLine($"Expected formula: (x+1)(x-1) = x^2 - 1");
            Console.WriteLine($"At x={x}: {x}^2 - 1 = 9 - 1 = {expected}");
            Console.WriteLine($"Calculated: {result}");
            Assert.AreEqual(expected, result, 0.0001);
            Console.WriteLine("✓ Test passed");
        }

        [TestMethod]
        public void MultiplicationByScalar_ReturnsCorrectProduct()
        {
            // Arrange
            var poly = new Poly("x^2 + 2x");

            // Act
            var result = poly * 3.0;

            // Assert
            var value = result.Calculate(2);
            // 3*(4 + 4) = 24
            Assert.AreEqual(24, value, 0.0001);
        }

        [TestMethod]
        public void Degree_ReturnsHighestPower()
        {
            // Arrange
            var poly = new Poly("5x^4 + 3x^2 + 2");

            // Act
            double degree = poly.Degree();

            // Assert
            Assert.AreEqual(4, degree);
        }

        [TestMethod]
        public void IsConstant_WithConstantPolynomial_ReturnsTrue()
        {
            // Arrange
            var poly = new Poly("5");

            // Act
            bool isConstant = poly.IsConstant();

            // Assert
            Assert.IsTrue(isConstant);
        }

        [TestMethod]
        public void IsConstant_WithNonConstantPolynomial_ReturnsFalse()
        {
            // Arrange
            var poly = new Poly("x + 5");

            // Act
            bool isConstant = poly.IsConstant();

            // Assert
            Assert.IsFalse(isConstant);
        }

        [TestMethod]
        public void IsLinear_WithLinearPolynomial_ReturnsTrue()
        {
            // Arrange
            var poly = new Poly("2x + 3");

            // Act
            bool isLinear = poly.IsLinear();

            // Assert
            Assert.IsTrue(isLinear);
        }

        [TestMethod]
        public void IsLinear_WithQuadraticPolynomial_ReturnsFalse()
        {
            // Arrange
            var poly = new Poly("x^2 + 2x");

            // Act
            bool isLinear = poly.IsLinear();

            // Assert
            Assert.IsFalse(isLinear);
        }

        [TestMethod]
        public void ToString_ReturnsCorrectStringRepresentation()
        {
            // Arrange
            var poly = new Poly("3x^2 + 2x - 1");

            // Act
            string result = poly.ToString();

            // Assert
            Assert.IsTrue(result.Contains("x^2"));
            Assert.IsTrue(result.Contains("x"));
        }

        [TestMethod]
        public void ValidateExpression_WithValidExpression_ReturnsTrue()
        {
            // Act
            bool isValid = Poly.ValidateExpression("3x^2 + 2x - 1");

            // Assert
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void ValidateExpression_WithInvalidExpression_ReturnsFalse()
        {
            // Act
            bool isValid = Poly.ValidateExpression("3x^2 + invalid");

            // Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void Square_ReturnsPolynomialSquared()
        {
            // Arrange
            var poly = new Poly("x + 1");

            // Act
            var squared = poly.Square();

            // Assert
            var result = squared.Calculate(2);
            // (2 + 1)^2 = 9
            Assert.AreEqual(9, result, 0.0001);
        }

        [TestMethod]
        public void Cube_ReturnsPolynomialCubed()
        {
            // Arrange
            var poly = new Poly("x + 1");

            // Act
            var cubed = poly.Cube();

            // Assert
            var result = cubed.Calculate(2);
            // (2 + 1)^3 = 27
            Assert.AreEqual(27, result, 0.0001);
        }

        [TestMethod]
        public void Parse_UpdatesPolynomialWithNewExpression()
        {
            // Arrange
            var poly = new Poly("x");

            // Act
            poly.Parse("x^2 + 1");
            var result = poly.Calculate(2);

            // Assert
            Assert.AreEqual(5, result, 0.0001); // 4 + 1 = 5
        }
    }
}
