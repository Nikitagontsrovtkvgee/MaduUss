using System;

namespace SnakeGame
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            if (obj is not Point other) return false;
            return X == other.X && Y == other.Y;
        }

        public override int GetHashCode() => HashCode.Combine(X, Y);
    }
}
