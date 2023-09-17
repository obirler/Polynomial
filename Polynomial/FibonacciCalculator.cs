using System;
using System.Collections.Generic;

namespace Polynomial
{
    public class FibonacciCalculator
    {
        public int Calculate(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException("Input must be a positive integer.");
            }

            int a = 0;
            int b = 1;

            for (int i = 0; i < n; i++)
            {
                int temp = a;
                a = b;
                b = temp + b;
            }

            return a;
        }

        public List<int> GenerateSequence(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException("Input must be a positive integer.");
            }

            List<int> sequence = new List<int>();
            int a = 0;
            int b = 1;

            for (int i = 0; i < n; i++)
            {
                sequence.Add(a);
                int temp = a;
                a = b;
                b = temp + b;
            }

            return sequence;
        }
    }
}
