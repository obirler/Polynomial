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
    /// Base interface for polynomial operations.
    /// </summary>
    /// <typeparam name="TResult">The result type of the operation.</typeparam>
    public interface IPolynomialOperation<TResult>
    {
        /// <summary>
        /// Executes the operation on a polynomial.
        /// </summary>
        /// <param name="polynomial">The polynomial to operate on.</param>
        /// <returns>The result of the operation.</returns>
        TResult Execute(IPolynomial polynomial);
    }
}
