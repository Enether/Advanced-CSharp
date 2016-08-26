using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    class MainClass
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            List<Student> students = new List<Student>();
            students.Add(new Student("Stanislav", "Kozlovski", 19, 101714, "+35989468159", "familyguyuser192@hackmail.com", RandomizeMarks(random), 1, "Sharks"));
            students.Add(new Student("Shopa", "Shopov", 19, 120315, "+0295139", "piqkatosvinq@abv.bg", RandomizeMarks(random), 2, "Iraq"));
            students.Add(new Student("Ico", "Shizo", 20, 190216, "+3941239764", "wowimotori@abv.bg", RandomizeMarks(random), 3, "TeTe"));
            students.Add(new Student("Sisko", "Shizo2", 40, 210414, "+359245129764", "aiareni@abv.bg", RandomizeMarks(random), 3, "TeTe"));
            students.Add(new Student("Bagdad", "BashtaTi", 54, 051013, "+31478784", "bagdadbagdad@hotmail.com", RandomizeMarks(random), 4, "AaA"));
            students.Add(new Student("Kiriqka", "Tedo", 14, 140715, "+392165239", "drinkanddrive@kotdoi.bg", RandomizeMarks(random), 4, "AaA"));
            students.Add(new Student("Rozestata", "Glava", 15, 101215, "??????????", "theonewhogotaway@FuckMyLife.com", RandomizeMarks(random), 1, "Sharks"));
            students.Add(new Student("Borislav", "Robev", 25, 310314, "351241543", "robkobobko@hotmail.com", RandomizeMarks(random), 1, "Sharks"));
            students.Add(new Student("Daniel", "Bossa", 36, 030313, "0251364353", "explos1vee@danielindustries.com", RandomizeMarks(random), 2, "Iraq"));

            List<StudentSpecialty> specialties = new List<StudentSpecialty>();
            specialties.Add(new StudentSpecialty("Web Developer", 120315));
            specialties.Add(new StudentSpecialty("Web Developer", 310314));
            specialties.Add(new StudentSpecialty("C# Developer", 101714));
            specialties.Add(new StudentSpecialty("Ruby Developer", 120315));
            specialties.Add(new StudentSpecialty("QA Engineer", 101215));
            specialties.Add(new StudentSpecialty("Senior Java Developer", 140715));
            specialties.Add(new StudentSpecialty("QA Engineer", 210414));

            // Print all students from group number 2. Use a LINQ query. Order the students by FirstName.
            var groupQuery =
                from student in students
                where student.GroupNumber == 2
                orderby student.FirstName
                select new { student.FirstName, student.LastName };
            Console.WriteLine("Students in Group 2:");
            foreach (var student in groupQuery)
            {
                Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
            }
            Console.WriteLine("\n");

            // Print all students whose first name is before their last name alphabetically. Use a LINQ query.
            var firstBeforeLastNameQuery =
                from student in students
                where student.FirstName.CompareTo(student.LastName) < 0
                select student;

            Console.WriteLine("Students whose first name precedes their last name alphabetically:");
            foreach (var student in firstBeforeLastNameQuery)
            {
                Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
            }
            Console.WriteLine("\n");

            // Write a LINQ query that finds the first name and last name of all students with age between 18 and 24. The query should return only the first name, last name and age            
            var ageQuery =
                from student in students
                where student.Age >= 18 && student.Age <= 24
                select new { student.FirstName, student.LastName, student.Age };

            Console.WriteLine("Students between 18 and 24:");
            foreach (var student in ageQuery)
            {
                Console.WriteLine("{0} {1} - {2}years old", student.FirstName, student.LastName, student.Age);
            }
            Console.WriteLine("\n");

            //Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the students by first name and last name in descending order. Rewrite the same with LINQ query syntax.
            var sortedQuery = students.OrderByDescending(student => student.FirstName).ThenByDescending(student => student.LastName);
            var sortedQuery_2 =
                from student in students
                orderby student.FirstName descending, student.LastName descending
                select student;

            Console.WriteLine("Sorted names with lambda expressions:");
            foreach (var student in sortedQuery)
            {
                Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
            }
            Console.WriteLine("\nSorted names with LINQ query:");
            foreach (var student in sortedQuery_2)
            {
                Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
            }
            Console.WriteLine("\n");

            //Print all students that have email @abv.bg. Use LINQ.
            var filteredStudentsByEmail =
                from student in students
                where student.Email.EndsWith("@abv.bg")
                select student;

            Console.WriteLine("Students with email adresses in abv.bg:");
            foreach (var student in filteredStudentsByEmail)
            {
                Console.WriteLine("{0} - {1}", student.FirstName, student.Email);
            }
            Console.WriteLine("\n");

            //Print all students with phones in Sofia (starting with 02 / +3592 / +359 2). Use LINQ.
            var filteredStudentsByPhone =
                from student in students
                where student.Phone.StartsWith("02") ||
                student.Phone.StartsWith("+3592") ||
                student.Phone.StartsWith("+359 2")
                select student;

            Console.WriteLine("Students with phones in Sofia:");
            foreach (var student in filteredStudentsByPhone)
            {
                Console.WriteLine("{0} - {1}", student.FirstName, student.Phone);
            }
            Console.WriteLine("\n");

            //Print all students that have at least one mark Excellent (6). Using LINQ first select them into a new anonymous class that holds { FullName + Marks}.
            var marks =
                from student in students
                select new { student.FullName, student.Marks };

            var filteredByMarks =
                from student in students
                where student.Marks.Contains(6) 
                select student;

            Console.WriteLine("Students that have at least one mark 6:");
            foreach (var student in filteredByMarks)
            {
                Console.WriteLine("{0} - {1}", student.FullName, string.Join(", ", student.Marks));
            }
            Console.WriteLine("\n");

            //Write a similar program to the previous one to extract the students with exactly two marks "2". Use extension methods.
            var weakStudents =
                from student in students
                where student.Marks.ContainsExactlyTwoOf(2)
                select student;

            Console.WriteLine("Students who have weak grades:");
            foreach (var student in weakStudents)
            {
                Console.WriteLine("{0} - {1}", student.FullName, string.Join(", ", student.Marks));
            }
            if(weakStudents.Count() == 0)
                Console.WriteLine("There are no weak students.");
            Console.WriteLine("\n");

            //Extract and print the Marks of the students that enrolled in 2014 (the students from 2014 have 14 as their 5-th and 6-th digit in the FacultyNumber).
            var _2014Students =
                from student in students
                where student.FacultyNumber.ToString()[4] == '1' && student.FacultyNumber.ToString()[5] == '4'
                select student;

            Console.WriteLine("Marks of students who were enrolled in 2014:");
            foreach (var student in _2014Students)
            {
                Console.WriteLine("{0} - {1}",student.FullName,string.Join(", ", student.Marks));
            }
            Console.WriteLine("\n");

            //Add a GroupName property to Student. Write a program that extracts all students grouped by GroupName and then prints them on the console.
            //Print all group names along with the students in each group. Use the "group by into" LINQ operator.
            var groupedStudents =
                from student in students
                group student.FullName by student.GroupName into studentGroup
                select new { studentGroup.Key, studentGroup };

            foreach (var student in groupedStudents)
            {
                Console.WriteLine("{0} - {1}", student.Key, string.Join(", ", student.studentGroup));
            }
            Console.WriteLine("\n");

            //Print all student names alphabetically along with their faculty number and specialty name. Use the "join" LINQ operator
            var studentWithSpecialties =
                from student in students
                join specialty in specialties on student.FacultyNumber equals specialty.FacultyNumber
                orderby specialty.SpecialtyName
                select new { student.FullName, student.FacultyNumber, specialty.SpecialtyName };

            foreach (var student in studentWithSpecialties)
            {
                Console.WriteLine("{0, -25} {1, -10} {2}", student.SpecialtyName, student.FacultyNumber, student.FullName);
            }
        }
        static List<int> RandomizeMarks(Random random)
        {
            List<int> marks = new List<int>();

            for (int i = 0; i < 5; i++)
            {
                marks.Add(random.Next(2, 7));
            }

            return marks;
        }
    }
}
