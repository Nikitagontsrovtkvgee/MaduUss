using System;

namespace SnakeGame
{
    // Taustahaldur (värvid, eriefektid)
    public static class BackgroundManager
    {
        public static void ClearScreen()
        {
            Console.Clear();
        }

        public static void SetBackground(ConsoleColor color)
        {
            Console.BackgroundColor = color;
            Console.Clear();
        }
    }
}
