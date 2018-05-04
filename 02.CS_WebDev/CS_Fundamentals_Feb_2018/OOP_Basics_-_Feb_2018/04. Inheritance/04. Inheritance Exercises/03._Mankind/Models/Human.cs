using System;
using System.Collections.Generic;
using System.Text;

public class Human
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

    private string firstName;
    private string lastName;

    public Human(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public string LastName
    {
        get => this.lastName;

        private set
        {
            if (!char.IsUpper(value[0]))
            {
                throw new ArgumentException(string.Format(InvalidNameBegining, nameof(lastName)));
            }
            if (value.Length < LastNameMinLength)
            {
                throw new ArgumentException(string.Format(InvalidNameLength, LastNameMinLength, nameof(lastName)));
            }

            this.lastName = value;
        }
    }

    public string FirstName
    {
        get => this.firstName;

        private set
        {
            if (!char.IsUpper(value[0]))
            {
                throw new ArgumentException(string.Format(InvalidNameBegining, nameof(firstName)));
            }
            if (value.Length < FirstNameMinLength)
            {
                throw new ArgumentException(string.Format(InvalidNameLength, FirstNameMinLength, nameof(firstName)));
            }

            this.firstName = value;
        }
    }

    public override string ToString()
    {
        var result = new StringBuilder();

        result.AppendLine($"First Name: {this.firstName}");
        result.AppendLine($"Last Name: {this.lastName}");

        return result.ToString();
    }
}
