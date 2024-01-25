using System.IO;
using System.Text;
using static ClassLibrary.InputData;
using static ClassLibrary.JsonParser;
using static ClassLibrary.DataMethods;
using System.Security.Cryptography.X509Certificates;
using System.Globalization;

namespace ClassLibrary
{
    /// <summary>
    /// Работает с выводом информации в консоль
    /// </summary>
    public class OutputData
    {
        /// <summary>
        /// Главное меню
        /// </summary>
        /// <returns>Число - НОМЕР нажатой кнопки</returns>
        public static int MainMenu()
        {
            // Элементы главного меню.
            string[] menuItems = { "1. Ввести данные через консоль.",
                                   "2. Ввести путь до файла с данными.",
                                   "3. Включить музыку.",
                                   "4. Выключить музыку."
            };
            int selectedIndex = 0;
            ConsoleKey keyPressed;

            // Пользователь перемещается по меню стрелочками вверх и вниз, нажатием Enter выбирает пункт меню.
            do
            {
                Console.Clear();
                Console.WriteLine("=====================================================================");
                Console.WriteLine("|                       МЕНЮ ВЫБОРА ДЕЙСТВИЙ                        |");
                Console.WriteLine("=====================================================================");
                for (int i = 0; i < menuItems.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("> ");
                        Console.Write(menuItems[i]);
                        Console.WriteLine(" < ");
                        Console.ResetColor();
                        continue;
                    }
                    Console.Write("  ");
                    Console.WriteLine(menuItems[i]);
                    Console.ResetColor();
                }

                Console.WriteLine("=====================================================================");

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                keyPressed = keyInfo.Key;

                // Обрабатываем нажатые пользователем кнопки.

                // Двигаемся вверх по меню при нажатой стрелочке вверх.
                if (keyPressed == ConsoleKey.UpArrow)
                {
                    selectedIndex--;
                    if (selectedIndex < 0)
                    {
                        selectedIndex = menuItems.Length - 1;
                    }
                }
                // Двигаемся вниз по меню при нажатой стрелочке вниз.
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    selectedIndex++;
                    if (selectedIndex >= menuItems.Length)
                    {
                        selectedIndex = 0;
                    }
                }

            } while (keyPressed != ConsoleKey.Enter);

