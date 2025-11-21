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

namespace Polynomial.Interfaces
{
    /// <summary>
    /// Defines the contract for parsing polynomial expressions.
    /// </summary>
    public interface IPolynomialParser
    {
        /// <summary>
        /// Validates a polynomial expression.
        /// </summary>
        /// <param name="expression">The expression to validate.</param>
        /// <returns>True if valid, false otherwise.</returns>
        bool Validate(string expression);

        /// <summary>
        /// Parses a polynomial expression into a term collection.
        /// </summary>
        /// <param name="expression">The expression to parse.</param>
        /// <returns>A collection of terms.</returns>
        TermCollection Parse(string expression);
    }
}
