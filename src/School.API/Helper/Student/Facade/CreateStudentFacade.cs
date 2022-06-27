using School.API.Models;

namespace School.API.Helper.Student.Facade
{
    public class CreateStudentFacade
    {
        private readonly Receita receita;
        private readonly Serasa serasa;
        private readonly SPC spc;

        public CreateStudentFacade()
        {
            this.receita = new Receita();
            this.serasa = new Serasa();
            this.spc = new SPC();
        }

        public bool UnrestrictedStudent(StudentAddModel studentAddModel)
        {
            bool result = true;

            if (!receita.CPFActive(studentAddModel)) result = false;
            if (serasa.CPFHasRestriction(studentAddModel)) result = false;
            if (spc.CPFHasRestriction(studentAddModel)) result = false;

            return result;
        }
    }
}
