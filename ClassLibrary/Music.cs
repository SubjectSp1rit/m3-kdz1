using WMPLib;

namespace ClassLibrary
{
    public class Music
    {
        private WindowsMediaPlayer player;

        public Music()
        {
            player = new WindowsMediaPlayer();
        }

        public void PlayMusic(string path)
        {
            player.URL = path;
            player.controls.play();
            // Зацикливание музыки
            player.settings.setMode("loop", true);
        }

        public void StopMusic()
        {
            player.controls.stop();
        }
    }
}
