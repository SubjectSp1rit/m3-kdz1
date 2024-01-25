using static ClassLibrary.InputData;
using static ClassLibrary.JsonParser;
using static ClassLibrary.DataMethods;
using static ClassLibrary.Projects;
using static ClassLibrary.OutputData;
using static ClassLibrary.Music;
using System.Collections.Generic;
using ClassLibrary;

public class Program
{
    public static void Main()
    {
        Music music = new Music();
        do
        {
            string? filePath = default;
            var data = new List<Dictionary<string, dynamic>>();
            /*string path = GetFilePath();*/
            int mainMenuIndex = MainMenu();
            switch (mainMenuIndex)
            {
                case 1: data = MainMenuFirst(); break;
                case 2: data = MainMenuSecond(out filePath); break;
                case 3: music.PlayMusic(@"song.m4a"); break;
                case 4: music.StopMusic(); break;
            }

            if (mainMenuIndex == 3 || mainMenuIndex == 4)
            {
                Console.WriteLine("Нажмите любую клавишу для возврата в меню.");
                continue;
            }

            var exemplares = CreateProjectsExemplares(data);

            int filterMenuIndex = FilterMenu();
            switch (filterMenuIndex)
            {
                case 1: FilterMenu1(exemplares); break;
                case 2: FilterMenu2(exemplares); break;
                case 3: FilterMenu3(exemplares); break;
                case 4: FilterMenu4(exemplares); break;
                case 5: FilterMenu5(exemplares); break;
                case 6: FilterMenu6(exemplares); break;
                case 7: FilterMenu7(exemplares); break;
                case 8: FilterMenu8(exemplares); break;
                case 9: FilterMenu9(exemplares); break;
                case 10: FilterMenu10(exemplares); break;
                case 11: FilterMenu11(exemplares); break;
                case 12: FilterMenu12(exemplares); break;
                case 13: FilterMenu13(exemplares); break;
                case 14: FilterMenu14(exemplares); break;
                case 15: FilterMenu15(exemplares); break;
                case 16: FilterMenu16(exemplares); break;
                case 17: FilterMenu17(exemplares); break;
                case 18: FilterMenu18(exemplares); break;
                case 19: FilterMenu19(exemplares); break;
                case 20: FilterMenu20(exemplares); break;
                case 21: FilterMenu21(exemplares); break;
            }
            Console.WriteLine("Нажмите любую клавишу для перехода в меню сохранения.");
            Console.ReadKey();

            if (mainMenuIndex == 1)
            {
                int saveMenuIndex = SaveMenuWithoutOriginalFile();
                switch (saveMenuIndex)
                {
                    case 3: SaveMenu3(exemplares); break;
                    case 4: SaveMenu4(exemplares); break;
                }
            }
            else if (mainMenuIndex == 2)
            {
                int saveMenuIndex = SaveMenuFull();
                switch (saveMenuIndex)
                {
                    case 1: SaveMenu1(filePath, exemplares); break;
                    case 2: SaveMenu2(filePath, exemplares); break;
                    case 3: SaveMenu3(exemplares); break;
                    case 4: SaveMenu4(exemplares); break;
                }
            }
            Console.WriteLine("Нажмите ESC для выхода из программы; иначе - любую другую.");

        } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
    }
}