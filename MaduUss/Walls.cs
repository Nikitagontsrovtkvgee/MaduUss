using System;
using System.Collections.Generic;

namespace SnakeGame
{

    public class Wall
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Symbol { get; set; } = '#';
        public int Duration { get; set; }

        public Wall(int x, int y, int duration = 5)
        {
            X = x;
            Y = y;
            Duration = duration;
        }

        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(Symbol);
        }

        public void Clear()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(' ');
        }
    }
}