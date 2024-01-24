namespace ClassLibrary
{
    public class Projects
    {
        readonly int _projectId;
        readonly string? _projectName;
        readonly string? _client;
        readonly string? _startDate;
        readonly string? _status;
        readonly List<string>? _members;
        readonly List<string>? _tasks;

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

        public List<string>? Members
        {
            get { return _members; }
        }

        public List<string>? Tasks
        {
            get { return _tasks; }
        }

        public Projects(int projectId, 
                        string projectName, 
                        string client, 
                        string startDate, 
                        string status, 
                        List<string> members, 
                        List<string> tasks)
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
