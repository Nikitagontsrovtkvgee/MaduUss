using System;
using System.Collections.Generic;

namespace Snake
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
            Point head = snake.GetNextPoint();
            Point p = pList[0];

            // догоняем змейку
            if (p.x < head.x) p.x++;
            else if (p.x > head.x) p.x--;

            if (p.y < head.y) p.y++;
            else if (p.y > head.y) p.y--;

            Draw();
        }

        public bool IsHitSnake(Snake snake)
        {
            return snake.IsHit(this);
        }
    }
}