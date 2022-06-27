using School.API.Models;

namespace School.API.Helper.Student.Facade
{
    public class Receita
    {
        public bool CPFActive(StudentAddModel studentAddModel)
        {
            // Call API RECEITA
            Random random = new Random();
            return random.Next(100) >= 50;    
        }
    }
}
