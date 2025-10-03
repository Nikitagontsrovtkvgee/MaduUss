using System;

namespace SnakeGame
{
    public class FoodCreator
    {
        private int mapWidth;
        private int mapHeight;
        private char sym;
        private Random random = new Random();

        public FoodCreator(int mapWidth, int mapHeight, char sym)
        {
            this.mapWidth = mapWidth;
            this.mapHeight = mapHeight;
            this.sym = sym;
        }

        public Position CreateFood()
        {
            int x = random.Next(1, mapWidth - 1);
            int y = random.Next(1, mapHeight - 1);
            return new Position(x, y);
        }

        public char Symbol() => sym;
    }
}
