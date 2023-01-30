namespace Lab3
{
    public class Student
    {
        private readonly int _id;

        private string _firstName;
        private string _lastName;

        public int Id { get { return _id; } }
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (value.Length < 1)
                    throw new ArgumentException("First name cannot be empty");

                _firstName = value;
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (value.Length < 1)
                    throw new ArgumentException("Last name cannot be empty");

                _lastName = value;
            }
        }

        public Enrolment? CurrentEnrolment { get; set; } 

        public Student(int id, string firstName, string lastName)
        {
            if (id < 1)
                throw new ArgumentException("Id must be greater than zero");

            _id = id;

            FirstName = firstName;
            LastName = lastName;
        }
    }
}
