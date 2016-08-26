using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;


namespace LinqToExcel
{
    class LinqToExcel
    {
        static void Main()
        {
            List<Students> students = ReadData();

            var onlineStudents =
                from student in students
                where student.StudentType == "Online"
                orderby student.Result
                select student;

            WriteData(onlineStudents);
            Console.WriteLine("Your Excel Sheet is done!");
                      
        }
        static void WriteData(IOrderedEnumerable<Students> onlineStudents)
        {
            using(FileStream fs = new FileStream(@"..\..\OnlineStudents.xlsx", FileMode.CreateNew, FileAccess.ReadWrite))
            {
                using(ExcelPackage package = new ExcelPackage(fs))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Online Students");

                    using(var range = worksheet.Cells["A1:M2"])
                    {
                        range.Merge = true;
                        range.Value = "Softuni OOP Course Results";
                        range.Style.Font.Bold = true;
                        range.Style.Font.Size = 22;
                        range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    }
                    // create template
                    worksheet.Cells[3, 1].Value = "ID";
                    worksheet.Cells[3, 2].Value = "First Name";
                    worksheet.Cells[3, 3].Value = "Last Name";
                    worksheet.Cells[3, 4].Value = "Email";
                    worksheet.Cells[3, 5].Value = "Gender";
                    worksheet.Cells[3, 6].Value = "Student Type";
                    worksheet.Cells[3, 7].Value = "Exam Result";
                    worksheet.Cells[3, 8].Value = "Homework Sent";
                    worksheet.Cells[3, 9].Value = "Homework Evaluated";
                    worksheet.Cells[3, 10].Value = "Teamwork";
                    worksheet.Cells[3, 11].Value = "Attendances";
                    worksheet.Cells[3, 12].Value = "Bonus";
                    worksheet.Cells[3, 13].Value = "Result";

                    // fix width to make it more appealing
                    worksheet.Column(1).Width = 7;
                    worksheet.Column(2).Width = 12;
                    worksheet.Column(3).Width = 12;
                    worksheet.Column(4).Width = 30;
                    worksheet.Column(5).Width = 9;
                    worksheet.Column(6).Width = 12.14;
                    worksheet.Column(7).Width = 11.43;
                    worksheet.Column(8).Width = 14.57;
                    worksheet.Column(9).Width = 19.43;
                    worksheet.Column(10).Width = 9.57;
                    worksheet.Column(11).Width = 11.43;
                    worksheet.Column(12).Width = 5.71;
                    worksheet.Column(13).Width = 6.29;

                    int iterator = 4;
                    foreach (var student in onlineStudents) // fill in with data
                    {
                        worksheet.Cells[iterator, 1].Value = student.ID;
                        worksheet.Cells[iterator, 2].Value = student.FirstName;
                        worksheet.Cells[iterator, 3].Value = student.LastName;
                        worksheet.Cells[iterator, 4].Value = student.Email;
                        worksheet.Cells[iterator, 5].Value = student.Gender;
                        worksheet.Cells[iterator, 6].Value = student.StudentType;
                        worksheet.Cells[iterator, 7].Value = student.ExamResult;
                        worksheet.Cells[iterator, 8].Value = student.HomeworkSent;
                        worksheet.Cells[iterator, 9].Value = student.HomeworkEvaluated;
                        worksheet.Cells[iterator, 10].Value = student.Teamwork;
                        worksheet.Cells[iterator, 11].Value = student.Attendances;
                        worksheet.Cells[iterator, 12].Value = student.Bonus;
                        worksheet.Cells[iterator, 13].Value = student.Result;

                        iterator++;
                    }
                    using (var range = worksheet.Cells["M:M"]) // colors the result column
                    {
                        range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        range.Style.Fill.BackgroundColor.SetColor(Color.LightGreen);
                    }
                    using (var range = worksheet.Cells[3, 1, 3, 13]) // colors the template row
                    {
                        range.Style.Font.Bold = true;
                        range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        range.Style.Fill.BackgroundColor.SetColor(Color.DarkGreen);
                        range.Style.Font.Color.SetColor(Color.White);
                        var border = range.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                    }

                    package.Save(); //saves the file
                }
            }
        }
        static List<Students> ReadData()
        {
            List<Students> students = new List<Students>();
            using (StreamReader sr = new StreamReader(@"..\..\Students-data.txt")) // reads and parses every line into a list
            {
                sr.ReadLine();
                while (true)
                {
                    string line = sr.ReadLine();

                    if (line == null) // checks to see if we've reached the end of the file
                        break;

                    // breaks the values up and parses them into the List
                    string[] values = line.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    int ID = int.Parse(values[0]);
                    string firstName = values[1];
                    string lastName = values[2];
                    string email = values[3];
                    string gender = values[4];
                    string studentType = values[5];
                    int examResult = int.Parse(values[6]);
                    int homeworkSent = int.Parse(values[7]);
                    int homeworkEvaluated = int.Parse(values[8]);
                    double teamwork = double.Parse(values[9]);
                    int attendances = int.Parse(values[10]);
                    double bonus = double.Parse(values[11]);
                    double result = CalculateResult(examResult, homeworkSent, homeworkEvaluated, teamwork, attendances, bonus);
                    
                    students.Add(new Students(ID, firstName, lastName, email, gender, studentType, examResult, homeworkSent, homeworkEvaluated, teamwork, attendances, bonus, result));
                }
            }
            return students;
        }
        static double CalculateResult(int examResult, int homeworkSent, int homeworkEvaluated, double teamwork, int attendance, double bonus)
        {
            double result = 0.00;

            result = (examResult + homeworkSent + homeworkEvaluated + teamwork + attendance + bonus) / 5;

            return result;
        }
    }
}
