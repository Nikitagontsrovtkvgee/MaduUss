namespace SnakeGame
{
    public class Bomb
    {
        private Position pos;
        public char Symbol { get; private set; }
        private int difficulty;

        public Bomb(int x, int y, char symbol, int diff)
        {
            pos = new Position(x, y);
            Symbol = symbol;
            difficulty = diff;
        }

        public Position GetHead() => pos;

        public void Move(Snake player, int width, int height)
        {
            // Простое хаотичное движение в пределах карты
            switch (new System.Random().Next(4))
            {
                case 0: if (pos.X + 1 < width - 1) pos.X++; break;
                case 1: if (pos.X - 1 > 0) pos.X--; break;
                case 2: if (pos.Y + 1 < height - 1) pos.Y++; break;
                case 3: if (pos.Y - 1 > 0) pos.Y--; break;
            }
        }

        public bool IsHitSnake(Snake player)
        {
            return pos.Equals(player.GetHead());
        }
    }
}
