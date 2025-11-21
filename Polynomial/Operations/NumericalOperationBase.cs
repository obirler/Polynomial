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

using System;

namespace Polynomial.Operations
{
    /// <summary>
    /// Base class for numerical operations that need to scan a polynomial's range.
    /// Provides common functionality for finding extrema and roots.
    /// </summary>
    public abstract class NumericalOperationBase
    {
        /// <summary>
        /// Calculates the initial scan step size.
        /// </summary>
        protected double GetInitialStep(double startPoint, double endPoint, int divisions = 200)
        {
            return (endPoint - startPoint) / divisions;
        }

        /// <summary>
        /// Refines a search in a narrow range.
        /// </summary>
        protected double GetRefinementStep(double left, double right, int divisions = 100)
        {
            return (right - left) / divisions;
        }

        /// <summary>
        /// Checks if a value is within the valid range.
        /// </summary>
        protected bool IsInRange(double value, double startPoint, double endPoint)
        {
            return value >= startPoint && value <= endPoint;
        }

        /// <summary>
        /// Compares two double values with a tolerance.
        /// </summary>
        protected bool AreEqual(double a, double b, double tolerance = PolynomialConstants.ComparisonTolerance)
        {
            return Math.Abs(a - b) < tolerance;
        }
    }
}
