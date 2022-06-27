using School.API.Models;

namespace School.API.Helper.Student.Strategy.Strategies
{
    public class MaxNameLengthStrategy : IValidateStudentStrategy
    {
        public Task<bool> ConditionAsync(StudentAddModel studentModel)
        {
            var hasNameMax = studentModel.Name.Length > 30;
            return Task.FromResult(hasNameMax);
        }

        public string ExecuteStrategy()
        {
            return $"Student name must not be longer than 30 characters.";
        }
    }
}
