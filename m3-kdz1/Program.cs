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
        // Создание экземпляра класса для воспроизведения музыки впоследствии
        Music music = new Music();
        do
        {
            string? filePath = default;
            var data = new List<Dictionary<string, dynamic>>();

            // Главное меню
            int mainMenuIndex = MainMenu();
            switch (mainMenuIndex)
            {
                case 1: data = MainMenuFirst(); break;
                case 2: data = MainMenuSecond(out filePath); break;
                case 3: music.PlayMusic(@"song.m4a"); break;
                case 4: music.StopMusic(); break;
            }

            // При вкл/выкл музыку пропускаем выполнение всех следующих действий
            if (mainMenuIndex == 3 || mainMenuIndex == 4)
            {
                Console.WriteLine("Нажмите любую клавишу для возврата в меню.");
                continue;
            }

            // Создание списка экземпляров класса Projects на основании полученных данных
            var exemplares = CreateProjectsExemplares(data);

            // Меню выбора параметров сортировки/фильтрации
            int filterMenuIndex = FilterMenu();
            switch (filterMenuIndex)
            {
                case 1: FilterMenu1(exemplares); break; // Отсортировать по полю project_id в порядке возрастания
                case 2: FilterMenu2(exemplares); break; // Отсортировать по полю project_id в порядке убывания
                case 3: FilterMenu3(exemplares); break; // Отсортировать по полю project_name в порядке возрастания
                case 4: FilterMenu4(exemplares); break; // Отсортировать по полю project_name в порядке убывания
                case 5: FilterMenu5(exemplares); break; // Отсортировать по полю client в порядке возрастания
                case 6: FilterMenu6(exemplares); break; // Отсортировать по полю client в порядке убывания
                case 7: FilterMenu7(exemplares); break; // Отсортировать по полю start_date в порядке возрастания
                case 8: FilterMenu8(exemplares); break; // Отсортировать по полю start_date в порядке убывания
                case 9: FilterMenu9(exemplares); break; // Отсортировать по полю status в порядке возрастания
                case 10: FilterMenu10(exemplares); break; // Отсортировать по полю status в порядке убывания
                case 11: FilterMenu11(exemplares); break; // Отсортировать по полю team_members в порядке возрастания
                case 12: FilterMenu12(exemplares); break; // Отсортировать по полю team_members в порядке убывания
                case 13: FilterMenu13(exemplares); break; // Отсортировать по полю tasks в порядке возрастания
                case 14: FilterMenu14(exemplares); break; // Отсортировать по полю tasks в порядке убывания
                case 15: FilterMenu15(exemplares); break; // Отфильтровать по полю project_id
                case 16: FilterMenu16(exemplares); break; // Отфильтровать по полю project_name
                case 17: FilterMenu17(exemplares); break; // Отфильтровать по полю client
                case 18: FilterMenu18(exemplares); break; // Отфильтровать по полю start_date
                case 19: FilterMenu19(exemplares); break; // Отфильтровать по полю status
                case 20: FilterMenu20(exemplares); break; // Отфильтровать по полю team_members (количеству)
                case 21: FilterMenu21(exemplares); break; // Отфильтровать по полю tasks (количеству)
            }
            Console.WriteLine("Нажмите любую клавишу для перехода в меню сохранения.");
            Console.ReadKey();

            // В зависимости от метода введения данных предлагаем разное меню
            // Если данные введены напрямую в консоль, то сохранить в исходный файл нельзя
            if (mainMenuIndex == 1)
            {
                // Меню сохранения
                int saveMenuIndex = SaveMenuWithoutOriginalFile();
                switch (saveMenuIndex)
                {
                    case 1: SaveMenu2(exemplares); break; // Сохранить данные в другой файл с удалением
                }
            }
            // Если данные введены в консоль из файла, то можно сохранить в исходный файл
            else if (mainMenuIndex == 2)
            {
                // Меню сохранения
                int saveMenuIndex = SaveMenuFull();
                switch (saveMenuIndex)
                {
                    case 1: SaveMenu1(filePath, exemplares); break; // Сохранить данные в исходный файл с удалением
                    case 2: SaveMenu2(exemplares); break; // Сохранить данные в другой файл с удалением
                }
            }
            Console.WriteLine("Нажмите ESC для выхода из программы; иначе - любую другую.");

        } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
    }
}