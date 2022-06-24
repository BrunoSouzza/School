using School.API.Entities;

namespace School.API.Models
{
    public class CourseAddModel
    {
        public CourseAddModel(string name)
        {
            Name = name;
        }
        public string Name { get; private set; }

        public static implicit operator CourseAddModel(Course course) => new CourseAddModel(course.Name);

        public static implicit operator Course(CourseAddModel courseAddModel) => new Course(courseAddModel.Name);
    }
}
