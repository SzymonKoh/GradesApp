using System;
using System.Collections.Generic;
using System.IO;

namespace GradesApp
{
    class Program
    {
        private static void Main(string[] args)
        {

            bool Exit = false;

            while (!Exit)
            {
                Console.WriteLine($"Hello! Welcome to the Student's Grades Book console.");
                Console.WriteLine($"--------------------Menu-------------------");
                Console.WriteLine($"|         Press 1. Chose Student.         |");
                Console.WriteLine($"|         Press Q. To Exit.               |");
                Console.WriteLine($"-------------------------------------------");

                var userinput = Console.ReadLine();

                switch (userinput)
                {
                    case "1":
                        EnterGradeToStudent();
                        break;

                    case "Q":
                        Exit = true;
                        break;

                    default:
                        Console.WriteLine("Ivalid operation.");
                        continue;
                }
            }
            Console.WriteLine("Bye Bye.");
        }

        private static void EnterGradeToStudent()
        {
            Console.WriteLine("Please insert student's name:");
            string Name = GetValueFromUser("Please insert student's name:");

            if (!string.IsNullOrEmpty(Name))
            {
                var student = new Student(Name);
                student.GradeAdded += GradeAdded;
                student.GradeLowerThen3 += GradeLowerThen3;
                EnterGrade(student);
                student.ShowStatistics();
            }

            else
            {
                Console.WriteLine("Student's name can not be empty!");
            }
        }
        private static void EnterGrade(IStudent student)
        {
            while (true)
            {
                Console.WriteLine($"Hello! Enter grade for: {student.Name}.");
                Console.WriteLine($"Remember that grades of one's student should be from 1 to 6.");
                var input = Console.ReadLine();

                if (input == "q" || "Q" == input)
                {
                    break;
                }

                try
                {
                    student.AddGrade(input);
                }

                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                catch (NullReferenceException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                finally
                {
                    Console.WriteLine($"To exit and view student statisctics for {student.Name} enter 'q/Q'.");
                }
            }
        }

        static void GradeAdded(object sender, EventArgs args)
        {
            Console.WriteLine($"New grade is added.");
        }

        static void GradeLowerThen3(object sender, EventArgs args)
        {
            Console.WriteLine($"Oh no! We should inform student’s parents about this fact.");
        }
        private static string GetValueFromUser(string comment)
        {
            string userInput = Console.ReadLine();
            return userInput;
        }
    }
}