namespace ClassLibrary
{
    /// <summary>
    /// Экземплярный класс, хранящий проекты из JSON файла
    /// </summary>
    public class Projects
    {
        // Поля класса, закрытые для записи вне конструктора класса
        readonly int _projectId; // project_id
        readonly string? _projectName; // project_name
        readonly string? _client; // client
        readonly string? _startDate; // start_date
        readonly string? _status; // status
        readonly string[]? _members; // team_members
        readonly string[]? _tasks; // tasks

        public int ProjectId
        {
            get { return _projectId; }
        }

        public string? ProjectName
        {
            get { return _projectName; }
        }

        public string? Client
        {
            get { return _client; }
        }

        public string? StartDate
        {
            get { return _startDate; }
        }

        public string? Status
        {
            get { return _status; }
        }

        public string[]? Members
        {
            get { return _members; }
        }

        public string[]? Tasks
        {
            get { return _tasks; }
        }

        public Projects(int projectId, 
                        string projectName, 
                        string client, 
                        string startDate, 
                        string status, 
                        string[] members, 
                        string[] tasks)
        {
            _projectId = projectId;
            _projectName = projectName;
            _client = client;
            _startDate = startDate;
            _status = status;
            _members = members;
            _tasks = tasks;
        }
    }
}
