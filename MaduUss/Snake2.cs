using System;

namespace Snake
{
    class Snake2 : Snake
    {
        public Snake2(Point tail, int length, Direction dir) : base(tail, length, dir) { }

        public void HandleKey2(ConsoleKey key)
        {
            if (key == ConsoleKey.A) direction = Direction.LEFT;
            else if (key == ConsoleKey.D) direction = Direction.RIGHT;
            else if (key == ConsoleKey.W) direction = Direction.UP;
            else if (key == ConsoleKey.S) direction = Direction.DOWN;
        }

        public void HandleKeyMirror(ConsoleKey key)
        {
            if (key == ConsoleKey.LeftArrow) direction = Direction.RIGHT;
            else if (key == ConsoleKey.RightArrow) direction = Direction.LEFT;
            else if (key == ConsoleKey.UpArrow) direction = Direction.DOWN;
            else if (key == ConsoleKey.DownArrow) direction = Direction.UP;
        }
    }
}