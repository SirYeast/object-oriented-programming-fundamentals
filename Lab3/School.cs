namespace Lab3
{
    public static class School
    {
        public static readonly HashSet<Student> Students = new();
        public static readonly HashSet<Course> Courses = new();
        public static readonly HashSet<Enrolment> Enrolments = new();

        private static int _courseIdCounter = 100;
        private static int _studentIdCounter = 10;
        private static int _enrolmentIdCounter = 1;

        public static Student? GetStudent(int id)
        {
            foreach (Student student in Students)
                if (student.Id == id)
                    return student;

            return null;
        }

        public static Course? GetCourse(int id)
        {
            foreach (Course course in Courses)
                if (course.Id == id)
                    return course;

            return null;
        }

        public static int CreateStudent(string firstName, string lastName)
        {
            try
            {
                Student newStudent = new(_studentIdCounter, firstName, lastName);
                _studentIdCounter++;

                Students.Add(newStudent);
                return newStudent.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        public static int CreateCourse(string title, int capacity)
        {
            try
            {
                Course newCourse = new(_courseIdCounter, title, capacity);
                _courseIdCounter++;

                Courses.Add(newCourse);
                return newCourse.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        public static void EnrolStudent(int studentId, int courseId)
        {
            Student? student = GetStudent(studentId);

            if (student == null)
                throw new ArgumentException($"Student ({studentId}) does not exist");

            Course? course = GetCourse(courseId);

            if (course == null)
                throw new ArgumentException($"Course ({courseId}) does not exist");

            Enrolment enrolment = new(_enrolmentIdCounter, course, student);

            course.AddEnrolment(enrolment);
            student.CurrentEnrolment = enrolment;

            Enrolments.Add(enrolment);
            _enrolmentIdCounter++;
        }

        public static void UnenrolStudent(int studentId)
        {
            Student? student = GetStudent(studentId);

            if (student == null)
                throw new ArgumentException($"Student ({studentId}) does not exist");

            if (student.CurrentEnrolment == null)
                throw new Exception("Student is not enrolled in any courses");

            Enrolment enrolment = student.CurrentEnrolment;
            enrolment.Course.RemoveEnrolment(enrolment);

            student.CurrentEnrolment = null;
        }
    }
}
