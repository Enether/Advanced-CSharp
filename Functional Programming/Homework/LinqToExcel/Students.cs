namespace LinqToExcel
{
    public class Students
    {
        public Students(int id, string firstName, string lastName, string email, string gender, string studentType, int examResult, int homeworkSent, int homeworkEvaluated, double teamwork, int attendances, double bonus, double result)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Gender = gender;
            StudentType = studentType;
            ExamResult = examResult;
            HomeworkSent = homeworkSent;
            HomeworkEvaluated = homeworkEvaluated;
            Teamwork = teamwork;
            Attendances = attendances;
            Bonus = bonus;
            Result = result;
        }
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string StudentType { get; set; }
        public int ExamResult { get; set; }
        public int HomeworkSent { get; set; }
        public int HomeworkEvaluated { get; set; }
        public double Teamwork { get; set; }
        public int Attendances { get; set; }
        public double Bonus { get; set; }
        public double Result { get; set; }

    }
}
