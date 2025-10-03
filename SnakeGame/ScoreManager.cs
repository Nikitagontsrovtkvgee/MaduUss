using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SnakeGame
{
    // Punktide haldur
    public class ScoreManager
    {
        private const string FileName = "Scores.txt";

        public void SaveResult(string name, int score)
        {
            using StreamWriter sw = new StreamWriter(FileName, true);
            sw.WriteLine($"{name}:{score}");
        }

        public void ShowResults(int topN)
        {
            if (!File.Exists(FileName)) return;

            var scores = new List<(string, int)>();
            foreach (var line in File.ReadAllLines(FileName))
            {
                var parts = line.Split(':');
                if (parts.Length == 2 && int.TryParse(parts[1], out int val))
                {
                    scores.Add((parts[0], val));
                }
            }

            foreach (var s in scores.OrderByDescending(x => x.Item2).Take(topN))
            {
                Console.WriteLine($"{s.Item1}: {s.Item2}");
            }
        }
    }
}
