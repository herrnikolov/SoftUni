using System;
using System.Collections.Generic;
using System.Text;


public class Worker : Human
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

    private decimal weekSalary;
    private double workHoursPerDay;

    public Worker(string firstName, string lastName, decimal weekSalary, double workHoursPerDay)
        : base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.WorkHoursPerDay = workHoursPerDay;
    }

    public double WorkHoursPerDay
    {
        get => this.workHoursPerDay;

        private set
        {
            if (value < MinDailyWorkHours || value > MaxDailyWorkHours)
            {
                throw new ArgumentException(string.Format(InvalidExpectedValueForWorker, nameof(workHoursPerDay)));
            }

            this.workHoursPerDay = value;
        }
    }

    public decimal WeekSalary
    {
        get => this.weekSalary;

        private set
        {
            if (value <= MinWeeklySalary)
            {
                throw new ArgumentException(string.Format(InvalidExpectedValueForWorker, nameof(weekSalary)));
            }

            this.weekSalary = value;
        }
    }

    private decimal CalculateSalaryPerHour()
    {
        return this.weekSalary / (decimal)(this.workHoursPerDay * 5);
    }

    public override string ToString()
    {
        var result = new StringBuilder();

        result.Append(base.ToString());

        result.AppendLine($"Week Salary: {this.weekSalary:f2}");
        result.AppendLine($"Hours per day: {this.workHoursPerDay:f2}");
        result.AppendLine($"Salary per hour: {this.CalculateSalaryPerHour():f2}");

        return result.ToString().TrimEnd();
    }

}
