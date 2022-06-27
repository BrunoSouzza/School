using School.API.Models;

namespace School.API.Helper.Student.Strategy.Strategies
{
    public class MinNameLengthStrategy : IValidateStudentStrategy
    {
        public Task<bool> ConditionAsync(StudentAddModel studentAddModel)
        {
            var hasNameMin = studentAddModel.Name.Length < 10;
            return Task.FromResult(hasNameMin);
        }

        public string ExecuteStrategy()
        {
            return $"Student name must not be less than 10 characters";
        }
    }
}
