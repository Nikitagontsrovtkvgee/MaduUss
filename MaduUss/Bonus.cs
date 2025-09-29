using System;

public class Bonus
{
    public int X { get; set; }
    public int Y { get; set; }
    public char Symbol { get; set; } = 'B';
    public int Duration { get; set; }
    public bool IsSpawnSecondSnake { get; set; } = false; // для бонуса, который вызывает вторую змейку

    public Bonus(int x, int y, int duration = 10, bool spawnSecond = false)
    {
        X = x;
        Y = y;
        Duration = duration;
        IsSpawnSecondSnake = spawnSecond;
    }

    public void Draw()
    {
        Console.SetCursorPosition(X, Y);
        Console.Write(Symbol);
    }

    public void Clear()
    {
        Console.SetCursorPosition(X, Y);
        Console.Write(' ');
    }
}