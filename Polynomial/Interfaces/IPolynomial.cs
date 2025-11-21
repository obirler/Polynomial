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

namespace Polynomial.Interfaces
{
    /// <summary>
    /// Defines the contract for polynomial operations.
    /// </summary>
    public interface IPolynomial
    {
        /// <summary>
        /// Gets or sets the start point of the polynomial domain.
        /// </summary>
        double StartPoint { get; set; }

        /// <summary>
        /// Gets or sets the end point of the polynomial domain.
        /// </summary>
        double EndPoint { get; set; }

        /// <summary>
        /// Calculates the value of the polynomial at a given x value.
        /// </summary>
        /// <param name="x">The x value.</param>
        /// <returns>The calculated polynomial value.</returns>
        double Calculate(double x);

        /// <summary>
        /// Returns the degree of the polynomial.
        /// </summary>
        /// <returns>The degree (highest power) of the polynomial.</returns>
        double Degree();

        /// <summary>
        /// Determines whether this polynomial is a constant.
        /// </summary>
        /// <returns>True if constant, false otherwise.</returns>
        bool IsConstant();

        /// <summary>
        /// Determines whether this polynomial is linear.
        /// </summary>
        /// <returns>True if linear, false otherwise.</returns>
        bool IsLinear();
    }
}
