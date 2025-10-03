using System;

namespace SnakeGame
{
    public class Walls
    {
        private int width;
        private int height;

        public Walls(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public void Draw()
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

        public bool CheckCollision(Position pos)
        {
            return pos.X <= 0 || pos.X >= width - 1 || pos.Y <= 0 || pos.Y >= height - 1;
        }
    }
}
