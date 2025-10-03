using System;

namespace SnakeGame
{
    public class HorizontalLine
    {
        private int y, xStart, xEnd;

        public HorizontalLine(int y, int xStart, int xEnd)
        {
            this.y = y;
            this.xStart = xStart;
            this.xEnd = xEnd;
        }

        public void Draw()
        {
            for (int x = xStart; x <= xEnd; x++)
            {
                Console.SetCursorPosition(x, y);
                Console.Write("-");
            }
        }
    }
}
