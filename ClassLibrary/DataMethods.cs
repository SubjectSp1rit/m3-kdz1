using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// Работает с данными
    /// </summary>
    public class DataMethods
    {
        /// <summary>
        /// Собирает данные из консоли
        /// </summary>
        /// <returns></returns>
        public static string GetData()
        {
            try
            {
                StringBuilder rawData = new StringBuilder();
                string? element;
                // Алгоритм ПСП. Когда закрывается последняя квадратная скобка - JSON файл подошел к концу
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
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при вводе данных с консоли: {ex.Message}");
                return "";
            }
        }

        /// <summary>
        /// Создает список экземпляров класса Projects на основании списка словарей
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static List<Projects> CreateProjectsExemplares(List<Dictionary<string, dynamic>> data)
        {
            try
            {
                var exemplares = new List<Projects>();
                foreach (var project in data)
                {
                    int projectId = int.Parse(project["project_id"]);
                    string projectName = project["project_name"];
                    string client = project["client"];
                    string startDate = project["start_date"];
                    string status = project["status"];
                    string[] teamMembers = project["team_members"];
                    string[] tasks = project["tasks"];

                    exemplares.Add(new Projects(projectId, projectName, client, startDate, status, teamMembers, tasks));
                }
                return exemplares;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при создании массива экземпляров: {ex.Message}");
                return new List<Projects>();
            }
        }
    }
}
