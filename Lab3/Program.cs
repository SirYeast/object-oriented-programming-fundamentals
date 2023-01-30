using Lab3;

int courseId = School.CreateCourse("Software", 12);
int studentId = School.CreateStudent("John", "Smith");

try
{
    School.EnrolStudent(studentId, courseId);
    Console.WriteLine($"Successfully enroled student ({studentId}) in course ({courseId})");

    School.UnenrolStudent(studentId);
    Console.WriteLine($"Successfully unenroled student ({studentId}) from course");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}