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

namespace Polynomial.Tests
{
    [TestClass]
    public class TermTests
    {
        [TestMethod]
        public void Constructor_WithPowerAndCoefficient_CreatesValidTerm()
        {
            // Arrange & Act
            var term = new Term(2, 3.5);

            // Assert
            Assert.AreEqual(2, term.Power);
            Assert.AreEqual(3.5, term.Coefficient);
        }

        [TestMethod]
        public void Constructor_WithStringExpression_ParsesSimpleTerm()
        {
            // Arrange & Act
            var term = new Term("3x^2");

            // Assert
            Assert.AreEqual(2, term.Power);
            Assert.AreEqual(3, term.Coefficient);
        }

        [TestMethod]
        public void Constructor_WithLinearTerm_ParsesCorrectly()
        {
            // Arrange & Act
            var term = new Term("5x");

            // Assert
            Assert.AreEqual(1, term.Power);
            Assert.AreEqual(5, term.Coefficient);
        }

        [TestMethod]
        public void Constructor_WithConstantTerm_ParsesCorrectly()
        {
            // Arrange & Act
            var term = new Term("7");

            // Assert
            Assert.AreEqual(0, term.Power);
            Assert.AreEqual(7, term.Coefficient);
        }

        [TestMethod]
        public void Constructor_WithNegativeCoefficient_ParsesCorrectly()
        {
            // Arrange & Act
            var term = new Term("-4x^3");

            // Assert
            Assert.AreEqual(3, term.Power);
            Assert.AreEqual(-4, term.Coefficient);
        }

        [TestMethod]
        public void Constructor_WithUnitCoefficient_ParsesCorrectly()
        {
            // Arrange & Act
            var term = new Term("x^2");

            // Assert
            Assert.AreEqual(2, term.Power);
            Assert.AreEqual(1, term.Coefficient);
        }

        [TestMethod]
        public void Constructor_WithNegativeUnitCoefficient_ParsesCorrectly()
        {
            // Arrange & Act
            var term = new Term("-x^2");

            // Assert
            Assert.AreEqual(2, term.Power);
            Assert.AreEqual(-1, term.Coefficient);
        }

        [TestMethod]
        public void ToString_WithPositiveTerm_ReturnsCorrectFormat()
        {
            // Arrange
            var term = new Term(2, 3);

            // Act
            string result = term.ToString();

            // Assert
            Assert.IsTrue(result.Contains("3"));
            Assert.IsTrue(result.Contains("x^2"));
        }

        [TestMethod]
        public void ToString_WithNegativeTerm_ReturnsCorrectFormat()
        {
            // Arrange
            var term = new Term(2, -3);

            // Act
            string result = term.ToString();

            // Assert
            Assert.IsTrue(result.StartsWith("-"));
        }

        [TestMethod]
        public void GetString_WithSpecifiedDigits_RoundsCorrectly()
        {
            // Arrange
            var term = new Term(2, 3.14159);

            // Act
            string result = term.GetString(2);

            // Assert
            Assert.IsTrue(result.Contains("3.14"));
        }

        [TestMethod]
        public void Power_SetNegativeValue_StoresAsPositive()
        {
            // Arrange & Act
            var term = new Term();
            term.Power = -3;

            // Assert
            Assert.AreEqual(3, term.Power);
        }

        [TestMethod]
        public void Coefficient_SetValue_StoresCorrectly()
        {
            // Arrange & Act
            var term = new Term();
            term.Coefficient = -5.5;

            // Assert
            Assert.AreEqual(-5.5, term.Coefficient);
        }
    }
}
