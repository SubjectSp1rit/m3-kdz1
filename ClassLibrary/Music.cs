using WMPLib;

namespace ClassLibrary
{
    /// <summary>
    /// Отвечает за музыку
    /// </summary>
    public class Music
    {
        private WindowsMediaPlayer player;

        public Music()
        {
            player = new WindowsMediaPlayer();
        }

        /// <summary>
        /// Запуск музыки по переданному пути
        /// </summary>
        /// <param name="path">путь до песни</param>
        public void PlayMusic(string path)
        {
            player.URL = path;
            player.controls.play();
            // Зацикливание музыки
            player.settings.setMode("loop", true);
        }

        /// <summary>
        /// Приостановка воспроизведения музыки
        /// </summary>
        public void StopMusic()
        {
            player.controls.stop();
        }
    }
}
