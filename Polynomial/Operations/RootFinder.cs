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
using System.Collections.Generic;
using Polynomial.Interfaces;

namespace Polynomial.Operations
{
    /// <summary>
    /// Finds roots of a polynomial using numerical methods.
    /// Implements Single Responsibility Principle.
    /// </summary>
    public class RootFinder : NumericalOperationBase, IPolynomialOperation<List<double>>
    {
        /// <summary>
        /// Finds all roots of the polynomial in its defined range.
        /// </summary>
        public List<double> Execute(IPolynomial polynomial)
        {
            if (polynomial == null)
                return null;

            double step = PolynomialConstants.RootFindingStep;
            
            // Get derivative - cast is necessary for Poly-specific operations
            var poly = polynomial as Poly;
            if (poly == null)
                return null;
            var derivative = new DifferentiationOperation().Execute(poly);
            
            var rootList = new List<double>();
            double previous = 0;

            for (double i = polynomial.StartPoint; i <= polynomial.EndPoint; i += step)
            {
                double currentValue = i;
                if (currentValue > polynomial.EndPoint)
                {
                    currentValue = polynomial.EndPoint;
                }

                if (currentValue > polynomial.StartPoint)
                {
                    double current = polynomial.Calculate(currentValue);
                    if (HasSignChange(previous, current))
                    {
                        double root = FindRootInRange(polynomial, derivative, currentValue - step, currentValue);
                        rootList.Add(root);
                    }
                }
                previous = polynomial.Calculate(currentValue);
            }

            return rootList.Count > 0 ? rootList : null;
        }

        /// <summary>
        /// Checks if there's a sign change between two values.
        /// </summary>
        private bool HasSignChange(double value1, double value2)
        {
            return (value1 > 0 && value2 < 0) || (value1 < 0 && value2 > 0);
        }

        /// <summary>
        /// Finds a root in the specified range using Newton's method.
        /// </summary>
        private double FindRootInRange(IPolynomial polynomial, Poly derivative, double min, double max)
        {
            double previous = (min + max) / 2;
            double tolerance = PolynomialConstants.RootTolerance;
            double root = double.MaxValue;

            while (Math.Abs(previous - root) > tolerance)
            {
                if (root < double.MaxValue)
                {
                    previous = root;
                }
                root = previous - polynomial.Calculate(previous) / derivative.Calculate(previous);
            }
            return root;
        }
    }
}
