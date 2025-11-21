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
using Polynomial.Interfaces;

namespace Polynomial.Parsers
{
    /// <summary>
    /// Responsible for parsing polynomial expressions into term collections.
    /// Implements Single Responsibility Principle by separating parsing logic.
    /// </summary>
    public class PolynomialParser : IPolynomialParser
    {
        private const string ValidCharacters = "+-x1234567890^.E";

        /// <summary>
        /// Validates a polynomial expression.
        /// </summary>
        /// <param name="expression">The expression to validate.</param>
        /// <returns>True if valid, false otherwise.</returns>
        public bool Validate(string expression)
        {
            if (string.IsNullOrEmpty(expression))
                return false;

            expression = NormalizeExpression(expression);

            foreach (char c in expression)
            {
                if (ValidCharacters.IndexOf(c) == -1)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Parses a polynomial expression into a term collection.
        /// </summary>
        /// <param name="expression">The expression to parse.</param>
        /// <returns>A collection of terms.</returns>
        public TermCollection Parse(string expression)
        {
            if (!Validate(expression))
            {
                throw new ArgumentException("Invalid Polynomial Expression: " + expression);
            }

            var terms = new TermCollection();
            expression = expression.Replace(" ", "");
            
            string nextChar = string.Empty;
            string nextTerm = string.Empty;
            bool epow = false;

            for (int i = 0; i < expression.Length; i++)
            {
                nextChar = expression.Substring(i, 1);
                if (nextChar == "E")
                {
                    epow = true;
                }

                if ((nextChar == "-" || nextChar == "+") && i > 0)
                {
                    if (epow)
                    {
                        epow = false;
                    }
                    else
                    {
                        HandleTerm(nextTerm, terms);
                        nextTerm = string.Empty;
                    }
                }
                nextTerm += nextChar;
            }
            HandleTerm(nextTerm, terms);

            terms.Sort(TermCollection.SortType.ASC);
            return terms;
        }

        /// <summary>
        /// Normalizes the expression by removing extra operators.
        /// </summary>
        private string NormalizeExpression(string expression)
        {
            expression = expression.Trim().Replace(" ", "");
            while (expression.IndexOf("--") > -1 || expression.IndexOf("++") > -1 || 
                   expression.IndexOf("^^") > -1 || expression.IndexOf("xx") > -1)
            {
                expression = expression.Replace("--", "-");
                expression = expression.Replace("++", "+");
                expression = expression.Replace("^^", "^");
                expression = expression.Replace("xx", "x");
            }
            return expression;
        }

        /// <summary>
        /// Handles parsing of individual terms.
        /// </summary>
        private void HandleTerm(string term, TermCollection terms)
        {
            if (string.IsNullOrEmpty(term))
                return;

            Term termItem;
            if (term.Contains("E"))
            {
                termItem = ParseScientificNotation(term);
            }
            else
            {
                termItem = new Term(term);
            }
            terms.Add(termItem);
        }

        /// <summary>
        /// Parses terms with scientific notation.
        /// </summary>
        private Term ParseScientificNotation(string term)
        {
            var coeffs = term.Split('E');
            double c = Convert.ToDouble(coeffs[0]);
            
            if (coeffs[1].Contains("x^"))
            {
                var epxs = coeffs[1].Split(new string[] { "x^" }, StringSplitOptions.None);
                double p1 = Convert.ToDouble(epxs[0]);
                double p2 = Convert.ToDouble(epxs[1]);
                return new Term(p2, c * System.Math.Pow(10, p1));
            }
            else if (coeffs[1].Contains("x"))
            {
                var epxs = coeffs[1].Split(new string[] { "x" }, StringSplitOptions.None);
                double p1 = Convert.ToDouble(epxs[0]);
                return new Term(1, c * System.Math.Pow(10, p1));
            }
            else
            {
                double p = Convert.ToDouble(coeffs[1]);
                return new Term(0, c * System.Math.Pow(10, p));
            }
        }
    }
}
