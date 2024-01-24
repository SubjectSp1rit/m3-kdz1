using static ClassLibrary.InputData;
using static ClassLibrary.JsonParser;
using static ClassLibrary.DataMethods;
using static ClassLibrary.Projects;
using static ClassLibrary.OutputData;

public class Program
{
    public static void Main()
    {
        do
        {
            var dataFromFile = new List<Dictionary<string, dynamic>>();
            /*string path = GetFilePath();*/
            int mainMenuIndex = MainMenu();
            switch (mainMenuIndex)
            {
                case 1: MainMenuFirst(); break;
                case 2: MainMenuSecond(dataFromFile); break;
            }
            Console.WriteLine("Нажмите ESC для выхода из программы; иначе - любую другую.");
        } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
    }
}