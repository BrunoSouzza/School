using School.API.Models;

namespace School.API.Helper.Student.Facade
{
    public class SPC
    {
        public bool CPFHasRestriction(StudentAddModel studentAddModel)
        {
            // Call API Serasa
            Random random = new Random();
            return random.Next(100) >= 50;
        }
    }
}
