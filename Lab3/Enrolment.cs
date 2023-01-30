namespace Lab3
{
    public class Enrolment
    {
        private readonly int _id;
        private readonly Course _course;
        private readonly Student _student;
        private readonly DateTime _enrolmentDate;

        private int _courseGrade = 0;

        public int Id { get { return _id; } }
        public Course Course { get { return _course; } }
        public Student Student { get { return _student; } }
        public int Grade
        {
            get { return _courseGrade; }
            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentException("Grade cannot be less than 0 or greater than 100");

                _courseGrade = value;
            }
        }
        public DateTime EnrolmentDate { get { return _enrolmentDate; } }

        public Enrolment(int id, Course course, Student student)
        {
            _id = id;
            _course = course;
            _student = student;
            _enrolmentDate = DateTime.Now;
        }
    }
}
