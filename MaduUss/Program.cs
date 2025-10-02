using System;
using System.Collections.Generic;
using System.Threading;

namespace SnakeGame
{
    class Program
    {
        static void Main()
        {
            Console.CursorVisible = false;

            int mapWidth = 40;
            int mapHeight = 20;

            Snake player = new Snake(new Position(mapWidth / 2, mapHeight / 2), Direction.Right, 3);

            List<Bonus> bonuses = new List<Bonus>();
            Random random = new Random();

            int tick = 0;
            bool gameOver = false;

            while (!gameOver)
            {
                // === 1. Управление ===
                if (Console.KeyAvailable)
                {
                    ConsoleKey key = Console.ReadKey(true).Key;
                    switch (key)
                    {
                        case ConsoleKey.UpArrow: player.SetDirection(Direction.Up); break;
                        case ConsoleKey.DownArrow: player.SetDirection(Direction.Down); break;
                        case ConsoleKey.LeftArrow: player.SetDirection(Direction.Left); break;
                        case ConsoleKey.RightArrow: player.SetDirection(Direction.Right); break;
                    }
                }

                // === 2. Двигаем змейку ===
                player.Move();

                // Проверка столкновения с самим собой
                if (player.CheckSelfCollision())
                {
                    gameOver = true;
                    break;
                }

                // === 3. Спавн бонусов с задержкой ===
                if (tick % 20 == 0) // каждые 20 тиков
                {
                    int x = random.Next(1, mapWidth - 1);
                    int y = random.Next(1, mapHeight - 1);
                    bonuses.Add(new Bonus(new Position(x, y), '*', 30)); // бонус живет 30 тиков
                }

                // Убираем истекшие бонусы
                bonuses.RemoveAll(b => b.IsExpired());

                foreach (var bonus in bonuses)
                    bonus.Tick();

                // === 4. Проверка на съеденный бонус ===
                foreach (var bonus in bonuses.ToArray())
                {
                    if (player.Body[0].Equals(bonus.Pos))
                    {
                        player.Grow();
                        bonuses.Remove(bonus);
                    }
                }

                // === 5. Отрисовка ===
                Console.Clear();

                // Рисуем границы
                for (int x = 0; x < mapWidth; x++)
                {
                    Console.SetCursorPosition(x, 0);
                    Console.Write("#");
                    Console.SetCursorPosition(x, mapHeight - 1);
                    Console.Write("#");
                }
                for (int y = 0; y < mapHeight; y++)
                {
                    Console.SetCursorPosition(0, y);
                    Console.Write("#");
                    Console.SetCursorPosition(mapWidth - 1, y);
                    Console.Write("#");
                }

                // Рисуем змейку
                foreach (var part in player.Body)
                {
                    Console.SetCursorPosition(part.X, part.Y);
                    Console.Write("O");
                }

                // Рисуем бонусы
                foreach (var bonus in bonuses)
                {
                    Console.SetCursorPosition(bonus.Pos.X, bonus.Pos.Y);
                    Console.Write(bonus.Symbol);
                }

                // === 6. Задержка игры ===
                Thread.Sleep(150);
                tick++;
            }

            // === Конец игры ===
            Console.Clear();
            Console.SetCursorPosition(mapWidth / 2 - 4, mapHeight / 2);
            Console.WriteLine("GAME OVER!");
            Console.ReadKey();
        }
    }
}