using System;

namespace SnakeGame
{
    // Horisontaaljoon (näiteks kaartidele)
    public class HorizontalLine
    {
        public void Draw(int y, int xStart, int xEnd)
        {
            for (int x = xStart; x <= xEnd; x++)
            {
                Console.SetCursorPosition(x, y);
                Console.Write("-");
            }
        }
    }
}
