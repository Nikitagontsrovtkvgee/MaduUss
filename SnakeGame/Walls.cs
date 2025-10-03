using System;

namespace SnakeGame
{
    // Seinte joonistamine
    public static class Walls
    {
        public static void Draw(int width, int height)
        {
            for (int x = 0; x < width; x++)
            {
                Console.SetCursorPosition(x, 0); Console.Write("#");
                Console.SetCursorPosition(x, height - 1); Console.Write("#");
            }
            for (int y = 0; y < height; y++)
            {
                Console.SetCursorPosition(0, y); Console.Write("#");
                Console.SetCursorPosition(width - 1, y); Console.Write("#");
            }
        }
    }
}
