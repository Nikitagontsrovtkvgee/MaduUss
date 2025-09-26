using System;

namespace Snake
{
    class BackgroundManager
    {
        private ConsoleColor[] bgColors = new ConsoleColor[]
        {
            ConsoleColor.Black,
            ConsoleColor.DarkBlue,
            ConsoleColor.DarkGreen,
            ConsoleColor.DarkRed,
            ConsoleColor.DarkMagenta,
            ConsoleColor.DarkCyan
        };

        private ConsoleColor[] fgColors = new ConsoleColor[]
        {
            ConsoleColor.White,
            ConsoleColor.Yellow,
            ConsoleColor.Cyan,
            ConsoleColor.Green,
            ConsoleColor.Red
        };

        private Random rnd = new Random();

        public void RandomTheme()
        {
            Console.BackgroundColor = bgColors[rnd.Next(bgColors.Length)];
            Console.ForegroundColor = fgColors[rnd.Next(fgColors.Length)];
            Console.Clear();
        }
    }
}