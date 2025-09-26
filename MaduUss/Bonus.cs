using System;

namespace Snake
{
    class Bonus : Point
    {
        public int Duration; // тики жизни бонуса
        public Action<Snake> Effect;

        public Bonus(int x, int y, char sym, int duration, Action<Snake> effect) : base(x, y, sym)
        {
            Duration = duration;
            Effect = effect;
        }

        public void Apply(Snake snake)
        {
            Effect?.Invoke(snake);
        }
    }
}