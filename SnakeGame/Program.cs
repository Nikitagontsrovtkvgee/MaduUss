using System;

namespace SnakeGame
{
    class Program
    {
        static void Main()
        {
            GameManager gameManager = new GameManager(40, 20); // laiuse ja kõrguse seadistus
            gameManager.RunGame();
        }
    }
}
