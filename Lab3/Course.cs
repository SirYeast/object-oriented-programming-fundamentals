namespace Lab3
{
    public class Course
    {
        private readonly int _id;
        private readonly int _capacity;
        private readonly HashSet<Enrolment> _enrolments = new();

        private string _title;

        public int Id { get { return _id; } }
        public string Title
        {
            get { return _title; }
            set
            {
                if (value.Length < 3)
                    throw new ArgumentException("Title must be at least 3 characters");

                _title = value;
            }
        }
        public int Capacity { get { return _capacity; } }

        public Course(int id, string title, int capacity)
        {
            if (id < 100)
                throw new Exception("Id must be 100 or greater");

            _id = id;

            Title = title;

            if (capacity < 1)
                throw new ArgumentException("Capacity must be at least 1");

            _capacity = capacity;
        }

        public void AddEnrolment(Enrolment enrolment)
        {
            if (_enrolments.Count == _capacity)
                throw new Exception("Course has reached max capacity");

            if (!_enrolments.Add(enrolment))
                throw new ArgumentException("Enrolment already exists in the course list");
        }

        public void RemoveEnrolment(Enrolment enrolment)
        {
            if (enrolment.Course.Id != _id)
                throw new ArgumentException("Could not find provided enrolment data in course");

            _enrolments.Remove(enrolment);
        }
    }
}
