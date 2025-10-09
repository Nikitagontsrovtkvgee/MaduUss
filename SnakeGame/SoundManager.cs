using System;
using System.Media;

namespace SnakeGame
{
    public class SoundManager
    {
        private readonly SoundPlayer _eatSound;
        private readonly SoundPlayer _gameOverSound;

        public SoundManager()
        {
            // Укажи свои пути, если файлы находятся в другой папке:
            _eatSound = new SoundPlayer("eat.wav");
            _gameOverSound = new SoundPlayer("gameover.wav");
        }

        /// <summary>
        /// Воспроизвести звук, когда змейка ест еду.
        /// </summary>
        public void PlayEatSound()
        {
            try
            {
                _eatSound.Play();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка воспроизведения звука еды: {ex.Message}");
            }
        }

        /// <summary>
        /// Воспроизвести звук при проигрыше.
        /// </summary>
        public void PlayGameOverSound()
        {
            try
            {
                _gameOverSound.Play();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка воспроизведения звука окончания игры: {ex.Message}");
            }
        }
    }
}
