using School.API.Entities;

namespace School.API.Models
{
    public class StudentAddModel
    {
        public StudentAddModel(
            string name,
            int courseId
            )
        {
            Name = name;
            Registered = true;
            CourseId = courseId;
        }

        public string Name { get; private set; }
        public bool Registered { get; private set; }
        public int CourseId { get; private set; }

        public static implicit operator StudentAddModel(Student student)
            => new StudentAddModel(student.Name, student.CourseId);

        public static implicit operator Student(StudentAddModel studentAddModel)
            => new Student(studentAddModel.Name, studentAddModel.Registered, studentAddModel.CourseId);
    }
}
