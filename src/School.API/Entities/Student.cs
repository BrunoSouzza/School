using School.API.Entities.Base;

namespace School.API.Entities
{
    public class Student : EntityBase
    {
        public Student(
            string name,
            //int age,
            //int cpf,
            bool registered,
            int courseId)
        {
            Name = name;
            //Age = age;
            //CPF = cpf;
            Registered = registered;
            CourseId = courseId;
        }

        public string Name { get; private set; }
        //public int Age { get; private set; }
        //public int CPF { get; private set; }
        public bool Registered { get; private set; }
        public int CourseId { get; private set; }
        public Course Course { get; private set; }

        public override void Update(
            string name,
            bool registered)
        {
            Name = name;
            Registered = registered;
        }
    }
}
