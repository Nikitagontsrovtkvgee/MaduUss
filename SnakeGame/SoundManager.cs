using System.Media;

namespace SnakeGame
{
    // Heli mängija klass
    public class SoundManager
    {
        private SoundPlayer eatPlayer;
        private SoundPlayer gameOverPlayer;

        public SoundManager()
        {
            eatPlayer = new SoundPlayer("eat.wav");
            gameOverPlayer = new SoundPlayer("gameover.wav");
        }

        public void PlayEat()
        {
            eatPlayer.Play();
        }

        public void PlayGameOver()
        {
            gameOverPlayer.Play();
        }
    }
}
