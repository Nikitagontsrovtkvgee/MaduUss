using System;

namespace SnakeGame
{
    public static class Menu
    {
        public static int ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("=== MÄNGU MENÜÜ ===");
            Console.WriteLine("1 - Alusta mängu");
            Console.WriteLine("2 - Näita tabeleid");
            Console.WriteLine("3 - Lõpeta");
            Console.WriteLine("4 - Legend (boonused)");

            int choice = 1;
            try { choice = int.Parse(Console.ReadLine() ?? "1"); } catch { choice = 1; }
            return choice;
        }

        public static void ShowLegend()
        {
            Console.Clear();
            Console.WriteLine("=== LEGEND (Boonused) ===");
            Console.WriteLine("B - Booster (aktiviseerib täiendava madu)");
            Console.WriteLine("* - Tavaline toidupunkt");
            Console.WriteLine("X - Booster madu keha");
            Console.WriteLine("! - Booster madu pea");
            Console.WriteLine("B (pommi puhul) - Bomb");
            Console.WriteLine("\nVajuta suvalist klahvi tagasi minemiseks.");
            Console.ReadKey();
        }
    }
}
