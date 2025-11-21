/*
========================================================================
    Copyright (C) 2022 Omer Birler.
    
    This file is part of polynomial project.
    Mesnet is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.
    Mesnet is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.
    You should have received a copy of the GNU General Public License
    along with Mesnet.  If not, see <http://www.gnu.org/licenses/>.
========================================================================
*/

using Polynomial.Interfaces;
using Polynomial.Parsers;

namespace Polynomial.Factories
{
    /// <summary>
    /// Factory for creating polynomial instances.
    /// Implements Factory pattern for better object creation and DIP compliance.
    /// </summary>
    public class PolynomialFactory
    {
        private readonly IPolynomialParser _parser;

        /// <summary>
        /// Creates a new instance with default parser.
        /// </summary>
        public PolynomialFactory()
        {
            _parser = new PolynomialParser();
        }

        /// <summary>
        /// Creates a new instance with a custom parser (Dependency Injection).
        /// </summary>
        /// <param name="parser">Custom parser implementation.</param>
        public PolynomialFactory(IPolynomialParser parser)
        {
            _parser = parser;
        }

        /// <summary>
        /// Creates a polynomial from an expression string.
        /// </summary>
        /// <param name="expression">The polynomial expression.</param>
        /// <returns>A new Poly instance.</returns>
        public Poly Create(string expression)
        {
            var terms = _parser.Parse(expression);
            return new Poly(terms);
        }

        /// <summary>
        /// Creates a polynomial from an expression with start and end points.
        /// </summary>
        /// <param name="expression">The polynomial expression.</param>
        /// <param name="startPoint">The start point of the domain.</param>
        /// <param name="endPoint">The end point of the domain.</param>
        /// <returns>A new Poly instance.</returns>
        public Poly Create(string expression, double startPoint, double endPoint)
        {
            var terms = _parser.Parse(expression);
            return new Poly(terms, startPoint, endPoint);
        }

        /// <summary>
        /// Creates a polynomial from a term collection.
        /// </summary>
        /// <param name="terms">The collection of terms.</param>
        /// <returns>A new Poly instance.</returns>
        public Poly Create(TermCollection terms)
        {
            return new Poly(terms);
        }

        /// <summary>
        /// Creates a polynomial from a term collection with start and end points.
        /// </summary>
        /// <param name="terms">The collection of terms.</param>
        /// <param name="startPoint">The start point of the domain.</param>
        /// <param name="endPoint">The end point of the domain.</param>
        /// <returns>A new Poly instance.</returns>
        public Poly Create(TermCollection terms, double startPoint, double endPoint)
        {
            return new Poly(terms, startPoint, endPoint);
        }

        /// <summary>
        /// Creates a polynomial from a single term.
        /// </summary>
        /// <param name="term">The term.</param>
        /// <param name="startPoint">The start point of the domain.</param>
        /// <param name="endPoint">The end point of the domain.</param>
        /// <returns>A new Poly instance.</returns>
        public Poly Create(Term term, double startPoint, double endPoint)
        {
            return new Poly(term, startPoint, endPoint);
        }
    }
}
