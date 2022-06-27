using School.API.Models;

namespace School.API.Helper.Student.Strategy
{
    public interface IValidateStudentFactoryStrategy
    {
        Task<string> ValidateAsync(StudentAddModel studentAddModel);
    }
}
