using System.IO;
using System.Text;
using static ClassLibrary.InputData;
using static ClassLibrary.JsonParser;
using static ClassLibrary.DataMethods;
using System.Security.Cryptography.X509Certificates;
using System.Globalization;

namespace ClassLibrary
{
    public class OutputData
    {
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

        public static int SaveMenuFull()
        {
            // Элементы главного меню.
            string[] menuItems = { "1. Сохранить данные в исходный файл с удалением.",
                                   "2. Сохранить данные в исходный файл с добавлением в конец.",
                                   "3. Сохранить данные в другой файл с удалением.",
                                   "4. Сохранить данные в другой файл с добавленим в конец."
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

        public static int SaveMenuWithoutOriginalFile()
        {
            // Элементы главного меню.
            string[] menuItems = { "1. Сохранить данные в другой файл с удалением.",
                                   "2. Сохранить данные в другой файл с добавленим в конец."
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

        public static List<Dictionary<string, dynamic>> MainMenuFirst()
        {
            Console.WriteLine("Введите данные JSON-файла ниже:");
            string data = GetData();
            List<Dictionary<string, dynamic>> convertedData = ReadJson(data);
            return convertedData;
        }

        public static List<Dictionary<string, dynamic>> MainMenuSecond(out string filePath)
        {
            /*string filePath = GetFilePath();*/
            filePath = @"D:/Other/data_7V.json";

            using var reader = new StreamReader(filePath);
            Console.SetIn(reader);
            string data = GetData();
            List<Dictionary<string, dynamic>> convertedData = ReadJson(data);
            Console.SetIn(new StreamReader(Console.OpenStandardInput()));
            return convertedData;
        }

        public static void FilterMenu1(List<Projects> exemplares)
        {
            exemplares.Sort((x, y) => x.ProjectId.CompareTo(y.ProjectId));
            PrintExemplares(exemplares, 1);
        }

        public static void FilterMenu2(List<Projects> exemplares)
        {
            exemplares.Sort((x, y) => y.ProjectId.CompareTo(x.ProjectId));
            PrintExemplares(exemplares, 1);
        }

        public static void FilterMenu3(List<Projects> exemplares)
        {
            exemplares.Sort((x, y) => x.ProjectName.CompareTo(y.ProjectName));
            PrintExemplares(exemplares, 2);
        }

        public static void FilterMenu4(List<Projects> exemplares)
        {
            exemplares.Sort((x, y) => y.ProjectName.CompareTo(x.ProjectName));
            PrintExemplares(exemplares, 2);
        }

        public static void FilterMenu5(List<Projects> exemplares)
        {
            exemplares.Sort((x, y) => x.Client.CompareTo(y.Client));
            PrintExemplares(exemplares, 3);
        }

        public static void FilterMenu6(List<Projects> exemplares)
        {
            exemplares.Sort((x, y) => y.Client.CompareTo(x.Client));
            PrintExemplares(exemplares, 3);
        }

        public static void FilterMenu7(List<Projects> exemplares)
        {
            exemplares.Sort((x, y) => DateTime.Parse(x.StartDate).CompareTo(DateTime.Parse(y.StartDate)));
            PrintExemplares(exemplares, 4);
        }

        public static void FilterMenu8(List<Projects> exemplares)
        {
            exemplares.Sort((x, y) => DateTime.Parse(y.StartDate).CompareTo(DateTime.Parse(x.StartDate)));
            PrintExemplares(exemplares, 4);
        }

        public static void FilterMenu9(List<Projects> exemplares)
        {
            exemplares.Sort((x, y) => x.Status.CompareTo(y.Status));
            PrintExemplares(exemplares, 5);
        }

        public static void FilterMenu10(List<Projects> exemplares)
        {
            exemplares.Sort((x, y) => y.Status.CompareTo(x.Status));
            PrintExemplares(exemplares, 5);
        }

        public static void FilterMenu11(List<Projects> exemplares)
        {
            exemplares.Sort((x, y) => x.Members.Length.CompareTo(y.Members.Length));
            PrintExemplares(exemplares, 6);
        }

        public static void FilterMenu12(List<Projects> exemplares)
        {
            exemplares.Sort((x, y) => y.Members.Length.CompareTo(x.Members.Length));
            PrintExemplares(exemplares, 6);
        }

        public static void FilterMenu13(List<Projects> exemplares)
        {
            exemplares.Sort((x, y) => x.Tasks.Length.CompareTo(y.Tasks.Length));
            PrintExemplares(exemplares, 7);
        }

        public static void FilterMenu14(List<Projects> exemplares)
        {
            exemplares.Sort((x, y) => y.Tasks.Length.CompareTo(x.Tasks.Length));
            PrintExemplares(exemplares, 7);
        }

        public static void FilterMenu15(List<Projects> exemplares)
        {
            int filterInteger = GetFilterInteger();
            exemplares.RemoveAll(p => p.ProjectId != filterInteger);
            PrintExemplares(exemplares);
        }

        public static void FilterMenu16(List<Projects> exemplares)
        {
            string filterString = GetFilterString().ToLower();
            exemplares.RemoveAll(p => p.ProjectName.ToLower() != filterString);
            PrintExemplares(exemplares);
        }

        public static void FilterMenu17(List<Projects> exemplares)
        {
            string filterString = GetFilterString().ToLower();
            exemplares.RemoveAll(p => p.Client.ToLower() != filterString);
            PrintExemplares(exemplares);
        }
        public static void FilterMenu18(List<Projects> exemplares)
        {
            string filterString = GetFilterString();
            exemplares.RemoveAll(p => p.StartDate != filterString);
            PrintExemplares(exemplares);
        }
        public static void FilterMenu19(List<Projects> exemplares)
        {
            string filterString = GetFilterString().ToLower();
            exemplares.RemoveAll(p => p.Status.ToLower() != filterString);
            PrintExemplares(exemplares);
        }
        public static void FilterMenu20(List<Projects> exemplares)
        {
            int filterInteger = GetFilterInteger();
            exemplares.RemoveAll(p => p.Members.Length != filterInteger);
            PrintExemplares(exemplares);
        }
        public static void FilterMenu21(List<Projects> exemplares)
        {
            int filterInteger = GetFilterInteger();
            exemplares.RemoveAll(p => p.Tasks.Length != filterInteger);
            PrintExemplares(exemplares);
        }

        public static void SaveMenu1(string filePath, List<Projects> exemplares)
        {
            Console.WriteLine("Данные успешно сохранены!");
        }

        public static void SaveMenu2(string filePath, List<Projects> exemplares)
        {
            Console.WriteLine("Данные успешно сохранены!");
        }

        public static void SaveMenu3(List<Projects> exemplares)
        {
            Console.WriteLine("Данные успешно сохранены!");
        }

        public static void SaveMenu4(List<Projects> exemplares)
        {
            Console.WriteLine("Данные успешно сохранены!");
        }

        private static void PrintExemplares(List<Projects> projects, int n = 0)
        {
            if (projects.Count == 0)
            {
                Console.WriteLine("Oops...Нет данных для вывода.");
                return;
            }
            int projectIdWidth = projects.Max(p => p.ProjectId.ToString().Length) + 2;
            int projectNameWidth = projects.Max(p => p.ProjectName.Length) + 2;
            int clientWidth = projects.Max(p => p.Client.Length) + 2;
            int startDateWidth = projects.Max(p => p.StartDate.Length) + 2;
            int statusWidth = projects.Max(p => p.Status.Length) + 2;
            int membersWidth = projects.Max(p => p.Members.Max(m => m.Length)) + 2;
            int tasksWidth = projects.Max(p => p.Tasks.Max(t => t.Length)) + 2;

            // Заголовки столбцов
            string[] headers = { "ID", "Name", "Client", "Start Date", "Status", "Members", "Tasks" };
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

        static void PrintColored(string text, int width, int columnNumber, int highlightColumn)
        {
            if (columnNumber == highlightColumn) Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(text.PadRight(width));
            Console.ResetColor();
        }
    }
}
