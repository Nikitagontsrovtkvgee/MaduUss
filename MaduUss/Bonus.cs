using System;
using System.Collections.Generic;

namespace SnakeGame
{
    // Класс бонуса
    public class Bonus
    {
        public Position Pos { get; private set; }
        public char Symbol { get; private set; }
        public int Duration { get; private set; } // Время жизни бонуса в тиках

        public Bonus(Position pos, char symbol, int duration)
        {
            Pos = pos;
            Symbol = symbol;
            Duration = duration;
        }

        // Уменьшение времени жизни
        public void Tick()
        {
            Duration--;
        }

        public bool IsExpired()
        {
            return Duration <= 0;
        }
    }

}