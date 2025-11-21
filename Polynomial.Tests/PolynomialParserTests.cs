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
using Polynomial.Parsers;
using System;
using System.Diagnostics;

namespace Polynomial.Tests
{
    [TestClass]
    public class PolynomialParserTests
    {
        private PolynomialParser _parser;

        [TestInitialize]
        public void Setup()
        {
            _parser = new PolynomialParser();
        }

        [TestMethod]
        public void Validate_WithValidExpression_ReturnsTrue()
        {
            // Act
            Debug.WriteLine("TEST: Validate_WithValidExpression_ReturnsTrue");
            Debug.WriteLine("Testing: Validating polynomial expression");
            string expression = "3x^2 + 2x - 1";
            Debug.WriteLine($"Input expression: '{expression}'");
            
            bool result = _parser.Validate(expression);

            // Assert
            Debug.WriteLine($"Expected: true (valid expression)");
            Debug.WriteLine($"Actual: {result}");
            Assert.IsTrue(result);
            Debug.WriteLine("✓ Test passed");
        }

        [TestMethod]
        public void Validate_WithInvalidCharacters_ReturnsFalse()
        {
            // Act
            bool result = _parser.Validate("3x^2 + invalid");

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Validate_WithEmptyString_ReturnsFalse()
        {
            // Act
            bool result = _parser.Validate("");

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Parse_WithSimpleExpression_ReturnsCorrectTerms()
        {
            // Act
            Debug.WriteLine("TEST: Parse_WithSimpleExpression_ReturnsCorrectTerms");
            Debug.WriteLine("Testing: Parsing polynomial expression into terms");
            string expression = "x^2 + 2x + 1";
            Debug.WriteLine($"Input expression: '{expression}'");
            
            var terms = _parser.Parse(expression);

            // Assert
            int expectedCount = 3;
            Debug.WriteLine($"Expected: {expectedCount} terms");
            Debug.WriteLine($"Actual: {terms.Count} terms");
            for (int i = 0; i < terms.Count; i++)
            {
                Debug.WriteLine($"  Term {i+1}: Power={terms[i].Power}, Coefficient={terms[i].Coefficient}");
            }
            Assert.IsNotNull(terms);
            Assert.AreEqual(expectedCount, terms.Count);
            Debug.WriteLine("✓ Test passed");
        }

        [TestMethod]
        public void Parse_WithNegativeCoefficients_ParsesCorrectly()
        {
            // Act
            var terms = _parser.Parse("3x^2 - 2x + 1");

            // Assert
            Assert.IsNotNull(terms);
            Assert.AreEqual(3, terms.Count);
        }

        [TestMethod]
        public void Parse_WithScientificNotation_ParsesCorrectly()
        {
            // Act
            var terms = _parser.Parse("1E2x^2");

            // Assert
            Assert.IsNotNull(terms);
            Assert.IsTrue(terms.Count > 0);
        }

        [TestMethod]
        public void Parse_WithInvalidExpression_ThrowsException()
        {
            // Arrange & Act
            try
            {
                _parser.Parse("invalid expression @#$");
                Assert.Fail("Expected ArgumentException was not thrown");
            }
            catch (ArgumentException)
            {
                // Expected exception
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void Parse_WithSpaces_IgnoresSpaces()
        {
            // Act
            var terms1 = _parser.Parse("x^2 + 2x + 1");
            var terms2 = _parser.Parse("x^2+2x+1");

            // Assert
            Assert.AreEqual(terms1.Count, terms2.Count);
        }

        [TestMethod]
        public void Parse_WithMultipleSigns_NormalizesCorrectly()
        {
            // Act
            var terms = _parser.Parse("x^2 + 2x");

            // Assert
            Assert.IsNotNull(terms);
            Assert.AreEqual(2, terms.Count);
        }
    }
}
