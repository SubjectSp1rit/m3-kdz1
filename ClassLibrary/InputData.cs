using System.Transactions;

namespace ClassLibrary
{
    public class InputData
    {
        public static string GetFilePath()
        {
            char[] invalidChars = Path.GetInvalidPathChars();

            Console.Write("Введите путь до файла: ");
            string? path = Console.ReadLine();
            while (true)
            {
                if (!path.Intersect(invalidChars).Any() || path == null)
                {
                    break;
                }
                Console.Write("Неправильный путь! Введите путь снова: ");
                path = Console.ReadLine();
            }
            return path;
        }

        public static int GetFilterInteger()
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

        public static string GetFilterString()
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
    }
}