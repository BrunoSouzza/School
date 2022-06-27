using School.API.Entities;

namespace School.API.Models
{
    public class StudentModel
    {
        public StudentModel(
            int id, 
            string name, 
            bool registered, 
            DateTime register, 
            CourseModel course)
        {
            Id = id;
            Name = name;
            Registered = registered;
            Register = register;
            Course = course;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public bool Registered { get; private set; }
        public DateTime Register { get; private set; }
        public CourseModel Course { get; private set; }

        public static implicit operator StudentModel(Student student) 
            => new StudentModel(student.Id, student.Name, student.Registered, student.Register, student.Course);
    
        public static implicit operator Student(StudentModel studentModel)
            => new Student(studentModel.Name, studentModel.Registered, studentModel.Course.Id);
    }
}
