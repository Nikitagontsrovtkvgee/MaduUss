using System;

namespace SnakeGame
{
    // Menüü klass
    public static class Menu
    {
        public static void Show()
        {
            Console.Clear();
            Console.WriteLine("=== Madu Mäng ===");
            Console.WriteLine("1. Mängi");
            Console.WriteLine("2. Punktid");
            Console.WriteLine("3. Legend (boosterid ja tähendused)");
            Console.WriteLine("4. Välju");
        }

        public static void ShowLegend()
        {
            Console.Clear();
            Console.WriteLine("=== Boosterite Legend ===");
            Console.WriteLine("* - Tavaline õun");
            Console.WriteLine("B - Booster madu");
            Console.WriteLine("F - Pommi freeze booster");
            Console.WriteLine("D - Topelt punktid");
            Console.WriteLine("M - Magnet");
            Console.WriteLine("C - Lõigatud saba");
            Console.WriteLine("Tagasi menüüsse vajuta Enter");
            Console.ReadKey();
        }
    }
}
