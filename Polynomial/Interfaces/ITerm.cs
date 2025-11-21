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
    /// Defines the contract for a polynomial term.
    /// </summary>
    public interface ITerm
    {
        /// <summary>
        /// Gets or sets the power of the term.
        /// </summary>
        double Power { get; set; }

        /// <summary>
        /// Gets or sets the coefficient of the term.
        /// </summary>
        double Coefficient { get; set; }

        /// <summary>
        /// Returns a string representation of the term.
        /// </summary>
        /// <returns>String representation.</returns>
        string ToString();

        /// <summary>
        /// Returns a string representation with specified decimal places.
        /// </summary>
        /// <param name="digit">Number of decimal places.</param>
        /// <returns>Formatted string representation.</returns>
        string GetString(int digit);
    }
}
