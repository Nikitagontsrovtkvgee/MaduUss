namespace SnakeGame
{
    // Boonus, mis ilmub kaardile
    public class Bonus
    {
        public Position Pos { get; private set; }
        public char Symbol { get; private set; }
        private int duration;

        public Bonus(Position pos, char symbol, int duration)
        {
            Pos = pos;
            Symbol = symbol;
            this.duration = duration;
        }

        // Igat liikumise tsüklit vähendame
        public void Tick()
        {
            duration--;
        }

        public bool IsExpired() => duration <= 0;
    }
}
