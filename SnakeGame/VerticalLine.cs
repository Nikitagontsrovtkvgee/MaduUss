using System;

namespace SnakeGame
{
    public class VerticalLine
    {
        private int x, yStart, yEnd;

        public VerticalLine(int x, int yStart, int yEnd)
        {
            this.x = x;
            this.yStart = yStart;
            this.yEnd = yEnd;
        }

        public void Draw()
        {
            for (int y = yStart; y <= yEnd; y++)
            {
                Console.SetCursorPosition(x, y);
                Console.Write("|");
            }
        }
    }
}
