using System;

namespace SnakeGame
{
    public class Point : IEquatable<Point>
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x = 0, int y = 0)
        {
            X = x;
            Y = y;
        }

        public void Move(int offsetX, int offsetY)
        {
            X += offsetX;
            Y += offsetY;
        }

        public bool Equals(Point? other)
        {
            if (other is null) return false;
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Point point)
                return Equals(point);
            return false;
        }

        public override int GetHashCode() => HashCode.Combine(X, Y);

        public static bool operator ==(Point? a, Point? b)
        {
            if (a is null && b is null) return true;
            if (a is null || b is null) return false;
            return a.Equals(b);
        }

        public static bool operator !=(Point? a, Point? b) => !(a == b);
    }
}
