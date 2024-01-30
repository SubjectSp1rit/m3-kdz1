using System.Linq;
using System;
using System.Transactions;

namespace ClassLibrary
{
    /// <summary>
    /// Работает с входными данными
    /// </summary>
    public class InputData
    {
        /// <summary>
        /// Ввод пути к файлу
        /// </summary>
        /// <returns>Строка - путь до файла</returns>
        public static string GetFilePath()
        {
            try
            {
                char[] invalidChars = Path.GetInvalidPathChars();

                Console.Write("Введите путь до файла: ");
                string? path = Console.ReadLine();
                while (true)
                {
                    if (path.Intersect(invalidChars).Any() || path == null)
                    {
                        Console.Write("Неправильный путь! Введите путь снова: ");
                        path = Console.ReadLine();
                    }
                    else
                    {
                        break;
                    }
                }
                return path;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при вводе пути: {ex.Message}");
                return "";
            }
        }

        /// <summary>
        /// Ввод числа, по которому будет произведена фильтрация
        /// </summary>
        /// <returns>Число-фильтр</returns>
        public static int GetFilterInteger()
        {
            try
            {
                Console.Write("Введите число: ");
                bool success = int.TryParse(Console.ReadLine(), out int num);
                while (true)
                {
                    if (success)
                    {
                        break;
                    }
                    Console.Write("Ошибка! Введите корректное значение: ");
                    success = int.TryParse(Console.ReadLine(), out num);
                }
                return num;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при вводе числа-фильтра: {ex.Message}");
                return 0;
            }
        }

        /// <summary>
        /// Ввод строки, по которому будет произведена фильтрация
        /// </summary>
        /// <returns>Строка-фильтр</returns>
        public static string GetFilterString()
        {
            try
            {
                Console.Write("Введите строку: ");
                string? word = Console.ReadLine();
                while (true)
                {
                    if (word != null)
                    {
                        break;
                    }
                    Console.Write("Ошибка! Введите корректную строку: ");
                    word = Console.ReadLine();
                }
                return word;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при вводе строки-фильтра: {ex.Message}");
                return "";
            }
        }
    }
}