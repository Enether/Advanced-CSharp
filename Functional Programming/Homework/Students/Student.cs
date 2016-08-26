using System.Collections.Generic;

namespace Students
{
    public class Student
    {
        public Student(string firstName, string lastName, byte age, int facultyNumber, string phone, string email, IList<int> marks, int groupNumber, string groupName)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            FacultyNumber = facultyNumber;
            Phone = phone;
            Email = email;
            Marks = marks;
            GroupNumber = groupNumber;
            FullName = firstName + " " + lastName;
            GroupName = groupName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public byte Age { get; set; }
        public int FacultyNumber { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public IList<int> Marks { get; set; }
        public int GroupNumber { get; set; }
        public string GroupName { get; set; }
    }
}
