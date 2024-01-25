using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using static ClassLibrary.DataMethods;

namespace ClassLibrary
{
    public static class JsonParser
    {
        public static void WriteJson()
        {
            ;
        }

        public static List<Dictionary<string, dynamic>> ReadJson(string dataFromFile)
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
    }
}
