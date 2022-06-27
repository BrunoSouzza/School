using School.API.Models;

namespace School.API.Helper.Student.Strategy
{
    public class ValidateStudentFactoryStrategy : IValidateStudentFactoryStrategy
    {
        private IEnumerable<IValidateStudentStrategy> _strategies;

        public ValidateStudentFactoryStrategy(
            IEnumerable<IValidateStudentStrategy> strategies)
        {
            _strategies = strategies;
        }

        public async Task<string> ValidateAsync(StudentAddModel studentAddModel)
        {
            string resultMessage = string.Empty;
            foreach (var strategy in _strategies)
            {
                var isMatch = await strategy.ConditionAsync(studentAddModel);
                if (!isMatch)
                {
                    resultMessage += $"{strategy.ExecuteStrategy()}\n";
                    resultMessage = resultMessage.Replace("\n", Environment.NewLine);
                }
            }

            return resultMessage;
        }
    }
}
