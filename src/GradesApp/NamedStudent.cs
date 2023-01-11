using System;
using System.Collections.Generic;
using System.IO;

namespace GradesApp
{
    public class NamedStudent
    {
        public NamedStudent(string name)
        {
            this.Name = name;
        }
        public string Name { get; set; }

        public void ChangeName(string NewName)
        {
            Boolean isDigit = false;

            foreach (var n in NewName)
            {
                if (char.IsDigit(n))
                {
                    isDigit = true;
                    break;
                }
            }

            if (isDigit)
            {
                Console.WriteLine("New name cannot containe numbers. Write new name constructed with letters.");
            }

            else
            {
                this.Name = NewName;
                Console.WriteLine($"The name has been changed correctly; the new name is:{NewName}.");
            }
        }
    }
}