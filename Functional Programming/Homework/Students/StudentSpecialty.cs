
namespace Students
{
    public class StudentSpecialty
    {
        public StudentSpecialty(string specialtyName, int facultyNumber)
        {
            SpecialtyName = specialtyName;
            FacultyNumber = facultyNumber;
        }
        public string SpecialtyName { get; set; }
        public int FacultyNumber { get; set; }
    }
}
