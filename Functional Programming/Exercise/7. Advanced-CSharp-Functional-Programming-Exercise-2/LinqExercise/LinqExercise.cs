namespace LinqExercise
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class LinqExercise
    {
        public static void Main()
        {
            const string FilePath = @"../../Students-data.txt";

            List<Student> students = new List<Student>();         

            using(StreamReader sr = new StreamReader(FilePath))
            {
                string line = sr.ReadLine();
                line = sr.ReadLine(); // starts from the line with the student info, first line is the template
                while (line != null)
                {
                    string[] tokens = line.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);

                    int id = int.Parse(tokens[0]);
                    string firstName = tokens[1];
                    string lastName = tokens[2];
                    string email = tokens[3];
                    string gender = tokens[4];
                    string studentType = tokens[5];
                    int examResult = int.Parse(tokens[6]);
                    int homeworksSent = int.Parse(tokens[7]);
                    int homeworksEvaluated = int.Parse(tokens[8]);
                    double teamworkScore = double.Parse(tokens[9]);
                    int attendancesCount = int.Parse(tokens[10]);
                    double bonus = double.Parse(tokens[11]);

                    students.Add(new Student(id, firstName, lastName, email, gender, studentType, examResult, homeworksSent, homeworksEvaluated, teamworkScore, attendancesCount, bonus));

                    line = sr.ReadLine(); 
                }
            }




            var goodGradesQuery =
                from student in students
                where student.Gender == "Male" && student.Bonus > 1.00 && student.StudentType == "Onsite" && student.ExamResult > 200
                orderby student.ExamResult, student.TeamworkScore, student.HomeworksSent descending
                select new { student.FirstName, student.ExamResult, student.Bonus };
            Console.WriteLine("{0}\t{1}\t{2}", "Name", "Exam", "Bonus");
            foreach (var student in goodGradesQuery)
            {
                Console.WriteLine("{0}\t{1}\t{2}", student.FirstName, student.ExamResult, student.Bonus);
            }

        }
    }
}
