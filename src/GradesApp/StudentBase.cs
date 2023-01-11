using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GradesApp
{
    public abstract class StudentBase : NamedStudent, IStudent
    {
        private List<double> grades = new List<double>();

        public StudentBase(string name) : base(name) { }

        public abstract event GradeAddedDelegate GradeAdded;

        public abstract event GradeAddedDelegate GradeLowerThen3;

        public abstract void AddGrade(string grade);

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();

        public void ShowStatistics()
        {
            var stat = GetStatistics();
            if (stat.Count != 0)
            {
                Console.WriteLine($"{Name} statistics:");
                Console.WriteLine($"Total grades: {stat.Count}");
                Console.WriteLine($"Highest grade: {stat.High:N2}");
                Console.WriteLine($"Lowest grade: {stat.Low:N2}");
                Console.WriteLine($"Average: {stat.Average:N2}");
            }

            else
            {
                Console.WriteLine($"Couldn't get statistics for {this.Name} because no grade has been added.");
            }
        }
    }
}