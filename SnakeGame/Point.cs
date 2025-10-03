namespace SnakeGame
{
    // Punkt klass
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool Equals(Point other)
        {
            return other != null && X == other.X && Y == other.Y;
        }
    }
}
