using System;
using System.Collections.Generic;
namespace SnakeGame
{
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        // Сравнение двух позиций
        public bool Equals(Position other)
        {
            return other != null && X == other.X && Y == other.Y;
        }
    }
}