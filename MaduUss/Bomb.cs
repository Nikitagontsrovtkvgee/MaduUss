using System;
using System.Collections.Generic;

namespace SnakeGame
{
    class Bomb : Figure
    {
        public int speed; // можно использовать для регулировки частоты движения

        public Bomb(int x, int y, char sym, int speed = 1)
        {
            this.speed = speed;
            pList = new List<Point> { new Point(x, y, sym) };
        }

        public void MoveTowards(Snake snake)
        {
            Position head = snake.GetHead();
            Point p = pList[0];

            // догоняем змейку
            if (p.x < head.X) p.x++;
            else if (p.x > head.X) p.x--;

            if (p.y < head.Y) p.y++;
            else if (p.y > head.Y) p.y--;

            Draw();
        }

        public bool IsHitSnake(Snake snake)
        {
            return snake.IsHit(this);
        }
    }
}