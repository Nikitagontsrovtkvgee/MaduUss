using System.Media;

namespace Snake
{
    class SoundManager
    {
        SoundPlayer background = new SoundPlayer();

        public void PlayBackground(string file)
        {
            background.SoundLocation = file;
            background.PlayLooping();
        }

        public void StopBackground()
        {
            background.Stop();
        }

        public void PlayEffect(string file)
        {
            SoundPlayer effect = new SoundPlayer(file);
            effect.Play();
        }
    }
}