            // Возвращаем номер нажатой кнопки (индекс + 1)
            Console.Clear();
            return selectedIndex + 1;
        }

        /// <summary>
        /// Меню фильтров
        /// </summary>
        /// <returns>Число - НОМЕР нажатой кнопки</returns>
        public static int FilterMenu()
        {
            // Элементы главного меню.
            string[] menuItems = { "1. Отсортировать по полю project_id в порядке возрастания.",
                                   "2. Отсортировать по полю project_id в порядке убывания.",
                                   "3. Отсортировать по полю project_name в порядке возрастания.",
                                   "4. Отсортировать по полю project_name в порядке убывания.",
                                   "5. Отсортировать по полю client в порядке возрастания.",
                                   "6. Отсортировать по полю client в порядке убывания.",
                                   "7. Отсортировать по полю start_date в порядке возрастания.",
                                   "8. Отсортировать по полю start_date в порядке убывания.",
                                   "9. Отсортировать по полю status в порядке возрастания.",
                                   "10. Отсортировать по полю status в порядке убывания.",
                                   "11. Отсортировать по полю team_members в порядке возрастания.",
                                   "12. Отсортировать по полю team_members в порядке убывания.",
                                   "13. Отсортировать по полю tasks в порядке возрастания.",
                                   "14. Отсортировать по полю tasks в порядке убывания.",
                                   "15. Отфильтровать по полю project_id.",
                                   "16. Отфильтровать по полю project_name.",
                                   "17. Отфильтровать по полю client.",
                                   "18. Отфильтровать по полю start_date.",
                                   "19. Отфильтровать по полю status.",
                                   "20. Отфильтровать по полю team_members (количеству).",
                                   "21. Отфильтровать по полю tasks (количеству)."
            };
            int selectedIndex = 0;
            ConsoleKey keyPressed;

            // Пользователь перемещается по меню стрелочками вверх и вниз, нажатием Enter выбирает пункт меню.
            do
            {
                Console.Clear();
                Console.WriteLine("=====================================================================");
                Console.WriteLine("|                       МЕНЮ ВЫБОРА ФИЛЬТРОВ                        |");
                Console.WriteLine("=====================================================================");
                for (int i = 0; i < menuItems.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("> ");
                        Console.Write(menuItems[i]);
                        Console.WriteLine(" < ");
                        Console.ResetColor();
                        continue;
                    }
                    Console.Write("  ");
                    Console.WriteLine(menuItems[i]);
                    Console.ResetColor();
                }

                Console.WriteLine("=====================================================================");

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                keyPressed = keyInfo.Key;

                // Обрабатываем нажатые пользователем кнопки.

                // Двигаемся вверх по меню при нажатой стрелочке вверх.
                if (keyPressed == ConsoleKey.UpArrow)
                {
                    selectedIndex--;
                    if (selectedIndex < 0)
                    {
                        selectedIndex = menuItems.Length - 1;
                    }
                }
                // Двигаемся вниз по меню при нажатой стрелочке вниз.
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    selectedIndex++;
                    if (selectedIndex >= menuItems.Length)
                    {
                        selectedIndex = 0;
                    }
                }

            } while (keyPressed != ConsoleKey.Enter);

            // Возвращаем номер нажатой кнопки (индекс + 1)
            Console.Clear();
            return selectedIndex + 1;
        }

        /// <summary>
        /// Меню сохранения (полное)
        /// </summary>
        /// <returns>Число - НОМЕР нажатой кнопки</returns>
        public static int SaveMenuFull()
        {
            // Элементы главного меню.
            string[] menuItems = { "1. Сохранить данные в исходный файл с удалением.",
                                   "2. Сохранить данные в другой файл с удалением.",
            };
            int selectedIndex = 0;
            ConsoleKey keyPressed;

            // Пользователь перемещается по меню стрелочками вверх и вниз, нажатием Enter выбирает пункт меню.
            do
            {
                Console.Clear();
                Console.WriteLine("=====================================================================");
                Console.WriteLine("|                          МЕНЮ СОХРАНЕНИЯ                          |");
                Console.WriteLine("=====================================================================");
                for (int i = 0; i < menuItems.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("> ");
                        Console.Write(menuItems[i]);
                        Console.WriteLine(" < ");
                        Console.ResetColor();
                        continue;
                    }
                    Console.Write("  ");
                    Console.WriteLine(menuItems[i]);
                    Console.ResetColor();
                }

                Console.WriteLine("=====================================================================");

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                keyPressed = keyInfo.Key;

                // Обрабатываем нажатые пользователем кнопки.

                // Двигаемся вверх по меню при нажатой стрелочке вверх.
                if (keyPressed == ConsoleKey.UpArrow)
                {
                    selectedIndex--;
                    if (selectedIndex < 0)
                    {
                        selectedIndex = menuItems.Length - 1;
                    }
                }
                // Двигаемся вниз по меню при нажатой стрелочке вниз.
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    selectedIndex++;
                    if (selectedIndex >= menuItems.Length)
                    {
                        selectedIndex = 0;
                    }
                }

            } while (keyPressed != ConsoleKey.Enter);

            // Возвращаем номер нажатой кнопки (индекс + 1)
            Console.Clear();
            return selectedIndex + 1;
        }

        /// <summary>
        /// Меню сохранения (без возможности сохранить в исходный файл)
        /// </summary>
        /// <returns>Число - НОМЕР нажатой кнопки</returns>
        public static int SaveMenuWithoutOriginalFile()
        {
            // Элементы главного меню.
            string[] menuItems = { "1. Сохранить данные в другой файл с удалением.",
            };
            int selectedIndex = 0;
            ConsoleKey keyPressed;

            // Пользователь перемещается по меню стрелочками вверх и вниз, нажатием Enter выбирает пункт меню.
            do
            {
                Console.Clear();
                Console.WriteLine("=====================================================================");
                Console.WriteLine("|                          МЕНЮ СОХРАНЕНИЯ                          |");
                Console.WriteLine("=====================================================================");
                for (int i = 0; i < menuItems.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("> ");
                        Console.Write(menuItems[i]);
                        Console.WriteLine(" < ");
                        Console.ResetColor();
                        continue;
                    }
                    Console.Write("  ");
                    Console.WriteLine(menuItems[i]);
                    Console.ResetColor();
                }

                Console.WriteLine("=====================================================================");

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                keyPressed = keyInfo.Key;

                // Обрабатываем нажатые пользователем кнопки.

                // Двигаемся вверх по меню при нажатой стрелочке вверх.
                if (keyPressed == ConsoleKey.UpArrow)
                {
                    selectedIndex--;
                    if (selectedIndex < 0)
                    {
                        selectedIndex = menuItems.Length - 1;
                    }
                }
                // Двигаемся вниз по меню при нажатой стрелочке вниз.
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    selectedIndex++;
                    if (selectedIndex >= menuItems.Length)
                    {
                        selectedIndex = 0;
                    }
                }

            } while (keyPressed != ConsoleKey.Enter);

            // Возвращаем номер нажатой кнопки (индекс + 1)
            Console.Clear();
            return selectedIndex + 1;
        }

        /// <summary>
        /// Ввод данных JSON файла вручную в консоль
        /// </summary>
        /// <returns>Список словарей, полученный путем преобразования JSON</returns>
        public static List<Dictionary<string, dynamic>> MainMenuFirst()
        {
            Console.WriteLine("Введите данные JSON-файла ниже:");
            // Получение данных из консоли
            string data = GetData();
            // Преобразование string-данных в список словарей
            List<Dictionary<string, dynamic>> convertedData = ReadJson(data);
            return convertedData;
        }

        /// <summary>
        /// Ввод данных JSON файла через файл
        /// </summary>
        /// <returns>Список словарей, полученный путем преобразования JSON</returns>
        public static List<Dictionary<string, dynamic>> MainMenuSecond(out string filePath)
        {
            /*filePath = GetFilePath();*/
            filePath = @"D:/Other/data_7V2.json";

            // Перенаправление потока ввода
            using var reader = new StreamReader(filePath, Encoding.UTF8);
            Console.SetIn(reader);
            // Получение данных
            string data = GetData();
            // Преобразование string-данных в список словарей
            List<Dictionary<string, dynamic>> convertedData = ReadJson(data);
            // Возвращение стандартного потока ввода в консоль
            Console.SetIn(new StreamReader(Console.OpenStandardInput()));
            return convertedData;
        }

        /// <summary>
        /// Отсортировать по полю project_id в порядке возрастания
        /// </summary>
        /// <param name="exemplares">Список экземпляров класса Projects</param>
        public static void FilterMenu1(List<Projects> exemplares)
        {
            exemplares.Sort((x, y) => x.ProjectId.CompareTo(y.ProjectId));
            PrintExemplares(exemplares, 1);
        }

        /// <summary>
        /// Отсортировать по полю project_id в порядке убывания
        /// </summary>
        /// <param name="exemplares">Список экземпляров класса Projects</param>
        public static void FilterMenu2(List<Projects> exemplares)
        {
            exemplares.Sort((x, y) => y.ProjectId.CompareTo(x.ProjectId));
            PrintExemplares(exemplares, 1);
        }

        /// <summary>
        /// Отсортировать по полю project_name в порядке возрастания
        /// </summary>
        /// <param name="exemplares">Список экземпляров класса Projects</param>
        public static void FilterMenu3(List<Projects> exemplares)
        {
            exemplares.Sort((x, y) => x.ProjectName.CompareTo(y.ProjectName));
            PrintExemplares(exemplares, 2);
        }

        /// <summary>
        /// Отсортировать по полю project_name в порядке убывания
        /// </summary>
        /// <param name="exemplares">Список экземпляров класса Projects</param>
        public static void FilterMenu4(List<Projects> exemplares)
        {
            exemplares.Sort((x, y) => y.ProjectName.CompareTo(x.ProjectName));
            PrintExemplares(exemplares, 2);
        }

        /// <summary>
        /// Отсортировать по полю client в порядке возрастания
        /// </summary>
        /// <param name="exemplares">Список экземпляров класса Projects</param>
        public static void FilterMenu5(List<Projects> exemplares)
        {
            exemplares.Sort((x, y) => x.Client.CompareTo(y.Client));
            PrintExemplares(exemplares, 3);
        }

        /// <summary>
        /// Отсортировать по полю client в порядке убывания
        /// </summary>
        /// <param name="exemplares">Список экземпляров класса Projects</param>
        public static void FilterMenu6(List<Projects> exemplares)
        {
            exemplares.Sort((x, y) => y.Client.CompareTo(x.Client));
            PrintExemplares(exemplares, 3);
        }

        /// <summary>
        /// Отсортировать по полю start_date в порядке возрастания
        /// </summary>
        /// <param name="exemplares">Список экземпляров класса Projects</param>
        public static void FilterMenu7(List<Projects> exemplares)
        {
            exemplares.Sort((x, y) => DateTime.Parse(x.StartDate).CompareTo(DateTime.Parse(y.StartDate)));
            PrintExemplares(exemplares, 4);
        }

        /// <summary>
        /// Отсортировать по полю start_date в порядке убывания
        /// </summary>
        /// <param name="exemplares">Список экземпляров класса Projects</param>
        public static void FilterMenu8(List<Projects> exemplares)
        {
            exemplares.Sort((x, y) => DateTime.Parse(y.StartDate).CompareTo(DateTime.Parse(x.StartDate)));
            PrintExemplares(exemplares, 4);
        }

        /// <summary>
        /// Отсортировать по полю status в порядке возрастания
        /// </summary>
        /// <param name="exemplares">Список экземпляров класса Projects</param>
        public static void FilterMenu9(List<Projects> exemplares)
        {
            exemplares.Sort((x, y) => x.Status.CompareTo(y.Status));
            PrintExemplares(exemplares, 5);
        }

        /// <summary>
        /// Отсортировать по полю status в порядке убывания
        /// </summary>
        /// <param name="exemplares">Список экземпляров класса Projects</param>
        public static void FilterMenu10(List<Projects> exemplares)
        {
            exemplares.Sort((x, y) => y.Status.CompareTo(x.Status));
            PrintExemplares(exemplares, 5);
        }

        /// <summary>
        /// Отсортировать по полю team_members в порядке возрастания
        /// </summary>
        /// <param name="exemplares">Список экземпляров класса Projects</param>
        public static void FilterMenu11(List<Projects> exemplares)
        {
            exemplares.Sort((x, y) => x.Members.Length.CompareTo(y.Members.Length));
            PrintExemplares(exemplares, 6);
        }

        /// <summary>
        /// Отсортировать по полю team_members в порядке убывания
        /// </summary>
        /// <param name="exemplares">Список экземпляров класса Projects</param>
        public static void FilterMenu12(List<Projects> exemplares)
        {
            exemplares.Sort((x, y) => y.Members.Length.CompareTo(x.Members.Length));
            PrintExemplares(exemplares, 6);
        }

        /// <summary>
        /// Отсортировать по полю tasks в порядке возрастания
        /// </summary>
        /// <param name="exemplares">Список экземпляров класса Projects</param>
        public static void FilterMenu13(List<Projects> exemplares)
        {
            exemplares.Sort((x, y) => x.Tasks.Length.CompareTo(y.Tasks.Length));
            PrintExemplares(exemplares, 7);
        }

        /// <summary>
        /// Отсортировать по полю tasks в порядке убывания
        /// </summary>
        /// <param name="exemplares">Список экземпляров класса Projects</param>
        public static void FilterMenu14(List<Projects> exemplares)
        {
            exemplares.Sort((x, y) => y.Tasks.Length.CompareTo(x.Tasks.Length));
            PrintExemplares(exemplares, 7);
        }

        /// <summary>
        /// Отфильтровать по полю project_id
        /// </summary>
        /// <param name="exemplares">Список экземпляров класса Projects</param>
        public static void FilterMenu15(List<Projects> exemplares)
        {
            int filterInteger = GetFilterInteger();
            exemplares.RemoveAll(p => p.ProjectId != filterInteger);
            PrintExemplares(exemplares, 1);
        }

        /// <summary>
        /// Отфильтровать по полю project_name
        /// </summary>
        /// <param name="exemplares">Список экземпляров класса Projects</param>
        public static void FilterMenu16(List<Projects> exemplares)
        {
            string filterString = GetFilterString().ToLower();
            exemplares.RemoveAll(p => p.ProjectName.ToLower() != filterString);
            PrintExemplares(exemplares, 2);
        }

        /// <summary>
        /// Отфильтровать по полю client
        /// </summary>
        /// <param name="exemplares">Список экземпляров класса Projects</param>
        public static void FilterMenu17(List<Projects> exemplares)
        {
            string filterString = GetFilterString().ToLower();
            exemplares.RemoveAll(p => p.Client.ToLower() != filterString);
            PrintExemplares(exemplares, 3);
        }

        /// <summary>
        /// Отфильтровать по полю start_date
        /// </summary>
        /// <param name="exemplares">Список экземпляров класса Projects</param>
        public static void FilterMenu18(List<Projects> exemplares)
        {
            string filterString = GetFilterString();
            exemplares.RemoveAll(p => p.StartDate != filterString);
            PrintExemplares(exemplares, 4);
        }

        /// <summary>
        /// Отфильтровать по полю status
        /// </summary>
        /// <param name="exemplares">Список экземпляров класса Projects</param>
        public static void FilterMenu19(List<Projects> exemplares)
        {
            string filterString = GetFilterString().ToLower();
            exemplares.RemoveAll(p => p.Status.ToLower() != filterString);
            PrintExemplares(exemplares, 5);
        }

        /// <summary>
        /// Отфильтровать по полю team_members (количеству)
        /// </summary>
        /// <param name="exemplares">Список экземпляров класса Projects</param>
        public static void FilterMenu20(List<Projects> exemplares)
        {
            int filterInteger = GetFilterInteger();
            exemplares.RemoveAll(p => p.Members.Length != filterInteger);
            PrintExemplares(exemplares, 6);
        }

        /// <summary>
        /// Отфильтровать по полю tasks (количеству)
        /// </summary>
        /// <param name="exemplares">Список экземпляров класса Projects</param>
        public static void FilterMenu21(List<Projects> exemplares)
        {
            int filterInteger = GetFilterInteger();
            exemplares.RemoveAll(p => p.Tasks.Length != filterInteger);
            PrintExemplares(exemplares, 7);
        }

        /// <summary>
        /// Сохранить данные в исходный файл с удалением
        /// </summary>
        /// <param name="filePath">Исходный путь</param>
        /// <param name="exemplares">Список экземпляров класса Projects</param>
        public static void SaveMenu1(string filePath, List<Projects> exemplares)
        {   
            TextWriter originalConsoleOut = Console.Out;
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    // Перенаправляем стандартный поток вывода в файл
                    Console.SetOut(writer);

                    // Добавление данных
                    Console.WriteLine(WriteJson(exemplares));
                }
            }
            finally
            {
                // Возвращаем стандартный поток вывода обратно в консоль
                Console.SetOut(originalConsoleOut);
                Console.WriteLine("Данные успешно сохранены!");
            }
        }

        /// <summary>
        /// Сохранить данные в другой файл с удалением
        /// </summary>
        /// <param name="exemplares">Список экземпляров класса Projects</param>
        public static void SaveMenu2(List<Projects> exemplares)
        {
            TextWriter originalConsoleOut = Console.Out;
            string filePath = GetFilePath();
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    // Перенаправляем стандартный поток вывода в файл
                    Console.SetOut(writer);

                    // Добавление данных
                    Console.WriteLine(WriteJson(exemplares));
                }
            }
            finally
            {
                // Возвращаем стандартный поток вывода обратно в консоль
                Console.SetOut(originalConsoleOut);
                Console.WriteLine("Данные успешно сохранены!");
            }
        }

        /// <summary>
        /// Выводит список экземпляров класса в виде таблицы, где 
        /// n - НОМЕР столбца, который надо выделить цветом
        /// </summary>
        /// <param name="projects"></param>
        /// <param name="n"></param>
        private static void PrintExemplares(List<Projects> projects, int n = 0)
        {
            // Если данные отсутствуют - метод завершает работу
            if (projects.Count == 0)
            {
                Console.WriteLine("Oops...Нет данных для вывода.");
                return;
            }

            // Определение необходимой ширины для каждого столбца (в зависимости от длины самого длинного элемента)
            int projectIdWidth = projects.Max(x => x.ProjectId.ToString().Length) + 2;
            int projectNameWidth = projects.Max(x => x.ProjectName.Length) + 2;
            int clientWidth = projects.Max(x => x.Client.Length) + 2;
            int startDateWidth = projects.Max(x => x.StartDate.Length) + 2;
            int statusWidth = projects.Max(x => x.Status.Length) + 2;
            int membersWidth = projects.Max(x => x.Members.Max(y => y.Length)) + 2;
            int tasksWidth = projects.Max(x => x.Tasks.Max(y => y.Length)) + 2;

            // Заголовки столбцов
            string[] headers = { "ID", "Name", "Client", "Start Date", "Status", "Members", "Tasks" };
            // Ширина столбцов
            int[] columnWidths = { projectIdWidth, projectNameWidth, clientWidth, startDateWidth, statusWidth, membersWidth, tasksWidth };

            // Печать заголовков
            Console.Write("|");
            for (int i = 0; i < headers.Length; i++)
            {
                PrintColored(headers[i], columnWidths[i], i + 1, n);
                Console.Write("|");
            }
            Console.WriteLine();
            Console.WriteLine(new string('-', columnWidths.Sum() + headers.Length));

            // Печать строк таблицы
            foreach (var project in projects)
            {
                int maxRows = Math.Max(project.Members.Length, project.Tasks.Length);
                for (int row = 0; row < maxRows; row++)
                {
                    Console.Write("|");
                    PrintColored(row == 0 ? project.ProjectId.ToString() : "", columnWidths[0], 1, n);
                    Console.Write("|");
                    PrintColored(row == 0 ? project.ProjectName : "", columnWidths[1], 2, n);
                    Console.Write("|");
                    PrintColored(row == 0 ? project.Client : "", columnWidths[2], 3, n);
                    Console.Write("|");
                    PrintColored(row == 0 ? project.StartDate : "", columnWidths[3], 4, n);
                    Console.Write("|");
                    PrintColored(row == 0 ? project.Status : "", columnWidths[4], 5, n);
                    Console.Write("|");
                    PrintColored(row < project.Members.Length ? project.Members[row] : "", columnWidths[5], 6, n);
                    Console.Write("|");
                    PrintColored(row < project.Tasks.Length ? project.Tasks[row] : "", columnWidths[6], 7, n);
                    Console.WriteLine("|");
                }
                Console.WriteLine(new string('-', columnWidths.Sum() + headers.Length));
            }
        }

        /// <summary>
        /// Смена цвета n-го столбца
        /// </summary>
        /// <param name="text"></param>
        /// <param name="width"></param>
        /// <param name="columnNumber"></param>
        /// <param name="highlightColumn"></param>
        private static void PrintColored(string text, int width, int columnNumber, int highlightColumn)
        {
            if (columnNumber == highlightColumn) Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(text.PadRight(width));
            Console.ResetColor();
        }
    }
}
