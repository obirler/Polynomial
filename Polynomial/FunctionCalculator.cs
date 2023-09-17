using System;

namespace Polynomial
{
    public class FunctionCalculator
    {
        public delegate double Function(double x);

        public Poly CalculateFunctionForPoly(Poly poly, Function f)
        {
            Poly result = new Poly();

            foreach (Term term in poly.Terms)
            {
                double newCoefficient = f(term.Coefficient);
                Term newTerm = new Term(term.Power, newCoefficient);
                result.Terms.Add(newTerm);
            }

            return result;
        }

        public PiecewisePoly CalculateFunctionForPiecewisePoly(PiecewisePoly piecewisePoly, Function f)
        {
            PiecewisePoly result = new PiecewisePoly();

            foreach (Poly poly in piecewisePoly)
            {
                Poly newPoly = CalculateFunctionForPoly(poly, f);
                result.Add(newPoly);
            }

            return result;
        }
    }
}
