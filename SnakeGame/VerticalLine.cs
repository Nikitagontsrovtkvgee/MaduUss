using System;

namespace SnakeGame
{
    // Vertikaaljoon (näiteks kaartidele)
    public class VerticalLine
    {
        public void Draw(int x, int yStart, int yEnd)
        {
            for (int y = yStart; y <= yEnd; y++)
            {
                Console.SetCursorPosition(x, y);
                Console.Write("|");
            }
        }
    }
}
