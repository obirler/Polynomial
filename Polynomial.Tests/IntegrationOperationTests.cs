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
using Polynomial.Operations;
using System.Diagnostics;

namespace Polynomial.Tests
{
    [TestClass]
    public class IntegrationOperationTests
    {
        [TestMethod]
        public void Execute_WithSimplePolynomial_ReturnsCorrectIntegral()
        {
            // Arrange
            Debug.WriteLine("TEST: Execute_WithSimplePolynomial_ReturnsCorrectIntegral");
            Debug.WriteLine("Testing: Integration operation on x^2");
            string expression = "x^2";
            Debug.WriteLine($"Input polynomial: {expression}");
            var poly = new Poly(expression);
            var operation = new IntegrationOperation();

            // Act
            var result = operation.Execute(poly);
            Debug.WriteLine($"Integrated polynomial: {result}");

            // Assert
            Assert.IsNotNull(result);
            // Integral of x^2 is (1/3)x^3
            double x = 3;
            double value = result.Calculate(x);
            double expected = 9; // (1/3) * 27 = 9
            Debug.WriteLine($"Expected integral: (1/3)x^3");
            Debug.WriteLine($"At x={x}: (1/3)*27 = {expected}");
            Debug.WriteLine($"Calculated: {value}");
            Assert.AreEqual(expected, value, 0.0001);
            Debug.WriteLine("✓ Test passed");
        }

        [TestMethod]
        public void Execute_WithLinearPolynomial_ReturnsCorrectIntegral()
        {
            // Arrange
            var poly = new Poly("2x");
            var operation = new IntegrationOperation();

            // Act
            var result = operation.Execute(poly);

            // Assert
            Assert.IsNotNull(result);
            // Integral of 2x is x^2
            double value = result.Calculate(2);
            Assert.AreEqual(4, value, 0.0001);
        }

        [TestMethod]
        public void Execute_WithConstant_ReturnsLinearTerm()
        {
            // Arrange
            var poly = new Poly("5");
            var operation = new IntegrationOperation();

            // Act
            var result = operation.Execute(poly);

            // Assert
            Assert.IsNotNull(result);
            // Integral of 5 is 5x
            double value = result.Calculate(2);
            Assert.AreEqual(10, value, 0.0001);
        }

        [TestMethod]
        public void Execute_WithMultipleTerms_IntegratesAllTerms()
        {
            // Arrange
            var poly = new Poly("x^2 + 3x + 2");
            var operation = new IntegrationOperation();

            // Act
            var result = operation.Execute(poly);

            // Assert
            Assert.IsNotNull(result);
            // Integral is (1/3)x^3 + (3/2)x^2 + 2x
            double value = result.Calculate(1);
            // (1/3) + (3/2) + 2 = 0.333... + 1.5 + 2 = 3.833...
            Assert.AreEqual(3.8333, value, 0.01);
        }
    }
}
