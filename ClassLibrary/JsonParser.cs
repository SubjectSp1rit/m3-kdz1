using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using static ClassLibrary.DataMethods;

namespace ClassLibrary
{
    /// <summary>
    /// Работа с JSON-данными
    /// </summary>
    public static class JsonParser
    {
        /// <summary>
        /// Конвертирует список экземпляров класса в готовый JSON-формат
        /// </summary>
        /// <param name="projects">Список экземпляров класса</param>
        /// <returns>Строку - готовые данные для занесения в файл в формате JSON</returns>
        public static string WriteJson(List<Projects> projects)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("[");

                for (int i = 0; i < projects.Count; i++)
                {
                    var project = projects[i];
                    sb.AppendLine("  {");
                    sb.AppendLine($"    \"project_id\": {project.ProjectId},");
                    sb.AppendLine($"    \"project_name\": \"{project.ProjectName}\",");
                    sb.AppendLine($"    \"client\": \"{project.Client}\",");
                    sb.AppendLine($"    \"start_date\": \"{project.StartDate}\",");
                    sb.AppendLine($"    \"status\": \"{project.Status}\",");
                    sb.AppendLine($"    \"team_members\": [{string.Join(", ", Array.ConvertAll(project.Members, member => $"{member}"))}],");
                    sb.AppendLine($"    \"tasks\": [{string.Join(", ", Array.ConvertAll(project.Tasks, task => $"{task}"))}]");
                    sb.Append("  }");

                    if (i < projects.Count - 1)
                    {
                        sb.AppendLine(",");
                    }
                    else
                    {
                        sb.AppendLine();
                    }
                }

                sb.AppendLine("]");
                return sb.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла неизвестная ошибка: {ex.Message}");
                return default;
            }
        }

        /// <summary>
        /// Конвертирует прочитанные данные из файла типа string в список словарей
        /// </summary>
        /// <param name="dataFromFile">Данные из файла типа string</param>
        /// <returns></returns>
        public static List<Dictionary<string, dynamic>> ReadJson(string dataFromFile)
        {
            try
            {
                var data = new List<Dictionary<string, dynamic>>();

                string pattern = "\"project_id\":\\s*(\\d+),\\s*" +
                                 "\"project_name\":\\s*\"([^\"]*)\",\\s*" +
                                 "\"client\":\\s*\"([^\"]*)\",\\s*" +
                                 "\"start_date\":\\s*\"([^\"]*)\",\\s*" +
                                 "\"status\":\\s*\"([^\"]*)\",\\s*" +
                                 "\"team_members\":\\s*\\[([^\\]]*)\\],\\s*" +
                                 "\"tasks\":\\s*\\[([^\\]]*)\\]";
                var regex = new Regex(pattern);
                foreach (Match match in regex.Matches(dataFromFile))
                {
                    var teamMembersString = match.Groups[6].Value;
                    var tasksString = match.Groups[7].Value;

                    // Преобразование team_members и tasks из string в List<string>
                    var teamMembers = teamMembersString.Split(',', StringSplitOptions.RemoveEmptyEntries);
                    var tasks = tasksString.Split(',', StringSplitOptions.RemoveEmptyEntries);

                    // Очистка списков team_members и tasks от кавычек и лишних символов
                    for (int i = 0; i < teamMembers.Length; i++)
                    {
                        teamMembers[i] = teamMembers[i].Trim(new char[] { ' ', '\t', '\n', '\r' });
                    }
                    for (int i = 0; i < tasks.Length; i++)
                    {
                        tasks[i] = tasks[i].Trim(new char[] { ' ', '\t', '\n', '\r' });
                    }
                    teamMembers = teamMembers.Select(s => s.Replace("\n", "").Replace("\r", "").Replace(" ", "")).ToArray();
                    tasks = tasks.Select(s => s.Replace("\n", "").Replace("\r", "").Replace(" ", "")).ToArray();

                    var dict = new Dictionary<string, dynamic>
                    {
                        {"project_id", match.Groups[1].Value},
                        {"project_name", match.Groups[2].Value},
                        {"client", match.Groups[3].Value},
                        {"start_date", match.Groups[4].Value},
                        {"status", match.Groups[5].Value},
                        {"team_members", teamMembers},
                        {"tasks", tasks}
                    };
                    data.Add(dict);
                }
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла неизвестная ошибка: {ex.Message}");
                return new List<Dictionary<string, dynamic>>();
            }
        }
    }
}
