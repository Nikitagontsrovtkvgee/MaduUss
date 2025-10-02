using System;
using System.Collections.Generic;

namespace SnakeGame
{

    public class Enemy
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Symbol { get; set; } = 'E';

        public Enemy(int x, int y)
        {
            X = x;
            Y = y;
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