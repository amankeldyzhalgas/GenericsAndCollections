using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace BinarySearchTreeLibrary.Tests.TestClasses
{
    public struct Point : IComparable<Point>
    {
        public int x;
        public int y;
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int CompareTo([AllowNull] Point point)
        {
            return (this.x + this.y).CompareTo(point.x + point.y);
        }
    }
}
