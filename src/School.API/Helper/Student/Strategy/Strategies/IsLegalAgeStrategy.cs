using School.API.Models;

namespace School.API.Helper.Student.Strategy.Strategies
{
    public class IsLegalAgeStrategy : IValidateStudentStrategy
    {
        public Task<bool> ConditionAsync(StudentAddModel studentModel)
        {
            Random random = new Random();
            var hasNameMax = random.Next(36) >= 18; //Simulate age
            return Task.FromResult(hasNameMax);
        }

        public string ExecuteStrategy()
        {
            return $"Student is not 18 years old.";
        }
    }
}