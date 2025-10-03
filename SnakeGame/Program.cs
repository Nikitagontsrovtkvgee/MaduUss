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

            // Valiku raskusaste
            Console.WriteLine("Vali raskusaste: 1 - Easy, 2 - Medium, 3 - Hard");
            int difficulty = 2;
            string? input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input))
            {
                try
                {
                    difficulty = int.Parse(input);
                }
                catch
                {
                    difficulty = 2;
                }
            }

            int tick = 0;
            bool gameOver = false;
            Random random = new Random();

            // Mängija madu
            Snake player = new Snake(new Position(mapWidth / 2, mapHeight / 2), Direction.Right, 3)!;

            // Boonused
            List<Bonus> bonuses = new List<Bonus>();

            // Booster madu
            Snake? booster = null;
            int boosterDuration = 0;

            // Pommi objekt
            Bomb? bomb = null;

            while (!gameOver)
            {
                // Mängija juhtimine
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

                // Liikumine
                player.Move();

                if (player.CheckSelfCollision())
                {
                    gameOver = true;
                    break;
                }

                // Boonuste spawn (kiirem spaw)
                if (tick % 10 == 0)
                {
                    int x = random.Next(1, mapWidth - 1);
                    int y = random.Next(1, mapHeight - 1);

                    char symbol = (random.Next(0, 5) == 0) ? 'B' : '*'; // B = booster
                    bonuses.Add(new Bonus(new Position(x, y), symbol, 30));
                }

                foreach (var bonus in bonuses) bonus.Tick();
                bonuses.RemoveAll(b => b.IsExpired());

                // Boonuste korjamine
                foreach (var bonus in bonuses.ToArray())
                {
                    if (player.Body[0].Equals(bonus.Pos))
                    {
                        player.Grow();
                        bonuses.Remove(bonus);

                        if (bonus.Symbol == 'B') // aktiveerime booster
                        {
                            booster = new Snake(new Position(random.Next(2, mapWidth - 2),
                                                             random.Next(2, mapHeight - 2)), Direction.Right, 2)!;
                            booster.ActivateBooster();
                            boosterDuration = 30;

                            // Täht hoiatus
                            Console.SetCursorPosition(booster.Body[0].X, booster.Body[0].Y);
                            Console.Write("!");
                        }
                    }
                }

                // Booster liikumine
                if (booster != null && booster.IsBooster)
                {
                    booster.MoveMirror(player.CurrentDirection);
                    boosterDuration--;

                    Position head = booster.GetHead();
                    if (head.X <= 0 || head.X >= mapWidth - 1 || head.Y <= 0 || head.Y >= mapHeight - 1)
                    {
                        gameOver = true;
                        break;
                    }
                    if (booster.IsHit(player))
                    {
                        gameOver = true;
                        break;
                    }

                    if (boosterDuration <= 0) booster = null;
                }

                // Pommi spawn
                if (tick % 50 == 0 && bomb == null)
                {
                    bomb = new Bomb(random.Next(2, mapWidth - 2), random.Next(2, mapHeight - 2), 'B', difficulty)!;
                }

                if (bomb != null)
                {
                    bomb.Move(player, mapWidth, mapHeight);
                    if (bomb.IsHitSnake(player))
                    {
                        gameOver = true;
                        break;
                    }
                }

                // Joonistamine
                Console.Clear();

                // Piirid
                for (int x = 0; x < mapWidth; x++)
                {
                    Console.SetCursorPosition(x, 0); Console.Write("#");
                    Console.SetCursorPosition(x, mapHeight - 1); Console.Write("#");
                }
                for (int y = 0; y < mapHeight; y++)
                {
                    Console.SetCursorPosition(0, y); Console.Write("#");
                    Console.SetCursorPosition(mapWidth - 1, y); Console.Write("#");
                }

                // Mängija
                foreach (var part in player.Body)
                {
                    Console.SetCursorPosition(part.X, part.Y);
                    Console.Write("O");
                }

                // Booster
                if (booster != null)
                {
                    foreach (var part in booster.Body)
                    {
                        Console.SetCursorPosition(part.X, part.Y);
                        Console.Write("X");
                    }
                }

                // Boonused
                foreach (var bonus in bonuses)
                {
                    Console.SetCursorPosition(bonus.Pos.X, bonus.Pos.Y);
                    Console.Write(bonus.Symbol);
                }

                // Pommi kuvamine
                if (bomb != null)
                {
                    Position p = bomb.GetHead();
                    Console.SetCursorPosition(p.X, p.Y);
                    Console.Write('B');
                }

                // Punktid
                Console.SetCursorPosition(0, mapHeight);
                Console.Write($"Punkte: {player.Body.Count - 3}");

                Thread.Sleep(150);
                tick++;
            }

            // Mängu lõpp
            Console.Clear();
            Console.SetCursorPosition(mapWidth / 2 - 4, mapHeight / 2);
            Console.WriteLine("GAME OVER!");
            Console.SetCursorPosition(mapWidth / 2 - 8, mapHeight / 2 + 1);
            Console.WriteLine($"Sinu punktid: {player.Body.Count - 3}");

            string name = "";
            while (name.Length < 3)
            {
                Console.SetCursorPosition(mapWidth / 2 - 8, mapHeight / 2 + 2);
                Console.Write("Sisesta nimi (≥3 tähemärki): ");
                name = Console.ReadLine() ?? "";
            }

            ScoreManager scoreManager = new ScoreManager();
            scoreManager.SaveResult(name, player.Body.Count - 3);
            scoreManager.ShowResults(10);

            Console.ReadKey();
        }
    }
}