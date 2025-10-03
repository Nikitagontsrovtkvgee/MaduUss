using System.Collections.Generic;

namespace SnakeGame
{
    public class Snake
    {
        public List<Position> Body { get; private set; }
        private Direction currentDirection;
        public bool IsBooster { get; private set; }

        public Direction CurrentDirection => currentDirection;

        public Snake(Position start, Direction dir, int size)
        {
            Body = new List<Position>();
            for (int i = 0; i < size; i++)
                Body.Add(new Position(start.X - i, start.Y));
            currentDirection = dir;
            IsBooster = false;
        }

        public void SetDirection(Direction dir)
        {
            currentDirection = dir;
        }

        public Position GetHead() => Body[0];

        public void Move()
        {
            Position head = GetHead().Copy();
            switch (currentDirection)
            {
                case Direction.Up: head.Y--; break;
                case Direction.Down: head.Y++; break;
                case Direction.Left: head.X--; break;
                case Direction.Right: head.X++; break;
            }
            Body.Insert(0, head);
            Body.RemoveAt(Body.Count - 1);
        }

        public void Grow()
        {
            Position tail = Body[Body.Count - 1];
            Body.Add(new Position(tail.X, tail.Y));
        }

        public bool CheckSelfCollision()
        {
            Position head = GetHead();
            for (int i = 1; i < Body.Count; i++)
                if (head.Equals(Body[i])) return true;
            return false;
        }

        public bool CheckWallCollision(int width, int height)
        {
            Position head = GetHead();
            return head.X <= 0 || head.X >= width - 1 || head.Y <= 0 || head.Y >= height - 1;
        }

        public void ActivateBooster() => IsBooster = true;

        public bool IsHit(Snake other)
        {
            Position head = GetHead();
            foreach (var part in other.Body)
                if (head.Equals(part)) return true;
            return false;
        }

        public void MoveMirror(Position target)
        {
            Position head = GetHead().Copy();
            if (head.X < target.X) SetDirection(Direction.Right);
            else if (head.X > target.X) SetDirection(Direction.Left);
            else if (head.Y < target.Y) SetDirection(Direction.Down);
            else if (head.Y > target.Y) SetDirection(Direction.Up);
            Move();
        }
    }
}
