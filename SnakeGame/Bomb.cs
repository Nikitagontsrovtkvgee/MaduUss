using System;

namespace SnakeGame
{
    // Bomber klass
    public class Bomb
    {
        private Random random = new Random();
        public Position Pos { get; private set; }
        private char symbol;
        private int difficulty;

        public Bomb(int x, int y, char sym, int diff)
        {
            Pos = new Position(x, y);
            symbol = sym;
            difficulty = diff;
        }

        public void Move(Snake player, int mapWidth, int mapHeight)
        {
            // Liigub juhuslikult
            int dx = random.Next(-1, 2);
            int dy = random.Next(-1, 2);
            Pos.X += dx;
            Pos.Y += dy;

            if (Pos.X <= 0) Pos.X = 1;
            if (Pos.X >= mapWidth - 1) Pos.X = mapWidth - 2;
            if (Pos.Y <= 0) Pos.Y = 1;
            if (Pos.Y >= mapHeight - 1) Pos.Y = mapHeight - 2;
        }

        public bool IsHitSnake(Snake snake)
        {
            return Pos.Equals(snake.GetHead());
        }

        public Position GetHead()
        {
            return Pos;
        }
    }
}
