using static ClassLibrary.InputData;
using static ClassLibrary.JsonParser;
using static ClassLibrary.DataMethods;
using static ClassLibrary.Projects;
using static ClassLibrary.OutputData;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        do
        {
            var data = new List<Dictionary<string, dynamic>>();
            /*string path = GetFilePath();*/
            int mainMenuIndex = MainMenu();
            switch (mainMenuIndex)
            {
                case 1: data = MainMenuFirst(); break;
                case 2: data = MainMenuSecond(); break;
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
            }
            Console.WriteLine("Нажмите ESC для выхода из программы; иначе - любую другую.");
        } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
    }
}