namespace SnakeGame
{
    public class Bonus
    {
        public Position Pos { get; private set; }
        public char Symbol { get; private set; }
        private int duration;

        public Bonus(Position pos, char sym, int time)
        {
            Pos = pos;
            Symbol = sym;
            duration = time;
        }

        public void Tick() => duration--;
        public bool IsExpired() => duration <= 0;
    }
}
