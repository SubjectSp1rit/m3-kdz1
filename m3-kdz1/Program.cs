using static ClassLibrary.InputData;
using static ClassLibrary.JsonParser;
using static ClassLibrary.DataMethods;
using static ClassLibrary.Projects;

public class Program
{
    public static void Main()
    {
        do
        {
            /*string path = GetFilePath();*/
            string path = @"D:/Other/data_7V.json";
            ReadJson(path);
        } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
    }
}