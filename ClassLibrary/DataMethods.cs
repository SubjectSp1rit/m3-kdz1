using System.Text;

namespace ClassLibrary
{
    public class DataMethods
    {
        public static string GetData()
        {
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
            return data;
        }

        public static List<Projects> CreateProjectsExemplares(List<Dictionary<string, dynamic>> data)
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
    }
}
