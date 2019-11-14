using System;
using System.Collections.Generic;

namespace Circle
{
    // Using enum for clarity and sorting ease
    public enum CircleSide
    {
        Left = 0,
        Right = 1
    }

    public struct CircleEdge : IComparable<CircleEdge>
    {
        private long X { get; }
        public CircleSide Side { get; }

        public CircleEdge(long x, CircleSide side)
        {
            X = x;
            Side = side;
        }

        public int CompareTo(CircleEdge other)
        {
            int xComparison = X.CompareTo(other.X);
            return xComparison != 0 ? xComparison : Side.CompareTo(other.Side);
        }

        public override string ToString()
        {
            return Side + " " + X;
        }
    }

    public class Solution
    {
        // Codility forces this naming
        // ReSharper disable InconsistentNaming
        public int solution(int[] A)
        // ReSharper enable InconsistentNaming
        {
            var edges = new List<CircleEdge>();
            // O(n)
            for (long i = 0; i < A.Length; i++)
            {
                edges.Add(new CircleEdge(i - A[i], CircleSide.Left));
                edges.Add(new CircleEdge(i + A[i], CircleSide.Right));
            }

            // O(lg n)
            edges.Sort();

            // O(n)
            int currentOverlapping = 0;
            int numOverlapping = 0;
            foreach (CircleEdge edge in edges)
            {
                if (edge.Side == CircleSide.Left)
                {
                    currentOverlapping += 1;
                    numOverlapping += currentOverlapping - 1;
                    // Codility does not like the underscores in numbers
                    if (numOverlapping > 10000000) return -1;
                }
                else
                {
                    currentOverlapping -= 1;
                }
            }

            return numOverlapping;
        }
    }
}