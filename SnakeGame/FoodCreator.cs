using System;

namespace SnakeGame
{
    // Toidu (õun) generaator
    public class FoodCreator
    {
        private int mapWidth;
        private int mapHeight;
        private char symbol;
        private Random random;

        public FoodCreator(int width, int height, char sym)
        {
            mapWidth = width;
            mapHeight = height;
            symbol = sym;
            random = new Random();
        }

        public Position CreateFood()
        {
            int x = random.Next(1, mapWidth - 1);
            int y = random.Next(1, mapHeight - 1);
            return new Position(x, y);
        }

        public char GetSymbol()
        {
            return symbol;
        }
    }
}
