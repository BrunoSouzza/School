using School.API.Models;

namespace School.API.Helper.Student.Strategy
{
    public interface IValidateStudentStrategy
    {
        Task<bool> ConditionAsync(StudentAddModel studentModel);
        string ExecuteStrategy();
    }
}
