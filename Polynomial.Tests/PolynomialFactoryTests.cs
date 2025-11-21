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
using Polynomial.Factories;

namespace Polynomial.Tests
{
    [TestClass]
    public class PolynomialFactoryTests
    {
        [TestMethod]
        public void Create_WithExpression_CreatesValidPolynomial()
        {
            // Arrange
            var factory = new PolynomialFactory();

            // Act
            var poly = factory.Create("x^2 + 1");

            // Assert
            Assert.IsNotNull(poly);
            Assert.AreEqual(5, poly.Calculate(2), 0.0001);
        }

        [TestMethod]
        public void Create_WithExpressionAndRange_SetsRangeCorrectly()
        {
            // Arrange
            var factory = new PolynomialFactory();

            // Act
            var poly = factory.Create("x^2", 0, 10);

            // Assert
            Assert.IsNotNull(poly);
            Assert.AreEqual(0, poly.StartPoint);
            Assert.AreEqual(10, poly.EndPoint);
        }

        [TestMethod]
        public void Create_WithTermCollection_CreatesValidPolynomial()
        {
            // Arrange
            var factory = new PolynomialFactory();
            var terms = new TermCollection();
            terms.Add(new Term(2, 1));
            terms.Add(new Term(0, 1));

            // Act
            var poly = factory.Create(terms);

            // Assert
            Assert.IsNotNull(poly);
            Assert.AreEqual(5, poly.Calculate(2), 0.0001); // x^2 + 1 at x=2
        }

        [TestMethod]
        public void Create_WithSingleTerm_CreatesValidPolynomial()
        {
            // Arrange
            var factory = new PolynomialFactory();
            var term = new Term(2, 3);

            // Act
            var poly = factory.Create(term, 0, 10);

            // Assert
            Assert.IsNotNull(poly);
            Assert.AreEqual(12, poly.Calculate(2), 0.0001); // 3x^2 at x=2 = 12
        }
    }
}
