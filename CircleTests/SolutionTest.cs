using System;
using System.Collections.Generic;
using Circle;
using Xunit;

namespace CircleTests
{
    public class SolutionTest
    {
        [Theory]
        [InlineData(new[] {1, 5, 2, 1, 4, 0}, 11)]
        [InlineData(new int[] { }, 0)]
        [InlineData(new[] {0, 0}, 0)]
        [InlineData(new[] {0, 0, 2, 0, 0, 0}, 4)]
        [InlineData(new[] {1, 2147483647, 0}, 2)]
        [MemberData(nameof(A_Lot_Of_Plain_Circles))]
        [MemberData(nameof(A_Lot_Of_Overlapping_Circles))]
        public void IsValid(int[] a, int result)
        {
            var sut = new Solution();
            Assert.Equal(result, sut.solution(a));
        }

        public static IEnumerable<object[]> A_Lot_Of_Plain_Circles()
        {
            var circles = new int[100_000];
            for (int i = 0; i < circles.Length; i++)
            {
                circles[i] = 0;
            }

            circles[50_000] = 50_000;
            yield return new object[] {circles, 99_999};
        }

        public static IEnumerable<object[]> A_Lot_Of_Overlapping_Circles()
        {
            var circles = new int[100_000];
            for (int i = 0; i < circles.Length; i++)
            {
                circles[i] = 100_000;
            }

            yield return new object[] {circles, -1};
        }
    }
}