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
    }
}