using System;
using System.Collections.Generic;
using System.IO;

namespace SnakeGame
{
    public class ScoreManager
    {
        private readonly string _scoreFilePath;
        private readonly List<(string Player, int Score)> _scores = new();

        public ScoreManager(string filePath = "scores.txt")
        {
            _scoreFilePath = filePath;
            LoadResults();
        }

        /// <summary>
        /// Сохранить результат игрока в файл.
        /// </summary>
        public void SaveResult(string playerName, int score)
        {
            _scores.Add((playerName, score));
            try
            {
                using StreamWriter writer = new StreamWriter(_scoreFilePath, append: true);
                writer.WriteLine($"{playerName}:{score}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при сохранении счёта: {ex.Message}");
            }
        }

        /// <summary>
        /// Загрузить результаты из файла.
        /// </summary>
        private void LoadResults()
        {
            if (!File.Exists(_scoreFilePath))
                return;

            try
            {
                foreach (var line in File.ReadAllLines(_scoreFilePath))
                {
                    var parts = line.Split(':');
                    if (parts.Length == 2 && int.TryParse(parts[1], out int score))
                    {
                        _scores.Add((parts[0], score));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при загрузке счёта: {ex.Message}");
            }
        }

        /// <summary>
        /// Отобразить результаты игроков.
        /// </summary>
        public void ShowResults()
        {
            Console.Clear();
            Console.WriteLine("=== Таблица результатов ===\n");

            if (_scores.Count == 0)
            {
                Console.WriteLine("Пока нет сохранённых результатов.");
            }
            else
            {
                int rank = 1;
                foreach (var (player, score) in _scores)
                {
                    Console.WriteLine($"{rank}. {player} — {score}");
                    rank++;
                }
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey(true);
        }
    }
}
