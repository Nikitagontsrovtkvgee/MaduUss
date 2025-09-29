using System;
using System.Collections.Generic;

public class Snake
{
    private List<(int X, int Y)> body;
    public (int X, int Y) Head => body[0];
    public Direction CurrentDirection { get; private set; } = Direction.Right;
    public bool IsActive { get; set; } = true;

    public Snake(int startX, int startY)
    {
        body = new List<(int X, int Y)>();
        body.Add((startX, startY));
    }

    public void Move()
    {
        if (!IsActive) return;

        var newHead = Head;
        switch (CurrentDirection)
        {
            case Direction.Up: newHead.Y--; break;
            case Direction.Down: newHead.Y++; break;
            case Direction.Left: newHead.X--; break;
            case Direction.Right: newHead.X++; break;
        }

        body.Insert(0, newHead);
        body.RemoveAt(body.Count - 1);
    }

    public void Grow() => body.Add(body[body.Count - 1]);

    public void ChangeDirection(Direction newDir)
    {
        if ((CurrentDirection == Direction.Up && newDir == Direction.Down) ||
            (CurrentDirection == Direction.Down && newDir == Direction.Up) ||
            (CurrentDirection == Direction.Left && newDir == Direction.Right) ||
            (CurrentDirection == Direction.Right && newDir == Direction.Left))
            return;

        CurrentDirection = newDir;
    }

    public bool CheckCollision(int mapWidth, int mapHeight, List<Enemy> enemies, List<Wall> walls, Snake otherSnake = null)
    {
        if (!IsActive) return false;

        if (Head.X < 0 || Head.X >= mapWidth || Head.Y < 0 || Head.Y >= mapHeight)
            return true;

        for (int i = 1; i < body.Count; i++)
            if (Head.X == body[i].X && Head.Y == body[i].Y)
                return true;

        if (otherSnake != null && otherSnake.IsActive)
            foreach (var part in otherSnake.body)
                if (Head.X == part.X && Head.Y == part.Y)
                    return true;

        foreach (var e in enemies)
            if (Head.X == e.X && Head.Y == e.Y)
                return true;

        foreach (var w in walls)
            if (Head.X == w.X && Head.Y == w.Y)
                return true;

        return false;
    }

    public void Draw()
    {
        if (!IsActive) return;

        foreach (var part in body)
        {
            Console.SetCursorPosition(part.X, part.Y);
            Console.Write('O');
        }
    }
}