using System.IO;
using System.Text;
using static ClassLibrary.InputData;
using static ClassLibrary.JsonParser;

namespace ClassLibrary
{
    public class OutputData
    {
        public static int MainMenu()
        {
            // Элементы главного меню.
            string[] menuItems = { "1. Ввести данные через консоль.",
                                   "2. Ввести путь до файла с данными.",
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

        public static void MainMenuFirst()
        {
            Console.WriteLine("Введите данные JSON-файла ниже:");
            StringBuilder rawData = new StringBuilder();
            string? element;
            int balance = 0;
            while (true)
            {
                element = Console.ReadLine();
                foreach (var part in element ?? "")
                {
                    if (part == ']')
                    {
                        balance--;
                    }
                    if (part == '[')
                    {
                        balance++;
                    }

                }
                rawData.Append(element);
                if (balance == 0)
                {
                    break;
                }
            }
            string data = rawData.ToString();
            Console.WriteLine(data);
        }

        public static void MainMenuSecond(List<Dictionary<string, dynamic>> dataFromFile)
        {
            /*string filePath = GetFilePath();*/
            string filePath = @"D:/Other/data_7V.json";

            using var reader = new StreamReader(filePath);
            Console.SetIn(reader);
            ReadJson();
            Console.SetIn(new StreamReader(Console.OpenStandardInput()));
        }
    }
}
