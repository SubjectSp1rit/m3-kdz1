using WMPLib;

namespace ClassLibrary
{
    /// <summary>
    /// Отвечает за музыку
    /// </summary>
    public class Music
    {
        private WindowsMediaPlayer player;
        private string songPath = @"song1.m4a";

        public Music()
        {
            player = new WindowsMediaPlayer();
        }

        /// <summary>
        /// Запуск музыки по переданному пути
        /// </summary>
        /// <param name="path">путь до песни</param>
        public void PlayMusic()
        {
            player.URL = songPath;
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

        /// <summary>
        /// Смена песни на альтернативную
        /// </summary>
        public void ChangeSong()
        {
            StopMusic();
            if (songPath == @"song1.m4a")
            {
                Console.WriteLine("Песня изменена на 2!");
                songPath = @"song2.m4a";
            }
            else if (songPath == @"song2.m4a")
            {
                Console.WriteLine("Песня изменена на 1!");
                songPath = @"song1.m4a";
            }
        }
    }
}
