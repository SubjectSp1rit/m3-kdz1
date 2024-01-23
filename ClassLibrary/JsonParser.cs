using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ClassLibrary
{
    public static class JsonParser
    {
        public static void WriteJson()
        {
            ;
        }

        public static void ReadJson(string path)
        {
            var data = new List<Dictionary<string, dynamic>>();
            string dataFromFile = File.ReadAllText(path);
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
                var dict = new Dictionary<string, dynamic>
                    {
                        {"project_id", int.Parse(match.Groups[1].Value)},
                        {"project_name", match.Groups[2].Value},
                        {"client", match.Groups[3].Value},
                        {"start_date", match.Groups[4].Value},
                        {"status", match.Groups[5].Value},
                        {"team_members", match.Groups[6].Value},
                        {"tasks", match.Groups[7].Value}
                    };
                data.Add(dict);
            }

            foreach (var elem in data)
            {
                foreach (var elem1 in elem)
                {
                    Console.WriteLine(elem1);
                }
            }
        }
    }
}
