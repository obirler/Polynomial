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

using Polynomial.Interfaces;

namespace Polynomial.Operations
{
    /// <summary>
    /// Performs integration operation on polynomials.
    /// Implements Single Responsibility Principle.
    /// </summary>
    public class IntegrationOperation : IPolynomialOperation<Poly>
    {
        /// <summary>
        /// Executes integration on the given polynomial.
        /// </summary>
        /// <param name="polynomial">The polynomial to integrate.</param>
        /// <returns>The integrated polynomial.</returns>
        public Poly Execute(IPolynomial polynomial)
        {
            var poly = polynomial as Poly;
            if (poly == null)
                return null;

            var terms = new TermCollection();
            foreach (Term t in poly.Terms)
            {
                var pow = t.Power + 1;
                var coeff = t.Coefficient / (t.Power + 1);
                terms.Add(new Term(pow, coeff));
            }
            return new Poly(terms);
        }
    }
}
