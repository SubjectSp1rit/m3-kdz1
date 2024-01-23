namespace ClassLibrary
{
    public class Projects
    {
        int _projectId;
        string? _projectName;
        string? _client;
        string? _startDate;
        string? _status;
        List<string>? _members;
        List<string>? _tasks;

        public int ProjectId
        {
            get { return _projectId; }
            set { _projectId = value; }
        }

        public string? ProjectName
        {
            get { return _projectName; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "Значение ProjectName не может быть null: ");
                }
                else
                {
                    _projectName = value;
                }
            }
        }

        public string? Client
        {
            get { return _client; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "Значение Client не может быть null: ");
                }
                else
                {
                    _client = value;
                }
            }
        }

        public string? StartDate
        {
            get { return _startDate; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "Значение StartDate не может быть null: ");
                }
                else
                {
                    _startDate = value;
                }
            }
        }

        public string? Status
        {
            get { return _status; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "Значение Status не может быть null: ");
                }
                else
                {
                    _status = value;
                }
            }
        }

        public List<string>? Members
        {
            get { return _members; }
            set
            {
                if (value == null || value.Count == 0)
                {
                    throw new ArgumentNullException(nameof(value), "Значение Members не может быть пустым или null: ");
                }
                else
                {
                    _members = value;
                }
            }
        }

        public List<string>? Tasks
        {
            get { return _tasks; }
            set
            {
                if (value == null || value.Count == 0)
                {
                    throw new ArgumentNullException(nameof(value), "Значение Tasks не может быть пустым или null: ");
                }
                else
                {
                    _tasks = value;
                }
            }
        }

        public Projects(int projectId, 
                        string projectName, 
                        string client, 
                        string startDate, 
                        string status, 
                        List<string> members, 
                        List<string> tasks)
        {
            ProjectId = projectId;
            ProjectName = projectName;
            Client = client;
            StartDate = startDate;
            Status = status;
            Members = members;
            Tasks = tasks;
        }
    }
}
