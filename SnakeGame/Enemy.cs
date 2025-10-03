using System;

namespace SnakeGame
{
    // Vaenlane – liikuva madu baasklass
    public class Enemy : Snake
    {
        private Random random = new Random();

        public Enemy(Position startPos, Direction dir, int length)
            : base(startPos, dir, length)
        {
        }

        // Liikumine juhuslikult või peegeldusmoodis
        public void MoveRandom(int width, int height)
        {
            Direction dir = (Direction)random.Next(0, 4);
            SetDirection(dir);

            Move();

            // Kontroll piiride vastu
            Position head = GetHead();
            if (head.X <= 0) head.X = 1;
            if (head.X >= width - 1) head.X = width - 2;
            if (head.Y <= 0) head.Y = 1;
            if (head.Y >= height - 1) head.Y = height - 2;
        }

        // Kas vaenlane tabas mängijat
        public bool CheckCollision(Snake player)
        {
            Position head = GetHead();
            foreach (var part in player.Body)
            {
                if (head.Equals(part))
                    return true;
            }
            return false;
        }
    }
}
