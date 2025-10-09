using System;
using System.Collections.Generic;
using System.Threading;

namespace SnakeGame
{
    public class GameManager
    {
        private int mapWidth;
        private int mapHeight;
        private Snake player;
        private Snake booster;
        private int boosterDuration;
        private Bomb bomb;
        private List<Bonus> bonuses;
        private Random random;
        private ScoreManager scoreManager;
        private SoundManager soundManager;

        public GameManager(int width, int height)
        {
            mapWidth = width;
            mapHeight = height;
            random = new Random();
            bonuses = new List<Bonus>();
            booster = null;
            scoreManager = new ScoreManager();
            soundManager = new SoundManager();
        }

        public void RunGame()
        {
            Console.CursorVisible = false;
            int tick = 0;
            bool gameOver = false;

            Console.WriteLine("Vali raskusaste: 1 - Easy, 2 - Medium, 3 - Hard");
            int difficulty = 2;
            try { difficulty = int.Parse(Console.ReadLine() ?? "2"); } catch { difficulty = 2; }

            player = new Snake(new Position(mapWidth / 2, mapHeight / 2), Direction.Right, 3);
            soundManager.PlayStart();

            while (!gameOver)
            {
                HandleInput();
                player.Move();

                if (player.CheckSelfCollision() || player.CheckWallCollision(mapWidth, mapHeight))
                {
                    soundManager.PlayGameOver();
                    gameOver = true;
                }

                SpawnBonuses(tick);
                UpdateBonuses();

                CheckBonusCollision();

                MoveBooster();

                SpawnBomb(difficulty);
                MoveBomb();

                Draw();

                Thread.Sleep(150);
                tick++;
            }

            EndGame();
        }

        private void HandleInput()
        {
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
        }

        private void SpawnBonuses(int tick)
        {
            if (tick % 10 == 0)
            {
                int x = random.Next(1, mapWidth - 1);
                int y = random.Next(1, mapHeight - 1);
                char symbol = (random.Next(0, 5) == 0) ? 'B' : '*';
                bonuses.Add(new Bonus(new Position(x, y), symbol, 30));
            }
        }

        private void UpdateBonuses()
        {
            foreach (var bonus in bonuses) bonus.Tick();
            bonuses.RemoveAll(b => b.IsExpired());
        }

        private void CheckBonusCollision()
        {
            foreach (var bonus in bonuses.ToArray())
            {
                if (player.Body[0].Equals(bonus.Pos))
                {
                    player.Grow();
                    bonuses.Remove(bonus);
                    soundManager.PlayBonus();

                    if (bonus.Symbol == 'B')
                    {
                        booster = new Snake(
                            new Position(random.Next(2, mapWidth - 2),
                                         random.Next(2, mapHeight - 2)),
                            Direction.Right, 2);

                        booster.ActivateBooster();
                        boosterDuration = 30;

                        soundManager.PlayBooster();

                        Console.SetCursorPosition(booster.Body[0].X, booster.Body[0].Y);
                        Console.Write("!");
                    }
                }
            }
        }

        private void MoveBooster()
        {
            if (booster != null && booster.IsBooster)
            {
                booster.MoveMirror(player.Body[0]);
                boosterDuration--;

                if (booster.CheckWallCollision(mapWidth, mapHeight) || booster.IsHit(player))
                    booster = null;

                if (boosterDuration <= 0)
                    booster = null;
            }
        }

        private void SpawnBomb(int difficulty)
        {
            if (bomb == null && random.Next(0, 50) == 0)
            {
                bomb = new Bomb(random.Next(2, mapWidth - 2), random.Next(2, mapHeight - 2), 'X', difficulty);
                soundManager.PlayBombSpawn();
            }
        }

        private void MoveBomb()
        {
            if (bomb != null)
            {
                bomb.Move(player, mapWidth, mapHeight);
                if (bomb.IsHitSnake(player))
                {
                    soundManager.PlayExplosion();
                    bomb = null;
                }
            }
        }

        private void Draw()
        {
            Console.Clear();

            // piirid
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

            // mängija
            foreach (var part in player.Body)
            {
                Console.SetCursorPosition(part.X, part.Y);
                Console.Write("O");
            }

            // booster
            if (booster != null)
            {
                foreach (var part in booster.Body)
                {
                    Console.SetCursorPosition(part.X, part.Y);
                    Console.Write("X");
                }
            }

            // boonused
            foreach (var bonus in bonuses)
            {
                Console.SetCursorPosition(bonus.Pos.X, bonus.Pos.Y);
                Console.Write(bonus.Symbol);
            }

            // pomm
            if (bomb != null)
            {
                var p = bomb.GetHead();
                Console.SetCursorPosition(p.X, p.Y);
                Console.Write(bomb.Symbol);
            }

            // punktid
            Console.SetCursorPosition(0, mapHeight);
            Console.Write($"Punkte: {player.Body.Count - 3}");
        }

        private void EndGame()
        {
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

            int score = player.Body.Count - 3;
            scoreManager.SaveResult(name, score);
            scoreManager.ShowResults(10);

            soundManager.PlayEnd();

            Console.ReadKey();
        }
    }
}
