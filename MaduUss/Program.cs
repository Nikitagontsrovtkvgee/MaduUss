using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static void Main()
    {
        int mapWidth = 40;
        int mapHeight = 20;
        Snake snake1 = new Snake(10, 10);
        Snake snake2 = new Snake(5, 5) { IsActive = false }; // появляется только после бонуса

        List<Bonus> bonuses = new List<Bonus>();
        List<Enemy> enemies = new List<Enemy>();
        List<Wall> walls = new List<Wall>();

        bool gameOver = false;
        Random rnd = new Random();

        while (!gameOver)
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow: snake1.ChangeDirection(Direction.Up); break;
                    case ConsoleKey.DownArrow: snake1.ChangeDirection(Direction.Down); break;
                    case ConsoleKey.LeftArrow: snake1.ChangeDirection(Direction.Left); break;
                    case ConsoleKey.RightArrow: snake1.ChangeDirection(Direction.Right); break;

                    case ConsoleKey.W: snake2.ChangeDirection(Direction.Up); break;
                    case ConsoleKey.S: snake2.ChangeDirection(Direction.Down); break;
                    case ConsoleKey.A: snake2.ChangeDirection(Direction.Left); break;
                    case ConsoleKey.D: snake2.ChangeDirection(Direction.Right); break;
                }
            }

            // Спавн бонусов
            if (rnd.Next(0, 20) == 0)
            {
                bool spawnSecond = rnd.Next(0, 5) == 0; // шанс 1 к 5
                bonuses.Add(new Bonus(rnd.Next(0, mapWidth), rnd.Next(0, mapHeight), 10, spawnSecond));
            }

            // Спавн врагов
            if (rnd.Next(0, 50) == 0)
                enemies.Add(new Enemy(rnd.Next(0, mapWidth), rnd.Next(0, mapHeight)));

            // Спавн стен
            if (rnd.Next(0, 50) == 0)
                walls.Add(new Wall(rnd.Next(0, mapWidth), rnd.Next(0, mapHeight), 5));

            // Очистка бонусов и стен
            for (int i = bonuses.Count - 1; i >= 0; i--)
            {
                bonuses[i].Duration--;
                if (bonuses[i].Duration <= 0)
                {
                    bonuses[i].Clear();
                    bonuses.RemoveAt(i);
                }
            }

            for (int i = walls.Count - 1; i >= 0; i--)
            {
                walls[i].Duration--;
                if (walls[i].Duration <= 0)
                {
                    walls[i].Clear();
                    walls.RemoveAt(i);
                }
            }

            // Движение змей
            snake1.Move();
            snake2.Move();

            // Проверка столкновений с бонусами
            for (int i = bonuses.Count - 1; i >= 0; i--)
            {
                if ((snake1.Head.X == bonuses[i].X && snake1.Head.Y == bonuses[i].Y))
                {
                    snake1.Grow();
                    if (bonuses[i].IsSpawnSecondSnake) snake2.IsActive = true;
                    bonuses[i].Clear();
                    bonuses.RemoveAt(i);
                }
                else if (snake2.IsActive && snake2.Head.X == bonuses[i].X && snake2.Head.Y == bonuses[i].Y)
                {
                    snake2.Grow();
                    bonuses[i].Clear();
                    bonuses.RemoveAt(i);
                }
            }

            // Отрисовка
            Console.Clear();
            snake1.Draw();
            snake2.Draw();
            foreach (var b in bonuses) b.Draw();
            foreach (var e in enemies) e.Draw();
            foreach (var w in walls) w.Draw();

            // Проверка столкновений
            gameOver = snake1.CheckCollision(mapWidth, mapHeight, enemies, walls, snake2) ||
                       snake2.CheckCollision(mapWidth, mapHeight, enemies, walls, snake1);

            Thread.Sleep(200);
        }

        Console.SetCursorPosition(0, mapHeight + 1);
        Console.WriteLine("Game Over!");
    }
}