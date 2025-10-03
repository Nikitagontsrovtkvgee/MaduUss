using System.Collections.Generic;

namespace SnakeGame
{
    // Madu klass
    public class Snake
    {
        public List<Position> Body { get; private set; }
        public Direction CurrentDirection { get; private set; }
        public bool IsBooster { get; private set; }

        public Snake(Position start, Direction dir, int length)
        {
            Body = new List<Position>();
            for (int i = 0; i < length; i++)
            {
                Body.Add(new Position(start.X - i, start.Y));
            }
            CurrentDirection = dir;
            IsBooster = false;
        }

        public void SetDirection(Direction dir)
        {
            CurrentDirection = dir;
        }

        public void Move()
        {
            Position head = GetHead();
            Position newHead = dirToPosition(head, CurrentDirection);
            Body.Insert(0, newHead);
            Body.RemoveAt(Body.Count - 1);
        }

        private Position dirToPosition(Position head, Direction dir)
        {
            switch (dir)
            {
                case Direction.Up: return new Position(head.X, head.Y - 1);
                case Direction.Down: return new Position(head.X, head.Y + 1);
                case Direction.Left: return new Position(head.X - 1, head.Y);
                case Direction.Right: return new Position(head.X + 1, head.Y);
                default: return head;
            }
        }

        public void MoveMirror(Direction playerDir)
        {
            // Liigub peeglisuunas mängija suhtes
            Direction mirrored = playerDir switch
            {
                Direction.Up => Direction.Down,
                Direction.Down => Direction.Up,
                Direction.Left => Direction.Right,
                Direction.Right => Direction.Left,
                _ => playerDir
            };
            SetDirection(mirrored);
            Move();
        }

        public Position GetHead()
        {
            return Body[0];
        }

        public bool CheckSelfCollision()
        {
            Position head = GetHead();
            for (int i = 1; i < Body.Count; i++)
            {
                if (head.Equals(Body[i])) return true;
            }
            return false;
        }

        public void Grow()
        {
            Position tail = Body[Body.Count - 1];
            Body.Add(new Position(tail.X, tail.Y));
        }

        public void ActivateBooster()
        {
            IsBooster = true;
        }

        public bool IsHit(Snake other)
        {
            foreach (var part in other.Body)
            {
                if (GetHead().Equals(part)) return true;
            }
            return false;
        }
    }
}
