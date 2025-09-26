using Snake;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = 80;
            int height = 27;
            int score = 0;

            Console.SetWindowSize(width, height);
            Console.SetBufferSize(width, height);

            // Менеджеры
            SoundManager sounds = new SoundManager();
            BackgroundManager bg = new BackgroundManager();
            ScoreManager scoreManager = new ScoreManager();

            sounds.PlayBackground("Resources/background.wav");

            Walls walls = new Walls(width, height - 2);
            walls.Draw();

            Point p1 = new Point(4, 5, '*');
            Snake snake = new Snake(p1, 4, Direction.RIGHT);
            snake.Draw();

            Point p2 = new Point(10, 10, '#');
            Snake2 snake2 = new Snake2(p2, 4, Direction.LEFT);
            snake2.Draw();

            FoodCreator foodCreator = new FoodCreator(width, height - 2, '$');
            Point food = foodCreator.CreateFood();
            food.Draw();

            List<Bomb> bombs = new List<Bomb>();
            List<Bonus> bonuses = new List<Bonus>();
            Random rnd = new Random();
            int tick = 0;

            while (true)
            {
                tick++;

                // Движение змейки
                snake.Move();
                snake2.Move();

                // Проверка еды
                if (snake.Eat(food) || snake2.Eat(food))
                {
                    sounds.PlayEffect("Resources/eat.wav");
                    score += 10;
                    food = foodCreator.CreateFood();
                    food.Draw();

                    // Генерация бонуса
                    if (rnd.Next(0, 100) < 20)
                    {
                        int bx = rnd.Next(2, width - 2);
                        int by = rnd.Next(2, height - 2);
                        Bonus bonus = new Bonus(bx, by, 'B', 50, s => { }); // можно добавить реальные эффекты
                        bonuses.Add(bonus);
                        bonus.Draw();
                    }

                    // Генерация бомбардиров
                    if (rnd.Next(0, 100) < 10)
                    {
                        int bx = rnd.Next(2, width - 2);
                        int by = rnd.Next(2, height - 2);
                        Bomb bomb = new Bomb(bx, by, 'X');
                        bombs.Add(bomb);
                        bomb.Draw();
                    }
                }

                // Движение бомбардиров
                foreach (var bomb in bombs)
                {
                    bomb.MoveTowards(snake);
                    bomb.MoveTowards(snake2);

                    if (bomb.IsHitSnake(snake) || bomb.IsHitSnake(snake2))
                        goto GameOver;
                }

                // Таймер бонусов
                for (int i = bonuses.Count - 1; i >= 0; i--)
                {
                    bonuses[i].Duration--;
                    if (bonuses[i].Duration <= 0)
                    {
                        bonuses[i].Clear();
                        bonuses.RemoveAt(i);
                    }
                }

                // Смена фона каждые 20 тиков
                if (tick % 20 == 0)
                    bg.RandomTheme();

                // Проверка столкновений со стенами и хвостом
                if (walls.IsHit(snake) || snake.IsHitTail() || walls.IsHit(snake2) || snake2.IsHitTail())
                    break;

                // Управление клавишами
                if (Console.KeyAvailable)
                {
                    ConsoleKey key = Console.ReadKey(true).Key;
                    snake.HandleKey(key);
                    snake2.HandleKey2(key);
                }

                // Скорость змейки
                int speed = 100;
                if (score >= 50) speed = 80;
                if (score >= 100) speed = 60;
                Thread.Sleep(speed);
            }

        GameOver:
            sounds.StopBackground();
            sounds.PlayEffect("Resources/gameover.wav");

            WriteGameOver();

            string playerName = "";
            while (playerName.Length < 3)
            {
                try
                {
                    Console.Write("Введите имя игрока (мин 3 символа): ");
                    playerName = Console.ReadLine();
                }
                catch { }
            }

            scoreManager.SaveResult(playerName, score);

            Console.Clear();
            scoreManager.ShowResults();
            Console.ReadLine();
        }

        static void WriteGameOver()
        {
            int xOffset = 25;
            int yOffset = 8;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(xOffset, yOffset++);
            Console.WriteLine("============================");
            Console.SetCursorPosition(xOffset + 1, yOffset++);
            Console.WriteLine("И Г Р А    О К О Н Ч Е Н А");
            yOffset++;
            Console.SetCursorPosition(xOffset + 2, yOffset++);
            Console.WriteLine("Автор: DARK LORD");
            Console.SetCursorPosition(xOffset + 1, yOffset++);
            Console.WriteLine("Специально для сервера жески майнкрафтеры");
            Console.SetCursorPosition(xOffset, yOffset++);
            Console.WriteLine("============================");
        }
    }
}