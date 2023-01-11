using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GradesApp
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);
    public class Student : StudentBase
    {
        private List<double> grades;
        private const string filename = "Grades.txt";
        private const string filename2 = "GradesAudit.txt";
        public Student(string name) : base(name)
        {
            grades = new List<double>();
        }
        public override event GradeAddedDelegate GradeAdded;
        public override event GradeAddedDelegate GradeLowerThen3;

        public override void AddGrade(double grade)
        {

            if (grade >= 0 && grade <= 6)
            {
                using (var writer = File.AppendText($"{Name} {filename}"))
                using (var writer2 = File.AppendText($"{Name} {filename2}"))
                {
                    writer.WriteLine(grade);
                    writer2.WriteLine($"Date:{DateTime.Now} Grade:{grade}");

                    if (grade > 0)
                    {
                        GradeAdded(this, new EventArgs());
                    }

                    if (grade < 3)
                    {
                        GradeLowerThen3(this, new EventArgs());
                    }
                }
            }

            else
            {
                throw new ArgumentException($"Invalid argument:{nameof(grade)}. Only grades from 1 to 6 are allowed!");
            }
        }

        public override void AddGrade(string grade)
        {

            double convertedGradeToDouble = char.GetNumericValue(grade[0]);
            if (grade.Length == 2 && char.IsDigit(grade[0]) && grade[0] <= '6' && (grade[1] == '+' || grade[1] == '-'))
            {

                switch (grade[1])
                {
                    case '+':

                        double gradePlus = convertedGradeToDouble + 0.50;

                        if (gradePlus > 1 && gradePlus <= 6)
                        {
                            AddGrade(gradePlus);
                        }

                        else
                        {
                            throw new ArgumentException($"Invalid argument:{nameof(grade)}. Only grades from 1 to 6 are allowed!");
                        }
                        break;

                    case '-':

                        double gradeMinus = convertedGradeToDouble - 0.250;

                        if (gradeMinus > 1 && gradeMinus <= 6)
                        {
                            AddGrade(gradeMinus);
                        }
                        else
                        {
                            throw new ArgumentException($"Invalid argument:{nameof(grade)}. Only grades from 1 to 6 are allowed! ");
                        }
                        break;

                    default:
                        throw new ArgumentException($"Invalid argument:{nameof(grade)}. Only grades from 1 to 6 are allowed!");
                }
            }

            else
            {
                double gradeDouble = 0;
                var isParsed = double.TryParse(grade, out gradeDouble);
                if (isParsed && gradeDouble > 0 && gradeDouble <= 6)
                {
                    AddGrade(gradeDouble);
                }

                else
                {
                    throw new ArgumentException($"Invalid argument:{nameof(grade)}. Only grades from 1 to 6 are allowed!");
                }
            }
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            using (var streamReader = File.OpenText($"{Name} {filename}"))
            {
                while (streamReader.Peek() > 0)
                {
                    var line = streamReader.ReadLine();

                    if (double.TryParse(line, out var number))
                    {
                        result.Add(number);
                    }
                }
            }

            return result;
        }
    }
}
