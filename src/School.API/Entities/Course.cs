using School.API.Entities.Base;

namespace School.API.Entities
{
    public class Course : EntityBase
    {
        public Course(
            string name
        )
        {
            Name = name;
        }
        public string Name { get; private set; }
        public ICollection<Student> Students { get; private set; }

        public override void Update(string name, bool registered)
        {
            Name = name;
        }
    }
}
