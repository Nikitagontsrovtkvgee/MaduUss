using System;

namespace SnakeGame
{
    // Vaenlase (bomber) liikumine
    public class Enemy
    {
        private Random random = new Random();
        public Position Pos { get; private set; }
        private int mapWidth;
        private int mapHeight;

        public Enemy(int width, int height)
        {
            mapWidth = width;
            mapHeight = height;
            Pos = new Position(random.Next(1, width - 1), random.Next(1, height - 1));
        }

        public void Move()
        {
            int dx = random.Next(-1, 2);
            int dy = random.Next(-1, 2);

            Pos.X += dx;
            Pos.Y += dy;

            if (Pos.X <= 0) Pos.X = 1;
            if (Pos.X >= mapWidth - 1) Pos.X = mapWidth - 2;
            if (Pos.Y <= 0) Pos.Y = 1;
            if (Pos.Y >= mapHeight - 1) Pos.Y = mapHeight - 2;
        }
    }
}
