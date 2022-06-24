using School.API.Entities;

namespace School.API.Models
{
    public class CourseModel
    {
        public CourseModel(
            int id, 
            string name, 
            DateTime register)
        {
            Id = id;
            Name = name;
            Register = register;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Register { get; set; }
        public ICollection<StudentModel> Students { get; set; }

        public static implicit operator CourseModel(Course course) 
            => new CourseModel(course.Id, course.Name, course.Register);

        public static implicit operator Course(CourseModel courseModel)
            => new Course(courseModel.Name);
    }
}
