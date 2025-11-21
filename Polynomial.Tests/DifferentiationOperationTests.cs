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

namespace Polynomial.Tests
{
    [TestClass]
    public class DifferentiationOperationTests
    {
        [TestMethod]
        public void Execute_WithQuadraticPolynomial_ReturnsCorrectDerivative()
        {
            // Arrange
            var poly = new Poly("x^2");
            var operation = new DifferentiationOperation();

            // Act
            var result = operation.Execute(poly);

            // Assert
            Assert.IsNotNull(result);
            // Derivative of x^2 is 2x
            double value = result.Calculate(3);
            Assert.AreEqual(6, value, 0.0001);
        }

        [TestMethod]
        public void Execute_WithCubicPolynomial_ReturnsCorrectDerivative()
        {
            // Arrange
            var poly = new Poly("x^3");
            var operation = new DifferentiationOperation();

            // Act
            var result = operation.Execute(poly);

            // Assert
            Assert.IsNotNull(result);
            // Derivative of x^3 is 3x^2
            double value = result.Calculate(2);
            Assert.AreEqual(12, value, 0.0001);
        }

        [TestMethod]
        public void Execute_WithLinearPolynomial_ReturnsConstant()
        {
            // Arrange
            var poly = new Poly("5x");
            var operation = new DifferentiationOperation();

            // Act
            var result = operation.Execute(poly);

            // Assert
            Assert.IsNotNull(result);
            // Derivative of 5x is 5
            double value = result.Calculate(100); // Should be constant
            Assert.AreEqual(5, value, 0.0001);
        }

        [TestMethod]
        public void Execute_WithMultipleTerms_DifferentiatesAllTerms()
        {
            // Arrange
            var poly = new Poly("2x^3 + 3x^2 + 4x + 5");
            var operation = new DifferentiationOperation();

            // Act
            var result = operation.Execute(poly);

            // Assert
            Assert.IsNotNull(result);
            // Derivative is 6x^2 + 6x + 4
            double value = result.Calculate(1);
            // 6 + 6 + 4 = 16
            Assert.AreEqual(16, value, 0.0001);
        }
    }
}
