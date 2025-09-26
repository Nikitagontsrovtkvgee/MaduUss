using System;
using System.IO;
using System.Linq;

namespace Snake
{
    class ScoreManager
    {
        private string fileName = "results.txt";

        public void SaveResult(string playerName, int score)
        {
            File.AppendAllLines(fileName, new[] { $"{playerName};{score}" });
        }

        public void ShowResults(int topN = 10)
        {
            if (!File.Exists(fileName))
            {
                Console.WriteLine("Результатов пока нет.");
                return;
            }

            var results = File.ReadAllLines(fileName)
                .Select(line => line.Split(';'))
                .Where(parts => parts.Length == 2)
                .Select(parts => new { Name = parts[0], Score = int.Parse(parts[1]) })
                .OrderByDescending(r => r.Score)
                .Take(topN);

            Console.WriteLine("\n--- Таблица рекордов ---");
            foreach (var r in results)
            {
                Console.WriteLine($"{r.Name,-15} {r.Score}");
            }
        }
    }
}