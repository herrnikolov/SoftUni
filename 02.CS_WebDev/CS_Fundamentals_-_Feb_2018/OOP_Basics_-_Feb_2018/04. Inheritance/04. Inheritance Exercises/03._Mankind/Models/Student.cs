using System;
using System.Collections.Generic;
using System.Text;

    public class Student : Human
    {
        public static readonly int FirstNameMinLength = 4;
        public static readonly int LastNameMinLength = 3;

        public static readonly int FacultyNumberMinimum = 5;
        public static readonly int FacultyNumberMaximum = 10;

        public static readonly decimal MinWeeklySalary = 10.0m;

        public static readonly int MinDailyWorkHours = 1;
        public static readonly int MaxDailyWorkHours = 12;

        public static readonly string InvalidNameLength = "Expected length at least {0} symbols! Argument: {1}";

        public static readonly string InvalidNameBegining = "Expected upper case letter! Argument: {0}";

        public static readonly string InvalidFacultyNumber = "Invalid faculty number!";

        public static readonly string InvalidExpectedValueForWorker = "Expected value mismatch! Argument: {0}";


    private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber)
            : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get => this.facultyNumber;

            private set
            {
                if (value.Length < FacultyNumberMinimum || value.Length > FacultyNumberMaximum)
                {
                    throw new ArgumentException("Invalid faculty number!");
                    //throw new ArgumentException(InvalidFacultyNumber);
                }

                for (int i = 0; i < value.Length; i++)
                {
                    if (!Char.IsLetterOrDigit(value[i]))
                    {
                        throw new ArgumentException("Invalid faculty number!");
                        //throw new ArgumentException(InvalidFacultyNumber);
                    }
                }

                this.facultyNumber = value;
            }
        }

        public override string ToString()
        {
            var result = base.ToString();

            result += $"Faculty number: {this.facultyNumber}";

            return result;
        }

}