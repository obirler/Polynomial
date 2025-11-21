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

namespace Polynomial.Operations
{
    /// <summary>
    /// Contains constant values used in polynomial operations.
    /// Extracted to avoid magic numbers throughout the codebase.
    /// </summary>
    public static class PolynomialConstants
    {
        /// <summary>
        /// Default initial step for numerical operations.
        /// </summary>
        public const double DefaultInitialStep = 200.0;

        /// <summary>
        /// Default end step for numerical operations.
        /// </summary>
        public const double DefaultEndStep = 100.0;

        /// <summary>
        /// Default number of decimal digits for rounding.
        /// </summary>
        public const int DefaultDigits = 4;

        /// <summary>
        /// Root finding tolerance.
        /// </summary>
        public const double RootTolerance = 0.00001;

        /// <summary>
        /// Step size for root finding.
        /// </summary>
        public const double RootFindingStep = 0.01;

        /// <summary>
        /// Comparison tolerance for floating point operations.
        /// </summary>
        public const double ComparisonTolerance = 0.000001;
    }
}
