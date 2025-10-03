using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SnakeGame
{
    public class ScoreManager
    {
        private const string fileName = "scores.txt";

        public void SaveResult(string name, int points)
        {
            File.AppendAllText(fileName, $"{name}:{points}\n");
        }

        public void ShowResults(int top)
        {
            if (!File.Exists(fileName)) return;

            var lines = File.ReadAllLines(fileName);
            var scores = new List<(string, int)>();

            foreach (var line in lines)
            {
                var parts = line.Split(':');
                if (parts.Length == 2 && int.TryParse(parts[1], out int pts))
                    scores.Add((parts[0], pts));
            }

            var topScores = scores.OrderByDescending(s => s.Item2).Take(top);
            Console.WriteLine("== Tabel ==");
            foreach (var s in topScores)
                Console.WriteLine($"{s.Item1} - {s.Item2}");
        }
    }
}
