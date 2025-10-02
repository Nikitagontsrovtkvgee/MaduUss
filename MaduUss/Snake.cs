using System;
using System.Collections.Generic;

namespace SnakeGame
{
    // Класс змейки
    public class Snake
    {
        public List<Position> Body { get; private set; }
        public Direction CurrentDirection { get; private set; }

        public Snake(Position startPos, Direction startDir, int initialLength)
        {
            CurrentDirection = startDir;
            Body = new List<Position>();
            for (int i = 0; i < initialLength; i++)
            {
                Body.Add(new Position(startPos.X, startPos.Y + i)); // начальное тело
            }
        }

        // Двигаем змейку
        public void Move()
        {
            Position head = Body[0];
            Position newHead = CurrentDirection switch
            {
                Direction.Up => new Position(head.X, head.Y - 1),
                Direction.Down => new Position(head.X, head.Y + 1),
                Direction.Left => new Position(head.X - 1, head.Y),
                Direction.Right => new Position(head.X + 1, head.Y),
                _ => head
            };

            Body.Insert(0, newHead);
            Body.RemoveAt(Body.Count - 1);
        }

        // Смена направления (нельзя в противоположную)
        public void SetDirection(Direction dir)
        {
            if ((CurrentDirection == Direction.Up && dir == Direction.Down) ||
                (CurrentDirection == Direction.Down && dir == Direction.Up) ||
                (CurrentDirection == Direction.Left && dir == Direction.Right) ||
                (CurrentDirection == Direction.Right && dir == Direction.Left))
                return; // запрещено двигаться в противоположную
            CurrentDirection = dir;
        }

        // Проверка на столкновение с самим собой
        public bool CheckSelfCollision()
        {
            Position head = Body[0];
            for (int i = 1; i < Body.Count; i++)
            {
                if (head.Equals(Body[i])) return true;
            }
            return false;
        }

        // Добавление нового сегмента
        public void Grow()
        {
            Position tail = Body[Body.Count - 1];
            Body.Add(new Position(tail.X, tail.Y));
        }
        public Position GetHead()
        {
            return Body[0];
        }
        public bool IsHit(Figure figure)
        {
            foreach (var part in Body)
            {
                foreach (var p in figure.pList)
                {
                    if (part.X == p.x && part.Y == p.y) return true;
                }
            }
            return false;
        }
    }
}
